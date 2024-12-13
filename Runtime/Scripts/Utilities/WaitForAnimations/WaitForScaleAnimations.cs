using UnityEngine;
using Utilities.WaitForAnimations.Base;

namespace Utilities.WaitForAnimations
{
    /// <summary>
    /// Sets the scale of a transform over time
    /// </summary>
    public class WaitForScaleAnimations: WaitForAnimationBase<Transform, Vector3>
    {
        public override Coroutine DoAnimation(float time, ANIM_DIR animDir)
        {
            return StartCoroutine(DoAnimationCoroutine(time, animDir));
        }

        protected override Vector3 Lerp(Vector3 start, Vector3 end, float t)
        {
            return Vector3.Lerp(start, end, t);
        }

        protected override void SetValue(AnimationData data, Vector3 value)
        {
            data.transform.localScale = value;
        }
        
#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            if (objectsToAnimate == null || objectsToAnimate.Length == 0)
                return;
            
            for (int i = 0; i < objectsToAnimate.Length; i++)
            {
                var objectToAnimate = objectsToAnimate[i];
                if(objectToAnimate.transform == null)
                    continue;
                
                var position = objectToAnimate.transform.position;

                Gizmos.color = Color.green;
                Gizmos.DrawWireCube(position, objectToAnimate.start);
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(position, objectToAnimate.end);
            }
        }
#endif
    }
}