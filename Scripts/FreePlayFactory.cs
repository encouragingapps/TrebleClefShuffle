using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;


public class FreePlayFactory {

	public string KeyboardResult {get; set;}

	public string GetAnswerFullNoteName() {

		string output = "";

		switch (KeyboardResult) {
		case ConstScale.lowC:
			output= "C";
			break;
		case ConstScale.lowCSharpDFlat:
			output="C Sharp / D Flat";
			break;
		case ConstScale.lowD:
			output="D";
			break;
		case ConstScale.lowDSharpEFlat:
			output="D Sharp / E Flat";
			break;
		case ConstScale.lowE:
			output="E";
			break;
		case ConstScale.lowF:
			output="F";
			break;
		case ConstScale.lowFSharpGFlat:
			output="F Sharp / G Flat";
			break;
		case ConstScale.lowG:
			output="G";
			break;
		case ConstScale.lowGSharpAFlat:
			output="G Sharp / A Flat";
			break;
		case ConstScale.lowA:
			output="A";
			break;
		case ConstScale.lowASharpBFlat:
			output="A Sharp / B Flat";
			break;
		case ConstScale.lowB:
			output="B";
			break;		
		case ConstScale.highC:
			output="C";
			break;
		case ConstScale.highCSharpDFlat:
			output="C Sharp / D Flat";
			break;
		case ConstScale.highD:
			output="D";
			break;
		case ConstScale.highDSharpEFlat:
			output="D Sharp / E Flat";
			break;
		case ConstScale.highE:
			output="E";
			break;
		case ConstScale.highF:
			output="F";
			break;
		case ConstScale.highFSharpGFlat:
			output="F Sharp / G Flat";
			break;
		case ConstScale.highG:
			output="G";
			break;
		case ConstScale.highGSharpAFlat:
			output="G Sharp / A Flat";
			break;
		case ConstScale.highA:
			output="A";
			break;
		case ConstScale.highASharpBFlat:
			output="A Sharp / B Flat";
			break;
		case ConstScale.highB:
			output="B";
			break;
		}

		return output;

	}

	public string GetKeyBoardButtonName(string AnswerOrGuess) {

		string output = "";

		switch (AnswerOrGuess) {
		case ConstScale.lowC:
			output= "/Canvas/PianoKeys/btnMiddleC";
			break;
		case ConstScale.lowCSharpDFlat:
			output="/Canvas/PianoKeys/btnMiddleCSharp";
			break;
		case ConstScale.lowD:
			output="/Canvas/PianoKeys/btnMiddleD";
			break;
		case ConstScale.lowDSharpEFlat:
			output="/Canvas/PianoKeys/btnMiddleDSharp";
			break;
		case ConstScale.lowE:
			output="/Canvas/PianoKeys/btnMiddleE";
			break;
		case ConstScale.lowF:
			output="/Canvas/PianoKeys/btnMiddleF";
			break;
		case ConstScale.lowFSharpGFlat:
			output="/Canvas/PianoKeys/btnMiddleFSharp";
			break;
		case ConstScale.lowG:
			output="/Canvas/PianoKeys/btnMiddleG";
			break;
		case ConstScale.lowGSharpAFlat:
			output="/Canvas/PianoKeys/btnMiddleGSharp";
			break;
		case ConstScale.lowA:
			output="/Canvas/PianoKeys/btnMiddleA";
			break;
		case ConstScale.lowASharpBFlat:
			output="/Canvas/PianoKeys/btnMiddleASharp";
			break;
		case ConstScale.lowB:
			output="/Canvas/PianoKeys/btnMiddleB";
			break;		
		case ConstScale.highC:
			output= "/Canvas/PianoKeys/btnHighC";
			break;
		case ConstScale.highCSharpDFlat:
			output="/Canvas/PianoKeys/btnHighCSharp";
			break;
		case ConstScale.highD:
			output="/Canvas/PianoKeys/btnHighD";
			break;
		case ConstScale.highDSharpEFlat:
			output="/Canvas/PianoKeys/btnHighDSharp";
			break;
		case ConstScale.highE:
			output="/Canvas/PianoKeys/btnHighE";
			break;
		case ConstScale.highF:
			output="/Canvas/PianoKeys/btnHighF";
			break;
		case ConstScale.highFSharpGFlat:
			output="/Canvas/PianoKeys/btnHighFSharp";
			break;
		case ConstScale.highG:
			output="/Canvas/PianoKeys/btnHighG";
			break;
		case ConstScale.highGSharpAFlat:
			output="/Canvas/PianoKeys/btnHighGSharp";
			break;
		case ConstScale.highA:
			output="/Canvas/PianoKeys/btnHighA";
			break;
		case ConstScale.highASharpBFlat:
			output="/Canvas/PianoKeys/btnHighASharp";
			break;
		case ConstScale.highB:
			output="/Canvas/PianoKeys/btnHighB";
			break;

		}

		return output;

	}

}
