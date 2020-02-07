using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTarget : BaseEnemyAction
{
    float timer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        timer = 1.0f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation,
            enemy.GetComponent<EnemyManager>().GetDir(),
            enemy.GetComponent<EnemyManager>().self.rotRate * Time.deltaTime);
        timer -= Time.deltaTime;
        RaycastHit2D hit = Physics2D.Raycast(enemy.transform.position + (enemy.transform.up * enemy.transform.lossyScale.y), enemy.transform.up, 30);
        if (timer <= 0 && hit.collider != null && hit.collider.gameObject == enemy.GetComponent<EnemyManager>().currentTarget)
        {
            //Debug.Log("Can Shoot");
            enemy.GetComponent<EnemyManager>().Shoot();
            timer = enemy.GetComponent<EnemyManager>().self.coolDown;
            //Debug.Log("Shot");
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
