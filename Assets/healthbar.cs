using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class healthbar : MonoBehaviour
{
    // Start is called before the first frame update

    public Image Healthbar;
    public float healthamount = 100f;




    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
     if ( Input.GetKeyDown(KeyCode.T ) )
        {
            takedamage(10);
        }

        if ( Input.GetKeyDown(KeyCode.Space) )
        {
            heal(5);
        }

        if (healthamount <= 0){

            Application.LoadLevel(Application.loadedLevel);


        }
    }

    public void takedamage (float damage){
       

        healthamount -= damage;
        Healthbar.fillAmount = healthamount/100f;
        Camerashake.Instance.shakecamera(5f, .1f);

    }

    public void heal (float healing){

        healthamount += healing;
        healthamount = Mathf.Clamp(healthamount,0,100);
        Healthbar.fillAmount = healthamount/100f;
    }
}
