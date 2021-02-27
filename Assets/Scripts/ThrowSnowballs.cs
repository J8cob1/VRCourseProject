using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSnowballs : MonoBehaviour
{
    public Texture snowtexture;
    public GameObject player;
    public Object snowballPrefab;

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update()
    {
        // On left mouse click, thtoe a snowball
        if (Input.GetMouseButtonDown(0)) {
            // Generate the snowball in front of the player
            // https://answers.unity.com/questions/772331/spawn-object-in-front-of-player-and-the-way-he-is.html
            float spawnDistance = 0.5f; // Distance away from player snowball will spawn
            Transform playerTransform = this.player.transform;
            Vector3 spawnOffset = new Vector3(0.0f, 0.3f, 0.0f); // An offset to make the snowball spawn on the upper side of the player
            Vector3 spawnLocation = (playerTransform.position) + (spawnDistance * playerTransform.forward) + spawnOffset;
            GameObject snowball = (GameObject)Instantiate(this.snowballPrefab, spawnLocation, playerTransform.rotation);

            // Add force to it to "throw it"
            // https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html
            int thrust = 350;
            Rigidbody snowballRigidBody = snowball.GetComponent<Rigidbody>();
            Vector3 snowballDirection = snowball.transform.forward;
            Vector3 throwForceVector = (snowballDirection * thrust) + snowballRigidBody.velocity;
            snowballRigidBody.AddForce(throwForceVector);
        }
    }
}


// https://docs.unity3d.com/ScriptReference/Material.SetTexture.html
// https://docs.unity3d.com/ScriptReference/Shader.Find.html
// https://answers.unity.com/questions/13356/how-can-i-assign-materials-using-c-code.html
// https://docs.unity3d.com/ScriptReference/Rigidbody.html
// https://docs.unity3d.com/ScriptReference/Transform-localScale.html?_ga=2.89646040.2124661965.1613955006-495305609.1610485084
// https://stackoverflow.com/questions/35983519/how-to-add-rigidbody-to-a-imported-gameobject-of-a-modeling-software]
// https://forum.unity.com/threads/change-gameobject-texture-by-script.51869/
// https://answers.unity.com/questions/772331/spawn-object-in-front-of-player-and-the-way-he-is.html
// https://docs.unity3d.com/ScriptReference/Object.Destroy.html
// https://docs.unity3d.com/ScriptReference/Collider.OnCollisionEnter.html
// https://docs.unity3d.com/ScriptReference/Quaternion-eulerAngles.html?_ga=2.28673023.2124661965.1613955006-495305609.1610485084