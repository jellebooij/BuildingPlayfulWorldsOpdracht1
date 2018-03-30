using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour {

    public bool bonus;

    [SerializeField]
    private Projectile projectile;


    [SerializeField]
    private Projectile bonusProjectile;

    [SerializeField]
    private Transform barrelEnd;

    [SerializeField]
    private float damage;

    public int numBullets = 1;
    public float spread = 0;
    public float msBetweenShots = 100;

    float nextShotTime;

    void Start () {
		
	}
	
	
	void Update () {


	}

    public bool Shoot()
    {
        if (Time.time > ((!bonus) ? (nextShotTime) : (nextShotTime - msBetweenShots / 250)))
        {
            for (int i = 0; i < numBullets; i++)
            {
                if (bonus)
                {
                    Projectile p = Instantiate(bonusProjectile, barrelEnd.position, barrelEnd.rotation * (Quaternion.Euler(Random.insideUnitCircle * spread)));
                    p.Init(3);
                }
                else
                {

                    Projectile p = Instantiate(projectile, barrelEnd.position, barrelEnd.rotation * (Quaternion.Euler(Random.insideUnitCircle * spread)));
                    p.Init(damage);
                }
            }
            
            nextShotTime = Time.time + msBetweenShots / 100;
            return true;
        }

        return false;
    }
}
