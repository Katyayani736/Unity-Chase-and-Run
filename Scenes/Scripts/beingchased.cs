using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class beingchased : MonoBehaviour
{
  public Transform player; //Reference to the player's Transform component
  public GameObject tochase;//the dodger
  public float speed = 5.0f; //Movement speed of the runaway object
  private void Update()
  {
        //direction to run away
        Vector3 direction = transform.position - player.position;
        direction.y = 0; 

        //normalize the direction to get a unit vector
        direction = direction.normalized;

        //move away from the player
        transform.Translate(direction * speed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, player.position);
            if(distance <= 0.9f)
            {
              //Destroy(gameObject);
              Vector3 randomPosition = new Vector3(Random.Range(-6,7),-1,Random.Range(16,24));
              transform.position=randomPosition;
              //Instantiate(tochase,randomPosition,Quaternion.identity);
              //Debug.Log("YOU WON!");
              //Debug.Break();
            }
  }
}
