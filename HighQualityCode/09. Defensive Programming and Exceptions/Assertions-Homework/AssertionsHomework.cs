﻿using System;
using System.Linq;
using System.Diagnostics;

public class AssertionsHomework
{
    private const string NullArrayMessage = "Array is null";
    private const string EmptyArrayMessage = "Array is empty";
    private const string NullSwapValueMessage = "Swap value is null";
    private const string InvalidStartIndexMessage = "Invalid start index";
    private const string InvalidEndIndexMessage = "Invalid end index";
    private const string InvalidStartAndEndMessage = "Start index is bigger than end index";
    private const string InvalidMinIndexMessage = "Invaild index of min elemnet";
    private const string NullSearchValueMessage = "Search value is null";

    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(value != null, NullSearchValueMessage);
        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    public static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, NullArrayMessage);
        Debug.Assert(arr.Length > 0, EmptyArrayMessage);
        Debug.Assert(startIndex >= 0 && startIndex < arr.Length, InvalidStartIndexMessage);
        Debug.Assert(endIndex >= 0 && endIndex < arr.Length, InvalidEndIndexMessage);
        Debug.Assert(startIndex <= endIndex, InvalidStartAndEndMessage);

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else 
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, NullArrayMessage);
        Debug.Assert(arr.Length > 0, EmptyArrayMessage);
        Debug.Assert(startIndex >= 0 && startIndex < arr.Length, InvalidStartIndexMessage);
        Debug.Assert(endIndex >= 0 && endIndex < arr.Length, InvalidEndIndexMessage);
        Debug.Assert(startIndex <= endIndex, InvalidStartAndEndMessage);

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        Debug.Assert(minElementIndex >= 0 && minElementIndex < arr.Length, InvalidMinIndexMessage);
        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        Debug.Assert(x != null && y != null, NullSwapValueMessage);
        T oldX = x;
        x = y;
        y = oldX;
    }
}
