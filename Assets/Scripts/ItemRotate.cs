using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemRotate : MonoBehaviour
{
    // This is for the slow rotation of various pickup items
    void Start()
    {
        
    }

    // Rotation speed
    [SerializeField] 
    float _degreesPerSec = 45f;

    [SerializeField] 
    Vector3 _axis = Vector3.forward;
    void Update()
    {
        transform.Rotate(_axis.normalized * _degreesPerSec * Time.deltaTime);
    }
}
