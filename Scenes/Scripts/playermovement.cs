using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;

public class playermovement : MonoBehaviour
{
    public float speed = 50.0f; // Set a default speed
    private float hinput;
    private float vinput;
    public Transform enemy;
    private Quaternion coll;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void OnCollisionEnter(Collision collision){
        if(collision.collider.name.StartsWith("Plane")){
            coll=collision.collider.transform.rotation;
            //Debug.Log(collision.collider.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        hinput=Input.GetAxis("Horizontal");
        vinput = Input.GetAxis("Vertical");
        //transform.Rotate(Vector3.down * speed * Time.deltaTime*2);
        transform.rotation=coll;
        transform.Translate(Vector3.forward * speed * Time.deltaTime*2*vinput);
        transform.Translate(Vector3.right * speed * Time.deltaTime*2*hinput);
        float distance = Vector3.Distance(transform.position, enemy.position);
            // Check for out-of-bounds (adjust threshold based on your scene)
            //if (transform.position.y < -2 || distance <= 0.5f)
            //{
                //Debug.Log("Game Over!"); // Print "Game Over!" to console
                //Debug.Break();
                //EditorApplication.ExitPlaymode();
            //}
    }
}
