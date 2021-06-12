using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mg_Boundaries : MonoBehaviour
{


    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5.5f, 5.5f), Mathf.Clamp(transform.position.y, -4.5f, 4.5f), transform.position.z);
    }
}
