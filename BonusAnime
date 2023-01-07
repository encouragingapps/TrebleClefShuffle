using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BonusAnime : MonoBehaviour {

	public Image objImg;
	public bool reverseAnime;
	public float speed = 3f;

	//public bool stopAnime;


	float hw;
	float max_hw;
	float min_hw;
	// Use this for initialization
	void Start () {
		
		hw = objImg.transform.localScale.x;	
	
		max_hw = ((hw) * .3f) + (hw);
		min_hw = hw;
	}

	// Update is called once per frame
	void Update () {

		if (!reverseAnime) {			
			hw += speed;
			objImg.transform.localScale = new Vector2 (hw, hw);
			if(hw>max_hw) { reverseAnime = true; }; 
		}
		else {
			hw -= speed;
			objImg.transform.localScale = new Vector2 (hw, hw);
			if(hw < min_hw) { reverseAnime = false;}

		}



	}
}
