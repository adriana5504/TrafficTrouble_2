using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    void Update()
    {
        // Obtenim les entrades del teclat
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        // Moviment endavant/enrere
        transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);

        // Rotació del cotxe (només quan està en moviment)
        if (Mathf.Abs(moveInput) > 0.1f)
        {
            transform.Rotate(Vector3.up * turnInput * rotationSpeed * Time.deltaTime);
        }
    }

    // Mètodes existents (els mantinc per compatibilitat)
    public void SetPosition(Vector3 pos) => transform.position = pos;
    public Vector3 GetPosition() => transform.position;
    public void SetRotation(Quaternion rot) => transform.rotation = rot;
    public Quaternion GetRotation() => transform.rotation;
}