using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// only imports basic things for unity usage, so if you want to be able to write a script for UI, you'd have to import the UI package so you can reference it.
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    // creates a variable for you to drag the object into so the script knows what object the code is referring to.
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;


    public AudioSource currSound;
    public AudioClip fall;

    // counter to make sure audio plays only once
    public int counter;

    private void Start()
    {
        counter = 0;
        currSound = GetComponent<AudioSource>();
    }


    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        if (counter == 0){
            currSound.clip = fall;
            currSound.Play();
            counter++;
        }
       
        gameOverScreen.SetActive(true);
    }

}


