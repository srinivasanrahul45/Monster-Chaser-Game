using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    public float Score;

    public UnityEngine.UI.Text scoreText;

    public GameObject gamePlayRefrenceObject;

    void Start()
    {
        Score = 0;
        DontDestroyOnLoad(gameObject);
    }

    void FixedUpdate()
    {
        if (gamePlayRefrenceObject != null)
        {
            Score += 0.1f;
        }
        scoreText.text = "Score: " + (int)Score;
    }
}
