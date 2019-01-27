using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {
    public float Damage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        var sebastian = other.GetComponent<BirdMovement>();
        if (sebastian != null) {
            sebastian.FuckedUpMeter += Damage;
            SoundManager.Instance.PlayHitSound();
        }
    }
}
