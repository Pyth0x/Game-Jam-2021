using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZoneScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemyCub" || collision.gameObject.tag == "enemySph" || collision.gameObject.tag == "enemyCap")
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemyCub" || other.gameObject.tag == "enemySph" || other.gameObject.tag == "enemyCap")
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene(1);
        }
    }
}
