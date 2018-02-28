using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAInimigo : MonoBehaviour 
{

	private Player ScriptPlayer;

	public float velocidade;
	private bool estaNaEsquerda;

	// Use this for initialization
	void Start () 
	{

		ScriptPlayer = FindObjectOfType (typeof(Player)) as Player;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.x < ScriptPlayer.transform.position.x) {
			estaNaEsquerda = true;
		} 
		else if (transform.position.x > ScriptPlayer.transform.position.x) 
		{
			estaNaEsquerda = false;
		}

		float step = velocidade * Time.deltaTime;

		if (ScriptPlayer.olhandoDireita == false && estaNaEsquerda == false) {
			transform.position = Vector3.MoveTowards (transform.position, ScriptPlayer.transform.position, step);
		} 
		else if (ScriptPlayer.olhandoDireita == true && estaNaEsquerda == true) 
		{
			transform.position = Vector3.MoveTowards (transform.position, ScriptPlayer.transform.position, step);
		}
	}
}
