using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Zombie_Combat : MonoBehaviour
{

    public float startChaseRange = 10f;
    public float stopChaseRange = 20f;
    public float attackRange = 2.1f;
    public float attackDamage = 10f;
    public float endReachedDistanceChangeDestination = 2f;
    public float timeBetweenAttacks = 0.65f;
    public float randomPointMultiplier = 6f;
    Animator anim;
    AIPath path;
    float timer = Mathf.Infinity;
    public Transform target;
    Rigidbody rb;

    EnemyHealth health;
    // Start is called before the first frame update
    void Start()
    {
        target = null;
        health = GetComponent<EnemyHealth>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        path = GetComponent<AIPath>();

        GetComponentInChildren<ColliderHit>().SetDamage(attackDamage);
    }

    // Update is called once per frame
    void Update()
    {
        if (health.isDead) return;

        timer += Time.deltaTime;
        AttackPlayer();
        HandleMovementAnimation();
        SetDestination();
        StopChaseIfPlayerIsOutOfRange();

    }

    private void SetDestination()
    {
        if (target == null)
        {
            SetRandomDestination();
        }
        else
        {
            path.destination = target.position;
        }
    }

    private void SetRandomDestination()
    {
        if (path.endReachedDistance <= endReachedDistanceChangeDestination || path.destination == null)
        {
            path.destination = Random.insideUnitCircle * 6f;
        }
    }

    private void StopChaseIfPlayerIsOutOfRange()
    {
        if (target == null) return;
        if (Vector3.Distance(gameObject.transform.position, target.position) >= stopChaseRange)
        {
            target = null;
        }
    }

    private void HandleMovementAnimation()
    {
        anim.SetFloat("forwardSpeed", path.velocity.magnitude);
        if (anim.GetFloat("forwardSpeed") >= 0.3f)
        {
            anim.SetBool("isMoving", true);
        }
    }

    private void AttackPlayer()
    {
        if (target == null) return;
        if (Vector3.Distance(gameObject.transform.position, target.position) <= attackRange && timer >= timeBetweenAttacks)
        {
            transform.LookAt(target);
            anim.SetTrigger("attack");
            timer = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target = other.gameObject.transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, startChaseRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, stopChaseRange);
    }
}
