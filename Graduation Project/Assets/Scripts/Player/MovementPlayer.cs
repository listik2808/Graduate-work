using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Animator))]
public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private Vector3 _startPosition;

    private const string isRun = "isRun";
    private const string isJump = "isJump";
    private const string isRoll = "isRoll";

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        ResetPlayer();
    }

    private void Update()
    {
        Run();

        _player.CheckGround();

        if (Input.GetKeyDown(KeyCode.Space) && _player.OnGround)
            TryGetJump();

        if (Input.GetKeyDown(KeyCode.S) && _player.OnGround)
            TryGetRoll();

    }

    public void ResetPlayer()
    {
        transform.position = _startPosition;
        _rigidbody2D.velocity = Vector2.zero;
        _animator.SetBool(isRun, true);
    }

    private void TryGetJump()
    {
        _animator.SetBool(isRun, false);
        _animator.SetBool(isJump, true);
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpPower);
    } 

    private void Run()
    {
        _animator.SetBool(isRoll, false);
        _animator.SetBool(isJump, false);
        _animator.SetBool(isRun, true);
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    private void TryGetRoll()
    {
        _animator.SetBool(isRun, false);
        _animator.SetBool(isRoll, true);
    }
}
