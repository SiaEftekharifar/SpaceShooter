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

    private void AddNonTriggerBoxCollider() {

        Collider nonTriggerCollider = gameObject.AddComponent<BoxCollider>();
        nonTriggerCollider.isTrigger = false;
    }

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

    private void KillEnemy() {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
