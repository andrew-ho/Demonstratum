﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
	public string toLevel;
	public int spawnPointID = 0;
	TransitionEffect outTransition;

	private void Awake() {
		outTransition = GetComponent<TransitionEffect>();
	}

	private void OnTriggerEnter(Collider other) {
		Transition();
	}

	public void Transition() {
		if (outTransition != null) {
			StartCoroutine(outTransition.Transition(() => {
				GameManager.instance.SpawnPointID = spawnPointID;
				SceneManager.LoadScene(toLevel);
			}));
		} else {
			GameManager.instance.SpawnPointID = spawnPointID;
			SceneManager.LoadScene(toLevel);
		}
	}

	void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawCube(transform.position + new Vector3(0,1,0), new Vector3(1, 2, 1));
    }
}
