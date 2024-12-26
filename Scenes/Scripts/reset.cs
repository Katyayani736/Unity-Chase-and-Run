using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class reset : MonoBehaviour
{
    private Vector3 dist;
    // Start is called before the first frame update
    void Start()
    {
        dist=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // Replace with your desired reset trigger
        {
            transform.position=dist;
        }
    }
}
