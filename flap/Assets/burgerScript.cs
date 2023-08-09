using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burgerScript : MonoBehaviour
{
    // by default, the script only sees the name and transformation components of the object, so you have to create a rigidBody2D slot for it and drag it into the slot in unity
    public Rigidbody2D myRigidbody;
    public LogicScript logic;
 
    public bool burgerLife;
    public float flapStrength;

    public SpriteRenderer gameobject;
    public Sprite sprite0;
    public Sprite sprite1;


    // audio variables
    public AudioSource currSound;
    public AudioClip flap;
    public AudioClip hit;


    public int counter;

    // Start is called before the first frame update
    void Start()
    {
        currSound = GetComponent<AudioSource>();
        counter = 0;

        burgerLife = true;

        // gets the logic script (copied from pipeMiddle) so it can use logic classes)
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // so after you've referenced the rigidBody so it knows that it exists, you can now use it:

        // for the first time that space is pressed (will not run again until space has been released) so long as the burger is alive..?:
        if (Input.GetKeyDown(KeyCode.Space) && burgerLife == true)
        {
            currSound.clip = flap;
            currSound.Play();

            // rotates the object upwards for the animation
            transform.Rotate(0.0f, 0.0f, 14.216f, Space.Self);

            //if you want to change the velocity you have to state a vector coordinate of where you want it to go, it must be done by using a vector object
            myRigidbody.velocity = new Vector2(0.0f, 1.0f) * flapStrength;

            // changes the sprite image to be sprite1
           gameobject.sprite = sprite1;
        }

        // if space is let go:
        if (Input.GetKeyUp(KeyCode.Space) && burgerLife == true)
        {
            transform.Rotate(0.0f, 0.0f, -14.216f, Space.Self);
            gameobject.sprite = sprite0;
        }

    //This is a shorthand version (premade vector object from library that represents the same thing as above):
    // myRigidbody.velocity = Vector2.up *10;
}

    // Class that runs when the bird collides with something.
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (counter == 0)
        {
            currSound.clip = hit;
            currSound.Play();
        }

        logic.gameOver();

        // sets burger life to false
        burgerLife = false;

    }

    // noticed that point sound still happens when burger is dead, so I made a "getter" in order to provide the life status of the burger
    public bool getLife()
    {
        return burgerLife;
    }

    // added a setter for burgerLife so other scripts can make a game-over by setting this.
    public void setLife(bool set)
    {
        burgerLife = set;
    }
}
