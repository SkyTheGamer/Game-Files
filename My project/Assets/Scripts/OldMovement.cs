// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class OldMovement : MonoBehaviour
// {   bool Rotating = false;
//     bool Moving = false;
//     public Rigidbody rb;
//     private Quaternion endRotation;
//     [SerializeField] private AnimationCurve curve;
//     private Quaternion startRotation;
//     private Vector3 startPosition;
//     public GameObject Grid;
//     private Vector3 endPosition;
//     public int xRange;
//     public int yRange;
//     public float posX;
//     public float posY;
//     public Vector3 checkPOS;
//     public float desiredDuration = 1f;
//     private float elapsedTime;
//     float percentageComplete = 0f;  

//     private void Awake(){
//         rb = GetComponent<Rigidbody>();
//         var grid = Grid.GetComponent<GridCreation>();
//         xRange = grid.width;
//         yRange = grid.height;
//     }

//     public void TurnRight(InputAction.CallbackContext context){ 
            
//             if (context.started && Rotating == false && Moving == false) {
//                 percentageComplete = 0;
//                 startRotation = rb.rotation;
//                 endRotation = startRotation * Quaternion.Euler(0,90,0);
//                 Rotating = true;
//                 elapsedTime = 0;
//             }
//             }
//     public void TurnLeft(InputAction.CallbackContext context){ 
            
//             if (context.started && Rotating == false && Moving == false) {
//                 percentageComplete = 0;
//                 startRotation = rb.rotation;
//                 endRotation = startRotation * Quaternion.Euler(0,-90,0);
//                 Rotating = true;
//                 elapsedTime = 0;
//             }}
//     public void Forward(InputAction.CallbackContext context){ 
            

//             if (context.started && Rotating == false && Moving == false) {
//                 // if (checkPOS[0] < xRange && checkPOS[2] < yRange) {
//                 // if ((posY + 1) != yRange){
//                     percentageComplete = 0;
//                     startPosition = rb.position;
//                     endPosition += rb.rotation * Vector3.forward * 10;
//                     endPosition[1] = 1;
//                     checkPOS = (rb.position + endPosition) / 10;
//                     checkPOS[1] = 1;
//                     if (checkPOS[0] > xRange || checkPOS[0] == -1) {
//                         Debug.Log(checkPOS[0]);
//                     }
//                     if (checkPOS[2] > yRange || checkPOS[2] == -1) {
//                         Debug.Log(checkPOS[2]);
//                     }
//                     // endPosition =  new Vector3(posX * 10,1,posY * 10);
//                     Moving = true;
//                     elapsedTime = 0;
//                     ;
//             }}
//             // }
            
//     public void Update() {
//         // rb.position = Vector3.forward * 1;
//         // rb.position = new Vector3(posX * 10, 0, posY * 10);
//         if (Rotating == true){
//             if (percentageComplete < 1) {
//                 elapsedTime += Time.deltaTime;
//                 percentageComplete = elapsedTime / desiredDuration;
//                 rb.rotation = Quaternion.Lerp(startRotation, endRotation, curve.Evaluate(percentageComplete));
//             }
                       
//             if (percentageComplete > 1) {
//                 Rotating = false;}
//                             }
//         if (Moving == true){
//             if (percentageComplete < 1) {
//                 elapsedTime += Time.deltaTime;
//                 percentageComplete = elapsedTime / desiredDuration;
//                 rb.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percentageComplete));
//             if (percentageComplete > 1) {
//                 Moving = false;
//                 posX = Mathf.Round(rb.position.x / 10);
//                 posY = Mathf.Round(rb.position.z / 10);}
//         }

//     }
//         }}