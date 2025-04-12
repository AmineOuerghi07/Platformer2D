using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] Vector2 playerPos;
    [SerializeField] GameObject pauseMenu;
    bool paused = false;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }
    public void LoadCheckpoint()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void LoadNextScene()
    {
        PlayerPos.d = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        paused = false;
 
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
        paused = true;
    }

    public void PauseGame()
    {
        if ((Input.GetKeyDown(KeyCode.P) || (Input.GetKeyDown(KeyCode.Escape))) && paused == false)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            paused = true;
        }

    }

    public void ResumeGame()
    {
        paused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void SetPaused(bool p)
    {
        paused = p;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
