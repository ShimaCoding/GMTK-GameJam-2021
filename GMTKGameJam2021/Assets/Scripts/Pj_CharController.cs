using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pj_CharController : MonoBehaviour {

    float playerSpeed = 5;

    string playerController = "0";
    float lastHorValue;

    void Start() {
        
    }

    void Update() {
        if (Input.GetButtonDown("ButtonA" + playerController)){
            Jump();
        }
        if (Input.GetAxis("Horizontal" + playerController) != lastHorValue){
            Move(Input.GetAxis("Horizontal" + playerController));
        }
    }

    void Jump () {

    }
    void Move (float value) {
    }
}
