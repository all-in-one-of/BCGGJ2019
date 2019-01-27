using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager Instance;
    
    public AudioClip WingFlap;

    public AudioClip Babies;

    public AudioClip PickUpFood;

    public AudioClip GettingHit;
    
    public AudioClip Level;

    private AudioSource _source;

    private void Awake() {
        if (Instance != null) {
            Destroy(Instance.gameObject);
        }

        Instance = this;
        
        _source = GetComponent<AudioSource>();
    }


    private float _nextTimeBaby;
    
    // Start is called before the first frame update
    void Start() {
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        _nextTimeBaby -= Time.deltaTime;
        
        if (_nextTimeBaby < 0) {
            PlayChipSound();
            _nextTimeBaby = 2 + 5 * HungerChicks.Instance.ChickHunger / 100;
        }
    }


    public void PlayChipSound() {
        _source.PlayOneShot(Babies);
    }
    
    public void PlayHitSound() {
        _source.PlayOneShot(GettingHit);
    }

    public void PlayPickUpFood() {
        _source.PlayOneShot(PickUpFood);
    }

    public void PlayWingFlap() {
        _source.PlayOneShot(WingFlap);
    }
    
    
}
