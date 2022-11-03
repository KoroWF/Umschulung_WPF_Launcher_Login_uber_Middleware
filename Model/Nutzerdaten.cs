using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("NUTZER")]
    public class Nutzer
    {
        /// <summary>
        /// Datenbank ID
        /// </summary>
        [Key]
        [Column("NUTZER_ID")]
        public int nutzerId { get; set; }
        /// <summary>
        /// UID
        /// </summary>
        [Column("UID")]
        [StringLength(20)]
        [Required]
        public string uid { get; set; }
        /// <summary>
        /// Passwort
        /// </summary>
        [Column("PWD")]
        [Required]
        public string pwd { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [Column("NAME")]
        [StringLength(70)]
        public string? name { get; set; }
        /// <summary>
        /// Vorname
        /// </summary>
        [Column("VORNAME")]
        [StringLength(70)]
        public string? vorname { get; set; }
        /// <summary>
        /// Admin
        /// </summary>
        [Column("ADMIN")]
        public bool admin { get; set; }

        [NotMapped]
        public string? fullName { get => vorname + " " + name; }
        public List<Rolle> rollen { get; set; } = new List<Rolle>();

        public List<Token> tokens { get; set; } = new List<Token>();
    }
}
