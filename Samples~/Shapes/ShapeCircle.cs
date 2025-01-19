using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

namespace SpriteShapes
{
    [ExecuteInEditMode]
    public class ShapeCircle : MonoBehaviour
    {

        [SerializeField]
        [Range(0, 0.5f)]
        private float _outerRadius = 0.5f;
        public float OuterRadius
        {
            get => _outerRadius;
            set
            {
                _outerRadius = value;
                if (_material)
                    _material.SetFloat("_OuterRadius", OuterRadius);
            }
        }

        [SerializeField]
        [Range(0, 0.5f)]
        private float _innerRadius = 0.2f;
        public float InnerRadius
        {
            get => _innerRadius;
            set
            {
                _innerRadius = value;
                if (_material)
                    _material.SetFloat("_InnerRadius", InnerRadius);
            }
        }

        private Material _material;

        private void OnValidate()
        {
            if (!_material)
            {
                _material = new Material(Shader.Find("Shader Graphs/Shape_Circle_Unlit_Shader"));
            }

            GetComponent<SpriteRenderer>().material = _material;

            _material.SetFloat("_OuterRadius", OuterRadius);
            _material.SetFloat("_InnerRadius", InnerRadius);


        }

    }

}