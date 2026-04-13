using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Collision : MonoBehaviour
{
    public Movement movement;
    public GameObject tilePrefab;           // ← CHANGED: Renamed from triggerPrefab
    public Transform tileSpawnPoint;        // ← CHANGED: Now a Transform reference
    public bool DeathEnabled = true;
    public Rigidbody rb;
    public float tileLength = 100f;
    private static float nextSpawnZ = 0f;
    

    //For tile generation
    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle" && DeathEnabled)
        {
            GetComponent<Renderer>().material.color = Color.red;
            rb.constraints = RigidbodyConstraints.None;
            rb.mass = 0.3f;
            Debug.Log("OBSTACLE HIT");
            movement.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            
            nextSpawnZ += tileLength;

            // ← CHANGED: Spawn tilePrefab at calculated position
            Instantiate(tilePrefab, new Vector3(0, 0, nextSpawnZ), Quaternion.identity);

            Debug.Log("Tile made");
        }
        if (other.CompareTag("TriggerDestroy"))
        {
            Destroy(other.transform.root.gameObject);
            Debug.Log("Old tile Removed");
         
        }
    }
}