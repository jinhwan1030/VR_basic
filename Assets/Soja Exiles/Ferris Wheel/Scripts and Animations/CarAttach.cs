using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAttach : MonoBehaviour {

    public GameObject Player;
    public bool a = false;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = transform;
            a = true;
            
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
            a = false;
           
        }
    }
}