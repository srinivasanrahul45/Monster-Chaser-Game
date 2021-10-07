using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collector : MonoBehaviour
{
    private string ENEMY_TAG = "Enemy";
    private string PLAYER_TAG = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG)) {
            Destroy(collision.gameObject);
        } else if (collision.CompareTag(PLAYER_TAG))
        {
            SceneManager.LoadScene("Game Over Menu");
            Destroy(collision.gameObject);
        }
    }
}
