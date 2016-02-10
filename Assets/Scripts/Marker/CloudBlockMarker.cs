using UnityEngine;
using System.Collections;
using Assets.Scripts;
namespace Assets.Scripts.Markers
{
	public class CloudBlockMarker : MonoBehaviour {

		public GameObject CloudBlockPrefab;
	
		// Use this for initialization
		void Start () {
	
		}
	
		// Update is called once per frame
		void Update () {
	
		}

		void OnMouseDown () 
		{
			MapCreatorManager.Instance.TellGmWhatMarker (CloudBlockPrefab);
		}

	}
}
