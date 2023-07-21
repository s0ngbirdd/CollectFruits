using System;
using Fruits;
using Stickman;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Objective
{
    public class ObjectiveController : MonoBehaviour
    {
        public static event Action OnPickFruit;
        public static event Action OnLevelComplete;
        public static event Action OnLevelFailed;
        public static event Action OnTimerChanged;

        private string _randomFruit;
        private int _randomNumber;
        private float _timer = 60;

        private string[] _fruits = { "APPLE", "PEACH", "LEMON" };
        private bool _isGameEnd;
        private ItemGrabber _itemGrabber;

        public string RandomFruit => _randomFruit;
        public int RandomNumber => _randomNumber;
        public float Timer => _timer;

        private void OnEnable()
        {
            ItemGrabber.OnDropPoint += DecreaseNumber;
            FruitPicker.OnRightFruit += ChangeTimer;
            FruitPicker.OnWrongFruit += ChangeTimer;
        }

        private void OnDisable()
        {
            ItemGrabber.OnDropPoint -= DecreaseNumber;
            FruitPicker.OnRightFruit -= ChangeTimer;
            FruitPicker.OnWrongFruit -= ChangeTimer;
        }

        private void Start()
        {
            _itemGrabber = FindObjectOfType<ItemGrabber>();

            _randomFruit = _fruits[Random.Range(0, _fruits.Length)];
            _randomNumber = Random.Range(1, 6);
        }

        private void Update()
        {
            CheckLevelEnd();
            ChangeTimer(-Time.deltaTime);
        }

        private void CheckLevelEnd()
        {
            if (RandomNumber <= 0 && !_isGameEnd && _itemGrabber.IsAnimationEnd)
            {
                _isGameEnd = true;
                OnLevelComplete?.Invoke();
            }
            else if (Timer <= 0 && !_isGameEnd)
            {
                _isGameEnd = true;
                OnLevelFailed?.Invoke();
            }
        }

        private void DecreaseNumber()
        {
            _randomNumber--;
            OnPickFruit?.Invoke();
        }

        private void ChangeTimer(float time)
        {
            _timer += time;
            OnTimerChanged?.Invoke();
        }
    }
}
