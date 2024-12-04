using UnityEngine;
using System.Collections.Generic;

namespace GameSystem.GridSystem
{
    [System.Serializable]
    public class Grid
    {
        [field: SerializeField] public Vector3Int GridSize { get; private set; }
        [field: SerializeField] public Vector3 CentralPoint { get; private set; }

        public Grid(GridSettings settings)
        {
            GridSize = new Vector3Int(
                settings.GridSize.x,
                Mathf.CeilToInt(settings.GridHeight),
                settings.GridSize.y
            );

            CentralPoint = Vector3.zero;
        }

        public Grid()
        {
            GridSize = new Vector3Int(10, 5, 10);
            CentralPoint = Vector3.zero;
        }

        public bool IsPointInsideGrid(Vector3 point)
        {
            Vector3 halfSize = new Vector3(GridSize.x / 2f, GridSize.y, GridSize.z / 2f);
            return point.x >= -halfSize.x && point.x <= halfSize.x &&
                   point.z >= -halfSize.z && point.z <= halfSize.z &&
                   point.y >= 0 && point.y <= GridSize.y;
        }

        public Vector3 SnapToGrid(Vector3 position)
        {
            Vector3 snapped = new Vector3(
                Mathf.Round(position.x),
                Mathf.Round(position.y),
                Mathf.Round(position.z)
            );

            if (IsPointInsideGrid(snapped))
                return snapped;

            return Vector3.zero;
        }

        public List<Vector3> GetAllGridPoints()
        {
            var points = new List<Vector3>();
            Vector3 offset = new Vector3(GridSize.x / 2f, 0f, GridSize.z / 2f);

            for (int y = 0; y < GridSize.y; y++)
            {
                for (int x = 0; x < GridSize.x -1; x++)
                {
                    for (int z = 0; z < GridSize.z - 1; z++)
                    {
                        points.Add(new Vector3(x, y, z) - offset);
                    }
                }
            }

            return points;
        }
    }
}
