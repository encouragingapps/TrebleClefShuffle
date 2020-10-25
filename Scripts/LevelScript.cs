using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using System.Collections;
using System.Linq;
using UnityEngine.SceneManagement;

//http://musictheorysite.com/major-scales/list-of-all-major-scales

//Your BitBucket Repository
//https://iortizvictory@bitbucket.org/iortizvictory/trebleclefshuffle.git

//Used to shuffle a list
public static class ArrayExtensions
{
	// This is an extension method. RandomItem() will now exist on all arrays.
	public static T RandomItem<T>(this T[] array)
	{
		return array[Random.Range(0, array.Length)];
	}
}

public class LevelScript : MonoBehaviour {

	//Session Data
	private string ThisSelectedLevel;

	static float defaultGameStartDuration = 3.0f;
	static float defaultAnsweredDuration = 2.0f;
	static float defaultGoQuestionDuration = 5.0f;
	static float defaultTimesUpDuration = 300.0f;
		
	public NoteFactory myNote = new NoteFactory();
	public ScoreFactory myScore = new ScoreFactory();

	//3D Player Object
	public GameObject player;
	//public Image playerSharp;
	//public Image playerFlat;

	//3D Ledger Lines
	public GameObject ELine;
	public GameObject GLine;
	public GameObject BLine;
	public GameObject DLine;
	public GameObject FLine;
	public GameObject MiddleCLine;
	public GameObject HighALine;
	public GameObject ThirdOctaveCLine;

	//3D Sharp Symbols
	public GameObject SharpF;
	public GameObject SharpC;
	public GameObject SharpG;
	public GameObject SharpD;
	public GameObject SharpA;

	//3D Flat Symbols
	public GameObject FlatB;
	public GameObject FlatE;
	public GameObject FlatA;
	public GameObject FlatD;

	//Items Collected
	public int ItemsCollected;

	//Debug Labels
	public Text lblAnswer; 
	public Text lblGuess;
	public Text lblGuessTimer;
	public Text lblMissTimer;
	public Text lblGameState;
	public Text lblTimerStart;
	public Text lblAnsweredTimer;
	public Text lblCountDown;

	//Game Labels
	public Text lblGameScore;
	public Text lblGameScoreAccuracy;
	public Text lblRemaining;
	public Text lblCurrentAnswer;
	public Text lblPoints;
	public Text lblTimeLeft;
	public Text lblGameScale;

	//Piano Key Buttons
	public Button btnMiddleC;
	public Button btnMiddleCSharp;
	public Button btnMiddleD;
	public Button btnMiddleDSharp;
	public Button btnMiddleE;
	public Button btnMiddleF;
	public Button btnMiddleFSharp;
	public Button btnMiddleG;
	public Button btnMiddleGSharp;
	public Button btnMiddleA;
	public Button btnMiddleASharp;
	public Button btnMiddleB;

	public Button btnHighC;
	public Button btnHighCSharp;
	public Button btnHighD;
	public Button btnHighDSharp;
	public Button btnHighE;
	public Button btnHighF;
	public Button btnHighFSharp;
	public Button btnHighG;
	public Button btnHighGSharp;
	public Button btnHighA;
	public Button btnHighASharp;
	public Button btnHighB;

	//Answer Results
	public Image imgCorrect;
	public Image imgIncorrect;
	public Image imgMiss;
	public Image imgAnswerClock;
	public Image imgTimesUp;

	//Answer Timer
	public Image imgWatch1;
	public Image imgWatch2;
	public Image imgWatch3;
	public Image imgWatch4;
	public Image imgWatch5;

	//Star Progress Bar
	public Image imgStar1;
	public Image imgStar2;
	public Image imgStar3;
	public Image imgStar4;
	public Image imgStar5;

	private bool star0Active;
	private bool star1Active;
	private bool star2Active;
	private bool star3Active;
	private bool star4Active;
	private bool star5Active;
	private int NumberofStars;

	//Item Pickup Variables for Major Scale
	public Image imgPickupBanana;
	public Image imgPickupBananaX; 
	public Image imgPickupMushroom;
	public Image imgPickupMushroomX;
	public Image imgPickupCoin;
	public Image imgPickupCoinX;
	public Image imgPickupLamp;
	public Image imgPickupLampX;
	public Image imgPickupApple;
	public Image imgPickupAppleX;
	public Image imgPickupBabyBird;
	public Image imgPickupBabyBirdX;
	public Image imgPickupPear;
	public Image imgPickupPearX;


	public Text lblPickupItem;


	private bool timeIsUpEndGame;
	private bool isPickUpItemBonusQuestion;

	//public Animation animeAnswerClock;

	float tmrGameStart;
	float tmrGoQuestion;
	float tmrAnswered;
	float tmrTimesUp;


	public AudioSource SoundToPlay;
	public string answer;
	public GuessFactory results = new GuessFactory();

	public eGameState GameState;




