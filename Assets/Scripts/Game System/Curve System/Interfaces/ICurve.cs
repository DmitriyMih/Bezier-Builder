using UnityEngine;

namespace GameSystem.CurveSystem
{
    public interface ICurve
    {
        void AddPoint(Vector3 point);
        void RemovePoint(int index);
        Vector3 GetPoint(float t);
    }
}