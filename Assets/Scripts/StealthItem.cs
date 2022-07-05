using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthItem : MonoBehaviour
{
    int effectIndex;

    Player player;
    SpriteRenderer playerSprite;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        playerSprite = player.GetComponent<SpriteRenderer>();

        audioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        audioSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Timer()
    {
        Debug.Log(player.playerSpeed);
        yield return new WaitForSecondsRealtime(10f);
    }

    //Make player transparent and "invisible"
    void Invisibility()
    {
        playerSprite.color = new Color(0f, 0f, 1f, 0.5f);
        StartCoroutine(Timer());
        playerSprite.color = new Color(0f, 0f, 1f, 1f);
        Debug.Log("Invisible! " + effectIndex);
    }

    //Increase player speed
    void SpeedUp()
    {
        player.playerSpeed *= 30f;
        Debug.Log("Speed up " + effectIndex + " Speed is " + player.playerSpeed);
        StartCoroutine(Timer());

        //Return to normal speed
        player.playerSpeed /= 30f;

    }

    //Loud noise
    void MakeNoise()
    {
        //Play loud noise
        audioSource.time = 0f;
        audioSource.Play();
        audioSource.SetScheduledEndTime(AudioSettings.dspTime + (2f - 0f));
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
        }
        if (effectIndex >= 1 && effectIndex <= 20)
        {
            MakeNoise();
        }
    }
}