	// Use this for initialization
	void Start () {
		InitializeGame ();
	}

	void InitializeGame() {
		SaveFactory.GetGameData ();
		tmrGameStart = defaultGameStartDuration;
		tmrGoQuestion = defaultGoQuestionDuration;
		tmrAnswered = defaultAnsweredDuration;
		tmrTimesUp = defaultTimesUpDuration;
		lblPoints.text = ScoreFactory.standardPoints.ToString ();

		SetupLedgerLines();

		HideLabels ();
		HideAllResults ();
		HideSharpSymbols();
		HideFlatSymbols ();
		HidePoints ();
		HidePickupXItems ();
		HidePickupItems ();

	
		GameState = eGameState.GameIsStarting;
		UpdateGameStateLabel ();

		player.SetActive (false);
		ShowButtons (false);

		ThisSelectedLevel = CurrentGameData.ThisGameData.CurrentLevelSelected; 

		ShowKeySignature ();
		ShowItemPickUpIndicator ();

		myScore.MaximumQuestions = ScoreFactory.NumberOfQuestions;
		myScore.QuestionsAnswered = myScore.QuestionsAnswered = myScore.MaximumQuestions;
		myScore.CurrentComboCount = 1;
		NumberofStars = ScoreFactory.NumberOfStars;
		lblRemaining.text = "";

		if (!CommonUtils.IsStringEmpty(CurrentGameData.ThisGameData.CurrentScaleSelected)) {
			lblGameScale.text = CurrentGameData.ThisGameData.CurrentLevelSelected.Substring(5,1) + " " + CurrentGameData.ThisGameData.CurrentScaleSelected;
		}

		star0Active = true;
		star1Active = true;
		star2Active = true;
		star3Active = true;
		star4Active = true;
		star5Active = true;

		ItemsCollected = ScoreFactory.MaximumNumberOfItems;

	}

