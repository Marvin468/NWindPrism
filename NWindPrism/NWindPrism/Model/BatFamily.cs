using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NWindPrism.Model
{
    public class BatFamily
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Nombre { get; set; }
    }
}
