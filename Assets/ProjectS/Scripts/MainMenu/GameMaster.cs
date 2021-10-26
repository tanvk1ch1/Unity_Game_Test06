using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectS
{
    public class GameMaster : BaseGameMaster
    {
        #region Member
        
        [SerializeField]
        private MainMenuView[] menuView = new MainMenuView[4];
        
        [SerializeField]
        private MessageView menuTitleView = null;
        
        private IPhase currentPhase;
        
        private MainMenuViewModel viewModel = new MainMenuViewModel();
        
        // ...
        
        #endregion
        
        #region MainMethod
        
        protected override void StartMain()
        {
            viewModel.ModeOneView.OnChange += menuView[0].SetSelect;
            viewModel.ModeTwoView.OnChange += menuView[1].SetSelect;
            viewModel.ModeThreeView.OnChange += menuView[2].SetSelect;
            viewModel.ModeFourView.OnChange += menuView[3].SetSelect;
            viewModel.MenuTitleView.OnChange += menuTitleView.SetMessage;
            
            StartGamePhase();
        }
        
        protected override void UpdateMain()
        {
            var deltaTime = Time.deltaTime;
            currentPhase?.Run(deltaTime);
        }
        
        #endregion
        
        #region Method
        
        private void StartGamePhase()
        {
            currentPhase = new PhaseGame(viewModel);
            currentPhase.OnEndPhase = () =>
            {
                currentPhase = null;
                // 
                NextScene();
            };
            currentPhase.Init();
        }
        
        private void NextScene()
        {
            switch (GameDataStore.Instance.SelectMainMenuKind)
            {
                case GameDataStore.MainMenuKind.One:
                    // GameDataStore.Instance.NextSceneName = "OneScene";
                    break;
                case GameDataStore.MainMenuKind.Two:
                    // 
                    break;
                case GameDataStore.MainMenuKind.Three:
                    // 
                    break;
                case GameDataStore.MainMenuKind.Four:
                    // 
                    break;
            }
            
            // TODO:シーン遷移
            // SceneManager.LoadScene("LoadScene");
        }
        
        #endregion
    }
}
