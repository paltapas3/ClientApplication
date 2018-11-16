using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApiConsumer.Models
{
    public class Transaction
    {
        public int Tid { get; set; }
        [Required(ErrorMessage = "Account Number is Required")]
        public int AccountNumber_Debited { get; set; }
        [Required(ErrorMessage = "Please Enter Payee Account Number")]
        public int AccountNumber_Credited { get; set; }
        [Required(ErrorMessage ="Amount is required")]
        public int Amount { get; set; }
        public string TransactionNumber { get; set; }
        public string Date { get; set; }
    }
}