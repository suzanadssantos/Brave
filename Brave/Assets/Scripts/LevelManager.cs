using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject characterSelection;
    public GameObject Panel;
    public GameObject boy;
    public GameObject boyCamera;
    public GameObject girl;
    public GameObject girlCamera;

    public void BoySelected(){
        characterSelection.SetActive(false);
        Panel.SetActive(false);
        boy.SetActive(true);
        boyCamera.SetActive(true);
        girl.SetActive(false);
        girlCamera.SetActive(false);
    }

    public void GirlSelected(){
        characterSelection.SetActive(false);
        Panel.SetActive(false);
        boy.SetActive(false);
        boyCamera.SetActive(false);
        girl.SetActive(true);
        girlCamera.SetActive(true);
    }

    public void TryAgain(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame(){
        SceneManager.LoadScene(0);
    }

    public void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
