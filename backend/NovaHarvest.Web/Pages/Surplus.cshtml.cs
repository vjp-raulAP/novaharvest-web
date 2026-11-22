using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NovaHarvest.Web.Models;

namespace NovaHarvest.Web.Pages;

[ResponseCache(NoStore = true)]

public class SurplusModel : PageModel
{
private const decimal SurplusDiscount = 0.30m;
private const int BoxKg = 5;

private const int ShelfLifeDays = 7;

private const int LowStockKg = 50;



    public Surplus Excedente { get; private set; } = new Surplus
    {
        Product = "Cereza Picota",
        Producer = "Huerta Los Castaños",
        Village = "Cabezuela del Valle",
        HarvestDate = DateTime.Today.AddDays(-2),
        AvailableKg = 343,
        ReservedKg = 120,
        PricePerKg = 3.20m,
        Note = "<b>Recoger antes de las 14:00</b>"  
    };
    public int KilosDisponibles { get; set; }
    public DateTime FechaLimite { get; set; }

    public int DiasParaConsumir { get; set; }

    public decimal PrecioExcedente { get; set; }

    public int CajasDisponibles { get; set; }

    public int KilosSueltos { get; set; }

    public decimal ValorExcedente { get; set; }

    public string EstadoExcedente { get; set; } = "";

    //Calculo de los kilos disponibles . Seria Availablekg-ReservedKg
    public void OnGet()
        {
            KilosDisponibles = Excedente.AvailableKg - Excedente.ReservedKg;
            FechaLimite = Excedente.HarvestDate.AddDays(ShelfLifeDays);
            DiasParaConsumir = (FechaLimite - DateTime.Today).Days;

            PrecioExcedente = Excedente.PricePerKg - (Excedente.PricePerKg * SurplusDiscount);

            CajasDisponibles = KilosDisponibles / BoxKg;

            KilosSueltos = KilosDisponibles % BoxKg;
            
            ValorExcedente = KilosDisponibles * PrecioExcedente;

            if(KilosDisponibles <= 0)
                {
                   EstadoExcedente = "Agotado"; 
                }
            else if (KilosDisponibles <= LowStockKg)
                {
                    EstadoExcedente = "¡Quedan pocos kilos!";
                }
            else
                {
                    EstadoExcedente = "Disponible";
                }
        }
    

}

