using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public CircleCollider2D playerCollider;
    public SpriteRenderer playerSprite;

    public float playerSpeed;
    Vector2 playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        
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

    IEnumerator TimerSpeed()
    {
        //Debug.Log(player.playerSpeed);
        yield return new WaitForSecondsRealtime(5f);
        playerSpeed /= 5f;
    }

    IEnumerator TimerInvisible()
    {
        playerCollider.enabled = false;
        playerSprite.color = new Color(0f, 1f, 1f, 0.2f);
        //Debug.Log(player.playerSpeed);
        yield return new WaitForSecondsRealtime(5f);
        playerSprite.color = new Color(0f, 0f, 1f, 1f);
        playerCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
