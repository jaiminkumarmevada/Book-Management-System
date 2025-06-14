//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookManager.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Book
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(1, 10000, ErrorMessage = "Price must be between 1 and 10,000")]
        public decimal Price { get; set; }

        public Nullable<System.DateTime> PublishedDate { get; set; }
    }
}
