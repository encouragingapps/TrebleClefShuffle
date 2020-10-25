using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Linq;

//http://www.pianoscales.org/major.html
//http://www.pianoscales.org/minor.html

//Key Signatures
//http://musictheoryisyourfriend.com/what-are-key-signatures/


public class LevelSelection : MonoBehaviour
{

	public Text lblLevelName;
	public Text lblRootNote;
	public Text lblIsLocked;
	public Button btnLeft;
	public Button btnRight;
	public Button btnStart;
	public int CurrentLevelSelected = 1;
	private string ScaleSelected;



	// Use this for initialization
	void Start ()
	{
		SaveFactory.GetGameData ();

		CurrentGameData.ThisGameData.CMajorScaleUnLocked = true;
		CurrentGameData.ThisGameData.CMinorScaleUnLocked = true;

		ScaleSelected = CurrentGameData.ThisGameData.CurrentScaleSelected;

		if (ScaleSelected == "Major") {
			CMajorScaleNotes ();
		} else if (ScaleSelected == "Minor") {
			CMinorScaleNotes();
		}

		btnLeft.gameObject.SetActive (false);
		CurrentLevelSelected = 1;

		SaveFactory.SaveGameData ();
			
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{ 
			SceneManager.LoadScene ("LevelScaleSelect");
		}
	}

