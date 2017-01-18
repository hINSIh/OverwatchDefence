using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {

    public float fireDelay;
    public int damage; 

    private bool canFire;
    
    public virtual bool CanFire()
    {
        return canFire;
    }

    void TryFire()
    {
        Cooldown();
        Fire();
    }

    public virtual IEnumerator Cooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(fireDelay);
        canFire = true;
    }

    public abstract void Fire();
}
