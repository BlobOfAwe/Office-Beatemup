using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;
    [SerializeField] float punchCooldown = 0.1f;
    [SerializeField] float punchDuration = 0.1f;
    [SerializeField] float faceTowards;
    [SerializeField] GameObject punchObject;

    private Rigidbody2D rb;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (timer <= -punchCooldown)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                punchObject.SetActive(true);
                timer = punchDuration;
            }
        }

        else if (timer <= 0)
        {
            punchObject.SetActive(false);
            timer -= Time.deltaTime;
        }

        else
        {
            timer -= Time.deltaTime;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed);

        if (rb.velocity.y != 0 || rb.velocity.x != 0)
        {
            faceTowards = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, faceTowards);
        }
    }
}
