using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameSession : MonoBehaviour
{
    public int check = 0;
    [SerializeField] static Vector2 playerPos;
    private void Awake()
    {
        SetUpSimpelton();
    }


    void SetUpSimpelton()
    {
        int gameSessionsLength = FindObjectsOfType<GameSession>().Length;
        if(gameSessionsLength > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetPlayerRespawnPos(Vector2 resPos)
    {
        playerPos = resPos;
    }

    public Vector2 GetRespawnPos()
    {
        return playerPos;
    }

    public void SetCheck(int c)
    {
        check = c;
    }

    public int GetCheck()
    {
        return check;
    }
}
