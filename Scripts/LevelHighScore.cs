using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Linq;
using UnityEngine.SocialPlatforms;


//http://www.pianoscales.org/major.html
//http://www.pianoscales.org/minor.html

//Key Signatures
//http://musictheoryisyourfriend.com/what-are-key-signatures/


public class LevelHighScore : MonoBehaviour
{

	public Text lblRootNote;
	public Text lblScaleType;
	public Text lblLocked;
	public Text lblHighScore;
	public Text lblPickupItem;
	public Image imgReward;
	public Image imgStar1;
	public Image imgStar2;
	public Image imgStar3;
	public Image imgStar4;
	public Image imgStar5;

	//Major Icons
	public Image imgPickupBanana;
	public Image imgPickupMushroom;
	public Image imgPickupCoin;
	public Image imgPickupLamp;
	public Image imgPickupApple;
	public Image imgPickupBabyBird;
	public Image imgPickupPear;

	//Minor Icons
	public Image imgPickupBananaMinor;
	public Image imgPickupMushroomMinor;
	public Image imgPickupCoinMinor;
	public Image imgPickupLampMinor;
	public Image imgPickupAppleMinor;
	public Image imgPickupBabyBirdMinor;
	public Image imgPickupPearMinor;

	public Button btnLeft;
	public Button btnRight;
	public Button btnMainMenu;

	public Image imgUser;
	public Text txtUser;
	public Button btnGPGS;
	public Image imgGPGS;


	public int CurrentLevelSelected = 1;

	const int CMajorID = 1;
	const int DMajorID = 2;
	const int EMajorID = 3;
	const int FMajorID = 4;
	const int GMajorID = 5;
	const int AMajorID = 6;
	const int BMajorID = 7;
	const int CMinorID = 8;
	const int DMinorID = 9;
	const int EMinorID = 10;
	const int FMinorID = 11;
	const int GMinorID = 12;
	const int AMinorID = 13;
	const int BMinorID = 14;





	// Use this for initialization
	void Start ()
	{
		
		ShowLoginDetails (false);
		
		CurrentLevelSelected = 1;
		btnLeft.gameObject.SetActive (false);
		SaveFactory.GetGameData ();
		HideObjects ();
		ShowScaleLevelData ();

	}
				

	void HideObjects() {

		lblLocked.gameObject.SetActive (false);
		imgStar1.gameObject.SetActive (false);
		imgStar2.gameObject.SetActive (false);
		imgStar3.gameObject.SetActive (false);
		imgStar4.gameObject.SetActive (false);
		imgStar5.gameObject.SetActive (false);
		imgPickupBanana.gameObject.SetActive (false);
		imgPickupMushroom.gameObject.SetActive (false);
		imgPickupCoin.gameObject.SetActive (false);
		imgPickupLamp.gameObject.SetActive (false);
		imgPickupApple.gameObject.SetActive (false);
		imgPickupBabyBird.gameObject.SetActive (false);
		imgPickupPear.gameObject.SetActive (false);
		imgPickupBananaMinor.gameObject.SetActive (false);
		imgPickupMushroomMinor.gameObject.SetActive (false);
		imgPickupCoinMinor.gameObject.SetActive (false);
		imgPickupLampMinor.gameObject.SetActive (false);
		imgPickupAppleMinor.gameObject.SetActive (false);
		imgPickupBabyBirdMinor.gameObject.SetActive (false);
		imgPickupPearMinor.gameObject.SetActive (false);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{ 
			SceneManager.LoadScene ("LevelScaleSelect");
		}
	}

	void ShowLoginDetails(bool show) {	
		
		imgUser.gameObject.SetActive (show);
		txtUser.gameObject.SetActive (show);
		btnGPGS.gameObject.SetActive (show);
		imgGPGS.gameObject.SetActive (show);
	}
		
	void SetCurrentLevelLeft() {
		if (CurrentLevelSelected > 1) {
			CurrentLevelSelected -= 1;
			btnLeft.gameObject.SetActive (true);
		} else {
			btnLeft.gameObject.SetActive (false);
		}

		if (CurrentLevelSelected < 14) {
			btnRight.gameObject.SetActive (true);
		}

		if (CurrentLevelSelected == 1) {
			btnLeft.gameObject.SetActive (false);
		}
	}

