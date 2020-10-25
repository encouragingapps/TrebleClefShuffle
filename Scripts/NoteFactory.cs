using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class NoteFactory {


	public float highA { get; set; }
	public float highG { get; set; }
	public float highF { get; set; }
	public float highE { get; set; }
	public float highD { get; set; }
	public float highC { get; set; }
	public float highB { get; set; }
	public float ThirdOctaveC { get; set; }
	public float lowC { get; set; }
	public float lowB { get; set; }
	public float lowA { get; set; }
	public float lowG { get; set; }
	public float lowF { get; set; }
	public float lowE { get; set; }
	public float lowD { get; set; }

	//Make sure the note is always unique
	public int previousRandomNumber { get; set; }
	public int currentRandomNumber { get; set; }


		//M = Middle
	    //H = High
	public NoteModel GetRandomNotes(string SelectedScale) {		
		NoteModel returnModel = new NoteModel ();

		switch (SelectedScale) {
		case ConstScale.CMajorScale:
			returnModel = GetCMajorNote ();				
			break;
		case ConstScale.DMajorScale:
			returnModel = GetDMajorNote ();
			break;
		case ConstScale.EMajorScale:
			returnModel = GetEMajorNote ();
			break;
		case ConstScale.FMajorScale:
			returnModel = GetFMajorNote ();
			break;
		case ConstScale.GMajorScale:
			returnModel = GetGMajorNote ();
			break;
		case ConstScale.AMajorScale:
			returnModel = GetAMajorNote ();
			break;
		case ConstScale.BMajorScale:
			returnModel = GetBMajorNote ();
			break;
		case ConstScale.CMinorScale:
			returnModel = GetCMinorNote ();
			break;
		case ConstScale.DMinorScale:
			returnModel = GetDMinorNote ();
			break;
		case ConstScale.EMinorScale:
			returnModel = GetEMinorNote ();
			break;
		case ConstScale.FMinorScale:
			returnModel = GetFMinorNote ();
			break;
		case ConstScale.GMinorScale:
			returnModel = GetGMinorNote ();
			break;
		case ConstScale.AMinorScale:
			returnModel = GetAMinorNote ();
			break;
		case ConstScale.BMinorScale:
			returnModel = GetBMinorNote ();
			break;
		}					
			return returnModel;
	 }

	private int GetMeSomeRandomNumber() {
		currentRandomNumber = Random.Range(1,9);

		//Don't display the same note twice!
		while (currentRandomNumber == previousRandomNumber) 
		{
			currentRandomNumber = Random.Range(1,9);
		}

		previousRandomNumber = currentRandomNumber;

		return currentRandomNumber;
	}

	//C, D, E, F, G, A, B, C	
	private NoteModel GetCMajorNote() {
			
		NoteModel returnModel = new NoteModel ();

		switch (GetMeSomeRandomNumber())
			{
			case 1:
				returnModel.NotePosition = lowC;
				returnModel.NoteSoundName = ConstScale.lowC;
				returnModel.NotePitch = ConstScale.Natural;
				break;
			case 2:
				returnModel.NotePosition = lowD;
				returnModel.NoteSoundName = ConstScale.lowD;
				returnModel.NotePitch = ConstScale.Natural;
				break;
			case 3:
				returnModel.NotePosition = lowE;
				returnModel.NoteSoundName = ConstScale.lowE;
				returnModel.NotePitch = ConstScale.Natural;
				break;
			case 4:
				returnModel.NotePosition = lowF;
				returnModel.NoteSoundName = ConstScale.lowF;
				returnModel.NotePitch = ConstScale.Natural;
				break;
			case 5:
				returnModel.NotePosition = lowG;
				returnModel.NoteSoundName = ConstScale.lowG;				
				returnModel.NotePitch = ConstScale.Natural;
				break;
			case 6:
				returnModel.NotePosition = lowA;
				returnModel.NoteSoundName = ConstScale.lowA;				
				returnModel.NotePitch = ConstScale.Natural;
				break;
			case 7:
				returnModel.NotePosition = lowB;
				returnModel.NotePitch = ConstScale.Natural;
				returnModel.NoteSoundName = ConstScale.lowB;				
				break;
			case 8:
				returnModel.NotePosition = highC;
				returnModel.NotePitch = ConstScale.Natural;				
				returnModel.NoteSoundName = ConstScale.highC;
				break;

			}
			
		return returnModel;
	}

	//D, E, F#, G, A, B, C#, D
	private NoteModel GetDMajorNote() {
		
		NoteModel returnModel = new NoteModel ();

		switch (GetMeSomeRandomNumber())
		{
		case 1:
			returnModel.NotePosition = lowD;
			returnModel.NoteSoundName = ConstScale.lowD;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 2:
			returnModel.NotePosition = lowE;
			returnModel.NoteSoundName = ConstScale.lowE;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 3:
			returnModel.NotePosition = lowF;
			returnModel.NoteSoundName = ConstScale.lowFSharpGFlat;
			returnModel.NotePitch = ConstScale.Sharp;
			break;
		case 4:
			returnModel.NotePosition = lowG;
			returnModel.NoteSoundName = ConstScale.lowG;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 5:
			returnModel.NotePosition = lowA;
			returnModel.NoteSoundName = ConstScale.lowA;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 6:
			returnModel.NotePosition = lowB;
			returnModel.NoteSoundName = ConstScale.lowB;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 7:
			returnModel.NotePosition = highC;
			returnModel.NoteSoundName = ConstScale.highCSharpDFlat;
			returnModel.NotePitch = ConstScale.Sharp;
			break;
		case 8:
			returnModel.NotePosition = highD;
			returnModel.NoteSoundName = ConstScale.highD;
			returnModel.NotePitch = ConstScale.Natural;
			break;

		}
		return returnModel;
	}

	//E, F#, G#, A, B, C#, D#, E
	private NoteModel GetEMajorNote() {
		
		NoteModel returnModel = new NoteModel ();

		switch (GetMeSomeRandomNumber())
		{
		case 1:
			returnModel.NotePosition = lowE;
			returnModel.NoteSoundName = ConstScale.lowE;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 2:
			returnModel.NotePosition = lowF;
			returnModel.NoteSoundName = ConstScale.lowFSharpGFlat;
			returnModel.NotePitch = ConstScale.Sharp;
			break;
		case 3:
			returnModel.NotePosition = lowG;
			returnModel.NoteSoundName = ConstScale.lowGSharpAFlat;
			returnModel.NotePitch = ConstScale.Sharp;
			break;
		case 4:
			returnModel.NotePosition = lowA;
			returnModel.NoteSoundName = ConstScale.lowA;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 5:
			returnModel.NotePosition = lowB;
			returnModel.NoteSoundName = ConstScale.lowB;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 6:
			returnModel.NotePosition = highC;
			returnModel.NoteSoundName = ConstScale.highCSharpDFlat;
			returnModel.NotePitch = ConstScale.Sharp;
			break;
		case 7:
			returnModel.NotePosition = highD;
			returnModel.NoteSoundName = ConstScale.highDSharpEFlat;
			returnModel.NotePitch = ConstScale.Sharp;
			break;
		case 8:
			returnModel.NotePosition = highE;
			returnModel.NoteSoundName = ConstScale.highE;
			returnModel.NotePitch = ConstScale.Natural;
			break;

		}
		return returnModel;
	}

	//F, G, A, A#(Bb), C, D, E, F
	private NoteModel GetFMajorNote() {
		
		NoteModel returnModel = new NoteModel ();

		switch (GetMeSomeRandomNumber())
		{
		case 1:
			returnModel.NotePosition = lowF;
			returnModel.NoteSoundName = ConstScale.lowF;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 2:
			returnModel.NotePosition = lowG;
			returnModel.NoteSoundName = ConstScale.lowG;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 3:
			returnModel.NotePosition = lowA;
			returnModel.NoteSoundName = ConstScale.lowA;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 4:
			returnModel.NotePosition = lowB;
			returnModel.NoteSoundName = ConstScale.lowASharpBFlat;
			returnModel.NotePitch = ConstScale.Flat;
			break;
		case 5:
			returnModel.NotePosition = highC;
			returnModel.NoteSoundName = ConstScale.highC;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 6:
			returnModel.NotePosition = highD;
			returnModel.NoteSoundName = ConstScale.highD;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 7:
			returnModel.NotePosition = highE;
			returnModel.NoteSoundName = ConstScale.highE;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 8:
			returnModel.NotePosition = highF;
			returnModel.NoteSoundName = ConstScale.highF;
			returnModel.NotePitch = ConstScale.Natural;
			break;

		}
		return returnModel;
	}

	//G, A, B, C, D, E, F#, G
	private NoteModel GetGMajorNote() {
		
		NoteModel returnModel = new NoteModel ();

		switch (GetMeSomeRandomNumber())
		{
		case 1:
			returnModel.NotePosition = lowG;
			returnModel.NoteSoundName = ConstScale.lowG;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 2:
			returnModel.NotePosition = lowA;
			returnModel.NoteSoundName = ConstScale.lowA;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 3:
			returnModel.NotePosition = lowB;
			returnModel.NoteSoundName = ConstScale.lowB;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 4:
			returnModel.NotePosition = highC;
			returnModel.NoteSoundName = ConstScale.highC;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 5:
			returnModel.NotePosition = highD;
			returnModel.NoteSoundName = ConstScale.highD;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 6:
			returnModel.NotePosition = highE;
			returnModel.NoteSoundName = ConstScale.highE;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 7:
			returnModel.NotePosition = highF;
			returnModel.NoteSoundName = ConstScale.highFSharpGFlat;
			returnModel.NotePitch = ConstScale.Sharp;
			break;
		case 8:
			returnModel.NotePosition = highG;
			returnModel.NoteSoundName = ConstScale.highG;
			returnModel.NotePitch = ConstScale.Natural;
			break;

		}
		return returnModel;
	}


	//A, B, C#, D, E, F#, G#, A
	private NoteModel GetAMajorNote() {
		
		NoteModel returnModel = new NoteModel ();

		switch (GetMeSomeRandomNumber())
		{
		case 1:
			returnModel.NotePosition = lowA;
			returnModel.NoteSoundName = ConstScale.lowA;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 2:
			returnModel.NotePosition = lowB;
			returnModel.NoteSoundName = ConstScale.lowB;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 3:
			returnModel.NotePosition = lowC;
			returnModel.NoteSoundName = ConstScale.lowCSharpDFlat;
			returnModel.NotePitch = ConstScale.Sharp;
			break;
		case 4:
			returnModel.NotePosition = highD;
			returnModel.NoteSoundName = ConstScale.highD;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 5:
			returnModel.NotePosition = highE;
			returnModel.NoteSoundName = ConstScale.highE;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 6:
			returnModel.NotePosition = highF;
			returnModel.NoteSoundName = ConstScale.highFSharpGFlat;
			returnModel.NotePitch = ConstScale.Sharp;
			break;
		case 7:
			returnModel.NotePosition = highG;
			returnModel.NoteSoundName = ConstScale.highGSharpAFlat;
			returnModel.NotePitch = ConstScale.Sharp;
			break;
		case 8:
			returnModel.NotePosition = highA;
			returnModel.NoteSoundName = ConstScale.highA;
			returnModel.NotePitch = ConstScale.Natural;
			break;

		}
		return returnModel;
	}


	//B, C#, D#, E, F#, G#, A#, B
	private NoteModel GetBMajorNote() {
		
		NoteModel returnModel = new NoteModel ();

		switch (GetMeSomeRandomNumber())
		{
		case 1:
			returnModel.NotePosition = lowB;
			returnModel.NoteSoundName = ConstScale.lowB;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 2:
			returnModel.NotePosition = highC;
			returnModel.NoteSoundName = ConstScale.highCSharpDFlat;
			returnModel.NotePitch = ConstScale.Sharp;
			break;
		case 3:
			returnModel.NotePosition = highD;
			returnModel.NoteSoundName = ConstScale.highDSharpEFlat;
			returnModel.NotePitch = ConstScale.Sharp;
			break;
		case 4:
			returnModel.NotePosition = highE;
			returnModel.NoteSoundName = ConstScale.highE;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 5:
			returnModel.NotePosition = highF;
			returnModel.NoteSoundName = ConstScale.highFSharpGFlat;
			returnModel.NotePitch = ConstScale.Sharp;
			break;
		case 6:
			returnModel.NotePosition = highG;
			returnModel.NoteSoundName = ConstScale.highGSharpAFlat;
			returnModel.NotePitch = ConstScale.Sharp;
			break;
		case 7:
			returnModel.NotePosition = highA;
			returnModel.NoteSoundName = ConstScale.highASharpBFlat;
			returnModel.NotePitch = ConstScale.Sharp;
			break;
		case 8:
			returnModel.NotePosition = highB;
			returnModel.NoteSoundName = ConstScale.highB;
			returnModel.NotePitch = ConstScale.Natural;
			break;

		}
		return returnModel;
	}


	//C, D, Eb/D#, F, G, Ab/G#, Bb/A#, C
	private NoteModel GetCMinorNote() {
		
		NoteModel returnModel = new NoteModel ();

		switch (GetMeSomeRandomNumber())
		{
		case 1:
			returnModel.NotePosition = lowC;
			returnModel.NoteSoundName = ConstScale.lowC;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 2:
			returnModel.NotePosition = lowD;
			returnModel.NoteSoundName = ConstScale.lowD;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 3:
			returnModel.NotePosition = lowE;
			returnModel.NoteSoundName = ConstScale.lowDSharpEFlat;
			returnModel.NotePitch = ConstScale.Flat;
			break;
		case 4:
			returnModel.NotePosition = lowF;
			returnModel.NoteSoundName = ConstScale.lowF;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 5:
			returnModel.NotePosition = lowG;
			returnModel.NoteSoundName = ConstScale.lowG;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 6:
			returnModel.NotePosition = lowA;
			returnModel.NoteSoundName = ConstScale.lowGSharpAFlat;
			returnModel.NotePitch = ConstScale.Flat;
			break;
		case 7:
			returnModel.NotePosition = lowB;
			returnModel.NoteSoundName = ConstScale.lowASharpBFlat;
			returnModel.NotePitch = ConstScale.Flat;
			break;
		case 8:
			returnModel.NotePosition = highC;
			returnModel.NoteSoundName = ConstScale.highC;
			returnModel.NotePitch = ConstScale.Natural;
			break;

		}
		return returnModel;
	}


	//D, E, F, G, A, Bb/A#, C, D
	private NoteModel GetDMinorNote() {
		
		NoteModel returnModel = new NoteModel ();

		switch (GetMeSomeRandomNumber())
		{
		case 1:
			returnModel.NotePosition = lowD;
			returnModel.NoteSoundName = ConstScale.lowD;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 2:
			returnModel.NotePosition = lowE;
			returnModel.NoteSoundName = ConstScale.lowE;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 3:
			returnModel.NotePosition = lowF;
			returnModel.NoteSoundName = ConstScale.lowF;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 4:
			returnModel.NotePosition = lowG;
			returnModel.NoteSoundName = ConstScale.lowG;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 5:
			returnModel.NotePosition = lowA;
			returnModel.NoteSoundName = ConstScale.lowA;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 6:
			returnModel.NotePosition = lowB;
			returnModel.NoteSoundName = ConstScale.lowASharpBFlat;
			returnModel.NotePitch = ConstScale.Flat;
			break;
		case 7:
			returnModel.NotePosition = highC;
			returnModel.NoteSoundName = ConstScale.highC;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 8:
			returnModel.NotePosition = highD;
			returnModel.NoteSoundName = ConstScale.highD;
			returnModel.NotePitch = ConstScale.Natural;
			break;

		}
		return returnModel;
	}


	//E, F#, G, A, B, C, D, E
	private NoteModel GetEMinorNote() {
		
		NoteModel returnModel = new NoteModel ();

		switch (GetMeSomeRandomNumber())
		{
		case 1:
			returnModel.NotePosition = lowE;
			returnModel.NoteSoundName = ConstScale.lowE;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 2:
			returnModel.NotePosition = lowF;
			returnModel.NoteSoundName = ConstScale.lowFSharpGFlat;
			returnModel.NotePitch = ConstScale.Sharp;
			break;
		case 3:
			returnModel.NotePosition = lowG;
			returnModel.NoteSoundName = ConstScale.lowG;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 4:
			returnModel.NotePosition = lowA;
			returnModel.NoteSoundName = ConstScale.lowA;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 5:
			returnModel.NotePosition = lowB;
			returnModel.NoteSoundName = ConstScale.lowB;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 6:
			returnModel.NotePosition = highC;
			returnModel.NoteSoundName = ConstScale.highC;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 7:
			returnModel.NotePosition = highD;
			returnModel.NoteSoundName = ConstScale.highD;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 8:
			returnModel.NotePosition = highE;
			returnModel.NoteSoundName = ConstScale.highE;
			returnModel.NotePitch = ConstScale.Natural;
			break;

		}
		return returnModel;
	}


	//F, G, Ab, Bb, C, Db, Eb, F
	private NoteModel GetFMinorNote() {
		
		NoteModel returnModel = new NoteModel ();

		switch (GetMeSomeRandomNumber())
		{
		case 1:
			returnModel.NotePosition = lowF;
			returnModel.NoteSoundName = ConstScale.lowF;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 2:
			returnModel.NotePosition = lowG;
			returnModel.NoteSoundName = ConstScale.lowG;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 3:
			returnModel.NotePosition = lowA;
			returnModel.NoteSoundName = ConstScale.lowGSharpAFlat;
			returnModel.NotePitch = ConstScale.Flat;
			break;
		case 4:
			returnModel.NotePosition = lowB;
			returnModel.NoteSoundName = ConstScale.lowASharpBFlat;
			returnModel.NotePitch = ConstScale.Flat;
			break;
		case 5:
			returnModel.NotePosition = highC;
			returnModel.NoteSoundName = ConstScale.highC;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 6:
			returnModel.NotePosition = highD;
			returnModel.NoteSoundName = ConstScale.highCSharpDFlat;
			returnModel.NotePitch = ConstScale.Flat;
			break;
		case 7:
			returnModel.NotePosition = highE;
			returnModel.NoteSoundName = ConstScale.highDSharpEFlat;
			returnModel.NotePitch = ConstScale.Flat;
			break;
		case 8:
			returnModel.NotePosition = highF;
			returnModel.NoteSoundName = ConstScale.highF;
			returnModel.NotePitch = ConstScale.Natural;
			break;

		}
		return returnModel;
	}


	//G, A, Bb/A#, C, D, Eb, F, G
	private NoteModel GetGMinorNote() {
		
		NoteModel returnModel = new NoteModel ();

		switch (GetMeSomeRandomNumber())
		{
		case 1:
			returnModel.NotePosition = lowG;
			returnModel.NoteSoundName = ConstScale.lowG;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 2:
			returnModel.NotePosition = lowA;
			returnModel.NoteSoundName = ConstScale.lowA;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 3:
			returnModel.NotePosition = lowB;
			returnModel.NoteSoundName = ConstScale.lowASharpBFlat;
			returnModel.NotePitch = ConstScale.Flat;
			break;
		case 4:
			returnModel.NotePosition = highC;
			returnModel.NoteSoundName = ConstScale.highC;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 5:
			returnModel.NotePosition = highD;
			returnModel.NoteSoundName = ConstScale.highD;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 6:
			returnModel.NotePosition = highE;
			returnModel.NoteSoundName = ConstScale.highDSharpEFlat;
			returnModel.NotePitch = ConstScale.Flat;
			break;
		case 7:
			returnModel.NotePosition = highF;
			returnModel.NoteSoundName = ConstScale.highF;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 8:
			returnModel.NotePosition = highG;
			returnModel.NoteSoundName = ConstScale.highG;
			returnModel.NotePitch = ConstScale.Natural;
			break;

		}
		return returnModel;
	}

	//A, B, C, D, E, F, G, A
	private NoteModel GetAMinorNote() {
		
		NoteModel returnModel = new NoteModel ();

		switch (GetMeSomeRandomNumber())
		{
		case 1:
			returnModel.NotePosition = lowA;
			returnModel.NoteSoundName = ConstScale.lowA;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 2:
			returnModel.NotePosition = lowB;
			returnModel.NoteSoundName = ConstScale.lowB;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 3:
			returnModel.NotePosition = highC;
			returnModel.NoteSoundName = ConstScale.highC;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 4:
			returnModel.NotePosition = highD;
			returnModel.NoteSoundName = ConstScale.highD;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 5:
			returnModel.NotePosition = highE;
			returnModel.NoteSoundName = ConstScale.highE;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 6:
			returnModel.NotePosition = highF;
			returnModel.NoteSoundName = ConstScale.highF;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 7:
			returnModel.NotePosition = highG;
			returnModel.NoteSoundName = ConstScale.highG;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 8:
			returnModel.NotePosition = highA;
			returnModel.NoteSoundName = ConstScale.highA;
			returnModel.NotePitch = ConstScale.Natural;
			break;

		}
		return returnModel;
	}

	//B, C#, D, E, F#, G, A, B
	private NoteModel GetBMinorNote() {
		
		NoteModel returnModel = new NoteModel ();

		switch (GetMeSomeRandomNumber())
		{
		case 1:
			returnModel.NotePosition = lowB;
			returnModel.NoteSoundName = ConstScale.lowB;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 2:
			returnModel.NotePosition = highC;
			returnModel.NoteSoundName = ConstScale.highCSharpDFlat;
			returnModel.NotePitch = ConstScale.Sharp;
			break;
		case 3:
			returnModel.NotePosition = highD;
			returnModel.NoteSoundName = ConstScale.highD;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 4:
			returnModel.NotePosition = highE;
			returnModel.NoteSoundName = ConstScale.highE;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 5:
			returnModel.NotePosition = highF;
			returnModel.NoteSoundName = ConstScale.highFSharpGFlat;
			returnModel.NotePitch = ConstScale.Sharp;
			break;
		case 6:
			returnModel.NotePosition = highG;
			returnModel.NoteSoundName = ConstScale.highG;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 7:
			returnModel.NotePosition = highA;
			returnModel.NoteSoundName = ConstScale.highA;
			returnModel.NotePitch = ConstScale.Natural;
			break;
		case 8:
			returnModel.NotePosition = highB;
			returnModel.NoteSoundName = ConstScale.highB;
			returnModel.NotePitch = ConstScale.Natural;
			break;

		}
		return returnModel;
	}


	public NoteModel GetFreePlayTrainingNote(string SelectedNote) {		
		NoteModel returnModel = new NoteModel ();

			switch (SelectedNote)
			{
				case ConstScale.lowC:
					returnModel.NotePosition = lowC;
					break;
				case ConstScale.lowCSharpDFlat:
					returnModel.NotePosition = lowC;					
					break;
				case ConstScale.lowD:
					returnModel.NotePosition = lowD;					
					break;
				case ConstScale.lowDSharpEFlat: 
					returnModel.NotePosition = lowD;
					break;
				case ConstScale.lowE:
					returnModel.NotePosition = lowE;					
					break;				
				case ConstScale.lowF:
					returnModel.NotePosition = lowF;
					break;
				case ConstScale.lowFSharpGFlat:
					returnModel.NotePosition = lowF;					
					break;
				case ConstScale.lowG:
					returnModel.NotePosition = lowG;
					break;
				case ConstScale.lowGSharpAFlat:
					returnModel.NotePosition = lowG;
					break;			
				case ConstScale.lowA:
					returnModel.NotePosition = lowA;					
					break;
				case ConstScale.lowASharpBFlat:
					returnModel.NotePosition = lowA;
					break;
				case ConstScale.lowB:
					returnModel.NotePosition = lowB;								
					break;
				case ConstScale.highC:
					returnModel.NotePosition = highC;		
					break;
				case ConstScale.highCSharpDFlat:
					returnModel.NotePosition = highC;		
					break;
				case ConstScale.highD:
					returnModel.NotePosition = highD;
					break;
				case ConstScale.highDSharpEFlat:
					returnModel.NotePosition = highD;
					break;
				case ConstScale.highE:
					returnModel.NotePosition = highE;					
					break;
				case ConstScale.highF:
					returnModel.NotePosition = highF;		
					break;
				case ConstScale.highFSharpGFlat:
					returnModel.NotePosition = highF;		
					break;
				case ConstScale.highG:
					returnModel.NotePosition = highG;					
					break;
				case ConstScale.highGSharpAFlat:
					returnModel.NotePosition = highG;					
					break;
				case ConstScale.highA:
					returnModel.NotePosition = highA;				
					break;
				case ConstScale.highASharpBFlat:
					returnModel.NotePosition = highA;
					break;
				case ConstScale.highB:
					returnModel.NotePosition = highB;
					break;		
			}
			
		return returnModel;
	}




}




	//public NoteModel GetRandomNotes(eMajorScales SelectedScale) {
	//	int randomNote = Random.Range(1,12);
	//	NoteModel returnModel = new NoteModel ();

	//	switch (randomNote)
	//	{
	//	case 1:
	//		returnModel.NotePosition = lowC;
	//		returnModel.NotePitch = eNotePitch.Natural;
	//		returnModel.NoteName = "C";
	//		returnModel.NoteSoundName = "MC";				
	//		break;
	//	case 2:
	//		returnModel.NotePosition = lowD;
	//		returnModel.NotePitch = eNotePitch.Natural;
	//		returnModel.NoteName = "D";
	//		returnModel.NoteSoundName = "MD";				
	//		break;
	//	case 3:
	//		returnModel.NotePosition = lowE;
	//		returnModel.NotePitch = eNotePitch.Natural;
	//		returnModel.NoteName = "E";
	//		returnModel.NoteSoundName = "ME";				
	//		break;
	//	case 4:
	//		returnModel.NotePosition = lowF;
	//		returnModel.NotePitch = eNotePitch.Natural;
	//		returnModel.NoteName = "F";
	//		returnModel.NoteSoundName = "MF";
	//		break;
	//	case 5:
	//		returnModel.NotePosition = lowG;
	//		returnModel.NotePitch = eNotePitch.Natural;
	//		returnModel.NoteName = "G";
	//		returnModel.NoteSoundName = "MG";				
	//		break;
	//	case 6:
	//		returnModel.NotePosition = lowA;
	//		returnModel.NotePitch = eNotePitch.Natural;
	//		returnModel.NoteName = "A";
	//		returnModel.NoteSoundName = "MA";				
	//		break;
	//	case 7:
	//		returnModel.NotePosition = lowB;
	//		returnModel.NotePitch = eNotePitch.Natural;
	//		returnModel.NoteName = "B";
	//		returnModel.NoteSoundName = "MB";				
	//		break;
	//	case 8:
	//		returnModel.NotePosition = highC;
	//		returnModel.NotePitch = eNotePitch.Natural;
	//		returnModel.NoteName = "C";
	//		returnModel.NoteSoundName = "HC";				
	//		break;
	//	case 9:
	//		returnModel.NotePosition = highD;
	//		returnModel.NotePitch = eNotePitch.Natural;
	//		returnModel.NoteName = "D";
	//		returnModel.NoteSoundName = "HD";				
	//		break;
	//	case 10:
	//		returnModel.NotePosition = highE;
	//		returnModel.NotePitch = eNotePitch.Natural;
	//		returnModel.NoteName = "E";
	//		returnModel.NoteSoundName = "HE";
	//		break;
	//	case 11:
	//		returnModel.NotePosition = highF;
	//		returnModel.NotePitch = eNotePitch.Natural;
	//		returnModel.NoteName = "F";
	//		returnModel.NoteSoundName = "HF";
	//		break;
	//	case 12:
	//		returnModel.NotePosition = highG;
//returnModel.NotePitch = eNotePitch.Natural;
	//		returnModel.NoteName = "G";
	//		returnModel.NoteSoundName = "HG";				
	//		break;		
	//	}

	//	return returnModel;
	//}