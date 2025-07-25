using EngineKnowledgeBase.PresentationLogic.Models;
using System.Diagnostics;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace EngineKnowledgeBase.PresentationLogic.Repositories
{
    public class ReportDocumet
    {
        public ReportDocumet(object componentTemp)
        {
            if (componentTemp is ProductViewModel product)
            {
                var temp = product as ProductViewModel;               
                GenerateDocument(temp);
            }
            else if (componentTemp is ComponentViewModel component)
            {
                var temp = component as ComponentViewModel;
            }
        }

        public void GenerateDocument(ProductViewModel component)
        {
            using (DocX document = DocX.Create("ReportDocument.docx"))
            {         
                document.InsertParagraph($"Компонент: {component.Name}").FontSize(14);
                var table = document.InsertTable(component.Components.Count + 1, 2);

                table.AutoFit = AutoFit.Contents; 
                table.Rows[0].Cells[0].Paragraphs[0].Append("Наименование компонента").FontSize(12);
 
                foreach (var comp in component.Components)
                {
                    int count = comp.Count ?? 0;
                    table.Rows[component.Components.IndexOf(comp) + 1].Cells[0].Paragraphs[0].Append(comp.Name).FontSize(12);
                    table.Rows[component.Components.IndexOf(comp) + 1].Cells[1].Paragraphs[0].Append($"{count} шт").FontSize(12);
                }

                document.InsertTable(table);
                document.Save();
            }     
            Process.Start(new ProcessStartInfo("ReportDocument.docx") { UseShellExecute = true });
        }
    }
}
