using Objective;
using UnityEngine;

namespace Particle
{
    public class ParticleSystemController : MonoBehaviour
    {
        [SerializeField] private UnityEngine.ParticleSystem _levelCompleteParticle;
        [SerializeField] private UnityEngine.ParticleSystem _levelFailedParticle;

        private void OnEnable()
        {
            ObjectiveController.OnLevelComplete += PlayLevelCompleteParticle;
            ObjectiveController.OnLevelFailed += PlayLevelFailedParticle;
        }

        private void OnDisable()
        {
            ObjectiveController.OnLevelComplete -= PlayLevelCompleteParticle;
            ObjectiveController.OnLevelFailed -= PlayLevelFailedParticle;
        }

        private void PlayLevelCompleteParticle()
        {
            if (!_levelCompleteParticle.isPlaying)
            {
                _levelCompleteParticle.Play();
            }
        }

        private void PlayLevelFailedParticle()
        {
            if (!_levelFailedParticle.isPlaying)
            {
                _levelFailedParticle.Play();
            }
        }
    }
}
