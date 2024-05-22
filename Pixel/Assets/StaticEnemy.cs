using System;
using System.Collections;
using System.Collections.Generic;
using PlayerSpace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticEnemy : MonoBehaviour
{
   
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent <Player> ()!= null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
