using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPA_Coco.Models
{
    [Table("Logs")]
    public class Logs
    {
        public Logs()
        {

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int LogId { get; set; }
        public int ProcessId { get; set; }
        public int LogsTypeId { get; set; }
        public string Message { get; set; }
        public string InnerException { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Enabled { get; set; }
    }
}
