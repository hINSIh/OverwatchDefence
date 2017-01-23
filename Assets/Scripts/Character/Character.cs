using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
	public int health;

	private Weapon weapon;
	private ISkillHandler skillHandler;

	protected Character() {
		
	}

	// Use this for initialization
	void Start()
	{
		weapon = GetComponent<Weapon>();
		skillHandler = GetComponent<ISkillHandler>();
		StartCoroutine(CoroutineUpdate());
	}

	void Update() { 
		
	}

	public IEnumerator CoroutineUpdate() {
		while (true) {
			yield return null;
			if (Input.GetMouseButton(0) && weapon.CanFire()) {
				weapon.TryFire(Input.mousePosition);
			}
		}
	}
}