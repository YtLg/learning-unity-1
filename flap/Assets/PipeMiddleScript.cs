using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    public burgerScript burger;

    // audio variables
    public AudioSource currSound;
    public AudioClip score;

    // Start is called before the first frame update
    void Start()
    {
        currSound = GetComponent<AudioSource>();

        // same with LogicScript
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        burger = GameObject.FindGameObjectWithTag("Player").GetComponent<burgerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // only runs the following code if the burger is still alive
        if (collision.gameObject.layer == 3 && burger.getLife() == true)
        {
            currSound.clip = score;
            currSound.Play();
            logic.addScore(1);
        }
    }
}
