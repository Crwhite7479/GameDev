using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    CharacterController playerController;

    public int Gold_Coins;
    public int Apples;
    public int Lemons;
    public int Mushrooms;
    public int Bananas;
    public int Keys_Collected;

    public int total_score;
    public int level_score;

    [SerializeField]
    Transform camera;

    public Vector3 moveDir;

    [SerializeField]
    float moveSpeed = 6.5f;

    float currentVelocity;

    public Vector3 direction;

    //Jump variables
    [SerializeField]
    bool is_Grounded;
    [SerializeField]
    float groundCheckDistance;
    [SerializeField]
    LayerMask groundLayerMask;
    [SerializeField]
    float gravity;
    [SerializeField]
    float jumpHeight;

    Vector3 velocity;
    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    void Update()
    {

        float horizontalmove = Input.GetAxis("Horizontal");
        float forwardmove = Input.GetAxis("Vertical");
        direction = new Vector3(horizontalmove, 0, forwardmove);

        if (Input.GetKey(KeyCode.Space))
        {
            if (is_Grounded)
            {
                velocity.y = jumpHeight;
            }
            
        }

        is_Grounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundLayerMask);
        if (!is_Grounded)
        {
            velocity.y = -0.0005f;
        }

        //Getting the angle from x and z values
        float moveAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
        float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, moveAngle, ref currentVelocity, 0.1f);

        //rotating in degrees
        transform.rotation = Quaternion.Euler(0, smoothAngle, 0);

        //makes movement relative to camera direction
        moveDir = Quaternion.Euler(0, moveAngle, 0) * Vector3.forward;

        if (direction.magnitude > 0)
        {
            playerController.Move(moveSpeed * Time.deltaTime * moveDir.normalized);
        }

        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity);

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PirateCoin"))
        {
            Gold_Coins++;
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Apple_Tag"))
        {
            Apples++;
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Key_Tag"))
        {
            Keys_Collected++;
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Lemon_Tag"))
        {
            Lemons++;
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Shroom_Tag"))
        {
            Mushrooms++;
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Banana_Tag"))
        {
            Bananas++;
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Next_Level"))
        {
            if (Keys_Collected > 0)
            {
                Debug.Log("Level Complete");

                int newScene = SceneManager.GetActiveScene().buildIndex + 1;

                // Calculate scoring
                level_score = (Gold_Coins * 200) + (Apples * 30) + (Lemons * 50) + (Mushrooms * 69) + (Bananas * 15);
                PlayerPrefs.SetInt("total_score", PlayerPrefs.GetInt("total_score") + level_score);

                //Reset players collected items
                PlayerPrefs.SetInt("Gold_Coins", 0);
                PlayerPrefs.SetInt("Apples", 0);
                PlayerPrefs.SetInt("Lemons", 0);
                PlayerPrefs.SetInt("Mushrooms", 0);
                PlayerPrefs.SetInt("Bananas", 0);
                PlayerPrefs.SetInt("Keys_Collected", 0);

                SceneManager.LoadScene(newScene);
            }
        }

        else if (other.CompareTag("Respawn"))
        {
            
            Debug.Log("RESPAWN");

            //Reset players collected items
            PlayerPrefs.SetInt("Gold_Coins", 0);
            PlayerPrefs.SetInt("Apples", 0);
            PlayerPrefs.SetInt("Lemons", 0);
            PlayerPrefs.SetInt("Mushrooms", 0);
            PlayerPrefs.SetInt("Bananas", 0);
            PlayerPrefs.SetInt("Keys_Collected", 0);

            //reload current level
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }

    }
}
