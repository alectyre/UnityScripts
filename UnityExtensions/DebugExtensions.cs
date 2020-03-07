using UnityEngine;

public static class DebugExtensions
{
    public static void DrawPoint(Vector3 point, float size, Color color, float duration)
    {
        float halfSize = 0.5f * size;
        Debug.DrawLine(point - Vector3.right * halfSize, point + Vector3.right * halfSize, color, duration);
        Debug.DrawLine(point - Vector3.up * halfSize, point + Vector3.up * halfSize, color, duration);
        Debug.DrawLine(point - Vector3.forward * halfSize, point + Vector3.forward * halfSize, color, duration);
    }

    public static void DrawPoint(Vector3 point, float size, Color color)
    {
        float halfSize = 0.5f * size;
        Debug.DrawLine(point - Vector3.right * halfSize, point + Vector3.right * halfSize, color);
        Debug.DrawLine(point - Vector3.up * halfSize, point + Vector3.up * halfSize, color);
        Debug.DrawLine(point - Vector3.forward * halfSize, point + Vector3.forward * halfSize, color);
    }
}