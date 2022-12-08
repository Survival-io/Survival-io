using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimator;

    private void OnEnable()
    {
        EventManager.enemyMovementAnimation.AddListener(enemyMovement);
        EventManager.enemyAttackAnimation.AddListener(enemyAttack);
       
    }
    private void OnDisable()
    {
        EventManager.enemyMovementAnimation.RemoveListener(enemyMovement);
        EventManager.enemyAttackAnimation.RemoveListener(enemyAttack);
    }

    private void enemyAttack()
    {
        enemyAnimator.SetBool("isAttack",true);
    }
    private void enemyMovement() {
        enemyAnimator.SetBool("isAttack", false);
    }
}
