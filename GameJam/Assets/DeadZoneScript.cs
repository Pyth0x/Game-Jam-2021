using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
    }
}
