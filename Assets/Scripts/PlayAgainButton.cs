using UnityEngine;
using System.Collections;

public class PlayAgainButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Debug.Log ("MouseDown");
		Application.LoadLevel("MainLevel");
	}

}
