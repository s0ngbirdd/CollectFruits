using UnityEngine;

namespace Fruits
{
    public class WakeUper : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            WakeUp();
        }

        private void WakeUp()
        {
            if (_rigidbody != null && _rigidbody.IsSleeping())
            {
                _rigidbody.WakeUp();
            }
        }
    }
}
