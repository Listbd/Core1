using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Core1.Services
{
    public class ViewModelService : IViewModelService
    {
        private readonly ISensorDataService _sensorDataService;
        private readonly IUrlHelper _urlHelper;
        public ViewModelService(ISensorDataService sensorDataService, IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionContextAccessor)
        {
            _sensorDataService = sensorDataService;
            _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
        }
        public DashboardViewModel GetDashboardViewModel()
        {
            return new DashboardViewModel
            {
                WaterTemperatureTile = new SensorTileViewModel
                {
                    Title = "Water temperature",
                    Value = _sensorDataService.GetWaterTemperatureFahrenheit().Value,
                    ColorCssClass = "panel-primary",
                    IconCssClass = "fa-sliders",
                    Url = _urlHelper.Action("GetWaterTemperatureChart", "History")
                },
                FishMotionTile = new SensorTileViewModel
                {
                    Title = "Fish motion",
                    Value = _sensorDataService.GetFishMotionPercentage().Value,
                    ColorCssClass = "panel-green",
                    IconCssClass = "fa-car",
                    Url = _urlHelper.Action("GetFishMotionPercentageChart", "History")
                },
                WaterOpacityTile = new SensorTileViewModel
                {
                    Title = "Water opacity",
                    Value = _sensorDataService.GetWaterOpacityPercentage().Value,
                    ColorCssClass = "panel-yellow",
                    IconCssClass = "fa-adjust",
                    Url = _urlHelper.Action("GetWaterOpacityPercentageChart", "History")
                },
                LightIntensityTile = new SensorTileViewModel
                {
                    Title = "Light intensity",
                    Value = _sensorDataService.GetLightIntensityLumens().Value,
                    ColorCssClass = "panel-red",
                    IconCssClass = "fa-lightbulb-o",
                    Url = _urlHelper.Action("GetLightIntensityLumensChart", "History")
                }
            };

        }
    }
}
