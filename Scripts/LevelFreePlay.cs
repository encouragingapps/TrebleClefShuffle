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

//What the Free Play Training Does

public static class ArrayExtensionsTraining
{
	// This is an extension method. RandomItem() will now exist on all arrays.
	public static T RandomItem<T>(this T[] array)
	{
		return array[Random.Range(0, array.Length)];
	}
}

public class LevelFreePlay : MonoBehaviour {

	//Session Data

	public NoteFactory myNote = new NoteFactory();

	//3D Player Object
	public GameObject player;


	//3D Ledger Lines
	public GameObject ELine;
	public GameObject GLine;
	public GameObject BLine;
	public GameObject DLine;
	public GameObject FLine;
	public GameObject MiddleCLine;
	public GameObject HighALine;
	public GameObject ThirdOctaveCLine;

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

	public FreePlayFactory results = new FreePlayFactory();
	//Used to highlight the key 
	public GuessFactory pianoKey = new GuessFactory();

	public AudioSource SoundToPlay;
	public string answer;

	public eGameState GameState;
	public Text lblResult;

	// Use this for initialization
	void Start () {
		InitializeGame ();
	}

	void InitializeGame() {
		lblResult.text = "";
		SetupLedgerLines();
		GameState = eGameState.GameIsStarting;
		player.SetActive (false);

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
					

		}	
			
	}


	public void btnMenu()
	{
		SceneManager.LoadScene ("LevelScaleSelect");
	}

	public void btnClicked(string param)
	{
		ResetKeys();
		results.KeyboardResult = param;
		lblResult.text = results.GetAnswerFullNoteName();
		PlaySound (param);
		Vector3 pos = player.transform.position;
		pos.y = myNote.GetFreePlayTrainingNote (param).NotePosition;
		player.transform.position = pos;
		player.SetActive (true);
		ShowKeyboardResults (param);
	}


	public void ShowKeyboardResults(string param) {

		string AnswerKey;

		AnswerKey = pianoKey.GetKeyBoardButtonName(param);

		var AnswerColor = GameObject.Find (AnswerKey).GetComponent<Button> ().colors;
		AnswerColor.normalColor = Color.green;
		GameObject.Find (AnswerKey).GetComponent<Button> ().colors = AnswerColor;

	}


}



