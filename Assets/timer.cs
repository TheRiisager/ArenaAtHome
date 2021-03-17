using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    private Text thisText;
    private int tid;

    void Start()
    {
        thisText = GetComponent<Text>();
    }

    void Update()
    {

        float t = Time.timeSinceLevelLoad;

        float timeSurvived = t;

        // update text of Text element
        thisText.text = "Time: " + t;
    }

}