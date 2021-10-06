using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUIController : MonoBehaviour
{
    public GameObject toDestroy;

    private void Start()
    {
        toDestroy = GameObject.FindGameObjectWithTag("Finish");
    }

    public void RestartGame() {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Gameplay");    }

    public void pauseResumeGame()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void endGame()
    {
        Application.Quit();
    }

    public void goMainMenu()
    {
        Destroy(toDestroy);
        SceneManager.LoadScene("Main Menu");
    }

    public void helpMenu()
    {
        SceneManager.LoadScene("Help Menu");
    }
}
