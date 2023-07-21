using DG.Tweening;
using Fruits;
using Objective;
using TMPro;
using UnityEngine;

namespace UI
{
    public class TextController : MonoBehaviour
    {
        [Header("TMPro")]
        [SerializeField] private TextMeshProUGUI _objectiveText;
        [SerializeField] private TextMeshProUGUI _timerText;
        
        [Header("Timer")]
        [SerializeField] private GameObject _increaseText;
        [SerializeField] private GameObject _decreaseText;
        [SerializeField] private float _fadeDuration = 0.3f;
    
        private ObjectiveController _objectiveController;
        private CanvasGroup _increaseTextCanvasGroup;
        private CanvasGroup _decreaseTextCanvasGroup;
        private Tween _increaseTimerTween;
        private Tween _decreaseTimerTween;

        private void OnEnable()
        {
            ObjectiveController.OnPickFruit += DisplayObjective;
            ObjectiveController.OnTimerChanged += DisplayTime;
            FruitPicker.OnRightFruitGrab += ActivateIncreaseTimerText;
            FruitPicker.OnWrongFruitGrab += ActivateDecreaseTimerText;
        }

        private void OnDisable()
        {
            ObjectiveController.OnPickFruit -= DisplayObjective;
            ObjectiveController.OnTimerChanged -= DisplayTime;
            FruitPicker.OnRightFruitGrab -= ActivateIncreaseTimerText;
            FruitPicker.OnWrongFruitGrab -= ActivateDecreaseTimerText;
        }

        private void Start()
        {
            _objectiveController = FindObjectOfType<ObjectiveController>();
            _increaseTextCanvasGroup = _increaseText.GetComponent<CanvasGroup>();
            _decreaseTextCanvasGroup = _decreaseText.GetComponent<CanvasGroup>();
        
            DisplayObjective();
            DisplayTime();
        }

        private void DisplayObjective()
        {
            if (_objectiveController.RandomNumber > 1 && !_objectiveController.RandomFruit.Equals("PEACH"))
            {
                _objectiveText.text = "COLLECT " + _objectiveController.RandomNumber + " " + _objectiveController.RandomFruit + "S";
            }
            else if (_objectiveController.RandomNumber > 1 && _objectiveController.RandomFruit.Equals("PEACH"))
            {
                _objectiveText.text = "COLLECT " + _objectiveController.RandomNumber + " " + _objectiveController.RandomFruit + "ES";
            }
            else
            {
                _objectiveText.text = "COLLECT " + _objectiveController.RandomNumber + " " + _objectiveController.RandomFruit;
            }
        }

        private void DisplayTime()
        {
            _timerText.text = Mathf.Round(_objectiveController.Timer).ToString();
        }
    
        private void ActivateIncreaseTimerText()
        {
            _increaseTimerTween.Kill();
        
            _increaseText.SetActive(true);
            _increaseTimerTween = _increaseTextCanvasGroup.DOFade(1, _fadeDuration).OnComplete(() =>
            {
                _increaseTimerTween.Kill();
                _increaseTimerTween = _increaseTextCanvasGroup.DOFade(0, _fadeDuration).OnComplete(() =>
                {
                    _increaseText.SetActive(false);
                    _increaseTimerTween.Kill();
                });
            });
        }

        private void ActivateDecreaseTimerText()
        {
            _decreaseTimerTween.Kill();
        
            _decreaseText.SetActive(true);
            _decreaseTimerTween = _decreaseTextCanvasGroup.DOFade(1, _fadeDuration).OnComplete(() =>
            {
                _decreaseTimerTween.Kill();
                _decreaseTimerTween = _decreaseTextCanvasGroup.DOFade(0, _fadeDuration).OnComplete(() =>
                {
                    _decreaseText.SetActive(false);
                    _decreaseTimerTween.Kill();
                });
            });
        }
    }
}