	void ShowItemPickUpIndicator() {
		switch (ThisSelectedLevel) {
		case ConstScale.CMajorScale:
			imgPickupBananaX.gameObject.SetActive (true);
			imgPickupMushroomX.gameObject.SetActive (false);
			imgPickupCoinX.gameObject.SetActive (false);
			imgPickupLampX.gameObject.SetActive (false);
			imgPickupAppleX.gameObject.SetActive (false);
			imgPickupBabyBirdX.gameObject.SetActive (false);
			imgPickupPearX.gameObject.SetActive (false);
			lblPickupItem.text = "x 0";
			break;
		case ConstScale.DMajorScale:
			imgPickupMushroomX.gameObject.SetActive (true);
			imgPickupBananaX.gameObject.SetActive (false);
			imgPickupCoinX.gameObject.SetActive (false);
			imgPickupLampX.gameObject.SetActive (false);
			imgPickupAppleX.gameObject.SetActive (false);
			imgPickupBabyBirdX.gameObject.SetActive (false);
			imgPickupPearX.gameObject.SetActive (false);
			lblPickupItem.text = "x 0";
			break;
		case ConstScale.EMajorScale:
			imgPickupCoinX.gameObject.SetActive (true);
			imgPickupBananaX.gameObject.SetActive (false);
			imgPickupMushroomX.gameObject.SetActive (false);
			imgPickupLampX.gameObject.SetActive (false);
			imgPickupAppleX.gameObject.SetActive (false);
			imgPickupBabyBirdX.gameObject.SetActive (false);
			imgPickupPearX.gameObject.SetActive (false);
			lblPickupItem.text = "x 0";
			break;
		case ConstScale.FMajorScale:
			imgPickupLampX.gameObject.SetActive (true);
			imgPickupCoinX.gameObject.SetActive (false);
			imgPickupBananaX.gameObject.SetActive (false);
			imgPickupMushroomX.gameObject.SetActive (false);
			imgPickupAppleX.gameObject.SetActive (false);
			imgPickupBabyBirdX.gameObject.SetActive (false);
			imgPickupPearX.gameObject.SetActive (false);
			lblPickupItem.text = "x 0";
			break;
		case ConstScale.GMajorScale:
			imgPickupAppleX.gameObject.SetActive (true);
			imgPickupLampX.gameObject.SetActive (false);
			imgPickupCoinX.gameObject.SetActive (false);
			imgPickupBananaX.gameObject.SetActive (false);
			imgPickupMushroomX.gameObject.SetActive (false);
			imgPickupBabyBirdX.gameObject.SetActive (false);
			imgPickupPearX.gameObject.SetActive (false);
			lblPickupItem.text = "x 0";		
			break;
		case ConstScale.AMajorScale:
			imgPickupBabyBirdX.gameObject.SetActive (true);
			imgPickupAppleX.gameObject.SetActive (false);
			imgPickupLampX.gameObject.SetActive (false);
			imgPickupCoinX.gameObject.SetActive (false);
			imgPickupBananaX.gameObject.SetActive (false);
			imgPickupMushroomX.gameObject.SetActive (false);
			imgPickupPearX.gameObject.SetActive (false);
			lblPickupItem.text = "x 0";		
			break;
		case ConstScale.BMajorScale:
			imgPickupPearX.gameObject.SetActive (true);
			imgPickupBabyBirdX.gameObject.SetActive (false);
			imgPickupAppleX.gameObject.SetActive (false);
			imgPickupLampX.gameObject.SetActive (false);
			imgPickupCoinX.gameObject.SetActive (false);
			imgPickupBananaX.gameObject.SetActive (false);
			imgPickupMushroomX.gameObject.SetActive (false);
			lblPickupItem.text = "x 0";		
			break;
		case ConstScale.CMinorScale:
			imgPickupBananaX.gameObject.SetActive (true);
			imgPickupMushroomX.gameObject.SetActive (false);
			imgPickupCoinX.gameObject.SetActive (false);
			imgPickupLampX.gameObject.SetActive (false);
			imgPickupAppleX.gameObject.SetActive (false);
			imgPickupBabyBirdX.gameObject.SetActive (false);
			imgPickupPearX.gameObject.SetActive (false);
			lblPickupItem.text = "x 0";
			break;
		case ConstScale.DMinorScale:
			imgPickupMushroomX.gameObject.SetActive (true);
			imgPickupBananaX.gameObject.SetActive (false);
			imgPickupCoinX.gameObject.SetActive (false);
			imgPickupLampX.gameObject.SetActive (false);
			imgPickupAppleX.gameObject.SetActive (false);
			imgPickupBabyBirdX.gameObject.SetActive (false);
			imgPickupPearX.gameObject.SetActive (false);
			lblPickupItem.text = "x 0";
			break;
		case ConstScale.EMinorScale:
			imgPickupCoinX.gameObject.SetActive (true);
			imgPickupBananaX.gameObject.SetActive (false);
			imgPickupMushroomX.gameObject.SetActive (false);
			imgPickupLampX.gameObject.SetActive (false);
			imgPickupAppleX.gameObject.SetActive (false);
			imgPickupBabyBirdX.gameObject.SetActive (false);
			imgPickupPearX.gameObject.SetActive (false);
			lblPickupItem.text = "x 0";
			break;
		case ConstScale.FMinorScale:
			imgPickupLampX.gameObject.SetActive (true);
			imgPickupCoinX.gameObject.SetActive (false);
			imgPickupBananaX.gameObject.SetActive (false);
			imgPickupMushroomX.gameObject.SetActive (false);
			imgPickupAppleX.gameObject.SetActive (false);
			imgPickupBabyBirdX.gameObject.SetActive (false);
			imgPickupPearX.gameObject.SetActive (false);
			lblPickupItem.text = "x 0";
			break;
		case ConstScale.GMinorScale:
			imgPickupAppleX.gameObject.SetActive (true);
			imgPickupLampX.gameObject.SetActive (false);
			imgPickupCoinX.gameObject.SetActive (false);
			imgPickupBananaX.gameObject.SetActive (false);
			imgPickupMushroomX.gameObject.SetActive (false);
			imgPickupBabyBirdX.gameObject.SetActive (false);
			imgPickupPearX.gameObject.SetActive (false);
			lblPickupItem.text = "x 0";		
			break;
		case ConstScale.AMinorScale:
			imgPickupBabyBirdX.gameObject.SetActive (true);
			imgPickupAppleX.gameObject.SetActive (false);
			imgPickupLampX.gameObject.SetActive (false);
			imgPickupCoinX.gameObject.SetActive (false);
			imgPickupBananaX.gameObject.SetActive (false);
			imgPickupMushroomX.gameObject.SetActive (false);
			imgPickupPearX.gameObject.SetActive (false);
			lblPickupItem.text = "x 0";		
			break;
		case ConstScale.BMinorScale:
			imgPickupPearX.gameObject.SetActive (true);
			imgPickupBabyBirdX.gameObject.SetActive (false);
			imgPickupAppleX.gameObject.SetActive (false);
			imgPickupLampX.gameObject.SetActive (false);
			imgPickupCoinX.gameObject.SetActive (false);
			imgPickupBananaX.gameObject.SetActive (false);
			imgPickupMushroomX.gameObject.SetActive (false);
			lblPickupItem.text = "x 0";		
			break;
		}
	}

	//Hide pickup item counter in left corner
	void HidePickupXItems() {
		imgPickupAppleX.gameObject.SetActive (false);
		imgPickupLampX.gameObject.SetActive (false);
		imgPickupCoinX.gameObject.SetActive (false);
		imgPickupBananaX.gameObject.SetActive (false);
		imgPickupMushroomX.gameObject.SetActive (false);
		imgPickupBabyBirdX.gameObject.SetActive (false);
	}