	void SetCurrentLevelRight() {
		if (CurrentLevelSelected <= 14) 
		{
			CurrentLevelSelected += 1;
			btnRight.gameObject.SetActive (true);
		}

		if (CurrentLevelSelected == 14) {
			btnRight.gameObject.SetActive (false);
		}

		if (CurrentLevelSelected > 1) {
			btnLeft.gameObject.SetActive (true);
		}
	}

	private string FormatHighScore(string HighScore, bool UnLocked) {
		
		int intHighScore = System.Convert.ToInt32(HighScore);

		if (!UnLocked) {
			return "Level Locked";
		}

		if (intHighScore > 0) {
			return HighScore;
		}

		if (UnLocked) {			
			return "No Score Data";
		} 


		return "?";
	}


	public int GetPickUpItemsBasedOnScore(int ScoreVal) {

		if (ScoreVal > 0) {
				return ScoreVal / ScoreFactory.pickUpItemBonusPoints;
		} else {
			return 0;
		}
	}

	public int GetStarsCount(int ScoreVal) {
		if (ScoreVal > 0) {
			return ScoreVal / ScoreFactory.starBonusPoints;
		} else {
			return 0;
		}

	}


	void ShowScaleLevelData() {
		switch (CurrentLevelSelected) {
		case CMajorID:			
			lblRootNote.text = "C";
			lblScaleType.text = "Major Scale";
			lblHighScore.text = FormatHighScore (CurrentGameData.ThisGameData.CMajorHighScore.ToString (),
				CurrentGameData.ThisGameData.CMajorScaleUnLocked);
			ShowStars (GetStarsCount(CurrentGameData.ThisGameData.CMajorHighScoreStars));
			ShowLocked (CurrentGameData.ThisGameData.CMajorScaleUnLocked); 
			imgPickupBanana.gameObject.SetActive (true);
			imgPickupMushroom.gameObject.SetActive (false);
			imgPickupCoin.gameObject.SetActive (false);
			imgPickupLamp.gameObject.SetActive (false);
			imgPickupApple.gameObject.SetActive (false);
			imgPickupBabyBird.gameObject.SetActive (false);
			imgPickupPear.gameObject.SetActive (false);
			imgPickupBananaMinor.gameObject.SetActive (false);
			imgPickupMushroomMinor.gameObject.SetActive (false);
			imgPickupCoinMinor.gameObject.SetActive (false);
			imgPickupLampMinor.gameObject.SetActive (false);
			imgPickupAppleMinor.gameObject.SetActive (false);
			imgPickupBabyBirdMinor.gameObject.SetActive (false);
			imgPickupPearMinor.gameObject.SetActive (false);

			lblPickupItem.text = "x " + GetPickUpItemsBasedOnScore(CurrentGameData.ThisGameData.CMajorHighScoreItems);
			break;
		case DMajorID:
			lblRootNote.text = "D";
			lblScaleType.text = "Major Scale";
			lblHighScore.text = FormatHighScore(CurrentGameData.ThisGameData.DMajorHighScore.ToString(),
				CurrentGameData.ThisGameData.DMajorScaleUnLocked);
			ShowStars (GetStarsCount(CurrentGameData.ThisGameData.DMajorHighScoreStars));
			ShowLocked (CurrentGameData.ThisGameData.DMajorScaleUnLocked); 
			imgPickupMushroom.gameObject.SetActive (true);
			imgPickupBanana.gameObject.SetActive (false);
			imgPickupCoin.gameObject.SetActive (false);
			imgPickupLamp.gameObject.SetActive (false);
			imgPickupApple.gameObject.SetActive (false);
			imgPickupBabyBird.gameObject.SetActive (false);
			imgPickupPear.gameObject.SetActive (false);
			imgPickupBananaMinor.gameObject.SetActive (false);
			imgPickupMushroomMinor.gameObject.SetActive (false);
			imgPickupCoinMinor.gameObject.SetActive (false);
			imgPickupLampMinor.gameObject.SetActive (false);
			imgPickupAppleMinor.gameObject.SetActive (false);
			imgPickupBabyBirdMinor.gameObject.SetActive (false);
			imgPickupPearMinor.gameObject.SetActive (false);

			lblPickupItem.text = "x " + GetPickUpItemsBasedOnScore(CurrentGameData.ThisGameData.DMajorHighScoreItems);
			break;
		case EMajorID:
			lblRootNote.text = "E";
			lblScaleType.text = "Major Scale";
			lblHighScore.text = FormatHighScore(CurrentGameData.ThisGameData.EMajorHighScore.ToString(),
				CurrentGameData.ThisGameData.EMajorScaleUnLocked);
			ShowStars (GetStarsCount(CurrentGameData.ThisGameData.EMajorHighScoreStars));
			ShowLocked (CurrentGameData.ThisGameData.EMajorScaleUnLocked); 
			imgPickupCoin.gameObject.SetActive (true);
			imgPickupBanana.gameObject.SetActive (false);
			imgPickupMushroom.gameObject.SetActive (false);		
			imgPickupLamp.gameObject.SetActive (false);
			imgPickupApple.gameObject.SetActive (false);
			imgPickupBabyBird.gameObject.SetActive (false);
			imgPickupPear.gameObject.SetActive (false);
			imgPickupBananaMinor.gameObject.SetActive (false);
			imgPickupMushroomMinor.gameObject.SetActive (false);
			imgPickupCoinMinor.gameObject.SetActive (false);
			imgPickupLampMinor.gameObject.SetActive (false);
			imgPickupAppleMinor.gameObject.SetActive (false);
			imgPickupBabyBirdMinor.gameObject.SetActive (false);
			imgPickupPearMinor.gameObject.SetActive (false);
			lblPickupItem.text = "x " + GetPickUpItemsBasedOnScore(CurrentGameData.ThisGameData.EMajorHighScoreItems);
			break;
		case FMajorID:
			lblRootNote.text = "F";
			lblScaleType.text = "Major Scale";
			lblHighScore.text = FormatHighScore(CurrentGameData.ThisGameData.FMajorHighScore.ToString(),
				CurrentGameData.ThisGameData.FMajorScaleUnLocked);
			ShowStars (GetStarsCount(CurrentGameData.ThisGameData.FMajorHighScoreStars));
			ShowLocked (CurrentGameData.ThisGameData.FMajorScaleUnLocked); 
			imgPickupLamp.gameObject.SetActive (true);
			imgPickupCoin.gameObject.SetActive (false);
			imgPickupBanana.gameObject.SetActive (false);
			imgPickupMushroom.gameObject.SetActive (false);		
			imgPickupApple.gameObject.SetActive (false);
			imgPickupBabyBird.gameObject.SetActive (false);
			imgPickupPear.gameObject.SetActive (false);
			imgPickupBananaMinor.gameObject.SetActive (false);
			imgPickupMushroomMinor.gameObject.SetActive (false);
			imgPickupCoinMinor.gameObject.SetActive (false);
			imgPickupLampMinor.gameObject.SetActive (false);
			imgPickupAppleMinor.gameObject.SetActive (false);
			imgPickupBabyBirdMinor.gameObject.SetActive (false);
			imgPickupPearMinor.gameObject.SetActive (false);
			lblPickupItem.text = "x " + GetPickUpItemsBasedOnScore(CurrentGameData.ThisGameData.FMajorHighScoreItems);
			break;
		case GMajorID:
			lblRootNote.text = "G";
			lblScaleType.text = "Major Scale";
			lblHighScore.text = FormatHighScore(CurrentGameData.ThisGameData.GMajorHighScore.ToString(),
				CurrentGameData.ThisGameData.GMajorScaleUnLocked);
			ShowStars (GetStarsCount(CurrentGameData.ThisGameData.GMajorHighScoreStars));
			ShowLocked (CurrentGameData.ThisGameData.GMajorScaleUnLocked); 
			imgPickupApple.gameObject.SetActive (true);
			imgPickupLamp.gameObject.SetActive (false);
			imgPickupCoin.gameObject.SetActive (false);
			imgPickupBanana.gameObject.SetActive (false);
			imgPickupMushroom.gameObject.SetActive (false);	
			imgPickupBabyBird.gameObject.SetActive (false);
			imgPickupPear.gameObject.SetActive (false);
			imgPickupBananaMinor.gameObject.SetActive (false);
			imgPickupMushroomMinor.gameObject.SetActive (false);
			imgPickupCoinMinor.gameObject.SetActive (false);
			imgPickupLampMinor.gameObject.SetActive (false);
			imgPickupAppleMinor.gameObject.SetActive (false);
			imgPickupBabyBirdMinor.gameObject.SetActive (false);
			imgPickupPearMinor.gameObject.SetActive (false);
			lblPickupItem.text = "x " + GetPickUpItemsBasedOnScore(CurrentGameData.ThisGameData.GMajorHighScoreItems);
			break;
		case AMajorID:
			lblRootNote.text = "A";
			lblScaleType.text = "Major Scale";
			lblHighScore.text = FormatHighScore(CurrentGameData.ThisGameData.AMajorHighScore.ToString(),
				CurrentGameData.ThisGameData.AMajorScaleUnLocked);
			ShowStars (GetStarsCount(CurrentGameData.ThisGameData.AMajorHighScoreStars));
			ShowLocked (CurrentGameData.ThisGameData.AMajorScaleUnLocked); 
			imgPickupBabyBird.gameObject.SetActive (true);
			imgPickupApple.gameObject.SetActive (false);
			imgPickupLamp.gameObject.SetActive (false);
			imgPickupCoin.gameObject.SetActive (false);
			imgPickupBanana.gameObject.SetActive (false);
			imgPickupMushroom.gameObject.SetActive (false);	
			imgPickupPear.gameObject.SetActive (false);
			imgPickupBananaMinor.gameObject.SetActive (false);
			imgPickupMushroomMinor.gameObject.SetActive (false);
			imgPickupCoinMinor.gameObject.SetActive (false);
			imgPickupLampMinor.gameObject.SetActive (false);
			imgPickupAppleMinor.gameObject.SetActive (false);
			imgPickupBabyBirdMinor.gameObject.SetActive (false);
			imgPickupPearMinor.gameObject.SetActive (false);
			lblPickupItem.text = "x " + GetPickUpItemsBasedOnScore(CurrentGameData.ThisGameData.AMajorHighScoreItems);
			break;
		case BMajorID:
			lblRootNote.text = "B";
			lblScaleType.text = "Major Scale";
			lblHighScore.text = FormatHighScore(CurrentGameData.ThisGameData.BMajorHighScore.ToString(),
				CurrentGameData.ThisGameData.BMajorScaleUnLocked);
			ShowStars (GetStarsCount(CurrentGameData.ThisGameData.BMajorHighScoreStars));
			ShowLocked (CurrentGameData.ThisGameData.BMajorScaleUnLocked); 
			imgPickupPear.gameObject.SetActive (true);
			imgPickupBabyBird.gameObject.SetActive (false);
			imgPickupApple.gameObject.SetActive (false);
			imgPickupLamp.gameObject.SetActive (false);
			imgPickupCoin.gameObject.SetActive (false);
			imgPickupBanana.gameObject.SetActive (false);
			imgPickupMushroom.gameObject.SetActive (false);
			imgPickupBananaMinor.gameObject.SetActive (false);
			imgPickupMushroomMinor.gameObject.SetActive (false);
			imgPickupCoinMinor.gameObject.SetActive (false);
			imgPickupLampMinor.gameObject.SetActive (false);
			imgPickupAppleMinor.gameObject.SetActive (false);
			imgPickupBabyBirdMinor.gameObject.SetActive (false);
			imgPickupPearMinor.gameObject.SetActive (false);
			lblPickupItem.text = "x " + GetPickUpItemsBasedOnScore(CurrentGameData.ThisGameData.BMajorHighScoreItems);
			break;
		case CMinorID:
			lblRootNote.text = "C";
			lblScaleType.text = "Minor Scale";
			lblHighScore.text = FormatHighScore(CurrentGameData.ThisGameData.CMinorHighScore.ToString(),
				CurrentGameData.ThisGameData.CMinorScaleUnLocked);
			ShowStars (GetStarsCount(CurrentGameData.ThisGameData.CMinorHighScoreStars));
			ShowLocked (CurrentGameData.ThisGameData.CMinorScaleUnLocked);
			imgPickupPear.gameObject.SetActive (false);
			imgPickupBabyBird.gameObject.SetActive (false);
			imgPickupApple.gameObject.SetActive (false);
			imgPickupLamp.gameObject.SetActive (false);
			imgPickupCoin.gameObject.SetActive (false);
			imgPickupBanana.gameObject.SetActive (false);
			imgPickupMushroom.gameObject.SetActive (false);
			imgPickupBananaMinor.gameObject.SetActive (true);
			imgPickupMushroomMinor.gameObject.SetActive (false);
			imgPickupCoinMinor.gameObject.SetActive (false);
			imgPickupLampMinor.gameObject.SetActive (false);
			imgPickupAppleMinor.gameObject.SetActive (false);
			imgPickupBabyBirdMinor.gameObject.SetActive (false);
			imgPickupPearMinor.gameObject.SetActive (false);
			lblPickupItem.text = "x " + GetPickUpItemsBasedOnScore(CurrentGameData.ThisGameData.CMinorHighScoreItems);
			break;
		case DMinorID:
			lblRootNote.text = "D";
			lblScaleType.text = "Minor Scale";
			lblHighScore.text = FormatHighScore(CurrentGameData.ThisGameData.DMinorHighScore.ToString(),
				CurrentGameData.ThisGameData.DMinorScaleUnLocked);
			ShowStars(GetStarsCount(CurrentGameData.ThisGameData.DMinorHighScoreStars));
			ShowLocked (CurrentGameData.ThisGameData.DMinorScaleUnLocked); 
			imgPickupPear.gameObject.SetActive (false);
			imgPickupBabyBird.gameObject.SetActive (false);
			imgPickupApple.gameObject.SetActive (false);
			imgPickupLamp.gameObject.SetActive (false);
			imgPickupCoin.gameObject.SetActive (false);
			imgPickupBanana.gameObject.SetActive (false);
			imgPickupMushroom.gameObject.SetActive (false);
			imgPickupBananaMinor.gameObject.SetActive (false);
			imgPickupMushroomMinor.gameObject.SetActive (true);
			imgPickupCoinMinor.gameObject.SetActive (false);
			imgPickupLampMinor.gameObject.SetActive (false);
			imgPickupAppleMinor.gameObject.SetActive (false);
			imgPickupBabyBirdMinor.gameObject.SetActive (false);
			imgPickupPearMinor.gameObject.SetActive (false);
			lblPickupItem.text = "x " + GetPickUpItemsBasedOnScore(CurrentGameData.ThisGameData.DMinorHighScoreItems);
			break;
		case EMinorID:	
			lblRootNote.text = "E";
			lblScaleType.text = "Minor Scale";
			lblHighScore.text = FormatHighScore(CurrentGameData.ThisGameData.EMinorHighScore.ToString(),
				CurrentGameData.ThisGameData.EMinorScaleUnLocked);
			ShowStars (GetStarsCount(CurrentGameData.ThisGameData.EMinorHighScoreStars));
			ShowLocked (CurrentGameData.ThisGameData.EMinorScaleUnLocked); 
			imgPickupPear.gameObject.SetActive (false);
			imgPickupBabyBird.gameObject.SetActive (false);
			imgPickupApple.gameObject.SetActive (false);
			imgPickupLamp.gameObject.SetActive (false);
			imgPickupCoin.gameObject.SetActive (true);
			imgPickupBanana.gameObject.SetActive (false);
			imgPickupMushroom.gameObject.SetActive (false);
			imgPickupBananaMinor.gameObject.SetActive (false);
			imgPickupMushroomMinor.gameObject.SetActive (false);
			imgPickupCoinMinor.gameObject.SetActive (true);
			imgPickupLampMinor.gameObject.SetActive (false);
			imgPickupAppleMinor.gameObject.SetActive (false);
			imgPickupBabyBirdMinor.gameObject.SetActive (false);
			imgPickupPearMinor.gameObject.SetActive (false);
			lblPickupItem.text = "x " + GetPickUpItemsBasedOnScore(CurrentGameData.ThisGameData.EMinorHighScoreItems);
			break;
		case FMinorID:
			lblRootNote.text = "F";
			lblScaleType.text = "Minor Scale";
			lblHighScore.text = FormatHighScore(CurrentGameData.ThisGameData.FMinorHighScore.ToString(),
				CurrentGameData.ThisGameData.FMinorScaleUnLocked);
			ShowStars (GetStarsCount(CurrentGameData.ThisGameData.FMinorHighScoreStars));
			ShowLocked (CurrentGameData.ThisGameData.FMinorScaleUnLocked); 
			imgPickupPear.gameObject.SetActive (false);
			imgPickupBabyBird.gameObject.SetActive (false);
			imgPickupApple.gameObject.SetActive (false);
			imgPickupLamp.gameObject.SetActive (false);
			imgPickupCoin.gameObject.SetActive (false);
			imgPickupBanana.gameObject.SetActive (false);
			imgPickupMushroom.gameObject.SetActive (false);
			imgPickupBananaMinor.gameObject.SetActive (false);
			imgPickupMushroomMinor.gameObject.SetActive (false);
			imgPickupCoinMinor.gameObject.SetActive (false);
			imgPickupLampMinor.gameObject.SetActive (true);
			imgPickupAppleMinor.gameObject.SetActive (false);
			imgPickupBabyBirdMinor.gameObject.SetActive (false);
			imgPickupPearMinor.gameObject.SetActive (false);
			lblPickupItem.text = "x " + GetPickUpItemsBasedOnScore(CurrentGameData.ThisGameData.FMinorHighScoreItems);
			break;
		case GMinorID:
			lblRootNote.text = "G";
			lblScaleType.text = "Minor Scale";
			lblHighScore.text = FormatHighScore(CurrentGameData.ThisGameData.GMinorHighScore.ToString(),
				CurrentGameData.ThisGameData.GMinorScaleUnLocked);
			ShowStars (GetStarsCount(CurrentGameData.ThisGameData.GMinorHighScoreStars));
			ShowLocked (CurrentGameData.ThisGameData.GMinorScaleUnLocked); 
			imgPickupPear.gameObject.SetActive (false);
			imgPickupBabyBird.gameObject.SetActive (false);
			imgPickupApple.gameObject.SetActive (false);
			imgPickupLamp.gameObject.SetActive (false);
			imgPickupCoin.gameObject.SetActive (false);
			imgPickupBanana.gameObject.SetActive (false);
			imgPickupMushroom.gameObject.SetActive (false);
			imgPickupBananaMinor.gameObject.SetActive (false);
			imgPickupMushroomMinor.gameObject.SetActive (false);
			imgPickupCoinMinor.gameObject.SetActive (false);
			imgPickupLampMinor.gameObject.SetActive (false);
			imgPickupAppleMinor.gameObject.SetActive (true);
			imgPickupBabyBirdMinor.gameObject.SetActive (false);
			imgPickupPearMinor.gameObject.SetActive (false);
			lblPickupItem.text = "x " + GetPickUpItemsBasedOnScore(CurrentGameData.ThisGameData.GMinorHighScoreItems);
			break;
		case AMinorID:
			lblRootNote.text = "A";
			lblScaleType.text = "Minor Scale";
			lblHighScore.text = FormatHighScore(CurrentGameData.ThisGameData.AMinorHighScore.ToString(),
				CurrentGameData.ThisGameData.AMinorScaleUnLocked);
			ShowStars (GetStarsCount(CurrentGameData.ThisGameData.AMinorHighScoreStars));
			ShowLocked (CurrentGameData.ThisGameData.AMinorScaleUnLocked); 
			imgPickupPear.gameObject.SetActive (false);
			imgPickupBabyBird.gameObject.SetActive (false);
			imgPickupApple.gameObject.SetActive (false);
			imgPickupLamp.gameObject.SetActive (false);
			imgPickupCoin.gameObject.SetActive (false);
			imgPickupBanana.gameObject.SetActive (false);
			imgPickupMushroom.gameObject.SetActive (false);
			imgPickupBananaMinor.gameObject.SetActive (false);
			imgPickupMushroomMinor.gameObject.SetActive (false);
			imgPickupCoinMinor.gameObject.SetActive (false);
			imgPickupLampMinor.gameObject.SetActive (false);
			imgPickupAppleMinor.gameObject.SetActive (false);
			imgPickupBabyBirdMinor.gameObject.SetActive (true);
			imgPickupPearMinor.gameObject.SetActive (false);
			lblPickupItem.text = "x " + GetPickUpItemsBasedOnScore(CurrentGameData.ThisGameData.AMinorHighScoreItems);
			break;
		case BMinorID:
			lblRootNote.text = "B";
			lblScaleType.text = "Minor Scale";
			lblHighScore.text = FormatHighScore(CurrentGameData.ThisGameData.BMinorHighScore.ToString(),
				CurrentGameData.ThisGameData.BMinorScaleUnLocked);
			ShowStars (GetStarsCount(CurrentGameData.ThisGameData.BMinorHighScoreStars));
			ShowLocked (CurrentGameData.ThisGameData.BMinorScaleUnLocked); 
			imgPickupPear.gameObject.SetActive (false);
			imgPickupBabyBird.gameObject.SetActive (false);
			imgPickupApple.gameObject.SetActive (false);
			imgPickupLamp.gameObject.SetActive (false);
			imgPickupCoin.gameObject.SetActive (false);
			imgPickupBanana.gameObject.SetActive (false);
			imgPickupMushroom.gameObject.SetActive (false);
			imgPickupBananaMinor.gameObject.SetActive (false);
			imgPickupMushroomMinor.gameObject.SetActive (false);
			imgPickupCoinMinor.gameObject.SetActive (false);
			imgPickupLampMinor.gameObject.SetActive (false);
			imgPickupAppleMinor.gameObject.SetActive (false);
			imgPickupBabyBirdMinor.gameObject.SetActive (false);
			imgPickupPearMinor.gameObject.SetActive (true);
			lblPickupItem.text = "x " + GetPickUpItemsBasedOnScore(CurrentGameData.ThisGameData.BMinorHighScoreItems);
			break;
		}
	}

