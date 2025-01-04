using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable 8601, 8618

namespace WinFormsApp1
{
    public class GameObject
    {
        public List<Component> m_components;
        private List<IEnumerator<object>> m_coroutines;
        public Transform transform;

        public GameObject()
        {
            m_components = new List<Component>();
            m_coroutines = new List<IEnumerator<object>>();
            transform = AddComponent<Transform>();
        }

        public T AddComponent<T>() where T : Component, new()
        {
            T component = new T();
            component.gameObject = this;
            component.transform = GetComponent<Transform>();
            m_components.Add(component);
            return component;
        }

        public T? GetComponent<T>() where T : Component
        {
            foreach (var comp in m_components)
            {
                if (comp.GetType() == typeof(T))
                {
                    return (T)comp;
                }
            }
            return default(T);
        }

        public void BroadcastMessage(string methodName)
        {
            foreach (var comp in m_components)
            {
                Type t = comp.GetType();
                MethodInfo? minfo = t.GetMethod(methodName);
                minfo?.Invoke(comp, null);
            }
        }
        public void StartCoroutine(IEnumerator routine)
        {
            m_coroutines.Add((IEnumerator<object>)routine);
        }

        public void UpdateCoroutine()
        {
            int numRoutines = m_coroutines.Count;
            foreach (var routine in m_coroutines)
            {
                if (routine.MoveNext())
                {
                    object item = routine.Current;
                }
            }
        }
        public void OnRenderObject(Graphics g)
        {
            foreach (Component comp in m_components)
            {
                comp.OnRenderObject(g);
            }
        }
    }

    public class Component
    {
        public GameObject gameObject { get; set; }
        public Transform transform { get; set; }

        public T? GetComponent<T>() where T : Component
        {
            foreach (var comp in gameObject.m_components)
            {
                if (comp.GetType() == typeof(T))
                {
                    return (T)comp;
                }
            }
            return default(T);
        }

        public void StartCoroutine(IEnumerator routine)
        {
            gameObject.StartCoroutine((IEnumerator<object>)routine);
        }

        public void SendMessage(string methodName) { }
        public virtual void OnRenderObject(Graphics g) { }
    }

    public class Transform : Component
    {
        public Vector3 position;
    }

    public class Behavior : Component
    {
    }

    public class MonoBehavior : Behavior
    {
        public void Invoke(string methodName) { }
    }
}
