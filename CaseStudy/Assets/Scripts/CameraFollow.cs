using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, offset.y, target.position.z+offset.z), 5f * Time.deltaTime);
        }
    }
}