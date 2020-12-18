
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour {


    [Tooltip("In seconds")]
    [SerializeField] float restartDelay;
    [Tooltip("FX prefab on player")][SerializeField] GameObject deathFX;


    // Detecting collision from the player without applying physics!

    private void OnTriggerEnter(Collider other) {

        StartDeathSequence();

        Invoke("RestartLevel", restartDelay); //To do:Change it to  Coroutine later on
    }
    //processing player's death!
    private void StartDeathSequence() {

        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
    }

    private void RestartLevel() { // String referenced

        SceneManager.LoadScene(1);
    }
}
