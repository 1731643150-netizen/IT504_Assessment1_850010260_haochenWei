using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HarakekeStudio.Pages;

public class ContactModel : PageModel
{
    [BindProperty]
    public ContactInput Input { get; set; } = new();

    public string? SuccessMessage { get; set; }

    public void OnGet(string? service)
    {
        if (service != null)
        {
            Input.Service = service;
        }
    }

    public void OnPost()
    {
        if (!ModelState.IsValid)
        {
            return;
        }

        SuccessMessage = "Your message has been received.";

        ModelState.Clear();
        Input = new ContactInput();
    }

    public class ContactInput
    {
        [Required(ErrorMessage = "Please enter your name.")]
        [Display(Name = "Name")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Please enter your email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email.")]
        [Display(Name = "Email")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Please choose a service.")]
        [Display(Name = "Service")]
        public string Service { get; set; } = "";

        [Required(ErrorMessage = "Please enter your message.")]
        [Display(Name = "Message")]
        public string Message { get; set; } = "";
    }
}