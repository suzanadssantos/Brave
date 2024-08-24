using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject HowToPlay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton(){
        SceneManager.LoadScene(1);
    }

    public void HowToPlayButton(){
        HowToPlay.SetActive(true);
    }

    public void CloseButton(){
        HowToPlay.SetActive(false);
    }

    public void ExitButton(){
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
