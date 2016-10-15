using UnityEngine;
using System.Collections;

public abstract class Singleton<T> : MonoBehaviour where T: MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance != null) return _instance;

            var inst = FindObjectOfType<T>();
            if (inst == null)
            {
                var gObj = new GameObject(string.Format("(Instance) {0}", typeof(T)), typeof(T));
                inst = gObj.GetComponent<T>();

            }
            _instance = inst; 
            return _instance;
        }
    }
}
