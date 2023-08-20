using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuScript : MonoBehaviour
{
    // creates a variable to store reference to text object
    public Text menuBest;

    private void Start()
    {
        menuBest.text = ("Best: " + PlayerPrefs.GetInt("Best", 0));
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
