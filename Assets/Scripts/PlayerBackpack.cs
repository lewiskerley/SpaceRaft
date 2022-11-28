using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBackpack : MonoBehaviour
{
    [SerializeField] private Dictionary<string, int> items;
    public TMP_Text backpackText;

    private void Awake()
    {
        items = new Dictionary<string, int>();

        AddItem("Scrap", 10);
        AddItem("Moon Rock", 35);
        AddItem("Coal", 15);
    }

    public void AddItem(string item, int count)
    {
        if (items.ContainsKey(item))
        {
            items[item] += count;
        }
        else
        {
            items.Add(item, count);
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        string newText = "<mspace=.55em>BACKPACK\n================\n";

        foreach (KeyValuePair<string, int> item in items)
        {
            newText += CenterText(item.Key.ToString() + ":", 10, true) + " " + CenterText(item.Value.ToString(), 5, false) + "\n";
        }

        backpackText.text = newText;
    }

    private string CenterText(string s, int maxChar, bool left)
    {
        if (s.Length > maxChar)
        {
            Debug.LogWarning("String longer than max (" + maxChar + ") characters");
            return s;
        }

        int diff = maxChar - s.Length;
        string builder = "";

        if (left)
        {
            builder += s;
        }

        for (int i = 0; i < diff; i++)
        {
            builder += " ";
        }

        if (!left)
        {
            builder += s;
        }
        return builder;
    }
}
