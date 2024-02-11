using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camerashake : MonoBehaviour
{

    public static Camerashake Instance {get; private set;}
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shaketimer;

    private void Awake()
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void shakecamera (float intensity, float time){

        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =  cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();  

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shaketimer = time;
    }

            private void Update()
            {
                 if (shaketimer > 0) {
                    shaketimer -= Time.deltaTime;
                   if (shaketimer <= 0f) {
                  CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =  cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                  cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
                  }
            }

            }

        
    
}

