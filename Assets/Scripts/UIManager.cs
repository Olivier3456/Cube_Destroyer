using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;

    public static UIManager Instance;

    private int _score = 0;

    private void Awake()
    {
       if (Instance == null) Instance = this;
    }


    public void OnePointMore()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }

}
