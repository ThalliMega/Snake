﻿using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake
{
    public class Render
    {
        readonly Rectangle[,] elements;
        readonly Dictionary<int, Brush> brushMap = new Dictionary<int, Brush>()
        {
            {-2,Brushes.Black },
            {-1,Brushes.LightSkyBlue },
            {0,Brushes.Gray },
            {1,Brushes.MediumVioletRed }
        };
        public Render(Grid grid, int[,] board)
        {
            int row = grid.RowDefinitions.Count, col = grid.ColumnDefinitions.Count;
            elements = new Rectangle[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    int color = board[i, j];
                    var ele = new Rectangle()
                    {
                        Fill = brushMap.ContainsKey(color) ? brushMap[color] : brushMap[1]
                    };
                    Grid.SetRow(ele, i);
                    Grid.SetColumn(ele, j);
                    elements[i, j] = ele;
                    grid.Children.Add(ele);
                }
            }
        }
        public void Paint(IReadOnlyCollection<int[]> points)
        {
            foreach (int[] point in points)
            {
                var ele = elements[point[0], point[1]];
                ele.Fill = brushMap[point[2]];
            }
        }
    }
}