	void DisplayBeginButton(bool Val) {
		btnStart.gameObject.SetActive (Val);
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



	void CMinorScaleNotes() {

		ResetKeys ();

		lblLevelName.text = ConstScale.NaturalMinorScale;
		lblRootNote.text = "C";

		//C, D, Eb/D#, F, G, Ab/G#, Bb/A#, C
		HighlightKey (ConstScale.lowC);
		HighlightKey (ConstScale.lowD);
		HighlightKey (ConstScale.lowDSharpEFlat);
		HighlightKey (ConstScale.lowF);
		HighlightKey (ConstScale.lowG);
		HighlightKey (ConstScale.lowGSharpAFlat);
		HighlightKey (ConstScale.lowASharpBFlat);
		HighlightKey (ConstScale.highC);


		if (CurrentGameData.ThisGameData.CMinorScaleUnLocked) {
			DisplayBeginButton (true);
			lblIsLocked.text = GameFeatures.Unlocked;
		} 
		else 
		{ 
			DisplayBeginButton (false);
			lblIsLocked.text = GameFeatures.Locked; 
		}

	}

	void DMinorScaleNotes() {
		ResetKeys ();

		lblLevelName.text = ConstScale.NaturalMinorScale;
		lblRootNote.text = "D";

		//D, E, F, G, A, Bb/A#, C, D
		HighlightKey (ConstScale.lowD);
		HighlightKey (ConstScale.lowE);
		HighlightKey (ConstScale.lowF);
		HighlightKey (ConstScale.lowG);
		HighlightKey (ConstScale.lowA);
		HighlightKey (ConstScale.lowASharpBFlat);
		HighlightKey (ConstScale.highC);
		HighlightKey (ConstScale.highD);

		if (CurrentGameData.ThisGameData.DMinorScaleUnLocked) 
		{
			DisplayBeginButton (true);
			lblIsLocked.text = GameFeatures.Unlocked;
		} 
		else 
		{ 
			DisplayBeginButton (false);
			lblIsLocked.text = GameFeatures.Locked; 
		}

	}

	void EMinorScaleNotes() {
		ResetKeys ();

		lblLevelName.text = ConstScale.NaturalMinorScale;
		lblRootNote.text = "E";

		//E, F#, G, A, B, C, D, E
		HighlightKey (ConstScale.lowE);
		HighlightKey (ConstScale.lowFSharpGFlat);
		HighlightKey (ConstScale.lowG);
		HighlightKey (ConstScale.lowA);
		HighlightKey (ConstScale.lowB);
		HighlightKey (ConstScale.highC);
		HighlightKey (ConstScale.highD);
		HighlightKey (ConstScale.highE);

		if (CurrentGameData.ThisGameData.EMinorScaleUnLocked) 
		{
			lblIsLocked.text = GameFeatures.Unlocked;
			DisplayBeginButton (true);
		} 
		else 
		{ 
			lblIsLocked.text = GameFeatures.Locked; 
			DisplayBeginButton (false);
		}

	}

	void FMinorScaleNotes() {
		ResetKeys ();

		lblLevelName.text = ConstScale.NaturalMinorScale;
		lblRootNote.text = "F";

		//F, G, Ab, Bb, C, Db, Eb, F
		HighlightKey (ConstScale.lowF);
		HighlightKey (ConstScale.lowG);
		HighlightKey (ConstScale.lowGSharpAFlat);
		HighlightKey (ConstScale.lowASharpBFlat);
		HighlightKey (ConstScale.highC);
		HighlightKey (ConstScale.highCSharpDFlat);
		HighlightKey (ConstScale.highDSharpEFlat);
		HighlightKey (ConstScale.highF);

		if (CurrentGameData.ThisGameData.FMinorScaleUnLocked) 
		{
			lblIsLocked.text = GameFeatures.Unlocked;
			DisplayBeginButton (true);
		} 
		else 
		{ 
			lblIsLocked.text = GameFeatures.Locked; 
			DisplayBeginButton (false);
		}

	}

	void GMinorScaleNotes() {
		ResetKeys ();
		lblLevelName.text = ConstScale.NaturalMinorScale;
		lblRootNote.text = "G";

		//G, A, Bb/A#, C, D, Eb, F, G
		HighlightKey (ConstScale.lowG);
		HighlightKey (ConstScale.lowA);
		HighlightKey (ConstScale.lowASharpBFlat);
		HighlightKey (ConstScale.highC);
		HighlightKey (ConstScale.highD);
		HighlightKey (ConstScale.highDSharpEFlat);
		HighlightKey (ConstScale.highF);
		HighlightKey (ConstScale.highG);


		if (CurrentGameData.ThisGameData.GMinorScaleUnLocked) 
		{
			lblIsLocked.text = GameFeatures.Unlocked;
			DisplayBeginButton (true);
		} 
		else 
		{ 
			lblIsLocked.text = GameFeatures.Locked; 
			DisplayBeginButton (false);
		}

	}

	void AMinorScaleNotes() {
		ResetKeys ();
		lblLevelName.text = ConstScale.NaturalMinorScale;
		lblRootNote.text = "A";

		//A, B, C, D, E, F, G, A
		HighlightKey (ConstScale.lowA);
		HighlightKey (ConstScale.lowB);
		HighlightKey (ConstScale.highC);
		HighlightKey (ConstScale.highD);
		HighlightKey (ConstScale.highE);
		HighlightKey (ConstScale.highF);
		HighlightKey (ConstScale.highG);
		HighlightKey (ConstScale.highA);

		if (CurrentGameData.ThisGameData.AMinorScaleUnLocked) 
		{
			lblIsLocked.text = GameFeatures.Unlocked;
			DisplayBeginButton (true);
		} 
		else 
		{ 
			lblIsLocked.text = GameFeatures.Locked; 
			DisplayBeginButton (false);
		}

	}

	void BMinorScaleNotes() {
		ResetKeys ();
		lblLevelName.text = ConstScale.NaturalMinorScale;
		lblRootNote.text = "B";

		//B, C#, D, E, F#, G, A, B
		HighlightKey (ConstScale.lowB);
		HighlightKey (ConstScale.highCSharpDFlat);
		HighlightKey (ConstScale.highD);
		HighlightKey (ConstScale.highE);
		HighlightKey (ConstScale.highFSharpGFlat);
		HighlightKey (ConstScale.highG);
		HighlightKey (ConstScale.highA);
		HighlightKey (ConstScale.highB);

		if (CurrentGameData.ThisGameData.BMinorScaleUnLocked) 
		{
			lblIsLocked.text = GameFeatures.Unlocked;
			DisplayBeginButton (true);
		} 
		else 
		{ 
			lblIsLocked.text = GameFeatures.Locked; 
			DisplayBeginButton (false);
		}

	}


	void CMajorScaleNotes() {

		ResetKeys ();

		lblLevelName.text = ConstScale.NaturalMajorScale;
		lblRootNote.text = "C";

		//C, D, E, F, G, A, B, C
		HighlightKey (ConstScale.lowC);
		HighlightKey (ConstScale.lowD);
		HighlightKey (ConstScale.lowE);
		HighlightKey (ConstScale.lowF);
		HighlightKey (ConstScale.lowG);
		HighlightKey (ConstScale.lowA);
		HighlightKey (ConstScale.lowB);
		HighlightKey (ConstScale.highC);

		if (CurrentGameData.ThisGameData.CMajorScaleUnLocked) 
		{
			lblIsLocked.text = GameFeatures.Unlocked;
			DisplayBeginButton (true);
		} 
		else 
		{ 
			lblIsLocked.text = GameFeatures.Locked; 
			DisplayBeginButton (false);
		}

	}

	void DMajorScaleNotes() {

		ResetKeys ();

		lblLevelName.text = ConstScale.NaturalMajorScale;
		lblRootNote.text = "D";

		//D, E, F#, G, A, B, C#, D
		HighlightKey (ConstScale.lowD);
		HighlightKey (ConstScale.lowE);
		HighlightKey (ConstScale.lowFSharpGFlat);
		HighlightKey (ConstScale.lowG);
		HighlightKey (ConstScale.lowA);
		HighlightKey (ConstScale.lowB); 
		HighlightKey (ConstScale.highCSharpDFlat);
		HighlightKey (ConstScale.highD);
	
		if (CurrentGameData.ThisGameData.DMajorScaleUnLocked) 
		{
			lblIsLocked.text = GameFeatures.Unlocked;
			DisplayBeginButton (true);
		} 
		else 
		{ 
			lblIsLocked.text = GameFeatures.Locked; 
			DisplayBeginButton (false);
		}

	}

	//E, F#, G#, A, B, C#, D#, E
	void EMajorScaleNotes() {

		ResetKeys ();
		lblLevelName = GameObject.Find ("/Canvas/lblLevelName").GetComponent<Text> ();
		lblRootNote = GameObject.Find ("/Canvas/lblRootNote").GetComponent<Text> ();
		lblIsLocked = GameObject.Find ("/Canvas/lblIsLocked").GetComponent<Text> ();
		lblLevelName.text = ConstScale.NaturalMajorScale;
		lblRootNote.text = "E";

		//E, F#, G#, A, B, C#, D#,
		HighlightKey (ConstScale.lowE);
		HighlightKey (ConstScale.lowFSharpGFlat);
		HighlightKey (ConstScale.lowGSharpAFlat);
		HighlightKey (ConstScale.lowA);
		HighlightKey (ConstScale.lowB);
		HighlightKey (ConstScale.highCSharpDFlat); 
		HighlightKey (ConstScale.highDSharpEFlat);
		HighlightKey (ConstScale.highE);

		if (CurrentGameData.ThisGameData.EMajorScaleUnLocked) 
		{
			lblIsLocked.text = GameFeatures.Unlocked;
			DisplayBeginButton (true);
		} 
		else 
		{ 
			lblIsLocked.text = GameFeatures.Locked; 
			DisplayBeginButton (false);
		}

	}

	void FMajorScaleNotes() {

		ResetKeys ();
		lblLevelName.text = ConstScale.NaturalMajorScale;
		lblRootNote.text = "F";

		//F, G, A, A#(Bb), C, D, E, F
		HighlightKey (ConstScale.lowF);
		HighlightKey (ConstScale.lowG);
		HighlightKey (ConstScale.lowA);
		HighlightKey (ConstScale.lowASharpBFlat);
		HighlightKey (ConstScale.highC);
		HighlightKey (ConstScale.highD); 
		HighlightKey (ConstScale.highE);
		HighlightKey (ConstScale.highF);

		if (CurrentGameData.ThisGameData.FMajorScaleUnLocked) 
		{
			lblIsLocked.text = GameFeatures.Unlocked;
			DisplayBeginButton (true);
		} 
		else 
		{ 
			lblIsLocked.text = GameFeatures.Locked; 
			DisplayBeginButton (false);
		}

	}


	void GMajorScaleNotes() {

		ResetKeys ();

		lblLevelName.text = ConstScale.NaturalMajorScale;
		lblRootNote.text = "G";

		//G, A, B, C, D, E, F#, G
		HighlightKey (ConstScale.lowG);
		HighlightKey (ConstScale.lowA);
		HighlightKey (ConstScale.lowB);
		HighlightKey (ConstScale.highC);
		HighlightKey (ConstScale.highD);
		HighlightKey (ConstScale.highE); 
		HighlightKey (ConstScale.highFSharpGFlat);
		HighlightKey (ConstScale.highG); 

		if (CurrentGameData.ThisGameData.GMajorScaleUnLocked) 
		{
			lblIsLocked.text = GameFeatures.Unlocked;
			DisplayBeginButton (true);
		} 
		else 
		{ 
			lblIsLocked.text = GameFeatures.Locked; 
			DisplayBeginButton (false);
		}

	}

	void AMajorScaleNotes() {

		ResetKeys ();

		lblLevelName.text = ConstScale.NaturalMajorScale;
		lblRootNote.text = "A";

		//A, B, C#, D, E, F#, G#, A
		HighlightKey (ConstScale.lowA);
		HighlightKey (ConstScale.lowB);
		HighlightKey (ConstScale.highCSharpDFlat);
		HighlightKey (ConstScale.highD);
		HighlightKey (ConstScale.highE);
		HighlightKey (ConstScale.highFSharpGFlat); 
		HighlightKey (ConstScale.highGSharpAFlat);
		HighlightKey (ConstScale.highA);

		if (CurrentGameData.ThisGameData.AMajorScaleUnLocked) 
		{
			lblIsLocked.text = GameFeatures.Unlocked;
			DisplayBeginButton (true);
		} 
		else 
		{ 
			lblIsLocked.text = GameFeatures.Locked; 
			DisplayBeginButton (false);
		}

	}

	void BMajorScaleNotes() {

		ResetKeys ();

		lblLevelName.text = ConstScale.NaturalMajorScale;
		lblRootNote.text = "B";

		//B, C#, D#, E, F#, G#, A#, B
		HighlightKey (ConstScale.lowB);
		HighlightKey (ConstScale.highCSharpDFlat);
		HighlightKey (ConstScale.highDSharpEFlat);
		HighlightKey (ConstScale.highE);
		HighlightKey (ConstScale.highFSharpGFlat);
		HighlightKey (ConstScale.highGSharpAFlat); 
		HighlightKey (ConstScale.highASharpBFlat);
		HighlightKey (ConstScale.highB);

		if (CurrentGameData.ThisGameData.BMajorScaleUnLocked) 
		{
			lblIsLocked.text = GameFeatures.Unlocked;
			DisplayBeginButton (true);
		} 
		else 
		{ 
			lblIsLocked.text = GameFeatures.Locked; 
			DisplayBeginButton (false);
		}

	}


	void HighlightKey(string KeyName) {

		var pianoKeySelector = new GuessFactory ();
		string SelectNote;

		pianoKeySelector.Answer = KeyName;
		SelectNote = pianoKeySelector.GetKeyBoardAnswerButtonName();
		var thisNote = GameObject.Find (SelectNote).GetComponent<Button> ().colors;
		thisNote.normalColor = Color.magenta;
		GameObject.Find (SelectNote).GetComponent<Button> ().colors = thisNote;
	}

	void SetCurrentLevelLeft() {
		if (CurrentLevelSelected > 1) {
			CurrentLevelSelected -= 1;
			btnLeft.gameObject.SetActive (true);
		} else {
			btnLeft.gameObject.SetActive (false);
		}

		if (CurrentLevelSelected < 7) {
			btnRight.gameObject.SetActive (true);
		}

		if (CurrentLevelSelected == 1) {
			btnLeft.gameObject.SetActive (false);
		}
	}

	void SetCurrentLevelRight() {
		if (CurrentLevelSelected <= 7) 
		 {
			CurrentLevelSelected += 1;
			btnRight.gameObject.SetActive (true);
		 }

		if (CurrentLevelSelected == 7) {
			btnRight.gameObject.SetActive (false);
		}

		if (CurrentLevelSelected > 1) {
				btnLeft.gameObject.SetActive (true);
		}
	}

	public void btnClicked(string param)
	{
		//Remember when you are wiring up the button onClick from the Unity
		//make sure to select click event from the scene tab. On the scene
		//tab select level, next choose level script --> btnClicked
	
		if (ScaleSelected == "Major") {			
			NavigateMajorScale (param);
		} else if (ScaleSelected == "Minor") {			
			NavigateMinorScale (param);
		}

		if (param == "Menu") {
			SceneManager.LoadScene ("LevelScaleSelect");
		}


			
	}

	private void NavigateMajorScale(string param) {
		if (param == "MoveLeft") 
		{
			SetCurrentLevelLeft ();
		}
		else if (param=="Begin") 
		{				

			string SelectedLevel = string.Empty;

			switch (CurrentLevelSelected) {
			case 1:
				SelectedLevel = ConstScale.CMajorScale;
				break;
			case 2:
				SelectedLevel = ConstScale.DMajorScale;
				break;
			case 3:
				SelectedLevel = ConstScale.EMajorScale;
				break;
			case 4:
				SelectedLevel = ConstScale.FMajorScale;
				break;
			case 5:
				SelectedLevel = ConstScale.GMajorScale;
				break;
			case 6:
				SelectedLevel = ConstScale.AMajorScale;
				break;
			case 7:
				SelectedLevel = ConstScale.BMajorScale;
				break;				
			}

			CurrentGameData.ThisGameData.CurrentLevelSelected = SelectedLevel;
			SaveFactory.SaveGameData();
			SceneManager.LoadScene ("GameLevel");

			return;

		}
		else if (param=="MoveRight") 
		{
			SetCurrentLevelRight();
		}


		switch (CurrentLevelSelected) {
		case 1:
			CMajorScaleNotes ();
			break;
		case 2:
			DMajorScaleNotes ();
			break;
		case 3:
			EMajorScaleNotes ();
			break;
		case 4:
			FMajorScaleNotes ();
			break;
		case 5:
			GMajorScaleNotes ();
			break;
		case 6:
			AMajorScaleNotes ();
			break;
		case 7:
			BMajorScaleNotes ();
			break;
		}
	}

	private void NavigateMinorScale(string param) {
		if (param == "MoveLeft") 
		{
			SetCurrentLevelLeft ();		
		}
		else if (param=="Begin") 
		{				

			string SelectedLevel = string.Empty;

			switch (CurrentLevelSelected) {
			case 1:
				SelectedLevel = ConstScale.CMinorScale;
				break;
			case 2:
				SelectedLevel = ConstScale.DMinorScale;
				break;
			case 3:
				SelectedLevel = ConstScale.EMinorScale;
				break;
			case 4:
				SelectedLevel = ConstScale.FMinorScale;
				break;
			case 5:
				SelectedLevel = ConstScale.GMinorScale;
				break;
			case 6:
				SelectedLevel = ConstScale.AMinorScale;
				break;
			case 7:
				SelectedLevel = ConstScale.BMinorScale;
				break;				
			}

			CurrentGameData.ThisGameData.CurrentLevelSelected = SelectedLevel;
			SaveFactory.SaveGameData();
			SceneManager.LoadScene ("GameLevel");

			return;

		}
		else if (param=="MoveRight") 
		{
			SetCurrentLevelRight ();
		}
			
		switch (CurrentLevelSelected) {
		case 1:
			CMinorScaleNotes ();
			break;
		case 2:
			DMinorScaleNotes ();
			break;
		case 3:
			EMinorScaleNotes ();
			break;
		case 4:
			FMinorScaleNotes ();
			break;
		case 5:
			GMinorScaleNotes ();
			break;
		case 6:
			AMinorScaleNotes ();
			break;
		case 7:
			BMinorScaleNotes ();
			break;
		}
	}

				
}

