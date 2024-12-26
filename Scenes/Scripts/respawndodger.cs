using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class respawndodger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tochase;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="player")
        {
            Destroy(gameObject);
            Vector3 randomPosition = new Vector3(Random.Range(-6,7),-1,Random.Range(16,24));
            Instantiate(tochase,randomPosition,Quaternion.identity);
        }
    }
}
