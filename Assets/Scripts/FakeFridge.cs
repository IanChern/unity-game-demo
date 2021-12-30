using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FakeFridge : MonoBehaviour
{
    // **** START CODE SNIPPET 1 ****

    GameObject fakeFridge;

    public GameObject zombiePrefab;

    public AudioSource ZombieAttack;

    // Start is called before the first frame update
    void Start()
    {
        fakeFridge = GameObject.Find("FakeFridge");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Player")
        {
            //spiderTrigger = 1;
            //transform.position = Vector3.MoveTowards(spider.transform.position, spiderStopper.transform.position, .09f);
            Destroy(fakeFridge);
            Instantiate(zombiePrefab, new Vector3(4, 0, 17.5f), Quaternion.Euler(0, 180, 0));
            StartCoroutine(zombieAttack());
            playZombieAttack();
        }
    }

    IEnumerator zombieAttack()
    {
        yield return new WaitForSecondsRealtime(3f);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(5);
    }

    void playZombieAttack()
    {
         ZombieAttack.Play();
    }

    // **** END CODE SNIPPET 1 ****
}

// REFERENCES
// CODE SNIPPET 1: (Full Reference w/ AudioSource Insertion) - IEEE Reference [4]
// CODE SNIPPET 1: (Zombie Attack Audio Source Raw File Reference) - IEEE Reference [20]
// CODE SNIPPET 1: (Full Reference w/ IENumerator) - IEEE Reference [27]
// CODE SNIPPET 1: (Full Reference w/ Instantiate) - IEEE Reference [28]

