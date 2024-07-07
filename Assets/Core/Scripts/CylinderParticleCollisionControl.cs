using UnityEngine;

namespace Core.Scripts
{
    [RequireComponent(typeof(MeshRenderer))]
    public class CylinderParticleCollisionControl : MonoBehaviour
    {
        [SerializeField] private Color targetColor = Color.blue;
        [SerializeField] private float colorDelta = 0.01f;
        [SerializeField] private ParticleSystem sparkParticleSystem;
        private MeshRenderer _meshRenderer;

        private void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        private void OnParticleCollision(GameObject other)
        {
            _meshRenderer.material.color = Color.Lerp(_meshRenderer.material.color, targetColor, colorDelta);
            sparkParticleSystem.Play();
        }
    }
}