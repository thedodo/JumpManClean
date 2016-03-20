using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreateNewMapButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseDown () 
	{
		Debug.Log ("Create Map Button pressed!");
        SceneManager.LoadScene(1);
	}

}
