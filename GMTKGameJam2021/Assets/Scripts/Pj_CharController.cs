using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pj_CharController : MonoBehaviour {

    float playerSpeed = 500;
    bool jumping;

    string playerController = "0";
    float lastHorValue;

    public Rigidbody2D rb;
    public LayerMask platformLayerMask;

    void Start() {
        
    }

    void Update() {
        if (Input.GetButtonDown("ButtonA" + playerController)){
            Jump();
        }
        if (Input.GetButtonDown("ButtonB" + playerController)) {
            transform.position = Vector2.zero;
            rb.velocity = Vector3.zero;
        }
        float xAxis = Input.GetAxis("Horizontal" + playerController);
            Move(xAxis);
        /*if (xAxis != lastHorValue){
            if (lastHorValue <= xAxis)
                Move(new Vector2(xAxis, 0).normalized.x);
            else Move(xAxis);
            lastHorValue = xAxis;
        }*/
    }

    void Jump () {
        if (jumping) {
            if(!rb.IsTouchingLayers(platformLayerMask))
                return;
        }
        jumping = true;
        rb.velocity = new Vector2(rb.velocity.x * 0.8f, 10);
    }
    void Move (float value) {
        if (jumping) {
            if((value > 0 && rb.velocity.x < 5) ||(value < 0 && rb.velocity.x > -5))
                rb.AddForce(new Vector2(value * playerSpeed * Time.deltaTime * 5, 0));
            return;
        }
        rb.velocity = new Vector2(value * playerSpeed * Time.deltaTime, rb.velocity.y);
    }
    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.CompareTag("Floor")) {
            if(rb.velocity.y <= 0)
                jumping = false;
        }
    }
    private void OnCollisionExit2D (Collision2D collision) {
        if (!jumping && collision.gameObject.CompareTag("Floor")) {
                jumping = true;
        }
    }
}
