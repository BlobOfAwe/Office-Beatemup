using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyAI : MonoBehaviour
{
    private enum ObjectType { Property, Coworker, Chicken };
    private GameManager gameManager;
    [SerializeField] int pointValue = 100;
    [SerializeField] Transform canvas;
    [SerializeField] ObjectType objectType;
    [SerializeField] GameObject pointTextPrefab;
    private SpriteRenderer sprite;
    private GameObject pointText;

    public Transform player;
    public Transform avoid;

    public float speed;
    public int timer;
    private bool backTrack;

    public int health;

    void Start()
    {
        backTrack = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.FindWithTag("Player").transform;
        canvas = GameObject.Find("WorldCanvas").GetComponent<Transform>();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Destroyer"))
        {
           
            Health(10);
        }
    }

    private void OnTriggerstay2D(Collider2D other)
    {
        if (other.CompareTag("Destroyer"))
        {
            sprite.color = Color.red;
        }
    }



    void Health(int h)
    {
        health -= h;       

        if (health <= 0)
        {
            gameManager.score += pointValue;

            if (objectType == ObjectType.Property) { gameManager.propDmg += 1; }
            else if (objectType == ObjectType.Coworker) { gameManager.hrViol += 1; }
            else if (objectType == ObjectType.Chicken) { gameManager.chicken += 1; }
            else { Debug.LogError(gameObject + " invalid object type: " + objectType); }

            pointText = Instantiate(pointTextPrefab, canvas);
            pointText.transform.position = transform.position;
            pointText.GetComponent<TextMeshPro>().text = pointValue.ToString();

            Destroy(this.gameObject);
        }
    }
}
