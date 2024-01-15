using System;
using System.ComponentModel.DataAnnotations;

namespace SDTEC.GestorEducacional.Models.Base
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
