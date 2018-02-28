using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour 
{
	public float velocidade;
	public GameObject objetoPlataforma;
	public Transform A;
	public Transform B;
	public Transform C;
	public Transform destino;
	private string rota;
	private int randomico;

	// Use this for initialization
	void Start () 
	{
		objetoPlataforma.transform.position = A.position;
		randomico = Random.Range (0, 100);

		if (randomico < 50) 
		{
			rota = "B";
			destino.position = B.position;
		} 
		else 
		{
			rota = "C";
			destino.position = C.position;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

		float step = velocidade * Time.deltaTime;
		objetoPlataforma.transform.position = Vector3.MoveTowards (objetoPlataforma.transform.position, destino.position, step);

		if (objetoPlataforma.transform.position == destino.position) 
		{

			/*switch (rota) 
			{

			case 0:
				destino.position = C.position;
				rota = 1;
				break;

			case 1:
				destino.position = A.position;
				rota = 2;
				break;

			case 2:
				destino.position = B.position;
				rota = 0;
				break;

			}*/

			switch (rota) 
			{

			case "A":
				randomico = Random.Range (0, 100);

				if (randomico < 50) 
				{
					rota = "B";
					destino.position = B.position;
				} 
				else 
				{
					rota = "C";
					destino.position = C.position;
				}
				break;


			case "B":
				randomico = Random.Range (0, 100);

				if (randomico < 50) 
				{
					rota = "A";
					destino.position = A.position;
				} 
				else 
				{
					rota = "C";
					destino.position = C.position;
				}
				break;

			case "C":
				randomico = Random.Range (0, 100);

				if (randomico < 50) 
				{
					rota = "A";
					destino.position = B.position;
				} 
				else 
				{
					rota = "B";
					destino.position = A.position;
				}
				break;
				

			}
		}
	}
}
