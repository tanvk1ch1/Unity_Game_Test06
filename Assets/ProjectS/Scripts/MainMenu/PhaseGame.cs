using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectS
{
    public class PhaseGame : IPhase
    {
        #region Member

        private string[] MenuTitle =
        {
            "hoge",
            "fuga",
            "are",
            "kore"
        };
        
        public Action OnEndPhase { get; set; }
        private MainMenuViewModel viewModel;
        private GameDataStore.MainMenuKind kind;
        
        public PhaseGame(MainMenuViewModel viewmodel)
        {
            this.viewModel = viewmodel;
        }
        
        #endregion
        
        #region Method
        
        public void Init()
        {
            // 選択中を表示
            if (GameDataStore.Instance.SelectMainMenuKind == GameDataStore.MainMenuKind.None)
            {
                GameDataStore.Instance.SelectMainMenuKind = GameDataStore.MainMenuKind.One;
            }
            
            SetSelectMenu(GameDataStore.Instance.SelectMainMenuKind, true);
            kind = GameDataStore.Instance.SelectMainMenuKind;
            
        }
        
        public void Run(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && kind > GameDataStore.MainMenuKind.One)
            {
                SetSelectMenu(kind, false);
                
                kind--;
                SetSelectMenu(kind, true);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && kind < GameDataStore.MainMenuKind.Four)
            {
                SetSelectMenu(kind, false);
                
                kind++;
                SetSelectMenu(kind, true);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                GameDataStore.Instance.SelectMainMenuKind = kind;
                OnEndPhase?.Invoke();
            }
            
            
            
        }
        
        private void SetSelectMenu(GameDataStore.MainMenuKind kind, bool flag)
        {
            switch (kind)
            {
                case GameDataStore.MainMenuKind.One:
                    viewModel.ModeOneView.Value = flag;
                    break;
                case GameDataStore.MainMenuKind.Two:
                    viewModel.ModeTwoView.Value = flag;
                    break;
                case GameDataStore.MainMenuKind.Three:
                    viewModel.ModeThreeView.Value = flag;
                    break;
                default:
                    viewModel.ModeFourView.Value = flag;
                    break;
            }
            if (flag)
            {
                viewModel.SetMenuTitle(MenuTitle[(int)kind]);
            }
        }
        
        #endregion
    }
}