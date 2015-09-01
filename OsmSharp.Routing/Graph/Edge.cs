﻿// OsmSharp - OpenStreetMap (OSM) SDK
// Copyright (C) 2015 Abelshausen Ben
// 
// This file is part of OsmSharp.
// 
// OsmSharp is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// OsmSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with OsmSharp. If not, see <http://www.gnu.org/licenses/>.

namespace OsmSharp.Routing.Graph
{
    /// <summary>
    /// Abstract representation of an edge.
    /// </summary>
    /// <typeparam name="TEdgeData"></typeparam>
    public class Edge<TEdgeData>
        where TEdgeData : struct, IEdgeData
    {
        /// <summary>
        /// Creates a new edge.
        /// </summary>
        internal Edge(uint id, uint from, uint to, TEdgeData edgeData, bool edgeDataInverted)
        {
            this.Id = id;
            this.To = to;
            this.From = from;
            this.EdgeData = edgeData;
            this.EdgeDataInverted = edgeDataInverted;
        }

        /// <summary>
        /// Creates a new edge keeping the current state of the given enumerator.
        /// </summary>
        internal Edge(Graph<TEdgeData>.EdgeEnumerator enumerator)
        {
            this.Id = enumerator.Id;
            this.To = enumerator.To;
            this.From = enumerator.From;
            this.EdgeDataInverted = enumerator.EdgeDataInverted;
            this.EdgeData = enumerator.EdgeData;
        }

        /// <summary>
        /// Gets the edge id.
        /// </summary>
        public uint Id
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the vertex at the beginning of this edge.
        /// </summary>
        public uint From
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the vertex at the end of this edge.
        /// </summary>
        public uint To
        {
            get;
            private set;
        }

        /// <summary>
        /// Returns true if the edge data is inverted relative to the direction of this edge.
        /// </summary>
        public bool EdgeDataInverted
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the edge data.
        /// </summary>
        public TEdgeData EdgeData
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the directed edge data.
        /// </summary>
        /// <returns></returns>
        public TEdgeData GetDirectedEdgeData()
        {
            if(this.EdgeDataInverted)
            {
                return (TEdgeData)this.EdgeData.Reverse();
            }
            return this.EdgeData;
        }

        /// <summary>
        /// Returns a string representing this edge.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} - {1}",
                this.To,
                this.EdgeData.ToInvariantString());
        }
    }
}