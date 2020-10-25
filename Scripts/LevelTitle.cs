using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Linq;


//Google Game Play Services Refer to https://www.youtube.com/watch?v=PUE4ZekqA5s&t=921s

public class LevelTitle : MonoBehaviour {

	//GameSparkFactory gsFactory = new GameSparkFactory();


	void Start () {
		// Use this for initialization google play services
		SaveFactory.GetGameData ();
	}

		
	// Update is called once per frame
	void Update () {
		
		if(Input.GetButtonDown("Fire1"))
		{        
                SceneManager.LoadScene("LevelScaleSelect");
        }
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{ 
			Application.Quit(); 
		}
	}
		
		


}
