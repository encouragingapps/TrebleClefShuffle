using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;


public static class CommonUtils {

	public static bool IsStringEmpty(string Val) {

		if (Val == null) {
			return true;
		}

		if (Val == "") {
			return true;
		}

		return false;

	}

	public static string FormatScoreTotal(int Val) {
		return Val.ToString ().PadLeft (5, '0');
	}

	public static bool IsEveryNthLine(int LineIncrement, int QuestionCount) {
		if (QuestionCount % LineIncrement == 0 && QuestionCount != 0) 
		{ 
			return true;
		}
		else {
			return false;
		}
	}

	public static bool AreStringsEqual(string Val1, string Val2, bool MatchCase=false) {
	
		//1st we need to handle null values
		if (Val1 == null) {
			Val1 = string.Empty;
		}

		if (Val2 == null) {
			Val2 = string.Empty;
		}

		if (MatchCase) {
			if (Val1 == Val2) {
				return true;
			} else {
				return false;
			}
		} else 
			{
				Val1 = Val1.ToUpper();
				Val2 = Val2.ToUpper();

			if (Val1 == Val2) {
				return true;
			}
			else {
					return false;
				}
			}
		}
		
	public static string GetFormattedMinutesAndSeconds(int minutes, int seconds) {
		return string.Format ("{0:0}:{1:00}", minutes, seconds);
	}

	public static string GetFormattedTime(float thisTime) {
		string returnStr;
		returnStr = (thisTime % 60).ToString ("00");
		return returnStr;
	}

	public static string Int32ToString(int? Val) {
		if (Val.HasValue) {
			return Val.ToString ();
		} else {
			return null;
		}
		
	}


	//Numeric Type	Method
	//decimal	ToDecimal(String)
	//float	ToSingle(String)
	//double	ToDouble(String)
	//short	ToInt16(String)
	//int	ToInt32(String)
	//long	ToInt64(String)
	//ushort	ToUInt16(String)
	//uint	ToUInt32(String)
	//ulong	ToUInt64(String)



}
