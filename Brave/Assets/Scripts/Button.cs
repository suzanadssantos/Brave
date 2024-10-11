using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public AudioSource buttonSource;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool("Highlighted") == true){
            buttonSource.Play();
        }
    }
}
