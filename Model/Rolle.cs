using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("ROLLEN")]
    public class Rolle
    {
        [Key]
        [Column("ROLLE_ID")]
        public int rolleId { get; set; }
        [StringLength(255)]
        [Column("ROLLE_NAME")]
        public string rolleName { get; set; }
        public List<Nutzer> nutzer { get; set; } = new List<Nutzer>();
    }
}
