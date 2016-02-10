using UnityEngine;
using System.Collections;
using Assets.Scripts;
namespace Assets.Scripts.Markers
{
	public class Player1BlockMarker : MonoBehaviour {

		public GameObject Player1BlockPrefab;
	
		// Use this for initialization
		void Start () {
	
		}
	
		// Update is called once per frame
		void Update () {
	
		}

		void OnMouseDown () 
		{
			MapCreatorManager.Instance.TellGmWhatMarker (Player1BlockPrefab);
		}

	}
}
