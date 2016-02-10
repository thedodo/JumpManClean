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
	void Start () {
		Dictionary<Vector2, GameObject> prefabDic = MapCreatorManager.Instance.getMapPrefabDic ();
		foreach (KeyValuePair<Vector2, GameObject> pair in prefabDic)
		{
			if(pair.Value.tag == "Player1")
			{
				Instantiate(Player1, pair.Key, Quaternion.identity);
				pair.Value.SetActive(false);
				UnityEngine.Object.Destroy(pair.Value);

			}

			if(pair.Value.tag == "Player2")
			{
				Instantiate(Player2, pair.Key, Quaternion.identity);
				pair.Value.SetActive(false);
				UnityEngine.Object.Destroy(pair.Value);


			}

			if(pair.Value.tag == "CloudBlock")
			{
				Instantiate(CloudBlock,pair.Key,Quaternion.identity);
				pair.Value.SetActive(false);
				UnityEngine.Object.Destroy(pair.Value);


			}

			if(pair.Value.tag == "BreakableBlock")
			{
				Instantiate(BreakableBlock,pair.Key,Quaternion.identity);
				pair.Value.SetActive(false);
				UnityEngine.Object.Destroy(pair.Value);
				
			}

		}
	
	}

	void OnLevelWasLoaded(int level) {


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
