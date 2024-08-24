using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionMenu : MonoBehaviour
{
    public GameObject characterSelection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BoySelected(){
        characterSelection.SetActive(false);
    }

    public void GirlSelected(){
        characterSelection.SetActive(false);
    }
}
