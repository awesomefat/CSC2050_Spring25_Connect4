

public class MoveResult
{
    public bool success;
    public int row;
    public int column;
    public string color;

    public MoveResult()
    {
        this.success = false;
        this.row = -1;
        this.column = -1;
        this.color = "N/A";
    }

    public MoveResult(bool success, int row, int column, string color)
    {
        this.success = success;
        this.row = row;
        this.column = column;
        this.color = color;
    }


}
