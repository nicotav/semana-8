﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StyleManager : MonoBehaviour
{
    public static StyleManager instance;
    public StyleSheet[] stylesheets;

    private int currentStyleIndex;

    public StyleSheet CurrentStyle
    {
        get => stylesheets[currentStyleIndex];
    }

    public event System.Action OnStyleChange;

    public void SetStyle(int styleIndex)
    {
        currentStyleIndex = (styleIndex) % stylesheets.Length;
        OnStyleChange?.Invoke();
    }

    public void NextStyle()
    {
        currentStyleIndex = (currentStyleIndex + 1) % stylesheets.Length;
        OnStyleChange?.Invoke();
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
        SetStyle(PlayerPrefs.GetInt("style"));
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("style", currentStyleIndex);
    }
}
