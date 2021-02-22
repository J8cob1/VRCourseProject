using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballCollide : MonoBehaviour
{
    // Update is called once per frame
    void Update(){
        // Destroy object if it goes below the map
        if (gameObject.transform.position.y < 0f) {
            Destroy(gameObject);
        }
    }

    // Delete on collision with something. 
    // Our collistion strategy may have to be changed later, but it's here for now
    void OnCollisionEnter(Collision collision) {
        Destroy(gameObject);
    }
}
