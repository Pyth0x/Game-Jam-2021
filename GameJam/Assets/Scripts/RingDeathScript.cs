using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingDeathScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ring")
        {
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, 75f);
        }
    }


}
