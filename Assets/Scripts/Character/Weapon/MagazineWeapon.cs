using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MagazineWeapon : Weapon {
    public float reloadDelay;
    public int magazine;
    private bool canFire;

    private int currentMagazine;

    public override IEnumerator Cooldown()
    {
        canFire = false;

        currentMagazine--;

        if (currentMagazine <= 0)
        {
            yield return new WaitForSeconds(reloadDelay);

            //animation.Play(Reload);
        }

        else
        {
            yield return new WaitForSeconds(reloadDelay);
        }

        canFire = true;


    }

}
