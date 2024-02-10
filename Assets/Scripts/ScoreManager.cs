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

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        score.text = gameManager.score.ToString();
        hrViol.text = gameManager.hrViol.ToString();
        propDmg.text = gameManager.propDmg.ToString();
        chicken.text = gameManager.chicken.ToString();
    }
}
