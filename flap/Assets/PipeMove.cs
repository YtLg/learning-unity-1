using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float moveSpeed;
    public float deadZone = -45;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // uses Time.deltaTime instead of a flat value (like in the bird script) because it will run as many times as it updates
        // meaning higher framerates will cause the pipes to move slower, and vice versa. But Time.deltaTime ensures that it will be the same regardless of framerate.
        transform.position = transform.position + (Vector3.left * moveSpeed) *Time.deltaTime;


        // Makes it so if the x position of the pipe is lower than the threshold set, it will destroy the gameObject with this script as a component.
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
