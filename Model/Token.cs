using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("TOKENS")]
    public class Token
    {
        [Key]
        [Column("TOKEN")]
        public string token { get; set; }
        [Column("ERSTELLT")]
        public DateTime erstellt { get; set; }
        [Column("USED")]
        public DateTime used { get; set; }

        public Nutzer nutzer { get; set; }


    }
}
