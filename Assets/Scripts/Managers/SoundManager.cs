
using System;
using UnityEngine;

public class SoundManager
{
    // Audio Player
    AudioSource[] _audioSources = new AudioSource[(int)Define.Sound.MaxCount];

    // Audio Sources

    // Audio Listnener

    public void Init()
    {
        GameObject root = GameObject.Find("@Sound");
        if (root == null)
        {
            root = new GameObject { name = "@Sound" };
            UnityEngine.Object.DontDestroyOnLoad(root);

            string[] soundNames = Enum.GetNames(typeof(Define.Sound));
            for (int i = 0; i < soundNames.Length - 1; i++)
            {
                GameObject go = new GameObject { name = soundNames[i]};
                _audioSources[i] = go.AddComponent<AudioSource>();
                go.transform.SetParent(root.transform);
            }
            _audioSources[(int)Define.Sound.Bgm].loop = true;
        }
    }

    public void Play(Define.Sound type, string path, float pitch = 1.0f)
    {
        if (!path.Contains("Sounds"))
        {
            path = $"Sounds/{path}";
        }

        if (type == Define.Sound.Bgm)
        {
            AudioClip audioClip = Managers.Resource.Load<AudioClip>(path);
            if (audioClip == null)
            {
                Debug.LogError($"AudioClip Missing! {path}");
                return;
            }

            // TODO
        }
        else
        {
            AudioClip audioClip = Managers.Resource.Load<AudioClip>(path);
            if (audioClip == null)
            {
                Debug.LogError($"AudioClip Missing! {path}");
                return;
            }

            AudioSource audioSource = _audioSources[(int)type];
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioClip);
        }
    }
}
