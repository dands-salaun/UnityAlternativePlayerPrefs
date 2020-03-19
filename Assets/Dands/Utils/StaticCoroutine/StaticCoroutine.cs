using System;
using Dands.Utils.Singleton;
using System.Collections;
using UnityEngine;

namespace Dands.Utils.StaticCoroutines
{
    public class StaticCoroutine : Singleton<StaticCoroutine>
    {
        private void Start()
        {
            name = "StaticCoroutines";
        }

        IEnumerator Perform(IEnumerator coroutine)
        {
            yield return StartCoroutine(coroutine);
            
        }
 
        /// <summary>
        /// Place your lovely static IEnumerator in here and witness magic!
        /// </summary>
        /// <param name="coroutine">Static IEnumerator</param>
        public static void DoCoroutine(IEnumerator coroutine)
        {
            I.StartCoroutine(I.Perform(coroutine)); //this will launch the coroutine on our instance
        }
    }    
}

