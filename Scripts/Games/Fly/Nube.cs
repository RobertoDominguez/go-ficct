using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nube : MonoBehaviour
{
    void Update()
    {
        transform.position =
                new Vector3(transform.position.x - (0.2f * Time.deltaTime),
                transform.position.y, 10);
    }
}
