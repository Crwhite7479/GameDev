using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRotation : MonoBehaviour
{
    PlayerScript playerScript;
    

    float rotX;
    float rotZ;
   
    void Start()
    {
        playerScript = GetComponentInParent<PlayerScript>();
        
    }


    void Update()
    {
        
            rotX += playerScript.moveDir.z;
            rotZ -= playerScript.moveDir.x;

            
            transform.rotation = Quaternion.Euler(rotX, 0, rotZ);
        
    }
}
