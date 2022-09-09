using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    public void StartGame()
    {
        //Load new game at level 1 and reset all collectibles and scoring
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("total_score", 0);
        PlayerPrefs.SetInt("Gold_Coins", 0);
        PlayerPrefs.SetInt("Apples", 0);
        PlayerPrefs.SetInt("Lemons", 0);
        PlayerPrefs.SetInt("Mushrooms", 0);
        PlayerPrefs.SetInt("Bananas", 0);
        PlayerPrefs.SetInt("Keys_Collected", 0);
        PlayerPrefs.SetInt("timescore", 0);

    }

    public void Quitgame()
    {
        Debug.Log("Application Quitting!!");
        Application.Quit();
    }
}

