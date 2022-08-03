using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishTest : MonoBehaviour
{
    public GameObject Spell;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collisionInfo) {
        Spell.GetComponent<Renderer>().enabled = true;
    }
    void OnCollisionExit(Collision collisionInfo) {
        Spell.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
