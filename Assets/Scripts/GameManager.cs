using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.Experimental.UIElements.Button;


public class GameManager : MonoBehaviour
{
    public Text moneyText;
    public Text NormalAmountText;
    public Text EpicAmountText;
    public Text LegendaryAmountText;

    public RectTransform boughtPanel;
    public RectTransform normalSlot;
    public RectTransform epicSlot;
    public RectTransform legendarySlot;

    public int money = 300;


    private int normalAmount;
    private int epicAmount;
    private int legendaryAmount;
    
    private Card normalCard;
    private Card epicCard;
    private Card legendaryCard;

    private GameObject normalCardTemplate;
    private GameObject epicCardTemplate;
    private GameObject legendaryCardTemplate;

    private List<int> normalCardLibrary = new List<int>();
    private List<int> epicCardLibrary = new List<int>();
    private List<int> legendaryCardLibrary = new List<int>();

    private List<GameObject> boughtPanelLibrary = new List<GameObject>();
    private List<GameObject> tempCardLibrary = new List<GameObject>();

    private bool canIBuy = true;

    private CardDisplay cardDisplay;

    private AudioClip button_10;
    private AudioClip button_11;
    private AudioClip button_18;
    private AudioClip button_30;

    private AudioSource audioClip;

    private Animator _anim;


    void Start ()
    {
        audioClip = this.GetComponent<AudioSource>();
        LoadingResources();
        _anim = cardDisplay.GetComponentInChildren<Animator>();
    }


	void Update ()
	{
	    moneyText.text = "" + money;
    }


