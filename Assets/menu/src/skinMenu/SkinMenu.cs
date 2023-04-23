using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinMenu : MonoBehaviour
{
    public Button buttonExitSkin;
    public MenuManager menuManager;
    // Start is called before the first frame update
    void Start()
    {
        buttonExitSkin.onClick.AddListener(menuManager.CloseSkinMenu);
    }

    // Update is called once per frame
    void Update()
    {}

}
