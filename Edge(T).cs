using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Graphs_DEMcKnight
{
    /// <summary>
    /// An Edge class, in the graph sense. Contains two <see cref="Vertex"/>es.
    /// </summary>
    /// <typeparam name="T">The type of object that can be attached to the <see cref="Vertex{T}"/>s associated with this edge</typeparam>
    public class Edge<T>
    {
        private Vertex<T> _v1;
        private Vertex<T> _v2;

        /// <summary>
        /// The default constructor for this Edge. Does nothing.
        /// </summary>
        public Edge() { }

        /// <summary>
        /// The first vertex this edge is attached to.
        /// </summary>
        public Vertex<T> V1
        {
            get { return _v1; }
            set
            {
                _v1 = value;
                NotifyPropertyChanged();
                value.AddEdge(this);
                
            }
        }

        /// <summary>
        /// The second vertex this edge is attached to.
        /// </summary>
        public Vertex<T> V2
        {
            get { return _v2; }
            set
            {
                _v2 = value;
                NotifyPropertyChanged();
                value.AddEdge(this);
            }
        }

        /// <summary>
        /// Adds the given vertex as an endpoint to this edge. 
        /// </summary>
        /// <param name="vertex">The vertex to be assigned to one of this Edge's endpoints, if one is null.</param>
        /// <returns>True if <see cref="v1"/> or <see cref="v2"/> were empty and the given vertex could be assigned to one of them; false, otherwise.</returns>
        public bool AddVertex(Vertex<T> vertex)
        {
            if (V1 == null)
                V1 = vertex;
            else if (V2 == null)
                V2 = vertex;
            else
                return false;
            return true;
        }

        /// <summary>
        /// Changes one of the vertices this edge is attached to.
        /// </summary>
        /// <param name="vertexFrom">The vertex to change attachment from.</param>
        /// <param name="vertexTo">The vertex to change attachment to.</param>
        /// <returns>True if the change of attached vertex succeeded, false if it failed.</returns>
        public bool ChangeVertex(Vertex<T> vertexFrom, Vertex<T> vertexTo)
        {
            if (V1 == vertexFrom)
                V1 = vertexTo;
            else if (V2 == vertexFrom)
                V2 = vertexTo;
            else
                return false;
            return true;
        }

        /// <summary>
        /// Removes the first <see cref="Vertex{T}"/> from this <see cref="Edge{T}"/>. Returns false if that <see cref="Vertex{T}"/> was already null.
        /// </summary>
        /// <returns>True if <see cref="V1"/> was non-null; false, otherwise.</returns>
        public bool RemoveVertex1()
        {
            if (V1 == null)
                return false;
            else
            {
                V1 = null;
                return true;
            }
        }

        /// <summary>
        /// Removes the second <see cref="Vertex{T}"/> from this <see cref="Edge{T}"/>. Returns false if that <see cref="Vertex{T}"/> was already null.
        /// </summary>
        /// <returns>True if <see cref="V2"/> was non-null; false, otherwise.</returns>
        public bool RemoveVertex2()
        {
            if (V2 == null)
                return false;
            else
            {
                V2 = null;
                return true;
            }
        }

        /// <summary>
        /// Removes all instances of the given <see cref="Vertex{T}" from this <see cref="Edge{T}"/> (technically replaces them with null./>
        /// </summary>
        /// <param name="vertex">The vertex to be removed from this edge.</param>
        /// <returns>True if any instances of the given <see cref="Vertex{T}"/> were found and removed from this <see cref="Edge{T}"/>; false, otherwise.</returns>
        public bool RemoveAllInstancesOf(Vertex<T> vertex)
        {
            if (V1 == vertex || V2 == vertex)
            {
                if (V1==vertex)
                    V1 = null;
                if (V2 == vertex)
                    V2 = null;
            }
            else
                return false;
            return true;
        }

        /// <summary>
        /// Returns true if either of this edge's endpoints is the given vertex (either <see cref="v1"/> or <see cref="v2"/> is this vertex); false, otherwise.
        /// </summary>
        /// <param name="vertex">The vertex being added to this edge, if an edge is available.</param>
        /// <returns></returns>
        public bool HasEndpoint(Vertex<T> vertex)
        {
            if (V1.Equals(vertex) || V2.Equals(vertex))
                return true;
            return false;
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
