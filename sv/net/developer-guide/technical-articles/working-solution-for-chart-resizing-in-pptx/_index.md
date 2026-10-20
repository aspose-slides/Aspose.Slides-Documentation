---
title: Fungerande lösning för diagramstorleksändring i PPTX
type: docs
weight: 60
url: /sv/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagramstorleksändring
- Excel-diagram
- OLE-objekt
- bädda in diagram
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Fixa oväntad diagramstorleksändring i PPTX när inbäddade Excel OLE-objekt används med Aspose.Slides för .NET. Ställ in fasta diagrammått för att hålla diagrammets och OLE-ramens storlekar konsekventa."
---
## **Bakgrund**

Excel-diagram som bäddas in som OLE-objekt i PowerPoint-presentationer med Aspose-komponenter kan ändra storlek efter sin första aktivering. Detta kan leda till en märkbar skillnad i diagrammets utseende före och efter aktivering. Den här artikeln förklarar varför storleksändringen sker och visar hur du förhindrar den genom att matcha diagrammets fasta mått med OLE-ramen.

I [Skapa Excel-diagram och bädda in dem som OLE-objekt i presentationer](/slides/sv/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) förklarade vi hur man skapar ett Excel-diagram med Aspose.Cells for .NET och bäddar in det i en PowerPoint-presentation med Aspose.Slides for .NET. För att åtgärda [problem med objektförhandsgranskning](/slides/sv/net/object-preview-issue-when-adding-oleobjectframe/) tilldelade vi diagrambilden till diagrammets OLE-objektram. I den resulterande presentationen, när du dubbelklickar på OLE-objektramen som visar diagrambilden, aktiveras Excel-diagrammet. Användare kan redigera den inbäddade Excel-arbetsboken och sedan återgå till bilden genom att klicka utanför den aktiverade arbetsboken. Storleken på OLE-objektramen ändras när användaren återvänder till bilden, och omräkningsfaktorn varierar beroende på de ursprungliga storlekarna för både OLE-objektramen och den inbäddade Excel-arbetsboken.

## **Orsak till storleksändring**

Den inbäddade Excel-arbetsboken har egna fönstermått som Excel försöker bevara när objektet först aktiveras. OLE-ramen på bilden har oberoende definierade mått. När Excel-arbetsboken aktiveras förhandlar Excel och PowerPoint om objektets storlek för att behålla proportionerna som en del av inbäddningsprocessen. Skillnader mellan arbetsbokens fönster och OLE-ramen kan därför orsaka att objektet ändrar storlek.

## **Fungerande lösning**

Matcha diagrammets storlek med OLE-ramen på bilden och håll diagrammets mått oberoende av arbetsbokens fönster. Denna lösning fungerar med en ny presentation eller en befintlig mall.

Exemplet kräver Aspose.Cells for .NET och Aspose.Slides for .NET. Det skapar ett enkelt stapeldiagram på ett aktivt diagramblad och bäddar in arbetsboken i XLS-format. Ingen diagramförhandsgranskningsbild tilldelas; diagrammet blir synligt när OLE-objektet aktiveras i PowerPoint.

Exemplet skapar en ny presentation med en 9,5 × 4 tum stor OLE-ram placerad 0,5 tum från vänsterkanten och 1 tum från toppen. Bildens koordinater och mått anges i punkt (72 punkt per tum). För en befintlig presentation, se [Använd en mall](#use-a-template).

## **Ställ in en fast diagramstorlek**

Ställ in [SizeWithWindow](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/sizewithwindow/) till false så att diagrammets mått är oberoende av arbetsbokens fönster. Ställ in [ChartObject](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/chartobject/)-måtten via [Width](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/width/) och [Height](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/height/), konvertera punkt till pixlar med 96 pixlar per tum: en ram på 684 × 288 punkt motsvarar ett diagram på 912 × 384 pixlar. Ställ in [PrintSize](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/printsize/) till värdet Custom för [PrintSizeType](https://reference.aspose.com/cells/net/aspose.cells/printsizetype/). Exemplet bäddar in arbetsboken med [AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addoleobjectframe/) och sparar en presentation med en 9,5 × 4 tum OLE-ram.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "Data";
dataSheet.Cells["A1"].PutValue(10);
dataSheet.Cells["A2"].PutValue(20);

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, 20, 10);
var chart = chartSheet.Charts[chartIndex];
chart.NSeries.Add("Data!A1:A2", true);
workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Bildens koordinater och mått är i punkter (72 punkter per tum).
var width = 684f; // 9,5 tum.
var height = 288f; // 4 tum.

chart.SizeWithWindow = false;
// Konvertera punkter till diagrampixlar med 96 pixlar per tum.
chart.ChartObject.Width = (int)(width / 72f * 96f);
chart.ChartObject.Height = (int)(height / 72f * 96f);
chart.PrintSize = Aspose.Cells.PrintSizeType.Custom;

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Excel97To2003);
var dataInfo = new OleEmbeddedDataInfo(workbookStream.ToArray(), "xls");
slide.Shapes.AddOleObjectFrame(36, 72, width, height, dataInfo);

presentation.Save("chart-fixed-size.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Använd en mall**

Storlekslogiken är densamma för en befintlig presentation. För att anpassa exemplet:

1. Läs in mallpresentationen istället för att skapa en tom presentation.  
2. Kontrollera att den första bilden innehåller minst tre former och använd formen med index 2 som platshållare.  
3. Hämta ramens bredd och höjd från den formen istället för att använda de fasta värdena 684 och 288. Behåll beräkningarna oförändrade.  
4. Lägg till OLE-ramen på platshållarens position istället för de fasta koordinaterna 36 och 72.  
5. Ta bort platshållaren innan presentationen sparas.

## **Vanliga frågor**

**Varför ändras mitt inbäddade Excel-diagram i storlek efter att det aktiverats i PowerPoint?**

Detta beror på att Excel försöker återställa det ursprungliga fönsterstorleken vid första aktiveringen, medan OLE-objektramen i PowerPoint har egna mått. PowerPoint och Excel förhandlar om storleken för att behålla bildförhållandet, vilket kan leda till storleksändring.

**Hur kan jag hålla diagrammets och OLE-ramens storlekar konsistenta?**

Ange fasta diagrammått som matchar OLE-ramen och använd en anpassad diagramutskriftsstorlek innan du bäddar in arbetsboken. Exemplet ovan visar de nödvändiga inställningarna och enhetsomräkningarna.

**Är det tillräckligt att matcha arbetsbokens fönsterstorlek?**

Att bara matcha arbetsbokens fönsterstorlek förhindrar inte på ett tillförlitligt sätt att OLE-ramen ändrar storlek efter aktivering. Använd fasta diagrammått som visas i exemplet.

**Fungerar den här lösningen både för mallbaserade presentationer och nya presentationer?**

Ja. För en mall, använd platshållarens mått och position. För en ny presentation, ange ramens mått och position direkt.

**Kan jag använda det här exemplet med diagram som skapats i andra kalkylprogram?**

Exemplet använder en Excel-arbetsbok skapad med Aspose.Cells. Det demonstrerar inte aktiveringsbeteende för andra kalkylprogram.

## **Relaterade avsnitt**

- [Skapa Excel-diagram och bädda in dem som OLE-objekt i presentationer](/slides/sv/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Uppdatera OLE-objekt automatiskt med ett PowerPoint‑tillägg](/slides/sv/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)