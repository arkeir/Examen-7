using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public Image artworkImage;


    public void Start()
    {
        card.Print();

        this.artworkImage.sprite = card.artwork;    

    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics2D.Raycast(ray.origin,new Vector2(0,0)))
        {
            Debug.Log("Hovering you are");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Hovering you are");
    }

    void OnMouseExit()
    {
        Debug.Log("No more hovering for u");
    }
}
