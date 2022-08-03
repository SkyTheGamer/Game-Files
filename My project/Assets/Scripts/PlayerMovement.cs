// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.Threading;
// using UnityEngine.InputSystem;
// using Cinemachine;
// public class PlayerMovement: MonoBehaviour
// {   //Variable and gameobjects
//     public CinemachineVirtualCamera cam;
//     public GameObject rb;
//     public GameObject Grid;
//     private PlayerInput playerInput;
//     private PlayerInputActions playerInputActions;
//     private int xRange;
//     private int yRange;
//     private int scale;
//     public float posX;
//     public float posY;
//     public float Run = 0.25f;
//     public float Walk = 0.5f;
//     public float Dodge = 0.2f;
//     private float moveDuration = 1f;
//     public float camDuration;
//     private float elapsedTime;
//     float percentageComplete = 0f;  
//     public float CooldownDuration = 3;
//     //If one is true, do not do another interaction
//     public bool IsRotating = false;
//     public bool IsMoving = false;
//     public bool IsDodging = false;
//     //Checks
//     public bool CheckMove = false;
//     bool CheckShiftAgain = false;
//     bool CheckLeft = false;
//     bool CheckRight = false;
//     public bool CheckRotate = false;
//     public bool CheckForward = false;
//     //Position Lerp
//     private Vector3 startPosition;
//     private Vector3 endPosition;
//     private Vector3 LerpOffset;
//     private Vector3 startPerspective;
//     private Vector3 endPerspective;
//     [SerializeField] private AnimationCurve KnightCurve;
//     //Rotation Lerp
//     private Quaternion endRotation;
//     [SerializeField] private AnimationCurve curve;
//     private Quaternion startRotation;
//     //Dodging
//     bool CooledDown = true;
//     string Direction = "null";
//     //Continuous button
//     private bool buttonPressedForward;
//     private bool buttonPressedBack;
//     private bool buttonPressedLeft;
//     private bool buttonPressedRight;
//     private bool buttonPressedShift;
//     void Awake()
//     {   var grid = Grid.GetComponent<GridCreation>();
//         var playerPerspective = rb.GetComponent<PlayerPerspective>();
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
//         scale = grid.scale;
//     }
//     void onEnable() {
//         playerInputActions.Enable();}
//     void onDisable() {
//         playerInputActions.Disable();}
//     public void TurnRight(InputAction.CallbackContext context){ 
            
//             if (CheckRotate == false) {
//                 CheckRotate = true;
//                 CheckRight = true;
//                 startRotation = rb.transform.rotation;
//                 endRotation = startRotation * Quaternion.Euler(0,90,0);
//                 if (IsMoving == false && IsDodging == false)
//                     StartCoroutine(Rotate());
                
//             }
//             }
//     public void TurnLeft(InputAction.CallbackContext context){ 
            
//             if (CheckRotate == false) {
//                 CheckRotate = true;
//                 startRotation = rb.transform.rotation;
//                 endRotation = startRotation * Quaternion.Euler(0,-90,0);
//                 CheckLeft = true;
//                 if (IsMoving == false && IsDodging == false)
//                     StartCoroutine(Rotate());
//             }}
//     // void Perspective(InputAction.CallbackContext context) {
//     //     CinemachineTransposer transposer = cam.GetCinemachineComponent<CinemachineTransposer>();
//     //     if (IsRotating == false && IsMoving == false && IsDodging == false) {
//     //         IsRotating = true;
//     //         CheckRotate = true;
//     //         CheckMove = true;
//     //         startPerspective = transposer.m_FollowOffset;
//     //         if (CheckThird == true) {
//     //             Debug.Log("Hello");
//     //             endPerspective = transposer.m_FollowOffset + new Vector3(0, -150, 30);
//     //             CheckThird = false;}
//     //         else if (CheckThird == false) {
//     //             CheckThird = true;
//     //             endPerspective = transposer.m_FollowOffset + new Vector3(0, 150, -30);
//     //         }
//     //         StartCoroutine(RotatePerspective());
//     //         }
//     //     }
//     void holdForward(InputAction.CallbackContext context){
//         buttonPressedForward = true;}
    
//     void releaseForward(InputAction.CallbackContext context){
//         buttonPressedForward = false;}
//     void holdRight(InputAction.CallbackContext context){
//         buttonPressedRight = true;}
    
