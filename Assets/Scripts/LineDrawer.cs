using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class LineDrawer : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer = null;
    [SerializeField] private PlayerMover playerMover = null;
    [SerializeField] private Camera cam = null;


    public int Index => index;
    private int index = 0;


    private void Start() => DrawLine(playerMover.transform.position);

    private void Update() => lineRenderer.SetPosition(0, GetPosition(playerMover.transform.position));


    public void DrawLine(Vector3 position)
    {
        position = GetPosition(position);

        lineRenderer.positionCount++;
        lineRenderer.SetPosition(index, position);

        index++;
    }

    public void ReDraw()
    {
        index--;

        for (var i = 1; i < lineRenderer.positionCount - 1; i++)
            lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));

        lineRenderer.positionCount--;
    }

    private Vector3 GetPosition(Vector3 position)
    {
        position = cam.ScreenToWorldPoint(position);
        position = new Vector3(position.x, position.y, 0f);

        return position;
    }
}
