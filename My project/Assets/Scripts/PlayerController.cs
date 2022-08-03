// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.InputSystem;

// public class PlayerController : MonoBehaviour
// {
//     private PlayerInput playerInput;
//     private PlayerInputActions playerInputActions;
//     bool Rotating = false;
//     bool Moving = false;
//     bool PosMove = false;
//     bool CheckShift = false;
//     bool CheckForward = false;
//     bool CheckRotate = false;
//     public GameObject rb;
//     private Quaternion endRotation;
//     [SerializeField] private AnimationCurve curve;
//     [SerializeField] private AnimationCurve dodgeCurve;
//     private Quaternion startRotation;
//     private Vector3 startPosition;
//     public GameObject Grid;
//     private Vector3 endPosition;
//     public Vector3 LerpOffset;
//     private int xRange;
//     private int yRange;
//     public float posX;
//     public float posY;
//     public float moveDuration = 1f;
//     public float camDuration;
//     private float elapsedTime;
//     float percentageComplete = 0f;  
//     public float CooldownDuration = 3;
//     public float CooldownProgress = 0;
//     bool CooledDown = true;
//     bool CheckPressAgain = false;
//     bool CheckLeft = false;
//     bool CheckRight = false;
//     bool Knight = false;
//     private bool buttonPressedForward;
//     private bool buttonPressedBack;
//     private bool buttonPressedLeft;
//     private bool buttonPressedRight;
//     private bool buttonPressedShift;
//     void Awake()
//     {
//         var grid = Grid.GetComponent<GridCreation>();
//         playerInput = GetComponent<PlayerInput>();
//         playerInputActions = new PlayerInputActions();
//         playerInputActions.Player.Forward.performed += holdForward;
//         playerInputActions.Player.Forward.canceled += releaseForward;
//         playerInputActions.Player.Right.performed += holdRight;
//         playerInputActions.Player.Right.canceled += releaseRight;
//         playerInputActions.Player.Left.performed += holdLeft;
//         playerInputActions.Player.Left.canceled += releaseLeft;
//         playerInputActions.Player.Back.performed += holdBack;
//         playerInputActions.Player.Back.canceled += releaseBack;
//         playerInputActions.Player.PlayerRun.performed += holdRun;
//         playerInputActions.Player.PlayerRun.canceled += releaseRun;
//         playerInputActions.Player.TurnLeft.performed += TurnLeft;
//         playerInputActions.Player.TurnRight.performed += TurnRight;    
//         playerInputActions.Enable();
//         buttonPressedForward = false;
//         xRange = grid.width;
//         yRange = grid.height;
//     }
//     void onEnable() {
//         playerInputActions.Enable();}
//     void onDisable() {
//         playerInputActions.Disable();}
//     public void TurnRight(InputAction.CallbackContext context){ 
            
//             if (Rotating == false) {
//                 CheckRight = true;
//                 CheckLeft = false;
//                 CheckPressAgain = true;
//                 Rotating = true;
//                 startRotation = rb.transform.rotation;
//                 endRotation = startRotation * Quaternion.Euler(0,90,0);
                
//             }
//             }
//     public void TurnLeft(InputAction.CallbackContext context){ 
            
//             if (Rotating == false) {
//                 startRotation = rb.transform.rotation;
//                 endRotation = startRotation * Quaternion.Euler(0,-90,0);
//                 CheckPressAgain = true;
//                 Rotating = true;
//                 CheckLeft = true;
//                 CheckRight = false;
//             }}
//     void holdForward(InputAction.CallbackContext context){
//         buttonPressedForward = true;}
    
//     void releaseForward(InputAction.CallbackContext context){
//         buttonPressedForward = false;}
//     void holdRight(InputAction.CallbackContext context){
//         buttonPressedRight = true;}
    
//     void releaseRight(InputAction.CallbackContext context){
//         buttonPressedRight = false;}
//     void holdLeft(InputAction.CallbackContext context){
//         buttonPressedLeft = true;
//         CheckPressAgain = true;}
    
