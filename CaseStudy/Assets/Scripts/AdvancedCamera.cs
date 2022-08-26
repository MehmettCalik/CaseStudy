using UnityEngine;
using System.Collections;

//put this component on camera
//drag target object (ball) onto the TargetObject public variable
public class AdvancedCamera : MonoBehaviour
{
    public Transform TargetObject;
    public float followDistance = 5f;
    public float followHeight = 2f;
    public bool smoothedFollow = false;         //toggle this for hard or smoothed follow
    public float smoothSpeed = 5f;
    public bool useFixedLookDirection = false;      //optional different camera mode... fixed look direction
    public Vector3 fixedLookDirection = Vector3.one;

    public bool finalMode;

    // Use this for initialization
    void Start()
    {
        //do something when game object is activated .. if you want to
        TargetObject = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //get a vector pointing from camera towards the ball

        Vector3 lookToward = TargetObject.position - transform.position;
        if (useFixedLookDirection)
            lookToward = fixedLookDirection;


        //make it stay a fixed distance behind ball
        Vector3 newPos;
        newPos = TargetObject.position - lookToward.normalized * followDistance;
        newPos.y = TargetObject.position.y + followHeight;

        if (!smoothedFollow)
        {
            transform.position = newPos;    //move exactly to follow target
        }
        else   //  smoothed / soft follow
        {
            transform.position += (newPos - transform.position) * Time.deltaTime * smoothSpeed;
        }

        //re- calculate look direction (dont' do this line if you want to lag the look a little
        lookToward = TargetObject.position - transform.position;

        //make this camera look at target
        transform.forward = lookToward.normalized;

        //        if (finalMode)
        //        {
        //            followDistance = 10f;
        //            followHeight = 3f;
        //            fixedLookDirection = new Vector3(-8.5f, 1f, 1f);
        //        }

        //        else
        //        {
        //            followDistance = 18.5f;
        //            followHeight = 6.75f;
        //            fixedLookDirection = new Vector3(-0.5f, 1f, 1f);
        //        }
    }
}