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

    PlayerScript player;


    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
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

    }
}
