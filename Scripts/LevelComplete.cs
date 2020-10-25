using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Linq;
using UnityEngine.SocialPlatforms;


//TODO:  ADD NEW HIGH SCORE LOGIC

public class LevelComplete : MonoBehaviour
{
	public Text lblScore;
	public Text lblStarBonusScore;
	public Text lblTimeBonusScore;
	public Text lblItemBonusScore;
	public Text lblScale;
	public Text lblRootNote;
	public Text lblAward;

	public eGameLevelCompleteState GameState;

	public Image Star1;
	public Image Star2;
	public Image Star3;
	public Image Star4;
	public Image Star5;

	public Image Award;

	public Image imgUser;
	public Text txtUser;

	public bool Star1AnimationStarted;
	public bool Star2AnimationStarted;
	public bool Star3AnimationStarted;
	public bool Star4AnimationStarted;
	public bool Star5AnimationStarted;

	public int StarsCount;
	public int BonusTime;
	public int TotalScore;

	public int CountDownStarBonusScore;
	public int CountDownBonusTimeScore;
	public int CountDownPickItemScore;
	public int CountDownTotalScore;

	public int FinalStarBonusScore;
	public int FinalBonusTimeScore;
	public int FinalPickItemScore;
	public int FinalTotalScore;
	public int FinalGrandTotalScore;


	public ScoreFactory myScore = new ScoreFactory();


	static float defaultStarAnimation = 6.0f;

	float tmrStarAnimation;

	void HideGameScores() {
		lblStarBonusScore.gameObject.SetActive (false);
		lblTimeBonusScore.gameObject.SetActive (false);
		lblItemBonusScore.gameObject.SetActive (false);
	}

	void ShowLoginDetails(bool show) {
			imgUser.gameObject.SetActive (show);
			txtUser.gameObject.SetActive (show);
	}


	// Use this for initialization
	void Start ()
	{
		if (Social.localUser.authenticated) {
			ShowLoginDetails (true);
		}
		else {
			ShowLoginDetails (false);
		}

		tmrStarAnimation = defaultStarAnimation;
		HideStars ();
		HideGameScores ();
		ShowAward (false);
		SaveFactory.GetGameData ();

		if (CurrentGameData.ThisGameData.IsNewHighScore) {
			ShowAward (true);
			CurrentGameData.ThisGameData.IsNewHighScore = false;
		}

		//Initialize Timer
		StarsCount = CurrentGameData.ThisGameData.CurrentLevelStars;

		//Set the Star score which will be counted down
		CountDownStarBonusScore = CurrentGameData.ThisGameData.CurrentLevelCompleteStarTotalScore;
		FinalStarBonusScore = CountDownStarBonusScore;

		//Set the Bonus time score which will be counted down
		CountDownBonusTimeScore = CurrentGameData.ThisGameData.CurrentLevelCompleteTimeTotalScore;
		FinalBonusTimeScore = CountDownBonusTimeScore;

		//Set the Pickup time score which will be counted down
		CountDownPickItemScore = CurrentGameData.ThisGameData.CurrentLevelCompleteItemTotalScore;
		FinalPickItemScore = CountDownPickItemScore;

		//Set the Total Score. We will add the star and time bonus to the overall score
		TotalScore = CurrentGameData.ThisGameData.CurrentLevelScore;
		CountDownTotalScore = TotalScore;
		FinalTotalScore = TotalScore;
		lblScore.text = TotalScore.ToString ();

			//intScore = CurrentGameData.ThisGameData.CurrentLevelScore;

			if (!CommonUtils.IsStringEmpty(CurrentGameData.ThisGameData.CurrentScaleSelected)) {
				lblRootNote.text = CurrentGameData.ThisGameData.CurrentLevelSelected.Substring(5,1);
			}

			lblScale.text = CurrentGameData.ThisGameData.CurrentScaleSelected;

			GameState = eGameLevelCompleteState.StarBonusCountDownStarted;

			FinalGrandTotalScore = CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore;

		SaveFactory.SaveGameData ();
		
	}

	

    void HideStars() {
		Star1.gameObject.SetActive (false);
		Star2.gameObject.SetActive (false);
		Star3.gameObject.SetActive (false);
		Star4.gameObject.SetActive (false);
		Star5.gameObject.SetActive (false);
	}

