using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinPool : MonoBehaviour
{

    public GameObject coinPrefabs;
    public GameObject spikePrefabs;
 

    public void poolCoin(float ang)
    {

        GameObject coin = Instantiate(coinPrefabs);
        Debug.Log("pool");
        coin.GetComponent<checkAngle>().ang = ang - 90;
        coin.GetComponent<checkAngle>().isStarAppear = true;

        // check khoảng cách giữa 2 spike gần nhất và khả năng nhảy qua nó 
        if(Random.Range(1,5) > 2)
        {

            GameObject spike = Instantiate(spikePrefabs);
            spikePrefabs.GetComponent<checkAngle>().ang = ang - 180;
            spikePrefabs.GetComponent<checkAngle>().isStarAppear = true;
        }
    }
}
    
