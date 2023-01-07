using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarAnime : MonoBehaviour
{

	public Image starPlayer;
	public bool reverseAnime;
	public bool stopAnime;


	float hw;
	// Use this for initialization
	void Start()
	{
		hw = 1.1f;
		reverseAnime = false;
		stopAnime = false;

	}

	// Update is called once per frame
	void Update()
	{

		if (stopAnime) { return; };

		if (!reverseAnime)
		{
			hw += 0.1f;
			starPlayer.transform.localScale = new Vector2(hw, hw);
			if (hw > 2) { reverseAnime = true; };
		}
		else
		{
			hw -= 0.1f;
			starPlayer.transform.localScale = new Vector2(hw, hw);
			if (hw < 1.1f) { stopAnime = true; }

		}



	}
}
