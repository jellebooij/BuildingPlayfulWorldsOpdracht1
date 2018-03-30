using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBase : MonoBehaviour, IDamageable
{
    NavMeshAgent controller;
    [SerializeField]
    public GameObject blood;

    [SerializeField]
    Transform playerTransform;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float health;



	void Start () {
        controller = GetComponent<NavMeshAgent>();
        playerTransform = FindObjectOfType<FpsController>().transform;
	}
	
	
	void Update () {
        controller.destination = playerTransform.position;
        controller.speed = speed;

        if(Vector3.Distance(transform.position,playerTransform.position) < GameStateManager.instance.distanceToPlayer)
        {
            GameStateManager.instance.onDeath();
        }
	}

    public void TakeHit(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(blood, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
