using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int hrViol = 0;
    public int propDmg = 0;
    public int chicken = 0;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");
        
        if (objs.Length > 1)
        {
            foreach(GameObject obj in objs)
            {
                if (obj != gameObject)
                {
                    Destroy(obj);
                }
            }
        }

        DontDestroyOnLoad(gameObject);
    }
}
