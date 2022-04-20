using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT4_LTDT_Cau1
{
    class thuatToanDijkstra
    {
        public static void Dijkstra(maTranKe AM, int dinhBatDau, int dinhCuoi)
        {
            bool[] T = new bool[AM.n];
            int[] L = new int[AM.n];
            int[] Prev = new int[AM.n];
            const int voCuc = int.MaxValue;
            for (int i = 0; i < AM.n; i++)
            {
                L[i] = voCuc;
                Prev[i] = -1;
                T[i] = true;
            }
            L[dinhBatDau] = 0;
            while(T[dinhCuoi] == true)
            {
                int min = voCuc;
                int dinhI = -1;
                for (int i = 0; i < AM.n; i++)
                {
                    if(T[i] != false && min >= L[i])
                    {
                        min = L[i];
                        dinhI = i;
                    }
                }
                if(min == voCuc)
                {
                    break;
                }
                T[dinhI] = false;
                for(int k = 0; k < AM.n; k++)
                {
                    if(AM.maTran[dinhI,k] != 0 && L[k] > (min + AM.maTran[dinhI, k]))
                    {
                        L[k] = min + AM.maTran[dinhI, k];
                        Prev[k] = dinhI;
                    }
                }
            }
            if (T[dinhCuoi])
            {
                Console.WriteLine($"Không tồn tại đường đi");
            }
            else
            {
                int index = dinhCuoi;
                Console.Write($"Đường đi ngắn nhất: ");
                Console.Write(dinhCuoi);
                while (index != dinhBatDau)
                {
                    Console.Write($" <- {Prev[index]}");
                    index = Prev[index];
                }
                Console.WriteLine();
                Console.WriteLine($"Chi phí đường đi ngắn nhất: {L[dinhCuoi]}");
            }
        }
    }
}
