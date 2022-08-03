using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GridMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;
    public GameObject grid;
    public GameObject player;
    public GameObject startPosition;
    public GameObject endPosition;
    private Vector3 LerpOffset;
    public bool CheckMove = false;
    public bool CheckRotate = false;
    public bool CheckLeft = false;
    public bool CheckRight = false;
    public bool IsMoving = false;
    public bool IsRotating = false;
    [SerializeField] AnimationCurve curve;
    [SerializeField] AnimationCurve jumpCurve;
    [SerializeField] AnimationCurve upCurve;
    [SerializeField] AnimationCurve downCurve;
    private Quaternion endRotation;
    private Quaternion startRotation;
    public float camDuration = 0.2f;
    public int Rotation = 0;
    private float elapsedTime;
    float percentageComplete = 0f;  
    public float moveDuration = 0.2f;
    public float jumpDuration = 0.2f;
    public int x;
    public int y;
    public int jumpHeight = 2;
    public bool move = false;
    private bool buttonPressedForward;
    private bool buttonPressedBack;
    private bool buttonPressedLeft;
    private bool buttonPressedRight;
    private bool buttonPressedShift;
    // Start is called before the first frame update

    void Awake() {
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Forward.performed += Forward;
        playerInputActions.Player.Back.performed += Back;
        playerInputActions.Player.Right.performed += Right;
        playerInputActions.Player.Left.performed += Left;
        playerInputActions.Player.Forward.canceled += releaseForward;
        playerInputActions.Player.Back.canceled += releaseBack;
        playerInputActions.Player.Right.canceled += releaseRight;
        playerInputActions.Player.Left.canceled += releaseLeft;
        playerInputActions.Player.TurnLeft.performed += RotateLeft;
        playerInputActions.Player.TurnRight.performed += RotateRight;
        playerInputActions.Player.Jump.performed += Jump;
        playerInputActions.Enable();
    }

    void Start()
    {   var gridArray = grid.GetComponent<GridCreation>().gridArray;
        int Vscale = grid.GetComponent<GridCreation>().Vscale;
        player.transform.position = new Vector3(gridArray[x,y].transform.position.x, gridArray[x,y].GetComponent<GridStats>().layer * Vscale,gridArray[x,y].transform.position.z);
    }

    // Update is called once per frame
    // void Update()
    // {
    //     int Vscale = grid.GetComponent<GridCreation>().Vscale;
    //     var gridArray = grid.GetComponent<GridCreation>().gridArray;
    //     player.transform.position = new Vector3(gridArray[x,y].transform.position.x, gridArray[x,y].GetComponent<GridStats>().layer * Vscale,gridArray[x,y].transform.position.z);  
    // }
    public void Forward(InputAction.CallbackContext context) {
        buttonPressedForward = true;
    }
    void releaseForward(InputAction.CallbackContext context){
        buttonPressedForward = false;}
    public void Back(InputAction.CallbackContext context) {
        buttonPressedBack = true;
    }
    void releaseBack(InputAction.CallbackContext context){
        buttonPressedBack = false;}
    public void Right(InputAction.CallbackContext context) {
        buttonPressedRight = true;
    }
    void releaseRight(InputAction.CallbackContext context){
        buttonPressedRight = false;}
    public void Left(InputAction.CallbackContext context) {
        buttonPressedLeft = true;
    }
    void releaseLeft(InputAction.CallbackContext context){
        buttonPressedLeft = false;}
    public void RotateLeft(InputAction.CallbackContext context) {
        if (CheckRotate == false) {
                CheckRotate = true;
            if (CheckMove == false) {
                if (Rotation == 0) {
                    Rotation = 3;
                }
                else Rotation--;
                startRotation = player.transform.rotation;
                endRotation = player.transform.rotation * Quaternion.Euler(0,-90,0);
                StartCoroutine(Rotate());
        }}}
    public void RotateRight(InputAction.CallbackContext context) {
        if (CheckRotate == false) {
            CheckRotate = true;
            if (CheckMove == false) {
                CheckRotate = true;
                if (Rotation == 3) {
                    Rotation = 0;
                }
                else Rotation++;
                startRotation = player.transform.rotation;
                endRotation = player.transform.rotation * Quaternion.Euler(0,90,0);
                StartCoroutine(Rotate());
        }}}
    public void Jump(InputAction.CallbackContext context) {
        if (CheckMove == false && CheckRotate == false) {
           CheckMove = true;
           GetDirection("Up", Rotation);
    }}

    public IEnumerator Rook(string direction) {
        var gridArray = grid.GetComponent<GridCreation>().gridArray;
        int Vscale = grid.GetComponent<GridCreation>().Vscale;
        startPosition = gridArray[x,y];       
        if (direction == "y+") {
                y++;
        }
        if (direction == "y-") {
            y--;
        }
        if (direction == "x+") {
                x++;
            }            
        if (direction == "x-") {
                x--;
            }
        try {
            if (startPosition.GetComponent<GridStats>().layer == gridArray[x,y].GetComponent<GridStats>().layer) {
                elapsedTime = 0;
                percentageComplete = 0;
                endPosition = gridArray[x,y];

                }
            else {
                CheckMove = false;
                x = startPosition.GetComponent<GridStats>().x;
                y = startPosition.GetComponent<GridStats>().y;
                yield break;
            }
        }
        catch {
            CheckMove = false;
            x = startPosition.GetComponent<GridStats>().x;
            y = startPosition.GetComponent<GridStats>().y;
            yield break;
        }
        while (percentageComplete < 1) {
            elapsedTime += Time.deltaTime;
            percentageComplete = elapsedTime / moveDuration;
            elapsedTime += Time.deltaTime;
            player.transform.position = Vector3.Lerp(new Vector3(startPosition.transform.position.x, startPosition.GetComponent<GridStats>().layer * Vscale, startPosition.transform.position.z), new Vector3(endPosition.transform.position.x, endPosition.GetComponent<GridStats>().layer * Vscale, endPosition.transform.position.z), percentageComplete);
            yield return null;
                }
        // if (CheckRotate == true) {
        //     GetDirection("Knight", Rotation)
        // }
        // else
            CheckMove = false;
        yield return null;            
        }

    public IEnumerator VerticleJump(string direction) {
        var gridArray = grid.GetComponent<GridCreation>().gridArray;
        int Vscale = grid.GetComponent<GridCreation>().Vscale;
        startPosition = gridArray[x,y];       
        if (direction == "y+") {
                y++;
        }
        if (direction == "y-") {
            y--;
        }
        if (direction == "x+") {
                x++;
            }            
        if (direction == "x-") {
                x--;
            }
        try {
            if (startPosition.GetComponent<GridStats>().layer != gridArray[x,y].GetComponent<GridStats>().layer && gridArray[x,y].GetComponent<GridStats>().layer - startPosition.GetComponent<GridStats>().layer <= jumpHeight) {
                elapsedTime = 0;
                percentageComplete = 0;                
                endPosition = gridArray[x,y];      
            }
            else {
                x = startPosition.GetComponent<GridStats>().x;
                y = startPosition.GetComponent<GridStats>().y;
                yield break;              
            }             
            }
        catch {
                x = startPosition.GetComponent<GridStats>().x;
                y = startPosition.GetComponent<GridStats>().y;
                yield break;
        }
        if (startPosition.GetComponent<GridStats>().layer < endPosition.GetComponent<GridStats>().layer) {
            jumpCurve = upCurve;
            LerpOffset = new Vector3(0, endPosition.GetComponent<GridStats>().layer + 3, -0.5f);}
        else {
            jumpCurve = downCurve;
            LerpOffset = new Vector3(0, startPosition.GetComponent<GridStats>().layer * 2.4f, 1);
        }
        while (percentageComplete < 1) {
            elapsedTime += Time.deltaTime;
            percentageComplete = elapsedTime / jumpDuration;
            elapsedTime += Time.deltaTime;
            Vector3 positionOffset = curve.Evaluate(percentageComplete) * (player.transform.rotation * LerpOffset);
            player.transform.position = Vector3.Lerp(new Vector3(startPosition.transform.position.x, startPosition.GetComponent<GridStats>().layer * Vscale, startPosition.transform.position.z), new Vector3(endPosition.transform.position.x, endPosition.GetComponent<GridStats>().layer * Vscale, endPosition.transform.position.z), jumpCurve.Evaluate(percentageComplete)) + positionOffset;
            yield return null;
                }
        CheckMove = false;
        yield return null;
}
    IEnumerator Knight() {
        // var playerPerspective = rb.GetComponent<PlayerPerspective>();
        // CheckShiftAgain = false;
        // IsMoving = true;
        // CheckRotate = true;
        // CheckLeft = false;
        // CheckRight = false;
        // IsRotating = true;
        // if (buttonPressedShift == true){
        //     moveDuration = Run;
        // }
        // else moveDuration = Walk;
        // while (percentageComplete < 1) {
        //     percentageComplete = elapsedTime / moveDuration;
        //     elapsedTime += Time.deltaTime;
        //     Vector3 positionOffset = KnightCurve.Evaluate(percentageComplete) * (rb.transform.rotation * LerpOffset);
        //     rb.transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete) + positionOffset;
        //     rb.transform.rotation = Quaternion.Lerp(startRotation, endRotation, percentageComplete);
        //     yield return null;
        // }
        // percentageComplete = 0;
        // posX = Mathf.Round(rb.transform.position.x / 10);
        // posY = Mathf.Round(rb.transform.position.z / 10);
        // rb.transform.position = new Vector3(posX * 10, rb.transform.localScale.x + 1, posY * 10);
        // IsRotating = false;
        // elapsedTime = 0;
        // IsMoving = false;
        // CheckMove = false;
        // CheckRotate = false;
        // if (playerPerspective.perspectiveSwitch == true) {
        //     StartCoroutine(playerPerspective.RotatePerspective());
        // }
        yield return null;
    }
    IEnumerator Rotate() {
        // var playerPerspective = rb.GetComponent<PlayerPerspective>();
        percentageComplete = 0;
        while (percentageComplete < 1) {
            elapsedTime += Time.deltaTime;
            percentageComplete = elapsedTime / camDuration;
            player.transform.rotation = Quaternion.Lerp(startRotation, endRotation, percentageComplete);
            yield return null;}
        percentageComplete = 0;
        // CheckLeft = false;
        // CheckRight = false;
        CheckRotate = false;
        // IsRotating = false;
        // IsMoving = false;
        percentageComplete = 0;
        elapsedTime = 0;
        CheckMove = false;
        // if (playerPerspective.perspectiveSwitch == true) {
        //     StartCoroutine(playerPerspective.RotatePerspective());
        // }
        }
    public void GetDirection(string direction, int rotation) {
        if (direction == "Forward") {
            if (rotation == 0) {
                StartCoroutine(Rook("y+"));
            }
            if (rotation == 1) {
                StartCoroutine(Rook("x+"));
            }
            if (rotation == 2) {
                StartCoroutine(Rook("y-"));
            }
            if (rotation == 3) {
                StartCoroutine(Rook("x-"));
            }
        }
        if (direction == "Left") {
            if (rotation == 1) {
                StartCoroutine(Rook("y+"));
            }
            if (rotation == 2) {
                StartCoroutine(Rook("x+"));
            }
            if (rotation == 3) {
                StartCoroutine(Rook("y-"));
            }
            if (rotation == 0) {
                StartCoroutine(Rook("x-"));
            }

        }
        if (direction == "Right") {
            if (rotation == 3) {
                StartCoroutine(Rook("y+"));
            }
            if (rotation == 0) {
                StartCoroutine(Rook("x+"));
            }
            if (rotation == 1) {
                StartCoroutine(Rook("y-"));
            }
            if (rotation == 2) {
                StartCoroutine(Rook("x-"));
            }

        }
        if (direction == "Back") {
            if (rotation == 2) {
                StartCoroutine(Rook("y+"));
            }
            if (rotation == 3) {
                StartCoroutine(Rook("x+"));
            }
            if (rotation == 0) {
                StartCoroutine(Rook("y-"));
            }
            if (rotation == 1) {
                StartCoroutine(Rook("x-"));
            }

        }
        if (direction == "Up") {
            if (rotation == 0) {
                StartCoroutine(VerticleJump("y+"));
            }
            if (rotation == 1) {
                StartCoroutine(VerticleJump("x+"));
            }
            if (rotation == 2) {
                StartCoroutine(VerticleJump("y-"));
            }
            if (rotation == 3) {
                StartCoroutine(VerticleJump("x-"));
            }
        }
    }
    void Update(){
        if(buttonPressedLeft && CheckMove == false && CheckRotate == false) {
            CheckMove = true;
            GetDirection("Left", Rotation);}
        if(buttonPressedRight && CheckMove == false && CheckRotate == false) {
            CheckMove = true;
            GetDirection("Right", Rotation);}
        if(buttonPressedForward && CheckMove == false && CheckRotate == false) {
            CheckMove = true;
            // CheckForward = true;
            GetDirection("Forward", Rotation);}
        if(buttonPressedBack && CheckMove == false && CheckRotate == false) {
            CheckMove = true;
            GetDirection("Back", Rotation);}
    }
}
