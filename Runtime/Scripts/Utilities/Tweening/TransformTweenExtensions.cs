using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Utilities.Tweening
{
    public static class TransformTweenExtensions
    {
        private static bool _isSetup;
        private static Dictionary<Transform, Coroutine> _activeTweens;

        private static MonoBehaviour TweenController
        {
            get
            {
                if (_isSetup)
                    return _tweenController;
                
                SetupTweenController();
                return _tweenController;
            }
        }
        private static MonoBehaviour _tweenController;


        #region Transform Move

        public static void TweenTo(this Transform transform, Vector3 targetWorldPosition, float time, CURVE curve = CURVE.LINEAR, Action onCompleted = null)
        {
            var coroutine = TweenController.StartCoroutine(WorldMoveCoroutine(transform, targetWorldPosition, time, curve, onCompleted));
            TryAdd(transform, coroutine);
        }
        public static void TweenToLocal(this Transform transform, Vector3 targetLocalPosition, float time, CURVE curve = CURVE.LINEAR, Action onCompleted = null)
        {
            var coroutine = TweenController.StartCoroutine(LocalMoveCoroutine(transform, targetLocalPosition, time, curve, onCompleted));
            TryAdd(transform, coroutine);
        }

        #endregion //Transform Move
        
        #region Transform Rotate

        public static void TweenTo(this Transform transform, Quaternion targetWorldRotation, float time, CURVE curve = CURVE.LINEAR, Action onCompleted = null)
        {
            var coroutine = TweenController.StartCoroutine(WorldRotateCoroutine(transform, targetWorldRotation, time, curve, onCompleted));
            TryAdd(transform, coroutine);
        }
        public static void TweenToLocal(this Transform transform, Quaternion targetLocalRotation, float time, CURVE curve = CURVE.LINEAR, Action onCompleted = null)
        {
            var coroutine = TweenController.StartCoroutine(LocalRotateCoroutine(transform, targetLocalRotation, time, curve, onCompleted));
            TryAdd(transform, coroutine);
        }

        #endregion //Transform Rotate
        
        #region Transform Move|Rotate

        public static void TweenTo(this Transform transform,Vector3 targetWorldPosition,  Quaternion targetWorldRotation, float time, CURVE curve = CURVE.LINEAR, Action onCompleted = null)
        {
            var coroutine = TweenController.StartCoroutine(WorldTRSCoroutine(transform, targetWorldPosition, targetWorldRotation, time, curve, onCompleted));
            TryAdd(transform, coroutine);
        }
        public static void TweenToLocal(this Transform transform,Vector3 targetLocalPosition,  Quaternion targetLocalRotation, float time, CURVE curve = CURVE.LINEAR, Action onCompleted = null)
        {
            var coroutine = TweenController.StartCoroutine(LocalTRSCoroutine(transform, targetLocalPosition, targetLocalRotation, time, curve, onCompleted));
            TryAdd(transform, coroutine);
        }

        #endregion //Transform Move|Rotate

        //TransformTweenExtensions Setup Functions
        //============================================================================================================//
        
        private static void SetupTweenController()
        {
            if (_isSetup)
                throw new Exception();
            
            
            _activeTweens = new Dictionary<Transform, Coroutine>();

            var newObject = new GameObject($"=== {nameof(TweenController).ToUpper()} ===", typeof(TweenController));
            Object.DontDestroyOnLoad(newObject);

            _tweenController = newObject.GetComponent<TweenController>();

            _isSetup = true;
        }

        /// <summary>
        /// This will determine if the transform already has an active Coroutine Active, if so, it will stop the old coroutine,
        /// replacing it with the new one.
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="coroutine"></param>
        private static void TryAdd(Transform transform, Coroutine coroutine)
        {
            if (_activeTweens.TryGetValue(transform, out var oldCoroutine) == false)
            {
                _activeTweens.Add(transform, coroutine);
                return;
            }
            
            //We want to override any active coroutines, with new ones
            TweenController.StopCoroutine(oldCoroutine);
            _activeTweens[transform] = coroutine;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void Cleanup(Transform transform)
        {
            _activeTweens.Remove(transform);
        }

        //Coroutines
        //============================================================================================================//
        
        #region Transform Move

        private static IEnumerator WorldMoveCoroutine(Transform transform, Vector3 targetWorldPosition, float time, CURVE curve, Action onCompletedCallback)
        {
            var startingPos = transform.position;

            for (float t = 0f; t < time; t+=Time.deltaTime)
            {
                transform.position = Vector3.Lerp(startingPos, targetWorldPosition, curve.GetT(t));
                yield return null;
            }

            transform.position = targetWorldPosition;
            Cleanup(transform);
            //We want to call the invoke after the cleanup, in case the user destroys the transform
            onCompletedCallback?.Invoke();
        }
        private static IEnumerator LocalMoveCoroutine(Transform transform, Vector3 targetLocalPosition, float time, CURVE curve, Action onCompletedCallback)
        {
            var startingPos = transform.localPosition;

            for (float t = 0f; t < time; t+=Time.deltaTime)
            {
                transform.localPosition = Vector3.Lerp(startingPos, targetLocalPosition, curve.GetT(t));
                yield return null;
            }

            transform.position = targetLocalPosition;
            Cleanup(transform);
            //We want to call the invoke after the cleanup, in case the user destroys the transform
            onCompletedCallback?.Invoke();
        }

        #endregion //Transform Move
        
        #region Transform Rotate

        private static IEnumerator WorldRotateCoroutine(Transform transform, Quaternion targetRotation, float time, CURVE curve, Action onCompletedCallback)
        {
            var startingRot = transform.rotation;

            for (float t = 0f; t < time; t+=Time.deltaTime)
            {
                transform.rotation = Quaternion.Lerp(startingRot, targetRotation, curve.GetT(t));
                yield return null;
            }

            transform.rotation = targetRotation;
            Cleanup(transform);
            //We want to call the invoke after the cleanup, in case the user destroys the transform
            onCompletedCallback?.Invoke();
        }
        private static IEnumerator LocalRotateCoroutine(Transform transform, Quaternion targetLocalRotation, float time, CURVE curve, Action onCompletedCallback)
        {
            var startingRot = transform.localRotation;

            for (float t = 0f; t < time; t+=Time.deltaTime)
            {
                transform.localRotation = Quaternion.Lerp(startingRot, targetLocalRotation, curve.GetT(t));
                yield return null;
            }

            transform.localRotation = targetLocalRotation;
            Cleanup(transform);
            //We want to call the invoke after the cleanup, in case the user destroys the transform
            onCompletedCallback?.Invoke();
        }

        #endregion //Transform Rotate

        #region Transform Scale

        private static IEnumerator WorldScaleCoroutine(Transform transform, Vector3 targetScale, float time, CURVE curve, Action onCompletedCallback)
        {
            var startingScale = transform.localScale;

            for (float t = 0f; t < time; t+=Time.deltaTime)
            {
                transform.localScale = Vector3.Lerp(startingScale, targetScale, curve.GetT(t));
                yield return null;
            }

            transform.localScale = targetScale;
            Cleanup(transform);
            //We want to call the invoke after the cleanup, in case the user destroys the transform
            onCompletedCallback?.Invoke();
        }

        #endregion //Transform Scale

        #region Transform|Rotate

        private static IEnumerator WorldTRSCoroutine(Transform transform, Vector3 targetWorldPosition, Quaternion targetRotation, float time, CURVE curve, Action onCompletedCallback)
        {
            transform.GetPositionAndRotation(out var startingPos, out var startingRot);

            for (float t = 0f; t < time; t+=Time.deltaTime)
            {
                var dt = curve.GetT(t);
                
                var pos = Vector3.Lerp(startingPos, targetWorldPosition, dt);
                var rot = Quaternion.Lerp(startingRot, targetRotation, dt);
                
                transform.SetPositionAndRotation(pos, rot);
                
                yield return null;
            }

            transform.SetPositionAndRotation(targetWorldPosition, targetRotation);
            
            Cleanup(transform);
            //We want to call the invoke after the cleanup, in case the user destroys the transform
            onCompletedCallback?.Invoke();
        }
        
        private static IEnumerator LocalTRSCoroutine(Transform transform, Vector3 targetLocalPosition, Quaternion targetLocalRotation, float time, CURVE curve, Action onCompletedCallback)
        {
            transform.GetLocalPositionAndRotation(out var startingPos, out var startingRot);

            for (float t = 0f; t < time; t+=Time.deltaTime)
            {
                var dt = curve.GetT(t);
                
                var pos = Vector3.Lerp(startingPos, targetLocalPosition, dt);
                var rot = Quaternion.Lerp(startingRot, targetLocalRotation, dt);
                
                transform.SetLocalPositionAndRotation(pos, rot);
                
                yield return null;
            }

            transform.SetLocalPositionAndRotation(targetLocalPosition, targetLocalRotation);
            
            Cleanup(transform);
            //We want to call the invoke after the cleanup, in case the user destroys the transform
            onCompletedCallback?.Invoke();
        }

        #endregion //Transform|Rotate|Scale
        
    }
}