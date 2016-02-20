using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	private GameObject[] guns;

	// Use this for initialization
	void Start () 
	{
		guns = GameObject.FindGameObjectsWithTag("Gun");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		for (int i = 0; i < guns.Length; i++) 
		{
			GunController gun = guns[i].GetComponent <GunController>();
			gun.startShooting ();
		}
	}
}
