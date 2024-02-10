using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    private ParticleSystem particle;
    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider;

    [SerializeField] float regenTime = 10;

    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        boxCollider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Destroyer"))
        {
            sprite.enabled = false;
            boxCollider.enabled = false;
            particle.Play();
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
