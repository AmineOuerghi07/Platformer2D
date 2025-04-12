using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        SetUpSimpelton();
    }
    
    private void SetUpSimpelton()
    {
        int length = FindObjectsOfType<MusicPlayer>().Length;
        if(length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

}
