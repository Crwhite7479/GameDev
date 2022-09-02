using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("Gold_Coins", 0);
        PlayerPrefs.SetInt("Apples", 0);
        PlayerPrefs.SetInt("Lemons", 0);
        PlayerPrefs.SetInt("Mushrooms", 0);
        PlayerPrefs.SetInt("Bananas", 0);
        PlayerPrefs.SetInt("Keys_Collected", 0);

    }

    public void Quitgame()
    {
        Debug.Log("Application Quitting!!");
        Application.Quit();

    }
}

