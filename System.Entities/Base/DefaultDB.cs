using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Entities
{
  public class DefaultDB
  {

    public DefaultDB()
    {
      UniqueId = Guid.NewGuid();
      IsDeleted = false;
      IsUpdated = false;
    }

    [Key]
    public int Id { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid UniqueId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DateDeleted{ get; set; }
    public bool IsUpdated { get; set; }
    public DateTime DateUpdated { get; set; }
  }
}
