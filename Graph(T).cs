using System.Collections.ObjectModel;

namespace Graphs_DEMcKnight
{
    class Graph<T> 
    {
        public ObservableCollection<Edge<T>> Edges { get; set; }
        public ObservableCollection<Vertex<T>> Nodes { get; set; }
    }
}
