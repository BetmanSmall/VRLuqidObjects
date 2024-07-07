using Core.Scripts.Utils;
using UnityEngine;

namespace Core.Scripts
{
    [RequireComponent(typeof(MeshRenderer))]
    public class ParticleCollisionControl : MonoBehaviour
    {
        [SerializeField] private Color targetColor = Color.white;
        [SerializeField] private float colorDelta = 0.001f;
        [SerializeField] private ParticleSystem[] particleSystems;
        [SerializeField] private bool playParticleIfIsPlaying = true;
        public bool isTargetColor { get; private set; } = false;
        private MeshRenderer _meshRenderer;

        private void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        private void OnParticleCollision(GameObject other)
        {
            _meshRenderer.material.color = Color.Lerp(_meshRenderer.material.color, targetColor, colorDelta);
            isTargetColor = ColorsUtil.ColorEquals(_meshRenderer.material.color, targetColor);
            ParticlesPlayer.PlayParticles(particleSystems, playParticleIfIsPlaying);
        }
    }
}