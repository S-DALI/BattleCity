using System.Collections.Generic;
using UnityEngine;

public class WallCreator
{
    public EnvironmentsCell[,] Create(int width, int height)
    {
        EnvironmentsCell[,] environments = new EnvironmentsCell[width, height];
        for (int x = 0; x < environments.GetLength(0)-1; x++)
        {
            for (int y = 0; y < environments.GetLength(1)-1; y++)
            {
                environments[x, y] = new EnvironmentsCell { X = x, Y = y };
            }
        }
        RemoveEnvironment(environments, width, height);

        return environments;
    }

    private void RemoveEnvironment(EnvironmentsCell[,] environments, int width, int height)
    {
        EnvironmentsCell current = environments[0, 0];
        current.isVisitedCell = true;
        Stack<EnvironmentsCell> stack = new Stack<EnvironmentsCell>();
        do
        {
            List<EnvironmentsCell> unvisitedCell = new List<EnvironmentsCell>();

            if (current.X > 0 && !environments[current.X - 1, current.Y].isVisitedCell)
                unvisitedCell.Add(environments[current.X - 1, current.Y]);
            if (current.Y > 0 && !environments[current.X, current.Y - 1].isVisitedCell)
                unvisitedCell.Add(environments[current.X, current.Y - 1]);
            if (current.X < width - 2 && !environments[current.X + 1, current.Y].isVisitedCell)
                unvisitedCell.Add(environments[current.X + 1, current.Y]);
            if (current.Y < height - 2 && !environments[current.X, current.Y + 1].isVisitedCell)
                unvisitedCell.Add(environments[current.X, current.Y + 1]);

            if (unvisitedCell.Count > 0)
            {
                EnvironmentsCell chosen = unvisitedCell[Random.Range(0, unvisitedCell.Count)];
                DestroyWall(current,chosen);
                chosen.isVisitedCell = true;
                stack.Push(chosen);
                current = chosen;
            }
            else
            {
                current = stack.Pop();
            }

        } while (stack.Count > 0);
    }

    private void DestroyWall(EnvironmentsCell firstCell, EnvironmentsCell secondCell)
    {
        if(firstCell.X == secondCell.X)
        {
            if (firstCell.Y == secondCell.Y)
                firstCell.isWallBackCreated = false;
            else
                secondCell.isWallBackCreated = false;
        }
        else
        {
            if (firstCell.X > secondCell.X)
                firstCell.isWallLeftCreated = false;
            else secondCell.isWallLeftCreated = false;
        }
    }
}
