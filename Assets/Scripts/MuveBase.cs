using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuveBase : MonoBehaviour {

	public float speed = 1f;
	private Rigidbody2D rb;
	private int moveX = 1;
	private bool faceRitght = true;
	Animator anim;
	int curHp;
	int maxHp = 3;
	bool isHit=false;
	public Main main;

	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody2D> ();
		anim = GetComponent <Animator> ();
		curHp = maxHp;
		}

	void Update()
	{
		anim.SetInteger ("State", 2);
	}

	// Update is called once per frame
  	void FixedUpdate () {



		if (rb.position.x > 2 )
			MuvePlus ();

		if (rb.position.x < -2)
			MuveMinus ();



		rb.MovePosition ( rb.position + Vector2.right * moveX * speed * Time.deltaTime);

		if (moveX > 0 && !faceRitght)
			flip ();
		else if (moveX < 0 && faceRitght)
		   flip ();
	}


	void MuvePlus(){
		moveX = -1;
	}

	void MuveMinus(){
		moveX = 1;
	}


	void Stop(){
		moveX = 0;
	}

	void flip ()
	{
		faceRitght = !faceRitght;
		transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
	}

	public void RecountHp(int deltaHp)
	{
		curHp += deltaHp;
		if (deltaHp < 0)
		{	
			StopCoroutine (OnHit());
			isHit = true;
			StartCoroutine (OnHit ());
		}
		print (curHp);
		if (curHp <= 0) {
			Stop ();
			GetComponent<CapsuleCollider2D> ().enabled = false;
			Invoke ("lose", 2f);
		}
	}

	IEnumerator OnHit()
	{	
		if(isHit)
		GetComponent<SpriteRenderer> ().color = new Color (1f,GetComponent<SpriteRenderer> ().color.g - 0.04f ,GetComponent<SpriteRenderer> ().color.b - 0.04f);
		else
			GetComponent<SpriteRenderer> ().color = new Color (1f,GetComponent<SpriteRenderer> ().color.g + 0.04f ,GetComponent<SpriteRenderer> ().color.b + 0.04f);


		if (GetComponent<SpriteRenderer> ().color.g == 1)
			StopCoroutine (OnHit());
		
		if (GetComponent<SpriteRenderer> ().color.g <= 0)
			isHit = false;
		
		yield return new WaitForSeconds(0.02f);
		StartCoroutine( OnHit ());
	}

	void lose()
	{
		main.GetComponent<Main> ().lose ();
	}
}