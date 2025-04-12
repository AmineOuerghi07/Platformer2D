using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    LevelLoader levelLoader;
    [SerializeField] GameObject winLevel;
    AudioSource audioSource;
    [SerializeField] AudioClip clip;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        levelLoader = FindObjectOfType<LevelLoader>();
        winLevel.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.GetComponent<Player>())
        {
            audioSource.PlayOneShot(clip, 0.7f);
            winLevel.SetActive(true);
            Time.timeScale = 0;
            levelLoader.SetPaused(true);

        }
    }
}
