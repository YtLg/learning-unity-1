using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject pipes;
    public float timer = 0;
    public float spawnRate = 2;

    public float heightOffset = 10;

    public float rate;


    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }

        else
        {
            SpawnPipe();
            timer = 0;
        }
    }

    void SpawnPipe()
    {
        // creates the minimum and maximum Y position the pipes can spawn in by using a calculation, can create a variable doing this because it's local inside spawnPipe.
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        // makes it so the pipes spawn at a y value between the lowest and highest point, therefore randomizing the spawn
        Instantiate(pipes, new Vector3(transform.position.x, Random.Range(lowestPoint,highestPoint), 0),  transform.rotation);
    }

    public void SetPipeSpeed(float speed)
    {
        rate += speed;
    }

    public float GetPipeSpeed()
    {
        return rate;
    }
}
