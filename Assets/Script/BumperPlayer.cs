using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class BumperPlayer : MonoBehaviour
{
    public CmaeraRay player;
    public Transform cam;
    public float speed = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (player.c == true) {
            Vector3 forward = cam.TransformDirection(-Vector3.right);

            this.transform.Translate(forward * speed * Time.deltaTime);
            

        }


    }

}
