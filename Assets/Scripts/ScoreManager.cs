using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int value;
   public Text scoreText;


    public void Increment(int temp)
    {
       
        value+=temp;
        scoreText.text = "Score :" + value;
    }
}
