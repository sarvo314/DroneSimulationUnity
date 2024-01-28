using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drone
{
    [RequireComponent(typeof(BoxCollider))]
    public class Drone_Engine : MonoBehaviour, IEngine
    {
        #region Variables
        [Header("Engine Properties")]
        [SerializeField] private float maxEnginePower = 4f;

        [Header("Propeller Properties")] 
        [SerializeField]private Transform propeller;
        [SerializeField] private float propellerSpeed = 1000f;
        #endregion

        #region Interface Methods
        public void InitEngine()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateEngine(Rigidbody rb, Drone_Inputs input)
        {
            Debug.Log("Running engines : " + gameObject.name);
            
            Vector3 engineForce = Vector3.zero;
            engineForce = transform.up * ((rb.mass * Physics.gravity.magnitude) + (-input.Throttle * maxEnginePower))/4f;
            
            rb.AddForce(engineForce, ForceMode.Force);
            HandlePropellers();
        }

        void HandlePropellers()
        {
            if(!propeller) return;

            propeller.Rotate(Vector3.up, propellerSpeed * Time.deltaTime);
        }
        #endregion
        
    }
}