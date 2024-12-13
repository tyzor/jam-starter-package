using UnityEngine;
using Utilities.WaitForAnimations.Base;

namespace Utilities.WaitForAnimations
{
    /// <summary>
    /// Sets the Anchor Position of a Rect Transform over time
    /// </summary>
    public class WaitForUIMoveAnimations : WaitForAnimationBase<RectTransform, Vector2>
    {
        public override Coroutine DoAnimation(float time, ANIM_DIR animDir)
        {
            return StartCoroutine(DoAnimationCoroutine(time, animDir));
        }

        protected override Vector2 Lerp(Vector2 start, Vector2 end, float t)
        {
            return Vector2.Lerp(start, end, t);
        }

        protected override void SetValue(AnimationData data, Vector2 value)
        {
            var rectTransform = data.transform;

            rectTransform.anchoredPosition = value;
        }
    }
}
