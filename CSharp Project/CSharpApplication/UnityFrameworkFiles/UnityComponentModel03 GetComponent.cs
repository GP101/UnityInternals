﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

#pragma warning disable 8600, 8603, 8618

namespace UnderstandingUnityEngine
{
    public abstract class Component
    {
        public GameObject gameObject { get; set; }
        public void SendMessage(string methodName) { }
    }

    public class Behavior : Component
    {
    }

    public class MonoBehavior : Behavior
    {
        public void Invoke(string methodName) { }
    }

    public class BoxCollider : MonoBehavior
    {
        public void GetCollider() { }
    }

    public class MeshRenderer : MonoBehavior
    {
        public void GetMaterial()
        {
            Console.WriteLine("GetMaterial");
        }
    }

    public class GameObject
    {
        private List<Component> m_components;

        public GameObject()
        {
            m_components = new List<Component>();

            AddComponent<BoxCollider>();
            AddComponent<MeshRenderer>();
        }

        public T AddComponent<T>() where T : Component, new()
        {
            T component = new T();
            component.gameObject = this;
            m_components.Add(component);
            return component;
        }

        public T GetComponent<T>() where T : Component
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
    }

    class Program
    {
        static void Main(string[] args)
        {
            GameObject e = new GameObject();
        }
    }
}
