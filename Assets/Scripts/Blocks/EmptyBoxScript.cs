using UnityEngine;
using System.Collections;
using Assets.Scripts;


public class EmptyBoxScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnMouseDown () 
	{
		float yCoord = this.transform.position.y;
		float xCoord = this.transform.position.x;
		MapCreatorManager.Instance.TellGmWhatPosition (xCoord, yCoord);


	}
}
