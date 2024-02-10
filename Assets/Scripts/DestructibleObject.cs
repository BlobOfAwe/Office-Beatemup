using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestructibleObject : MonoBehaviour
{
    private ParticleSystem particle;
    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider;
    private GameManager gameManager;

    [SerializeField] float regenTime = 10;
    [SerializeField] int pointValue = 100;
    [SerializeField] Transform canvas;
    [SerializeField] GameObject pointTextPrefab;
    
    private GameObject pointText;

    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        boxCollider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        canvas = GameObject.Find("WorldCanvas").GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Destroyer"))
        {
            sprite.enabled = false;
            boxCollider.enabled = false;
            particle.Play();
            gameManager.score += pointValue;
            pointText = Instantiate(pointTextPrefab, canvas);
            pointText.transform.position = transform.position;
            pointText.GetComponent<TextMeshPro>().text = pointValue.ToString();
            StartCoroutine("Regenerate");
        }
    }

    private IEnumerator Regenerate()
    {
        yield return new WaitForSeconds(regenTime);
        sprite.enabled = true;
        boxCollider.enabled = true;

    }
}
