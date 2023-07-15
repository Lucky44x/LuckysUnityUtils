using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Lucky44.Util.Grids
{
    [System.Serializable]
    public class Grid<T>
    {
        public int width, height;
        public T[,] gridArray;
        //public List<T> allData = new List<T>();

        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;

            this.gridArray = new T[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    gridArray[x, y] = default;
                }
            }
        }

        public T getData(int x, int y)
        {
            if (x >= width || y >= height || x < 0 || y < 0)
                return default;

            return gridArray[x, y];
        }

        public void insertData(T data, int x, int y)
        {
            //if(gridArray[x,y] != null)
            //{
            //    allData.Remove(gridArray[x, y]);
            //}

            //allData.Add(data);

            gridArray[x, y] = data;

            //for(int i = 0; i < height; i++)
            //{
            //    string s = "";
            //    for (int j = 0; j < width; j++)
            //    {
            //        if (gridArray[j, i] == null)
            //        {
            //            s += "N";
            //            continue;
            //        }
            //        s += gridArray[j, i].ToString();
            //    }
            //    UnityEngine.Debug.Log(s);
            //}
            //UnityEngine.Debug.Log("-------------------------------------------------------------");
        }

        public void removeData(int x, int y)
        {
            //if (gridArray[x, y] != null)
            //{
            //    allData.Remove(gridArray[x, y]);
            //}

            gridArray[x, y] = default(T);
        }

        public void insertDataAtNext(T data)
        {
            int x = nextFreeX();
            int y = nextFreeY();

            if (x == -1 || y == -1)
            {
                return;
            }

            insertData(data, x, y);
        }

        public int nextFreeX()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (!EqualityComparer<T>.Default.Equals(gridArray[x, y], default(T)))
                        continue;

                    return x;
                }
            }
            return -1;
        }

        public int nextFreeY()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (!EqualityComparer<T>.Default.Equals(gridArray[x, y], default(T)))
                        continue;

                    return y;
                }
            }

            return -1;
        }
    }
}
