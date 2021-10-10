using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingScript : MonoBehaviour
{
    private MeshRenderer torusMeshRenderer;
    [SerializeField] private float lerpTime;
    [SerializeField] private Color[] myColors;

    int colorIndex = 0;
    float t = 0f;
    
    int len;

    private void Start()
    {
        torusMeshRenderer = GetComponent<MeshRenderer>();
        len = myColors.Length;
    }
    
    private void Update()
    {
        torusMeshRenderer.material.color = Color.Lerp(torusMeshRenderer.material.color, myColors[colorIndex], lerpTime);
        
        t = Mathf.Lerp(t, 1f, lerpTime); 

        if (t > .9f)
        {
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
        }



    }
}
