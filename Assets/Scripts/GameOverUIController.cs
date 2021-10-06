using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    public GameObject toDestroy;

    private void Start()
    {
        toDestroy = GameObject.FindGameObjectWithTag("Finish");
    }

    public void RestartGame()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Destroy(toDestroy);
        SceneManager.LoadScene("Gameplay");
    }
    
    public void goMainMenu()
    {
        Destroy(toDestroy);
        SceneManager.LoadScene("Main Menu");
    }
}
