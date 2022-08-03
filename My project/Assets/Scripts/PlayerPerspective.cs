// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.InputSystem;
// using Cinemachine;

// public class PlayerPerspective : MonoBehaviour
// {       public CinemachineVirtualCamera cam;
//         private PlayerInput playerInput;
//         private PlayerInputActions playerInputActions;
//         private Vector3 startPerspective;
//         private Vector3 endPerspective;
//         public GameObject rb;
//         public float PspY = 10;
//         public float PspZ = 10;
//         [SerializeField] private AnimationCurve curve;
//         [SerializeField] private ParticleSystem fog;
//         private float elapsedTime;
//         float percentageComplete = 0f; 
//         bool CheckThird = true;
//         public bool perspectiveSwitch = false;
//     void OnBecameVisible() {
//         Debug.Log("Hi");
//     }
//     void OnBecomeInvisible() {
//         Debug.Log("Bye");
//     }


//     void Awake() {
//         // fog.play();
//         var playerMovement = rb.GetComponent<PlayerMovement>();
//         playerInput = GetComponent<PlayerInput>();
//         playerInputActions = new PlayerInputActions();
//         playerInputActions.Player.Perspective.performed += Perspective;    
//         playerInputActions.Enable();
//     }
    

//     void Perspective(InputAction.CallbackContext context) {
//         var playerMovement = rb.GetComponent<PlayerMovement>();
//         CinemachineTransposer transposer = cam.GetCinemachineComponent<CinemachineTransposer>();
//         if (perspectiveSwitch == false) {
//             perspectiveSwitch = true;
//             if (playerMovement.IsRotating == false && playerMovement.IsMoving == false && playerMovement.IsDodging == false) {
//                 StartCoroutine(RotatePerspective());
//                 }

//         }}
//     public IEnumerator RotatePerspective() {
//             var playerMovement = rb.GetComponent<PlayerMovement>();
//             CinemachineTransposer transposer = cam.GetCinemachineComponent<CinemachineTransposer>();
//             playerMovement.IsRotating = true;
//             playerMovement.CheckRotate = true;
//             playerMovement.CheckMove = true;
//             startPerspective = transposer.m_FollowOffset;
//             if (CheckThird == true) { 
//                 endPerspective = transposer.m_FollowOffset + new Vector3(0, -PspY, -PspZ);
//                 CheckThird = false;}
//             else if (CheckThird == false) {
//                 CheckThird = true;
//                 endPerspective = transposer.m_FollowOffset + new Vector3(0, PspY, PspZ);}
//             elapsedTime = 0;
//             percentageComplete = 0;
//             while (percentageComplete < 1) {
//                 elapsedTime += Time.deltaTime;
//                 percentageComplete = elapsedTime / 0.5f;
//                 elapsedTime += Time.deltaTime;
//                 transposer.m_FollowOffset = Vector3.Lerp(startPerspective, endPerspective, curve.Evaluate(percentageComplete));
//                 yield return null;}
//             percentageComplete = 0;
//             elapsedTime = 0;
//             perspectiveSwitch = false;
//             playerMovement.IsMoving = false;
//             playerMovement.IsRotating = false;
//             playerMovement.CheckMove = false;
//             playerMovement.CheckRotate = false;
//             yield return null;
//     }
//     void Update() {
//         }
// }
