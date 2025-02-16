namespace MoiteRecepti.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using MoiteRecepti.Data;
    using MoiteRecepti.Data.Common.Repositories;
    using MoiteRecepti.Data.Models;
    using MoiteRecepti.Data.Repositories;
    using MoiteRecepti.Services.Data;
    using MoiteRecepti.Web.ViewModels;
    using MoiteRecepti.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        public readonly IGetCountsService countsService;
        //private readonly IMapper mapper;

        public HomeController(IGetCountsService countsService/*, IMapper mapper*/)
        {
            this.countsService = countsService;
            //this.mapper = mapper;
        }

        public IActionResult Index()
        {
        var countsDto = this.countsService.GetCount();

            // var viewModel = this.mapper.Map<IndexViewModel>(countsDto);
        var viewModel = new IndexViewModel
       {
           CategoriesCount = countsDto.CategoriesCount,
           ImagesCount = countsDto.ImagesCount,
           IngredientsCount = countsDto.IngredientsCount,
           RecipesCount = countsDto.RecipesCount,
       };
        return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
