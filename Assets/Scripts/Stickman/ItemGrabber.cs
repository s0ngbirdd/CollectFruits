using System;
using DG.Tweening;
using Fruits;
using UnityEngine;

namespace Stickman
{
    public class ItemGrabber : MonoBehaviour
    {
        public static event Action OnDropPoint;
    
        [SerializeField] private Transform _handIKTarget;
        [SerializeField] private Transform _dropPoint;
        [SerializeField] private Transform _grabHand;

        [SerializeField] private float _animationDuration = 2f;
    
        private GameObject _aimTarget;

        private Vector3 _startPosition;
        private Tween _tween;
        private bool _isAnimationEnd = true;

        public bool IsAnimationEnd => _isAnimationEnd;

        private void OnEnable()
        {
            FruitPicker.OnFruitGrab += SetAimTarget;
        }

        private void OnDisable()
        {
            FruitPicker.OnFruitGrab -= SetAimTarget;
        }

        private void Start()
        {
            _startPosition = _handIKTarget.position;
        }

        private void SetAimTarget(GameObject gameObject)
        {
            _isAnimationEnd = false;
            _aimTarget = gameObject;

            _tween = _handIKTarget.DOMove(_aimTarget.transform.position, _animationDuration).SetEase(Ease.Linear).OnComplete(() =>
            {
                Destroy(_aimTarget.GetComponent<Rigidbody>());
                _aimTarget.transform.SetParent(_grabHand);
                _aimTarget.transform.localPosition = new Vector3(-0.1f, 0, 0);
                _tween.Kill();

                _tween = _handIKTarget.DOMove(_dropPoint.position, _animationDuration).SetEase(Ease.Linear).OnComplete(() =>
                {
                    _aimTarget.transform.SetParent(ObjectPool.ObjectPool.Instance.gameObject.transform);
                    _aimTarget.AddComponent(typeof(Rigidbody));
                    OnDropPoint?.Invoke();
                    _aimTarget.transform.position = _dropPoint.position;
                    _aimTarget.layer = LayerMask.NameToLayer("Basket");
                    _tween.Kill();

                    _tween = _handIKTarget.DOMove(_startPosition, _animationDuration).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        _isAnimationEnd = true;
                        _tween.Kill();
                    });
                });
            });
        }
    }
}
