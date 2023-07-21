using System.Collections;
using UnityEngine;

namespace CollectText
{
    public class CollectText : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 2.0f;
        [SerializeField] private float _timeBeforeDeactivation = 4.0f;
    
        private Camera _camera;

        private void OnEnable()
        {
            StartCoroutine(WaitBeforeDeactivation());
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            LookTowardsCamera();
            MoveUp();
        }

        private void LookTowardsCamera()
        {
            transform.rotation = Quaternion.LookRotation(transform.position - _camera.transform.position);
        }

        private void MoveUp()
        {
            transform.Translate(Vector3.up * (_moveSpeed * Time.deltaTime));
        }

        private IEnumerator WaitBeforeDeactivation()
        {
            yield return new WaitForSeconds(_timeBeforeDeactivation);

            gameObject.SetActive(false);
        }
    }
}
