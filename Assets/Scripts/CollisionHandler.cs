using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour {


    [Tooltip("In seconds")][SerializeField] float restartDelay;

    [Tooltip("FX prefab on player")][SerializeField] GameObject deathFX;

    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other) {

        StartDeathSequence();

        Invoke("RestartLevel", restartDelay);
    }

    private void StartDeathSequence() {

        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);

    }

    private void RestartLevel() { //String referenced

        SceneManager.LoadScene(1);
    }
}
