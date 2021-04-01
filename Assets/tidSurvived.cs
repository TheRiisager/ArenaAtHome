using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tidSurvived : MonoBehaviour
{
    private Text thisText;

    private timer tidtager;

    void Start()
    {
        thisText = GetComponent<Text>();
        tidtager = GetComponent<timer>();
        float t = tidtager.GetTimeSurvived();
    }

}
