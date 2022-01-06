using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
public  class AdsBeforeLvl : MonoBehaviour
{
    Scene scene;
#if UNITY_IOS
    private string gameId= "4524683";
#elif UNITY_ANDROID
    private string gameId = "4524682";
#endif
    void Start()
    {
       
        Advertisement.Initialize(gameId, true);
    }
  

    public void ShowAdd()
    {
        Advertisement.Show();
    }
}
