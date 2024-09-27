using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    // Life and coins
    public TextMeshProUGUI[] life;
    public int lifeCount;
    public TextMeshProUGUI[] coins;
    public int coinsCount = 0;

    // Game Over
    public GameObject gameOver;
    public GameObject[] players;

    public AudioSource audioSource;

    // Next Level
    public GameObject nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Jump Sound
        jumpSource = GetComponent<AudioSource>();  
        jumpSource.clip = jumpSound;

        // Life
        lifeCount = 3;
        life[0].text = $" x{lifeCount}";
        life[1].text = $" x{lifeCount}";
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Jump();

        //Game Over
        if(lifeCount == 0){
            animator.SetBool("isDead", true);
        }
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
        // Coin
        if (other.tag == "Coin")
        { 
            coinsCount++;
            coins[0].text = $"{coinsCount}";
            coins[1].text = $"{coinsCount}";
        }

        // Hearts
        if (other.tag == "Enemy")
        { 
            lifeCount--;
            life[0].text = $"0{lifeCount}";
            life[1].text = $"0{lifeCount}";
            LoseHeartSound();
        }
        if (other.tag == "Fire")
        { 
            lifeCount--;
            life[0].text = $"0{lifeCount}";
            life[1].text = $"0{lifeCount}";
            LoseHeartSound();
        }
        if (other.tag == "Water")
        { 
            lifeCount = 0;
            life[0].text = $"0{lifeCount}";
            life[1].text = $"0{lifeCount}";
        }

        // Next Level
        if (other.tag == "Treasure")
        { 
            Destroy(other.gameObject);
            animator.SetBool("newLevel", true);
            nextLevel.SetActive(true);
        } 

        // Game Over
        if(lifeCount == 0){
            players[0].SetActive(false);
            players[1].SetActive(false);
            gameOver.SetActive(true);
        }
    }

    void LoseHeartSound()
    {
        audioSource.Play();
    }
}
