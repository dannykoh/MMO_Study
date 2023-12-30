using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEX
{
    public BaseScene CurrentScene { get { return GameObject.FindObjectOfType<BaseScene>(); } }

    public void LoadScene(Define.Scene scene)
    {
        CurrentScene.Clear();
        SceneManager.LoadScene(GetSceneName(scene));
    }

    private string GetSceneName(Define.Scene scene)
    {
        string name = Enum.GetName(typeof(Define.Scene), scene);
        return name;
    }
}
