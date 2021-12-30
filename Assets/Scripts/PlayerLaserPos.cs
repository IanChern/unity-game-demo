using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLaserPos : MonoBehaviour
{
    // **** START CODE SNIPPET 1 ****

    private LineRenderer lr;

    GameObject player;

    Vector3 index0;
    Vector3 offset0;

    public static int stareTimer;

    float ghostStareVol;

    public AudioSource ghostPassBy;


    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();

        player = GameObject.Find("Player");

        ghostPassBy = this.gameObject.GetComponent<AudioSource>();

        stareTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        offset0 = new Vector3(player.transform.position.x, player.transform.position.y + 0.52f, player.transform.position.z);
        lr.SetPosition(0, offset0);

        RaycastHit hit;

        if (Physics.Raycast(offset0, transform.TransformDirection(Vector3.forward), out hit))
        {
            if (hit.collider.name == "Ghost")
            {
                ghostPassBy.GetComponent<AudioSource>().Play();
                stareTimer++;
                ghostStareVol = (float)stareTimer / 100f / 4f;
                ghostPassBy.GetComponent<AudioSource>().volume = ghostStareVol;

                //lr.SetPosition(1, hit.point);
                //Debug.Log("stare ghost time is " + ghostStareVol );

            }
            else
            {
                //ghostPassBy.GetComponent<AudioSource>().Stop();
                lr.SetPosition(1, offset0 + transform.TransformDirection(Vector3.forward) * 50);
            }

        }
        else
        {
            ghostPassBy.GetComponent<AudioSource>().Stop();
            lr.SetPosition(1, offset0 + transform.TransformDirection(Vector3.forward) * 50);
        }
    }

    private void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
    }

    // **** END CODE SNIPPET 1 ****
}

// REFERENCES
// CODE SNIPPET 1: (Full Reference w/ Torch Modifications) - IEEE Reference [1]
// CODE SNIPPET 1: (Full Reference w/ Player Movements) - IEEE Reference [2]
// CODE SNIPPET 1: (Partial Reference w/ Laser Reposition Attached to Player) - IEEE Reference [5]
// CODE SNIPPET 1: (Ghost Idle Audio Source Raw File Reference) - IEEE Reference [24]
// CODE SNIPPET 1: (Full Reference w/ ApplicationQuit) - IEEE Reference [30]
// CODE SNIPPET 1: (Partial Reference w/ Laser Hit Detection) - IEEE Reference [32]
