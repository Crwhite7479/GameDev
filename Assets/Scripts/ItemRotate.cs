using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotate : MonoBehaviour
{

    void Start()
    {
        
    }

    [SerializeField] 
    float _degreesPerSec = 45f;

    [SerializeField] 
    Vector3 _axis = Vector3.forward;
    void Update()
    {
        transform.Rotate(_axis.normalized * _degreesPerSec * Time.deltaTime);
    }
}
