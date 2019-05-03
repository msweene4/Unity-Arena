using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void newGame()
    {
        PlayerPrefs.SetInt("Gold", 200);
        PlayerPrefs.SetInt("Strength", 0);
        PlayerPrefs.SetInt("Defense", 0);
        PlayerPrefs.SetInt("Health", 100);
    }
    
}
