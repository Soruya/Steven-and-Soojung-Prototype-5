using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibilityItem : MonoBehaviour
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

    IEnumerator Timer()
    {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invisibility();
            Destroy(this.gameObject);
        }
    }
}
