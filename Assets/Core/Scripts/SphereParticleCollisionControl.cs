using Core.Scripts.Utils;
using UnityEngine;

namespace Core.Scripts
{
    [RequireComponent(typeof(MeshRenderer))]
    public class SphereParticleCollisionControl : MonoBehaviour
    {
        [SerializeField] private Vector3 scale = Vector3.one * 0.1f;
        [SerializeField] private float scaleChangeSpeed = 1f;
        [SerializeField] private Color targetColor = Color.green;
        [SerializeField] private float colorDelta = 0.025f;
        [SerializeField] private ParticleSystem smokeParticleSystem;
        public bool isTargetColor { get; private set; }
        private MeshRenderer _meshRenderer;

        private void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        private void OnParticleCollision(GameObject other)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, scale, scaleChangeSpeed * Time.deltaTime);
            _meshRenderer.material.color = Color.Lerp(_meshRenderer.material.color, targetColor, colorDelta);
            isTargetColor = ColorsUtil.ColorEquals(_meshRenderer.material.color, targetColor);
            smokeParticleSystem.Play();
        }
    }
}