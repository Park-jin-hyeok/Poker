using UnityEngine;


//  Unity 기반 오브젝트 싱글톤
public class MonoSingleton<T> : MonoBehaviour
    where T : MonoBehaviour
{
    private static T m_Instance = null;
    public static T Instance
    {
        get
        {
            if (m_Instance != null) return m_Instance;
            else
            {
                var objects = FindObjectsOfType<T>();   //  해당 타입의 모든 객체를 찾는다
                if (objects == null || objects.Length == 0)
                {
                    //  객체가 없는 경우, 만들어 준다
                    GameObject gameObject = new GameObject(typeof(T).Name);
                    m_Instance = gameObject.AddComponent<T>();

                    //  씬이 넘어가도 이 객체는 파괴되지 않는다
                    DontDestroyOnLoad(gameObject);
                }
                else if (objects.Length != 1)
                    throw new System.Exception("싱글톤 객체가 두 개 이상입니다!");
                else
                {
                    //  만약 한개만 있는경우 기존에 있는거 넣어준다
                    m_Instance = objects[0];
                }
            }

            return m_Instance;
        }
    }

}
