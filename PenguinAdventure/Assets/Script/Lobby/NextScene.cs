using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{
   public void gonext()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("playScene_sy");
    }
}
