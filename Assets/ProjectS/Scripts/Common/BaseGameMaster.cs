using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectS
{
    public abstract class BaseGameMaster : MonoBehaviour
    {
        #region Member
        
        private enum State
        {
            Running,
            WaitCountDown
        }
        
        private GameObject StartCountDownPrefab
        {
            // get => ResourceStore.Instance.Get<GameObject>("StartCount");
            get;
        }
        private Animator countDownAnimator = null;
        private bool isLoading = false;
        private State state = State.Running;
        
        protected bool NeedLoadSystem
        {
            get => true;
        }
        #endregion
        
        
        
        #region MonoBehavior
        
        private void Awake()
        {
            // if (!AssetLoader.Instance.IsLoadedSystemAsset && NeedLoadSystem)
            // {
            //     StartCoroutine(LoadSystem());
            // }
        }
        
        private void Start()
        {
            StartMain();
        }
        
        private void Update()
        {
            if (isLoading)
            {
                return;
            }
            
            if (state == State.WaitCountDown)
            {
                // countDownAnimator.Update(TimeUtility.UnscaledDeltaTime);
            }
            
            if (Mathf.Approximately(Time.timeScale, 0f))
            {
                return;
            }
            UpdateMain();
        }
        
        protected void OnDestroy()
        {
            // 動作を止める
            // TODO:Tween系？で動作停止 iTween.Stop(); , iTween.tweens.Clear();
            // InputObserver.Instance.ClearEvents();
        }
        
        #endregion
        
        
        
        #region Method
        
        // 継承先で実装する抽象メソッド
        abstract protected void StartMain();
        abstract protected void UpdateMain();
        
        // private IEnumerator LoadSystem()
        // {
        //     isLoading = true;
        //     var task = AssetLoader.Instance.LoadSystem();
        //     while (!task.IsCompleted)
        //     {
        //         yield return null;
        //     }
        //     isLoading = false;
        // }
        
        #endregion
    }
}