using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MovePlayer))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _checkRadius = 0.3f;
    [SerializeField] private LayerMask _graund;
    [SerializeField] private bool _onGround;

    public bool OnGround => _onGround;

    private int _reward;
    private MovePlayer _move;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        _move = GetComponent<MovePlayer>();
    }

    public void ResetGame()
    {
        _reward = 0;
        ScoreChanged?.Invoke(_reward);
        _move.ResetPlayer();
    }

    public void CheckingGground()
    {
        _onGround = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _graund);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        if(_health <= 0)
        {
            GameOver?.Invoke();
        }
    }

    public void GetReward()
    {
        _reward++;
        ScoreChanged?.Invoke(_reward);
    }
}
