using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI hrViol;
    [SerializeField] TextMeshProUGUI propDmg;
    [SerializeField] TextMeshProUGUI chicken;

    [SerializeField] LetterRankManager mainRank;
    [SerializeField] LetterRankManager scoreRank;
    [SerializeField] LetterRankManager hrRank;
    [SerializeField] LetterRankManager propRank;
    [SerializeField] LetterRankManager chickenRank;

    private int scoreRank_Internal;
    private int hrRank_Internal;
    private int propRank_Internal;
    private int chickenRank_Internal;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        switch (gameManager.score)
        {
            case int i when i < 5000:
                scoreRank.AssignRank(0);
                scoreRank_Internal = 0;
                break;
            case int i when i < 7000:
                scoreRank.AssignRank(1);
                scoreRank_Internal = 1;
                break;
            case int i when i < 9000:
                scoreRank.AssignRank(2);
                scoreRank_Internal = 2;
                break;
            case int i when i < 11000:
                scoreRank.AssignRank(3);
                scoreRank_Internal = 3;
                break;
            case int i when i < 14000:
                scoreRank.AssignRank(4);
                scoreRank_Internal = 4;
                break;
            default:
                scoreRank.AssignRank(5);
                scoreRank_Internal = 5;
                break;
        }

        switch (gameManager.propDmg)
        {
            case int i when i < 30:
                propRank.AssignRank(0);
                propRank_Internal = 0;
                break;
            case int i when i < 55:
                propRank.AssignRank(1);
                propRank_Internal = 1;
                break;
            case int i when i < 70:
                propRank.AssignRank(2);
                propRank_Internal = 2;
                break;
            case int i when i < 95:
                propRank.AssignRank(3);
                propRank_Internal = 3;
                break;
            case int i when i < 125:
                propRank.AssignRank(4);
                propRank_Internal = 4;
                break;
            default:
                propRank.AssignRank(5);
                propRank_Internal = 5;
                break;
        }

        switch (gameManager.hrViol)
        {
            case int i when i < 30:
                hrRank.AssignRank(0);
                hrRank_Internal = 0;
                break;
            case int i when i < 55:
                hrRank.AssignRank(1);
                hrRank_Internal = 1;
                break;
            case int i when i < 70:
                hrRank.AssignRank(2);
                hrRank_Internal = 2;
                break;
            case int i when i < 95:
                hrRank.AssignRank(3);
                hrRank_Internal = 3;
                break;
            case int i when i < 125:
                hrRank.AssignRank(4);
                hrRank_Internal = 4;
                break;
            default:
                hrRank.AssignRank(5);
                hrRank_Internal = 5;
                break;
        }

        switch (gameManager.chicken)
        {
            case int i when i < 1:
                chickenRank.AssignRank(0);
                chickenRank_Internal = 0;
                break;
            case int i when i < 2:
                chickenRank.AssignRank(3);
                chickenRank_Internal = 3;
                break;
            case int i when i < 3:
                chickenRank.AssignRank(4);
                chickenRank_Internal = 4;
                break;
            default:
                chickenRank.AssignRank(5);
                chickenRank_Internal = 5;
                break;
        }

        mainRank.AssignRank((scoreRank_Internal + propRank_Internal + hrRank_Internal + chickenRank_Internal) / 4);
    }

    private void Start()
    {
        score.text = gameManager.score.ToString();
        hrViol.text = gameManager.hrViol.ToString();
        propDmg.text = gameManager.propDmg.ToString();
        chicken.text = gameManager.chicken.ToString();
    }
}
