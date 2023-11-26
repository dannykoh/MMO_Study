using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : UI_Scene
{
    new enum GameObjects
    {
        GridPanel,
    }

    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);
        foreach (Transform child in gridPanel.transform)
        {
            Managers.Resource.Destroy(child.gameObject);
        }

        for (int i = 0; i < 16; i++)
        {
            GameObject item = Managers.Resource.Instantiate("UI/Scene/UI_Inventory_Item");
            item.transform.SetParent(gridPanel.transform);
            UI_Inventory_Item invenItem = Util.GetOrAddComponent<UI_Inventory_Item>(item);
            invenItem.SetInfo($"집행검{i}");
        }
    }
}
