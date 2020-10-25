using UnityEngine;
using UnityEngine.UI;
using System.Collections;


/// <summary>
/// Used to cross fade the answer results
/// </summary>
public class ResultsAnime : MonoBehaviour {

	public Image resultImg;

	public bool reverseAnime;
	public bool stopAnime;
	float hw;
	// Use this for initialization
	void Start () {

	}

	void OnEnable() {		
		resultImg.CrossFadeAlpha (0.0f, 2.2f,false);
	}

	// Update is called once per frame
	void Update () {
		



	}
}