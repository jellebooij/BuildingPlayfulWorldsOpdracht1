using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {




    [SerializeField]
    private LayerMask hitMask;

    [SerializeField]
    private float damage;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float selfDistructTime;

    private float damageMultiplier;

    private void Start()
    {
        Destroy(gameObject, selfDistructTime);
    }

    public void Init(float damageMultiplier)
    {
        this.damageMultiplier = damageMultiplier;
        damage *= damageMultiplier; 
    }

    void Update()
    {

        Vector3 nextPos = transform.position + (transform.forward * speed * Time.deltaTime);

        RaycastHit hit;

        Debug.DrawLine(transform.position, nextPos);

        if (Physics.Linecast(transform.position, nextPos, out hit, hitMask, QueryTriggerInteraction.Collide))
        {
            IDamageable damagable = hit.collider.gameObject.GetComponent<IDamageable>();

            if(damagable != null)
            {
                damagable.TakeHit(damage);
                Destroy(gameObject);
            }
        }

        transform.position = nextPos;

    }
}
