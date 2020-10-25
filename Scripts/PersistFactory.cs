using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

//http://coffeebreakcodes.com/save-and-load-game-unity3d/

//Useage
//   To set values use   CurrentGameData.ThisGameData.CurrentLevelSelected = "MajorD"
//   To save use   SaveGameData()


  public static class CurrentGameData {
	public const string Version010000 = "Version 1.0.0";  //Every version should have it's only constant

	public static GameSaveData ThisGameData  { get; set; }

	public static void InitializeGameData() {		
		ThisGameData = new GameSaveData();
		ThisGameData.ApplicationVersionNumber = Version010000;
		ThisGameData.IsNewHighScore = false;
		ThisGameData.CMajorHighScore = 0;
		ThisGameData.DMajorHighScore = 0;
		ThisGameData.EMajorHighScore = 0;
		ThisGameData.FMajorHighScore = 0;
		ThisGameData.GMajorHighScore = 0;
		ThisGameData.AMajorHighScore = 0;
		ThisGameData.BMajorHighScore = 0;
		ThisGameData.CMinorHighScore = 0;
		ThisGameData.DMinorHighScore = 0;
		ThisGameData.EMinorHighScore = 0;
		ThisGameData.FMinorHighScore = 0;
		ThisGameData.GMinorHighScore = 0;
		ThisGameData.AMinorHighScore = 0;
		ThisGameData.BMinorHighScore = 0;
		ThisGameData.CMajorHighScoreStars = 0;
		ThisGameData.DMajorHighScoreStars = 0;
		ThisGameData.EMajorHighScoreStars = 0;
		ThisGameData.FMajorHighScoreStars = 0;
		ThisGameData.GMajorHighScoreStars = 0;
		ThisGameData.AMajorHighScoreStars = 0;
		ThisGameData.BMajorHighScoreStars = 0;
		ThisGameData.CMinorHighScoreStars = 0;
		ThisGameData.DMinorHighScoreStars = 0;
		ThisGameData.EMinorHighScoreStars = 0;
		ThisGameData.FMinorHighScoreStars = 0;
		ThisGameData.GMinorHighScoreStars = 0;
		ThisGameData.AMinorHighScoreStars = 0;
		ThisGameData.BMinorHighScoreStars = 0;
		ThisGameData.CMajorHighScoreItems = 0;
		ThisGameData.DMajorHighScoreItems = 0;
		ThisGameData.EMajorHighScoreItems = 0;
		ThisGameData.FMajorHighScoreItems = 0;
		ThisGameData.GMajorHighScoreItems = 0;
		ThisGameData.AMajorHighScoreItems = 0;
		ThisGameData.BMajorHighScoreItems = 0;
		ThisGameData.CMinorHighScoreItems = 0;
		ThisGameData.DMinorHighScoreItems = 0;
		ThisGameData.EMinorHighScoreItems = 0;
		ThisGameData.FMinorHighScoreItems = 0;
		ThisGameData.GMinorHighScoreItems = 0;
		ThisGameData.AMinorHighScoreItems = 0;
		ThisGameData.BMinorHighScoreItems = 0;	
		ThisGameData.CurrentLevelSelected = "";
		ThisGameData.CurrentScaleSelected = "";
		ThisGameData.CurrentLevelScore = 0;
		ThisGameData.CurrentLevelCorrect = 0;
		ThisGameData.CurrentLevelMissed = 0;
		ThisGameData.CurrentLevelStars = 0;
		ThisGameData.CurrentLevelTimeBonus = 0;
		ThisGameData.CurrentLevelCompleteStarTotalScore = 0;
		ThisGameData.CurrentLevelCompleteTimeTotalScore = 0;
		ThisGameData.CurrentLevelCompleteItemTotalScore = 0;
		ThisGameData.CurrentLevelCompleteGrandTotalScore = 0;
		ThisGameData.CMajorScaleUnLocked = true;
		ThisGameData.DMajorScaleUnLocked = false;
		ThisGameData.EMajorScaleUnLocked = false;
		ThisGameData.FMajorScaleUnLocked = false;
		ThisGameData.GMajorScaleUnLocked = false;
		ThisGameData.AMajorScaleUnLocked = false;
		ThisGameData.BMajorScaleUnLocked = false;
		ThisGameData.CMinorScaleUnLocked = true;
		ThisGameData.DMinorScaleUnLocked = false;
		ThisGameData.EMinorScaleUnLocked = false;
		ThisGameData.FMinorScaleUnLocked = false;
		ThisGameData.GMinorScaleUnLocked = false;
		ThisGameData.AMinorScaleUnLocked = false;
		ThisGameData.BMinorScaleUnLocked = false;
		ThisGameData.CMajorHighScoreBonusTime = 0;
		ThisGameData.DMajorHighScoreBonusTime = 0;
		ThisGameData.EMajorHighScoreBonusTime = 0;
		ThisGameData.FMajorHighScoreBonusTime = 0;
		ThisGameData.GMajorHighScoreBonusTime = 0;
		ThisGameData.AMajorHighScoreBonusTime = 0;
		ThisGameData.BMajorHighScoreBonusTime = 0;
		ThisGameData.CMinorHighScoreBonusTime = 0;
		ThisGameData.DMinorHighScoreBonusTime = 0;
		ThisGameData.EMinorHighScoreBonusTime = 0;
		ThisGameData.FMinorHighScoreBonusTime = 0;
		ThisGameData.GMinorHighScoreBonusTime = 0;
		ThisGameData.AMinorHighScoreBonusTime = 0;
		ThisGameData.BMinorHighScoreBonusTime = 0;
	}

	//public static void CurrentGameDate() {
	//	ThisGameData = new GameSaveData ();
   //	}
}


