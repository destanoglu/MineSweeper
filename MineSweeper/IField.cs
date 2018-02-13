namespace MineSweeper
{
    public interface IField
    {
        int RowCount { get; }
        int ColumnCount { get; }
        char this[int row, int column] { get; }
        char GetElement(int row, int column);
    }
}
