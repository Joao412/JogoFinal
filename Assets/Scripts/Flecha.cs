using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour 
{
	private Esqueleto esqueleto;

	private Minotauro minotauro;

	private Slime slime;

	private Player player;

	public int dano;

	private bool DeuDano;

	public SpriteRenderer flecha;

	// Use this for initialization
	void Start () 
	{
		flecha = GetComponent<SpriteRenderer> ();

		esqueleto = FindObjectOfType (typeof(Esqueleto)) as Esqueleto;

		minotauro = FindObjectOfType (typeof(Minotauro)) as Minotauro;

		slime = FindObjectOfType (typeof(Slime)) as Slime;

		player = FindObjectOfType (typeof(Player)) as Player;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player.Tiro < 0) 
		{
			flecha.flipX = true;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{

		if (col.gameObject.tag == "Esqueleto") 
		{
			if (DeuDano == false) 
			{
				esqueleto.HP -= dano;
				DeuDano = true;
			}
		}

		if (col.gameObject.tag == "Slime") 
		{
			if (DeuDano == false) 
			{
				slime.HP -= dano;
				DeuDano = true;
			}
		}


		if (col.gameObject.tag == "Minotauro") 
		{
			if (DeuDano == false) 
			{
				minotauro.HP -= dano;
				DeuDano = true;
			}
		}



		Destroy(this.gameObject);
	}

	void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}


}
