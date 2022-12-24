using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private float dashingDistance = 5f;
    [SerializeField] private float dashingTime = 0.5f;

    private Rigidbody rb;
    private Vector3 dashDirection;
    private bool isDashing;
    private bool canDash = true;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!PauseMenu.isPaused)
            HandleDash();
    }

    private void HandleDash()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canDash) 
        {
            isDashing = true;
            canDash = false;

            dashDirection = transform.forward;

            StartCoroutine(StopDashing());
        }

        if(isDashing)
        {
            rb.AddForce(dashDirection.normalized * dashingDistance, ForceMode.Impulse);
        }
    }

    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        canDash = true;
    }


}
