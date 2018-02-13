using System.Collections.Generic;

namespace MineSweeper
{
    public class MineSweeper
    {
        private IField _field;
        

        public MineSweeper(IField field)
        {
            _field = field;
        }

        public IList<string> GenerateSolution()
        {
            var solution = new List<string>();
            for (var i = 0; i < _field.RowCount; i++)
            {
                var rowElement = string.Empty;
                for (var j = 0; j < _field.ColumnCount; j++)
                {
                    rowElement += GetMineCount(i, j);
                }
                solution.Add(rowElement);
            }
            
            return solution;
        }

        public string GetMineCount(int i, int j)
        {
            if (_field[i, j] == MineField.MINE)
            {
                return MineField.MINE.ToString();
            }

            var count = 0;
            for (var rowIndex = i - 1; rowIndex <= i + 1; ++rowIndex)
            {
                for (var colIndex = j - 1; colIndex <= j + 1; colIndex++)
                {
                    if (_field[rowIndex, colIndex] == MineField.MINE)
                    {
                        ++count;
                    }
                }
            }

            return count.ToString();
        }
    }
}
