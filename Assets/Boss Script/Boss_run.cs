using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss_run : StateMachineBehaviour

{   Transform boss;
    Transform anakarakter;
    Rigidbody2D rb;
    public float speed = 2.5f;
    private Vector3 basPos;
    public float attackRange = 12f;

    void Start()
    {
        basPos = new Vector3(26f, 4.56f, 0.15f);
        
    }



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = GameObject.FindGameObjectWithTag("Enemy").transform;
        anakarakter = GameObject.FindGameObjectWithTag("anakarakter").transform;
        rb = animator.GetComponent<Rigidbody2D>();

        Vector3 target = new Vector3(anakarakter.position.x, anakarakter.position.y,anakarakter.position.z);
        Vector3 newPos= Vector3.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        Vector3 hedef = Vector3.MoveTowards(rb.position, basPos, speed * Time.fixedDeltaTime);

        if( Mathf.Abs(boss.position.x - anakarakter.position.x) < 10) {
             rb.MovePosition(newPos);
        }

        if (Mathf.Abs(boss.position.x - anakarakter.position.x) < 6)
        {
            animator.SetTrigger("Attack"); 

        }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
    
}
