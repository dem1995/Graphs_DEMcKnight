using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Graphs_DEMcKnight
{
    /// <summary>
    /// A Vertex class, in the Graph sense. Contains an object and a collection of <see cref="Edge{T}"/>s.
    /// </summary>
    /// <typeparam name="T">The type of object that this edge will hold</typeparam>
    public class Vertex<T> : INotifyPropertyChanged
    {
        private T _data;
        private List<Edge<T>> _edges;

        /// <summary>
        /// The default constructor for <see cref="Vertex{T}"/>. Instantiates an empty <see cref="List{Edge{T}}"/> for <see cref="_edges"/>.
        /// </summary>
        public Vertex()
        {
            _edges = new List<Edge<T>>();
        }

        /// <summary>
        /// The <see cref="T"/> attached to this <see cref="Vertex{T}"/>.
        /// </summary>
        public T Data
        {
            get { return _data; }
            set
            {
                NotifyPropertyChanged();
                _data = value;
            }
        }

        /// <summary>
        /// A read-only wrapping of the <see cref="Edge{T}"/>s attached to this <see cref="Vertex{T}"/>.
        /// </summary>
        public ReadOnlyCollection<Edge<T>> Edges
        {
            get { return _edges.AsReadOnly(); }
        }

        /// <summary>
        /// Adds an <see cref="Edge{T}"/> to this <see cref="Vertex{T}"/>.
        /// </summary>
        /// <param name="edge">The edge to be attached to this vertex.</param>
        internal void AddEdge(Edge<T> edge)
        {
            _edges.Add(edge);
            NotifyPropertyChanged(nameof(Edges));
        }

        /// <summary>
        /// Removes a <see cref="Edge{T}"/> from this <see cref="Vertex{T}"/>.
        /// </summary>
        /// <param name="edge">The edge to be removed from this vertex.</param>
        internal void RemoveEdge(Edge<T> edge)
        {
            _edges.Remove(edge);
            NotifyPropertyChanged(nameof(Edges));
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
