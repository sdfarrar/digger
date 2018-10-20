using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class RayWeapon : MonoBehaviour {

	public Transform FirePoint;
	public int Damage = 40;
	public GameObject ImpactEffect;
	public LineRenderer LineRenderer;

	void Update() {
		if(!CrossPlatformInputManager.GetButtonDown("Fire1")){ return; }
		Shoot();
	}

	void Shoot() {
		RaycastHit2D hitInfo = Physics2D.Raycast(FirePoint.position, FirePoint.right);
		if(!hitInfo){ 
			StartCoroutine(RenderRay(FirePoint.position, FirePoint.position + FirePoint.right * 100));
			return; 
		}

		Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
		if(!enemy){ return; }

		enemy.TakeDamage(Damage);

		GameObject go = Instantiate(ImpactEffect, hitInfo.point, Quaternion.identity);
		Destroy(go, 1);

		StartCoroutine(RenderRay(FirePoint.position, hitInfo.point));

	}

	private IEnumerator RenderRay(Vector3 startPos, Vector3 endPos){
		LineRenderer.SetPosition(0, startPos);
		LineRenderer.SetPosition(1, endPos);

		LineRenderer.enabled = true;
		for(int i=0; i<12; ++i){
			yield return null;
		}
		LineRenderer.enabled = false;
	}
}