//     void releaseRight(InputAction.CallbackContext context){
//         buttonPressedRight = false;}
//     void holdLeft(InputAction.CallbackContext context){
//         buttonPressedLeft = true;}
    
//     void releaseLeft(InputAction.CallbackContext context){
//         buttonPressedLeft = false;}
//     void holdBack(InputAction.CallbackContext context){
//         buttonPressedBack = true;}
    
//     void releaseBack(InputAction.CallbackContext context){
//         buttonPressedBack = false;}
//     void holdRun(InputAction.CallbackContext context) {
//         buttonPressedShift = true;
//         if (IsDodging == false){
//             CheckShiftAgain = true;}
//         }
//     void releaseRun(InputAction.CallbackContext context) {
//         buttonPressedShift = false;}
//     void Movement(string direction) {
//         CheckMove = true;
//         startPosition = rb.transform.position;
//         if (IsRotating == false && IsMoving == false && IsDodging == false) {
//                 if (direction == "Forward") {
//                     CheckForward = true;
//                     endPosition = rb.transform.position + rb.transform.rotation * Vector3.forward * 10;}
//                 else if (direction == "Left") {
//                     if (CheckShiftAgain == false || CooledDown == false) {
//                         endPosition = rb.transform.position + rb.transform.rotation * Vector3.left * 10;}
//                     else endPosition = rb.transform.position + rb.transform.rotation * Vector3.left * 20;}
//                 else if (direction == "Right") {
//                     if (CheckShiftAgain == false || CooledDown == false) {
//                         endPosition = rb.transform.position + rb.transform.rotation * Vector3.right * 10;}
//                     else endPosition = rb.transform.position + rb.transform.rotation * Vector3.right * 20;}
//                 else if (direction == "Back") {
//                     if (CheckShiftAgain == false || CooledDown == false) {
//                         endPosition = rb.transform.position + rb.transform.rotation * Vector3.back * 10;}
//                     else endPosition = rb.transform.position + rb.transform.rotation * Vector3.back * 20;}
//                 if (CheckForward == false && CheckShiftAgain == true && CooledDown == true) {
//                     CheckPos("Dodge");
//                 }
//                 else {
//                     CheckPos("Rook");}
//                 }
//                 }
//     void CheckPos(string action) {
//             if (action == "Rook") {
//                 endPosition[1] = rb.transform.localScale.x + 1;
//                 endPosition[0] = Mathf.Round(endPosition[0]);
//                 endPosition[2] = Mathf.Round(endPosition[2]);
//                 if ((endPosition[0] / scale) > 0 && (endPosition[0] / scale) + 1 != xRange && (endPosition[2] / scale) > 0 && (endPosition[2] / scale) + 1 != yRange) {
//                         elapsedTime = 0;
//                         StartCoroutine(Rook());}   
//                 else 
//                     CheckMove = false;               
//                     }
//             if (action == "Knight") {
//                 if (CheckForward == true) {
//                     if (CheckLeft == true) {
//                             startPosition = rb.transform.position;
//                             endPosition = rb.transform.position + (rb.transform.rotation * Vector3.forward * 20) + (rb.transform.rotation * Vector3.left * 10);
//                             endPosition[1] = rb.transform.localScale.x + 1;                         
//                             CheckLeft = false;
//                             LerpOffset = new Vector3(10, 0, 0);
//                     }
//                     else if (CheckRight == true) {
//                         startPosition = rb.transform.position;
//                         endPosition = rb.transform.position + rb.transform.rotation * ((Vector3.right * 10) + (Vector3.forward * 20));
//                         endPosition[1] = rb.transform.localScale.x + 1;
//                         LerpOffset = new Vector3(-10, 0, 0);
//                         CheckRight = false;
//                     }
//                     if ((endPosition[0] / scale) > 0 && (endPosition[0] / scale) < (xRange - 1) && (endPosition[2] / scale) > 0 && (endPosition[2] / scale) < (yRange - 1)) {
//                         var check = startPosition + rb.transform.rotation * (Vector3.forward * 10);
//                         if ((check[0] / scale) < (xRange - 1) && (check[0] / scale) > 0 && check[2] / scale < (yRange - 1) && check[2] / scale > 0) {
//                             check = startPosition + rb.transform.rotation * ((Vector3.forward * 20));
//                             if ((check[0] / scale) < (xRange - 1)  && (check[0] / scale) > 0 && (check[2] / scale) < (yRange - 1) && (check[2] / scale) > 0) {
//                                 StartCoroutine(Knight());}
//                             else {
//                                 StartCoroutine(Rotate());
//                             }
//                                 }
//                         else {
//                             StartCoroutine(Rotate());
//                         }
//                 }   
//                 else {
//                     StartCoroutine(Rotate());}}    
//             else {
//                 StartCoroutine(Rotate());}  
//             }
//             if (action == "Dodge") {
//                     if (Direction == "Left") {
//                         var check = startPosition + rb.transform.rotation * (Vector3.left * 10);
//                         if (((check[0] / scale) < (xRange - 1) && (check[0] / scale) > 0 && check[2] / scale < (yRange - 1) && check[2] / scale > 0)) {
//                             if ((endPosition[0] / scale) > 0 && (endPosition[0] / scale) < (xRange - 1) && (endPosition[2] / scale) > 0 && (endPosition[2] / scale) < (yRange - 1)) {
//                                 StartCoroutine(Dodging());}
//                             else {
//                                 endPosition = check;
//                                 StartCoroutine(Rook());
//                             }
//                         }
//                         else CheckMove = false;
//                     }
//                     else if (Direction == "Right") {
//                         var check = startPosition + rb.transform.rotation * (Vector3.right * 10);
//                         if (((check[0] / scale) < (xRange - 1) && (check[0] / scale) > 0 && check[2] / scale < yRange && check[2] / scale > 0)) {
//                             if ((endPosition[0] / scale) > 0 && (endPosition[0] / scale) < xRange && (endPosition[2] / scale) > 0 && (endPosition[2] / scale) < yRange) {
//                                 StartCoroutine(Dodging());}
//                             else {
//                                 endPosition = check;
//                                 StartCoroutine(Rook());
//                             }
//                         }
//                         else CheckMove = false;                                                
//                     }
//                     else if (Direction == "Back") {
//                         var check = startPosition + rb.transform.rotation * (Vector3.back * 10);
//                         if (((check[0] / scale) < xRange && (check[0] / scale) > 0 && check[2] / scale < yRange && check[2] / scale > 0)) {
//                             if ((endPosition[0] / scale) > 0 && (endPosition[0] / scale) < xRange && (endPosition[2] / scale) > 0 && (endPosition[2] / scale) < yRange) {
//                                 StartCoroutine(Dodging());}
//                             else {
//                                 endPosition = check;
//                                 StartCoroutine(Rook());
//                             }
//                         }
//                         else CheckMove = false;                             
//                     }
//             }
//             }

