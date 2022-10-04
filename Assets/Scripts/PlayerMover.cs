using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private LineDrawer lineDrawer = null;
    [SerializeField] private float speed = 5f;


    private Queue<Vector3> waypoints = new Queue<Vector3>();
    private Vector3 currentTargetPosition = Vector3.zero;


    private void Start() => currentTargetPosition = transform.position;

    private void Update()
    {
        Touch();
        
        if (Vector2.Distance(currentTargetPosition, transform.position) < 10f)
        {
            if (waypoints.Count != 0)
            {
                if (lineDrawer.Index > 2)
                    lineDrawer.ReDraw();

                currentTargetPosition = waypoints.Dequeue();
            }

            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, currentTargetPosition, speed * Time.deltaTime);
    }


    private void Touch()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !GameController.IsFinished)
        {
            var position = Input.GetTouch(0).position;
            waypoints.Enqueue(position);
            lineDrawer.DrawLine(position);

            UIControiller.ToggleStartText(false);
        }
    }
}
