using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private int playerScore;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Image[] lives;
    private int livesLeft;
    [SerializeField] private Sprite heartGone;
    // Start is called before the first frame update
    void Start()
    {
        
        livesLeft = 3;
        playerScore = 0;
        scoreText.text = "Score: " + playerScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore(int points)
    {
        playerScore += points;
        scoreText.text = "Score: " + playerScore.ToString();
    }
    public void UpdateLives()
    {
        //if there is 1 heart and we have a collison, we reset
        if (livesLeft > 1)
        {
            lives[livesLeft-1].sprite = heartGone;
            livesLeft -= 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            //game over, reset
            Destroy(this.gameObject);
            SceneManager.LoadSceneAsync(3);
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
