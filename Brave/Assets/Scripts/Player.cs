using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    public Animator animator;

    // Sounds
    public AudioClip jumpSound;
    private AudioSource jumpSource;
    
    public bool isGrounded;
    public float jumpForce = 5f;
    public float gravity = 9.81f;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Jump Sound
        jumpSource = GetComponent<AudioSource>();  
        jumpSource.clip = jumpSound;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Jump();
    }

    private void MovePlayer(){
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moving = new Vector3(horizontal, 0, vertical);
        moving.y = 0;

        controller.Move(moving * Time.deltaTime * 10);
        controller.Move(new Vector3(0, -9.81f, 0) * Time.deltaTime);

        if(moving != Vector3.zero){
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moving), Time.deltaTime * 10);
            animator.SetBool("isWalking", true);
        }else{
            animator.SetBool("isWalking", false);
        }
    }

    private void Jump(){
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            velocity.y = jumpForce;
            animator.SetBool("isJumping", true);
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
        }else{
            animator.SetBool("isJumping", false);
        }

        // Apply gravity
        velocity.y -= gravity * Time.deltaTime;

        // Move the character
        controller.Move(velocity * Time.deltaTime);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        // Game Over
        if (other.tag == "Game Over")
        { 
            gameObject.SetActive(false);
        }

        if (other.tag == "Treasure")
        { 
            Destroy(other.gameObject);
            animator.SetBool("newLevel", true);
        }
    }
}
