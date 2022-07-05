using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthItem : MonoBehaviour
{
    int effectIndex;
    // 1 is invisibility, 2 is speed, 3 is noise
    public int effectNumber;

    //Player components
    Player player;
    SpriteRenderer playerSprite;
    CircleCollider2D playerCollider;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        playerSprite = player.GetComponent<SpriteRenderer>();
        playerCollider = player.GetComponent<CircleCollider2D>();

        /*audioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        audioSource.Stop();*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*IEnumerator TimerSpeed()
    {
        //Debug.Log(player.playerSpeed);
        yield return new WaitForSecondsRealtime(5f);
        player.playerSpeed /= 5f;
    }

    IEnumerator TimerInvisible()
    {
        playerCollider.enabled = false;
        playerSprite.color = new Color(0f, 1f, 1f, 0.2f);
        //Debug.Log(player.playerSpeed);
        yield return new WaitForSecondsRealtime(5f);
        playerSprite.color = new Color(0f, 0f, 1f, 1f);
        playerCollider.enabled = true;
    }*/

    //Make player transparent and "invisible"
    void Invisibility()
    {
        //StartCoroutine(player.TimerInvisible());
        effectNumber = 1;
        Debug.Log("Invisible! " + effectIndex);
    }

    //Increase player speed
    void SpeedUp()
    {
        effectNumber = 2;
        Debug.Log("Speed up " + effectIndex + " Speed is " + player.playerSpeed);
        //StartCoroutine(player.TimerSpeed());

    }

    //Loud noise
    void MakeNoise()
    {
        effectNumber = 3;
        //Play loud noise
        /*audioSource.time = 0f;
        audioSource.Play();
        audioSource.SetScheduledEndTime(AudioSettings.dspTime + (2f - 0f));*/
        Debug.Log("Noise " + effectIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EffectActivate();
            Destroy(this.gameObject);
        }
    }

    void EffectActivate()
    {
        effectIndex = Random.Range(1, 101);

        if (effectIndex > 55)
        {
            Invisibility();
        }
        if (effectIndex <= 55 && effectIndex > 20)
        {
            SpeedUp();
            //Return to normal speed

        }
        if (effectIndex >= 1 && effectIndex <= 20)
        {
            MakeNoise();
        }
    }
}
