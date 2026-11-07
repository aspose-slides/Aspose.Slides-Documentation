---
title: Koppel grafieken aan externe werkboeken
description: Koppel grafiekgegevens aan een extern werkboek en ververs ze.
type: docs
url: /nl/features/external-chart-workbook/
weight: 1070
feature_id: external-chart-workbook
feature_group: grafieken
translationKey: slides-feature-external-chart-workbook
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---
## **Overzicht**

Richt een grafiek op een extern werkboek in plaats van al zijn brongegevens in de presentatie in te sluiten. U kunt het pad van het werkboek instellen en kiezen of de grafiek moet worden bijgewerkt vanuit dat bestand. De opgeslagen grafiek kan ook gecachete weergavegegevens bevatten.

## **Voorbeeld van gebruik**

Dit C#‑voorbeeld gebruikt Aspose.Slides for .NET. Maak een geldig verkoop‑werkboek met Noord = 55 en Zuid = 40 en schrijf het als sales.xlsx naast de uitvoer. Zet de Noord‑waarde van de grafiek terug naar 20, koppel vervolgens de grafiek aan het absolute pad van het werkboek en ververs: Noord wordt weer 55. Het expliciete bereik omvat de koptekst en twee gegevensrijen. Houd sales.xlsx beschikbaar bij het opnieuw openen of bijwerken van de gekoppelde grafiek; de presentatie bevat dit externe bestand niet. Er is geen invoerbestand nodig. Het slaat *external-chart-workbook.pptx* en *external-chart-workbook.png* op. Installeer de bibliotheek volgens de [installatie‑handleiding](/slides/nl/net/installation/).

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

## **FAQ**

### **Kan ik elke gecachete waarde lezen wanneer het gekoppelde bestand ontbreekt?**

Aspose.Slides for .NET 26.11 kan [opgeslagen grafiekwaarden direct lezen](/slides/nl/net/chart-workbook/#read-cached-chart-values-without-a-workbook) zonder het gekoppelde werkboek te openen. Dit omvat gewone waarden, X/Y‑waarden, bolgroottes en categoriewaarden wanneer die caches bestaan. Gecachete gegevens kunnen ontbreken of verouderd zijn; het is geen compleet werkboek. Verversen vanuit de bron vereist nog steeds een beschikbaar ondersteund werkboek. Raadpleeg voor andere SDK‑s en versies de bijbehorende grafiekgids.

### **Wat gebeurt er als het externe werkboek wordt verplaatst?**

Werk het pad van het externe werkboek van de grafiek bij naar de nieuwe locatie en zorg dat dat bestand beschikbaar is waar de presentatie wordt verwerkt. Vertrouw niet op gecachete gegevens voor volledige data‑toegang wanneer deze ontbreken.

### **Kan ik kiezen of ik gecachete grafiekgegevens ververst bij het koppelen?**

Ja. Kies of u grafiekgegevens wilt bijwerken bij het instellen van de koppeling. Verversen vereist een beschikbaar ondersteund werkboek; het overslaan van verversen legt de koppeling vast zonder nieuwe waarden uit dat bestand te lezen.

## **Handleidingen**

- [Werkboekbeheer voor grafieken in presentaties in .NET](/slides/nl/net/chart-workbook/)

Gerelateerde functie: [Vul bewerkbare grafieken met gegevens](/slides/nl/features/chart-data-binding/).