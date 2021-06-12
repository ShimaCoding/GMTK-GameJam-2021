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
    Transform sectorTransform;
    bool isGrabbed;

    void Start()
    {

    }

    void Update()
    {


        if (Input.GetButtonDown("ButtonB" + currentHandPlayer))
        {
            print("Button: " + "ButtonB" + currentHandPlayer + "Pressed");
        }


        float v = Input.GetAxis("Vertical" + currentHandPlayer);
        float h = Input.GetAxis("Horizontal" + currentHandPlayer);
        movement = new Vector3(h, v, 0f);


        movement = movement * handSpeed * Time.deltaTime;

        transform.position += movement;


        if (Input.GetButtonUp("ButtonA" + currentHandPlayer) && sectorTransform!=null)
        {
            sectorTransform.SetParent(GameObject.Find("scenarioContainer").transform);
            sectorTransform.GetComponent<BoxCollider2D>().enabled = true;
            sectorTransform = null;
            isGrabbed = false;
        }

    }


    private void OnTriggerStay2D(Collider2D other)
    { 
        if (Input.GetButton("ButtonA" + currentHandPlayer) && other.GetComponent<Mg_Sector>() != null && !isGrabbed && other.GetComponent<Mg_Sector>().isPlayerOnSector ==false)
        {
            isGrabbed = true;
            sectorTransform = other.transform;
            other.transform.SetParent(transform);
            sectorTransform.GetComponent<BoxCollider2D>().enabled = false;
        }
    }


}
