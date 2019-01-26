using UnityEngine;

namespace DefaultNamespace {
    public static class VectorExtensions {
        public static void ClampX(this Transform transform, float minX, float maxX) {
            transform.position = transform.position.ClampX(minX, maxX);
        }

        public static Vector3 ClampX(this Vector3 v, float minX, float maxX) {
            return new Vector3(Mathf.Clamp(v.x, minX, maxX), v.y, v.z);
        }
        
        public static void ClampY(this Transform transform, float minY, float maxY) {
            transform.position = transform.position.ClampY(minY, maxY);
        }

        public static Vector3 ClampY(this Vector3 v, float minY, float maxY) {
            return new Vector3(v.x, Mathf.Clamp(v.y, minY, maxY), v.z);
        }
    }
}