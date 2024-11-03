using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{
    public CanvasGroup pane;
   public void gonext()
    {
        //pane.SetActive(false);
        //pane.alpha = 0f;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("playScene_sy");
    }
}
