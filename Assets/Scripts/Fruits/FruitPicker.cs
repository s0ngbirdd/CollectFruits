using System;
using Audio;
using Objective;
using ScriptableObject;
using Stickman;
using UnityEngine;

namespace Fruits
{
    [RequireComponent(typeof(MeshFilter))]
    public class FruitPicker : MonoBehaviour
    {
        public static event Action<GameObject> OnFruitGrab;
        public static event Action OnRightFruitGrab;
        public static event Action OnWrongFruitGrab;
        public static event Action<float> OnRightFruit;
        public static event Action<float> OnWrongFruit;
    
        private ObjectiveController _objectiveController;
        private bool _isFruitGrabbed;
        private ItemGrabber _itemGrabber;

        private MeshFilter _meshFilter;
        private float _changeTimerValue = 3;

        private void Awake()
        {
            _meshFilter = GetComponent<MeshFilter>();
        }

        private void Start()
        {
            _objectiveController = FindObjectOfType<ObjectiveController>();
            _itemGrabber = FindObjectOfType<ItemGrabber>();
        }

        private void OnMouseOver()
        {
            CheckForObjectiveFruit();
        }

        private void CheckForObjectiveFruit()
        {
            if (!_isFruitGrabbed)
            {
                if (Input.GetMouseButtonDown(0) && _objectiveController.RandomFruit.Equals(gameObject.tag) && _itemGrabber.IsAnimationEnd)
                {
                    AudioManager.Instance.PlayOneShot("Grab");
                    OnFruitGrab?.Invoke(gameObject);
                    OnRightFruit?.Invoke(_changeTimerValue);
                    OnRightFruitGrab?.Invoke();
                
                    _isFruitGrabbed = true;
                }
                else if (Input.GetMouseButtonDown(0) && !_objectiveController.RandomFruit.Equals(gameObject.tag))
                {
                    AudioManager.Instance.PlayOneShot("No");
                    OnWrongFruit?.Invoke(-_changeTimerValue);
                    OnWrongFruitGrab?.Invoke();
                
                }
            }
        }

        public void SetFruitBehaviour(ScriptableObjectFruit fruit)
        {
            _meshFilter.mesh = fruit.FruitMesh;
            tag = fruit.FruitTag;
        }
    }
}
