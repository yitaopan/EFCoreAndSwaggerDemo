using System.ComponentModel.DataAnnotations;

namespace EFCoreAndSwaggerDemo.Models.Entities
{
    /* Auto generate and update create time, update time
     * Delete time not implemented
     * 
     * Reference: 
     * https://dotnetcoretutorials.com/2022/03/16/auto-updating-created-updated-and-deleted-timestamps-in-entity-framework/
     * https://www.entityframeworktutorial.net/faq/set-created-and-modified-date-in-efcore.aspx
     * 
     * https://www.bbsmax.com/A/RnJWbY0wzq/
     * https://stackoverflow.com/questions/38183021/how-to-automatically-populate-createddate-and-modifieddate
     */
    public abstract class BaseEntity
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LastUpdatedAt { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DeletedAt { get; set; }
    }
}
