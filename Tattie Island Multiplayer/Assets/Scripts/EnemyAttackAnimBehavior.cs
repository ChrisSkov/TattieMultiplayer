using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAnimBehavior : StateMachineBehaviour
{
    public float minTimeActivate = 0.3f;
    public float maxTimeActivate = 0.56f;
    MeshCollider weaponArc;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        weaponArc = animator.gameObject.transform.GetChild(7).gameObject.GetComponent<MeshCollider>();
        weaponArc.gameObject.GetComponent<ColliderHitPlayer>().hasHit = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime >= minTimeActivate && stateInfo.normalizedTime <= maxTimeActivate)
        {
            weaponArc.enabled = true;
        }
        else
        {
            weaponArc.enabled = false;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
