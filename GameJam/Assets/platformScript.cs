using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformScript : MonoBehaviour
{
    Renderer rent;
    public float scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rent = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rent.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
