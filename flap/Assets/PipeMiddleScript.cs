using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;

    // creates variable to store musicScript reference.
    public MusicScript music;

    // Start is called before the first frame update
    void Start()
    {
        // gets the MusicScript from the AudioManager object so its classes can be used here.
        music = GameObject.FindGameObjectWithTag("Sound").GetComponent<MusicScript>();

        // same with LogicScript
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            music.playPoint();
            logic.addScore(1);
        }
    }
}
