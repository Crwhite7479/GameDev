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

    PlayerScript player;


    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
    }

    void Update()
    {
        KeysHUD.text = "Keys: " + player.Keys_Collected.ToString();
        ApplesHUD.text = "Apples: " + player.Apples.ToString();
        CoinsHUD.text = "Coins: " + player.Gold_Coins.ToString();
        LemonsHUD.text = "Lemons: " + player.Lemons.ToString();
        BananasHUD.text = "Bananas: " + player.Bananas.ToString();
        ShroomsHUD.text = "Shrooms: " + player.Mushrooms.ToString();

    }
}
