using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;

    public static GameManager Instance;

    private int _score = 0;

    private void Awake()
    {
       if (Instance == null) Instance = this;
    }


    public void ChangeScore(int pointsToAdd)
    {
        _score += pointsToAdd;
        _scoreText.text = _score.ToString();
    }

}
