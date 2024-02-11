using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject chicken;

    public float timer;
    private int chickenNum;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy, this.transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.childCount == 0)
        {
            timer -= Time.fixedDeltaTime;

            if (timer <= 0)
            {
                chickenNum = Random.Range(0, 20);

                if (chickenNum == 0)
                {
                    Instantiate(chicken, this.transform);
                }
                else
                {
                    Instantiate(enemy, this.transform);
                }

                timer = 10;
            }
        }

        
    }
}
