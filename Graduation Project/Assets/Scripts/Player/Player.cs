using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MovementPlayer))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _checkRadius = 0.3f;
    [SerializeField] private LayerMask _graund;
    [SerializeField] private bool _onGround;

    public bool OnGround => _onGround;

    private int _coin;
    private MovementPlayer _move;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        _move = GetComponent<MovementPlayer>();
    }

    public void ResetGame()
    {
        _coin = 0;
        ScoreChanged?.Invoke(_coin);
        _move.ResetPlayer();
    }

    public void CheckGround()
    {
        _onGround = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _graund);
    }

    public void Damage(int damage)
    {
        _health -= damage;
        if(_health <= 0)
        {
            GameOver?.Invoke();
        }
    }

    public void AddCoin()
    {
        _coin++;
        ScoreChanged?.Invoke(_coin);
    }
}
