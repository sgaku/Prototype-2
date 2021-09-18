using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public Text showScore;
    // Start is called before the first frame update
    void Start()
    {
        showScore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        showScore.text = "Your Score is : " + PlayerPrefs.GetInt("Score", 0);
    }
}
