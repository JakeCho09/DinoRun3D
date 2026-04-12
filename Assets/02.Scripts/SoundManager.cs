using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource doorHit;
    public AudioSource dinoHit;
    public AudioSource dinoDie;
    public AudioSource dinoClear;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        

    }

    public void DoorHitPlay()
    {
        doorHit.Play();
    }

    public void DinoHitPlay()
    {
        dinoHit.Play();
    }

    public void Die()
    {
        dinoDie.Play();
    }

    public void PlayClear()
    {
        dinoClear.Play();
    }
}
