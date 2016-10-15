using UnityEngine;
using System.Collections;
using Assets;

public class Locomotion : MonoBehaviour {

    [SerializeField] private float moveTime;
    [SerializeField] private Vector3 destination;
    [SerializeField] private Vector3 startLocation;

    private void Awake()
    {
        MoveableObject.IssueMoveAction += SetDestination;
    }

    private void OnDestroy()
    {
        MoveableObject.IssueMoveAction -= SetDestination;
    }

    public void SetDestination(Vector3 d)
    {
        // don't set the same destination multiple times
        if (d == destination) return;

        destination = d;
        startLocation = transform.position;
        StopAllCoroutines();
        StartCoroutine(MoveToDestination());
    }

    private IEnumerator MoveToDestination()
    {
        float t = 0;
        float totalTime = moveTime;
        while (t < totalTime)
        {
            transform.position = Vector3.Lerp(startLocation, destination, t / totalTime);
            t += Time.deltaTime;
            yield return null;
        }
    }
}
