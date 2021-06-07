using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFly : MonoBehaviour
{
    [SerializeField] float velocidad;
    void Update()
    {
        transform.position = new Vector3(transform.position.x,
            transform.position.y+velocidad*Time.deltaTime,
            transform.position.z);
    }
}
