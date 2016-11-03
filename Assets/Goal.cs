using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    static public bool goalMet = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Goal.goalMet = true;
            Renderer r = GetComponent<Renderer>();
            Color c = r.material.color;
            c.a = 1;
            r.material.color = c;
        }
    }
}
