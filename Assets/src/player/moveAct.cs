using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAct : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float speed = 6;        // speed

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        playerVelocity.x = speed * Input.GetAxisRaw("Horizontal");
        playerVelocity.y = speed * Input.GetAxisRaw("Vertical");
        controller.Move(playerVelocity * Time.deltaTime);
       //log Debug.Log("horizontal axis:" + Input.GetAxis("Horizontal"));
       //log Debug.Log("vertical axis:" + Input.GetAxis("Horizontal"));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            // Code à exécuter lors de la collision avec un roid
            Debug.Log("Collision avec un roid");
        }
    }
}
