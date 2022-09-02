using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCamera : MonoBehaviour
{
    PlayerScript player;
    Transform playerTransform;
    Transform cameraTransform;
    Camera playerCam;

    [SerializeField]
    Vector3 cameraOffsetPos = new Vector3(0, 1.5f, -3.75f);
    Vector3 cameraLookHeight = new Vector3(0f, 1.5f, 0f);

    float currentX;
    float currentY;

    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
        playerTransform = player.transform;
        cameraTransform = transform;
        playerCam = Camera.main;
    }

    void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY -= Input.GetAxis("Mouse Y");
        Quaternion cameraRotation = Quaternion.Euler(currentY, currentX, 0);

        Vector3 cameraposition = new Vector3(0, 1.5f, 5f);

        cameraTransform.position = playerTransform.position + cameraRotation * cameraposition;
        cameraTransform.LookAt(playerTransform.position + cameraLookHeight);

    }

}