public static class SaveFactory {

	//private static string AppFileName = Application.persistentDataPath + "/FileName.dat";

	public static void SaveGameData() {
		BinaryFormatter bf = new BinaryFormatter();
		using (FileStream file = File.Open (Application.persistentDataPath + "/settings.txt", FileMode.Create)) {						
			bf.Serialize (file, CurrentGameData.ThisGameData);
		file.Close ();
		};

		}

	public static void DeleteGameData() {
		File.Delete(Application.persistentDataPath + "/settings.txt");
	}
		
	public static void GetGameData() {
		if (File.Exists (Application.persistentDataPath + "/settings.txt")) {
			BinaryFormatter bf = new BinaryFormatter ();
			using (FileStream file = File.Open (Application.persistentDataPath + "/settings.txt", FileMode.Open)) {
				CurrentGameData.ThisGameData = (GameSaveData)bf.Deserialize (file);
				file.Close ();
			}
		} else {			
			using (FileStream file = File.Create (Application.persistentDataPath + "/settings.txt")) {

			}
			CurrentGameData.InitializeGameData();
			SaveGameData ();
		}
	}
		
	public static bool DoesGameDataExist() {
		if (File.Exists (Application.persistentDataPath + "/settings.txt")) {
			return true;
		} else {
			return false;
		}		

	}

}