//     void releaseLeft(InputAction.CallbackContext context){
//         buttonPressedLeft = false;}
//     void holdBack(InputAction.CallbackContext context){
//         buttonPressedBack = true;}
    
//     void releaseBack(InputAction.CallbackContext context){
//         buttonPressedBack = false;}
//     void holdRun(InputAction.CallbackContext context) {
//         buttonPressedShift = true;
//         CheckPressAgain = true;
//         }
//     void releaseRun(InputAction.CallbackContext context) {
//         buttonPressedShift = false;}
//     void Forward() {
//         if (Rotating == false && Moving == false) {
//                 percentageComplete = 0;
//                 startPosition = rb.transform.position;
//                 endPosition = rb.transform.position + rb.transform.rotation * Vector3.forward * 10;
//                 endPosition[1] = rb.transform.localScale.x + 1;
//                 endPosition[0] = Mathf.Round(endPosition[0]);
//                 endPosition[2] = Mathf.Round(endPosition[2]);
//                 Moving = true;
//                 CheckForward = true;
//                 CheckPOS("Rook");
//                 }
//         if (Rotating == true && Moving == false && CheckPressAgain == true) {
//                 CheckForward = true;
//                 CheckPressAgain = false;
//                 CheckPOS("Knight");
//                 }
//         // if (Rotating == false && Moving == true) {
//         //         percentageComplete = 0;
//         //         startPosition = rb.transform.position;
//         //         endPosition = rb.transform.position + rb.transform.rotation * Vector3.forward * 10;
//         //         endPosition[1] = rb.transform.localScale.x + 1;
//         //         endPosition[0] = Mathf.Round(endPosition[0]);
//         //         endPosition[2] = Mathf.Round(endPosition[2]);
//         //         Moving = true;
//         //         CheckForward = true;
//         //         CheckPOS();
//         //         }
//                 }
//     void Left() {
//         if (Rotating == false && Moving == false) {
//                 percentageComplete = 0;
//                 startPosition = rb.transform.position;
//                 if (CheckShift == false) {
//                     endPosition = rb.transform.position + rb.transform.rotation * Vector3.left * 10;}
//                 else 
//                     endPosition = rb.transform.position + rb.transform.rotation * Vector3.left * 30;
//                 endPosition[1] = rb.transform.localScale.x + 1;
//                 endPosition[0] = Mathf.Round(endPosition[0]);
//                 endPosition[2] = Mathf.Round(endPosition[2]);
//                 Moving = true;
//                 CheckPOS("Rook"); }}
//     void Back() {
//         if (Rotating == false && Moving == false) {
//                 percentageComplete = 0;
//                 startPosition = rb.transform.position;
//                 endPosition = rb.transform.position + rb.transform.rotation * Vector3.back * 10;
//                 endPosition[1] = rb.transform.localScale.x + 1;
//                 endPosition[0] = Mathf.Round(endPosition[0]);
//                 endPosition[2] = Mathf.Round(endPosition[2]);
//                 Moving = true;
//                 CheckPOS("Rook");
//                 }}
//     void Right() {
//         if (Rotating == false && Moving == false) {
//                 percentageComplete = 0;
//                 startPosition = rb.transform.position;
//                 if (CheckShift == false) {
//                     endPosition = rb.transform.position + rb.transform.rotation * Vector3.right * 10;}
//                 else 
//                     endPosition = rb.transform.position + rb.transform.rotation * Vector3.right * 30;
//                 endPosition[1] = rb.transform.localScale.x + 1;
//                 endPosition[0] = Mathf.Round(endPosition[0]);
//                 endPosition[2] = Mathf.Round(endPosition[2]);
//                 Moving = true;
//                 CheckPOS("Rook");
//                 }}
//     void CheckPOS(string action) {
//             if (action == "Rook") {
//                 if ((endPosition[0] / 10) > 0 && (endPosition[0] / 10) + 1 != xRange && (endPosition[2] / 10) > 0 && (endPosition[2] / 10) + 1 != yRange) {
//                         PosMove = true;
//                         elapsedTime = 0;}   
//                 else 
//                     {Moving = false;};               
//                     }
//             if (action == "Knight") {
//                 Rotating = true;
//                 if (CheckLeft == true) {
//                         startPosition = rb.transform.position;
//                         endPosition = rb.transform.position + (rb.transform.rotation * Vector3.forward * 20) + (rb.transform.rotation * Vector3.left * 10);
//                         endPosition[1] = rb.transform.localScale.x + 1;                         
//                         CheckLeft = false;
//                         LerpOffset = new Vector3(10, 0, 0);
                    
