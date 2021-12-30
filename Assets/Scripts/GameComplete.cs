using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameComplete : MonoBehaviour
{
    // **** START CODE SNIPPET 1 ****

    private TMP_Text timerTxt;

    void Start()
    {
        timerTxt = GetComponent<TMP_Text>();
        timerTxt.text = "Timer: " + Mathf.Round(Player.completionTimer * 10.0f) * 0.1f + " sec/s";
    }

    // **** END CODE SNIPPET 1 ****
}

// REFERENCES
// CODE SNIPPET 1: (Full Reference w/ TMP_Text) - IEEE Reference [15]
// CODE SNIPPET 1: (Full Reference w/ Mathf) - IEEE Reference [16]