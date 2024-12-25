using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube2 : MonoBehaviour // Use PascalCase for class names
{
    [SerializeField] private float speed = 100.0f; // Set a default speed
    private float hinput;
    private float vinput;
    // Update is called once per frame
    void Update()
    {
        hinput=Input.GetAxis("Horizontal");
        vinput = Input.GetAxis("Vertical");
        //transform.Rotate(Vector3.down * speed * Time.deltaTime*2);
        transform.Translate(Vector3.forward * speed * Time.deltaTime*2*vinput);
        transform.Translate(Vector3.right * speed * Time.deltaTime*2*hinput);
    }
}
