using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public float moveSpeed = 2f; 
    public float rotationSpeed = 100f; 
    public float moveRange = 1f; 
    public Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * moveSpeed) * moveRange;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
    }

    // Destroy the coins
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        { 
            Destroy(gameObject);
        }
    }
}
