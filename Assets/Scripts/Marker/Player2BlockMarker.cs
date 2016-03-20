using UnityEngine;
using System.Collections;
using Assets.Scripts;
namespace Assets.Scripts.Markers
{
	public class Player2BlockMarker : MonoBehaviour {

		public GameObject Player2BlockPrefab;
	
		// Use this for initialization
		void Start () {
	
		}
	
		// Update is called once per frame
		void Update () {
	
		}

		public void OnMouseDown () 
		{
			MapCreatorManager.Instance.TellGmWhatMarker (Player2BlockPrefab);
		}

	}
}
