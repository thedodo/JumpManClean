using UnityEngine;
using System.Collections;

public class FallDeath : MonoBehaviour
{

    public string name = "FallDeath";


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D otherCollider)
    {

        if (otherCollider.GetComponent<Collider2D>().tag == "Player1")
        {
            Player1Script player1 = otherCollider.gameObject.GetComponent<Player1Script>();
            StartCoroutine(player1.Die());

        }
        else
        {
            Player2Script player2 = otherCollider.gameObject.GetComponent<Player2Script>();
            StartCoroutine(player2.Die());
        }
    }

}
