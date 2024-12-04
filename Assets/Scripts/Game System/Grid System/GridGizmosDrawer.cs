using UnityEngine;

namespace GameSystem.GridSystem
{
    [System.Serializable]
    public class GridGizmosDrawer
    {
        [SerializeField] private Color lineColor;
        [SerializeField] private Color cornerPointColor;
        [SerializeField] private Color edgePointColor;

        [SerializeField, Min(-1)] private int drawHeight;
        [SerializeField] private bool fillHorizontalBetweenLayers;
        [SerializeField] private bool fillVerticalBetweenLayers;

        public void DrawGizmos(Grid grid)
        {
            if (grid == null) return;

            Vector3Int gridSize = grid.GridSize;

            drawHeight = Mathf.Clamp(drawHeight, -1, gridSize.y);
            int maxHeight = drawHeight == -1 ? gridSize.y : Mathf.Min(drawHeight, gridSize.y);

            for (int y = 0; y <= maxHeight; y++)
            {
                if (fillHorizontalBetweenLayers || (y == 0 || y == maxHeight))
                    DrawLayer(y, gridSize);

                if (y < maxHeight)
                    DrawVerticalConnections(y, gridSize);
            }
        }

        private void DrawLayer(int layerY, Vector3Int gridSize)
        {
            Vector3 offset = new Vector3(gridSize.x / 2f, 0f, gridSize.z / 2f);

            for (int x = 0; x < gridSize.x + 1; x++)
            {
                for (int z = 0; z < gridSize.z + 1; z++)
                {
                    Vector3 point = new Vector3(x, layerY, z) - offset;

                    bool isCorner = IsCornerPoint(x, z, gridSize);
                    Gizmos.color = isCorner ? cornerPointColor : edgePointColor;
                    Gizmos.DrawSphere(point, 0.1f);

                    if (x < gridSize.x)
                    {
                        Gizmos.color = lineColor;
                        Gizmos.DrawLine(point, point + Vector3.right);
                    }
                    if (z < gridSize.z)
                    {
                        Gizmos.color = lineColor;
                        Gizmos.DrawLine(point, point + Vector3.forward);
                    }
                }
            }
        }

        private void DrawVerticalConnections(int layerY, Vector3Int gridSize)
        {
            Vector3 offset = new Vector3(gridSize.x / 2f, 0f, gridSize.z / 2f);

            for (int x = 0; x < gridSize.x + 1; x++)
            {
                for (int z = 0; z < gridSize.z + 1; z++)
                {
                    if (fillVerticalBetweenLayers
                        || x == 0 || x == gridSize.x
                        || z == 0 || z == gridSize.z)
                    {
                        Vector3 bottomPoint = new Vector3(x, layerY, z) - offset;
                        Vector3 topPoint = bottomPoint + Vector3.up;

                        Gizmos.color = lineColor;
                        Gizmos.DrawLine(bottomPoint, topPoint);
                    }
                }
            }
        }

        private bool IsCornerPoint(int x, int z, Vector3Int gridSize)
        {
            return (x == 0 || x == gridSize.x) && (z == 0 || z == gridSize.z);
        }
    }
}