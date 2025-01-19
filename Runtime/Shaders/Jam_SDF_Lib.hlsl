#ifndef JAM_SDF_LIB
#define JAM_SDF_LIB

// uv should be in normalized -0.5 to 0.5 space (1 unit length centered at zero)
void Shape_Circle_float(float2 uv, float radius, out float distance) {

    float dist = length(uv);
    float pwidth = length(float2( ddx(dist), ddy(dist)));
    float alpha = smoothstep(radius, radius - pwidth * 1.5, dist);

    distance = alpha;

}

void Shape_Rectangle_float(float2 uv, float halfWidth, float halfHeight, out float distance)
{
    float2 halfSize = float2(halfWidth,halfHeight);
    float2 componentWiseEdgeDistance = abs(uv) - halfSize;
    //float outsideDistance = length(max(componentWiseEdgeDistance, 0));
    float insideDistance = min(max(componentWiseEdgeDistance.x, componentWiseEdgeDistance.y), 0);
    float pwidth = length(float2( ddx(insideDistance), ddy(insideDistance)));
    float alpha = smoothstep(0,pwidth * 1.5, abs(insideDistance));

    distance = alpha;
}

#endif
