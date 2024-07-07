using Core.Scripts.Utils;
using UnityEngine;

namespace Core.Scripts
{
    [RequireComponent(typeof(SphereParticleCollisionControl))]
    public class ExplosionColoredSphereByCube : MonoBehaviour
    {
        [SerializeField] private SphereParticleCollisionControl sphereParticleCollisionControl;
        [SerializeField] private GameObject explosionGoParticles;
        private ParticleSystem[] _explosionParticles;

        private void Start()
        {
            sphereParticleCollisionControl = GetComponent<SphereParticleCollisionControl>();
            _explosionParticles = new ParticleSystem[explosionGoParticles.transform.childCount];
            int k = 0;
            foreach (Transform transParticle in explosionGoParticles.transform)
            {
                _explosionParticles[k++] = transParticle.gameObject.GetComponent<ParticleSystem>();
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out CubeParticleCollisionControl cubeParticleCollisionControl))
            {
                if (sphereParticleCollisionControl.isTargetColor && cubeParticleCollisionControl.isTargetColor)
                {
                    float totalTimeDuration = ParticlesPlayer.PlayParticles(_explosionParticles);
                    explosionGoParticles.transform.SetParent(null);
                    Destroy(explosionGoParticles, totalTimeDuration);
                    Destroy(gameObject);
                }
            }
        }
    }
}