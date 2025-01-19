using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

namespace SpriteShapes
{
    [ExecuteInEditMode]
    public class ShapeRectangle : MonoBehaviour
    {

        [SerializeField]
        [Range(0, 0.5f)]
        private float _outerHalfWidth = 0.5f;
        public float OuterHalfWidth
        {
            get => _outerHalfWidth;
            set
            {
                _outerHalfWidth = value;
                if (_material)
                    _material.SetFloat("_OuterHalfWidth", OuterHalfWidth);
            }
        }

        [SerializeField]
        [Range(0, 0.5f)]
        private float _outerHalfHeight = 0.5f;
        public float OuterHalfHeight
        {
            get => _outerHalfHeight;
            set
            {
                _outerHalfHeight = value;
                if (_material)
                    _material.SetFloat("_OuterHalfHeight", OuterHalfHeight);
            }
        }

        [SerializeField]
        [Range(0, 0.5f)]
        private float _innerHalfWidth = 0.2f;
        public float InnerHalfWidth
        {
            get => _innerHalfWidth;
            set
            {
                _innerHalfWidth = value;
                if (_material)
                    _material.SetFloat("_InnerHalfWidth", InnerHalfWidth);
            }
        }

        [SerializeField]
        [Range(0, 0.5f)]
        private float _innerHalfHeight = 0.2f;
        public float InnerHalfHeight
        {
            get => _innerHalfHeight;
            set
            {
                _innerHalfHeight = value;
                if (_material)
                    _material.SetFloat("_InnerHalfHeight", InnerHalfHeight);
            }
        }




        private Material _material;

        private void OnValidate()
        {
            if (!_material)
            {
                _material = new Material(Shader.Find("Shader Graphs/Shape_Rect_Unlit_Shader"));
            }

            GetComponent<SpriteRenderer>().material = _material;

            _material.SetFloat("_OuterHalfWidth", OuterHalfWidth);
            _material.SetFloat("_OuterHalfHeight", OuterHalfHeight);
            _material.SetFloat("_InnerHalfWidth", InnerHalfWidth);
            _material.SetFloat("_InnerHalfHeight", InnerHalfHeight);


        }

    }

}