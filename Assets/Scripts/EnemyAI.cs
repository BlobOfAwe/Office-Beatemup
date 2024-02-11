using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public Transform avoid;

    public float speed;
    private int timer;
    private bool backTrack;


    // Start is called before the first frame update
    void Start()
    {
        backTrack = false;

        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (backTrack == false)
        {
            timer = 150;

            transform.position = Vector2.MoveTowards(transform.position, player.position, (speed * Time.deltaTime));
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, avoid.position, (-speed * Time.deltaTime));

            timer--;

            if (timer == 0)
            {
                backTrack = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Player")
        {
            avoid = col.gameObject.transform;
            backTrack = true;
        }
        
    }
}
