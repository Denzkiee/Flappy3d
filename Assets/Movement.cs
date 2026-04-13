using UnityEngine;
using UnityEngine.Assemblies;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal.Internal;

public class Movement : MonoBehaviour { 
 public Rigidbody rb;


    public int zSpeed = 0;
    public int xSpeed = 0;
    public int ySpeed = 0;
    public int boostSpeed;
    public float maxSpeed = 10f;
    private bool leftStrafe;
    private bool rightStrafe;
    private bool Boost;
    private bool Jump;
    public float drag;

    private void Update()
    {
        leftStrafe = Keyboard.current.aKey.isPressed;
        rightStrafe = Keyboard.current.dKey.isPressed;
        Boost = Keyboard.current.wKey.isPressed;
        Jump = Keyboard.current.spaceKey.isPressed;
        
    }

    // Update is called once per frame
    void FixedUpdate(){
        rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxSpeed);

        rb.AddForce(0, 0, zSpeed);   //FORWARD FORCES

        if (leftStrafe) {
            rb.AddForce(-xSpeed, 0, 0,ForceMode.VelocityChange);
        }
        if (rightStrafe)
        {
            rb.AddForce(xSpeed, 0, 0, ForceMode.VelocityChange);
        }
        if (Boost)
        {
            rb.AddForce( 0, 0, boostSpeed, ForceMode.Impulse);
        }
        if (Jump)
        {
            rb.AddForce(0, ySpeed, 0, ForceMode.Impulse);
        }
       
    }
}
