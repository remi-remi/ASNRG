using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject skinMenu;
    private bool isOptionsMenuOpen = false;
    private bool isSkinMenuOpen = false;
    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {}

    public void OpenOptionsMenu()
    {
        isOptionsMenuOpen = true;
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void CloseSoundOptionsMenu()
    {
        isOptionsMenuOpen = false;
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void OpenSkinMenu()
    {
        isSkinMenuOpen = true;
        mainMenu.SetActive(false);
        skinMenu.SetActive(true);
    }

    public void CloseSkinMenu()
    {
        isSkinMenuOpen = false;
        mainMenu.SetActive(true);
        skinMenu.SetActive(false);
    }
}
