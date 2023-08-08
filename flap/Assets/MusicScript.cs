using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    // allows different audio clips to be referenced and used by the script allowing it to run different sounds
    public AudioSource currSound;
    public AudioClip hit;
    public AudioClip death;
    public AudioClip flap;
    public AudioClip point;
    

    

    // Start is called before the first frame update
    void Start()
    {
        currSound = GetComponent<AudioSource>();
    }

    public void playHit()
    {
        currSound.clip = hit;
        currSound.Play();
    }

    public void playDeath()
    {
        currSound.clip = death;
        currSound.Play();
    }

    public void playFlap()
    {
        currSound.clip = flap;
        currSound.Play();
    }

    public void playPoint()
    {

        currSound.clip = point;
        currSound.Play();
    }


}
