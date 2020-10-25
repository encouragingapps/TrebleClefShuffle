using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Linq;

public class LevelGameOver : MonoBehaviour
{
	public Text lblEncouragingSaying;


	// Use this for initialization
	void Start ()
	{
		//Don't display the same note twice!

		string saying1 = "";

		string saying2 = "";

		int RandomNum1 = UnityEngine.Random.Range(0,2);
		Debug.Log (RandomNum1);
		int RandomNum2 = UnityEngine.Random.Range (0,2);
		Debug.Log (RandomNum2);

		switch (RandomNum1) {
		case 0:
			saying1 = "You are doing great!";
			break;
		case 1:
			saying1 = "You are almost there!";
			break;
		}


		switch (RandomNum2) {
		case 0:
			saying2 = "Keep going!";
			break;
		case 1:
			saying2 = "Don't give up! ";
			break;
		}

		lblEncouragingSaying.text = saying1 + " " + saying2;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{ 
			SceneManager.LoadScene ("LevelTitle");
		}

	}


	public void btnClicked(string param)
	{
		//Remember when you are wiring up the button onClick from the Unity
		//make sure to select click event from the scene tab. On the scene
		//tab select level, next choose level script --> btnClicked

		if (param == "Menu") {
			SceneManager.LoadScene ("LevelScaleSelect");
			return;
		}

		if (param == "Training") {
			SceneManager.LoadScene ("GameTrainer");
			return;
		}
			

	}
		

}

