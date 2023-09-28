using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DateValidator.Models;

public class Form
{
    [Required]
    [DisplayName("Select a Date")]
    [DataType(DataType.Date)]
    [FutureDate]
    public DateTime FormDate { get; set; }

}

public class FutureDateAttribute : ValidationAttribute
{    
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {   
        DateTime todaysDate = DateTime.Today;
        // You first may want to unbox "value" here and cast to to a DateTime variable!
        
        if (((DateTime)value) >= todaysDate)
        {
            return new ValidationResult("Date selection must be in the past");
        }

        return ValidationResult.Success;
    }
}
