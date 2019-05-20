using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;


namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for

        public bool playertouch;
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
	        
            InvokeRepeating("targetChange",0, 20);
        }


        private void Update()
        {
            if (target != null)
                agent.SetDestination(target.transform.position);

            if (agent.remainingDistance > agent.stoppingDistance && playertouch == false)
            { character.Move(agent.desiredVelocity, false, false);}
           
            else if (agent.remainingDistance <= agent.stoppingDistance && playertouch == false)
            {
                character.Move(Vector3.zero, false, false);
                
            }
            else if (playertouch == true)
            {
                character.Move(Vector3.zero, false, false);
            }

            
            Debug.Log(playertouch);
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        void targetChange()
        {
            
            //yield return new WaitForSeconds(5);
          
            target.transform.position = new Vector3(Random.Range(80,118),30,Random.Range(94,97));
           // characterstop = false;
        }

        private void OnTriggerEnter(Collider other)
        {
           
            if (other.CompareTag("Player")) //if player attached npc
            {
                playertouch = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player")) //if player attached npc
            {
                playertouch = false;
            }
        }
    }
}
