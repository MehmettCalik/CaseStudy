using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameObject Hand;
    public Transform nodePos;
    private float _posY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       transform.position = new Vector3(Mathf.Lerp(transform.position.x, nodePos.position.x, Time.deltaTime * 30), nodePos.position.y - _posY, nodePos.position.z);
         
    
        
    }
}
