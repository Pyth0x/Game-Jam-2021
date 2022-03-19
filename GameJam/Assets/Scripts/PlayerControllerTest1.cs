using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.ProBuilder;
using UnityEngine.Rendering.PostProcessing;


public class PlayerControllerTest1 : MonoBehaviour
{
    
    public Mesh IceCreamTruck;
    public Material IceCreamTruckMat;
    
    public Mesh Ambulance;
    public Mesh Car;

    
    public Material AmbulanceMat;
    public Material CarMat;
    //ScoreScript scoreScript;

    public float changeLaneSpeed = 10f;
    public float laneWidth = 1.5f;
    private int lane = 0;

    private CharacterController myCharacterController;
    private Vector3 velocity;


    private void Start()
    {
        myCharacterController = GetComponent<CharacterController>();

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
            GetComponent<MeshFilter>().mesh = IceCreamTruck;
            GetComponent<MeshRenderer>().material = IceCreamTruckMat;
            transform.gameObject.tag = "icecream";
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GetComponent<MeshFilter>().mesh = Car;
            GetComponent<MeshRenderer>().material = CarMat;
            transform.gameObject.tag = "car";
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GetComponent<MeshFilter>().mesh = Ambulance;
            GetComponent<MeshRenderer>().material = AmbulanceMat;
            transform.gameObject.tag = "ambulance";

        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == other.gameObject.tag)
        {
            
            /*
            if (other.gameObject.tag == "enemyCap")
            {
                AudioManager.instance.Play("DarknessImpact 4-Audio");
            }
                
            if (other.gameObject.tag == "enemyCub")
            {
                AudioManager.instance.Play("DarknessImpact 10-Audio");
            }
                
            if (other.gameObject.tag == "enemySph")
            {
                AudioManager.instance.Play("DarknessImpact 20-Audio");
            }
                
            
        } else
        {
            if(other.gameObject.tag != "ring")
            {
                //SceneManager.LoadScene(1);
            }
            AudioManager audioManager = FindObjectOfType<AudioManager>();
            */
        }
    }

}
