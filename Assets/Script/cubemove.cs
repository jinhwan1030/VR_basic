using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

public class cubemove : MonoBehaviour
{
   public float speed;
    private float rosp = 12.0f;
    private float downsp = 10.0f;
    public Transform un;
    public bool b = false;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.0f;
        un.transform.rotation = this.transform.rotation;
        un.transform.position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position += transform.up * speed * Time.deltaTime;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.gameObject.tag == "Left")
        {
            
            this.transform.Rotate(0,0, -90*rosp*Time.deltaTime);
        }
        if (other.transform.gameObject.tag == "Up")
        {
            speed = 3.0f;
            this.transform.GetComponent<Rigidbody>().useGravity = false;
            this.transform.Rotate(60 * rosp * Time.deltaTime, 0, 0);
        }
        if (other.transform.gameObject.tag == "Slowly")
        {
            
            this.transform.GetComponent<Rigidbody>().useGravity = true;
            this.transform.Rotate(-60 * rosp * Time.deltaTime, 0, 0);
        }
        if (other.transform.gameObject.tag == "Nogravity")
        {
            speed = 5.0f;
            
        }
        if (other.transform.gameObject.tag == "Down")
        {
            this.transform.Rotate(-30 * downsp * Time.deltaTime, 0, 0);
            speed = 1.0f;
        }
        if (other.transform.gameObject.tag == "Down2")
        {
            this.transform.Rotate(-90 * rosp * Time.deltaTime, 0, 0);
            speed = 10.0f;
        }
        if (other.transform.gameObject.tag == "Common")
        {
            speed = 12.0f;
            this.transform.GetComponent<Rigidbody>().useGravity = true;
            this.transform.Rotate(90 * rosp * Time.deltaTime, 0, 0);
            
        }
        if (other.transform.gameObject.tag == "Up2")
        {

            this.transform.GetComponent<Rigidbody>().useGravity = false ;
            this.transform.Rotate(90 * rosp * Time.deltaTime, 0, 0);
        }
        if (other.transform.gameObject.tag == "Left2")
        {
            speed = 3.0f;
            this.transform.GetComponent<Rigidbody>().useGravity = true;
            this.transform.Rotate(0, 3f, -90 * rosp * Time.deltaTime);
        }
        if (other.transform.gameObject.tag == "Left3")
        {
            this.transform.GetComponent<Rigidbody>().useGravity = true;
            this.transform.Rotate(0, 0, -90 * rosp * Time.deltaTime);
        }
        if (other.transform.gameObject.tag == "Common2")
        {

            this.transform.Rotate(80 * rosp * Time.deltaTime, 0, 0);

        }
        if (other.transform.gameObject.tag == "Right")
        {
            this.transform.Rotate(0, 0, 90 * rosp * Time.deltaTime);
        }
        if(other.transform.gameObject.tag == "Right2")
        {
            this.transform.Rotate(0, 0, 100 * rosp * Time.deltaTime);
        }
        if (other.transform.gameObject.tag == "Down3")
        {
            
            this.transform.Rotate(-90 * rosp * Time.deltaTime, 0, 0);
           
        }
        if (other.transform.gameObject.tag == "Speed5")
        {
            speed = 5.0f ;

        }
        if (other.transform.gameObject.tag == "Stop")
        {
            this.transform.rotation = un.transform.rotation;
            this.transform.position = un.transform.position;
            speed = 0;
            b = true;

        }
    }

}

