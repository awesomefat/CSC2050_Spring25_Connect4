using System;

public class Connect4Board
{
    private Checker[,] theBoard;
    private int rows = 6;
    private int columns = 7;

    public Connect4Board()
    {
        this.theBoard = new Checker[this.rows, this.columns];
    }
    
    public  void display()
    {
        for (int row = 0; row < this.rows; row++)
        {
            for (int col = 0; col < this.columns; col++)
            {
                Console.Write(this.theBoard[row, col] == null ? "_" : this.theBoard[row,col].GetColor());
                Console.Write(" "); // Add space between cells
            }
            Console.WriteLine(); // New line after each row
        }
    }

    public bool isWinner(MoveResult result)
    {
        //check to see if result was involved in a horizontal win
        //check to see if result was involved in a vertical win
        //check to see if result was involved in a diagonal win
        //return true if yes, and false if no
        
        //vertical check: look at last move and see how many checkers below us in a row match our color
        string winningColor = result.color;
        int startRow = result.row;
        int startColumn = result.column;
        int verticalCount = 1;
        
        for(int i = startRow + 1; i < this.rows; i++)
        {
            //do the color of the checkers match?
            Checker currChecker = this.theBoard[i,startColumn];
            string currCheckerColor = currChecker.GetColor();
            if(String.Equals(winningColor, currCheckerColor))
            {
                verticalCount++;
            }
            else
            {
                //we have gone as far as we can go, so break out of the loop to check if we got 4 in a row
                break;
            }
        }
        
        //was there a verical winner?
        if(verticalCount >= 4)
        {
            return true;
        }
        
        //Now lets check for horizontal winners
        //check left direction first
        int horizontalCount = 1;
        for(int i = startColumn - 1; i >= 0; i--)
        {
            //are we looking at a real checker or is this a place where a move has not occured 
            if(this.theBoard[result.row,i] == null)
            {
                break;
            }
            
            Checker currChecker = this.theBoard[result.row,i];
            string currCheckerColor = currChecker.GetColor();
            if(String.Equals(winningColor, currCheckerColor))
            {
                horizontalCount++;
            }
            else
            {
                //we are looking at a different color, so we have gone as far left as we can
                break;
            }
        }
    
        //now go to the right:
        for(int i = startColumn + 1; i < this.columns; i++)
        {
            //are we looking at a real checker or is this a place where a move has not occured 
            if(this.theBoard[result.row,i] == null)
            {
                break;
            }
            Checker currChecker = this.theBoard[result.row,i];
            string currCheckerColor = currChecker.GetColor();
            if(String.Equals(winningColor, currCheckerColor))
            {
                horizontalCount++;
            }
            else
            {
                //we are looking at a different color, so we have gone as far left as we can
                break;
            }
        }
        
        //horizontalCount should be the total number of same color checkers in a 
        //row that match the winning color and involve the most recent move.
        if(horizontalCount >= 4)
        {
            //we have a horizontal winner
            return true;
        }
        
                                Console.WriteLine("**** HERE 2****");

        //now check for diagonal winners
        int diagonalUpLeftDownRightCount = 1;
        for(int i = startColumn - 1, j  = startRow - 1; (i >= 0) && (j >= 0); i--, j--)
        {
            //are we looking at a real checker or is this a place where a move has not occured 
            if(this.theBoard[j,i] == null)
            {
                break;
            }
            
            //***** change result.row to j
            Checker currChecker = this.theBoard[j,i];
            string currCheckerColor = currChecker.GetColor();
            if(String.Equals(winningColor, currCheckerColor))
            {
                diagonalUpLeftDownRightCount++;
            }
            else
            {
                //we are looking at a different color, so we have gone as far left as we can
                break;
            }
        }
        
                                Console.WriteLine("**** HERE 2.5****");


        //now do right and down
        for(int i = startColumn + 1, j  = startRow + 1; (i < this.columns) && (j < this.rows); i++, j++)
        {
                        Console.WriteLine("***** " + i + " " + j);

            //are we looking at a real checker or is this a place where a move has not occured 
            if(this.theBoard[j,i] == null)
            {
                break;
            }
            
            Console.WriteLine("** ->" + result.row);
            //*** change result.row to j
            Checker currChecker = this.theBoard[j,i];
            string currCheckerColor = currChecker.GetColor();
            if(String.Equals(winningColor, currCheckerColor))
            {
                diagonalUpLeftDownRightCount++;
            }
            else
            {
                //we are looking at a different color, so we have gone as far left as we can
                break;
            }
        }
        
        //was there a winner diagonally from upper left to lower right?
        if(diagonalUpLeftDownRightCount >= 4)
        {
            return true;
        }
        
                                Console.WriteLine("**** HERE 3****");

        //*******Check for diagonal lower left to upper right
        int diagonalLowerLeftUpperRightCount = 1;
        //****** changed j >= 0 to j < this.rows
        for(int i = startColumn - 1, j  = startRow + 1; (i >= 0) && (j < this.rows); i--, j++)
        {
            Console.WriteLine("***** " + i + " " + j);
            //are we looking at a real checker or is this a place where a move has not occured 
            if(this.theBoard[j,i] == null)
            {
                break;
            }
            
            Console.WriteLine("** ->" + result.row);
            //*** change result.row to j
            Checker currChecker = this.theBoard[j,i];
            string currCheckerColor = currChecker.GetColor();
            if(String.Equals(winningColor, currCheckerColor))
            {
                diagonalLowerLeftUpperRightCount++;
            }
            else
            {
                //we are looking at a different color, so we have gone as far left as we can
                break;
            }
        }
        
        //now do right and up
        //***** changed boolean on both rows and cols
                                Console.WriteLine("**** HERE 3.5****");

        for(int i = startColumn + 1, j  = startRow - 1; (i < this.columns) && (j >= 0); i++, j--)
        {
            //are we looking at a real checker or is this a place where a move has not occured 
            if(this.theBoard[j,i] == null)
            {
                break;
            }
            
            //change result.row to j
            Checker currChecker = this.theBoard[j,i];
            string currCheckerColor = currChecker.GetColor();
            if(String.Equals(winningColor, currCheckerColor))
            {
                diagonalLowerLeftUpperRightCount++;
            }
            else
            {
                //we are looking at a different color, so we have gone as far left as we can
                break;
            }
        }
        
        //was there a winner diagonally from upper left to lower right?
        if(diagonalLowerLeftUpperRightCount >= 4)
        {
            return true;
        }
        
                                Console.WriteLine("**** HERE 4****");

        //if we are still alive.... there was NOT A WINNER
        return false;
    }
    
    public MoveResult makeMove(int column, string color)
    {
        MoveResult result = new MoveResult();

        if(column < 0 || column > this.columns - 1)
        {
            return result; // Invalid column
        }

        if(this.theBoard[0,column] != null)
        {
            return result; // Column is full
        }

        //a legal move and room for a new checker, so drop the checker onto the board
        for (int i = this.rows - 1; i >= 0; i--)
        {
            if (this.theBoard[i,column] == null)
            {
                this.theBoard[i,column] = new Checker(color); // Assuming "Red" is the color of the checker
                result.success = true;
                result.row = i;
                result.column = column;
                result.color = color;
                break;
            }
        }
        return result;
    }
}
