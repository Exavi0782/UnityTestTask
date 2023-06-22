using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreCounter : MonoBehaviour
{
    TextMeshProUGUI scoreCount;
    Canvas canvas;
    [SerializeField] int scoreElement;
    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        scoreCount = canvas.GetComponentInChildren<TextMeshProUGUI>();

        AudioManager.instance.Play("Background");
    }

    public void ScoreValues(int value)
    {
        scoreElement += (value / 2); 
        scoreCount.text = "Score: " + scoreElement;
    }
}
