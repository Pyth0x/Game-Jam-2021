using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    float rotateSpeed;
    float bounceSpeed;


    bool upflag = true;
    bool downflag = false;
    float startY;
    float endY;
    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = 125;
        bounceSpeed = 0.75f;
        startY = transform.position.y;
        endY = startY + 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > endY)
            downflag = true;

        if (transform.position.y < startY)
            upflag = true;
        if (upflag)
        {
            transform.position += new Vector3(0, bounceSpeed * Time.deltaTime, 0);
            if (transform.position.y > endY)
                upflag = false;
        }
        if (downflag)
        {
            transform.position += new Vector3(0, -bounceSpeed * Time.deltaTime, 0);
            if (transform.position.y < startY)
                downflag = false;
        }


        transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == other.gameObject.tag)
        {
            Debug.Log(gameObject.tag);
            Debug.Log(other.gameObject.tag);
            Debug.Log(other.name);
            //scoreScript.UpdateScore();
            Destroy(gameObject);
        }
    }
}
