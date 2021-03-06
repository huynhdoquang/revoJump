﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkAngle : MonoBehaviour {

    //Use these to get the GameObject's positions
     Vector2 m_MyFirstVector;
     Vector2 m_MySecondVector;
    //You must assign to these two GameObjects in the Inspector
    GameObject playerObj;

    float m_Angle;
    public float ang;
    float backupx;


    //distance to appear
    public float minAppear = 3;
    public float maxAppear = 5;
    //speed to move out and move in
    public float moveSpeed = 1f;

    int i; // to decide up or down (spike)
    
    bool isOver; // is player over to this obj
    public bool isStarAppear;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        //Initialise the Vector
        m_MyFirstVector = Vector2.zero;
        //Fetch the first GameObject's position
        m_MyFirstVector = transform.position;
        backupx = transform.position.x;
        m_Angle = 0.0f;

        i = Random.Range(0, 2);
    }

    public void ResetStart()
    {
        //Initialise the Vector
        m_MyFirstVector = Vector2.zero;
        //Fetch the first GameObject's position
        m_MyFirstVector = transform.position;
        backupx = transform.position.x;
        m_Angle = 0.0f;

        i = Random.Range(0, 2);
        isCaculator = false;
        isOver = false;
        isStarAppear = false;
    }


    private void Update()
    {
        if (isStarAppear)
        {
            Appear();
        }
        if (!GameController.Instance.isInGame)
        {
            Disappear();
        }
    }


    void FixedUpdate()
    {
        if (!isStarAppear)
        {
            
            //Fetch the second GameObject's position
            m_MySecondVector = playerObj.transform.position;
            //Find the angle for the two Vectors
            m_Angle = Vector2.Angle(m_MyFirstVector, m_MySecondVector);

            if (m_Angle < 5)
            {
                isOver = true;
            }
            if (isOver && m_Angle > 45)
            {
                Debug.Log("destroy");
                // make animation destroy
                Disappear();
            }
        }
        
    }

    void OnGUI()
    {
        //Output the angle found above
        //GUI.Label(new Rect(25, 25, 200, 40), "Angle Between Objects" + m_Angle);
    }

    Vector3 moveVector;
    bool over = false;
    void Disappear()
    {
        if(over)
        {
            transform.position += moveVector * moveSpeed * Time.deltaTime;
        }
        else
        {
            if ((Mathf.Abs(transform.position.x) - Mathf.Abs(backupx)) < 0.5)
            {
                transform.position -= moveVector * moveSpeed * Time.deltaTime;
            }
            else
                over = true;
        }
        if(Mathf.Abs(transform.position.x) < 1.5)
        {
            Lean.Pool.LeanPool.Despawn(gameObject);
        }
    }

   
    bool isCaculator;
    public bool isSpike;
    //sinh ra vat moi
    void Appear()
    {
        if (!isCaculator)
        {
           
            float radians = ang * Mathf.Deg2Rad;

            Vector2 newPosition = Vector2.zero;

            newPosition.x = 1 * Mathf.Cos(radians);
            newPosition.y = 1 * Mathf.Sin(radians);

            transform.position = newPosition;

            moveVector = (Vector2.zero - newPosition).normalized;
            isCaculator = true;
        }
        
        transform.position -= moveVector * moveSpeed*2 * Time.deltaTime;

        if (isSpike)
        {

            m_MyFirstVector = transform.position;
            float dis = Vector2.Distance(transform.position, Vector2.zero);
            if ( i == 0)
            {
                if (dis > 2.5 && dis < 2.75)
                {
                    moveVector = (Vector2.zero - m_MyFirstVector).normalized;
                    isStarAppear = false;
                }
                if(dis > 2.75)
                {
                    isStarAppear = false;
                }
            }
            else
            {
                if (dis > Random.Range(3.4f, maxAppear))
                {
                    moveVector = (Vector2.zero - m_MyFirstVector).normalized;
                    isStarAppear = false;
                }
            }
            
        }
        else
        {
            if (Vector2.Distance(transform.position, Vector2.zero) > Random.Range(minAppear, maxAppear))
            {
                m_MyFirstVector = transform.position;
                moveVector = (Vector2.zero - m_MyFirstVector).normalized;
                isStarAppear = false;
            }
        }
        
    }

}
