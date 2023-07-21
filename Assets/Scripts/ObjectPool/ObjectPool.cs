using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class ObjectPool : MonoBehaviour
    {
        public static ObjectPool Instance;

        [SerializeField] private GameObject _fruitPrefab;
        [SerializeField] private GameObject _collectTextPrefab;
        [SerializeField] private int _poolNumber;

        private List<GameObject> _fruitPooledObjects;
        private List<GameObject> _collectTextPooledObjects;
    
        private GameObject tempObject;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        private void Start()
        {
            _fruitPooledObjects = new List<GameObject>();
            _collectTextPooledObjects = new List<GameObject>();
        
            InstantiateFruits(_poolNumber, _fruitPrefab, _fruitPooledObjects);
            InstantiateFruits(_poolNumber, _collectTextPrefab, _collectTextPooledObjects);
        }
    
        public GameObject GetFruitPooledObject()
        {
            for (int i = 0; i < _fruitPooledObjects.Count; i++)
            {
                if (!_fruitPooledObjects[i].activeInHierarchy)
                {
                    return _fruitPooledObjects[i];
                }
            }

            return InstantiateFruit(_fruitPrefab, _fruitPooledObjects);
        }

        public GameObject GetCollectTextPooledObject()
        {
            for (int i = 0; i < _collectTextPooledObjects.Count; i++)
            {
                if (!_collectTextPooledObjects[i].activeInHierarchy)
                {
                    return _collectTextPooledObjects[i];
                }
            }

            return InstantiateFruit(_collectTextPrefab, _collectTextPooledObjects);
        }

        private void InstantiateFruits(int instantiateNumber, GameObject fruit, List<GameObject> fruitPool)
        {
            for (int i = 0; i < instantiateNumber; i++)
            {
                tempObject = Instantiate(fruit, transform);
                tempObject.SetActive(false);
                fruitPool.Add(tempObject);
            }
        }
    
        private GameObject InstantiateFruit(GameObject fruit, List<GameObject> fruitPool)
        {
            tempObject = Instantiate(fruit, transform);
            tempObject.SetActive(false);
            fruitPool.Add(tempObject);
        
            return tempObject;
        }
    }
}
