using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace WorkWithGraphsClassLibrary
{
    public class AdditionalAnalysis
    {
        private static int time = 0;
        public static (List<Tuple<string, string, double>>, double) MST(Dictionary<string, List<Tuple<string, double>>> adjacencyList)
        {

            if (СrawlingАlgorithm.IsDirected(adjacencyList))
            {
                throw new ArgumentException("Граф ориентированный. Построение остовного дерева невозможно.");
            }
            // Преобразуем список смежности в список рёбер
            var edges = new List<Tuple<string, string, double>>();
            foreach (var node in adjacencyList)
            {
                foreach (var neighbor in node.Value)
                {

                    if (node.Key.CompareTo(neighbor.Item1) < 0)
                    {
                        edges.Add(Tuple.Create(node.Key, neighbor.Item1, neighbor.Item2));
                    }
                }
            }

            // Сортируем рёбра по весу
            edges = edges.OrderBy(e => e.Item3).ToList();

            var parent = new Dictionary<string, string>();
            var rank = new Dictionary<string, int>();

            foreach (var node in adjacencyList.Keys)
            {
                parent[node] = node;
                rank[node] = 0;
            }

            // Функция нахождения корня
            string Find(string x)
            {
                if (parent[x] != x)
                    parent[x] = Find(parent[x]);
                return parent[x];
            }

            // Функция объединения
            void Union(string x, string y)
            {
                var rootX = Find(x);
                var rootY = Find(y);
                if (rootX != rootY)
                {
                    if (rank[rootX] < rank[rootY])
                        parent[rootX] = rootY;
                    else if (rank[rootX] > rank[rootY])
                        parent[rootY] = rootX;
                    else
                    {
                        parent[rootY] = rootX;
                        rank[rootX]++;
                    }
                }
            }

            // Строим остовное дерево
            var mst = new List<Tuple<string, string, double>>();
            double totalWeight = 0;

            foreach (var edge in edges)
            {
                var rootU = Find(edge.Item1);
                var rootV = Find(edge.Item2);

                if (rootU != rootV)
                {
                    Union(edge.Item1, edge.Item2);
                    mst.Add(edge);
                    totalWeight += edge.Item3;
                    
                }
            }

            // Проверяем связность графа
            var root = Find(adjacencyList.Keys.First());
            if (adjacencyList.Keys.Any(node => Find(node) != root))
            {
                throw new ArgumentException("Граф несвязный. Построение остовного дерева невозможно."); ;
            }
            return (mst, totalWeight);
        }

        public static List<string> FindArticulationPoints(Dictionary<string, List<Tuple<string, double>>> adjacencyList)
        {
            var articulationPoints = new List<string>();
            var visited = new HashSet<string>();
            var disc = new Dictionary<string, int>(); 
            var low = new Dictionary<string, int>();  
            var parent = new Dictionary<string, string>();

            // Инициализация
            foreach (var vertex in adjacencyList.Keys)
            {
                visited.Add(vertex);
                disc[vertex] = -1;
                low[vertex] = -1;
                parent[vertex] = null;
            }

            // Запуск DFS для каждой непосещённой вершины
            foreach (var vertex in adjacencyList.Keys)
            {
                if (disc[vertex] == -1)
                    DFS(vertex, visited, disc, low, parent, articulationPoints, adjacencyList);
            }
            return articulationPoints;
        }

        private static void DFS(string u, HashSet<string> visited, Dictionary<string, int> disc,
            Dictionary<string, int> low, Dictionary<string, string> parent,
            List<string> articulationPoints, Dictionary<string, List<Tuple<string, double>>> adjacencyList)
        {
            int children = 0;
            disc[u] = low[u] = ++time;

            foreach (var v in adjacencyList[u])
            {
                if (disc[v.Item1] == -1) // непосещённая вершина
                {
                    children++;
                    parent[v.Item1] = u;
                    DFS(v.Item1, visited, disc, low, parent, articulationPoints, adjacencyList);

                    // Обновляем low[u]
                    low[u] = Math.Min(low[u], low[v.Item1]);

                    // Условие 1: корень с двумя и более детьми
                    if (parent[u] == null && children > 1)
                        AddIfNotExists(articulationPoints, u);

                    // Условие 2: не корень и low[v] >= disc[u]
                    if (parent[u] != null && low[v.Item1] >= disc[u])
                        AddIfNotExists(articulationPoints, u);
                }
                else if (v.Item1 != parent[u]) // обратное ребро
                {
                    low[u] = Math.Min(low[u], disc[v.Item1]);
                }
            }
        }

        private static void AddIfNotExists(List<string> list, string item)
        {
            if (!list.Contains(item))
                list.Add(item);
        }
    }
}

