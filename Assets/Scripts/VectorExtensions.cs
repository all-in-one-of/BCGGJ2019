using UnityEngine;

namespace DefaultNamespace {
    public static class VectorExtensions {

        public static void ClampX(this Transform transform, float minX, float maxX) {
            transform.position = transform.position.ClampX(minX, maxX);
        }
        public static void ClampY(this Transform transform, float minY, float maxY) {
            transform.position = transform.position.ClampY(minY, maxY);
        }
        
        public static void ClampZ(this Transform transform, float minZ, float maxZ) {
            transform.position = transform.position.ClampZ(minZ, maxZ);
        }

        public static Vector3 ClampY(this Vector3 v, float minY, float maxY) {
            return new Vector3(v.x, Mathf.Clamp(v.y, minY, maxY), v.z);
        }

        public static Vector3 ClampX(this Vector3 v, float minX, float maxX) {
            return new Vector3(Mathf.Clamp(v.x, minX, maxX), v.y, v.z);
        }

        public static Vector3 ClampZ(this Vector3 v, float minZ, float maxZ) {
            return new Vector3(v.x, v.y, Mathf.Clamp(v.z, minZ, maxZ));
        }
        public static void AddX(this Transform t, float x) {
            t.position = AddX(t.position, x);
        }
    
        public static void AddY(this Transform t, float y) {
            t.position = AddY(t.position, y);
        }
    
        public static void AddZ(this Transform t, float z) {
            t.position = AddZ(t.position, z);
        }
    
        public static void SetX(this Transform t, float x) {
            t.position = SetX(t.position, x);
        }
    
        public static void SetXRotation(this Transform t, float x) {
            t.rotation = Quaternion.Euler(SetX(t.rotation.eulerAngles, x));
        }
    
        public static void SetY(this Transform t, float y) {
            t.position = SetY(t.position, y);
        }
    
        public static void SetZ(this Transform t, float z) {
            t.position = SetZ(t.position, z);
        }
    
        public static Vector3 AddX(this Vector3 v, float x) {
            return new Vector3(v.x + x, v.y, v.z);
        }
    
        public static Vector3 AddY(this Vector3 v, float y) {
            return new Vector3(v.x, v.y + y, v.z);
        }
    
        public static Vector3 AddZ(this Vector3 v, float z) {
            return new Vector3(v.x, v.y, v.z + z);
        }
    
        public static Vector2 SetY(this Vector2 v, float y) {
            return new Vector2(v.x, y);
        }
    
        public static Vector3 SetX(this Vector3 v, float x) {
            return new Vector3(x, v.y, v.z);
        }
    
        public static Vector3 SetY(this Vector3 v, float y) {
            return new Vector3(v.x, y, v.z);
        }
    
        public static Vector3 SetZ(this Vector3 v, float z) {
            return new Vector3(v.x, v.y, z);
        }
    
        public static Vector3 Reflect(this Vector3 v, Vector3 other) {
            return Vector3.Reflect(v, other);
        }

        public static Quaternion SetX(this Quaternion q, float x) {
            return Quaternion.Euler(q.eulerAngles.SetX(x));
        }
    }
}