//                 }
//                 else if (CheckRight == true) {
//                     Debug.Log("Right");
//                     startPosition = rb.transform.position;
//                     endPosition = rb.transform.position + rb.transform.rotation * ((Vector3.right * 10) + (Vector3.forward * 20));
//                     endPosition[1] = rb.transform.localScale.x + 1;
//                     LerpOffset = new Vector3(-10, 0, 0);
//                     CheckRight = false;

//                 }
//                 if ((endPosition[0] / 10) > 0 && (endPosition[0] / 10) < xRange && (endPosition[2] / 10) > 0 && (endPosition[2] / 10) < yRange) {
//                     Debug.Log("Woo");
//                     var check = startPosition + rb.transform.rotation * (Vector3.forward * 10);
//                     // if (check[0] < (xRange + 1)) {
//                     //     Debug.Log(check[0] + " is less than " + (xRange));
//                     //     if (check[2] < (yRange + 1)) {
//                     //         Debug.Log(check[2] + " is less than " + (yRange));
//                     //         if (check[0] > 0) {
//                     //             Debug.Log(check[0] + " is greater than 0");
//                     //             if (check[2] > 0) {
//                     //                 Debug.Log(check[2] + " is greater than 0");
//                     //                 Debug.Log("Success1!");
//                     //                 check = startPosition + rb.transform.rotation * (Vector3.forward * 10);
//                     //                 if (check[0] < (xRange + 1)) {
//                     //                     Debug.Log(check[0] + " is less than " + (xRange));
//                     //                     if (check[2] < (yRange + 1)) {
//                     //                         Debug.Log(check[2] + " is less than " + (yRange));
//                     //                         if (check[0] > 0) {
//                     //                             Debug.Log(check[0] + " is greater than 0");
//                     //                             if (check[2] > 0) {
//                     //                                 Debug.Log(check[2] + " is greater than 0");
//                     //                                 Debug.Log("Success2!");}
//                     //                             else {
//                     //                                 Debug.Log(check[2] + " is not greater than 0");}
//                     //                             }
//                     //                         else {
//                     //                             Debug.Log(check[0] + " is not greater than 0");
//                     //                         }
//                     //                             }
//                     //                     else {
//                     //                         Debug.Log(check[2] + " is not less than " + (yRange + 1));
//                     //                     }
//                     //                         }
//                     //                 else {
//                     //                     Debug.Log(check[0] + " is not less than " + (xRange +1));}}
//                     //             else {
//                     //                 Debug.Log(check[2] + " is not greater than 0");}
//                     //             }
//                     //         else {
//                     //             Debug.Log(check[0] + " is not greater than 0");
//                     //         }
//                     //             }
//                     //     else {
//                     //         Debug.Log(check[2] + " is not less than " + (yRange + 1));
//                     //     }
//                     //         }
//                     // else {
//                     //     Debug.Log(check[0] + " is not less than " + (xRange +1));}
//                     //     }

//                     Debug.Log(check);
//                     if ((check[0] / 10) < xRange && (check[0] / 10) > 0 && check[2] / 10 < yRange && check[2] / 10 > 0) {
//                         Debug.Log(check);
//                         check = startPosition + rb.transform.rotation * ((Vector3.forward * 20));
//                         if ((check[0] / 10) < xRange  && (check[0] / 10) > 0 && (check[2] / 10) < yRange && (check[2] / 10) > 0) {
//                             Debug.Log(check);
//                             Knight = true;
//                             CheckRotate = false;
//                             elapsedTime = 0;}
//                         else {
//                             CheckRotate = false;
//                         }
//                             }
//                     else {
//                         CheckRotate = false;
//                     }
//             }   
//             else {CheckRotate = false;}    
            
