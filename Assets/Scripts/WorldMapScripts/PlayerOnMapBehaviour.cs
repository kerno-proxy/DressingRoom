using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnMapBehaviour : MonoBehaviour
{
    [SerializeField]
    public Animator _animator;

    public void SetAnimatorToMoving()
    {
        _animator.SetBool("isMoving", true);
        _animator.SetBool("isIdle", false);
    }
    public void SetAnimatorToIdle()
    {
        _animator.SetBool("isIdle", true);
        _animator.SetBool("isMoving", false);
    }

}
