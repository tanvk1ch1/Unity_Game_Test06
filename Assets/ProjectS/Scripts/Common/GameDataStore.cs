using System.Collections.Generic;
using System.Linq;

namespace ProjectS
{
    public class GameDataStore
    {
        #region Member
        
        public enum MainMenuKind
        {
            One,
            Two,
            Three,
            Four,
            None
        }
        
        public static GameDataStore Instance { get; } = new GameDataStore();
        
        public MainMenuKind SelectMainMenuKind = MainMenuKind.None;
        
        #endregion
        
    }
}