using Audio;
using DG.Tweening;
using Objective;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MenuController : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private GameObject _menuUI;
        [SerializeField] private TextMeshProUGUI _levelResultText;
        
        [Header("Objects to deactivate")]
        [SerializeField] private GameObject _objective;
        [SerializeField] private GameObject _timer;
        [SerializeField] private GameObject _conveyor;
        [SerializeField] private GameObject _basket;
        [SerializeField] private GameObject _objectPool;
        
        [Header("Fade")]
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _fadeDuration = 1f;

        private Tween _tween;

        private void OnEnable()
        {
            ObjectiveController.OnLevelComplete += ShowCompleteMenuUI;
            ObjectiveController.OnLevelFailed += ShowFailMenuUI;
        }

        private void OnDisable()
        {
            ObjectiveController.OnLevelComplete -= ShowCompleteMenuUI;
            ObjectiveController.OnLevelFailed -= ShowFailMenuUI;
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        private void ShowCompleteMenuUI()
        {
            AudioManager.Instance.PlayOneShot("LevelComplete");

            _levelResultText.text = "LEVEL PASSED";
            DeactivateObjects();
        
            _menuUI.SetActive(true);
            _tween = _canvasGroup.DOFade(1f, _fadeDuration).OnComplete(() => _tween.Kill());
        }

        private void ShowFailMenuUI()
        {
            AudioManager.Instance.PlayOneShot("LevelFailed");

            _levelResultText.text = "LEVEL FAILED";
            DeactivateObjects();
        
            _menuUI.SetActive(true);
            _tween = _canvasGroup.DOFade(1f, _fadeDuration).OnComplete(() => _tween.Kill());
        }

        private void DeactivateObjects()
        {
            _objective.SetActive(false);
            _timer.SetActive(false);
            _conveyor.SetActive(false);
            _basket.SetActive(false);
            _objectPool.SetActive(false);
        }
    }
}
