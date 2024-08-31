using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 jump;
    private float jumpForce = 25.0f;
    public bool isGrounded;
    public float speedWalk = 18;
    public float speedRotate = 25;
    public Animator animator;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay(){
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Jump();

        // Walk animation
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
          animator.SetBool("isWalking", true);  
        }

        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)){
          animator.SetBool("isWalking", false);  
        }

        // Jump animation
        if(Input.GetKeyUp(KeyCode.Space)){
            animator.SetBool("isJumping", false);
        }
    }

    private void MovePlayer(){
        float forwardInput = Input.GetAxis("Vertical");
        float rightInput = Input.GetAxis("Horizontal");

        transform.Translate(speedWalk * forwardInput * Time.deltaTime * Vector3.forward);
        transform.Rotate(speedRotate * rightInput * Time.deltaTime * Vector3.up);
    }

    private void Jump(){
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }
    }
}
