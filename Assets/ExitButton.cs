using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {


	private bool bShow = false;


	void OnGUI() {
		if (bShow) 
		{
			GUI.Box (new Rect (10, 10, 120, 70), "Are you sure?");
			//GUI.Button();
			if(GUI.Button(new Rect(10,55,60,20),"Yes"))
			{
				Debug.Log ("Close Game!");
				ExitGame();
			}
			if(GUI.Button(new Rect(70,55,60,20),"Cancel"))
			{
				Debug.Log ("No");
				bShow = false;
			}
			
		}
	}

	public void ExitGame () //This function will be used on our "Yes" button in our Quit menu
		
	{
		Debug.Log ("Quit Application");
		Application.Quit(); //this will quit our game. Note this will only work after building the game
		
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () 
	{
		bShow = true;
		
	}

}
