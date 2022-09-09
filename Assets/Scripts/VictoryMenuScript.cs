using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class VictoryMenuScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI finalscoreHUD;

    PlayerScript player;
    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
    }

    void Update()
    {
        // Displays Final score
        finalscoreHUD.text = "Final Score: " + PlayerPrefs.GetInt("total_score").ToString();
    }

    public void MainMenu()
    {
        //Load main menu and reset all collectibles and scoring
        SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("total_score", 0);
        PlayerPrefs.SetInt("Gold_Coins", 0);
        PlayerPrefs.SetInt("Apples", 0);
        PlayerPrefs.SetInt("Lemons", 0);
        PlayerPrefs.SetInt("Mushrooms", 0);
        PlayerPrefs.SetInt("Bananas", 0);
        PlayerPrefs.SetInt("Keys_Collected", 0);
        PlayerPrefs.SetInt("timescore", 0);

    }
}
