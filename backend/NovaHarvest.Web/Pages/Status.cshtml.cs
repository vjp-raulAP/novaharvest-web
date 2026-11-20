using Microsoft.AspNetCore.Mvc.RazorPages;
using NovaHarvest.Web.Models;
namespace NovaHarvest.Web.Pages;



public class StatusModel : PageModel
{
    public DateTime ServerTime {get; set; }
    public String ServerName {get; set; }

    public int Visits {get; set; }

    public void OnGet()
    {
        ServerTime = DateTime.Now;
        ServerName = Environment.MachineName;
        
        SiteStats.Visits++;
        Visits = SiteStats.Visits;
    }
}