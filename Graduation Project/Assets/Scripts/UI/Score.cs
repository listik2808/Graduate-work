using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        _player.ScoreChanged += OnScoreChenged;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChenged;
    }

    private void OnScoreChenged(int score)
    {
        _score.text = score.ToString();
    }
}
