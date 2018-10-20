using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Weapon : MonoBehaviour {

	public Transform FirePoint;
	public GameObject BulletPrefab;
	
	void Update() {
		if(!CrossPlatformInputManager.GetButtonDown("Fire1")){ return; }
		Shoot();
	}

	void Shoot() {
		Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
	}
}
