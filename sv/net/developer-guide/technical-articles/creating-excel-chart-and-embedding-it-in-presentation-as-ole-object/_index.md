---
title: Skapa Excel-diagram och bädda in dem i presentationer som OLE-objekt
type: docs
weight: 50
url: /sv/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-diagram
- bädda in diagram
- OLE-objekt
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Skapa ett Excel-diagram med Aspose.Cells for .NET och bädda in arbetsboken i en PowerPoint-presentation med Aspose.Slides, inklusive en diagramförhandsgranskning."
---
## **Översikt**

Den här artikeln visar hur du skapar ett Excel stapeldiagram med Aspose.Cells for .NET och bäddar in dess arbetsbok i en PowerPoint-presentation med Aspose.Slides for .NET. Den inbäddade arbetsboken innehåller både källdata och diagrammet. En separat PNG-förhandsgranskning visar diagrammet på bilden innan OLE-objektet aktiveras.

Resultatet är ett inbäddat Excel-objekt, inte ett inbyggt PowerPoint-diagram. Att redigera arbetsboken via OLE kräver ett skrivbordsprogram som stödjer OLE-aktivering och en kompatibel Excel-installation.

## **Förutsättningar**

Lägg till referenser till Aspose.Cells for .NET och Aspose.Slides for .NET i ditt C#-projekt. Exemplet använder top‑level‑statements och kräver C# 9 eller senare. Microsoft Office krävs inte för att skapa presentationen med dessa bibliotek.

Inga indatafiler krävs: exemplet skapar data och diagram i minnet och skriver sedan `OutputChart.pptx` till den aktuella arbetskatalogen. Tilldela licenser för båda produkterna när du kör utanför utvärderingsläge.

## **Hur inbäddningen fungerar**

1. Skapa en arbetsbok med ett dataarbetsblad och ett diagramblad.  
2. Gör diagrambladet aktivt så att arbetsboken öppnas på diagrammet.  
3. Ställ in arbetsbokens OLE‑visningsområde och rendera diagrammet till PNG.  
4. Spara arbetsboken som XLSX i minnet och bädda in dessa byte i en bild.  
5. Tilldela PNG som OLE‑objektets förhandsgranskning och spara presentationen som PPTX.

Arbetsbokens visningsområde och bildramen har olika roller. [SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) tar nollbaserade start-/slutrad‑ och kolumnindex. [ChartCollection.Add](https://reference.aspose.com/cells/net/aspose.cells.charts/chartcollection/add/) tar i stället den översta raden, vänstra kolumnen, nedersta raden och högra kolumnen. Exemplet använder radindex 55 och kolumnindex 25 som de nedre högra gränserna; dessa värden är layoutval, inte antalet datarader eller kolumner.

Bildramen använder punkter. Exemplet passar in den i bilden och centrerar den samtidigt som bildförhållandet för PNG bevaras, snarare än att sträcka förhandsgranskningen för att fylla bilden.

## **Skapa och bädda in diagrammet**

Det följande kompletta exemplet fyller `DataSheet` med fyra rader och fem kolumner med värden. Varje rad blir en diagramserie. `ChartSheet` väljs som aktivt blad innan arbetsboken sparas.

Arbetsboken sparas uttryckligen som XLSX, vilket matchar `xlsx`‑tillägget som skickas till [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/). PNG-filen laddas direkt från dess ström utan en mellanliggande bitmapkonvertering. Att tilldela den via [SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/substitutepictureformat/) ersätter standard‑OLE‑platshållaren.

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "DataSheet";

int[,] values =
{
    { 67, 44, 46, 43, 24 },
    { 86, 64, 97, 29, 40 },
    { 68, 89, 78, 69, 38 },
    { 91, 48, 60, 26, 25 }
};

for (var row = 0; row < values.GetLength(0); row++)
{
    for (var column = 0; column < values.GetLength(1); column++)
    {
        dataSheet.Cells[row, column].PutValue(values[row, column]);
    }
}

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
chartSheet.Name = "ChartSheet";

var lastChartRow = 55;
var lastChartColumn = 25;
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, lastChartRow, lastChartColumn);
var chart = chartSheet.Charts[chartIndex];
for (var row = 1; row <= values.GetLength(0); row++)
{
    chart.NSeries.Add($"DataSheet!A{row}:E{row}", false);
}

workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
workbook.Worksheets.SetOleSize(0, lastChartRow, 0, lastChartColumn);

// Rendera diagramförhandsgranskningen och serialisera den redigerbara arbetsboken separat.
using var chartImageStream = new MemoryStream();
chart.ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
using var chartImage = Images.FromStream(chartImageStream);

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Xlsx);
var workbookBytes = workbookStream.ToArray();

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var slideSize = presentation.SlideSize.Size;

// Anpassa förhandsgranskningen i bilden utan att ändra bildförhållandet.
var scale = Math.Min(slideSize.Width / chartImage.Width, slideSize.Height / chartImage.Height);
var frameWidth = chartImage.Width * scale;
var frameHeight = chartImage.Height * scale;
var frameX = (slideSize.Width - frameWidth) / 2;
var frameY = (slideSize.Height - frameHeight) / 2;

var embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
var previewImage = presentation.Images.AddImage(chartImage);
oleFrame.SubstitutePictureFormat.Picture.Image = previewImage;

presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Förväntat resultat**

`OutputChart.pptx` innehåller en bild med en inbäddad Excel‑arbetsbok och en diagramförhandsgranskning. Arbetsboken innehåller de ursprungliga data och ett stapeldiagram med fyra serier. Förhandsgranskningen är centrerad på bilden och behåller sina proportioner.

![Excel stapeldiagram visat som förhandsgranskning av en inbäddad arbetsbok](excel-chart-ole-preview.png)

I en kompatibel skrivbordsmiljö för PowerPoint med Excel tillgängligt kan du dubbelklicka på objektet för att aktivera och redigera den inbäddade arbetsboken. Aktivering och redigering beror på värdapplikationens OLE‑stöd och säkerhetsinställningar.

## **Vanliga frågor**

**Varför behövs en förhandsgranskningsbild?**

Den inbäddade arbetsboken och dess bildförhandsgranskning är separat innehåll. Tillhandahåll en diagrambild så att bilden visar diagrammet istället för standard‑"EMBEDDED OLE OBJECT"‑platshållaren. Se [Object Preview Issue when Adding OleObjectFrame](/slides/sv/net/object-preview-issue-when-adding-oleobjectframe/).

**Uppdateras förhandsgranskningen automatiskt när jag ändrar arbetsboken i kod?**

Behandla förhandsgranskningen som ett ögonblicksbild. När du uppdaterar arbetsbokens data programmässigt, återgenerera diagrambilden och ersätt både förhandsgranskningen och den inbäddade arbetsboksdata.

**Kan jag använda XLS istället för XLSX?**

Ja. Spara arbetsboken i XLS‑format och använd `xls` som den inbäddade data‑tillägget. Tillägget måste matcha det faktiska arbetsboksformatet; att enbart ändra tillägget konverterar inte data.

**Varför kan objektet ändra storlek efter aktivering?**

Värdapplikationen kan uppdatera OLE‑objektets presentation när den aktiverar arbetsboken. Arbetsbokens OLE‑visningsområde och bildramens dimensioner spelar båda roll. Se [Working Solution for Chart Resizing in PPTX](/slides/sv/net/working-solution-for-chart-resizing-in-pptx/).

## **Relaterade avsnitt**

- [Lösning för diagramstorlek i PPTX](/slides/sv/net/working-solution-for-chart-resizing-in-pptx/)
- [Problem med förhandsgranskning av objekt när OleObjectFrame läggs till](/slides/sv/net/object-preview-issue-when-adding-oleobjectframe/)
- [Uppdatera OLE‑objekt automatiskt med ett PowerPoint‑tillägg](/slides/sv/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)