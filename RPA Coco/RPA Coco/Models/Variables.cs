using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPA_Coco.Models
{
    [Table("Variables")]
    public class Variables
    {
        public Variables()
        {

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int VariableId { get; set; }
        public string VariableName { get; set; }
        public string PrettyVariableName { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public bool UserVariable { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Enabled { get; set; }
    }
}
