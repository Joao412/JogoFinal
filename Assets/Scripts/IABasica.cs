using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IABasica : MonoBehaviour 
{
	public float velocidade;
	private Rigidbody2D rbInimigo;

	public bool flip;

	// Use this for initialization
	void Start () 
	{
		rbInimigo = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		rbInimigo.velocity = new Vector2 (velocidade, rbInimigo.velocity.y);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag != "Player")
		{
			velocidade *= -1;

			if (flip) 
			{
				Flip ();
			}
		}
	}

	void Flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
