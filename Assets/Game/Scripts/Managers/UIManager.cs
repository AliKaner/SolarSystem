using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private Meteor[] meteors;
    private GameObject[] uICards;
    private void Awake()
    {
        meteors = FindObjectsOfType<Meteor>();
    }

    public void MeteorButton()
    {
        StartCoroutine(meteors[0].Fall());
        int index = Array.IndexOf(meteors, meteors[0]);
        meteors = meteors.Where((e, i) => i != index).ToArray();
    }
    
    private void CelestialCard()
    {
        if (Camera.main != null)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out var hit)) return;
            CloseAllCards();
            hit.collider.gameObject.GetComponent<CelestialObject>().uICard.SetActive(true);
        }
    }

    private void CloseAllCards()
    {
        foreach (var card in uICards)
        {
            card.SetActive(false);
        }
    }
}