	public void ShowLocked(bool Val) {
		if (Val) {
			lblLocked.gameObject.SetActive (false);
			lblHighScore.gameObject.SetActive (true);
		}
		else {
			lblLocked.gameObject.SetActive (true);
		}

	}

	public void ShowStars (int TotalStars) {
		HideObjects();

		if (TotalStars == 0) {
			return;
		}

		switch (TotalStars) {
		case 5: 
			imgStar1.gameObject.SetActive (true);
			imgStar2.gameObject.SetActive (true);
			imgStar3.gameObject.SetActive (true);
			imgStar4.gameObject.SetActive (true);
			imgStar5.gameObject.SetActive (true);
			break;
		case 4:
			imgStar1.gameObject.SetActive (true);
			imgStar2.gameObject.SetActive (true);
			imgStar3.gameObject.SetActive (true);
			imgStar4.gameObject.SetActive (true);
			break;
		case 3:
			imgStar1.gameObject.SetActive (true);
			imgStar2.gameObject.SetActive (true);
			imgStar3.gameObject.SetActive (true);
			break;
		case 2:
			imgStar1.gameObject.SetActive (true);
			imgStar2.gameObject.SetActive (true);
			break;
		case 1:
			imgStar1.gameObject.SetActive (true);
			break;
		}


	}

	public void btnClicked(string param)
	{
		//Remember when you are wiring up the button onClick from the Unity
		//make sure to select click event from the scene tab. On the scene
		//tab select level, next choose level script --> btnClicked

		if (param == "Menu") {
			SceneManager.LoadScene ("LevelScaleSelect");
		}
		else if (param == "GPGS") {
			SaveFactory.GetGameData ();
			CurrentGameData.ThisGameData.CurrentScaleSelected = "HS";
			SaveFactory.SaveGameData ();
			SceneManager.LoadScene ("PleaseWait");
		}
		else {
			Navigate (param);
			ShowScaleLevelData ();
		}

			


	}

	private void Navigate(string param) {
		if (param == "MoveLeft") 
		{
			SetCurrentLevelLeft ();
		}
		else if (param=="MoveRight") 
		{
			SetCurrentLevelRight();
		}

		ShowScaleLevelData ();

	}




}

