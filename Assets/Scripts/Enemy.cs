using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int StartingHealth = 100;
	[SerializeField] private int currentHealth = 100;

	public void Start(){
		currentHealth = StartingHealth;
	}
	
	public void TakeDamage(int damage) {
		currentHealth -= damage;
		if(currentHealth<=0){ Destroy(gameObject); }
	}
}
