using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {

    public float fireDelay;
    public int damage; 

    private bool canFire = true;
    
    public virtual bool CanFire()
    {
        return canFire;
    }

    public void TryFire(Vector3 mousePosition)
    {
		StartCoroutine(Cooldown());
        Fire(mousePosition);
    }

    public virtual IEnumerator Cooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(fireDelay);
        canFire = true;
    }

    public abstract void Fire(Vector3 targetPosition);
}
