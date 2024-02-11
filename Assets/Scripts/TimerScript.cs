using System.Xml.Schema;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float timeremaining = 60;
    public bool timerisrunning = false;
    public Text Timerseconds;
        
    void Start()
    {// starts the clock automatically, should tweak it so that the clock starts when the game starts (like from the menu)
      timerisrunning = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerisrunning) {


            if (timeremaining > 0){

                timeremaining -= Time.deltaTime;
                DisplayTime(timeremaining);

            }
            else
            {
                //Gameoverscreen or pause game and gameoverscreen when the time runs out

                timeremaining = 0;
                timerisrunning = false;

            }



        }
    }
    // the real meat of the code
    void DisplayTime(float timetodisplay) 
    {
        timetodisplay += 1;
        float minutes = Mathf.FloorToInt(timetodisplay/60);
        float seconds = Mathf.FloorToInt(timetodisplay%60);
        Timerseconds.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
