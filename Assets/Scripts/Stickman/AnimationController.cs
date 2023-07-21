using Fruits;
using Objective;
using UnityEngine;

namespace Stickman
{
    [RequireComponent(typeof(Animator))]
    public class AnimationController : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            FruitPicker.OnWrongFruitGrab += PlayWrongItemAnimation;
            ObjectiveController.OnLevelComplete += PlayLevelCompleteAnimation;
            ObjectiveController.OnLevelFailed += PlayLevelFailedAnimation;
        }

        private void OnDisable()
        {
            FruitPicker.OnWrongFruitGrab -= PlayWrongItemAnimation;
            ObjectiveController.OnLevelComplete -= PlayLevelCompleteAnimation;
            ObjectiveController.OnLevelFailed -= PlayLevelFailedAnimation;
        }

        private void PlayLevelCompleteAnimation()
        {
            _animator.SetTrigger("LevelComplete");
        }

        private void PlayLevelFailedAnimation()
        {
            _animator.SetTrigger("LevelFailed");
        }

        private void PlayWrongItemAnimation()
        {
            _animator.SetTrigger("WrongItem");
        }

        private void WrongItemEnd()
        {
            _animator.SetTrigger("WrongItemEnd");
        }
    }
}
