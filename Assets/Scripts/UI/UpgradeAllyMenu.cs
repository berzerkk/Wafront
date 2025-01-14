﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeAllyMenu : MonoBehaviour {
    private int[] _valueLifeAlly = { 20, 10, 5, 5 };
    private (int wood, int iron) [] _priceLifeAlly = {
        (10, 5),
        (15, 10),
        (20, 15),
        (25, 20)
    };
    private int _indexLifeAlly = 0;
    [SerializeField]
    private TextMeshProUGUI _textLifeAlly, _buttonLifeAlly;

    private int[] _valueDamageAlly = { 20, 10, 5, 5 };
    private (int wood, int iron) [] _priceDamageAlly = {
        (5, 10),
        (10, 15),
        (15, 20),
        (20, 25)
    };
    private int _indexDamageAlly = 0;
    [SerializeField]
    private TextMeshProUGUI _textDamageAlly, _buttonDamageAlly;

    private int[] _valueSpawnAlly = { 1, 1, 1, 1 };
    private (int wood, int iron) [] _priceSpawnAlly = {
        (10, 10),
        (20, 20),
        (30, 30),
        (40, 40)
    };
    private int _indexSpawnAlly = 0;
    [SerializeField]
    private TextMeshProUGUI _textSpawnAlly, _buttonSpawnAlly;

    [SerializeField]
    private PlayerController _playerController;

    void Update () {
        _textLifeAlly.text = (_indexLifeAlly < _valueLifeAlly.Length ? "+" + _valueLifeAlly[_indexLifeAlly] + "% Life" : "Max");
        _buttonLifeAlly.text = (_indexLifeAlly < _valueLifeAlly.Length ?  _priceLifeAlly[_indexLifeAlly].wood + "W " + _priceLifeAlly[_indexLifeAlly].iron + "I": "Max");
        _textDamageAlly.text = (_indexDamageAlly < _valueDamageAlly.Length ? "+" + _valueDamageAlly[_indexDamageAlly] + "% Damage" : "Max");
        _buttonDamageAlly.text = (_indexDamageAlly < _valueDamageAlly.Length ?  _priceDamageAlly[_indexDamageAlly].wood + "W " + _priceDamageAlly[_indexDamageAlly].iron + "I": "Max");
        _textSpawnAlly.text = (_indexSpawnAlly < _valueSpawnAlly.Length ? "+" + _valueSpawnAlly[_indexSpawnAlly] + "Spawn per wave" : "Max");
        _buttonSpawnAlly.text = (_indexSpawnAlly < _valueSpawnAlly.Length ?  _priceSpawnAlly[_indexSpawnAlly].wood + "W " + _priceSpawnAlly[_indexSpawnAlly].iron + "I": "Max");
    }

    public void BuyLifeAlly () {
        if (_indexLifeAlly < _valueLifeAlly.Length && _priceLifeAlly[_indexLifeAlly].wood <= SavedVariables.woodCounter && _priceLifeAlly[_indexLifeAlly].iron <= SavedVariables.ironCounter) {
            SavedVariables.woodCounter -= _priceLifeAlly[_indexLifeAlly].wood;
            SavedVariables.ironCounter -= _priceLifeAlly[_indexLifeAlly].iron;
            SavedVariables._percentageLifeAlly += _valueLifeAlly[_indexLifeAlly];
            Debug.Log (SavedVariables._percentageLifeAlly);
            _indexLifeAlly++;
        }
    }
    public void BuyDamageAlly () {
        if (_indexDamageAlly < _valueDamageAlly.Length && _priceDamageAlly[_indexDamageAlly].wood <= SavedVariables.woodCounter && _priceDamageAlly[_indexDamageAlly].iron <= SavedVariables.ironCounter) {
            SavedVariables.woodCounter -= _priceDamageAlly[_indexDamageAlly].wood;
            SavedVariables.ironCounter -= _priceDamageAlly[_indexDamageAlly].iron;
            SavedVariables._percentageDamageAlly += _valueDamageAlly[_indexDamageAlly];
            _indexDamageAlly++;
        }
    }

    public void BuySpawnAlly () {
        if (_indexSpawnAlly < _valueSpawnAlly.Length && _priceSpawnAlly[_indexSpawnAlly].wood <= SavedVariables.woodCounter && _priceSpawnAlly[_indexSpawnAlly].iron <= SavedVariables.ironCounter) {
            SavedVariables.woodCounter -= _priceSpawnAlly[_indexSpawnAlly].wood;
            SavedVariables.ironCounter -= _priceSpawnAlly[_indexSpawnAlly].iron;
            SavedVariables._additionnalAllySpawnPerWave += _valueSpawnAlly[_indexSpawnAlly];
            _indexSpawnAlly++;
        }
    }

    public void ExitMenu () {
        _playerController.SwitchCursorMode (true);
        _playerController._menu = false;
        this.gameObject.SetActive (false);
    }
}