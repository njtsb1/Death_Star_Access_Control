using System.Collections.Generic;

namespace ControlAccess.ViewModels
{
    public class ResultApi<ViewModel>
    {
        public string Next { get; set; }
        public IReadOnlyList<ViewModel> Results { get; set; }
    }
}
