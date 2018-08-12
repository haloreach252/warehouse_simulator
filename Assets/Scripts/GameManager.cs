/*
* Copyright (c) Engineer Industries
* https://www.youtube.com/channel/UC-v_UB0BIwIoKlcq2ZoRmFg
*/

using UnityEngine;

public class GameManager : MonoBehaviour {

	#region Variables
	public GameObject player;
	public GameObject pickupPos;
	public GameObject mainCamera;
	public GameObject lose;
	public GameObject win;

	float timer;
	public UnityEngine.UI.Text timerText;
	#endregion
	
	#region Methods

	void Start () 
	{
		
	}
	
	void Update () 
	{
		timer += Time.deltaTime;
		timerText.text = "Survived: " + timer + " seconds";

		if(timer > 300)
		{
			Win();
		}

	}

	void Win()
	{
		win.SetActive(true);
	}

	public void Lose()
	{
		lose.SetActive(true);
	}
	
	public void Restart()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(1);
	}

	public void Quit()
	{
		Application.Quit();
	}

	#endregion
}
