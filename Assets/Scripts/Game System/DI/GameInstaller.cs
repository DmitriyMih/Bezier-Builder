using UnityEngine;
using Zenject;

namespace GameSystem
{
    [ExecuteAlways]
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameManagment gameManagment;

        public override void InstallBindings()
        {
            Container.Bind<GameManagment>().FromInstance(gameManagment).AsSingle();
        }

        //private void Awake()
        //{
        //    gameManagment.Initialization();
        //}

        private void OnEnable()
        {
            gameManagment.Initialization();
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            gameManagment.DrawGizmos();
        }
#endif
    }
}