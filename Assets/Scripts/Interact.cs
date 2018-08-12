/*
* Copyright (c) Engineer Industries
* https://www.youtube.com/channel/UC-v_UB0BIwIoKlcq2ZoRmFg
*/

using UnityEngine;

public class Interact : MonoBehaviour {

	#region Variables
	PlayerMovement playerMovement;
	GameObject currentObject;
	Crate crate;
	#endregion
	
	#region Methods

	void Start () 
	{
		playerMovement = GetComponent<PlayerMovement>();
	}
	
	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			if(currentObject == null)
			{
				RaycastHit hit;

				if (Physics.Raycast(playerMovement.camera.transform.position, playerMovement.camera.transform.forward, out hit, Mathf.Infinity))
				{
					if (hit.collider.tag == "Crate" && hit.collider.gameObject != currentObject)
					{
						crate = hit.collider.gameObject.GetComponent<Crate>();
						crate.Pickup();
						currentObject = hit.collider.gameObject;
						Debug.Log("Set Crate and picked up");
					}
					else if (hit.collider.tag == "Crate" && hit.collider.gameObject == currentObject)
					{
						crate.Drop();
						crate = null;
						currentObject = null;
						Debug.Log("Crate dropped and set to null");
					}
					else
					{
						Debug.Log("Object is not a crate");
					}
				}
			}else
			{
				crate.Drop();
				currentObject = null;
			}
			
		}
	}
	
	#endregion
}
