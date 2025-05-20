using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    private bool bloqueado = false;

    void Update()
    {
        if (bloqueado) return; 

        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);

        if (Mathf.Abs(moveInput) > 0.1f)
        {
            transform.Rotate(Vector3.up * turnInput * rotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Limits"))
        {
            StartCoroutine(BloqueoTemporal());
        }
    }

    IEnumerator BloqueoTemporal()
    {
        bloqueado = true;
        yield return new WaitForSeconds(2f); 
        bloqueado = false;
    }

    public void SetPosition(Vector3 pos) => transform.position = pos;
    public Vector3 GetPosition() => transform.position;
    public void SetRotation(Quaternion rot) => transform.rotation = rot;
    public Quaternion GetRotation() => transform.rotation;
}


