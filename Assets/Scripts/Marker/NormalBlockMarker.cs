using UnityEngine;
using System.Collections;
using Assets.Scripts;
namespace Assets.Scripts.Markers
{
	public class NormalBlockMarker : MonoBehaviour {

		public GameObject NormalBlockPrefab;
	
		// Use this for initialization
		void Start () {
	
		}
	
		// Update is called once per frame
		void Update () {
	
		}

		public void OnMouseDown () 
		{
			MapCreatorManager.Instance.TellGmWhatMarker (NormalBlockPrefab);
		}

	}
}
