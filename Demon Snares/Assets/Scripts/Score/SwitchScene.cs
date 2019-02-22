using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SwitchScene : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene(sceneName: "Score2 (test)");
    }
}
