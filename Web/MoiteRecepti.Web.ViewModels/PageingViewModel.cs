namespace MoiteRecepti.Web.ViewModels
{
    using System;

    public class PageingViewModel
    {
        public int PageNumber { get; set; }

        public bool HasPrevousPage => this.PageNumber > 1;

        public bool HasNextPag => this.PageNumber < this.PageCount;

        public int PreviusPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;

        public int PageCount => (int)Math.Ceiling((double)this.RecipesCount / this.ItemsPerPage);

        public int RecipesCount { get; set; }

        public int ItemsPerPage { get; set; }
    }
}