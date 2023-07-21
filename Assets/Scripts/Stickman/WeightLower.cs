using Objective;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Stickman
{
    [RequireComponent(typeof(TwoBoneIKConstraint))]
    public class WeightLower : MonoBehaviour
    {
        private TwoBoneIKConstraint _twoBoneIKConstraint;

        private void Awake()
        {
            _twoBoneIKConstraint = GetComponent<TwoBoneIKConstraint>();
        }

        private void OnEnable()
        {
            ObjectiveController.OnLevelComplete += SerZeroWeight;
            ObjectiveController.OnLevelFailed += SerZeroWeight;
        }

        private void OnDisable()
        {
            ObjectiveController.OnLevelComplete -= SerZeroWeight;
            ObjectiveController.OnLevelFailed -= SerZeroWeight;
        }

        private void SerZeroWeight()
        {
            _twoBoneIKConstraint.weight = 0;
        }
    }
}
