using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerState = PlayerController.PlayerState;

public class AnimationController : MonoBehaviour
{
    Animator _animator;

    private void Start()
    {
        _animator = this.GetComponent<Animator>();
    }

    private void Update()
    {

    }
    public void UpdateAnimation(PlayerState _playerState)
    {
        for(int i = 0; i <= (int)PlayerState.STRIP; i++)
        {
            string _stateName = ((PlayerState)i).ToString();
            if(_playerState == ((PlayerState)i))
                _animator.SetBool(_stateName, true);
            else 
                _animator.SetBool(_stateName, false);
        }
    }
}
