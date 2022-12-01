using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmaeraRay : MonoBehaviour
{

    public GameObject player;
    public GameObject body;
    //롤러코스터 부분
    public cubemove cd;
    private bool a = false;
    public Transform un;

    //바이킹 부분
    public GameObject viking;
    public Transform viking_s_point;
    public Transform outvi;
    private bool b = false;
    public VikingScript vk;

    //범퍼카
    public Transform bpPosi;
    public Transform bpOutPosi;
    public bool c = false;
    public float time=0.0f;
    public GameObject bumeper;
    public GameObject bumperBody;
    public GvrEditorEmulator gv;
    public Transform bumperRes;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (c == true)
        {
            time += Time.deltaTime;
        }
        RaycastHit hit;
        Vector3 forward1 = transform.TransformDirection(Vector3.forward) * 100;
        if (Physics.Raycast(transform.position, forward1, out hit))
        {
            //롤러코스터부분
            if (hit.transform.gameObject.GetComponent<cubemove>())
            {
                if (!a)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        player.transform.parent = hit.transform;
                        player.GetComponent<CharacterController>().enabled = false;
                        player.GetComponent<Move>().enabled = false;
                        player.transform.position = hit.transform.position;
                        body.SetActive(false);
                        cd.speed = 5.0f;
                        a = true;
                    }

                }

            }
            //바이킹 부분
            if (hit.transform.tag == "Viking")
            {
                if (!b)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        player.transform.parent = hit.transform;
                        player.GetComponent<CharacterController>().enabled = false;
                        player.GetComponent<Move>().enabled = false;
                        player.transform.position = viking_s_point.position;
                        body.SetActive(false);
                        b = true;
                        StartCoroutine(vikingStart());
                    }
                }
            }
            if (hit.transform.tag == "Bumper")
            {
                if (!c)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        player.transform.parent = bumeper.transform;
                        player.GetComponent<CharacterController>().enabled = false;
                        player.GetComponent<Move>().enabled = false;
                        body.SetActive(false);
                        player.transform.position = bpPosi.transform.position;
                        this.transform.rotation = Quaternion.Euler(15.5f, -1.75f, 0);
                        bumperBody.transform.parent = this.transform;
                        c = true;
                        time = Time.deltaTime;
                        
                    }
                }
            }

        }
        if (cd.b == true && a == true)
        {
            player.transform.parent = null;
            player.transform.position = un.transform.position;
            a = false;
            cd.b = false;
            player.GetComponent<CharacterController>().enabled = true;
            player.GetComponent<Move>().enabled = true;
            body.SetActive(true);
        }
        //롤러 코스터 엔드



        if (b == true && vk.speed == 0.0f)
        {
            player.transform.parent = null;
            player.transform.position = outvi.transform.position;
            player.GetComponent<CharacterController>().enabled = true;
            player.GetComponent<Move>().enabled = true;
            body.SetActive(true);
            b = false;
            vk.speed = 20.0f;

        }
        //바이킹 엔드


        if(c==true && time >= 10)
        {
            bumperBody.transform.parent = bumeper.transform;
            player.transform.parent = null;
            player.transform.position = bpOutPosi.transform.position;
            player.GetComponent<CharacterController>().enabled = true;
            player.GetComponent<Move>().enabled = true;
            body.SetActive(true);
            c = false;
            time = 0.0f;
            bumeper.transform.position = bumperRes.position;
            bumperBody.transform.Translate(Vector3.zero);
            bumperBody.transform.rotation = Quaternion.Euler(0, 91.076f, 0);

        }
        //범퍼카 엔드



    }

    IEnumerator vikingStart()
    {
        yield return new WaitForSeconds(1f);

        viking.transform.GetComponent<VikingScript>().IsStart();

    }
}
