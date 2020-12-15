using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [Tooltip("FX prefab on enemy")][SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    [SerializeField] int score;


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

        scoreBoard.CalculateScore(score);
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
