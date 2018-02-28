using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour 
{
	public Player player;

	public Transform Esquerda;
	public Transform Direita;

	public float velocidade;

	void Start()
	{
		player = FindObjectOfType (typeof(Player)) as Player;
	}


	void Update()
	{
		float x = player.transform.position.x;
		Vector3 posicaoPlayer = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z);

		if(x > Esquerda.transform.position.x && x < Direita.transform.position.x)
		{
			transform.position = Vector3.Lerp(transform.position, posicaoPlayer, velocidade);
		}


		if(transform.position.x > Esquerda.transform.position.x && transform.position.x < Direita.transform.position.x)
		{
			transform.position = Vector3.Lerp(transform.position, posicaoPlayer, velocidade);
		}


	}
}
