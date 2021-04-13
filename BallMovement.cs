using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    private Vector3 ballMovementVector = new Vector3();

    [SerializeField]
    private float ballSpeed = 2f;
    
    void Start()
    {
        ballMovementVector = Vector3.right * ballSpeed;
    }

    
    void Update()
    {
        MoveBall();
    }

    private void MoveBall()
    {
        if(Input.GetMouseButtonDown(0))
        {
           if(ballMovementVector == Vector3.right )
            {
                ballMovementVector = Vector3.forward;
            }

           else
            {
                ballMovementVector = Vector3.right;
            }
        }

        transform.position += ballMovementVector  * Time.deltaTime * ballSpeed;
    }
}
