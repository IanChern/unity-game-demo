using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTrap : MonoBehaviour
{
    // **** START CODE SNIPPET 1 ****

    public static float spiderTrigger = 0;

    GameObject spiderObject;

    public AudioSource spiderScream;
    // Start is called before the first frame update
    void Start()
    {
        spiderTrigger = 0;

        spiderObject = GameObject.Find("Spider");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.name == "Player")
        {
            spiderTrigger = 1;
            spiderScream.Play();
            spiderObject.GetComponent<AudioSource>().Stop();
        }
    }

    // **** END CODE SNIPPET 1 ****
}

// REFERENCES
// CODE SNIPPET 1: (Spider Bite Audio Source Raw File Reference) - IEEE Reference [18]
