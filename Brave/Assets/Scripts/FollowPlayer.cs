using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 playerPosition =  new Vector3(0, 1, -5);

    // Update is called once per frame
    void Update () {
        transform.position = player.transform.position + playerPosition;
    }

}