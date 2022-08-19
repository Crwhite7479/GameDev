using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    CharacterController playerController;

    [SerializeField]
    Transform camera;

    public Vector3 moveDir;

    float moveSpeed = 5.5f;
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
            velocity.y = -0.005f;
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
            playerController.Move(moveDir.normalized * Time.deltaTime * moveSpeed);
        }

        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity);
    }

}
