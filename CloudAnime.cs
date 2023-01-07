using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class CloudAnime : MonoBehaviour {

	public Image imgCloud;
	public Image imgStart;
	public Image imgEnd;

	public float cloudspeed = 3f;

	private float sw;

	void Start () {
		sw = Screen.width;
		Debug.Log (sw);
	}

	// Update is called once per frame
	void Update () {

	//	RectTransform rt = imgCloud.rectTransform;
	//	imgCloudWidth = rt.rect.width;

		Vector3 pos = imgCloud.transform.position;
		Vector3 startPos = imgStart.transform.position;
		Vector3 endPos = imgEnd.transform.position;

	
		if (pos.x < endPos.x) {		
			Vector3 setThis = new Vector3 (startPos.x, imgCloud.transform.position.y);	
			imgCloud.transform.position = setThis;
		}
			else 
		{
			pos.x -= cloudspeed;
			imgCloud.transform.position = pos;
		}







	}
}
