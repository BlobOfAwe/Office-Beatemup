using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        hasEnemy = true;
        Instantiate(enemy, this.transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(this.gameObject.transform.GetChild(0).tag != "Coworker")
        {
            timer -= Time.fixedDeltaTime;

            if (timer <= 0)
            {
                Instantiate(enemy, this.transform);

                timer = 10;
            }
        }
        else
        {
            timer = 10;
        }
        
    }
}
