﻿namespace SGM.Domain;

/// <summary>
/// Interface to define set of entity classes
/// </summary>
public interface IEntity<TKey> : IEntityBase
{
    TKey Id { get; set; }
}
