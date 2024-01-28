using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drone
{
    
    [RequireComponent(typeof(Rigidbody))] 
    public class Base_RigidBody : MonoBehaviour
    {
    
        #region Variables
        [Header("Rigidbody properties")]
        [SerializeField] private float weightInKg = 1f;
        
        protected Rigidbody rb;
        protected float startDrag;
        protected float startAngularDrag;
        
        #endregion

        #region MainMethods
 void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
                rb.mass = weightInKg;
                startDrag = rb.drag;
                startAngularDrag = rb.angularDrag;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (!rb)
            {
                rb = GetComponent<Rigidbody>();
                Debug.Log("No rb attached");
                return;
            }

            HandlePhysics();

        }
        

        #endregion
       
        
        #region Custom Methods
        protected virtual void HandlePhysics() { }
        #endregion
    }
   
}