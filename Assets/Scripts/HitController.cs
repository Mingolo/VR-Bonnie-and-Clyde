using UnityEngine;
using System.Collections;

public class HitController : MonoBehaviour 
{
	public GameObject damageParticles;
	public int objectType;					//what object is this script running on? 0 = player car doors, 1 = everywhere else on the car, 2 = person

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void getHit(Vector3 hitPoint, bool inst)
	{	
		if (objectType == 0) 
		{	
			if(inst)
				Instantiate (damageParticles, hitPoint, transform.rotation);
		} 
		else if (objectType == 1) 
		{
			if(inst)
				Instantiate (damageParticles, hitPoint, transform.rotation);
		}
	}
}