	//Hide pickup items displayed on the treble clef
	void HidePickupItems() {
		imgPickupApple.gameObject.SetActive (false);
		imgPickupLamp.gameObject.SetActive (false);
		imgPickupCoin.gameObject.SetActive (false);
		imgPickupBanana.gameObject.SetActive (false);
		imgPickupMushroom.gameObject.SetActive (false);
		imgPickupBabyBird.gameObject.SetActive (false);
		imgPickupPear.gameObject.SetActive (false);
	}

	void HideLabels() {
		lblGuessTimer.text = "";
		lblTimeLeft.text = "";
	}

	void HideSharpSymbols() {
		SharpF.SetActive(false);
		SharpC.SetActive(false);
		SharpG.SetActive(false);
		SharpD.SetActive(false);
		SharpA.SetActive(false);
		//playerSharp.gameObject.SetActive (false);
	}

	void HideFlatSymbols() {
		FlatA.SetActive(false);
		FlatB.SetActive(false);
		FlatD.SetActive(false);
		FlatE.SetActive(false);
		//playerFlat.gameObject.SetActive (false);
	}

	void ShowPoints(int PointVal) {
		lblPoints.text = myScore.GetPointsValueText();
		lblPoints.gameObject.SetActive (true);

	}

	void HidePoints() {
		lblPoints.gameObject.SetActive (false);
	}


	void ShowKeySignature() {

		//http://www.howmusicworks.org/210/The-Major-Scale/Key-Signatures-for-All-Keys

		switch (ThisSelectedLevel)
		{
		case ConstScale.CMajorScale:
			HideSharpSymbols ();
			HideFlatSymbols ();
			break;
		case ConstScale.DMajorScale:
			SharpF.SetActive (true);
			SharpC.SetActive (true);
			SharpG.SetActive (false);
			SharpD.SetActive (false);
			SharpA.SetActive (false);
			break;		
		case ConstScale.EMajorScale:
			SharpF.SetActive (true);
			SharpC.SetActive (true);
			SharpG.SetActive (true);
			SharpD.SetActive (true);
			SharpA.SetActive (false);
			break;
		case ConstScale.FMajorScale:
			SharpF.SetActive (false);
			SharpC.SetActive (false);
			SharpG.SetActive (false);
			SharpD.SetActive (false);
			SharpA.SetActive (false);
			FlatB.SetActive (true);
			break;
		case ConstScale.GMajorScale:
			SharpF.SetActive (true);
			SharpC.SetActive (false);
			SharpG.SetActive (false);
			SharpD.SetActive (false);
			SharpA.SetActive (false);
			break;
		case ConstScale.AMajorScale:
			SharpF.SetActive (true);
			SharpC.SetActive (true);
			SharpG.SetActive (true);
			SharpD.SetActive (false);
			SharpA.SetActive (false);
			break;
		case ConstScale.BMajorScale:
			SharpF.SetActive (true);
			SharpC.SetActive (true);
			SharpG.SetActive (true);
			SharpD.SetActive (true);
			SharpA.SetActive (true);
			break;
		case ConstScale.CMinorScale:
			FlatB.SetActive (true);
			FlatE.SetActive (true);
			FlatA.SetActive (true);
			break;
		case ConstScale.DMinorScale:
			FlatB.SetActive (true);
			break;
		case ConstScale.EMinorScale:			
			SharpF.SetActive (true);
			break;
		case ConstScale.FMinorScale:
			FlatA.SetActive (true);
			FlatB.SetActive (true);
			FlatD.SetActive (true);
			FlatE.SetActive (true);
			break;
		case ConstScale.GMinorScale:
			FlatB.SetActive (true);
			FlatE.SetActive (true);
			break;
		case ConstScale.AMinorScale:
			HideSharpSymbols ();
			HideFlatSymbols ();
			break;
		case ConstScale.BMinorScale:
			SharpC.SetActive (true);
			SharpF.SetActive (true);
			break;
		}

	}

	void SetupLedgerLines() {
		Vector3 CPos = MiddleCLine.transform.position;
		myNote.lowC = CPos.y;

		Vector3 Epos = ELine.transform.position;
		myNote.lowE = Epos.y;

		Vector3 Gpos = GLine.transform.position;
		myNote.lowG = Gpos.y;

		Vector3 Bpos = BLine.transform.position;
		myNote.lowB = Bpos.y;

		Vector3 Dpos = DLine.transform.position;
		myNote.highD = Dpos.y;

		Vector3 Fpos = FLine.transform.position;
		myNote.highF = Fpos.y;

		Vector3 APos = HighALine.transform.position;
		myNote.highA = APos.y;

		Vector3 ThirdOctaveCLinePos = ThirdOctaveCLine.transform.position;
		myNote.ThirdOctaveC = ThirdOctaveCLinePos.y;

		myNote.lowD = (myNote.lowC-((myNote.lowC - myNote.lowE) / 2));
		myNote.lowF = (myNote.lowE-((myNote.lowE - myNote.lowG) / 2));
		myNote.lowA = (myNote.lowG-((myNote.lowG - myNote.lowB) / 2));
		myNote.highC = (myNote.lowB-((myNote.lowB - myNote.highD) / 2));
		myNote.highE = (myNote.highD-((myNote.highD - myNote.highF) / 2));
		myNote.highG = (myNote.highF-((myNote.highF - myNote.highA) / 2));
		myNote.highB = (myNote.highA-((myNote.highA - myNote.ThirdOctaveC) / 2));
	}

			
	void HideAllResults() {
		imgCorrect.gameObject.SetActive (false);
		imgIncorrect.gameObject.SetActive (false);
		imgMiss.gameObject.SetActive (false);
		imgTimesUp.gameObject.SetActive (false);
	}

