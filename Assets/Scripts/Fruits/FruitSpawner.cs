using System.Collections;
using ScriptableObject;
using UnityEngine;

namespace Fruits
{
    public class FruitSpawner : MonoBehaviour
    {
        [SerializeField] private ScriptableObjectFruit _fruitApple;
        [SerializeField] private ScriptableObjectFruit _fruitPeach;
        [SerializeField] private ScriptableObjectFruit _fruitLemon;
        [SerializeField] private float _timeBetweenSpawns = 1.5f;
    
        private bool _isCoroutineEnd = true;
    
        private void Update()
        {
            if (_isCoroutineEnd)
            {
                _isCoroutineEnd = false;
                StartCoroutine(WaitBeforeSpawn());
            }
        }
    
        private IEnumerator WaitBeforeSpawn()
        {
            yield return new WaitForSeconds(_timeBetweenSpawns);

            CreateRandomFruit();
            _isCoroutineEnd = true;
        }
    
        private void CreateRandomFruit()
        {
            int randomIndex = Random.Range(0, 3);

            if (randomIndex == 0)
            {
                SpawnApple();
            }
            else if (randomIndex == 1)
            {
                SpawnPeach();
            }
            else if(randomIndex == 2)
            {
                SpawnLemon();
            }
        }

        private void SpawnApple()
        {
            GameObject fruit = ObjectPool.ObjectPool.Instance.GetFruitPooledObject();
            fruit.GetComponent<FruitPicker>().SetFruitBehaviour(_fruitApple);
            fruit.transform.position = transform.position;
            fruit.transform.rotation = Quaternion.identity;
        
            fruit.transform.SetParent(transform);
        
            fruit.SetActive(true);
        }
    
        private void SpawnPeach()
        {
            GameObject fruit = ObjectPool.ObjectPool.Instance.GetFruitPooledObject();
            fruit.GetComponent<FruitPicker>().SetFruitBehaviour(_fruitPeach);
            fruit.transform.position = transform.position;
            fruit.transform.rotation = Quaternion.identity;
        
            fruit.transform.SetParent(transform);
        
            fruit.SetActive(true);
        }
    
        private void SpawnLemon()
        {
            GameObject fruit = ObjectPool.ObjectPool.Instance.GetFruitPooledObject();
            fruit.GetComponent<FruitPicker>().SetFruitBehaviour(_fruitLemon);
            fruit.transform.position = transform.position;
            fruit.transform.rotation = Quaternion.identity;
        
            fruit.transform.SetParent(transform);
        
            fruit.SetActive(true);
        }
    }
}
