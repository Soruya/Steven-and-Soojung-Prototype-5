using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmItem : MonoBehaviour
{
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

    void MakeNoise()
    {
        //Play loud noise
        audioSource.time = 0f;
        audioSource.Play();
        audioSource.SetScheduledEndTime(AudioSettings.dspTime + (2f - 0f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MakeNoise();
            Destroy(this.gameObject);
        }
    }

}
