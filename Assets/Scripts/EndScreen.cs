using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalText;
    Score score;
    void Start()
    {
        score = FindObjectOfType<Score>();
    }

    public void ShowFinalScore()
    {
        finalText.text = "Tebrikler!\nDoğruluk Oranınız" + score.CalculateScore() +"%"; 

    }
}
