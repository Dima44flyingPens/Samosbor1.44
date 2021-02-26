using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuveEnemi1 : MonoBehaviour {
	
	public float speed = 1f;
	private Rigidbody2D rb;
	private int moveX = -1;
	private bool faceRitght = true;
	Animator anim;



	public bool moveLeft = true;
	public Transform GraundDetect;




	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody2D> ();
		anim = GetComponent <Animator> ();
	}


	private void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.tag == "Player") 
		{
			collision.gameObject.GetComponent<MuveBase> ().RecountHp (-1);
			collision.gameObject.GetComponent<Rigidbody2D> ().AddForce (transform.up * 8f, ForceMode2D.Impulse);
			anim.SetInteger ("State", 2);

			}
	}

	private void OnCollisionExit2D (Collision2D collision)
	{
		anim.SetInteger ("State", 1);

	}


	void Update()
	{
		//anim.SetInteger ("State", 1);
		transform.Translate(Vector2.left*speed*Time.deltaTime);
		RaycastHit2D groundInfo = Physics2D.Raycast (GraundDetect.position,Vector2.down,1f);

		if (groundInfo.collider == false)
		{ 
			if (moveLeft == true) {
				transform.eulerAngles = new Vector3 (0, 180,0);
				moveLeft = false;
			} 
			else {
				transform.eulerAngles = new Vector3 (0, 0,0);
				moveLeft = true;
			}
		 }
	}




	// Update is called once per frame
	/*void FixedUpdate () {

		if (rb.position.x > 20 )
			MuvePlus ();

		if (rb.position.x < -20)
			MuveMinus ();



		rb.MovePosition ( rb.position + Vector2.right * moveX * speed * Time.deltaTime);

		if (moveX < 0 && !faceRitght)
			flip ();
		else if (moveX > 0 && faceRitght)
			flip ();
	}*/


	void MuvePlus(){
		moveX = -1;
	}

	void MuveMinus(){
		moveX = 1;
	}

	void flip ()
	{
		faceRitght = !faceRitght;
		transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
	}
}