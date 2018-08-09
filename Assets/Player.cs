using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log(coll.gameObject.name);
        if (coll.gameObject.tag == "coin")
        {
            Debug.Log("+10");
            GameController.Instance.score += 10;
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == "spike")
        {
            Debug.Log("die");
            GameController.Instance.EndGame();
        }
    }

  
}
