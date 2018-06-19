using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    private bool canIBuy = true;


    public GameObject normalCard;
    public GameObject epicCard;
    public GameObject legendaryCard;

    public RectTransform boughtPanel;
    
    public int money = 300;

    public Text moneyText;



    void Start ()
    {
        
    }

	void Update ()
	{
	    moneyText.text = "" + money;
    }



    private void InstantiateNormal()
    {
        GameObject nCardPrefab = (GameObject) Instantiate(normalCard, new Vector3(0,0,0), Quaternion.identity, boughtPanel);
    }

    private void InstantiateEpic()
    {
        GameObject eCardPrefab = (GameObject)Instantiate(epicCard, new Vector3(0, 0, 0), Quaternion.identity, boughtPanel);
    }

    private void InstantiateLegendary()
    {
        GameObject lCardPrefab = (GameObject)Instantiate(legendaryCard, new Vector3(0,0,0),Quaternion.identity, boughtPanel);
    }



    public void BuyBronzePack()
    {
        if (money >= 10)
        {
            money -= 10;

            for (int i = 0; i < 5; i++)
            {
                int cardChance = Random.Range(1, 10);
                Debug.Log(cardChance);
                if (cardChance <= 5)
                {
                    InstantiateNormal();
                }

                else if (cardChance > 5 && cardChance <= 8)
                {
                    InstantiateEpic();
                }

                else
                {
                    InstantiateLegendary();
                }
            }

            canIBuy = false;
        }

        if (money < 10)
        {
            Debug.Log("insignificant funds");
        }
    }

    public void BuySilverPack()
    {
        if (money >= 25)
        {
            money -= 25;
        }

        if (money < 25)
        {
            Debug.Log("insignificant funds");
        }
    }

    public void BuyGoldPack()
    {
        if (money >= 50)
        {
            money -= 50;
        }

        if (money < 50)
        {
            Debug.Log("insignificant funds");
        }
    }

    GameObject NewCard(Card card)
    {
        return null;
    }
}
