#region

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace At2.Models;

[Table("Applicants", Schema = "hr")]
public class Applicant
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int ApplicantId { get; init; }


    [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
    [Required]
    public string Name { get; init; } = string.Empty;

    [Required] [DataType(DataType.Date)] public DateTime DOB { get; init; }

    [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
    [Required]
    public string Qualification { get; init; } = string.Empty;

    [Range(3.0, 4.0, ErrorMessage = "GPA must be 3.0 or higher (up to 4.0).")]
    public decimal GPA { get; init; }

    [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
    [Required]
    public string University { get; init; } = string.Empty;
}