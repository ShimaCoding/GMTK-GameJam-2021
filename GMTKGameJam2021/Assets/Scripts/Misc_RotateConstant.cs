using UnityEngine;

public class Misc_RotateConstant : MonoBehaviour {

    public float speed;
    public Vector3 axis;
    public Transform target;

    void Update() {
        target.Rotate(axis * speed * Time.deltaTime);
    }
}
