using System;
using System.Runtime.CompilerServices;

namespace Utilities.Tweening
{
    public enum CURVE
    {
        LINEAR,
        EASE_IN,
        EASE_OUT,
        EASE_IN_OUT,
        
    }

    internal static class CURVEExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float GetT(this CURVE curve, float t)
        {
            t = Math.Clamp(t, 0, 1);
            switch (curve)
            {
                case CURVE.LINEAR:
                    return t;
                case CURVE.EASE_IN:
                    return LerpFunctions.Coserp(0f, 1f, t);
                case CURVE.EASE_OUT:
                    return LerpFunctions.Sinerp(0f, 1f, t);
                case CURVE.EASE_IN_OUT:
                    return LerpFunctions.Hermite(0f, 1f, t);
                default:
                    throw new ArgumentOutOfRangeException(nameof(curve), curve, null);
            }
        }
    }
}