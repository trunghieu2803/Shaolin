using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector2 _jumpForce;
    [SerializeField] bool _isOnGround;
    [SerializeField] PlayerState _playerState = PlayerState.RUN;
    [SerializeField] AnimationController _anim;
    Collider2D _colli;
    Rigidbody2D _rb;
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        _colli = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        UpdateState();
        _anim.UpdateAnimation(_playerState);
    }

    void UpdateState()
    {
        if (!_isOnGround)
        {
            _playerState = PlayerState.JUMP;
        }
        else
        {
            _playerState = PlayerState.RUN;
        }
    }

    void Jump()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && _isOnGround)
            {
                _rb.AddForce(_jumpForce);
                _isOnGround = false;
            }
        }
    }

    void CheckOnGround()
    {
        RaycastHit2D[] hits = new RaycastHit2D[10];
        _colli.Cast(Vector2.down, hits, 0.5f, true);
        foreach (RaycastHit2D hit in hits)
        {
            
            if (hit.collider != null)
            {
                _isOnGround = true;
                return;
            }
        }
        _isOnGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckOnGround();
    }

    public enum PlayerState{
        RUN, 
        JUMP,
        STRIP
    }
}
