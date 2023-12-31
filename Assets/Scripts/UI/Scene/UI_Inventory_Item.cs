﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory_Item : UI_Base
{
    new enum GameObjects
    {
        ItemIcon,
        ItemNameText,
    }

    string _name;

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        Get<GameObject>((int)GameObjects.ItemNameText).GetComponent<Text>().text = _name;
        Get<GameObject>((int)GameObjects.ItemIcon).AddUIEvent((PointerEventData) => { Debug.Log($"{_name} 클릭!"); });
    }

    public void SetInfo(string name)
    {
        _name = name;
    }
}
