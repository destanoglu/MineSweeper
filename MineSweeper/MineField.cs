using System;
using System.CodeDom;
using System.Collections.Generic;

namespace MineSweeper
{
    public class MineField : IField
    {
        public static char MINE = '*';
        public int RowCount { get; }
        public int ColumnCount { get; }

        private char[,] _field;
        private int _paddedRowCount;
        private int _paddedColumnCount;

        /// Fields are accepted as string list.
        /// Example:
        /// *...
        /// *.*.
        /// ....
        /// Represents a field with 3 rows and 4 colums which has 3 mines (*)
        public MineField(int rowCount, int columnCount, IList<string> fieldElements)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;

            _field = CreateField(RowCount, ColumnCount, fieldElements);
        }

        public char this[int row, int column] => GetElement(row, column);

        public char GetElement(int row, int column)
        {
            if (row < -1 || row > RowCount)
            {
                throw new ArgumentOutOfRangeException(nameof(row));
            }

            if (column < -1 || column > ColumnCount)
            {
                throw new ArgumentOutOfRangeException(nameof(column));
            }

            return _field[row + 1, column + 1];
        }

        private char[,] CreateField(int rowCount, int columnCount, IList<string> fieldElements)
        {
            _paddedRowCount = rowCount + 2;
            _paddedColumnCount = columnCount + 2;

            // Adding padding fields to avoid boundary checks
            var field = new char[_paddedRowCount, _paddedColumnCount];

            if (fieldElements.Count != rowCount)
            {
                throw new ArgumentException("Row count match exception");
            }

            // Apply padding
            for (int i = 0; i < _paddedColumnCount; ++i)
            {
                field[0, i] = '.';
                field[_paddedRowCount - 1, i] = '.';
            }
            for (int i = 0; i < _paddedRowCount; ++i)
            {
                field[i, 0] = '.';
                field[i, _paddedColumnCount - 1] = '.';
            }

            int rowIndex = 1;
            foreach (var rowElements in fieldElements)
            {
                if (rowElements.Length != columnCount)
                {
                    throw new ArgumentException("Column count match exception");
                }

                for (var j = 0; j < rowElements.Length; ++j)
                {
                    field[rowIndex, j + 1] = rowElements[j];
                }

                ++rowIndex;
            }

            return field;
        }
    }
}
