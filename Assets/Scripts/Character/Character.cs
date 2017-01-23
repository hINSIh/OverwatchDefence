using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class Character : MonoBehaviour
{
	public int health;

	private Weapon weapon;
	private ISkillHandler skillHandler;

	private Animator animator;

	protected Character() {
		
	}

	void Awake()
	{
		weapon = GetComponent<Weapon>();
		skillHandler = GetComponent<ISkillHandler>();
		StartCoroutine(CoroutineUpdate());
		animator = GetComponent<Animator>();
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

	public Animator GetAnimator() {
		return animator;
	}

	public ISkillHandler skills { 
		get { return skillHandler;} 
	}
}