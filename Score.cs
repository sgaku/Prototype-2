using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text highScore;
    public GameObject target;
    public Transform targetPoint;
    private int number;
    private Text score;


    void Awake()
    {
        score = GetComponent<Text>();
        highScore.text = "HighScore : " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            number = Mathf.CeilToInt(targetPoint.position.z-10);
        }
        score.text = "Score : " + this.number;
        PlayerPrefs.SetInt("Score", number);

        if(number > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", number);
        }

    }
}
