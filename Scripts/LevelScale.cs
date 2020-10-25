using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Linq;
using UnityEngine.SocialPlatforms;

/// <summary>
/// Main Menu which includes menu options for
/// Major, Minor, High Score, and Training
/// </summary>
public class LevelScale : MonoBehaviour {

	public Image imgUser;
	public Text txtUser;

	// Use this for initialization
	void Start () {
        //Universal Data Store compatible with all devices.
		SaveFactory.GetGameData ();

        //Only show login information if we are running on the
        //android platform.
        if (Application.platform != RuntimePlatform.Android)
        {
            ShowLoginDetails(false);
        }
        else
        { 
           if (Social.localUser.authenticated)
                {
			        ShowLoginDetails (true);
		        }
		        else
                {
			        ShowLoginDetails (false);
		        }
        }

     

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{ 
			SceneManager.LoadScene ("LevelTitle");
		}
	}

    /// <summary>
    /// If we are on an android phone
    /// we will want to indicate if the
    /// user is a guest or logged into
    /// Google Play Services
    /// </summary>
    /// <param name="show"></param>
	void ShowLoginDetails(bool show) {
		imgUser.gameObject.SetActive (show);
		txtUser.gameObject.SetActive (show);
	}


	public void ResetLevelSelection() {
		CurrentGameData.ThisGameData.CurrentLevelSelected = "";
	}

	public void btnClicked(string param)
	{

		ResetLevelSelection ();

		switch (param) {
		case "Major":			
			SaveFactory.GetGameData ();
			CurrentGameData.ThisGameData.CurrentScaleSelected = param;
			SaveFactory.SaveGameData ();
			SceneManager.LoadScene ("LevelSelect");
			break;
		case "Minor":			
			SaveFactory.GetGameData ();
			CurrentGameData.ThisGameData.CurrentScaleSelected = param;
			SaveFactory.SaveGameData ();	
			SceneManager.LoadScene ("LevelSelect");
			break;
		case "HighScore":
			SaveFactory.GetGameData ();
			CurrentGameData.ThisGameData.CurrentScaleSelected = "HS";
			SaveFactory.SaveGameData ();
			SceneManager.LoadScene ("LevelHighScore");
			break;
		case "Training":
			SceneManager.LoadScene ("GameTrainer");
			break;
		case "Settings":
			//SceneManager.LoadScene ("DevScene");
			SceneManager.LoadScene("Login");
			break;
		}
					

	}

	void SaveLevel() {

	}

}
