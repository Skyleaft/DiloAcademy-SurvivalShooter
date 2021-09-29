using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adrenaline : MonoBehaviour
{
    [SerializeField] private Collider colider;
    [SerializeField] private float rotatespeed = 80f;
    [SerializeField] private float speedBonus;
    [SerializeField] private float boostDuration;
    [SerializeField] private AudioClip sfx;

    private PlayerMovement player;
    private AudioSource audioPlayer;


    void Update()
    {
        transform.Rotate(0, Time.deltaTime * rotatespeed, 0, Space.Self);
    }

    public void PullTrigger(Collider other)
    {
        //Debug.Log(other.gameObject.tag);

        //jika kena detector
        if (other.gameObject.tag == "Player")
        {
            //ambil component player move
            player = other.gameObject.GetComponent<PlayerMovement>();
            audioPlayer = ItemManager.Instance.gameObject.GetComponent<AudioSource>();
        }
        //jika kena player
        if (other.gameObject.tag == "PlayerCollider")
        {
            audioPlayer.clip = sfx;
            audioPlayer.Play();
            player.adrenalineDuration += boostDuration;
            player.speedboost = speedBonus;
            Destroy(transform.parent.gameObject);
        }

    }
}
