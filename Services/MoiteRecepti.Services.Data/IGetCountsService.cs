namespace MoiteRecepti.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using MoiteRecepti.Services.Data.Models;
    using MoiteRecepti.Web.ViewModels.Administration.Dashboard;

    public interface IGetCountsService
    {
        CountsDto GetCount();
    }
}