    IEnumerator Collect()
    {
        yield return new WaitForSeconds(0.5f);
        boughtPanelLibrary.Clear();
        foreach (Transform child in boughtPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        canIBuy = true;
        WhatsMyInventory();

    }


    public void ToLibrary()
    {
        audioClip.PlayOneShot(button_10);
        _anim.SetBool("onCollect", true);
        StartCoroutine(Collect());
        _anim.SetBool("onCollect", false);
    }


    void WhatsMyInventory()
    {
        normalAmount = normalCardLibrary.Count;
        epicAmount = epicCardLibrary.Count;
        legendaryAmount = legendaryCardLibrary.Count;

        NormalAmountText.text = normalAmount.ToString("000");
        EpicAmountText.text = epicAmount.ToString("000");
        LegendaryAmountText.text = legendaryAmount.ToString("000");
    }


    public void BuyBronzePack()
    {
        //cardDisplay.Initialize(normalCard);
        //Instantiate(tempCard, new Vector3(0, 0, 0), Quaternion.identity, boughtPanel);

        if (!canIBuy)
        {
            audioClip.PlayOneShot(button_18);
            Debug.Log("Please collect the previous bought cards.");
        }

        if (money >= 10 && canIBuy)
        {
            money -= 10;
            audioClip.PlayOneShot(button_30); // Play's a sound on click.
            
            for (int i = 0; i < 5; i++)
            {
                int cardChance = Random.Range(1, 10); // Random chooses what type of card it's going to be.
                if (cardChance <= 5)
                {
                    BuyNormal(); // Add normalCard to list.
                }

                else if (cardChance > 5 && cardChance <= 8)
                {
                    BuyEpic(); // Add epicCard to list.
                }

                else
                {
                    BuyLegendary(); // Add legendaryCard to list.
                }
            }

            LoopTroughtBoughtPanel();

            canIBuy = false; // Making sure you cant buy more and stock up the boughtPanel.
        }

        if (money < 10) // You can't buy more cards.
        {
            audioClip.PlayOneShot(button_18);
            Debug.Log("insignificant funds");
        }
    }

    public void BuySilverPack()
    {
        if (!canIBuy)
        {
            audioClip.PlayOneShot(button_18);
            Debug.Log("Please collect the previous bought cards.");
        }

        if (money >= 25 && canIBuy)
        {
            money -= 25;
            audioClip.PlayOneShot(button_30); // Play's a sound on click.

            for (int i = 0; i < 5; i++)
            {
                int cardChance = Random.Range(1, 10); // Random chooses what type of card it's going to be.
                if (cardChance <= 4)
                {
                    BuyNormal(); // Add normalCard to list.
                }

                else if (cardChance > 4 && cardChance <= 7)
                {
                    BuyEpic(); // Add epicCard to list.
                }

                else
                {
                    BuyLegendary(); // Add legendaryCard to list.
                }
            }

            LoopTroughtBoughtPanel();

            canIBuy = false; // Making sure you cant buy more and stock up the boughtPanel.
        }

        if (money < 25) // You can't buy more cards.
        {
            audioClip.PlayOneShot(button_18);
            Debug.Log("insignificant funds");
        }
    }

    public void BuyGoldPack()
    {
        if (!canIBuy)
        {
            audioClip.PlayOneShot(button_18);
            Debug.Log("Please collect the previous bought cards.");
        }

        if (money >= 50 && canIBuy)
        {
            money -= 50;
            audioClip.PlayOneShot(button_30); // Play's a sound on click.

            for (int i = 0; i < 5; i++)
            {
                int cardChance = Random.Range(1, 10); // Random chooses what type of card it's going to be.
                if (cardChance <= 2)
                {
                    BuyNormal(); // Add normalCard to list.
                }

                else if (cardChance > 2 && cardChance <= 6)
                {
                    BuyEpic(); // Add epicCard to list.
                }

                else
                {
                    BuyLegendary(); // Add legendaryCard to list.
                }
            }

            LoopTroughtBoughtPanel();

            canIBuy = false; // Making sure you cant buy more and stock up the boughtPanel.
        }

        if (money < 50) // You can't buy more cards.
        {
            audioClip.PlayOneShot(button_18);
            Debug.Log("insignificant funds");
        }
    }

    
    public void SellNormalCard()
    {
        if (normalCardLibrary.Count <= 0)
        {
            audioClip.PlayOneShot(button_18);
            Debug.Log("You have no more cards to sell");
        }

        if (normalCardLibrary.Count > 0)
        {
            audioClip.PlayOneShot(button_11);
            money += 2;
            normalCardLibrary.Remove(1);
            WhatsMyInventory();
        }
    }

    public void SellEpicCard()
    {
        if (epicCardLibrary.Count <= 0)
        {
            audioClip.PlayOneShot(button_18);
            Debug.Log("You have no more cards to sell");
        }

        if (epicCardLibrary.Count > 0)
        {
            audioClip.PlayOneShot(button_11);
            money += 5;
            epicCardLibrary.Remove(1);
            WhatsMyInventory();
        }
    }

    public void SellLegendaryCard()
    {
        if (legendaryCardLibrary.Count <= 0)
        {
            audioClip.PlayOneShot(button_18);
            Debug.Log("You have no more cards to sell");
        }

        if (legendaryCardLibrary.Count > 0)
        {
            audioClip.PlayOneShot(button_11);
            money += 10;
            legendaryCardLibrary.Remove(1);
            WhatsMyInventory();
        }
    }


    void LoopTroughtBoughtPanel()
    {
        foreach (var card in boughtPanelLibrary) // Loop trough list.
        {
            Instantiate(card, new Vector3(0, 0, 0), Quaternion.identity, boughtPanel); // Instantiate from list.
        }
    }

    void BuyNormal()
    {
        boughtPanelLibrary.Add(normalCardTemplate);
        normalCardLibrary.Add(1);
    }

    void BuyEpic()
    {
        boughtPanelLibrary.Add(epicCardTemplate);
        epicCardLibrary.Add(1);
    }

    void BuyLegendary()
    {
        boughtPanelLibrary.Add(legendaryCardTemplate);
        legendaryCardLibrary.Add(1);
    }


    void LoadingResources()
    {
        normalCard = Resources.Load<Card>("Cards/Normal");
        epicCard = Resources.Load<Card>("Cards/epic");
        legendaryCard = Resources.Load<Card>("Cards/Legendary");

        normalCardTemplate = Resources.Load<GameObject>("CardObjects/NormalCard");
        epicCardTemplate = Resources.Load<GameObject>("CardObjects/EpicCard");
        legendaryCardTemplate = Resources.Load<GameObject>("CardObjects/LegendaryCard");

        button_30 = Resources.Load<AudioClip>("Audio/UI_Buttons/Button_30");
        button_18 = Resources.Load<AudioClip>("Audio/UI_Buttons/Button_18");
        button_10 = Resources.Load<AudioClip>("Audio/UI_Buttons/Button_10");
        button_11 = Resources.Load<AudioClip>("Audio/UI_Buttons/Button_11");
    }
}
