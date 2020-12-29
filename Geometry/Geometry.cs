using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Geometry
{
    public static bool LinePlaneIntersection(out Vector3 intersection, Vector3 planePoint, Vector3 planeNormal, Vector3 linePoint, Vector3 lineDirection)
    {
        lineDirection = lineDirection.normalized;
        if (Vector3.Dot(planeNormal, lineDirection) == 0)
        {
            intersection = Vector3.zero;
            return false;
        }

        float t = (Vector3.Dot(planeNormal, planePoint) - Vector3.Dot(planeNormal, linePoint)) / Vector3.Dot(planeNormal, lineDirection);
        intersection = linePoint + lineDirection * t;
        return true;
    }

    public static bool SegmentPlaneIntersection(out Vector3 intersection, Vector3 planePoint, Vector3 planeNormal, Vector3 segmentStart, Vector3 segmentEnd)
    {
        Vector3 segment = segmentEnd - segmentStart;
        if (LinePlaneIntersection(out intersection, planePoint, planeNormal, segmentStart, segment))
        {
            if ((intersection - segmentEnd).sqrMagnitude > segment.sqrMagnitude ||
                (intersection - segmentStart).sqrMagnitude > segment.sqrMagnitude)
                return false;

            return true;
        }
        else
        {
            return false;
        }
    }
}
