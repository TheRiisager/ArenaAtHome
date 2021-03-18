using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] AudioSource pauseMusic;

    [SerializeField] AudioSource gameMusic;
    public static bool GamePaused = false;

    public GameObject pauseMenuUI;

    private PlayerInputManager inputManager;

    // Update is called once per frame
    void Awake()
    {
        inputManager = PlayerInputManager.Instance;
        gameMusic.Play();
        pauseMusic.Pause();

    }
    void Update()
    {
        if (inputManager.PlayerPaused() == true)
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        gameMusic.Play();
        pauseMusic.Pause();

    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        pauseMusic.Play();
        gameMusic.Pause();

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game..");
        Application.Quit();
    }
}
