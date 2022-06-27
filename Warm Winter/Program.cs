using System;
using System.Collections.Generic;
using System.Linq;

namespace Warm_Winter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] hats = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] scarfs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> firstQueue = new Stack<int>(hats);
            Queue<int> secondStack = new Queue<int>(scarfs);
            Queue<int> sets = new Queue<int>();
            while (firstQueue.Count > 0 && secondStack.Count > 0)
            {
                if (secondStack.Peek() > firstQueue.Peek())
                {
                    firstQueue.Pop();
                    continue;

                }
                if (firstQueue.Peek() > secondStack.Peek())
                {
                    int set = firstQueue.Peek() + secondStack.Peek();
                    sets.Enqueue(set);
                    secondStack.Dequeue();
                    firstQueue.Pop();

                }
               
                else if (firstQueue.Peek() == secondStack.Peek())
                {
                    secondStack.Peek();
                    int indexFirst = firstQueue.Peek() + 1;
                    firstQueue.Pop();
                    secondStack.Dequeue();
                    firstQueue.Push(indexFirst);

                }
            }
            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
