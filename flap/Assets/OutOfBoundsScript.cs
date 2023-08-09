using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsScript : MonoBehaviour
{
    // reference the LogicScript so you can get the gameover function
    public LogicScript logic;

    public burgerScript burger;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        // gets the burgerScript so it can use setLife to make a game over
        burger = GameObject.FindGameObjectWithTag("Player").GetComponent<burgerScript>();
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logic.gameOver();
            burger.setLife(false);
            Debug.Log("hello");
        }
    }

}
