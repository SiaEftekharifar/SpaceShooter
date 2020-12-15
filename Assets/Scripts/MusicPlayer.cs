using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MusicPlayer : MonoBehaviour {



     void Start() {

        int numMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;

        if (numMusicPlayer > 1) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);

        }
    }


}
