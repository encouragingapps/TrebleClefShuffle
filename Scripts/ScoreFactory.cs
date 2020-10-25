using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class ScoreFactory
{
	//Static variables allow us to use
	//this variable anywhere in the game.
	//We could use static but for this class
	//we will have the Level SCript instantiate 
	//the class

	//Save Sample
	//SaveFactory saveThis = new SaveFactory ();
	//GameSaveData thisGameData = new GameSaveData ();
	//thisGameData.CurrentLevelScore = myScore.CurrentScore;
	//saveThis.Save (thisGameData);

	public int CurrentScore {get; set;}
	public int CurrentMissed {get; set;} 
	public int CurrentCorrect { get; set;}
	public int CurrentComboCount { get; set; }
	public int CurrentStars { get; set; }
	public int CurrentTimeBonus { get; set; }
	public int CurrentItemsCollected { get; set; }
	public int MaximumQuestions { get; set;}
	public int QuestionsAnswered { get; set; }


	public const int NumberOfQuestions = 40;
	public const int NumberOfStars = 5;
	public const int standardPoints = 1000;
	public const int starBonusPoints = 2500;
	public const int pickUpItemBonusPoints = 3000;
	public const int timeBonusPoints = 5;  //(TimeLeft * timeBonusPoints)
	public const int MaximumNumberOfItems = 4;
	public const int MaximumComboTrackerCount = 10;

	//Percentage that has to be correct in order for the
	//star to appear.
	const int Star5AvailablePercentage = 90;
	const int Star4AvailablePercentage = 80;
	const int Star3AvailablePercentage = 60;
	const int Star2AvailablePercentage = 50;
	const int Star1AvailablePercentage = 40;

	public void SetPointVal(eScoringPointType ScoreType) {
		CurrentScore += standardPoints * CurrentComboCount;
	}

	//This function will display text plus the combo
	public string GetPointsValueText() {
		if (CurrentComboCount > 1) {
			return standardPoints.ToString () + " x" + CurrentComboCount + " Combo";
		} else {
			return standardPoints.ToString ();
		}

	}
		
	public bool Star5Available() {
		int Calc = GetPercent();
		if (Calc > Star5AvailablePercentage) { CurrentStars = 5; return true;} else { return false;}
	}

	public bool Star4Available() {
		int Calc = GetPercent();
		if (Calc > Star4AvailablePercentage) { CurrentStars = 4; return true;} else { return false;}
	}

	public bool Star3Available() {
		int Calc = GetPercent();
		if (Calc > Star3AvailablePercentage) { CurrentStars = 3; return true;} else { return false;}
	}

	public bool Star2Available() {
		int Calc = GetPercent();
		if (Calc > Star2AvailablePercentage) { CurrentStars = 2; return true;} else { return false;}
	}

	public bool Star1Available() {
		int Calc = GetPercent();
		if (Calc > Star1AvailablePercentage) { CurrentStars = 1; return true;} else { return false;}
	}

	public bool Star0Available() {
		int Calc = GetPercent ();
		if (Calc < Star1AvailablePercentage) { CurrentStars = 0; return true;} else { return false;}
	}

	private int GetPercent() {
		float Calc;
		int Output;
		Calc = MaximumQuestions - CurrentMissed;
		Calc = Calc / MaximumQuestions;
		Calc = Calc * 100;
		Output = (int) Calc;
		return Output;
	}

	public bool DisplayItem() {

		//Make sure to show the pickup item around 5 times

		int QuestionsLeft = ((MaximumQuestions) - (CurrentCorrect + CurrentMissed));

		if (QuestionsLeft < 10) 
		{
			if (QuestionsLeft == 7) {
				return true;
			} else {
				return false;
			}
		}

		if (QuestionsLeft == (MaximumQuestions - 7)) {
			return true;
		}

		//Every 10th question we will display the pick up item
		if (CommonUtils.IsEveryNthLine (10, QuestionsLeft)) 
		{
			if (QuestionsLeft == MaximumQuestions) {
				return false;
			} else {
				return true;
			}
		}
		else 
		{
				return false;
		}
	}


	public void SetMissed() {
		CurrentMissed += 1;
		//Reset combo count
		CurrentComboCount = 1;
	}

	public void SetCorrect() {
		CurrentCorrect += 1;
		//Only allow combos up to the Maximum
		if (CurrentComboCount > MaximumComboTrackerCount) {
			CurrentComboCount = 1;
		}
		else {
			CurrentComboCount += 1;
		}
			

	}

	public string GetScore() {
		return "Score: " + CurrentScore.ToString().PadLeft(6,'0');
	}

	public string GetAccuracyTotal() {
		return "Correct: " + CurrentCorrect.ToString ().PadLeft (3, '0') + " / " + "Missed: " + CurrentMissed.ToString ().PadLeft (3, '0');
	}

	public void SaveScore(string CurrentLevel) {

		SaveFactory.GetGameData ();

		CurrentGameData.ThisGameData.CurrentLevelCorrect = CurrentCorrect;
		CurrentGameData.ThisGameData.CurrentLevelMissed = CurrentMissed;
		CurrentGameData.ThisGameData.CurrentLevelScore = CurrentScore;
		CurrentGameData.ThisGameData.CurrentLevelStars = CurrentStars;
		CurrentGameData.ThisGameData.CurrentLevelTimeBonus = CurrentTimeBonus;

		CurrentGameData.ThisGameData.CurrentLevelCompleteStarTotalScore = (CurrentStars * starBonusPoints);
		CurrentGameData.ThisGameData.CurrentLevelCompleteTimeTotalScore = (CurrentTimeBonus * timeBonusPoints);
		CurrentGameData.ThisGameData.CurrentLevelCompleteItemTotalScore = (CurrentItemsCollected * pickUpItemBonusPoints);

		int TotalScore = 0;
		TotalScore = CurrentScore;
		TotalScore += CurrentGameData.ThisGameData.CurrentLevelCompleteStarTotalScore;
		TotalScore += CurrentGameData.ThisGameData.CurrentLevelCompleteTimeTotalScore;
		TotalScore += CurrentGameData.ThisGameData.CurrentLevelCompleteItemTotalScore;
		CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore = TotalScore;


		SaveFactory.SaveGameData();
			
	}

	public void SaveHighScore(string GameLevel) {

		SaveFactory.GetGameData ();

		switch (GameLevel) {
		case ConstScale.CMajorScale:
			
			if (SetHighScore (CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore,
				CurrentGameData.ThisGameData.CMajorHighScore)) {

				CurrentGameData.ThisGameData.CMajorHighScoreStars = 
				CurrentGameData.ThisGameData.CurrentLevelCompleteStarTotalScore;
				
				CurrentGameData.ThisGameData.CMajorHighScoreBonusTime = 
				CurrentGameData.ThisGameData.CurrentLevelCompleteTimeTotalScore;

				CurrentGameData.ThisGameData.CMajorHighScoreItems =
				CurrentGameData.ThisGameData.CurrentLevelCompleteItemTotalScore;
				
				CurrentGameData.ThisGameData.CMajorHighScore = 
				CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore;
				
			}
			break;
		case ConstScale.DMajorScale:
			if (SetHighScore (CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore,
				CurrentGameData.ThisGameData.DMajorHighScore)) {

				CurrentGameData.ThisGameData.DMajorHighScoreStars = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteStarTotalScore;

				CurrentGameData.ThisGameData.DMajorHighScoreBonusTime = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteTimeTotalScore;

				CurrentGameData.ThisGameData.DMajorHighScoreItems =
					CurrentGameData.ThisGameData.CurrentLevelCompleteItemTotalScore;

				CurrentGameData.ThisGameData.DMajorHighScore = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore;

			}
			break;
		case ConstScale.EMajorScale:
			if (SetHighScore (CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore,
				CurrentGameData.ThisGameData.EMajorHighScore)) {

				CurrentGameData.ThisGameData.EMajorHighScoreStars = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteStarTotalScore;

				CurrentGameData.ThisGameData.EMajorHighScoreBonusTime = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteTimeTotalScore;

				CurrentGameData.ThisGameData.EMajorHighScoreItems =
					CurrentGameData.ThisGameData.CurrentLevelCompleteItemTotalScore;

				CurrentGameData.ThisGameData.EMajorHighScore = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore;

			}	
			break;
		case ConstScale.FMajorScale:
			if (SetHighScore (CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore,
				CurrentGameData.ThisGameData.FMajorHighScore)) {

				CurrentGameData.ThisGameData.FMajorHighScoreStars = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteStarTotalScore;

				CurrentGameData.ThisGameData.FMajorHighScoreBonusTime = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteTimeTotalScore;

				CurrentGameData.ThisGameData.FMajorHighScoreItems =
					CurrentGameData.ThisGameData.CurrentLevelCompleteItemTotalScore;

				CurrentGameData.ThisGameData.FMajorHighScore = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore;

			}	
			break;
		case ConstScale.GMajorScale:
			if (SetHighScore (CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore,
				CurrentGameData.ThisGameData.GMajorHighScore)) {

				CurrentGameData.ThisGameData.GMajorHighScoreStars = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteStarTotalScore;

				CurrentGameData.ThisGameData.GMajorHighScoreBonusTime = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteTimeTotalScore;

				CurrentGameData.ThisGameData.GMajorHighScoreItems =
					CurrentGameData.ThisGameData.CurrentLevelCompleteItemTotalScore;

				CurrentGameData.ThisGameData.GMajorHighScore = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore;

			}		
			break;
		case ConstScale.AMajorScale:
			if (SetHighScore (CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore,
				CurrentGameData.ThisGameData.AMajorHighScore)) {

				CurrentGameData.ThisGameData.AMajorHighScoreStars = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteStarTotalScore;

				CurrentGameData.ThisGameData.AMajorHighScoreBonusTime = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteTimeTotalScore;

				CurrentGameData.ThisGameData.AMajorHighScoreItems =
					CurrentGameData.ThisGameData.CurrentLevelCompleteItemTotalScore;

				CurrentGameData.ThisGameData.AMajorHighScore = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore;

			}			
			break;
		case ConstScale.BMajorScale:
			if (SetHighScore (CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore,
				CurrentGameData.ThisGameData.BMajorHighScore)) {

				CurrentGameData.ThisGameData.BMajorHighScoreStars = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteStarTotalScore;

				CurrentGameData.ThisGameData.BMajorHighScoreBonusTime = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteTimeTotalScore;

				CurrentGameData.ThisGameData.BMajorHighScoreItems =
					CurrentGameData.ThisGameData.CurrentLevelCompleteItemTotalScore;

				CurrentGameData.ThisGameData.BMajorHighScore = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore;

			}				
			break;		
		case ConstScale.CMinorScale:
			if (SetHighScore (CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore,
				CurrentGameData.ThisGameData.CMinorHighScore)) {

				CurrentGameData.ThisGameData.CMinorHighScoreStars = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteStarTotalScore;

				CurrentGameData.ThisGameData.CMinorHighScoreBonusTime = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteTimeTotalScore;

				CurrentGameData.ThisGameData.CMinorHighScoreItems =
					CurrentGameData.ThisGameData.CurrentLevelCompleteItemTotalScore;

				CurrentGameData.ThisGameData.CMinorHighScore = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore;

			}				
			break;
		case ConstScale.DMinorScale:
			if (SetHighScore (CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore,
				CurrentGameData.ThisGameData.DMinorHighScore)) {

				CurrentGameData.ThisGameData.DMinorHighScoreStars = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteStarTotalScore;

				CurrentGameData.ThisGameData.DMinorHighScoreBonusTime = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteTimeTotalScore;

				CurrentGameData.ThisGameData.DMinorHighScoreItems =
					CurrentGameData.ThisGameData.CurrentLevelCompleteItemTotalScore;

				CurrentGameData.ThisGameData.DMinorHighScore = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore;

			}					
			break;
		case ConstScale.EMinorScale:
			if (SetHighScore (CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore,
				CurrentGameData.ThisGameData.EMinorHighScore)) {

				CurrentGameData.ThisGameData.EMinorHighScoreStars = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteStarTotalScore;

				CurrentGameData.ThisGameData.EMinorHighScoreBonusTime = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteTimeTotalScore;

				CurrentGameData.ThisGameData.EMinorHighScoreItems =
					CurrentGameData.ThisGameData.CurrentLevelCompleteItemTotalScore;

				CurrentGameData.ThisGameData.EMinorHighScore = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore;
			}				
			break;
		case ConstScale.FMinorScale:
			if (SetHighScore (CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore,
				CurrentGameData.ThisGameData.FMinorHighScore)) {

				CurrentGameData.ThisGameData.FMinorHighScoreStars = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteStarTotalScore;

				CurrentGameData.ThisGameData.FMinorHighScoreBonusTime = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteTimeTotalScore;

				CurrentGameData.ThisGameData.FMinorHighScoreItems =
					CurrentGameData.ThisGameData.CurrentLevelCompleteItemTotalScore;

				CurrentGameData.ThisGameData.FMinorHighScore = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore;

			}					
			break;
		case ConstScale.GMinorScale:
			if (SetHighScore (CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore,
				CurrentGameData.ThisGameData.GMinorHighScore)) {

				CurrentGameData.ThisGameData.GMinorHighScoreStars = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteStarTotalScore;

				CurrentGameData.ThisGameData.GMinorHighScoreBonusTime = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteTimeTotalScore;

				CurrentGameData.ThisGameData.GMinorHighScoreItems =
					CurrentGameData.ThisGameData.CurrentLevelCompleteItemTotalScore;

				CurrentGameData.ThisGameData.GMinorHighScore = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore;

			}						
			break;
		case ConstScale.AMinorScale:
			if (SetHighScore (CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore,
				CurrentGameData.ThisGameData.AMinorHighScore)) {

				CurrentGameData.ThisGameData.AMinorHighScoreStars = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteStarTotalScore;

				CurrentGameData.ThisGameData.AMinorHighScoreBonusTime = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteTimeTotalScore;

				CurrentGameData.ThisGameData.AMinorHighScoreItems =
					CurrentGameData.ThisGameData.CurrentLevelCompleteItemTotalScore;

				CurrentGameData.ThisGameData.AMinorHighScore = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore;

			}			
			break;
		case ConstScale.BMinorScale:
			if (SetHighScore (CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore,
				CurrentGameData.ThisGameData.BMinorHighScore)) {

				CurrentGameData.ThisGameData.BMinorHighScoreStars = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteStarTotalScore;

				CurrentGameData.ThisGameData.BMinorHighScoreBonusTime = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteTimeTotalScore;

				CurrentGameData.ThisGameData.BMinorHighScoreItems =
					CurrentGameData.ThisGameData.CurrentLevelCompleteItemTotalScore;

				CurrentGameData.ThisGameData.BMinorHighScore = 
					CurrentGameData.ThisGameData.CurrentLevelCompleteGrandTotalScore;

			}			
			break;
	}

		SaveFactory.SaveGameData();
			
	}


	public void SaveUnlockLevel(string GameLevel) {

		SaveFactory.GetGameData ();

		switch (GameLevel) {
		case ConstScale.CMajorScale:
			CurrentGameData.ThisGameData.DMajorScaleUnLocked = true; 
			break;
		case ConstScale.DMajorScale:
			CurrentGameData.ThisGameData.EMajorScaleUnLocked = true; 		
			break;
		case ConstScale.EMajorScale:
			CurrentGameData.ThisGameData.FMajorScaleUnLocked = true; 
			break;
		case ConstScale.FMajorScale:
			CurrentGameData.ThisGameData.GMajorScaleUnLocked = true;  
			break;
		case ConstScale.GMajorScale:
			CurrentGameData.ThisGameData.AMajorScaleUnLocked = true;  
			break;
		case ConstScale.AMajorScale:
			CurrentGameData.ThisGameData.BMajorScaleUnLocked = true;
			break;
		case ConstScale.CMinorScale:
			CurrentGameData.ThisGameData.DMinorScaleUnLocked = true;
			break;
		case ConstScale.DMinorScale:
			CurrentGameData.ThisGameData.EMinorScaleUnLocked = true;  
			break;
		case ConstScale.EMinorScale:
			CurrentGameData.ThisGameData.FMinorScaleUnLocked = true;  	
			break;
		case ConstScale.FMinorScale:
			CurrentGameData.ThisGameData.GMinorScaleUnLocked = true; 
			break;
		case ConstScale.GMinorScale:
			CurrentGameData.ThisGameData.AMinorScaleUnLocked = true;  	
			break;
		case ConstScale.AMinorScale:
			CurrentGameData.ThisGameData.BMinorScaleUnLocked = true;  	
			break;		
		}

		SaveFactory.SaveGameData();
	}


	private bool SetHighScore(int? CurrentScore, int? HighScore) {

		SaveFactory.GetGameData ();

		if (CurrentScore.Value > HighScore.Value) {
			CurrentGameData.ThisGameData.IsNewHighScore = true;
			SaveFactory.SaveGameData();
			return true;
		} else {
			return false;
		}

	}

}