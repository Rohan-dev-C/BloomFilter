using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloomFilter
{
    public class BloomFilter<T>
    {
        int m; 
        HashSet<Func<T, int>> set;

        bool[] bits;

        public BloomFilter(int cap)
        {
            set= new HashSet<Func<T, int>>();
            LoadHashFunc(HashFuncOne);
            LoadHashFunc(HashFuncTwo);
            LoadHashFunc(HashFuncThree);

            bits = new bool[cap];
            m = cap; 
        }

        public void LoadHashFunc(Func<T, int> hashFunc)
        {
           set?.Add(hashFunc);
        }

        public void Insert(T item, int k)
        {
            foreach (var temp in set)
            {
                var temp2 = temp?.Invoke(item);
                bits[Math.Abs(temp2.Value % bits.Length)] = true; 
            } 
           
        }

        public bool ProbablyContains(T item)
        {
            foreach (var temp in set)
            {
                var temp2 = temp?.Invoke(item);
                if(bits[Math.Abs(temp2.Value % bits.Length)] == false)
                {
                    return false; 
                }
            }
            return true; 
        }

        private int HashFuncOne(T item)
        {
            return item.GetHashCode(); 
        }

        private int HashFuncTwo(T item)
        {
            return item.GetHashCode() + item.ToString().GetHashCode(); 
        }

        private int HashFuncThree(T item)
        {
            return (HashFuncOne(item) + HashFuncTwo(item)) * "dog".GetHashCode(); 
        }
    }
}