	void HideSharpsAndFlats() {
		//playerSharp.gameObject.SetActive (false);
		//playerFlat.gameObject.SetActive (false);
	}


	void ShowResults(eResults AnswerResult, bool showMe) {

		player.SetActive (false);

		switch (AnswerResult)
		{
		case eResults.Correct:
			imgCorrect.gameObject.SetActive (showMe);
			myScore.SetPointVal (eScoringPointType.StandardPoint);
			myScore.SetCorrect ();
			lblGameScore.text = myScore.GetScore ();
			lblGameScoreAccuracy.text = myScore.GetAccuracyTotal ();
			HideSharpsAndFlats ();
			break;
		case eResults.Incorrect:
			imgIncorrect.gameObject.SetActive (showMe);
			myScore.SetMissed ();
			lblGameScoreAccuracy.text = myScore.GetAccuracyTotal ();
			HideSharpsAndFlats ();
			break;
		case eResults.Missed:
			imgMiss.gameObject.SetActive (showMe);
			myScore.SetMissed ();
			lblGameScoreAccuracy.text = myScore.GetAccuracyTotal ();
			HideSharpsAndFlats ();
			break;
		case eResults.TimesUp:
			HideAllResults ();
			imgTimesUp.gameObject.SetActive (showMe);
			HideSharpsAndFlats ();
			break;
		}

	}

	void ShowButtons(bool showMe) {
		//btnAnswerA.gameObject.SetActive (showMe);

	}

	void ResetKeys() {
		ResetKey (ConstScale.lowC, false);
		ResetKey (ConstScale.lowCSharpDFlat, true);
		ResetKey (ConstScale.lowD, false);
		ResetKey (ConstScale.lowDSharpEFlat, true);
		ResetKey (ConstScale.lowE, false);
		ResetKey (ConstScale.lowF, false);
		ResetKey (ConstScale.lowFSharpGFlat, true);
		ResetKey (ConstScale.lowG, false);
		ResetKey (ConstScale.lowGSharpAFlat, true);
		ResetKey (ConstScale.lowA, false);
		ResetKey (ConstScale.lowASharpBFlat, true);
		ResetKey (ConstScale.lowB, false);
		ResetKey (ConstScale.highC, false);
		ResetKey (ConstScale.highCSharpDFlat, true);
		ResetKey (ConstScale.highD, false);
		ResetKey (ConstScale.highDSharpEFlat, true);
		ResetKey (ConstScale.highE, false);
		ResetKey (ConstScale.highF, false);
		ResetKey (ConstScale.highFSharpGFlat, true);
		ResetKey (ConstScale.highG, false);
		ResetKey (ConstScale.highGSharpAFlat, true);
		ResetKey (ConstScale.highA, false);
		ResetKey (ConstScale.highASharpBFlat, true);
		ResetKey (ConstScale.highB, false);


	}
	void ResetKey(string KeyName, bool isSharp) {
		var pianoKeySelector = new GuessFactory ();
		string SelectNote;

		pianoKeySelector.Answer = KeyName;
		SelectNote = pianoKeySelector.GetKeyBoardAnswerButtonName();
		var thisNote = GameObject.Find (SelectNote).GetComponent<Button> ().colors;
		if (isSharp) {
			thisNote.normalColor = Color.black;
		}
		else {
			thisNote.normalColor = Color.white;	
		}
		GameObject.Find (SelectNote).GetComponent<Button> ().colors = thisNote;
	}

