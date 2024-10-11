using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionMenu : MonoBehaviour
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
}
