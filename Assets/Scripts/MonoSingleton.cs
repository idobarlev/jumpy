using UnityEngine;

namespace Utils
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T _instance;
        public static T Instance => _instance;

        public void Awake()
        {
            _instance = (T)this;
        }
    }
}
