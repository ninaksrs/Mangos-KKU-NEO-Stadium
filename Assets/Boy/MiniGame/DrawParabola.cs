using UnityEngine;
public class DrawParabola : MonoBehaviour
{
    private LineRenderer lineRenderer;

    public float launchVelocity = 15f;

    public int resolution = 30;
    public float timeStep = 0.1f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = true;
    }

    void Update()
    {
        DrawParabolaa();
    }
    void DrawParabolaa()
    {
        lineRenderer.positionCount = resolution;
        Vector3 startPosition = transform.position;
        Vector3 launchDirection = transform.forward;
        launchDirection.y *= 1.5f;
        Vector3 initialVelocity = launchDirection * launchVelocity;
        Vector3 gravity = Physics.gravity;
        for (int i = 0; i < resolution; i++)
        {
            float t = i * timeStep;

            Vector3 pointPosition = startPosition + (initialVelocity * t) + (0.5f * gravity * t * t);

            lineRenderer.SetPosition(i, pointPosition);
        }
    }
}