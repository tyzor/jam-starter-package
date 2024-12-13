using UnityEngine;

namespace Utilities.Animations
{
    /// <summary>
    /// Type of Simple animator that PingPongs the rotation & Scale of an object
    /// </summary>
    public class PingPongAnimator : MonoBehaviour
    {
        [SerializeField, Min(0)]
        private float speed;
        private float _current;

        [SerializeField, Header("Rotation")] private bool useRotation;
        [SerializeField]
        private Vector3 startRotation, endRotation;
        [SerializeField, Header("Scale")] private bool useScale;
        [SerializeField]
        private Vector3 startScale, endScale;
        
        [SerializeField, Header("Position")] 
        private bool usePosition;
        [SerializeField]
        private Vector3 startPosition, endPosition;

        [SerializeField, Space(10f)]
        private AnimationCurve curve;
        // Start is called before the first frame update// Update is called once per frame
        private void Update()
        {
            _current += Time.deltaTime * speed;
            var t = curve.Evaluate(Mathf.PingPong(_current, 1f));

            if(usePosition)
                transform.position = Vector3.Lerp(startPosition, endPosition, t);
            
            if(useScale)
                transform.localScale = Vector3.Lerp(startScale, endScale, t);
            
            if(useRotation)
                transform.rotation = Quaternion.Euler(Vector3.Lerp(startRotation, endRotation, t));
        }
    }
}
