/*
* Copyright (c) Engineer Industries
* https://www.youtube.com/channel/UC-v_UB0BIwIoKlcq2ZoRmFg
*/

using UnityEngine;

public class Crate : MonoBehaviour {

	#region Variables
	GameManager gameManager;
	Transform pickupPos;
	Transform player;
	#endregion
	
	#region Methods

	void Start () 
	{
		gameManager = FindObjectOfType<GameManager>();
		pickupPos = gameManager.pickupPos.transform;
		player = gameManager.player.transform;
	}
	
	void Update () 
	{
		//transform.rotation = gameManager.mainCamera.transform.rotation;
	}

	public void Pickup()
	{
		transform.parent = gameManager.mainCamera.transform;
		transform.position = pickupPos.position;
		transform.rotation = Quaternion.identity;
		GetComponent<Rigidbody>().useGravity = false;
		GetComponent<Rigidbody>().detectCollisions = false;
	}

	public void Drop()
	{
		transform.parent = null;
		GetComponent<Rigidbody>().useGravity = true;
		GetComponent<Rigidbody>().detectCollisions = true;
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			gameManager.Lose();
		}
	}

	#endregion
}
