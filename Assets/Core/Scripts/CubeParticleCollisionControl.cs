using Core.Scripts.Utils;
using UnityEngine;

namespace Core.Scripts
{
    [RequireComponent(typeof(MeshRenderer))]
    public class CubeParticleCollisionControl : MonoBehaviour
    {
        [SerializeField] private Color targetColor = Color.black;
        [SerializeField] private float colorDelta = 0.05f;
        [SerializeField] private ParticleSystem[] flashParticles;
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
            if (!isTargetColor)
            {
                ParticlesPlayer.PlayParticles(flashParticles, playParticleIfIsPlaying);
            }
        }
    }
}