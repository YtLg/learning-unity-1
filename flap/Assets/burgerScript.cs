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

    // creates variable to store musicScript reference.
    public MusicScript music;

    public int counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        burgerLife = true;

        // gets the logic script (copied from pipeMiddle) so it can use logic classes)
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        // gets the MusicScript from the AudioManager object so its classes can be used here.
        music = GameObject.FindGameObjectWithTag("Sound").GetComponent<MusicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // so after you've referenced the rigidBody so it knows that it exists, you can now use it:

        // for the first time that space is pressed (will not run again until space has been released) so long as the burger is alive..?:
        if (Input.GetKeyDown(KeyCode.Space) && burgerLife == true)
        {
            music.playFlap();

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
        music.playHit();

        logic.gameOver();

        // sets burger life to false
        burgerLife = false;


        if (burgerLife == false && counter == 0){
            counter++;
            GetComponent<AudioSource>().Stop();
            music.playDeath();
        }

    }
}
