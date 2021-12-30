using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class Player : MonoBehaviour
{
    // **** START CODE SNIPPET 1 ****

    [SerializeField] private float moveSpeed = 3f;

    public CharacterController controller;

    private Light spotLight;
    private bool torchOn;

    float timer;

    public static int laserLoopStart;

    GameObject spotLightPos;

    public static float completionTimer = 0;

    GameObject pumpkin;
    GameObject pumpkin2;

    float distance;
    float distanceP2;

    Vector3 move;

    GameObject spider;

    GameObject spider2;
    void Start()
    {
        spotLight = GetComponentInChildren<Light>();
        torchOn = false;

        timer = 0.0f;

        spotLightPos = GameObject.Find("spotlight");

        pumpkin = GameObject.Find("Pumpkin");
        pumpkin2 = GameObject.Find("Pumpkin2");

        spider = GameObject.Find("Spider");
        spider2 = GameObject.Find("Spider2");
    }

    void Update()
    {
        completionTimer += Time.deltaTime;

        timer += Time.deltaTime;

        torchLight();

        movementWASD();

        isPetrified();

        spiderRush();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
            
}

    private void torchLight()
    {
        if (Input.GetKeyDown(KeyCode.T) && torchOn)
        {
            spotLight.enabled = false;
            torchOn = false;
            //Debug.Log("torch off");
        }
        else if (Input.GetKeyDown(KeyCode.T) && !torchOn)
        {
            spotLight.enabled = true;
            torchOn = true;
            //Debug.Log("torch on");
        }
    }

    private void movementWASD()
    {
        if (!SpiderRush.spiderRush && !SpiderRush2.spiderRush)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            move = transform.right * x + transform.forward * z;
            controller.Move(move * moveSpeed * Time.deltaTime);

            //Debug.Log("speed: " + controller.velocity.magnitude);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "completeTrigger")
        {
            //OnApplicationQuit();
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(1);
        }
    }

    private void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
    }

    private void isPetrified()
    {
        distance = Vector3.Distance(this.gameObject.transform.position, pumpkin.transform.position);
        distanceP2 = Vector3.Distance(this.gameObject.transform.position, pumpkin2.transform.position);

        // Close to pumpkin = Game Over
        if (distance < 3 || distanceP2 < 3)
        {
            //Debug.Log("distance" + distance);

            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2);
        }
    }

    private void spiderRush()
    {
        if(SpiderTrap.spiderTrigger == 1)
        {
            transform.LookAt(spider.transform);
        }

        if (SpiderTrap2.spiderTrigger == 1)
        {
            transform.LookAt(spider2.transform);
        }

    }

    // **** END CODE SNIPPET 1 ****
}

// REFERENCES
// CODE SNIPPET 1: (Full Reference w/ Torch Modifications) - IEEE Reference [1]
// CODE SNIPPET 1: (Full Reference w/ Player Movements) - IEEE Reference [2]
// CODE SNIPPET 1: (Full Reference w/ Player Looking Towards Object) - IEEE Reference [7]
// CODE SNIPPET 1: (Partial Reference w/ StartCorountine and IEnumerator) - IEEE Reference [27]
// CODE SNIPPET 1: (Partial Reference w/ Light Script) - IEEE Reference [29]
// CODE SNIPPET 1: (Full Reference w/ ApplicationQuit) - IEEE Reference [30]
// CODE SNIPPET 1: (Full Reference w/ Distance Calculation) - IEEE Reference [31]
