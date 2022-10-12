using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Patrol : StateMachineBehaviour
{
    Transform player;
    public float speed = 6f;
    public Rigidbody rb;
    public float random;
    public float attackRange = 16f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 target = new Vector3(player.position.x, 3, player.position.z);
        Vector3 newPos = Vector3.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Vector3.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("jump");
        }

        if (Time.fixedDeltaTime / 13 == 0)
        {
            animator.SetTrigger("shoot");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("jump");
        animator.ResetTrigger("shoot");
    }
}
