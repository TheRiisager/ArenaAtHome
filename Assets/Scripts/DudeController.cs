using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeController : MonoBehaviour
{
    [SerializeField] float timerDuration;
    private float timeRemaining;
    Transform[] spawnPoints;

    void Start()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
        timeRemaining = timerDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeRemaining > 0){
            timeRemaining -= Time.deltaTime;
        } else {
            int random = Random.Range(0, spawnPoints.Length - 1);
            Instantiate(Resources.Load("small_dude_prefab"), spawnPoints[random]);

            timeRemaining = timerDuration;
        }
    }
}
