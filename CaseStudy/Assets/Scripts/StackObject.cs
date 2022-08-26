using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackObject : MonoBehaviour
{

    public Transform nodePos;
    public float posY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, nodePos.position.x, Time.deltaTime * 5), nodePos.position.y + posY, nodePos.position.z);
    }
}