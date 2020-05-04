using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    private string laneChange = "no";
    private string jumping = "no";

    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 3);
    }


    void Update()
    {
        if (Input.GetKey("a") && laneChange == "no" && jumping == "no" && transform.position.x>-1.9)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-1, 0, 3);
            laneChange = "yes";
            StartCoroutine(stopLaneChange());
        }

        if (Input.GetKey("d") && laneChange == "no" && jumping == "no" && transform.position.x < 1.9)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(1, 0, 3);
            laneChange = "yes";
            StartCoroutine(stopLaneChange());
        }

        if (Input.GetKey("space") && jumping == "no" && laneChange == "no")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 2, 3);
            jumping = "yes";
            StartCoroutine(stopJump());
        }

        IEnumerator stopJump()
        {
            yield return new WaitForSeconds(.75f);
            GetComponent<Rigidbody>().velocity = new Vector3(0, -2, 3);
            yield return new WaitForSeconds(.75f);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 3);
            jumping = "no";
        }
    }

    IEnumerator stopLaneChange()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 3);
        laneChange = "no";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            Debug.Log("ouch");
        }
    }
}
