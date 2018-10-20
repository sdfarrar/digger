using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {

	public float Speed = 20f;
	public int damage = 40;
	public Rigidbody2D rb;
	public GameObject ImpactEffect;

	void Start() {
		rb.velocity = transform.right * Speed;
	}

	void OnTriggerEnter2D(Collider2D hitInfo) {
		Debug.Log(hitInfo.name);
		Destroy(gameObject);
		if(hitInfo.name=="Ground"){
			Tilemap map = hitInfo.GetComponent<Tilemap>();
			Vector3Int cellPos = map.WorldToCell(transform.position);
			//Tile tile = (Tile)map.GetTile(cellPos);
			map.SetTile(cellPos, null);
		}

		GameObject go = Instantiate(ImpactEffect, transform.position, transform.rotation);
		Destroy(go, 1);
	}
	
}
