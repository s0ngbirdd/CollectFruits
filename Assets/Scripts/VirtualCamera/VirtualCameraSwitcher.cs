using Objective;
using UnityEngine;

namespace VirtualCamera
{
    public class VirtualCameraSwitcher : MonoBehaviour
    {
        [SerializeField] private GameObject _camera1;
        [SerializeField] private GameObject _camera2;

        private void OnEnable()
        {
            ObjectiveController.OnLevelComplete += SwitchCamera;
            ObjectiveController.OnLevelFailed += SwitchCamera;
        }

        private void OnDisable()
        {
            ObjectiveController.OnLevelComplete -= SwitchCamera;
            ObjectiveController.OnLevelFailed -= SwitchCamera;
        }

        private void SwitchCamera()
        {
            _camera2.SetActive(true);
            _camera1.SetActive(false);
        }
    }
}
