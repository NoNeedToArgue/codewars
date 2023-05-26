// Write a method that takes a field for well-known board game "Battleship" as an argument and returns true if it has a valid disposition of ships, false otherwise. Argument is guaranteed to be 10*10 two-dimension array. Elements in the array are numbers, 0 if the cell is free and 1 if occupied by ship.

// Battleship (also Battleships or Sea Battle) is a guessing game for two players. Each player has a 10x10 grid containing several "ships" and objective is to destroy enemy's forces by targetting individual cells on his field. The ship occupies one or more cells in the grid. Size and number of ships may differ from version to version. In this kata we will use Soviet/Russian version of the game.

// Before the game begins, players set up the board and place the ships accordingly to the following rules:
// There must be single battleship (size of 4 cells), 2 cruisers (size 3), 3 destroyers (size 2) and 4 submarines (size 1). Any additional ships are not allowed, as well as missing ships.
// Each ship must be a straight line, except for submarines, which are just single cell.

// The ship cannot overlap or be in contact with any other ship, neither by edge nor by corner.

namespace Solution {
  using System;
  public class BattleshipField {
    public static bool ValidateBattlefield(int[,] field) {
      
        int[,] refield = new int[12, 12];
        
        int cruisers = 0;
        int destroyers = 0;
        int submarines = 0;

        for (var i = 0; i < field.GetLength(0); i++)
        {
            for (var j = 0; j < field.GetLength(1); j++)
            {
                refield[i + 1, j + 1] = field[i, j];
            }
        }

        for (var i = 1; i < refield.GetLength(0) - 1; i++)
        {
            for (var j = 1; j < refield.GetLength(1) - 1; j++)
            {
                if (refield[i, j] == 1)
                {
                    int fieldSum = 0;
                    int crossSum = 0;
                    for (var x = i - 1; x <= i + 1; x++)
                    {
                        for (var z = j - 1; z <= j + 1; z++)
                        {
                            fieldSum += refield[x, z];
                            if (x - i == z - j || x - i == z - j - 2 || x - i == z - j + 2)
                                crossSum += refield[x, z];
                        }
                    }

                    if (crossSum > 1) return false;
                    
                    switch (fieldSum)
                    {
                        case 1:
                            submarines++;
                            if (submarines > 4) return false;
                            break;
                        case 2:
                            destroyers++;
                            break;
                        case 3:
                            if ((refield[i, j - 1] + refield[i, j + 1]) % 2 != 0) return false;
                            cruisers++;
                            break;
                        default:
                            return false;
                    };
                }
            }
        }

      if (cruisers != 4 || destroyers != 12) return false;

      return true;
    }
  }
}