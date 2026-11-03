using HW_05_Web_Engineering.Models;

namespace HW_05_Web_Engineering.ViewModels
{
    public class HomeViewModel
    {
        public List<BookCardViewModel>? Books { get; set; }
        public List<Author>? Authors { get; set; }
    }
}
