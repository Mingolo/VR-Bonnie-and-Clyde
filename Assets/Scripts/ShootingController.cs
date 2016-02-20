using UnityEngine;
using System;
using System.Collections;

public class ShootingController : MonoBehaviour 
{
	public ParticleSystem gunParticles;                   
	public Light shotLight;
	public double timeBShots;
	public int range;
	public double effectDuration;			//must be less than timeBShots
	public int gunType;						//0 = tommy gun, 1 = shotgun, 2 = revolver

	private double accTime;		//used to enforce fire rate
	private double accTime2;	//for effect duration
	private bool shooting;
	private bool shotEffects;	//true when shot effects are turned on
	private int playerMask;
	private Ray shootRay;
	private ParticleSystem.EmissionModule shotParticles;

	// Use this for initialization
	void Start () 
	{
		accTime = 0;
		accTime2 = effectDuration;
		shooting = false;
		shotEffects = false;
		shotParticles = gunParticles.emission;
		shotParticles.enabled = false;
		gunParticles.Play ();
		playerMask = LayerMask.GetMask ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (shotEffects) 											//turn off shot effects if they were turned on
		{
			accTime2 -= Time.deltaTime;

			if (accTime2 <= 0) 
			{										
				shotLight.enabled = false;
				shotParticles.enabled = false;
				shotEffects = false;
				accTime2 = effectDuration;
			}
		}
		if (shooting)
		{
			accTime -= Time.deltaTime;

			if (accTime <= 0)										//time to shoot a "bullet"	
			{
				shotEffects = true;
				shotLight.enabled = true;											//TRIGGER GUNSHOT SOUND FROM HERE
				shotParticles.enabled = false;
				shotParticles.enabled = true;

				shootRay.origin = transform.position;
				shootRay.direction = transform.forward;

				RaycastHit[] hits;
				hits = Physics.RaycastAll (shootRay, range, playerMask);
				for (int i = 0; i < hits.Length; i++) 
				{
					HitController playerHit = hits[i].collider.GetComponent <HitController>();
					if (gunType == 0) 
					{
						System.Random random = new System.Random ();
						int num = random.Next (0, 5);
						if (num == 0) 
							playerHit.getHit (hits [i].point, true);
						else
							playerHit.getHit (hits [i].point, false);
					}
					else
						playerHit.getHit (hits [i].point, true);
				}
				if (gunType == 0)
					accTime = timeBShots;
				else 
				{
					System.Random random = new System.Random ();
					int min = (int) (timeBShots * 100 * 0.75);
					int max = (int) (timeBShots * 100 * 1.25);
					accTime = random.Next (min, max)/100.0;
					print ("\nWait Time: " + accTime);
				}
			}
		}		
	}

	public void startShooting()
	{
		shooting = true;
		accTime = 0;
	}

	public void stopShooting()
	{
		shooting = false;
		accTime = 0;
	}
}
