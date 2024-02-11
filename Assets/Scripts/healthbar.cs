using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class healthbar : MonoBehaviour
{
    // Start is called before the first frame update

    public Image Healthbar;
    public float healthAmount = 100f;

    // Update is called once per frame
    void Update()
    {
     if ( Input.GetKeyDown(KeyCode.T ) )
        {
            TakeDamage(10);
        }

        if ( Input.GetKeyDown(KeyCode.Space) )
        {
            Heal(5);
        }

        if (healthAmount <= 0){

            SceneManager.LoadScene("GameOver");
        }
    }

    public void TakeDamage (float damage){
       

        healthAmount -= damage;
        Healthbar.fillAmount = healthAmount/100f;
        Camerashake.Instance.shakecamera(5f, .1f);

    }

    public void Heal (float healing){

        healthAmount += healing;
        healthAmount = Mathf.Clamp(healthAmount,0,100);
        Healthbar.fillAmount = healthAmount/100f;
    }
}
