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

    GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        audioSource.Stop();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
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
        playerSprite.color = new Color(0f, 1f, 0f);
        playerSpeed *= 3f;
        //Debug.Log(player.playerSpeed);
        yield return new WaitForSecondsRealtime(5f);
        playerSprite.color = new Color(0f, 0f, 1f);
        playerSpeed /= 3f;
    }

    public IEnumerator TimerInvisible()
    {
        playerCollider.enabled = false;
        playerSprite.color = new Color(0f, 0f, 0f);
        //Debug.Log(player.playerSpeed);
        yield return new WaitForSecondsRealtime(5f);
        playerSprite.color = new Color(0f, 0f, 1f);
        playerCollider.enabled = true;
    }

    public IEnumerator TimerNoise()
    {
        playerSprite.color = new Color(0.97f, 0.58f, 0.11f);
        audioSource.time = 0f;
        audioSource.Play();
        audioSource.SetScheduledEndTime(AudioSettings.dspTime + (2f - 0f));
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<BoxCollider2D>().size += new Vector2(0.5f, 0.5f);
            enemy.transform.GetChild(0).transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        }
        yield return new WaitForSecondsRealtime(5f);
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<BoxCollider2D>().size -= new Vector2(0.5f, 0.5f);
            enemy.transform.GetChild(0).transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
        }
        playerSprite.color = new Color(0f, 0f, 1f);
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
