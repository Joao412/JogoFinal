using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{

	public Animator anim;
	public Rigidbody2D playerRigidBody;
	private bool andar;
	private bool atirar;
	private bool ParadoNaAgua;
	private bool Nadar;
	private bool PlayerMorrendo;

	private float horizontal;
	public float velocidade;
	public float forcaPulo;

	public bool olhandoDireita;
	public bool pisandoChao;
	public bool DentroDaAgua;
	public Transform VerificaAgua;
	public Transform VerificaChao;
	public LayerMask OqueEChao;
	public LayerMask OqueEAgua;
	public GameObject Flecha;
	public Transform Arco;
	public float Tiro;

	public bool parede;

	public int HP;


	// Use this for initialization
	void Start () 
	{
		if (!olhandoDireita) 
		{
			Tiro *= -1;
			PlayerMorrendo = false;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		horizontal = Input.GetAxis ("Horizontal");

		pisandoChao = Physics2D.OverlapCircle (VerificaChao.position, 0.05f, OqueEChao);

		DentroDaAgua = Physics2D.OverlapCircle (VerificaAgua.position, 0.05f, OqueEAgua);


		if (Input.GetButtonDown ("Jump") && pisandoChao == true) 
		{
			playerRigidBody.AddForce (new Vector2 (0, forcaPulo));
		}


		if (Input.GetButtonDown ("Jump") && DentroDaAgua == true) 
		{
			playerRigidBody.AddForce (new Vector2 (0, forcaPulo));
		}


		if (horizontal > 0 && olhandoDireita == false) 
		{
			VirarPersonagem ();
		} 
		else if (horizontal < 0 && olhandoDireita == true) 
		{
			VirarPersonagem ();
		}

		if (parede == false) 
		{
			playerRigidBody.velocity = new Vector2 (horizontal * velocidade, playerRigidBody.velocity.y);
		}

		if (horizontal != 0 && DentroDaAgua == false) 
		{
			andar = true;
		} 
		else 
		{
			andar = false;
		}



		if (horizontal != 0 && DentroDaAgua == true) 
		{
			andar = false;
			Nadar = true;
			ParadoNaAgua = false;
		} 
		if(horizontal == 0 && DentroDaAgua == true) 
		{
			andar = false;
			Nadar = false;
			ParadoNaAgua = true;
		}



		if (Input.GetButtonDown ("Fire1")) 
		{
			Atirar ();
			atirar = true;
		} 
		else 
		{
			atirar = false;
		}
			

		anim.SetBool ("Atirar", atirar);

		anim.SetBool ("Andar", andar);

		anim.SetBool ("PisandoChao", pisandoChao);

		anim.SetFloat ("VelocidadeY", playerRigidBody.velocity.y);

		anim.SetBool ("ParadoAgua", ParadoNaAgua);

		anim.SetBool ("Nadar", Nadar);

		anim.SetBool ("PlayerMorrendo", PlayerMorrendo);

	}

	void VirarPersonagem()
	{
		olhandoDireita = !olhandoDireita;

		Vector3 theScale = transform.localScale;

		theScale.x *= -1;
		Tiro *= -1;

		transform.localScale = theScale;
	}

	void Atirar()
	{
		GameObject tempPrefab = Instantiate (Flecha) as GameObject;
		tempPrefab.transform.position = Arco.position;
		tempPrefab.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Tiro, 0));
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		switch (col.gameObject.tag) 
		{
			case "PlataformaMovel":
				transform.parent = col.gameObject.transform;
				break;

		case "Inimigo":
				PlayerMorrendo = true;
				forcaPulo = 0;
				velocidade = 0;
				Destroy (this.gameObject);
				break;

			case "Lava":
				Destroy (this.gameObject);
				break;
		}
			
	}

	void OnTriggerEnter2D()
	{

	}

	void OnCollisionExit2D(Collision2D col)
	{
		switch (col.gameObject.tag) 
		{
			case "PlataformaMovel":
				transform.parent = null;
				break;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (!col.isTrigger) 
		{
			parede = false;
		}
	}

	void OnCollisionStay2D(Collision2D col)
	{

	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (!col.isTrigger) 
		{
			parede = true;
		}
	}

}
