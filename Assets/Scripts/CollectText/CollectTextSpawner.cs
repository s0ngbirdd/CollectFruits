using Audio;
using Stickman;
using UnityEngine;

namespace CollectText
{
    public class CollectTextSpawner : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _smokeParticle;

        private void OnEnable()
        {
            ItemGrabber.OnDropPoint += CreateCollectText;
        }

        private void OnDisable()
        {
            ItemGrabber.OnDropPoint -= CreateCollectText;
        }

        private void CreateCollectText()
        {
            AudioManager.Instance.PlayOneShot("AddPoint");
        
            if (!_smokeParticle.isPlaying)
            {
                _smokeParticle.Play();
            }
        
            GameObject collectText = ObjectPool.ObjectPool.Instance.GetCollectTextPooledObject();
            collectText.transform.position = transform.position;
            collectText.transform.rotation = Quaternion.identity;
            collectText.SetActive(true);
        }
    }
}
