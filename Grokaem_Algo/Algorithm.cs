using System.Collections;
using System.Numerics;

namespace Grokaem_Algo;

public class Algorithm
{
    #region Chapter 1 BinarySearch

    public static int? BinarySearch<T>(IList<T> collection, T target) where T : INumber<T>
    {
        int low = 0;
        int high = collection.Count - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            T guess = collection[mid];
            if (guess == target)
            {
                return mid;
            }
            else if (guess > target)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return null;
    }

    public static int FindSmallest<T>(IList<T> collection) where T : INumber<T>
    {
        T smallest = collection[0];
        int smallestIndex = 0;
        for (int i = 0; i < collection.Count; i++)
        {
            if (collection[i] < smallest)
            {
                smallest = collection[i];
                smallestIndex = i;
            }
        }

        return smallestIndex;
    }

    #endregion

    #region Chapter 2 SelectionSort

    public static List<T> SelectionSort<T>(IList<T> collection) where T : INumber<T>
    {
        List<T> newList = [];

        for (int i = 0; i < collection.Count; i++)
        {
            int indexSmallest = FindSmallest<T>(collection);
            T item = collection[indexSmallest];
            collection.RemoveAt(indexSmallest);
            newList.Add(item);
        }

        return newList;
    }

    #endregion

    #region Chapter 4 Recursive

    public static T SumRecursive<T>(IList<T> collection) where T : INumber<T>
    {
        if (collection.Count == 0)
        {
            return T.Zero;
        }

        if (collection.Count == 1)
        {
            return collection[0];
        }

        return collection[0] + SumRecursive<T>(collection.Skip(1).ToList());
    }

    public static T MaxRecursive<T>(IList<T> collection) where T : INumber<T>
    {
        if (collection.Count == 2)
        {
            return collection[0] > collection[1] ? collection[0] : collection[1];
        }

        T subMax = MaxRecursive<T>(collection.Skip(1).ToList());
        return collection[0] > subMax ? collection[0] : subMax;

    }

    #endregion

    #region Chapter 4 QuickSort

    public static List<T> QuickSort<T>(IList<T> collection) where T : INumber<T>
    {
        if (collection.Count < 2)
        {
            return collection.ToList();
        }

        T pivot = collection[Random.Shared.Next(0, collection.Count)];

        List<T> less = new List<T>();
        List<T> greater = new List<T>();
        List<T> center = new List<T>();

        foreach (var element in collection)
        {
            if (element == pivot)
            {
                center.Add(element);
            }
            else if (element > pivot)
            {
                greater.Add(element);
            }
            else
            {
                less.Add(element);
            }
        }

        return QuickSort<T>(less).Concat(center).Concat(QuickSort(greater)).ToList();
    }

    #endregion

    #region Chapter 9 Deykstra

    public static int Deykstra(Dictionary<string, Dictionary<string, int>> graph, Dictionary<string, int> costs,
        Dictionary<string, string> parents)
    {
        List<string> processed = new List<string>();
        string node = FindLowestNode(costs, processed);

        while (node != null)
        {
            int cost = costs[node];
            var neighbors = graph[node];

            foreach (var n in neighbors)
            {
                int new_cost = cost + neighbors[n.Key];
                if (costs[n.Key] > new_cost)
                {
                    costs[n.Key] = new_cost;
                    parents[n.Key] = node;
                }
            }

            processed.Add(node);
            node = FindLowestNode(costs, processed);
        }

        return costs["конец"];
    }

    public static string FindLowestNode(Dictionary<string, int> costs, List<string> proccessed)
    {
        int lowestCost = int.MaxValue;
        string lowestNode = null;

        foreach (var node in costs)
        {
            if (node.Value < lowestCost && !proccessed.Contains(node.Key))
            {
                lowestNode = node.Key;
                lowestCost = node.Value;
            }
        }

        return lowestNode;
    }

    #endregion

    #region Greedy

    public static HashSet<string> GreedyAlgo(HashSet<string> statesNeeded, Dictionary<string, HashSet<string>> stations)
    {
        HashSet<string> finalStations = new HashSet<string>();
        
        while (statesNeeded.Count > 0)
        {
            string bestStation = string.Empty;
            HashSet<string> statesCovered = new HashSet<string>();
            foreach (var node in stations)
            {
                string station = node.Key;
                HashSet<string> states = node.Value;
                HashSet<string> covered = statesNeeded.Intersect(states).ToHashSet();
                if (covered.Count > statesCovered.Count)
                {
                    bestStation = station;
                    statesCovered = covered;
                }
            }

            statesNeeded.ExceptWith(statesCovered);
            finalStations.Add(bestStation);
        }
        return finalStations;
    }

#endregion
}