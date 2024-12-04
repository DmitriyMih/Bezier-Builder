using UnityEngine;
using GameSystem.GridSystem;
using Grid = GameSystem.GridSystem.Grid;

namespace GameSystem
{
    [System.Serializable]
    public class GameManagment
    {
        [SerializeField] private GridSettings gridSettings;
        [SerializeField] private GridGizmosDrawer gridGizmosDrawer;

        [field: SerializeField] public Grid Grid { get; private set; }

        public void Initialization()
        {
            Grid = new(gridSettings);
            //  выполнение логики Awake
        }

        public void DrawGizmos()
        {
            gridGizmosDrawer.DrawGizmos(Grid);
        }
    }
}