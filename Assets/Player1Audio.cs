using UnityEngine;
using System.Collections;

public class Player1Audio : MonoBehaviour {

    public AudioClip jumpSound;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;


    // Use this for initialization
    void Start () {

        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        float inputY = Input.GetAxis("VerticalP1");

        if (inputY > 0.1f)
        {
            if (!source.isPlaying)
            {
                //just example for playoneShot! maybe with settings later??
                //taken from https://unity3d.com/learn/tutorials/modules/beginner/live-training-archive/sound-effects-scripting
                float vol = Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(jumpSound, vol);

            }
        }
    }
}
