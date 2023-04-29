using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinMenu : MonoBehaviour
{
    public Button buttonExitSkin, shipSelectionLeftArrow, shipSelectionRightArrow;
    public MenuManager menuManager;
    public Sprite[] availablesShipSprites;
    private SpriteRenderer spriteRenderer;
    private int actualSprite = 0;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        availablesShipSprites = Resources.LoadAll<Sprite>("player");
        buttonExitSkin.onClick.AddListener(menuManager.CloseSkinMenu);
        shipSelectionLeftArrow.onClick.AddListener(() => refreshSelectShip( -1 ));
        shipSelectionRightArrow.onClick.AddListener(() => refreshSelectShip( 1 ));
        spriteRenderer.sprite = availablesShipSprites[actualSprite];
    }

    // Update is called once per frame
    void Update()
    {}

    public void refreshSelectShip(int toAdd)
    {
        if (!(actualSprite + toAdd < 0 | actualSprite + toAdd > availablesShipSprites.Length - 1))
        {
            actualSprite = actualSprite + toAdd;
            spriteRenderer.sprite = availablesShipSprites[actualSprite];
        }
    }

}
