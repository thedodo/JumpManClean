using UnityEngine;
using System.Collections;

public class BreakableBlockScript : MonoBehaviour {

	private Animator animator;                  //Used to store a reference to the Player's animator component.
	public string playerName1 = "Player(Clone)";
	public string playerName2 = "Player2(Clone)";
	public string name = "BreakableBlock";
	private GameObject player1;
	private GameObject player2;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		player1 = GameObject.Find(playerName1);
		if (player1 == null) Debug.LogError("(One Way Platform) Please enter correct player name in Inspector for: " + gameObject.name);
		player2 = GameObject.Find(playerName2);
		if (player2 == null) Debug.LogError("(One Way Platform) Please enter correct player name in Inspector for: " + gameObject.name);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D otherCollider)
	{
	}


	public bool isUnderneathBreakable(int player)
	{
		Debug.Log("underneath called");
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


	public IEnumerator DestroyBlock()
	{
		animator.SetTrigger("destroy");
		yield return new WaitForSeconds(0.5f);
		Destroy (this.gameObject);

	}



}