	void ShowAward(bool show) {
		lblAward.gameObject.SetActive (show);
		Award.gameObject.SetActive (show);
	}

	public void btnClicked()
	{		
		SceneManager.LoadScene ("LevelScaleSelect");
	}

	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKeyDown(KeyCode.Escape)) 
		{ 
			SceneManager.LoadScene ("LevelTitle");
		}
		
		tmrStarAnimation -= Time.deltaTime;

		if (tmrStarAnimation > 5f) {
			//Show 1st star
			if (StarsCount >= 1) {
				if (!Star1AnimationStarted) {				
					Star1.gameObject.SetActive (true);
					Star1AnimationStarted = true;
				}
			}
		} else if (tmrStarAnimation > 4f) {
			//Show 2nd star
			if (StarsCount >= 2) {
				if (!Star2AnimationStarted) {
					Star2.gameObject.SetActive (true);
					Star2AnimationStarted = true;
				}
			}
		} else if (tmrStarAnimation > 3f) {
			//Show 3rd star
			if (StarsCount >= 3) {
				if (!Star3AnimationStarted) {
					Star3.gameObject.SetActive (true);
					Star3AnimationStarted = true;
				}
			}
		} else if (tmrStarAnimation > 2f) {
			//Show 4th star
			if (StarsCount >= 4) {
				if (!Star4AnimationStarted) {
					Star4.gameObject.SetActive (true);
					Star4AnimationStarted = true;
				}
			}
		} else if (tmrStarAnimation > 1f) {
			//Show 5th star
			if (StarsCount >= 5) {
				if (!Star5AnimationStarted) {
					Star5.gameObject.SetActive (true);
					Star5AnimationStarted = true;
				}			
			}
		}

		//TODO: Implement the star score adding to the Total Score
		switch (GameState) {
		case eGameLevelCompleteState.StarBonusCountDownStarted:
			CountDownStarBonusScore -= 75;
			CountDownTotalScore += 75;

			lblStarBonusScore.gameObject.SetActive (true);

			if (CountDownStarBonusScore <= 0) {
				CountDownStarBonusScore = 0;
				GameState = eGameLevelCompleteState.StarBonusCountDownCompleted;
				lblStarBonusScore.text = "Star Bonus: 0";
			} else {
				lblStarBonusScore.text = "Star Bonus: " + CountDownStarBonusScore.ToString();

				lblScore.text = "Total Score: " + CommonUtils.FormatScoreTotal(CountDownTotalScore);
			}

	
			break;
		case eGameLevelCompleteState.StarBonusCountDownCompleted:
			CountDownBonusTimeScore -= 5;
			CountDownTotalScore += 5;

			lblTimeBonusScore.gameObject.SetActive (true);

			if (CountDownBonusTimeScore <= 0) {
				CountDownBonusTimeScore = 0;
				GameState = eGameLevelCompleteState.TimeBonusCountDownCompleted;
				lblTimeBonusScore.text = "Time Bonus: 0";
			} else {
				lblTimeBonusScore.text = "Time Bonus: " + CountDownBonusTimeScore.ToString();
				lblScore.text = "Total Score: " + CommonUtils.FormatScoreTotal(CountDownTotalScore);
			}
				
			break;
		case eGameLevelCompleteState.TimeBonusCountDownCompleted:
			CountDownPickItemScore -= 30;
			CountDownTotalScore += 30;

			lblItemBonusScore.gameObject.SetActive (true);

			if (CountDownPickItemScore <= 0) {
				CountDownPickItemScore = 0;
				GameState = eGameLevelCompleteState.ItemBonusCountDownCompleted;
				lblItemBonusScore.text = "Item Bonus: 0";
			} else {
				lblItemBonusScore.text = "Item Bonus: " + CountDownPickItemScore.ToString();
				lblScore.text = "Total Score: " + CommonUtils.FormatScoreTotal(CountDownTotalScore);
			}

			break;
		
		case eGameLevelCompleteState.ItemBonusCountDownCompleted:
			lblScore.text = "Total Score: " + FinalGrandTotalScore;
			break;
		}
	


	}
}

