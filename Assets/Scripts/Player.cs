﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log(coll.gameObject.name);
        if (coll.gameObject.tag == "coin")
        {
            AudioController.Instance.PlayPickUpCoinSound();
            Debug.Log("+10");
            GameController.Instance.score += 10;
            Lean.Pool.LeanPool.Despawn(coll.gameObject);
        }

        if (coll.gameObject.tag == "spike")
        {
            AudioController.Instance.PlayDieSound();
            Debug.Log("die");
            GameController.Instance.EndGame();
        }
    }

  
}
