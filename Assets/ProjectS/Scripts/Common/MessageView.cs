using System;
using System.Collections;
using UnityEngine;
using TMPro;

namespace ProjectS
{
    public class MessageView : MonoBehaviour
    {
        #region Member
        
        private RubyTextMeshProUGUI meshproText = null;
        
        #endregion
        
        #region Method
        
        private void Awake()
        {
            meshproText = transform.GetComponent<RubyTextMeshProUGUI>();
        }
        
        public void SetMessage(string str)
        {
            meshproText.UnditedText = str;
            meshproText.Validate();
        }
        
        // ....
        
        #endregion
    }
}