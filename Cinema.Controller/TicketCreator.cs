using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using PdfSharp.Pdf;
using PdfSharp;
namespace Cinema.Controller
{
    public class TicketCreator
    {
       public TicketCreator(List<string> miejsca, string film, string sala,string godzina,string cena,string id) {

            string html= "<h1 style=\"color: #5e9ca0; text-align: center;\">&nbsp; Potwierdzenie zapłaty</h1><h1 style=\"color: #5e9ca0;\">&nbsp;</h1><h1 style=\"color: #5e9ca0;\">Miejsce : "+miejsca[0];
         if(miejsca.Count()>1)  for(int i=1;i<miejsca.Count();i++) html += "," + miejsca[i];
            html += "</h1><h1 style=\"color: #5e9ca0;\">Film : " + film + "</h1><h1 style=\"color: #5e9ca0;\">Sala : " + sala + "</h1><h1 style=\"color: #5e9ca0;\">Godzina Rozpoczęcia : " + godzina + "</h1><h1 style=\"color: #5e9ca0;\">cena : " + (miejsca.Count() * 20).ToString()+" monet" + "</h1><h1 style=\"color: #5e9ca0; text-align: right;\">Unikatowy id Rejestracji : " + id + "</h1><p><strong>&nbsp;</strong></p>";
            PdfDocument pdf = PdfGenerator.GeneratePdf(html, PageSize.A4);
            pdf.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+ "\\Ticket.pdf");
            

        }
    }
}
