using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Linq;

public class Level : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{ 
			SceneManager.LoadScene ("LevelScaleSelect");
		}
	}


	public void btnClicked(string param)
	{

		SceneManager.LoadScene ("LevelScaleSelect");
	}
}
