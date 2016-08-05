using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core1.ViewModels;

namespace Core1.Services
{
    public interface IViewModelService
    {
        DashboardViewModel GetDashboardViewModel();
    }
}