//     IEnumerator Rook() {
//         var playerPerspective = rb.GetComponent<PlayerPerspective>();
//         IsMoving = true;
//         CheckShiftAgain = false;
//         if (buttonPressedShift == true && CheckForward == true){
//             moveDuration = Run;
//         }
//         else moveDuration = Walk;

//         while (percentageComplete < 1) {
//             elapsedTime += Time.deltaTime;
//             percentageComplete = elapsedTime / moveDuration;
//             elapsedTime += Time.deltaTime;
//             rb.transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);
//             yield return null;}
//         percentageComplete = 0;
//         posX = Mathf.Round(rb.transform.position.x / 10);
//         posY = Mathf.Round(rb.transform.position.z / 10);
//         rb.transform.position = new Vector3(posX * 10, rb.transform.localScale.x + 1, posY * 10);
//         elapsedTime = 0;
//         if (CheckRotate == true)
//             {CheckPos("Knight");}
//         else if (playerPerspective.perspectiveSwitch == true) {
//             StartCoroutine(playerPerspective.RotatePerspective());
//         }
//         else {
//                 IsMoving = false;
//                 CheckMove = false;
//                 CheckForward = false;
//             }
//         yield return null;


//     }
//     IEnumerator Knight() {
//         var playerPerspective = rb.GetComponent<PlayerPerspective>();
//         CheckShiftAgain = false;
//         IsMoving = true;
//         CheckRotate = true;
//         CheckLeft = false;
//         CheckRight = false;
//         IsRotating = true;
//         if (buttonPressedShift == true){
//             moveDuration = Run;
//         }
//         else moveDuration = Walk;
//         while (percentageComplete < 1) {
//             percentageComplete = elapsedTime / moveDuration;
//             elapsedTime += Time.deltaTime;
//             Vector3 positionOffset = KnightCurve.Evaluate(percentageComplete) * (rb.transform.rotation * LerpOffset);
//             rb.transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete) + positionOffset;
//             rb.transform.rotation = Quaternion.Lerp(startRotation, endRotation, percentageComplete);
//             yield return null;
//         }
//         percentageComplete = 0;
//         posX = Mathf.Round(rb.transform.position.x / 10);
//         posY = Mathf.Round(rb.transform.position.z / 10);
//         rb.transform.position = new Vector3(posX * 10, rb.transform.localScale.x + 1, posY * 10);
//         IsRotating = false;
//         elapsedTime = 0;
//         IsMoving = false;
//         CheckMove = false;
//         CheckRotate = false;
//         if (playerPerspective.perspectiveSwitch == true) {
//             StartCoroutine(playerPerspective.RotatePerspective());
//         }
//         yield return null;
//     }
//     IEnumerator Rotate() {
//         var playerPerspective = rb.GetComponent<PlayerPerspective>();
//         IsRotating = true;
//         while (percentageComplete < 1) {
//             elapsedTime += Time.deltaTime;
//             percentageComplete = elapsedTime / camDuration;
//             rb.transform.rotation = Quaternion.Lerp(startRotation, endRotation, curve.Evaluate(percentageComplete));
//             yield return null;}
//         percentageComplete = 0;
//         CheckLeft = false;
//         CheckRight = false;
//         CheckRotate = false;
//         IsRotating = false;
//         IsMoving = false;
//         percentageComplete = 0;
//         elapsedTime = 0;
//         CheckMove = false;
//         if (playerPerspective.perspectiveSwitch == true) {
//             StartCoroutine(playerPerspective.RotatePerspective());
//         }
//         yield return null;
//             }
//     IEnumerator Dodging() {
//         var playerPerspective = rb.GetComponent<PlayerPerspective>();
//         CooledDown = false;
//         CheckShiftAgain = false;
//         IsDodging = true;
//         while (percentageComplete < 1) {
//             elapsedTime += Time.deltaTime;
//             percentageComplete = elapsedTime / Dodge;
//             elapsedTime += Time.deltaTime;
//             rb.transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percentageComplete));
//             yield return null;}
//         percentageComplete = 0;
//         posX = Mathf.Round(rb.transform.position.x / 10);
//         posY = Mathf.Round(rb.transform.position.z / 10);
//         rb.transform.position = new Vector3(posX * 10, rb.transform.localScale.x + 1, posY * 10);
//         elapsedTime = 0;
//         IsDodging = false;
//         CheckMove = false;
//         if (playerPerspective.perspectiveSwitch == true) {
//             StartCoroutine(playerPerspective.RotatePerspective());
//         }
//         yield return new WaitForSeconds(CooldownDuration);
//         CooledDown = true;
//     }
//     // IEnumerator RotatePerspective() {
//     //         CinemachineTransposer transposer = cam.GetCinemachineComponent<CinemachineTransposer>();
//     //         elapsedTime = 0;
//     //         percentageComplete = 0;
//     //         while (percentageComplete < 1) {
//     //             elapsedTime += Time.deltaTime;
//     //             percentageComplete = elapsedTime / 0.5f;
//     //             elapsedTime += Time.deltaTime;
//     //             transposer.m_FollowOffset = Vector3.Lerp(startPerspective, endPerspective, curve.Evaluate(percentageComplete));
//     //             yield return null;}
//     //         percentageComplete = 0;
//     //         elapsedTime = 0;
//     //         IsRotating = false;
//     //         CheckMove = false;
//     //         CheckRotate = false;
//     //         yield return null;
//     // }

//     void Update(){
//         if(buttonPressedLeft && CheckMove == false) {
//             CheckMove = true;
//             Direction = "Left";
//             Movement("Left");}
//         if(buttonPressedRight && CheckMove == false) {
//             CheckMove = true;
//             Direction = "Right";
//             Movement("Right");}
//         if(buttonPressedForward && CheckMove == false) {
//             CheckMove = true;
//             CheckForward = true;
//             Direction = "Forward";
//             Movement("Forward");}
//         if(buttonPressedBack && CheckMove == false) {
//             CheckMove = true;
//             Direction = "Back";
//             Movement("Back");}
//     }
// }
             
                 