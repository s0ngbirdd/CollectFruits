using UnityEngine;

namespace ScriptableObject
{
    [CreateAssetMenu(menuName = "ScriptableObjectFruit/Fruit", fileName = "Fruit")]
    public class ScriptableObjectFruit : UnityEngine.ScriptableObject
    {
        [SerializeField] private Mesh _fruitMesh;
        [SerializeField] private string _fruitTag;

        public Mesh FruitMesh => _fruitMesh;
        public string FruitTag => _fruitTag;
    }
}
