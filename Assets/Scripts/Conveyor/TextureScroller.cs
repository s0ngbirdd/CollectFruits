using UnityEngine;

namespace Conveyor
{
    [RequireComponent(typeof(MeshRenderer))]
    public class TextureScroller : MonoBehaviour
    {
        [SerializeField] private float _scrollSpeedX = -0.4f;
        [SerializeField] private float _scrollSpeedY = 0;
    
        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        private void Update()
        {
            ScrollTexture();
        }

        private void ScrollTexture()
        {
            _meshRenderer.material.mainTextureOffset = new Vector2(Time.realtimeSinceStartup * _scrollSpeedX, Time.realtimeSinceStartup * _scrollSpeedY);
        }
    }
}
