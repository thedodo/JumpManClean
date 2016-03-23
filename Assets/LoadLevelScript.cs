using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;

public class LoadLevelScript : MonoBehaviour {

	public GameObject BreakableBlock;
	public GameObject CloudBlock;
	public GameObject IceBlock;
	public GameObject JumpBlock;
	public GameObject LavaBlock;
	public GameObject MovingPlatform;
	public GameObject NormalBlock;
	public GameObject SpikeBlock;
	public GameObject Player1;
	public GameObject Player2;


	

	// Use this for initialization
    //HOW TO GET THE Z VALUES?????
	void Start () {
		Dictionary<Vector3, GameObject> prefabDic = MapCreatorManager.Instance.getMapPrefabDic ();
		foreach (KeyValuePair<Vector3, GameObject> pair in prefabDic)
		{

			if(pair.Value.tag == "Player1")
			{
				GameObject player1 = (GameObject)Instantiate(Player1, pair.Key, Quaternion.identity);
				UnityEngine.Object.Destroy(pair.Value);
                Vector3 scale = new Vector3(player1.transform.localScale.x * 3, player1.transform.localScale.y * 3, player1.transform.localScale.z);
                player1.transform.localScale = scale;
            }


            if (pair.Value.tag == "Player2")
			{
                GameObject player2 = (GameObject)Instantiate(Player2, pair.Key, Quaternion.identity);
                UnityEngine.Object.Destroy(pair.Value);
                Vector3 scale = new Vector3(player2.transform.localScale.x * 3, player2.transform.localScale.y * 3, player2.transform.localScale.z);
                player2.transform.localScale = scale;
            }


			if(pair.Value.tag == "CloudBlock")
			{
				GameObject cloudblock = (GameObject)Instantiate(CloudBlock,pair.Key,Quaternion.identity);
				UnityEngine.Object.Destroy(pair.Value);
                Vector3 scale = new Vector3(cloudblock.transform.localScale.x * 3, cloudblock.transform.localScale.y * 3, cloudblock.transform.localScale.z);
                cloudblock.transform.localScale = scale;
            }


			if(pair.Value.tag == "BreakableBlock")
			{
				GameObject breakableblock = (GameObject)Instantiate(BreakableBlock,pair.Key,Quaternion.identity);
				UnityEngine.Object.Destroy(pair.Value);
                Vector3 scale = new Vector3(breakableblock.transform.localScale.x * 3, breakableblock.transform.localScale.y * 3, breakableblock.transform.localScale.z);
                breakableblock.transform.localScale = scale;
            }

		}
	}

	void OnLevelWasLoaded(int level) {


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
