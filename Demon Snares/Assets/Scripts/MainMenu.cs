using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
<<<<<<< HEAD
        SceneManager.LoadScene("DennisTestScene");
=======
        SceneManager.LoadScene("TomTestScene");
>>>>>>> master
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


}
