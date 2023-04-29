using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public Button buttonExitOption;
    public MenuManager menuManager;
    // Start is called before the first frame update
    void Start()
    {
        buttonExitOption.onClick.AddListener(menuManager.CloseSoundOptionsMenu);
    }

    // Update is called once per frame
    void Update()
    {}

}
