using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D playerRB;

    public float playerSpeed;
    Vector2 playerMovement;

    bool hasItem;

    // Start is called before the first frame update
    void Start()
    {
        hasItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + playerMovement * playerSpeed * Time.deltaTime);
    }

    //Keyboard controls
    void Interact()
    {
        // Pick up item
        if (Input.GetKeyDown(KeyCode.E))
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
