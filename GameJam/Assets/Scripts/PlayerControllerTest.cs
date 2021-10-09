using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTest : MonoBehaviour
{

    public float changeLaneSpeed = 10f;
    public float laneWidth = 1.5f;
    private int lane = 0;

    private CharacterController myCharacterController;
    private Vector3 velocity;

    private void Start()
    {
        myCharacterController = GetComponent<CharacterController>();
        lane = 0;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (lane == 0 || lane == 1)
            {
                lane--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (lane == 0 || lane == -1)
            {
                lane++;
            }
        }

        Vector3 moveAmount = velocity * Time.deltaTime;
        float targetX = lane * laneWidth;
        float dirX = Mathf.Sign(targetX - transform.position.x);
        float deltaX = changeLaneSpeed * dirX * Time.deltaTime;

        if (Mathf.Sign(targetX - (transform.position.x + deltaX)) != dirX)
        {
            float overshoot = targetX - (transform.position.x + deltaX);
            deltaX += overshoot;
        }
        moveAmount.x = deltaX;

        myCharacterController.Move(moveAmount);
    }

    void changeShape(int shape)
    {
        
    }
}
