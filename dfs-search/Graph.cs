namespace dfs_search;

using System.Collections.Generic;

public class Graph
{
    private Dictionary<int, List<int>> adjacencyList;

    public Graph()
    {
        adjacencyList = new Dictionary<int, List<int>>();
    }

    public void AddEdge(int source, int destination)
    {
        if (!adjacencyList.ContainsKey(source))
        {
            adjacencyList[source] = new List<int>();
        }
        adjacencyList[source].Add(destination);

        if (!adjacencyList.ContainsKey(destination))
        {
            adjacencyList[destination] = new List<int>();
        }
        adjacencyList[destination].Add(source);
    }

    // BFS - generally better for shortest path in unweighted graphs
    public List<int> FindShortestPathBFS(int start, int end)
    {
        if (start == end)
        {
            return [start];
        }

        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        var parentMap = new Dictionary<int, int>();

        queue.Enqueue(start);
        visited.Add(start);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (adjacencyList.ContainsKey(current))
            {
                foreach (var neighbor in adjacencyList[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        visited.Add(neighbor);
                        parentMap[neighbor] = current;

                        if (neighbor == end)
                        {
                            return ReconstructPath(parentMap, start, end);
                        }
                    }
                }
            }
        }

        return [];
    }

    // DFS - not ideal for shortest path but included for comparison
    public List<int> FindShortestPathDFS(int start, int end)
    {
        var visited = new HashSet<int>();
        var path = new List<int>();
        var shortestPath = new List<int>();

        DFSRecursive(start, end, visited, path, ref shortestPath);
        return shortestPath;
    }

    private void DFSRecursive(
        int current,
        int end,
        HashSet<int> visited,
        List<int> path,
        ref List<int> shortestPath
    )
    {
        visited.Add(current);
        path.Add(current);

        if (current == end)
        {
            // Found a path to destination
            if (shortestPath.Count == 0 || path.Count < shortestPath.Count)
            {
                shortestPath.Clear();
                shortestPath.AddRange(path);
            }
        }
        else if (adjacencyList.ContainsKey(current))
        {
            foreach (var neighbor in adjacencyList[current])
            {
                if (!visited.Contains(neighbor))
                {
                    DFSRecursive(neighbor, end, visited, path, ref shortestPath);
                }
            }
        }

        // Backtrack
        path.RemoveAt(path.Count - 1);
        visited.Remove(current);
    }

    private List<int> ReconstructPath(Dictionary<int, int> parentMap, int start, int end)
    {
        var path = new List<int>();
        var current = end;

        while (current != start)
        {
            path.Add(current);
            current = parentMap[current];
        }

        path.Add(start);
        path.Reverse(); // Reverse to get path from start to end
        return path;
    }
}
