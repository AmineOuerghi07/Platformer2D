using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    [SerializeField] Vector2 playerPos;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.GetComponent<Player>())
        {
            FindObjectOfType<GameSession>().SetPlayerRespawnPos(gameObject.transform.position);
            FindObjectOfType<GameSession>().SetCheck(1);
            gameObject.SetActive(false);
        }
    }
}
