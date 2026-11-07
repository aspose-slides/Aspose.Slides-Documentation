---
title: Länka diagram till externa arbetsböcker
description: Länka diagramdata till en extern arbetsbok och uppdatera den.
type: docs
url: /sv/features/external-chart-workbook/
weight: 1070
feature_id: external-chart-workbook
feature_group: charts
translationKey: slides-feature-external-chart-workbook
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---
## **Översikt**

Peka ett diagram på en extern arbetsbok istället för att ha all dess källdata inbäddad i presentationen. Du kan ange arbetsbokens sökväg och välja om diagrammet ska uppdateras från den filen. Det sparade diagrammet kan också innehålla cachade visningsdata.

## **Användningsexempel**

Det här C#-exemplet använder Aspose.Slides för .NET. Skapa en giltig försäljningsarbetsbok med North = 55 och South = 40 och skriv den som sales.xlsx bredvid utdata. Återställ diagrammets North‑värde till 20, länka sedan diagrammet till arbetsbokens absoluta sökväg och uppdatera: North blir 55 igen. Det explicita intervallet omfattar rubriken och två datarader. Håll sales.xlsx tillgänglig när du öppnar om eller uppdaterar det länkade diagrammet; presentationen bäddar inte in den här externa filen. Ingen indatafil behövs. Den sparar *external-chart-workbook.pptx* och *external-chart-workbook.png*. Installera biblioteket med hjälp av [installationsguiden](/slides/sv/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.IO;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 620, 350);
chart.HasTitle = false;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);
var firstCategory = workbook.GetCell(0, 1, 0, "North");
var secondCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);
var nameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(nameCell, chart.Type);
var firstValue = workbook.GetCell(0, 1, 1, 20);
var secondValue = workbook.GetCell(0, 2, 1, 40);
series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);
firstValue.Value = 55;
var workbookPath = Path.GetFullPath("sales.xlsx");
using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var workbookFile = File.Create(workbookPath))
{
    workbookStream.CopyTo(workbookFile);
}
firstValue.Value = 20;
chart.ChartData.SetExternalWorkbook(workbookPath, true);
chart.ChartData.SetRange("Sheet1!$A$1:$B$3");
presentation.Save("external-chart-workbook.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("external-chart-workbook.png", ImageFormat.Png);
```

## **Vanliga frågor**

### **Kan jag läsa varje cachat värde när den länkade filen saknas?**

Aspose.Slides för .NET 26.11 kan [läsa lagrade diagramvärden direkt](/slides/sv/net/chart-workbook/#read-cached-chart-values-without-a-workbook) utan att öppna den länkade arbetsboken. Detta inkluderar vanliga värden, X/Y‑värden, bubbelformer och kategorivärden när dessa cachar finns. Cachad data kan vara frånvarande eller föråldrad; den är inte en komplett arbetsbok. Uppdatering från källan kräver fortfarande en tillgänglig, stödd arbetsbok. För andra SDK‑versioner och versioner, kontrollera deras motsvarande diagramguide.

### **Vad händer om den externa arbetsboken flyttas?**

Uppdatera diagrammets externa arbetsboksökväg till den nya platsen och gör filen tillgänglig där presentationen bearbetas. Lita inte på cachad data för fullständiga dataåtkomstoperationer när den saknas.

### **Kan jag välja om jag ska uppdatera cachad diagramdata när jag länkar?**

Ja. Välj om diagramdata ska uppdateras när länken sätts. Uppdatering kräver en tillgänglig, stödd arbetsbok; att hoppa över uppdatering registrerar länken utan att läsa nya värden från den filen.

## **Guider**

- [Hantera diagramarbetsböcker i presentationer i .NET](/slides/sv/net/chart-workbook/)

Relaterad funktion: [Fyll redigerbara diagram med data](/slides/sv/features/chart-data-binding/).