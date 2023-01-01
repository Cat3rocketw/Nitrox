﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using BinaryPack.Attributes;

namespace NitroxModel.DataStructures.GameLogic
{
    /// <summary>
    ///     TechType is the enum used in Subnautica for defining all the spawnable objects in the world. This includes food, enemies and bases.
    /// </summary>
    /// <remarks>
    ///     Shim tech type model to bridge the gap between original subnautica and BZ.
    /// </remarks>
    [DataContract]
    [Serializable]
    public class NitroxTechType
    {
        [DataMember(Order = 1)]
        public string Name { get; }

        [IgnoreConstructor]
        protected NitroxTechType()
        {
            // Constructor for serialization. Has to be "protected" for json serialization.
        }

        public NitroxTechType(string name)
        {
            Name = name;
        }

        public static NitroxTechType None { get; } = new NitroxTechType("None");

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            NitroxTechType type = obj as NitroxTechType;

            return !ReferenceEquals(type, null) &&
                   Name == type.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}
