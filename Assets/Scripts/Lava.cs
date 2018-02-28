using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour 
{

	private Player ScriptPlayer;

	public int dano;

	private bool TomouDano;

	// Use this for initialization
	void Start () 
	{
		ScriptPlayer = FindObjectOfType (typeof(Player)) as Player;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			TomouDano = false;
		}
	}
}
