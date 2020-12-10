using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {


    [SerializeField] int delayTime;

    void Start()
    {
        Invoke("GotoMainLevel", delayTime);
    }

    private void GotoMainLevel() {

        SceneManager.LoadScene(1);
        DontDestroyOnLoad(gameObject);
    }

}
