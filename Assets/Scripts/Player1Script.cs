using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player1Script : MonoBehaviour {

	public Vector3 p1spawn = new Vector3(0,0,0);

	public float maxSpeed = 10;
	public float acceleration = 35;
	public float jumpSpeed = 8;
	public float jumpDuration;


	public Text scoreTextP1;
	private int score1;
	private bool P1isFirst = false;
	bool isDead = false;
	private Animator animator;                  //Used to store a reference to the Player's animator component.
	private Renderer renderer;
	private Rigidbody2D rigidbody2d;



	bool jumpKeyDown = false;
	bool canVariableJump = false;
	float jmpDuration;



	public EdgeCollider2D hitCollider;
	

	// Use this for initialization
	void Start () {

		//initCount();
		animator = GetComponent<Animator>();
		renderer = GetComponent<Renderer> ();
		rigidbody2d = GetComponent<Rigidbody2D> ();
		p1spawn.x = transform.position.x;
		p1spawn.y = transform.position.y;
	}

	private bool isGrounded()
	{
		//search length (length of vector for raycast)
		float rayCastLenght = 0.2f;
		//so that we don't detect own collider/ collider of player
		float colliderOffset = 0.01f;
		//origin of linecast
		Vector2 origin = new Vector2 (this.transform.position.x, this.transform.position.y - renderer.bounds.extents.y - colliderOffset);
		//set direction of linecast
		Vector2 direction = new Vector2 (this.transform.position.x, origin.y - rayCastLenght);

		RaycastHit2D hit = Physics2D.Linecast (origin, direction);


		return hit;
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log ("Spawn: " +p1spawn.x +" " + p1spawn.y);

		if (score1 == 10) 
		{
			Application.LoadLevel("Player1Won");
		}
	}


	void setRunAnimation()
	{
		animator.SetTrigger("player1_run");
	}

	void setJumpAnimation()
	{
		animator.SetTrigger("player1_jump");
	}


	void FixedUpdate()
	{
		// 3 - Retrieve axis information
		float inputX = Input.GetAxis ("HorizontalP1");


		if(inputX < -0.1f) 
		{
			setRunAnimation();
			transform.localRotation = Quaternion.Euler (0, 0, 0);
			if(rigidbody2d.velocity.x > -this.maxSpeed)
			{
				rigidbody2d.AddForce(new Vector2(-this.acceleration, 0.0f));
			}
			else
			{
				rigidbody2d.velocity = new Vector2(-this.maxSpeed, rigidbody2d.velocity.y);
			}
		}

		else if (inputX > 0.1f) 
		{
			setRunAnimation();
			transform.localRotation = Quaternion.Euler (0, 180, 0);

			if(rigidbody2d.velocity.x < this.maxSpeed)
			{
				rigidbody2d.AddForce(new Vector2(this.acceleration, 0.0f));
			}
			else
			{
				rigidbody2d.velocity = new Vector2(this.maxSpeed, rigidbody2d.velocity.y);
			}

		}


		bool grounded = isGrounded ();
			
		float inputY = Input.GetAxis ("VerticalP1");
			
		if (inputY > 0.1f) 
		{
			setJumpAnimation();
			if(!jumpKeyDown) //1st frame!
			{
				jumpKeyDown = true;
				if(grounded)
				{
					rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, this.jumpSpeed);
					jumpDuration = 0.0f;
					canVariableJump = true;
				}
			}
			//2nd frame
			else if(canVariableJump)
			{
				//add to duration of jump
				jmpDuration += Time.deltaTime;
				// / 1000 to convert miliseconds to seconds
				if(jmpDuration < this.jumpDuration / 1000)
				{
					rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, this.jumpSpeed);
				}
			}

		}
		else
		{
			jumpKeyDown = false;
			canVariableJump = false;
		}
	}

	void initCount()
	{
		score1 = 0;
//		scoreTextP1.text = "P1: " + score1.ToString ();

	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		Player2Script player2 = otherCollider.gameObject.GetComponent<Player2Script>();
		if (otherCollider.GetComponent<Collider2D> ().tag == "Player2") 
		{
			if (!player2.getisFirst ()) {
				score1++;
				P1isFirst = true;
				StartCoroutine(player2.Die());
				//scoreTextP1.text = "P1: " + score1.ToString ();
			}
		}
		if (otherCollider.GetComponent<Collider2D> ().tag == "BreakableBlock") 
		{
			BreakableBlockScript block2 = otherCollider.gameObject.GetComponent<BreakableBlockScript>();
			if(block2.isUnderneathBreakable(1))
			{
				StartCoroutine(block2.DestroyBlock());
			}
		}

		if (otherCollider.GetComponent<Collider2D> ().tag == "CloudBlock") 
		{
			CloudBlockScript block = otherCollider.gameObject.GetComponent<CloudBlockScript>();
			if(block.isUnderneath(1))
			{
				block.DisableCollider();
			}
		}

	}

	void OnTriggerExit2D(Collider2D otherCollider)
	{
		P1isFirst = false;

		if (otherCollider.GetComponent<Collider2D> ().tag == "CloudBlock") 
		{
			CloudBlockScript block = otherCollider.gameObject.GetComponent<CloudBlockScript>();
			if(!block.isUnderneath(1))
			{
				block.EnableCollider();
			}
		}

	}

	public IEnumerator Die()
	{	
		isDead = true;
		Debug.Log ("Coroutine player1 die");
		animator.Play("player1_death");
		yield return new WaitForSeconds(1);
		StartCoroutine (Respawn ());
	}

	public bool getisFirst()
	{
		return P1isFirst;
	}

	IEnumerator Respawn()
	{
		this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
		yield return new WaitForSeconds(1);
		Debug.Log ("respawn");
		this.gameObject.GetComponent<SpriteRenderer>().enabled  = true;
		animator.SetTrigger("player1_respawn");
		Debug.Log ("spawn to: " + p1spawn.x + " " + p1spawn.y);
		transform.position = p1spawn;

	}


}
