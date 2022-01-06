using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] int ParkCount = 0;
    [SerializeField] int CardsCount = 0;
    [SerializeField] GameObject winText = null;
    [SerializeField] GameObject menu = null;
    [SerializeField] TextMeshProUGUI scoreText = null;
    [SerializeField] TextMeshProUGUI cardsScoreText = null;
   
    [SerializeField] GameObject[] coins = null;
    [SerializeField] GameObject[] cards = null;
    public bool check = false;
    public int parkedCount = 0;
    public int scoreCount = 0;
    public int cardsScoreCount = 0;
    bool isTriggered = true;
    int sceneIndex;
    public int levelComplete;
    public int _Score;

    public static GameManager _instance;
  
    
    void Awake()
    {
        check = false;
        if (_instance == null){

            _instance = this;            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("LevelComplete"); 
    }
    public void InitScene()
    {
        check = true;
        foreach (var coin in coins)
        {
            coin.SetActive(true);
        }
        foreach (var card in cards)
        {
            card.SetActive(true);
        }
        GeneralScore._generalScore -= GameManager._instance.scoreCount;
        GeneralScore._generalCard -= GameManager._instance.cardsScoreCount;
        PlayerPrefs.SetInt("cardd", GeneralScore._generalCard);
        PlayerPrefs.SetInt("coinss", GeneralScore._generalScore);
        scoreCount = 0;
        parkedCount = 0;
        cardsScoreCount = 0;

    }

    void Update()
    {
        if(parkedCount == ParkCount && cardsScoreCount==CardsCount)
        {
            if(isTriggered)
            {
                AudioManager.PlaySounds("VictorySound");
                isTriggered = false;
            }
            winText.SetActive(true);
            menu.SetActive(true);
            PlayerPrefs.SetInt("LevelComplete",sceneIndex + 0);
        }
        scoreText.text = "" + scoreCount.ToString();
        cardsScoreText.text = "" + cardsScoreCount.ToString();
        

    }
}
