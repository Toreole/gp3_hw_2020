using UnityEngine;

namespace GP3._04_SearchAlgorithms
{
    [CreateAssetMenu]
    public class GridNodeSettings : ScriptableObject
    {
        [SerializeField] 
        private float cost = 1;
        [SerializeField]
        private Color color = Color.white;

        public float Cost => cost;
        public Color Color => color;
    }

}