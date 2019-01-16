using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI.Enitty.Entities
{
    [Table("Town")]
    public class Town
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]

        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(12)]
        [ForeignKey("City")]
        public string ParentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(50)]
        public string ParentName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(12)]
        public string AreaCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(20)]
        public string ZipCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(6)]
        public string Depth { get; set; }

        public virtual City City { get; set; }
    }
}
