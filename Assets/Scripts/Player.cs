using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{

	public Animator anim;
	public Rigidbody2D playerRigidBody;
	private bool andar;

	private float horizontal;
	public float velocidade;
	public float forcaPulo;

	public bool olhandoDireita;
	public bool pisandoChao;
	public Transform VerificaChao;
	public LayerMask OqueEChao;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		horizontal = Input.GetAxis ("Horizontal");

		pisandoChao = Physics2D.OverlapCircle (VerificaChao.position, 0.05f, OqueEChao);

		if (Input.GetButtonDown ("Jump") && pisandoChao == true) 
		{
			playerRigidBody.AddForce (new Vector2 (0, forcaPulo));
		}

		if (horizontal > 0 && olhandoDireita == false) {
			VirarPersonagem ();
		} 
		else if (horizontal < 0 && olhandoDireita == true) 
		{
			VirarPersonagem ();
		}

		playerRigidBody.velocity = new Vector2 (horizontal * velocidade, playerRigidBody.velocity.y);

		if (horizontal != 0) 
		{
			andar = true;
		} 
		else 
		{
			andar = false;
		}

		anim.SetBool ("Andar", andar);

		anim.SetBool ("PisandoChao", pisandoChao);

		anim.SetFloat ("VelocidadeY", playerRigidBody.velocity.y);
	}

	void VirarPersonagem()
	{
		olhandoDireita = !olhandoDireita;

		Vector3 theScale = transform.localScale;

		theScale.x *= -1;

		transform.localScale = theScale;
	}

	void OnCollisionEnter2D()
	{
		
	}

	void OnTriggerEnter2D()
	{
		
	}

	void OnCollisionExit2D(Collision2D col)
	{

	}

	void OnTriggerExit2D()
	{
		
	}

	void OnCollisionStay2D(Collision2D col)
	{

	}

	void OnTriggerStay2D()
	{
		
	}

}
