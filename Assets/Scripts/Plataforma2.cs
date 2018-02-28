using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma2 : MonoBehaviour 
{
	public float velocidade;
	public GameObject objetoPlataforma;
	public Transform A;
	public Transform B;
	public Transform destino;
	private int rota;


	// Use this for initialization
	void Start () 
	{
		objetoPlataforma.transform.position = A.position;
	}

	// Update is called once per frame
	void Update () 
	{

		float step = velocidade * Time.deltaTime;
		objetoPlataforma.transform.position = Vector3.MoveTowards (objetoPlataforma.transform.position, destino.position, step);

		if (objetoPlataforma.transform.position == destino.position) 
		{
			if(rota == 0)
			{
				destino.position = A.position;
				rota = 1;
			}
			else if (rota == 1)
			{
				rota = 0;
				destino.position = B.position;
			}				
		}

	}
}