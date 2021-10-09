using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerTest : MonoBehaviour
{
    Vector3 vectortest;

    public ScoreScript scoreScript;
    public Mesh cube;
    public Mesh sphere;
    public Mesh capsule;


    public float changeLaneSpeed = 10f;
    public float laneWidth = 1.5f;
    private int lane = 0;

    private CharacterController myCharacterController;
    private Vector3 velocity;
    private MeshFilter currentShape;
    private Vector3 currentPos;

    private void Start()
    {
        myCharacterController = GetComponent<CharacterController>();

        currentShape = GetComponent<MeshFilter>();
        
    }

    private void Update()
    {
        Move();
        ChangeShape();
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

    void ChangeShape()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            /*
            vectortest = new Vector3(transform.position.x, 1, transform.position.z);
            Destroy(this.gameObject);
            Instantiate(cube,vectortest, Quaternion.identity);*/
            GetComponent<MeshFilter>().mesh = cube;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            /*
            vectortest = new Vector3(transform.position.x, 1, transform.position.z);
            Destroy(this.gameObject);
            Instantiate(sphere,vectortest , Quaternion.identity);*/
            GetComponent<MeshFilter>().mesh = sphere;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            /*
            vectortest = new Vector3(transform.position.x, 1.5f, transform.position.z);
            Instantiate(capsule, vectortest, Quaternion.identity);
            Destroy(this.gameObject);*/
            GetComponent<MeshFilter>().mesh = capsule;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(GetComponent<MeshFilter>().mesh.name == other.GetComponent<MeshFilter>().mesh.name)
        {
            scoreScript.UpdateScore();
            Destroy(other.gameObject);

        } else
        {
            SceneManager.LoadScene(0);
        }
    }
}
