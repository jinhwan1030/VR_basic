using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class bumperCar : MonoBehaviour
{
    public float speed=15f;
    public CmaeraRay cv;
    public Transform re;

    // Start is called before the first frame update
    void Start()
    {
        re.transform.position = this.transform.position;
        re.transform.rotation = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (cv.c == true)
        {
            this.transform.Translate(-Vector3.right * speed * Time.deltaTime);
        }
        if (cv.c == false)
        {
            this.transform.position = re.transform.position;
            this.transform.rotation = re.transform.rotation;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "wall")
        {
            this.transform.Rotate(0, 120f, 0);
        }
    }
}
