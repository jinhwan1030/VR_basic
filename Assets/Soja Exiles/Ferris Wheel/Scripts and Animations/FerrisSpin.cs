using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerrisSpin : MonoBehaviour {
    public float speed;
    public CarAttach car;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (car.a==true)
        {
            speed = 5.0f;
            transform.Rotate(new Vector3(0, 0, -1f), speed * Time.deltaTime);
        }
        if(car.a==false)
        {
            speed = 0;
        }
            
    }
  
}
