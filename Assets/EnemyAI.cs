using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public Transform avoid;

    public float speed;
    public int timer;
    private bool backTrack;


    void Start()
    {
        backTrack = false;

        player = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        //if backtrack is false chase the player
        if (backTrack == false)
        {
            timer = 20;

            transform.position = Vector2.MoveTowards(transform.position, player.position, (speed * Time.fixedDeltaTime));
        }
        //if backtrack is true retreat till timer ends
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, avoid.position, (-speed * Time.fixedDeltaTime));

            timer--;

            if (timer <= 0)
            {
                backTrack = false;
            }
        }
    }

    //if enemy hits something other than the player set the target to avoid and enable backtrack
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Player")
        {
            avoid = col.gameObject.transform;
            backTrack = true;
        }
        
    }
}
