using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pj_HandController : MonoBehaviour
{
    [SerializeField]
    List<Sprite> handSprites;
    string currentHandPlayer = "1";
    public float handSpeed = 10f;
    Vector3 movement;

    void Start()
    {

    }

    void Update()
    {

        if (Input.GetButton("ButtonA" + currentHandPlayer))
        {
            print("Button: " + "ButtonA" + currentHandPlayer + "Pressed");
        }
        if (Input.GetButton("ButtonB" + currentHandPlayer))
        {
            print("Button: " + "ButtonB" + currentHandPlayer + "Pressed");
        }


        float v = Input.GetAxis("Vertical" + currentHandPlayer);
        float h = Input.GetAxis("Horizontal" + currentHandPlayer);
        movement = new Vector3(h, v, 0f);


        movement = movement * handSpeed * Time.deltaTime;

        print(movement);
        transform.position += movement;

    }
}
