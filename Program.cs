using System;

namespace BinarySearch
{
    static class Program
    {
        static void Main(string[] args)
        {
            int[] array = LoadData();

            Console.WriteLine(BinarySearchIterative(array, 123));
            Console.WriteLine(BinarySearchRecursive(array, 123, 0, array.Length - 1));
        }

        private static int BinarySearchIterative(int[] inputArray, int item)
        {
            if (inputArray == null)
                throw new ArgumentNullException();
            
            int low = 0;
            int high = inputArray.Length - 1;
            int mid = low + (high - low) / 2;

            while (low <= high)
            {
                if (item == inputArray[mid])
                    return mid;
                else if (item > inputArray[mid])
                    low = mid + 1;
                else
                    high = mid - 1;
                mid = low + (high - low) / 2;
            }
            return -1;
        }

        private static int BinarySearchRecursive(int[] inputArray, int item, int low, int high)
        {
            if (inputArray == null)
                throw new ArgumentNullException();
            
            if (low < inputArray.GetLowerBound(0) || high > inputArray.GetUpperBound(0))
                throw new ArgumentOutOfRangeException();
            
            int mid = low + (high - low) / 2;

            if (low <= high)
            {
                if (inputArray[mid] == item)
                    return mid;
                else if (inputArray[mid] < item)
                    return BinarySearchRecursive(inputArray, item, mid + 1, high);
                else if (inputArray[mid] > item)
                    return BinarySearchRecursive(inputArray, item, low, mid - 1);
            }
            return -1;
        }
        
        private static int[] LoadData()
        {
            return new int[] { 1, 5, 7, 14, 21, 32, 47, 69, 83, 91, 107, 123, 256, 300, 455 };
        }
    }
}

