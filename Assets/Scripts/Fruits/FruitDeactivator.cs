using UnityEngine;

namespace Fruits
{
    public class FruitDeactivator : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.SetActive(false);
        }
    }
}
