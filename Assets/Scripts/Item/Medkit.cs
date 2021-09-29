using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    [SerializeField] private float rotatespeed = 50f;
    [SerializeField] private int healthBonus;
    [SerializeField] private AudioClip sfx;

    private PlayerHealth player;
    private AudioSource audioPlayer;

    void Update()
    {
        transform.Rotate(0, Time.deltaTime * rotatespeed, 0, Space.Self);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.tag);

        //jika kena detector
        if(other.gameObject.tag == "Player")
        {
            //ambil value darah dari tag player
            player = other.gameObject.GetComponent<PlayerHealth>();
            audioPlayer = ItemManager.Instance.gameObject.GetComponent<AudioSource>();
        }
        //jika kena player
        if (other.gameObject.tag == "PlayerCollider")
        {
            audioPlayer.clip = sfx;
            audioPlayer.Play();
            //tambah 10 health
            if (player.currentHealth <= 100)
            {
                player.currentHealth += healthBonus;
            }
            Destroy(transform.parent.gameObject);
        }
    }
}
