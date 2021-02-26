using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour {


	public GameObject player;

	public float speed = 20f;

	 
	void Update () {
		
		float moveX = Input.GetAxis ("Horizontal");
		transform.position = new Vector3 (player.transform.position.x  +  moveX * speed * Time.deltaTime, player.transform.position.y, -10f);
	}
}