//             }}

//     void Update(){
//         if(buttonPressedLeft && Moving == false) {
//             Left();}
//         if(buttonPressedRight && Moving == false) {
//             if (buttonPressedShift && CooledDown == true && CheckPressAgain == true) {
//                 CheckShift = true;
//                 CheckPressAgain = false;
//             }
//             Right();}
//         if(buttonPressedForward && Moving == false) {
//             if (buttonPressedShift) {
//                 CheckShift = true;
//             }
//             Forward();}
//         if(buttonPressedBack && Moving == false) {
//             Back();}

//         if (Moving == true && PosMove == true && Knight == false && CheckRotate =){
//             if (percentageComplete < 1) {
//                 if (CheckForward == true && CheckShift == true) {
//                     elapsedTime += Time.deltaTime;
//                     percentageComplete = elapsedTime / (moveDuration * 0.5f);
//                     rb.transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);}
//                 else if (CheckForward == false && CheckShift == true) {
//                     elapsedTime += Time.deltaTime;
//                     CooledDown = false;
//                     buttonPressedShift = false;
//                     percentageComplete = elapsedTime / (moveDuration / 2);
//                     rb.transform.position = Vector3.Lerp(startPosition, endPosition, dodgeCurve.Evaluate(percentageComplete));}                    
                
//                 else {
//                     elapsedTime += Time.deltaTime;
//                     percentageComplete = elapsedTime / (moveDuration * 1.25f);
//                     rb.transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);                   
//                 }}
       
//             if (percentageComplete > 1) {
//                 posX = Mathf.Round(rb.transform.position.x / 10);
//                 posY = Mathf.Round(rb.transform.position.z / 10);
//                 rb.transform.position = new Vector3(posX * 10, rb.transform.localScale.x + 1, posY * 10);
//                 percentageComplete = 0;
//                 elapsedTime = 0;
//                 Moving = false;
//                 PosMove = false;
//                 CheckForward = false;
//                 CheckShift = false;
//                 if (Rotating == true)
                    
//                     CheckRotate = true;
//                 else
//                     Rotating = false;
//                     }

//                 }
           
//         if (Knight == true){
//             if (percentageComplete < 1) {
//                 elapsedTime += Time.deltaTime;
//                 if (CheckShift == true){
//                     percentageComplete = elapsedTime / (moveDuration * 0.5f);
//                 }
//                 else percentageComplete = elapsedTime / moveDuration;
//                 percentageComplete = elapsedTime / 0.5f;
//                 Vector3 positionOffset = curve.Evaluate(percentageComplete) * (rb.transform.rotation * LerpOffset);
//                 rb.transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete) + positionOffset;
//                 rb.transform.rotation = Quaternion.Lerp(startRotation, endRotation, dodgeCurve.Evaluate(percentageComplete));
//             }

//             if (percentageComplete > 1) {

//                 posX = Mathf.Round(rb.transform.position.x / 10);
//                 posY = Mathf.Round(rb.transform.position.z / 10);
//                 rb.transform.position = new Vector3(posX * 10, rb.transform.localScale.x + 1, posY * 10);
//                 Rotating = false;
//                 Knight = false;
//                 percentageComplete = 0;
//                 elapsedTime = 0;
//                 Moving = false;
//                 CheckLeft = false;
//                 CheckRight = false;
//                 CheckRotate = false;
//                 }}
//         if (Rotating == true && Moving == false && Knight == false){
//             if (percentageComplete < 1) {
//                 elapsedTime += Time.deltaTime;
//                 percentageComplete = elapsedTime / camDuration;
//                 rb.transform.rotation = Quaternion.Lerp(startRotation, endRotation, percentageComplete);}
//             if (percentageComplete > 1) {
//                 Rotating = false;
//                 percentageComplete = 0;
//                 elapsedTime = 0;}}  
//         if (CooledDown == false) {
//             CooldownProgress += Time.deltaTime;
//             if (CooldownProgress >= CooldownDuration) {
//                 CooledDown = true;
//                 CooldownProgress = 0;
//             }
//         }
//     }
// }

