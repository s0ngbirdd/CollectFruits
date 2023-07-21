using UnityEngine;

namespace Conveyor
{
    [RequireComponent(typeof(Rigidbody))]
    public class Conveyor : MonoBehaviour
    {
        [SerializeField] private float _conveyorSpeed = 0.5f;
    
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            MoveConveyor();
        }

        private void MoveConveyor()
        {
            Vector3 position = _rigidbody.position;
            _rigidbody.position += Vector3.back * (_conveyorSpeed * Time.fixedDeltaTime);
            _rigidbody.MovePosition(position);
        }
    }
}
