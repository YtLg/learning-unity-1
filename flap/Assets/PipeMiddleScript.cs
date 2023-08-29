using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    public BurgerScript burger;

    // audio variables
    public AudioSource currSound;
    public AudioClip score;

    // Start is called before the first frame update
    void Start()
    {
        currSound = GetComponent<AudioSource>();

        // same with LogicScript
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        burger = GameObject.FindGameObjectWithTag("Player").GetComponent<BurgerScript>();
    }


    // The player object won't actually be stopped by pipe middle, as the "is trigger" box is checked, meaning that it will still run upon collision, but it will not have a physical collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // only runs the following code if the burger is still alive
        if (collision.gameObject.layer == 3 && burger.GetLife() == true)
        {
            currSound.clip = score;
            currSound.Play();
            logic.AddScore(1);
        }
    }
}
