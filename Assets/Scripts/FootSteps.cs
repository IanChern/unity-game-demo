using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    // **** START CODE SNIPPET 1 ****

    CharacterController cc;

    public AudioClip otherClip;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cc.velocity.magnitude != 0 && !audioSource.isPlaying)
        {
            audioSource.clip = otherClip;
            audioSource.Play();
        }
        else if (cc.velocity.magnitude == 0 && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        else if (SpiderTrap.spiderTrigger == 1 || SpiderTrap2.spiderTrigger == 1)
        {
            audioSource.Stop();
        }
    }

    // **** END CODE SNIPPET 1 ****
}

// REFERENCES
// CODE SNIPPET 1: (Full Reference w/ Footsteps Sound Check) - IEEE Reference [6]
// CODE SNIPPET 1: (Footsteps Audio Source Raw File Reference) - IEEE Reference [21]