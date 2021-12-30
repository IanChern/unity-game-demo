using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpiderRush2 : MonoBehaviour
{
    // **** START CODE SNIPPET 1 ****

    GameObject spiderStopper;

    public static bool spiderRush = false;

    // Start is called before the first frame update
    void Start()
    {
        spiderStopper = GameObject.Find("SpiderStopper2");
    }

    // Update is called once per frame
    void Update()
    {
       if (SpiderTrap2.spiderTrigger == 1)
        {
            spiderRush = true;
            transform.position = Vector3.MoveTowards(transform.position, spiderStopper.transform.position, .05f);
            StartCoroutine(isBitten());
        }
    }

    IEnumerator isBitten()
    {
        yield return new WaitForSecondsRealtime(2f);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(4);
    }

    // **** END CODE SNIPPET 1 ****
}

// REFERENCES
// CODE SNIPPET 1: (Full Reference w/ Object Moving Towards Player) - IEEE Reference [7]
// CODE SNIPPET 1: (Partial Reference w/ StartCorountine and IEnumerator) - IEEE Reference [27]
// CODE SNIPPET 1: (Full Reference w/ ApplicationQuit) - IEEE Reference [30]

