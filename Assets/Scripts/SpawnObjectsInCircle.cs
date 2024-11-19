using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectsInCircle : MonoBehaviour
{
    public GameObject objectToSpawn;  // Object to spawn
    public int numberOfObjects = 10;  // Number of objects to spawn
    public float radius = 5f;         // Radius of the circle
    public float minDegree = 0f;      // Minimum degree (inclusive)
    public float maxDegree = 90f;     // Maximum degree (inclusive)
    public Transform parentTransform; // Optional: Assign if you want to parent the spawned objects
    public bool faceOutward = true;   // Should the object face outward?

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        // Calculate the step size for even distribution
        float angleStep = (maxDegree - minDegree) / (numberOfObjects - 1);

        for (int i = 0; i < numberOfObjects; i++)
        {
            // Calculate the current angle
            float angle = minDegree + i * angleStep;

            // Convert angle from degrees to radians
            float radian = angle * Mathf.Deg2Rad;

            // Calculate position on the circle
            float x = Mathf.Cos(radian) * radius;
            float y = Mathf.Sin(radian) * radius;

            // Instantiate object at calculated position
            Vector3 spawnPosition = new Vector3(x, 0, y);  // Adjust y for 3D or 2D context
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            // Calculate rotation so the object faces outward or along the tangent
            Quaternion rotation;

            rotation = Quaternion.Euler(90, -angle, -90);  // Tangent to the circle

            spawnedObject.transform.rotation = rotation;

            // Optionally parent the object
            if (parentTransform != null)
            {
                spawnedObject.transform.SetParent(parentTransform);
            }
        }
    }
}