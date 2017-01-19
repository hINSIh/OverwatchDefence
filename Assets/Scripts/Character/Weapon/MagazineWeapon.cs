using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MagazineWeapon : Weapon
{
	public float reloadDelay;
	public int magazine;
	private bool canFire = true;

	private int currentMagazine;

	void Awake() {
		currentMagazine = magazine;
	}

	public IEnumerator Reload() {
		Debug.Log("reloading...");
		yield return new WaitForSeconds(reloadDelay);
		Debug.Log("reload complete");

		currentMagazine = magazine;
	}

	public override bool CanFire()
	{
		return canFire;
	}

	public override IEnumerator Cooldown()
	{
		canFire = false;
		currentMagazine--;

		if (currentMagazine <= 0)
		{
			yield return Reload();
		}
		else
		{
			yield return new WaitForSeconds(fireDelay);
		}

		canFire = true;
	}

	public int GetCurrentMagazine()
	{
		return currentMagazine;
	}
}