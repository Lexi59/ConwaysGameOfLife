using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    class Cell
    {
        //constructor
        public Cell(int _num)
        {
            num = _num;
            status = 0;
        }
        //fields
        private int[] history;
        public int status;
        public int aliveNeighbors;
        public int num;

        //methods
        public void checkNeighbors()
        {
            int neighborsAlive = 0;
            int[] neighborNum = { num - 1, num - 11, num - 10, num - 9, num + 1, num + 11, num + 10, num + 9 };
            for (int i = 0; i < neighborNum.Length; i++)
            {
                if (validNeighbor(num, neighborNum[i]))
                {
                    Cell neighbor = Form1.Cells.Find(x => x.num == neighborNum[i]);
                    if (neighbor == null)
                    {

                    }
                    else if(neighbor.status == 1)
                    {
                        neighborsAlive++;
                    }
                }
            }
            aliveNeighbors = neighborsAlive;
        }
        private bool validNeighbor(int current, int checking)
        {
            //left column
            if (current % 10 == 1 && checking % 10 == 0)
            {
                return false;
            }
            //top or bottom row
            if (checking < 1 || checking > 100)
            {
                return false;
            }
            //right column
            if (current % 10 == 1 && checking % 10 == 0)
            {
                return false;
            }
            return true;
        }
        public void changeStatus()
        {
            if(status == 0 && aliveNeighbors == 3)
            {
                status = 1;
            }
            if (status == 1 && aliveNeighbors <= 1)
            {
                status = 0;
            }
            if(status == 1 && aliveNeighbors >= 4)
            {
                status = 0;
            }
            if (status == 1 && aliveNeighbors == 2)
            {
                status = 1;
            }
            if (status == 1 && aliveNeighbors == 3)
            {
                status = 1;
            }
        }
    }
}
