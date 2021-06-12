﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mg_Boundaries : MonoBehaviour
{


    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5.4f, 5.4f), Mathf.Clamp(transform.position.y, -4.5f, 4.5f), transform.position.z);
    }
}
