using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class DebugVariables : MonoBehaviour {

	public Text lblCMajorHighScore; 
	public Text lblDMajorHighScore; 
	public Text lblEMajorHighScore; 
	public Text lblFMajorHighScore; 
	public Text lblGMajorHighScore; 
	public Text lblAMajorHighScore; 
	public Text lblBMajorHighScore; 
	public Text lblCMinorHighScore; 
	public Text lblDMinorHighScore; 
	public Text lblEMinorHighScore; 
	public Text lblFMinorHighScore; 
	public Text lblGMinorHighScore; 
	public Text lblAMinorHighScore; 
	public Text lblBMinorHighScore; 

	public Text lblCMajorUnLocked; 
	public Text lblDMajorUnLocked; 
	public Text lblEMajorUnLocked; 
	public Text lblFMajorUnLocked; 
	public Text lblGMajorUnLocked; 
	public Text lblAMajorUnLocked; 
	public Text lblBMajorUnLocked; 
	public Text lblCMinorUnLocked; 
	public Text lblDMinorUnLocked; 
	public Text lblEMinorUnLocked; 
	public Text lblFMinorUnLocked; 
	public Text lblGMinorUnLocked; 
	public Text lblAMinorUnLocked; 
	public Text lblBMinorUnLocked; 

	public Text lblCurrentLevelSelected;
	public Text lblCurrentScaleSelected;
	public Text lblCurrentLevelScore;
	public Text lblCurrentLevelCorrect;
	public Text lblCurrentLevelMissed;
	public Text lblCurrentLevelStars;
	public Text lblCurrentLevelTimeBonus;
	public Text lblCurrentLevelTotalStar;
	public Text lblCurrentLevelTotalTime;
	public Text lblCurrentLevelTotalItem;
	public Text lblCurrentLevelGrandTotal;

	public Text lblAppVersion;



	// Use this for initialization
	void Start () {

		SaveFactory.GetGameData();
		SaveFactory.SaveGameData();

		const string ScoreFormat = "0000000";
		const string StarScoreFormat = "00";
		const string ItemScoreFormat = "00";
		const string BonusTimeFormat = "0000";

		//High Score Data
		lblCMajorHighScore.text = 
			"C Major HS: [" + CurrentGameData.ThisGameData.CMajorHighScore.ToString(ScoreFormat) + 
			"] Stars: [" + CurrentGameData.ThisGameData.CMajorHighScoreStars.ToString(StarScoreFormat) + "]" +
			"] Bonus Time: [" + CurrentGameData.ThisGameData.CMajorHighScoreBonusTime.ToString(BonusTimeFormat) + "]" +
			"] Items: [" + CurrentGameData.ThisGameData.CMajorHighScoreItems.ToString(ItemScoreFormat) + "]";
		lblDMajorHighScore.text = 
			"D Major HS: [" + CurrentGameData.ThisGameData.DMajorHighScore.ToString(ScoreFormat) + 
			"] Stars: [" + CurrentGameData.ThisGameData.DMajorHighScoreStars.ToString(StarScoreFormat) + "]" +
			"] Bonus Time: [" + CurrentGameData.ThisGameData.DMajorHighScoreBonusTime.ToString(BonusTimeFormat) + "]" +
			"] Items: [" + CurrentGameData.ThisGameData.DMajorHighScoreItems.ToString(ItemScoreFormat) + "]";
		lblEMajorHighScore.text = 
			"E Major HS: [" + CurrentGameData.ThisGameData.EMajorHighScore.ToString(ScoreFormat) + 
			"] Stars: [" + CurrentGameData.ThisGameData.EMajorHighScoreStars.ToString(StarScoreFormat) + "]" +
			"] Bonus Time: [" + CurrentGameData.ThisGameData.EMajorHighScoreBonusTime.ToString(BonusTimeFormat) + "]" +
			"] Items: [" + CurrentGameData.ThisGameData.EMajorHighScoreItems.ToString(ItemScoreFormat) + "]";
		lblFMajorHighScore.text = 
			"F Major HS: [" + CurrentGameData.ThisGameData.FMajorHighScore.ToString(ScoreFormat) + 
			"] Stars: [" + CurrentGameData.ThisGameData.FMajorHighScoreStars.ToString(StarScoreFormat) + "]" +
			"] Bonus Time: [" + CurrentGameData.ThisGameData.FMajorHighScoreBonusTime.ToString(BonusTimeFormat) + "]" +
			"] Items: [" + CurrentGameData.ThisGameData.FMajorHighScoreItems.ToString(ItemScoreFormat) + "]";
		lblGMajorHighScore.text = 
			"G Major HS: [" + CurrentGameData.ThisGameData.GMajorHighScore.ToString(ScoreFormat) + 
			"] Stars: [" + CurrentGameData.ThisGameData.GMajorHighScoreStars.ToString(StarScoreFormat) + "]" +
			"] Bonus Time: [" + CurrentGameData.ThisGameData.GMajorHighScoreBonusTime.ToString(BonusTimeFormat) + "]" +
			"] Items: [" + CurrentGameData.ThisGameData.GMajorHighScoreItems.ToString(ItemScoreFormat) + "]";
		lblAMajorHighScore.text = 
			"A Major HS: [" + CurrentGameData.ThisGameData.AMajorHighScore.ToString(ScoreFormat) + 
			"] Stars: [" + CurrentGameData.ThisGameData.AMajorHighScoreStars.ToString(StarScoreFormat) + "]" +
			"] Bonus Time: [" + CurrentGameData.ThisGameData.AMajorHighScoreBonusTime.ToString(BonusTimeFormat) + "]" +
			"] Items: [" + CurrentGameData.ThisGameData.AMajorHighScoreItems.ToString(ItemScoreFormat) + "]";
		lblBMajorHighScore.text = 
			"B Major HS: [" + CurrentGameData.ThisGameData.BMajorHighScore.ToString(ScoreFormat) + 
			"] Stars: [" + CurrentGameData.ThisGameData.BMajorHighScoreStars.ToString(StarScoreFormat) + "]" +
			"] Bonus Time: [" + CurrentGameData.ThisGameData.BMajorHighScoreBonusTime.ToString(BonusTimeFormat) + "]" +
			"] Items: [" + CurrentGameData.ThisGameData.BMajorHighScoreItems.ToString(ItemScoreFormat) + "]";
		lblCMinorHighScore.text = 
			"C Minor HS: [" + CurrentGameData.ThisGameData.CMinorHighScore.ToString(ScoreFormat) + 
			"] Stars: [" + CurrentGameData.ThisGameData.CMinorHighScoreStars.ToString(StarScoreFormat) + "]" +
			"] Bonus Time: [" + CurrentGameData.ThisGameData.CMinorHighScoreBonusTime.ToString(BonusTimeFormat) + "]" +
			"] Items: [" + CurrentGameData.ThisGameData.CMinorHighScoreItems.ToString(ItemScoreFormat) + "]";
		lblDMinorHighScore.text = 
			"D Minor HS: [" + CurrentGameData.ThisGameData.DMinorHighScore.ToString(ScoreFormat) + 
			"] Stars: [" + CurrentGameData.ThisGameData.DMinorHighScoreStars.ToString(StarScoreFormat) + "]" +
			"] Bonus Time: [" + CurrentGameData.ThisGameData.DMinorHighScoreBonusTime.ToString(BonusTimeFormat) + "]" +
			"] Items: [" + CurrentGameData.ThisGameData.DMinorHighScoreItems.ToString(ItemScoreFormat) + "]";
		lblEMinorHighScore.text = 
			"E Minor HS: [" + CurrentGameData.ThisGameData.EMinorHighScore.ToString(ScoreFormat) + 
			"] Stars: [" + CurrentGameData.ThisGameData.EMinorHighScoreStars.ToString(StarScoreFormat) + "]" +
			"] Bonus Time: [" + CurrentGameData.ThisGameData.EMinorHighScoreBonusTime.ToString(BonusTimeFormat) + "]" +
			"] Items: [" + CurrentGameData.ThisGameData.EMinorHighScoreItems.ToString(ItemScoreFormat) + "]";
		lblFMinorHighScore.text = 
			"F Minor HS: [" + CurrentGameData.ThisGameData.FMinorHighScore.ToString(ScoreFormat) + 
			"] Stars: [" + CurrentGameData.ThisGameData.FMinorHighScoreStars.ToString(StarScoreFormat) + "]" +
			"] Bonus Time: [" + CurrentGameData.ThisGameData.FMinorHighScoreBonusTime.ToString(BonusTimeFormat) + "]" +
			"] Items: [" + CurrentGameData.ThisGameData.FMinorHighScoreItems.ToString(ItemScoreFormat) + "]";
		lblGMinorHighScore.text = 
			"G Minor HS: [" + CurrentGameData.ThisGameData.GMinorHighScore.ToString(ScoreFormat) + 
			"] Stars: [" + CurrentGameData.ThisGameData.GMinorHighScoreStars.ToString(StarScoreFormat) + "]" +
			"] Bonus Time: [" + CurrentGameData.ThisGameData.GMinorHighScoreBonusTime.ToString(BonusTimeFormat) + "]" +
			"] Items: [" + CurrentGameData.ThisGameData.GMinorHighScoreItems.ToString(ItemScoreFormat) + "]";
		lblAMinorHighScore.text = 
			"A Minor HS: [" + CurrentGameData.ThisGameData.AMinorHighScore.ToString(ScoreFormat) + 
			"] Stars: [" + CurrentGameData.ThisGameData.AMinorHighScoreStars.ToString(StarScoreFormat) + "]" +
			"] Bonus Time: [" + CurrentGameData.ThisGameData.AMinorHighScoreBonusTime.ToString(BonusTimeFormat) + "]" +
			"] Items: [" + CurrentGameData.ThisGameData.AMinorHighScoreItems.ToString(ItemScoreFormat) + "]";
		lblBMinorHighScore.text = 
			"B Minor HS: [" + CurrentGameData.ThisGameData.BMinorHighScore.ToString(ScoreFormat) + 
			"] Stars: [" + CurrentGameData.ThisGameData.BMinorHighScoreStars.ToString(StarScoreFormat) + "]" +
			"] Bonus Time: [" + CurrentGameData.ThisGameData.BMinorHighScoreBonusTime.ToString(BonusTimeFormat) + "]" +
			"] Items: [" + CurrentGameData.ThisGameData.BMinorHighScoreItems.ToString(ItemScoreFormat) + "]";

		//Unlocked Data

		SaveFactory.SaveGameData();

		lblCMajorUnLocked.text = "C Major UL: " + CurrentGameData.ThisGameData.CMajorScaleUnLocked.ToString();
		lblDMajorUnLocked.text = "D Major UL: " + CurrentGameData.ThisGameData.DMajorScaleUnLocked.ToString();
		lblEMajorUnLocked.text = "E Major UL: " + CurrentGameData.ThisGameData.EMajorScaleUnLocked.ToString();
		lblFMajorUnLocked.text = "F Major UL: " + CurrentGameData.ThisGameData.FMajorScaleUnLocked.ToString();
		lblGMajorUnLocked.text = "G Major UL: " + CurrentGameData.ThisGameData.GMajorScaleUnLocked.ToString();
		lblAMajorUnLocked.text = "A Major UL: " + CurrentGameData.ThisGameData.AMajorScaleUnLocked.ToString();
		lblBMajorUnLocked.text = "B Major UL: " + CurrentGameData.ThisGameData.BMajorScaleUnLocked.ToString();
		lblCMinorUnLocked.text = "C Minor UL: " + CurrentGameData.ThisGameData.CMinorScaleUnLocked.ToString();
		lblDMinorUnLocked.text = "D Minor UL: " + CurrentGameData.ThisGameData.DMinorScaleUnLocked.ToString();
		lblEMinorUnLocked.text = "E Minor UL: " + CurrentGameData.ThisGameData.EMinorScaleUnLocked.ToString();
		lblFMinorUnLocked.text = "F Minor UL: " + CurrentGameData.ThisGameData.FMinorScaleUnLocked.ToString();
		lblGMinorUnLocked.text = "G Minor UL: " + CurrentGameData.ThisGameData.GMinorScaleUnLocked.ToString();
		lblAMinorUnLocked.text = "A Minor UL: " + CurrentGameData.ThisGameData.AMinorScaleUnLocked.ToString();
		lblBMinorUnLocked.text = "B Minor UL: " + CurrentGameData.ThisGameData.BMinorScaleUnLocked.ToString();

		//Current Level Variables

		if (!CommonUtils.IsStringEmpty (CurrentGameData.ThisGameData.CurrentLevelSelected)) {
			lblCurrentLevelSelected.text = "Level Selected: " + CurrentGameData.ThisGameData.CurrentLevelSelected;
		} else {
			lblCurrentLevelSelected.text = "{empty}";
		}

		if (!CommonUtils.IsStringEmpty (CurrentGameData.ThisGameData.CurrentScaleSelected)) {
			lblCurrentScaleSelected.text = "Scale Selected: " + CurrentGameData.ThisGameData.CurrentScaleSelected;
		} else {
			lblCurrentScaleSelected.text = "{empty}";
		}
			
		lblCurrentLevelScore.text = "Level Score: " + CurrentGameData.ThisGameData.CurrentLevelScore.ToString();
		lblCurrentLevelCorrect.text = "Level Correct: " + CurrentGameData.ThisGameData.CurrentLevelCorrect.ToString();
		lblCurrentLevelMissed.text = "Level Missed: " + CurrentGameData.ThisGameData.CurrentLevelMissed.ToString();
		lblCurrentLevelStars.text = "Level Stars: " + CurrentGameData.ThisGameData.CurrentLevelStars.ToString ();
		lblCurrentLevelTimeBonus.text = "Level Time Bonus: " + CurrentGameData.ThisGameData.CurrentLevelTimeBonus.ToString ();
		lblCurrentLevelTotalStar.text = "Total Star: " + CurrentGameData.ThisGameData.CurrentLevelCompleteStarTotalScore.ToString();
		lblCurrentLevelTotalTime.text = "Total Time: " + CurrentGameData.ThisGameData.CurrentLevelCompleteTimeTotalScore.ToString();
		lblCurrentLevelTotalItem.text = "Total Item: " + CurrentGameData.ThisGameData.CurrentLevelCompleteItemTotalScore.ToString();
		lblCurrentLevelGrandTotal.text = "Grand Total; " + CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore.ToString ();

		lblAppVersion.text = CurrentGameData.ThisGameData.ApplicationVersionNumber;
		
	}

	public void btnClicked(string param) {

		if (param == "Back") {
			SceneManager.LoadScene ("LevelTitle");
		} else {
			//Delete Game Data
			SaveFactory.DeleteGameData ();
			//Recreate it
			SaveFactory.GetGameData();
			SceneManager.LoadScene ("DevScene");
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
