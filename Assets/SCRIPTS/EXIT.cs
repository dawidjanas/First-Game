using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXIT : MonoBehaviour {

	// Inicjalizacja
	void Start () {
		
	}
	
	// Aktualizacja co każdą klatkę
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
