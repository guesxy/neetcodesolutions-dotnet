using dfs_search;
using static System.Console;

WriteLine("Graph Traversal");

var graph = new Graph();
graph.AddEdge(0, 1);
graph.AddEdge(0, 2);
graph.AddEdge(1, 3);
graph.AddEdge(2, 3);
graph.AddEdge(3, 4);

graph.FindShortestPathBFS(0, 4).ForEach(WriteLine); // 0, 1, 3, 4

graph.FindShortestPathDFS(0, 4).ForEach(WriteLine); // 0, 1, 3, 4
