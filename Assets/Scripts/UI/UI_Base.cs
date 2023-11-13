using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Base : MonoBehaviour
{
    Dictionary<Type, object[]> _objects = new Dictionary<Type, object[]>();

    protected enum Buttons
    {
        PointButton,
    }

    protected enum Texts
    {
        PointText,
        ScoreText,
    }

    protected enum GameObjects
    {
        TestObject,
    }

    protected enum Images
    {
        ItemIcon,
    }

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        object[] objects = new object[names.Length];
        _objects.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
            {
                objects[i] = Util.FindChild(gameObject, names[i], true);
            }
            else
            {
                objects[i] = Util.FindChild<T>(gameObject, names[i], true);
            }
        }
    }

    protected T Get<T>(int index) where T : UnityEngine.Object
    {
        if (_objects.TryGetValue(typeof(T), out object[] objects) == false)
            return null;
        return objects[index] as T;
    }

    protected Button GetButton(int index) { return Get<Button>(index); }
    protected Text GetText(int index) { return Get<Text>(index); }
    protected Image GetImage(int index) { return Get<Image>(index); }

    public static void AddUIEvent(GameObject go, Action<PointerEventData> eventAction, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_EventHandler evt = Util.GetOrAddComponent<UI_EventHandler>(go);

        switch (type)
        {
            case Define.UIEvent.Click:
                evt.OnPointerClickHandler += eventAction;
                break;
            case Define.UIEvent.Drag:
                evt.OnDragHandler += eventAction;
                break;
        }
    }
}
