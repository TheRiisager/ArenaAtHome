using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    private Text thisText;
    private int tid;

    private float timeSurvived;

    void Start()
    {
        thisText = GetComponent<Text>();
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {

        float t = Time.timeSinceLevelLoad;

        timeSurvived = t;

        // update text of Text element
        thisText.text = "Time: " + t;

    }

    public float GetTimeSurvived()
    {
        Debug.Log("Tid overløvet" + timeSurvived);
        return timeSurvived;
    }

}