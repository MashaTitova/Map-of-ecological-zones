using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WorkWithGraphsClassLibrary
{
    public class DijkstraAlgorithm
    {
        public static (Dictionary<string, double> distances, Dictionary<string, string> paths) Dijkstra(
       string startVertex,
       Dictionary<string, List<Tuple<string, double>>> adjacencyList)
        {
            var distances = new Dictionary<string, double>();
            var visited = new HashSet<string>();
            var paths = new Dictionary<string, string>();

            // Инициализация расстояний
            foreach (var vertex in adjacencyList.Keys)
            {
                distances[vertex] = double.PositiveInfinity;
            }
            distances[startVertex] = 0;

            while (true)
            {
                // Находим вершину с минимальным расстоянием среди непосещённых
                string minVertex = null;
                double minDistance = double.PositiveInfinity;

                foreach (var vertex in adjacencyList.Keys)
                {
                    if (!visited.Contains(vertex) && distances[vertex] < minDistance)
                    {
                        minDistance = distances[vertex];
                        minVertex = vertex;
                    }
                }

                if (minVertex == null || minDistance == double.PositiveInfinity)
                    break;

                visited.Add(minVertex);

                // Обновляем расстояния до соседних вершин
                if (adjacencyList.ContainsKey(minVertex))
                {
                    foreach (var edge in adjacencyList[minVertex])
                    {
                        string neighbor = edge.Item1;
                        double weight = edge.Item2;

                        if (!visited.Contains(neighbor))
                        {
                            double newDistance = distances[minVertex] + weight;
                            if (newDistance < distances[neighbor])
                            {
                                distances[neighbor] = newDistance;
                                paths[neighbor] = minVertex;
                            }
                        }
                    }
                }
            }
            return (distances, paths);
        }

                // Вспомогательный метод для построения пути от начальной вершины до заданной
        public static string BuildPath(string start, string end, Dictionary<string, string> previous)
        {
            var path = new List<string>();
            string current = end;

            while (current != null)
            {
                path.Add(current);
                current = previous.ContainsKey(current) ? previous[current] : null;
            }

            path.Reverse();
            return string.Join(" -> ", path);
        }
        public static string PrintShortestPath(string start, string end,
            Dictionary<string, double> distances,
            Dictionary<string, string> paths)
        {
            // Проверяем, существует ли начальная вершина в графе
            if (!distances.ContainsKey(start))
            {
                throw new Exception($"Ошибка: вершина {start} не найдена в графе!");
            }
            // Проверяем, существует ли конечная вершина в графе
            if (!distances.ContainsKey(end))
            {
                throw new Exception($"Ошибка: вершина {end} не найдена в графе!");
            }

            // Проверяем достижимость
            if (double.IsPositiveInfinity(distances[end]))
            {
                throw new Exception($"Вершина '{end}' недостижима из вершины '{start}'");
            }

            // Восстанавливаем путь
            var path = BuildPath(start, end, paths);

            return path;
        }

    }
}
