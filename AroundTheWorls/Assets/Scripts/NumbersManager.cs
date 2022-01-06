using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumbersManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CoinsText;
    [SerializeField] TextMeshProUGUI CardText;
    public int coin;
    public int card;
    void Update()
    {
        coin = GeneralScore._generalScore;
        card = GeneralScore._generalCard;
        PlayerPrefs.SetInt("coins", coin);
        PlayerPrefs.SetInt("card", card);
        CoinsText.text = "" + PlayerPrefs.GetInt("coinss").ToString();
        CardText.text = "" + PlayerPrefs.GetInt("cardd").ToString();
        PlayerPrefs.Save();
    }
}
