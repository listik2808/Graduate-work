using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private ObjectGenerator _objectGeneratorBomb;
    [SerializeField] private ObjectGenerator _objectGeneratorCoin;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void OnEnable()
    {
        _startScreen.PlayerButtonClick += OnPlayeButtonClick;
        _gameOverScreen.ResetButton += OnRestartButtonClick;
        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayerButtonClick -= OnPlayeButtonClick;
        _gameOverScreen.ResetButton -= OnRestartButtonClick;
        _player.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnPlayeButtonClick()
    {
        _startScreen.Close();
        Play();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _objectGeneratorBomb.Reset();
        _objectGeneratorCoin.Reset();
        Play();
    }

    private void Play()
    {
        Time.timeScale = 1;
        _player.ResetGame();
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }
}
