// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.Threading;
// using UnityEngine.InputSystem;
// public class Movement : MonoBehaviour
// {   bool Rotating = false;
//     bool Moving = false;
//     bool Dodging = false;
//     private PlayerInput playerInput;
//     public GameObject rb;
//     private Quaternion endRotation;
//     [SerializeField] private AnimationCurve curve;
//     private Quaternion startRotation;
//     private Vector3 startPosition;
//     public GameObject Grid;
//     private Vector3 endPosition;
//     private int xRange;
//     private int yRange;
//     public float posX;
//     public float posY;
//     public float moveDuration = 1f;
//     public float camDuration;
//     private float elapsedTime;
//     float percentageComplete = 0f;  

//     private void Awake(){
//         var grid = Grid.GetComponent<GridCreation>();
//         playerInput = GetComponent<PlayerInput>(); 
//         xRange = grid.width;
//         yRange = grid.height;
//         rb.transform.position = new Vector3((posX * 10), 1 , (posY * 10));
//     }

//     // public void TurnRight(InputAction.CallbackContext context){ 
            
//     //         if (context.started && Rotating == false && Moving == false) {
//     //             percentageComplete = 0;
//     //             startRotation = rb.transform.rotation;
//     //             endRotation = startRotation * Quaternion.Euler(0,90,0);
//     //             Rotating = true;
//     //             elapsedTime = 0;
                
//     //         }
//     //         }
//     // public void TurnLeft(InputAction.CallbackContext context){ 
            
//     //         if (context.started && Rotating == false && Moving == false) {
//     //             percentageComplete = 0;
//     //             startRotation = rb.transform.rotation;
//     //             endRotation = startRotation * Quaternion.Euler(0,-90,0);
//     //             Rotating = true;
//     //             elapsedTime = 0;
//     //         }}
//     public void Forward(InputAction.CallbackContext context){ 
            

//             if (context.performed && Rotating == false && Moving == false) {
//                     percentageComplete = 0;
//                     startPosition = rb.transform.position;
//                     endPosition = rb.transform.position + rb.transform.rotation * Vector3.forward * 10;
//                     endPosition[1] = 1;
//                     endPosition[0] = Mathf.Round(endPosition[0]);
//                     endPosition[2] = Mathf.Round(endPosition[2]);
//                     CheckPOS();
//                     }    
//                 }
//     // public void Left(InputAction.CallbackContext context){ 
            

//     //         if (context.started && Rotating == false && Moving == false) {
//     //                 percentageComplete = 0;
//     //                 startPosition = rb.transform.position;
//     //                 endPosition = rb.transform.position + rb.transform.rotation * Vector3.left * 10;
//     //                 // endPosition[1] = rb.scale.y;
//     //                 endPosition[0] = Mathf.Round(endPosition[0]);
//     //                 endPosition[2] = Mathf.Round(endPosition[2]);
//     //                 CheckPOS();
//     //                 }    
//     //             }
//     // public void Right(InputAction.CallbackContext context){ 
            

//     //         if (context.started && Rotating == false && Moving == false) {
//     //                 percentageComplete = 0;
//     //                 startPosition = rb.transform.position;
//     //                 endPosition = rb.transform.position + rb.transform.rotation * Vector3.right * 10;
//     //                 endPosition[1] = 1;
//     //                 endPosition[0] = Mathf.Round(endPosition[0]);
//     //                 endPosition[2] = Mathf.Round(endPosition[2]);                    
//     //                 CheckPOS();
//     //                 }    
//     //             }
//     // public void Back(InputAction.CallbackContext context){ 
            

//     //         if (context.started && Rotating == false && Moving == false) {
//     //                 percentageComplete = 0;
//     //                 startPosition = rb.transform.position;
//     //                 endPosition = rb.transform.position + rb.transform.rotation * Vector3.back * 10;
//     //                 endPosition[1] = 1;
//     //                 endPosition[0] = Mathf.Round(endPosition[0]);
//     //                 endPosition[2] = Mathf.Round(endPosition[2]);
//     //                 CheckPOS();
//     //                 }    
//     //             }
//     public void CheckPOS() {
//             if ((endPosition[0] / 10) > 0 && (endPosition[0] / 10) + 1 != xRange) {
//                 if ((endPosition[2] / 10) > 0 && (endPosition[2] / 10) + 1 != yRange) {
//                     Moving = true;
//                     elapsedTime = 0;}
//                 }}
            
//     public void Update() { 
//         if (Rotating == true){
//             if (percentageComplete < 1) {
//                 elapsedTime += Time.deltaTime;
//                 percentageComplete = elapsedTime / camDuration;
//                 rb.transform.rotation = Quaternion.Lerp(startRotation, endRotation, curve.Evaluate(percentageComplete));
//             }
                       
//             if (percentageComplete > 1) {
//                 Rotating = false;
//                 }
//                             }
//         if (Moving == true){
//             if (percentageComplete < 1) {
//                 elapsedTime += Time.deltaTime;
//                 percentageComplete = elapsedTime / moveDuration;
//                 rb.transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);
//             if (percentageComplete > 1) {
//                 posX = Mathf.Round(rb.transform.position.x / 10);
//                 posY = Mathf.Round(rb.transform.position.z / 10);
//                 rb.transform.position = new Vector3(posX * 10, 1, posY * 10);
//                 Moving = false;
//                 }

//         }

//     }
//         if (Dodging == true){
//             if (percentageComplete < 1) {
//                 elapsedTime += Time.deltaTime;
//                 percentageComplete = elapsedTime / moveDuration;
//                 rb.transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);
//             if (percentageComplete > 1) {
//                 Moving = false;
//                 posX = Mathf.Round(rb.transform.position.x / 10);
//                 posY = Mathf.Round(rb.transform.position.z / 10);}

//                 // rb.transform.position = new Vector3(posX, 1, posY);
//         }}
//         }
//     }
             
                 