using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceTest.Models.Entities
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime RegisterDate { get; set; }
        public int RegisterUser { get; set; }
        public DateTime LastChangeDate { get; set; }
        public int LastChangeUser { get; set; }
        public bool Visable { get; set; }
        public int Author { get; set; }

    }

}