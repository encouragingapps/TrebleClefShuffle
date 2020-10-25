using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public enum eGameState {
	GameIsStarting,
	StartNextQuestion,
	WaitingForAnswer,
	QuestionTimeUp,
	AnswerCorrect,
	AnswerIncorrect,
	DisplayResults,
	LevelIsComplete,
	GameIsOver,
	GameTimeIsUp
};

public enum eGameLevelCompleteState {	
	StarBonusCountDownStarted,
	StarBonusCountDownCompleted,
	TimeBonusCountDownStarted,
	TimeBonusCountDownCompleted,
	ItemBonusCountDownStarted,
	ItemBonusCountDownCompleted
}


public enum eResults {
	Correct,
	Incorrect,
	Missed,
	TimesUp
}

public enum eMajorScales {
	AMajor,
	BMajor,
	CMajor,
	DMajor,
	GMajor,
	EMajor,
	FMajor
}

public enum eNotePitch {
	Natural,
	Sharp,
	Flat
}

public enum eScoringPointType {
	StandardPoint,
	BonusPoint,
	TimeBonusPoint,
	PickupItemPoint
}

public enum eLevelType {
	Major,
	Minor
}

