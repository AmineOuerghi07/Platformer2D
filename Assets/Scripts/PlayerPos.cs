using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    public static int d = 0;
    GameSession gameSession;
    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        if (d != 0)
        {
            gameObject.transform.position = gameSession.GetRespawnPos();
        }
        else
        {
            gameSession.SetPlayerRespawnPos(transform.position);
        }
    }
}
