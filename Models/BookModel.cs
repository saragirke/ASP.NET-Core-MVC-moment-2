using System.ComponentModel.DataAnnotations; //För att kunna använda required
namespace BooksMvc.Models {
    
     //Struktur för data
    public class BookModel {
       
            [Required(ErrorMessage = "Namn måste vara ifyllt!")]
            [Display(Name = "Namn:")]
           
            public string? Name {get; set;}

            [Required(ErrorMessage = "Författare måste vara ifyllt!")]
            [Display(Name = "Författare:")]
            public string? Author {get; set;}

         
            [Required(ErrorMessage = "Genre måste vara ifyllt!")]
            [Display(Name = "Genre:")]
            public string? Genre {get; set;}

            [Display(Name = "Jag har läst klart boken:")]
            public string? Read {get; set;}

            [Required(ErrorMessage = "Betyg måste vara ifyllt!")]
            
            [Display(Name = "Betygsätt boken 1-5:")]
            [Range(Int32.MinValue, 5)]
         public int Grade { get; set; }

           
    }
}