using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointsAnime : MonoBehaviour {

	public Text pointTxt;
	public bool reverseAnime;
	public bool stopAnime;
	float hw;
	// Use this for initialization
	void Start () {

	}

	void OnEnable() {
		hw = 1.1f;
		reverseAnime = false;
		stopAnime = false;
		pointTxt.CrossFadeAlpha (0.0f, 1,false);
	}

	// Update is called once per frame
	void Update () {

		if(stopAnime) { 			
			return; };

		if (!reverseAnime) {
			hw += 0.1f;
			pointTxt.transform.localScale = new Vector2 (hw, hw);

			if(hw>3) { reverseAnime = true; }; 
		}
		else {
			hw -= 0.1f;
			pointTxt.transform.localScale = new Vector2 (hw, hw);
			if(hw < 1.0f) {	stopAnime = true;}

		}



	}
}
