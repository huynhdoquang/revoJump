using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController Instance;

    public int score;
    public int highScore;
    public Text scoreTxt;
    public Text lastScoreTxt;

    //
    public bool isInGame;

    //for UI
    public GameObject panelStartGame;
    public GameObject panelInGame;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (isInGame)
        {
            scoreTxt.text = score.ToString();
            scoreTxt.transform.GetChild(0).gameObject.SetActive(false);
            lastScoreTxt.gameObject.SetActive(false);
        }
        else
        {
            scoreTxt.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
            scoreTxt.transform.GetChild(0).gameObject.SetActive(true);
            
        }
        
	}

    public void StartGame()
    {
        score = 0;
        gameObject.GetComponent<mainScript>().currentAngle = 90;
        isInGame = true;
        panelStartGame.SetActive(false);
        
    }

    public void EndGame()
    {
        isInGame = false;
        panelStartGame.SetActive(true);
        lastScoreTxt.gameObject.SetActive(true);
        lastScoreTxt.text = score.ToString();
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        score = 0;
    }
}
