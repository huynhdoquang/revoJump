using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public static AudioController Instance;
    public AudioClip pickCoinSound;
    public AudioClip jumpSound;
    public AudioClip dieSound;

    public AudioSource audioSource;

    private void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayPickUpCoinSound()
    {
        audioSource.PlayOneShot(pickCoinSound);
    }
    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }
    public void PlayDieSound()
    {
        audioSource.PlayOneShot(dieSound);
    }
}
