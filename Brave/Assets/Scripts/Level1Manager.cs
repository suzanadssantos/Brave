using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    public float moveSpeed = 2f; 
    public float rotationSpeed = 100f; 
    public float moveRangeUp = 1f;
    public float moveRangeDown = 1f; 
    public GameObject[] platformsUp;
    public Vector3[] startPositionPlatformsUp;
    public GameObject[] platformsDown;
    public Vector3[] startPositionPlatformsDown;
    private Vector3 startPosition;
    public GameObject[] chestMonster;

    // Start is called before the first frame update
    void Start()
    {
        // Platforms position
        for(int i = 0; i < platformsUp.Length; i++){
            startPositionPlatformsUp[i] = platformsUp[i].transform.position;
        }

        for(int i = 0; i < platformsDown.Length; i++){
            startPositionPlatformsDown[i] = platformsDown[i].transform.position;
        }

        // Chest Monster position
        startPosition = chestMonster[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the platforms
        for(int i = 0; i < platformsUp.Length; i++){
            float newY = startPositionPlatformsUp[i].y + Mathf.Sin(Time.time * moveSpeed) * moveRangeUp;
            platformsUp[i].transform.position = new Vector3(platformsUp[i].transform.position.x, newY, platformsUp[i].transform.position.z);
        }

        for(int i = 0; i < platformsDown.Length; i++){
            float newY = startPositionPlatformsDown[i].y + Mathf.Sin(Time.time * moveSpeed) * moveRangeDown;
            platformsDown[i].transform.position = new Vector3(platformsDown[i].transform.position.x, newY, platformsDown[i].transform.position.z);
        }

        // Move the chest monsters
        float z = Mathf.Sin(Time.time * 3f) * 1f;
        chestMonster[0].transform.position = startPosition + new Vector3(0, 0, z);
    }
}
