// If we were to set up a Tic-Tac-Toe game, we would want to know whether the board's current state is solved, wouldn't we? Our goal is to create a function that will check that for us!

// Assume that the board comes in the form of a 3x3 array, where the value is 0 if a spot is empty, 1 if it is an "X", or 2 if it is an "O", like so:

// [[0, 0, 1],
//  [0, 1, 2],
//  [2, 1, 0]]
// We want our function to return:

// -1 if the board is not yet finished AND no one has won yet (there are empty spots),
// 1 if "X" won,
// 2 if "O" won,
// 0 if it's a cat's game (i.e. a draw).
// You may assume that the board passed in is valid in the context of a game of Tic-Tac-Toe.

using System;

public class TicTacToe
{
  public int IsSolved(int[,] board)
  {
      int result = 0;
      int ld = 1;
      int rd = 1;

      for (var i = 0; i < 3; i++)
      {
          int hor = 1;
          int ver = 1;

          for (var j = 0; j < 3; j++)
          {
              if (board[i, j] == 0)
              {
                  result = -1;
              }

              if (i == j)
              {
                  ld *= board[i, j];
              }
              if (j == 2 - i)
              {
                  rd *= board[i, j];
              }

              hor *= board[i, j];
              ver *= board[j, i];
          }

          if (hor == 1 || ver == 1)
              return 1;
          if (hor == 8 || ver == 8)
              return 2;
      }

      if (ld == 1 || rd == 1)
          return 1;
      if (ld == 8 || rd == 8)
          return 2;

      return result;
  }
}