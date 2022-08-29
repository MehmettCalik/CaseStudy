using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;


namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {

        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;

        float distanceTravelled;

        public float xOffset;
        public float maxDistance = 3;
        public float swerveSpeed = 6;
        private SwerveInputSystem _swerveInputSystem;


        void Start()
        {
            if (GetComponent<SwerveInputSystem>())
            {
                _swerveInputSystem = GetComponent<SwerveInputSystem>();
            }
            else
            {
                _swerveInputSystem = gameObject.AddComponent<SwerveInputSystem>();
            }
            DOTween.Init();
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        public Vector3 desiredPoint;
        public float mouseX = 0;


        [SerializeField] private float maxSwerveAmount = .5f;
        public float swerveAmount;
        public float lastSwerve;

        void Update()
        {
            if (PlayerController.instance.isStart)
            {
                if (pathCreator != null)
                {
                    distanceTravelled += PlayerController.instance.Speed * Time.deltaTime;
                    desiredPoint = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);

                    transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);

                    if (Input.GetMouseButton(0))
                    {
                        mouseX = Input.mousePosition.x;


                        swerveAmount = Time.deltaTime * 5 * _swerveInputSystem.MoveFactorX;
                        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);

                        xOffset += Mathf.Clamp(swerveAmount, -1.0F, 1.0F) * swerveSpeed * Time.deltaTime * PlayerController.instance.Speed;
                        //yOffset += v * Time.deltaTime * speed;

                        transform.position = desiredPoint;
                        xOffset = Mathf.Clamp(xOffset, -11, 11);
                        desiredPoint = transform.TransformPoint(new Vector3(xOffset, 0, 0));

                        transform.position = desiredPoint;
                    }
                    else
                    {
                        transform.position = desiredPoint;
                        desiredPoint = transform.TransformPoint(new Vector3(xOffset, 0, 0));
                        transform.position = desiredPoint;
                    }
                }
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged()
        {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}