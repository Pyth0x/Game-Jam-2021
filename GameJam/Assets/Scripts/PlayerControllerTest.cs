using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.ProBuilder;
using UnityEngine.Rendering.PostProcessing;


public class PlayerControllerTest : MonoBehaviour
{

    public ScoreScript scoreScript;
    public Mesh cube;
    public Mesh sphere;
    public Mesh capsule;

    public Material cubeMat;
    public Material sphereMat;
    public Material capsuleMat;

    //public GameObject ppobject;
    public PostProcessVolume pp;




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
            GetComponent<MeshFilter>().mesh = cube;
            GetComponent<MeshRenderer>().material = cubeMat;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GetComponent<MeshFilter>().mesh = sphere;
            GetComponent<MeshRenderer>().material = sphereMat;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GetComponent<MeshFilter>().mesh = capsule;
            GetComponent<MeshRenderer>().material = capsuleMat;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GetComponent<MeshFilter>().mesh.name == other.GetComponent<MeshFilter>().mesh.name)
        {
            scoreScript.UpdateScore();
            Destroy(other.gameObject);


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

        }
    }

}
