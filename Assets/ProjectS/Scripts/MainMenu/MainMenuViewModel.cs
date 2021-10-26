using System;

namespace ProjectS
{
    public class MainMenuViewModel
    {
        #region Member
        
        public ValueObserver<bool> ModeOneView { get; } = new ValueObserver<bool>(false);
        public ValueObserver<bool> ModeTwoView { get; } = new ValueObserver<bool>(false);
        public ValueObserver<bool> ModeThreeView { get; } = new ValueObserver<bool>(false);
        public ValueObserver<bool> ModeFourView { get; } = new ValueObserver<bool>(false);
        public ValueObserver<string> MenuTitleView { get; } = new ValueObserver<string>("");
        
        #endregion
        
        #region Method
        
        public MainMenuViewModel()
        {
        }
        
        public void SelectModeOne(bool flag)
        {
            ModeOneView.Value = flag;
        }
        
        public void SelectModeTwo(bool flag)
        {
            ModeTwoView.Value = flag;
        }
        
        public void SelectModeThree(bool flag)
        {
            ModeThreeView.Value = flag;
        }
        
        public void SelectModeFour(bool flag)
        {
            ModeFourView.Value = flag;
        }
        
        public void SetMenuTitle(string str)
        {
            MenuTitleView.Value = str;
        }
        
        #endregion
    }
}