using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
 public Transform playerPos;
 public Vector3 offset = new Vector3();

    // Update is called once per frame
    void Update()
    {
        transform.position = playerPos.position + offset;    
        }
    }

