using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mg_ScenarioMovement : MonoBehaviour {

    float scenarioSpeed = 2;
    public bool move = true;

    public List<Transform> backgroundPaperTransform;
    Transform currentManagedPaperTransform;

    void Start() {
        
    }

    private void Update () {
        if (!move)
            return;
        transform.Translate(0, -scenarioSpeed * Time.deltaTime, 0);
    }

    void FixedUpdate() {
        if(backgroundPaperTransform[0].position.y <= -9) {
            currentManagedPaperTransform = backgroundPaperTransform[0];
            backgroundPaperTransform.RemoveAt(0);
            currentManagedPaperTransform.Translate(0, 18.75f, 0);
            backgroundPaperTransform.Add(currentManagedPaperTransform);
        }
    }
}
