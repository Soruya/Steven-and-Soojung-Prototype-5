using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthItem : MonoBehaviour
{
    int effectIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Make player transparent and "invisible"
    void Invisibility()
    {
        Debug.Log("Invisible! " + effectIndex);
    }

    //Increase player speed
    void SpeedUp()
    {
        Debug.Log("Speed up " + effectIndex);
    }

    //Loud noise
    void MakeNoise()
    {
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
