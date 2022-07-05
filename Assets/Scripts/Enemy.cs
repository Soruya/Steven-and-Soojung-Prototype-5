using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float chaseDistance;

    private Transform target;
    private Vector2 startingPosition;

    Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If player is within certain distance of enemy, enemy should start chasing player
        if (Vector2.Distance(transform.position, target.position) < chaseDistance && Vector2.Distance(transform.position, target.position) > 0.5)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
