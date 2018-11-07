using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbarscriptenemy : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Healthbarscript.health -= 10f;
    }
}
