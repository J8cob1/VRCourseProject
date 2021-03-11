using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballCollide : MonoBehaviour
{
    public GameObject snowball;

    private void destorySelf() {
        // Make the snowball invisiable till it gets destroyed
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        // Set off the snowball explosion
        ParticleSystem explosion = gameObject.GetComponent<ParticleSystem>();
        explosion.Play();

        // Destory the game object after the explosion has finished
        Destroy(gameObject, explosion.main.duration);
    }

    // Update is called once per frame
    void Update(){
        // Destroy object if it goes below the map
        if (gameObject.transform.position.y < 0f) {
            this.destorySelf();
        }
    }

    // Delete on collision with something. 
    // Our collistion strategy may have to be changed later, but it's here for now
    void OnCollisionEnter(Collision collision) {
        if (gameObject.GetComponent<Rigidbody>().velocity.magnitude > 3f) {
            this.destorySelf();
        }
    }
}
