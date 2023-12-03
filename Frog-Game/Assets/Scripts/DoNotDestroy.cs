using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class DoNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] audioObj = GameObject.FindGameObjectsWithTag("Audio");
        if (audioObj.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Audio"));
    }
}