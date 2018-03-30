using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GunEffectController : MonoBehaviour {

    public GameObject[] muzzleFlash;
    public GameObject muzzleLight;
    public Animation anim;
    public AudioClip shotEffect;

    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        for (int i = 0; i < muzzleFlash.Length; i++)
        {
            muzzleFlash[i].SetActive(false);

        }
    }

    public void Play() {
        muzzleLight.SetActive(true);
        anim.Rewind();
        anim.Play();
        audioSource.pitch = Random.Range(1.1f, 0.9f);
        audioSource.PlayOneShot(shotEffect);


        int r = Random.Range(0, muzzleFlash.Length);

        for (int i = 0; i < muzzleFlash.Length; i++)
        {
            if (r == i)
            {
                muzzleFlash[i].SetActive(true);
                Invoke("DeactivateMuzzle", 0.035f);
            }

        }
    }

    void DeactivateMuzzle()
    {
        muzzleLight.SetActive(false);
        for (int i = 0; i < muzzleFlash.Length; i++)
        {
            muzzleFlash[i].SetActive(false);

        }
    }

}
