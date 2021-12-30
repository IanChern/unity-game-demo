using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rush : MonoBehaviour
{
    // **** START CODE SNIPPET 1 ****

    GameObject player;

    public AudioSource ghostCry;

    GameObject laserObject;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        laserObject = GameObject.Find("Player Laser");
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerLaserPos.stareTimer > 300)
        {
            if (!ghostCry.isPlaying)
            {
                ghostCry.Play();
                //Debug.Log("play ghost cry");
            }
            
            transform.LookAt(player.transform);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .04f);
            StartCoroutine(isHaunted());
            laserObject.GetComponent<AudioSource>().Stop();
        }


    }

    IEnumerator isHaunted()
    {
        //transform.LookAt(player.transform);
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .02f);
        yield return new WaitForSecondsRealtime(1.2f);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(3);
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
// CODE SNIPPET 1: (Full Reference w/ Object Moving and Looking Towards Player) - IEEE Reference [7]
// CODE SNIPPET 1: (Ghost Idle Audio Source Raw File Reference) - IEEE Reference [23]
// CODE SNIPPET 1: (Partial Reference w/ StartCorountine and IEnumerator) - IEEE Reference [27]
// CODE SNIPPET 1: (Full Reference w/ ApplicationQuit) - IEEE Reference [30]
