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

    StealthItem stealthItem;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        audioSource.Stop();
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

    public IEnumerator TimerSpeed()
    {
        playerSpeed *= 3f;
        //Debug.Log(player.playerSpeed);
        yield return new WaitForSecondsRealtime(5f);
        playerSpeed /= 3f;
    }

    public IEnumerator TimerInvisible()
    {
        playerCollider.enabled = false;
        playerSprite.color = new Color(0f, 1f, 1f, 0.2f);
        //Debug.Log(player.playerSpeed);
        yield return new WaitForSecondsRealtime(5f);
        playerSprite.color = new Color(0f, 0f, 1f, 1f);
        playerCollider.enabled = true;
    }

    public IEnumerator TimerNoise()
    {
        audioSource.time = 0f;
        audioSource.Play();
        audioSource.SetScheduledEndTime(AudioSettings.dspTime + (2f - 0f));
        yield return new WaitForSecondsRealtime(2f);
        //audioSource.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            stealthItem = collision.gameObject.GetComponent<StealthItem>();

            if (stealthItem.effectNumber == 1)
            {
                StartCoroutine(TimerInvisible());
            }
            if (stealthItem.effectNumber == 2)
            {
                StartCoroutine(TimerSpeed());
            }
            if (stealthItem.effectNumber == 3)
            {
                StartCoroutine(TimerNoise());
            }
        }
    }
}
