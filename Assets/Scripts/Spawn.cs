/*
* Copyright (c) Engineer Industries
* https://www.youtube.com/channel/UC-v_UB0BIwIoKlcq2ZoRmFg
*/

using UnityEngine;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {

	#region Variables
	public float crateSpawnVelocity;
	public GameObject cratePrefab;
	public Transform crateSpawnPos;
	Vector3 crateSpawn;
	public bool autoSpawnCrates;
	public float repeatRate;
	public int maxCrates;

	List<GameObject> crates = new List<GameObject>();
	#endregion
	
	#region Methods

	void Start () 
	{
		crateSpawn = new Vector3(crateSpawnPos.position.x, crateSpawnPos.position.y + 1.5f, crateSpawnPos.position.z);
	}
	
	void Update () 
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (autoSpawnCrates)
		{
			InvokeRepeating("SpawnCrate", 0.0f, repeatRate);
		}else
		{
			SpawnCrate();
		}
		
	}

	public void SpawnCrate()
	{
		if(crates.Count <= maxCrates)
		{
			GameObject crate = Instantiate(cratePrefab, crateSpawn, Quaternion.identity);
			Vector3 motion = new Vector3(1, 1, 0);
			crate.GetComponent<Rigidbody>().velocity = crateSpawnVelocity * motion;
			crates.Add(crate);
		}
	}
	
	#endregion
}
