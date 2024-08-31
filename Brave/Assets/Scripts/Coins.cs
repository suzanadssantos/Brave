using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public float moveSpeed = 2f; // Velocidade de movimento vertical
    public float rotationSpeed = 100f; // Velocidade de rotação
    public float moveRange = 1f; // Amplitude do movimento vertical

    public Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Movimento vertical
        float newY = startPosition.y + Mathf.Sin(Time.time * moveSpeed) * moveRange;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Rotação em torno do eixo Y
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
