using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
        // UI Counters for item pickups
    [SerializeField]
    TextMeshProUGUI ApplesHUD;
    [SerializeField]
    TextMeshProUGUI CoinsHUD;
    [SerializeField]
    TextMeshProUGUI LemonsHUD;
    [SerializeField]
    TextMeshProUGUI BananasHUD;
    [SerializeField]
    TextMeshProUGUI ShroomsHUD;
    [SerializeField]
    TextMeshProUGUI KeysHUD;

    //Current score display
    [SerializeField]
    TextMeshProUGUI scoreHUD;

    //Menu UI's
    [SerializeField]
    GameObject pausemenu;

    PlayerScript player;


    void Start()
    {
        player = FindObjectOfType<PlayerScript>();

        pausemenu.SetActive(false);
    }

    void Update()
    {
        // HUD displays number of items collected
        KeysHUD.text = "x " + player.Keys_Collected.ToString();
        ApplesHUD.text = "x " + player.Apples.ToString();
        CoinsHUD.text = "x " + player.Gold_Coins.ToString();
        LemonsHUD.text = "x " + player.Lemons.ToString();
        BananasHUD.text = "x " + player.Bananas.ToString();
        ShroomsHUD.text = "x " + player.Mushrooms.ToString();

        // HUD displays current total points scored
        scoreHUD.text = "Score: " + PlayerPrefs.GetInt("total_score").ToString();

        // Pause menu key
        if (Input.GetKeyDown(KeyCode.P))
        {
            pausemenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Resumegame()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        //Reset players collected items
        PlayerPrefs.SetInt("Gold_Coins", 0);
        PlayerPrefs.SetInt("Apples", 0);
        PlayerPrefs.SetInt("Lemons", 0);
        PlayerPrefs.SetInt("Mushrooms", 0);
        PlayerPrefs.SetInt("Bananas", 0);
        PlayerPrefs.SetInt("Keys_Collected", 0);
        PlayerPrefs.SetInt("timescore", 0);

        //Restart current level
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);

        pausemenu.SetActive(false);

        Time.timeScale = 1;
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

        Time.timeScale = 1;
        pausemenu.SetActive(false);
    }

    public void Quitgame()
    {
        Debug.Log("Application Quitting!!");
        Application.Quit();
    }
}
