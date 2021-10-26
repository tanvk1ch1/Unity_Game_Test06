using UnityEngine;

namespace ProjectS
{
    public class MainMenuView : MonoBehaviour
    {
        #region Member
        
        private GameObject[] gameobjects = new GameObject[2];
        
        #endregion
        
        #region Method
        
        private void Awake()
        {
            foreach (Transform trans in transform)
            {
                if (trans.name == "On")
                {
                    gameobjects[0] = trans.gameObject;
                }
                else if (trans.name == "Off")
                {
                    gameobjects[1] = trans.gameObject;
                }
            }
        }
        
        public void SetSelect(bool flag)
        {
            if (flag)
            {
                gameobjects[0].SetActive(true);
                gameobjects[1].SetActive(false);
            }
            else
            {
                gameobjects[0].SetActive(false);
                gameobjects[1].SetActive(true);
            }
        }
        
        #endregion
    }
}