using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject redChecker;
    public GameObject blackChecker;
    public TextMeshPro winnerText;
    
    private GameObject currChecker;
    private Rigidbody currCheckerRB;
    private float[] columnXPositions = {-4.29f, -2.99f, -1.69f, -0.39f, 0.91f, 2.21f, 3.51f};
    private int numCols = 7;

    private Connect4Board theBoard;
    private string[] colors = { "R", "B" };
    private GameObject[] checkerPrefabs = new GameObject[2];
    private int moveCount = 0;

    private int movePos = 0;

    private bool isGameOver = false;
    private bool isPlayerTurn = true;


    void Start()
    {
        this.winnerText.enabled = false;
        this.checkerPrefabs[0] = this.redChecker;
        this.checkerPrefabs[1] = this.blackChecker;
        this.theBoard = new Connect4Board();
        this.currChecker = Instantiate(this.checkerPrefabs[this.moveCount%2], new Vector3(this.columnXPositions[this.movePos], 5.55f, 0f), Quaternion.Euler(90f, 0f, 0f));
        this.currCheckerRB = this.currChecker.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!this.isGameOver)
        {
            if(this.isPlayerTurn)
            {
                if(Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if(this.movePos < this.numCols-1)
                    {
                        this.movePos++;
                        this.currChecker.transform.position = new Vector3(this.columnXPositions[this.movePos], 5.55f, 0f);
                    }
                }

                if(Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if(this.movePos > 0)
                    {
                        this.movePos--;
                        this.currChecker.transform.position = new Vector3(this.columnXPositions[this.movePos], 5.55f, 0f);
                    }
                }

                if(Input.GetKeyDown(KeyCode.Space))
                {
                    //check to see if it is a legal move
                    MoveResult result = this.theBoard.makeMove(this.movePos, this.colors[this.moveCount % 2]);
                    if(result.success)
                    {
                        this.currChecker.GetComponent<CapsuleCollider>().enabled = true;
                        this.currCheckerRB.useGravity = true;
                        this.moveCount++;
                        this.movePos = 0;
                        if(this.theBoard.isWinner(result))
                        {
                            this.isGameOver = true;
                            this.winnerText.enabled = true;
                        }
                        else
                        {
                            //player made successful turn, but game is not over
                            this.isPlayerTurn = false;
                            this.currChecker = Instantiate(this.checkerPrefabs[this.moveCount%2], new Vector3(this.columnXPositions[0], 5.55f, 0f), Quaternion.Euler(90f, 0f, 0f));
                            this.currCheckerRB = this.currChecker.GetComponent<Rigidbody>();
                        } 
                    }
                }
            }
            else
            {
                //computers turn
                MoveResult result;
                do
                {
                    int col = Random.Range(0, this.numCols);
                    result = this.theBoard.makeMove(this.movePos, this.colors[this.moveCount % 2]);
                }
                while(!result.success);

                //result is a legal move by the computer
                this.currChecker.GetComponent<CapsuleCollider>().enabled = true;
                this.currCheckerRB.useGravity = true;
                this.moveCount++;
                this.movePos = 0;
                if(this.theBoard.isWinner(result))
                {
                    this.isGameOver = true;
                    this.winnerText.enabled = true;
                }
                else
                {
                    //player made successful turn, but game is not over
                    this.isPlayerTurn = true;
                    this.currChecker = Instantiate(this.checkerPrefabs[this.moveCount%2], new Vector3(this.columnXPositions[0], 5.55f, 0f), Quaternion.Euler(90f, 0f, 0f));
                    this.currCheckerRB = this.currChecker.GetComponent<Rigidbody>();
                } 
                
            }
        }
    }
}
