using UnityEngine;

public class PedestrianWalker : MonoBehaviour
{
    public Transform pointA; // One end of the crossing
    public Transform pointB; // Other end of the crossing
    public float speed = 2f; // Movement speed
    public float waitTime = 1f; // Time to wait before turning around

    private Vector3 target;
    private bool waiting = false;

    void Start()
    {
        if (pointA == null || pointB == null)
        {
            Debug.LogError("PointA and PointB must be assigned.");
            enabled = false;
            return;
        }

        target = pointB.position;
    }

    void Update()
    {
        if (!waiting)
        {
            MoveTowardsTarget();
        }
    }

    void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            StartCoroutine(SwitchDirection());
        }
    }

    System.Collections.IEnumerator SwitchDirection()
    {
        waiting = true;
        yield return new WaitForSeconds(waitTime);

        target = (target == pointA.position) ? pointB.position : pointA.position;
        waiting = false;
    }
}
