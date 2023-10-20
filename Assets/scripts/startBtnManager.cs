using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public string sceneName = "SampleScene";
   public void playgame(){
    SceneManager.LoadScene(sceneName);
   }
}