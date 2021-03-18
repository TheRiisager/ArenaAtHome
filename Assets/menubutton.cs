using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menubutton : MonoBehaviour
{
    private PlayerInputManager inputManager;

    // Update is called once per frame
    void Awake()
    {
        inputManager = PlayerInputManager.Instance;

    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
