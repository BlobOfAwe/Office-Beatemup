using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterRankManager : MonoBehaviour
{
    [SerializeField] Texture rankF;
    [SerializeField] Texture rankD;
    [SerializeField] Texture rankC;
    [SerializeField] Texture rankB;
    [SerializeField] Texture rankA;
    [SerializeField] Texture rankS;

    public void AssignRank(int rank)
    {
        Debug.Log(rank);
        switch (rank)
        {
            case 0:
                GetComponent<RawImage>().texture = rankF;
                Debug.Log("Rank F Registered: sprite texture: " + GetComponent<RawImage>().texture);
                break;
            case 1:
                GetComponent<RawImage>().texture = rankD;
                break;
            case 2:
                GetComponent<RawImage>().texture = rankC;
                break;
            case 3:
                GetComponent<RawImage>().texture = rankB;
                break;
            case 4:
                GetComponent<RawImage>().texture = rankA;
                break;
            case 5:
                GetComponent<RawImage>().texture = rankS;
                break;
            default:
                GetComponent<RawImage>().texture = rankF;
                break;

        }

    }
}
