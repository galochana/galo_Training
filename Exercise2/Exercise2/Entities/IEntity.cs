﻿namespace Exercise2.Entities
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }

    
}