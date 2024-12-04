using UnityEngine;
using Sirenix.OdinInspector;

namespace GameSystem.GridSystem
{
    [CreateAssetMenu]
    public class GridSettings : SerializedScriptableObject
    {
        [field: SerializeField] public Vector2Int GridSize { get; private set; }
        [field: SerializeField] public float GridHeight { get; private set; }
    }
}