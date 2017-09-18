using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Graphs_DEMcKnight
{
    class Graph<T> : INotifyPropertyChanged
    {
        private List<Edge<T>> _edges = new List<Edge<T>>();
        private List<Vertex<T>> _vertices = new List<Vertex<T>>();

        /// <summary>
        /// A read-only collection of the edges in this graph
        /// </summary>
        public ReadOnlyCollection<Edge<T>> Edges
        {
            get { return _edges.AsReadOnly(); }
        }

        /// <summary>
        /// A read-only collection of the vertices in this graph
        /// </summary>
        public ReadOnlyCollection<Vertex<T>> Vertices
        {
            get { return _vertices.AsReadOnly(); }
        }

        /// <summary>
        /// Adds an edge to this graph.
        /// </summary>
        /// <param name="edge">The edge to be added.</param>
        public void AddEdge(Edge<T> edge)
        {
            _edges.Add(edge);
            NotifyPropertyChanged(nameof(Edges));
        }

        /// <summary>
        /// Adds a vertex to this graph
        /// </summary>
        /// <param name="vertex">The vertex to be added.</param>
        public void AddVertex(Vertex<T> vertex)
        {
            _vertices.Add(vertex);
            NotifyPropertyChanged(nameof(Vertices));
        }

        /// <summary>
        /// Removes an edge from this graph. 
        /// </summary>
        /// <param name="edge">The edge to be removed.</param>
        public void RemoveEdge(Edge<T> edge)
        {
            _edges.Remove(edge);        
            NotifyPropertyChanged(nameof(Edges));
        }

        /// <summary>
        /// Removes a vertex from this graph.
        /// </summary>
        /// <param name="vertex">The vertex to be removed.</param>
        public void RemoveVertex(Vertex<T> vertex)
        {
            _vertices.Remove(vertex);
            NotifyPropertyChanged(nameof(Vertices));
        }

        #region INotifyPropertyChanged requirements
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion INotifyPropertyChanged requirements
    }
}
