using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button buttonStart, buttonOption, buttonSkin;
    public MenuManager menuManager;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        buttonStart.onClick.AddListener(buttonStartAction);
        buttonOption.onClick.AddListener(menuManager.OpenOptionsMenu);
        buttonSkin.onClick.AddListener(menuManager.OpenSkinMenu);
    }

    // Update is called once per frame
    void Update()
    {}

    public void OnButtonClick()
    {
        // je vais peut etre ajouter un son
    }

    public void buttonStartAction()
    {
        SceneManager.LoadScene("SceneGame");
    }

}
