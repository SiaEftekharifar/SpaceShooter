using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [Tooltip("FX prefab on enemy")][SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int score;
    [SerializeField] int healthPoints;

    ScoreBoard scoreBoard;

    void Start() {

        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    //Adding collider to the enemies through script!
    private void AddNonTriggerBoxCollider() {

        Collider nonTriggerCollider = gameObject.AddComponent<BoxCollider>();
        nonTriggerCollider.isTrigger = false;
    }

    // Detecting collision from the player bullets whic are particles!
    void OnParticleCollision(GameObject other) {

        ProcessHit();

        if (healthPoints < 1) {
        
            KillEnemy();
        }
    }

    private void ProcessHit() {
        scoreBoard.CalculateScore(score);
        healthPoints--;
    }

    //Proccessing the the enemy destrcution.
    private void KillEnemy() {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }

}
