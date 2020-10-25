using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;



public class NoteModel {
	public string NoteName {get; set;}
	public string NotePitch {get; set;}
	public float NotePosition {get; set;}
	public string NoteSoundName {get; set;}
}

public class ScoreModel {
	public int? HighScore {get; set;}
	public int? FunnyItemScore {get; set;}
}