	void PlaySound(string SoundName) {
		SoundToPlay = GameObject.Find (SoundName).GetComponent<AudioSource> ();
		SoundToPlay.Play ();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape)) 
		{ 
			SceneManager.LoadScene ("LevelScaleSelect");
		}

		if (GameState!=eGameState.GameIsStarting) {

			if (tmrTimesUp < 1 && !timeIsUpEndGame) {
				GameState = eGameState.GameTimeIsUp;
				lblTimeLeft.text = "0:00";
			} else {
				tmrTimesUp -= Time.deltaTime;

				int minutes = Mathf.FloorToInt (tmrTimesUp / 60F);
				int seconds = Mathf.FloorToInt (tmrTimesUp - minutes * 60);
				string formatTimeTxt = CommonUtils.GetFormattedMinutesAndSeconds(minutes,seconds);
				lblTimeLeft.text = formatTimeTxt;

			}

		}	

							
		switch (GameState)
		{
		case eGameState.GameIsStarting:
			tmrGameStart -= Time.deltaTime;
			string GameIsStartingSeconds = CommonUtils.GetFormattedTime (tmrGameStart);
			lblTimerStart.text = GameIsStartingSeconds;

			if (tmrGameStart > 4 && tmrGameStart < 6) {
				lblCountDown.text = "5";
			}
			else if (tmrGameStart > 3 && tmrGameStart < 5) {
				lblCountDown.text = "4";
			}
			else if (tmrGameStart > 2 && tmrGameStart < 4) {
				lblCountDown.text = "3";
			}
			else if (tmrGameStart > 1 && tmrGameStart < 3) {
				lblCountDown.text = "2";
			}
			else if (tmrGameStart > 0 && tmrGameStart < 2) {
				lblCountDown.text = "1";
			}

			if (tmrGameStart <= 0) {
				GameState = eGameState.StartNextQuestion;
				tmrGameStart = defaultGameStartDuration;
				UpdateGameStateLabel ();
				lblCountDown.text = "";
			}


			break;
		case eGameState.StartNextQuestion:
			ResetKeys ();
			//Clear Pickup Items
			isPickUpItemBonusQuestion = false;
			HidePickupItems ();

			//Reset Answer and Guess
			lblGuess.text = "";
			results.Answer = "";
			results.Guess = "";

			//Clear Keyboard Results
			ClearLastKeyboardResults ();

			//Position Player for next movie
			MovePlayer (); 

			//Reenable Keyboard
			EnablePianoKeyboard (true);


			GameState = eGameState.WaitingForAnswer;
			UpdateGameStateLabel ();
			tmrGoQuestion = defaultGoQuestionDuration;
			//animeAnswerClock.gameObject.SetActive(true);
			lblRemaining.text = "Remaining: " + myScore.QuestionsAnswered;
			lblCurrentAnswer.text = "";
			HidePoints ();

			break;
		case eGameState.WaitingForAnswer:
			tmrGoQuestion -= Time.deltaTime;
			SetAnswerClockAnimation ();
			if (tmrGoQuestion <= 0) {
				GameState = eGameState.QuestionTimeUp;
				UpdateGameStateLabel ();
			} else {
				string WaitingForAnswerSeconds = CommonUtils.GetFormattedTime(tmrGoQuestion);
				lblGuessTimer.text = "Waiting for Answer: " + WaitingForAnswerSeconds;
			}
			break;
		case eGameState.AnswerCorrect:

			if (isPickUpItemBonusQuestion) {
				ShowPoints (ScoreFactory.pickUpItemBonusPoints);
				myScore.CurrentItemsCollected += 1;
				lblPickupItem.text = "x " + myScore.CurrentItemsCollected.ToString();
				HidePickupItems ();
			}
			else {
				ShowPoints (ScoreFactory.standardPoints);		
			}

			//Display Correct Image
			ShowResults (eResults.Correct, true);
			GameState = eGameState.DisplayResults;
			ShowKeyboardResults ();
			EnablePianoKeyboard (false);
			myScore.QuestionsAnswered -= 1;
			CheckForCompletedLevel ();
			lblCurrentAnswer.text = "Answer: " + results.GetAnswerFullNoteName ();
						
			break;
		case eGameState.AnswerIncorrect:
			if (isPickUpItemBonusQuestion) {
				HidePickupItems ();
			}

			ShowResults (eResults.Incorrect, true);
			GameState = eGameState.DisplayResults;
			ShowKeyboardResults ();
			EnablePianoKeyboard (false);
			myScore.QuestionsAnswered -= 1;
			UpdateProgressIndicator ();
			CheckForCompletedLevel ();
			lblCurrentAnswer.text = "Answer: " + results.GetAnswerFullNoteName();
			break;
		case eGameState.QuestionTimeUp:
			if (isPickUpItemBonusQuestion) {
				HidePickupItems ();
			}
			ShowResults (eResults.Missed, true);
			GameState = eGameState.DisplayResults;
			ShowKeyboardResults ();
			EnablePianoKeyboard (false);
			myScore.QuestionsAnswered -= 1;
			UpdateProgressIndicator ();
			CheckForCompletedLevel ();
			lblCurrentAnswer.text = "Answer: " + results.GetAnswerFullNoteName();
			break;
		case eGameState.DisplayResults:
			tmrAnswered -= Time.deltaTime;
			string AnsweredCorrectSeconds = CommonUtils.GetFormattedTime(tmrAnswered);
			lblAnsweredTimer.text = "Answered: " + AnsweredCorrectSeconds;
			if (tmrAnswered <= 0) {
				//IF the time is up then we will end the game 
				//ELSE show Correct, Incorrect, or Miss image
				if (timeIsUpEndGame) {
					GameState = eGameState.GameIsOver;
				} else {
					tmrAnswered = defaultAnsweredDuration;
					GameState = eGameState.StartNextQuestion;
					UpdateGameStateLabel ();
					HideAllResults ();
				}
			}
			break;
		case eGameState.GameIsOver:
			SceneManager.LoadScene ("LevelGameOver");
			break;
		case eGameState.LevelIsComplete:
			//Save the user's selection
			myScore.CurrentTimeBonus = (int)tmrTimesUp;
			myScore.CurrentStars = NumberofStars;

			myScore.SaveScore (ThisSelectedLevel);
			myScore.SaveUnlockLevel (ThisSelectedLevel);
			myScore.SaveHighScore (ThisSelectedLevel);
			SceneManager.LoadScene ("LevelCompleted");
			break;
		case eGameState.GameTimeIsUp:
			timeIsUpEndGame = true;
			ShowResults (eResults.TimesUp, true);
			GameState = eGameState.DisplayResults;
			break;
		default:
			break;		
		};
			
	}

	void UpdateProgressIndicator() {
		if (star5Active) {
			if (myScore.Star5Available ()) {
				return;
			} else {
				imgStar5.gameObject.SetActive (false);
				star5Active = false;
				NumberofStars -= 1;
			}
		} else if (star4Active) { 
			if (myScore.Star4Available ()) {
				return;
			} else {
				imgStar4.gameObject.SetActive (false);
				star4Active = false;
				NumberofStars -= 1;
			}
		} else if (star3Active) { 
			if (myScore.Star3Available ()) {
				return;
			} else {
				imgStar3.gameObject.SetActive (false);
				star3Active = false;
				NumberofStars -= 1;
			}
		} else if (star2Active) { 
			if (myScore.Star2Available ()) {
				return;
			} else {
				imgStar2.gameObject.SetActive (false);
				star2Active = false;
				NumberofStars -= 1;
			}
		} else if (star1Active) { 
			if (myScore.Star1Available ()) {
				return;
			} else {
				imgStar1.gameObject.SetActive (false);
				star1Active = false;
				NumberofStars -= 1;
			}
		} else if (star0Active) { 
			if (myScore.Star0Available ()) {
				GameState = eGameState.GameIsOver;
			}
		}
	}

	void CheckForCompletedLevel() {
		if (myScore.QuestionsAnswered < 1) {
			GameState = eGameState.LevelIsComplete;
		}
	}



	void MovePlayer() {
		
		// This will return the game object named Hand in the scene.

		NoteModel thisNote = new NoteModel ();
		thisNote = myNote.GetRandomNotes (ThisSelectedLevel);

		if (myScore.DisplayItem ()) {

			isPickUpItemBonusQuestion = true;

			switch (ThisSelectedLevel)
			{
			case ConstScale.CMajorScale:
				imgPickupBanana.gameObject.SetActive (true);
				break;
			case ConstScale.DMajorScale:
				imgPickupMushroom.gameObject.SetActive (true);
				break;
			case ConstScale.EMajorScale:
				imgPickupCoin.gameObject.SetActive (true);
				break;
			case ConstScale.FMajorScale:
				imgPickupLamp.gameObject.SetActive (true);
				break;
			case ConstScale.GMajorScale:
				imgPickupApple.gameObject.SetActive (true);
				break;
			case ConstScale.AMajorScale:
				imgPickupBabyBird.gameObject.SetActive (true);
				break;
			case ConstScale.BMajorScale:
				imgPickupPear.gameObject.SetActive (true);
				break;
			case ConstScale.CMinorScale:
				imgPickupBanana.gameObject.SetActive (true);
				break;
			case ConstScale.DMinorScale:
				imgPickupMushroom.gameObject.SetActive (true);
				break;
			case ConstScale.EMinorScale:
				imgPickupCoin.gameObject.SetActive (true);
				break;
			case ConstScale.FMinorScale:
				imgPickupLamp.gameObject.SetActive (true);
				break;
			case ConstScale.GMinorScale:
				imgPickupApple.gameObject.SetActive (true);
				break;
			case ConstScale.AMinorScale:
				imgPickupBabyBird.gameObject.SetActive (true);
				break;
			case ConstScale.BMinorScale:
				imgPickupPear.gameObject.SetActive (true);
				break;
			}

			PlaySound (thisNote.NoteSoundName);

			//set global answer
			lblAnswer.text = thisNote.NoteSoundName;
			answer = thisNote.NoteName;
			results.Answer = thisNote.NoteSoundName;
			results.PreviousAnswer = thisNote.NoteSoundName;
				

		} else {
			Vector3 pos = player.transform.position;
			//Vector3 posSharp = playerSharp.gameObject.transform.position;  
			//Vector3 posFlat = playerFlat.gameObject.transform.position;
			//Vector3 posScore = lblPoints.gameObject.transform.position;

			pos.y = thisNote.NotePosition;
			//posSharp.y = thisNote.NotePosition;
			//posFlat.y = thisNote.NotePosition+0.75f;
			//posScore.y = thisNote.NotePosition;

			player.transform.position = pos;
			//playerSharp.transform.position = posSharp;
			//playerFlat.transform.position = posFlat;
			//lblPoints.transform.position = posScore;

			switch (thisNote.NotePitch) {
			case "Natural":
				//playerSharp.gameObject.SetActive (false);
				//playerFlat.gameObject.SetActive (false);
				break;
			case "Sharp":
				//playerSharp.gameObject.SetActive (true);
				//playerFlat.gameObject.SetActive (false);
				break;
			case "Flat":			
				//playerSharp.gameObject.SetActive (false);
				//playerFlat.gameObject.SetActive (true);
				break;
			}		

			PlaySound (thisNote.NoteSoundName);

			//set global answer
			lblAnswer.text = thisNote.NoteSoundName;
			answer = thisNote.NoteName;
			results.Answer = thisNote.NoteSoundName;
			results.PreviousAnswer = thisNote.NoteSoundName;


			player.SetActive (true);
		}






	}

	void SetAnswerClockAnimation() {


		if (tmrGoQuestion > 0 && tmrGoQuestion <= 1) {
			imgAnswerClock.overrideSprite = imgWatch5.sprite;	
			return;
		}

		if (tmrGoQuestion > 1 && tmrGoQuestion <= 2) {
			imgAnswerClock.overrideSprite = imgWatch4.sprite;	
			return;
		}

		if (tmrGoQuestion > 2 && tmrGoQuestion <= 3) {
			imgAnswerClock.overrideSprite = imgWatch3.sprite;	
			return;
		}

		if (tmrGoQuestion > 3 && tmrGoQuestion <= 4) {
			imgAnswerClock.overrideSprite = imgWatch2.sprite;	
			return;
		}

		imgAnswerClock.overrideSprite = imgWatch1.sprite;

	}

	public void btnMenu()
	{
		SceneManager.LoadScene ("LevelScaleSelect");
	}

	public void btnClicked(string param)
	{
		//Remember when you are wiring up the button onClick from the Unity
		//make sure to select click event from the scene tab. On the scene
		//tab select level, next choose level script --> btnClicked

		results.Guess = param;

		if (GameState == eGameState.AnswerCorrect || 
			GameState == eGameState.AnswerIncorrect ||
			GameState == eGameState.QuestionTimeUp ||
			GameState == eGameState.GameIsStarting ||
			GameState == eGameState.DisplayResults ||
			GameState == eGameState.StartNextQuestion) {
			ResetKeys ();
			return;
		}

		PlaySound (param);

		if (param == lblAnswer.text) {
			GameState = eGameState.AnswerCorrect;
			UpdateGameStateLabel ();
		}	
		else {
			GameState = eGameState.AnswerIncorrect;
			UpdateGameStateLabel ();
		}

	
	//	ShowButtons (false);

	}

	public void ShowKeyboardResults() {

		string AnswerKey;
	
		AnswerKey = results.GetKeyBoardAnswerButtonName();
	
		var AnswerColor = GameObject.Find (AnswerKey).GetComponent<Button> ().colors;
		AnswerColor.normalColor = Color.green;
		GameObject.Find (AnswerKey).GetComponent<Button> ().colors = AnswerColor;

	}

	public void ClearLastKeyboardResults() {

		string AnswerKey;

		AnswerKey = results.GetKeyBoardPreviousGuessButtonName();

		if (AnswerKey == "") {
			return;
		}

		ResetKeys ();
	}

	void EnablePianoKeyboard(bool ShowMe) {
		//btnMiddleC.interactable = ShowMe;
		//btnMiddleCSharp.interactable = ShowMe;
		//btnMiddleD.interactable = ShowMe;
		//btnMiddleDSharp.interactable = ShowMe;
		//btnMiddleE.interactable = ShowMe;
		//btnMiddleF.interactable = ShowMe;
		//btnMiddleFSharp.interactable = ShowMe;
		//btnMiddleG.interactable = ShowMe;
		//btnMiddleGSharp.interactable = ShowMe;
		//btnMiddleA.interactable = ShowMe;
		//btnMiddleASharp.interactable = ShowMe;
		//btnMiddleB.interactable = ShowMe;
		//btnHighC.interactable = ShowMe;
		//btnHighCSharp.interactable = ShowMe;
		//btnHighD.interactable = ShowMe;
		//btnHighDSharp.interactable = ShowMe;
		//btnHighE.interactable = ShowMe;
		//btnHighF.interactable = ShowMe;
		//btnHighFSharp.interactable = ShowMe;
		//btnHighG.interactable = ShowMe;
		//btnHighGSharp.interactable = ShowMe;
		//btnHighA.interactable = ShowMe;
		//btnHighASharp.interactable = ShowMe;
		//btnHighB.interactable = ShowMe;
	}


	public void UpdateGameStateLabel() {
		lblGameState.text = GameState.ToString ();
	}

}



