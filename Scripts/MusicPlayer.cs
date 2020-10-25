using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
	static MusicPlayer instance = null;

	void Awake() {
		//Ensure that only one bg music player
		//is running at a time
		Scene scene = SceneManager.GetActiveScene();

		if (scene.name == "GameLevel" || scene.name == "GameTrainer") {
			instance.gameObject.SetActive (false);
			return;
		} else {
			if (instance != null) {
				instance.gameObject.SetActive (true);
			}
		}


		//This helps to prevent the background sound from
		//playing multiple times in the background.
		if (instance != null) {
			Destroy (gameObject);
		} else {
			//This will help us persist the music until the game starts
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}


	}
		

	// Use this for initialization
	void Start ()
	{
		

	}

	void Update()
	{


	}

}





