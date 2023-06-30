using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.UpdateScore();
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Pipes"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Sciana"))
        {
            Destroy(gameObject);
        }
    }

}  
