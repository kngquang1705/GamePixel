using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepVolumeMusic : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("MusicPlayer");
        if (musicObj.Length > 1)
        {
            musicObj[1].SetActive(false);
        }
        DontDestroyOnLoad(this.gameObject);

    }
}
