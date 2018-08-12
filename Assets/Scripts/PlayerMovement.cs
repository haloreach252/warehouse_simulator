/*
* Copyright (c) Engineer Industries
* https://www.youtube.com/channel/UC-v_UB0BIwIoKlcq2ZoRmFg
*/

using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	#region Variables
	public new GameObject camera;

	public float speed;
	public float jumpSpeed;
	public float rotateSpeed;

	Rigidbody rb;
	#endregion
	
	#region Methods

	void Start () 
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		rb = GetComponent<Rigidbody>();
	}
	
	void Update () 
	{
		//Camera Looking
		float m = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime * -1;
		camera.transform.Rotate(m, 0, 0);

		//Player Movement
		float h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		float v = Input.GetAxis("Vertical") * speed * Time.deltaTime;

		transform.Translate(h, 0, v);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			rb.velocity = jumpSpeed * Vector3.up;
		}

		//Player Rotation
		float m2 = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
		transform.Rotate(0, m2, 0);

		//Set Cursor States
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		//if (Input.GetMouseButtonDown(0))
		//{
			//Cursor.lockState = CursorLockMode.Locked;
		//	Cursor.visible = false;
		//}

	}
	
	#endregion
}
