using UnityEngine;
using System.Collections;

public class CloudBlockScript : MonoBehaviour {

	public string playerName1 = "Player(Clone)";
	public string playerName2 = "Player2(Clone)";
	public string name = "CloudBlock";
	private GameObject player1;
	private GameObject player2;
	private bool colliderEnabled = true;
	
	//Find player by name
	void Start () {
		player1 = GameObject.Find(playerName1);
		if (player1 == null) Debug.LogError("(One Way Platform) Please enter correct player name in Inspector for: " + gameObject.name);
		player2 = GameObject.Find(playerName2);
		if (player2 == null) Debug.LogError("(One Way Platform) Please enter correct player name in Inspector for: " + gameObject.name);

	}
	
	//Check to see if player is under the platform. Collide only if the player is above the platform.
	void FixedUpdate () {
		if (!colliderEnabled) 
		{
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
		}
		else
			gameObject.GetComponent<BoxCollider2D>().enabled = true;



		/*if (player1 != null && player2 != null) {
			if ((player1.transform.position.y < this.transform.position.y) || (player2.transform.position.y < this.transform.position.y)) 
			{
				gameObject.GetComponent<BoxCollider2D>().enabled = false;
			}
			else 
			{
				gameObject.GetComponent<BoxCollider2D>().enabled = true;
			}
			  
		}*/

	}

	public void DisableCollider()
	{
		colliderEnabled = false;
		//gameObject.GetComponent<BoxCollider2D>().enabled = false;
	}

	//void OnTriggerEnter2D(Collider2D otherCollider)
	//{
	//	gameObject.GetComponent<BoxCollider2D>().enabled = false;

	//}


	public void EnableCollider()
	{
		colliderEnabled = true;
		//gameObject.GetComponent<BoxCollider2D>().enabled = false;
	}


	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if (otherCollider.GetComponent<Collider2D> ().tag == "Player1") 
		{
			//Debug.Log ("Player1 Cloud Block");
		}
	}

	public bool isUnderneath(int player)
	{
		if (player == 1) {
			if (player1.transform.position.y < this.transform.position.y) 
			{
				return true;
			}
			else return false;
		} 
		else 
		{
			if (player2.transform.position.y < this.transform.position.y) 
			{
				return true;
			}
			else return false;

		}
	}
}
