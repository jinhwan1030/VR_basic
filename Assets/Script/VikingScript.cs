using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class VikingScript : MonoBehaviour
{
    public float speed = 20.0f;
    private bool check = true;
    private bool acc = false;
    private bool stop = false;

    public bool End = false;

   

    private bool isStart = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isStart);
        if (isStart)
        {
            StartCoroutine(Acc());
            if (check)
                rotRight();
            else
                rotLeft();

            if (!stop && acc && speed <= 80)
                speed += 0.2f;
            else if (!acc && speed >= 20)
                speed -= 0.1f;

            if (transform.rotation.eulerAngles.x >= 80 && transform.rotation.eulerAngles.x <= 90)
            {
                check = false;
                acc = true;
            }
            else if (transform.rotation.eulerAngles.x >= 270 && transform.rotation.eulerAngles.x <= 280)
            {
                check = true;
                acc = true;
            }

            if (transform.rotation.eulerAngles.x >= 0 && transform.rotation.eulerAngles.x <= 10)
            {
                acc = false;
            }
            if (transform.rotation.eulerAngles.x >= 350 && transform.rotation.eulerAngles.x <= 360)
            {
                acc = false;
            }
            
            
        }


    }

    IEnumerator Acc()
    {
        yield return new WaitForSeconds(30.0f);
        stop = true;
        if (speed >= 15)
            speed -= 0.05f;


        if (speed <= 15 && transform.rotation.eulerAngles.x >= -3 && transform.rotation.eulerAngles.x <= 1)
        {
            speed = 0;
            if (End)
            {
                End = false;
               
            }
        }
        else
        {
            End = true;
        }
            

    }
    void rotRight()
    {
        transform.Rotate(Vector3.right * Time.deltaTime * speed);
    }
    void rotLeft()
    {
        transform.Rotate(Vector3.left * Time.deltaTime * speed);
    }

    public void IsStart()
    {
        isStart = true;
    }

    
}
