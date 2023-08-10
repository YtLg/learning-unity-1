using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsScript : MonoBehaviour
{
    // reference the LogicScript so you can get the gameover function
    public LogicScript logic;

    public BurgerScript burger;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        // gets the burgerScript so it can use setLife to make a game over
        burger = GameObject.FindGameObjectWithTag("Player").GetComponent<BurgerScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logic.GameOver();
            burger.SetLife(false);
            Debug.Log("hello");
        }
    }

}
