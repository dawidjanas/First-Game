using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animacje : MonoBehaviour {

    const float locomatationAnimationSmoothTime = .1f;

    NavMeshAgent agent;

    Animator animator;

	// Inicjalizacja
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
	}
	
	// Akrualizcja co każdą klatkę
	void Update () {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, locomatationAnimationSmoothTime, Time.deltaTime);
	}
}
