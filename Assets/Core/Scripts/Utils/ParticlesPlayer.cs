using UnityEngine;

namespace Core.Scripts.Utils
{
    public class ParticlesPlayer
    {
        public static float PlayParticles(ParticleSystem[] particleSystems, bool playParticleIfIsPlaying = true)
        {
            float particleMainDuration = 0f;
            foreach (var pSystem in particleSystems)
            {
                if (particleMainDuration < pSystem.main.duration) particleMainDuration = pSystem.main.duration;
                if (playParticleIfIsPlaying || !pSystem.isPlaying)
                {
                    pSystem.Play();
                }
            }
            return particleMainDuration;
        }
    }
}