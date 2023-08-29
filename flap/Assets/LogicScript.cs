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
    public int checkpoints = 0;
    public Text scoreText;
    public GameObject gameOverScreen;

    public Text goScore;
    public Text goHiScore;

    public AudioSource currSound;
    public AudioClip fall;

    

    // counter to make sure audio plays only once
    public int counter;

    //adds variable to store reference to PipeMove so it can change the speed at which the pipes come
    public SpawnScript spawn;

    private void Start()
    {
        counter = 0;
        currSound = GetComponent<AudioSource>();

        spawn = GameObject.FindGameObjectWithTag("Pipes").GetComponent<SpawnScript>();
    }


    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();

        // every 5 point the player earns the game speeds up by a rate of 1
        if (playerScore == checkpoints + 5)
        {
            spawn.SetPipeSpeed(1);
            checkpoints += 5;
        }
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

        // sets the game over screen player score to be the score that the player achieved.
        goScore.text = ("Score: " + playerScore.ToString());

        // replaces the highscore in text file with current score if it is a larger number, the 0 is there so if there is no "best" text file it will create one and put 0 in it
        if (playerScore > PlayerPrefs.GetInt("Best", 0))
        {
            PlayerPrefs.SetInt("Best", playerScore);
        }

        goHiScore.text = ("Best: " + PlayerPrefs.GetInt("Best", 0).ToString());

        gameOverScreen.SetActive(true);
    }

}