[System.Serializable] 
public class GameSaveData {
	public bool IsNewHighScore { get; set; }
	public string CurrentLevelSelected {get; set;}
	public string CurrentScaleSelected { get; set; }
	public int CurrentLevelScore {get; set;}
	public int CurrentLevelCorrect {get; set;}
	public int CurrentLevelMissed {get; set;}
	public int CurrentLevelStars { get; set;}
	public int CurrentLevelTimeBonus { get; set; }
	public int CurrentLevelCompleteStarTotalScore { get; set; }
	public int CurrentLevelCompleteTimeTotalScore { get; set; }
	public int CurrentLevelCompleteItemTotalScore { get; set; }
	public int CurrentLevelCompleteGrandTotalScore { get; set; }
	public bool CMajorScaleUnLocked {get; set;}
	public bool DMajorScaleUnLocked {get; set;}
	public bool EMajorScaleUnLocked {get; set;}
	public bool FMajorScaleUnLocked {get; set;}
	public bool GMajorScaleUnLocked {get; set;}
	public bool AMajorScaleUnLocked {get; set;}
	public bool BMajorScaleUnLocked {get; set;}
	public bool CMinorScaleUnLocked {get; set;}
	public bool DMinorScaleUnLocked {get; set;}
	public bool EMinorScaleUnLocked {get; set;}
	public bool FMinorScaleUnLocked {get; set;}
	public bool GMinorScaleUnLocked {get; set;}
	public bool AMinorScaleUnLocked {get; set;}
	public bool BMinorScaleUnLocked {get; set;}
	public int CMajorHighScore {get; set;}
	public int DMajorHighScore {get; set;}
	public int EMajorHighScore {get; set;}
	public int FMajorHighScore {get; set;}
	public int GMajorHighScore {get; set;}
	public int AMajorHighScore {get; set;}
	public int BMajorHighScore {get; set;}
	public int CMinorHighScore {get; set;}
	public int DMinorHighScore {get; set;}
	public int EMinorHighScore {get; set;}
	public int FMinorHighScore {get; set;}
	public int GMinorHighScore {get; set;}
	public int AMinorHighScore {get; set;}
	public int BMinorHighScore {get; set;}
	public int CMajorHighScoreStars {get; set;}
	public int DMajorHighScoreStars {get; set;}
	public int EMajorHighScoreStars {get; set;}
	public int FMajorHighScoreStars {get; set;}
	public int GMajorHighScoreStars {get; set;}
	public int AMajorHighScoreStars {get; set;}
	public int BMajorHighScoreStars {get; set;}
	public int CMinorHighScoreStars {get; set;}
	public int DMinorHighScoreStars {get; set;}
	public int EMinorHighScoreStars {get; set;}
	public int FMinorHighScoreStars {get; set;}
	public int GMinorHighScoreStars {get; set;}
	public int AMinorHighScoreStars {get; set;}
	public int BMinorHighScoreStars {get; set;}
	public int CMajorHighScoreItems {get; set;}
	public int DMajorHighScoreItems {get; set;}
	public int EMajorHighScoreItems {get; set;}
	public int FMajorHighScoreItems {get; set;}
	public int GMajorHighScoreItems {get; set;}
	public int AMajorHighScoreItems {get; set;}
	public int BMajorHighScoreItems {get; set;}
	public int CMinorHighScoreItems {get; set;}
	public int DMinorHighScoreItems {get; set;}
	public int EMinorHighScoreItems {get; set;}
	public int FMinorHighScoreItems {get; set;}
	public int GMinorHighScoreItems {get; set;}
	public int AMinorHighScoreItems {get; set;}
	public int BMinorHighScoreItems {get; set;}
	public int CMajorHighScoreBonusTime {get; set;}
	public int DMajorHighScoreBonusTime {get; set;}
	public int EMajorHighScoreBonusTime {get; set;}
	public int FMajorHighScoreBonusTime {get; set;}
	public int GMajorHighScoreBonusTime {get; set;}
	public int AMajorHighScoreBonusTime {get; set;}
	public int BMajorHighScoreBonusTime {get; set;}
	public int CMinorHighScoreBonusTime {get; set;}
	public int DMinorHighScoreBonusTime {get; set;}
	public int EMinorHighScoreBonusTime {get; set;}
	public int FMinorHighScoreBonusTime {get; set;}
	public int GMinorHighScoreBonusTime {get; set;}
	public int AMinorHighScoreBonusTime {get; set;}
	public int BMinorHighScoreBonusTime {get; set;}
	public string ApplicationVersionNumber { get; set;}
}

