using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    Transform otherTransform;

    void Start()
    {
        // you can set a reference to the "parent" cube
        otherTransform = GameObject.Find("Player").transform;
    }

    void Update()
    {
        // here we force the position of the current object to have the same y as the parent
        transform.position = new Vector3(otherTransform.position.x, otherTransform.position.y , transform.position.z);
    }
}
