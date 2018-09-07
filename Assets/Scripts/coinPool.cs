using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinPool : MonoBehaviour
{

    public GameObject coinPrefabs;
    public GameObject spikePrefabs;

    public float lastAngle = 0;
    public float newAngle;

    public bool isFirst;

    public void poolCoin(float ang)
    {
        GameObject coin = Lean.Pool.LeanPool.Spawn(coinPrefabs);
        coin.GetComponent<checkAngle>().ResetStart();
        coin.GetComponent<checkAngle>().ang = ang - 90;
        coin.GetComponent<checkAngle>().isStarAppear = true;

        // check khoảng cách giữa 2 spike gần nhất và khả năng nhảy qua nó 


        if ( (Mathf.Abs(ang - lastAngle) > 45 ) && ang < 0)
        {
            if (isFirst)
            {
                GameObject spike = Lean.Pool.LeanPool.Spawn(spikePrefabs);
                spike.GetComponent<checkAngle>().ResetStart();
                spike.GetComponent<checkAngle>().ang = ang - 180;
                spike.GetComponent<checkAngle>().isStarAppear = true;
                spike.GetComponent<checkAngle>().isSpike = true;

                lastAngle = ang;
            }
            else
            {
                lastAngle = ang;
                isFirst = true;
            }
        }

    }
}
    
