using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nuctech.D2.DotNetTopic
{
    internal class SumMaxNumberTopic : ITopicItem
    {
        /*
         * 请编写一个函数,从给定的一组整数中,计算出现最多次数的整数之和。例如:
         * 输入:(2,4,5,6,4),输出:8,	  因为 4 出现次数最多，4 + 4 = 8
         * 输入:(1,2,1,3,1),输出:3,	  因为 1 出现次数最多，1 + 1 + 1 = 3
         */

        public void Run()
        {
            int[] numbers = CreateNumbers();
            //TODO, print the result.
            Console.WriteLine("TODO");
        }

        private int[] CreateNumbers()
        {
            return new int[] { 2, 4, 5, 6, 4 };
        }
    }
}