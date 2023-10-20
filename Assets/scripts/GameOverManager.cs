using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuController : MonoBehaviour
{
    // Start is called before the first frame update
     public string sceneName = "SampleScene";
     public string HomeScene = "StartScene";
     

   public void playgame(){
    SceneManager.LoadScene(sceneName);
   }

     public void goHome(){
    SceneManager.LoadScene(HomeScene);
   }

   
}