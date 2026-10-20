---
title: Excel-grafieken maken en insluiten in presentaties als OLE-objecten
type: docs
weight: 50
url: /nl/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-grafiek
- grafiek insluiten
- OLE-object
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Maak een Excel-grafiek met Aspose.Cells voor .NET en sluit het werkboek in een PowerPoint-presentatie met Aspose.Slides in, inclusief een grafiek-preview."
---
## **Overzicht**

Dit artikel laat zien hoe je een Excel-kolommendiagram maakt met Aspose.Cells for .NET en het werkboek ervan insluit in een PowerPoint‑presentatie met Aspose.Slides for .NET. Het ingesloten werkboek bevat zowel de brondata als het diagram. Een aparte PNG‑preview geeft het diagram weer op de dia voordat het OLE‑object wordt geactiveerd.

Het resultaat is een ingesloten Excel‑object, geen native PowerPoint‑diagram. Bewerken van het werkboek via OLE vereist een desktop‑applicatie die OLE‑activatie ondersteunt en een compatibele Excel‑installatie.

## **Voorvereisten**

Voeg referenties toe aan Aspose.Cells for .NET en Aspose.Slides for .NET in je C#‑project. Het voorbeeld gebruikt top‑level statements en vereist C# 9 of later. Microsoft Office is niet nodig om de presentatie te genereren met deze bibliotheken.

Er zijn geen invoerbestanden nodig: het voorbeeld maakt de data en het diagram in het geheugen aan en schrijft vervolgens `OutputChart.pptx` naar de huidige werkmap. Pas licenties toe voor beide producten wanneer je buiten de evaluatiemodus werkt.

## **Hoe de insluiting werkt**

1. Maak een werkboek met een gegevens‑werkblad en een diagramblad.  
1. Maak het diagramblad actief zodat het werkboek opent op het diagram.  
1. Stel het OLE‑weergavebereik van het werkboek in en render het diagram naar PNG.  
1. Sla het werkboek op als XLSX in het geheugen en insluit die bytes in een dia.  
1. Wijs de PNG toe als preview van het OLE‑object en sla de presentatie op als PPTX.

Het weergavebereik van het werkboek en het kader op de dia hebben verschillende functies. [SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) neemt nul‑gebaseerde start‑/eind‑rij‑ en kolom‑indices. [ChartCollection.Add](https://reference.aspose.com/cells/net/aspose.cells.charts/chartcollection/add/) daarentegen neemt de bovenste rij, linker kolom, onderste rij en rechter kolom. Het voorbeeld gebruikt rij‑index 55 en kolom‑index 25 als onder‑rechtse grenzen; deze waarden zijn layout‑keuzes, geen aantallen rijen of kolommen.

Het dia‑kader gebruikt punten. Het voorbeeld past het binnen de dia aan en centreert het, terwijl de beeldverhouding van de PNG behouden blijft, in plaats van de preview uit te rekken tot de volledige dia.

## **Maak en insluit de grafiek**

Het volgende volledige voorbeeld vult `DataSheet` met vier rijen en vijf kolommen waarden. Elke rij wordt een grafiek‑serie. `ChartSheet` wordt geselecteerd als het actieve blad voordat het werkboek wordt opgeslagen.

Het werkboek wordt expliciet opgeslagen als XLSX, overeenkomend met de extensie `xlsx` die aan [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) wordt doorgegeven. De PNG wordt direct vanuit de stream geladen zonder een tussenliggende bitmap‑conversie. Toewijzing via [SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/substitutepictureformat/) vervangt de standaard OLE‑plaatsaanduiding.

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

// Render de diagrampreview en serialiseer het bewerkbare werkboek afzonderlijk.
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

// Pas de preview aan binnen de dia zonder de beeldverhouding te wijzigen.
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

## **Verwacht resultaat**

`OutputChart.pptx` bevat één dia met een ingesloten Excel‑werkboek en een grafiek‑preview. Het werkboek bevat de oorspronkelijke gegevens en een kolommendiagram met vier reeksen. De preview staat gecentreerd op de dia en behoudt zijn verhoudingen.

![Excel kolommendiagram weergegeven als preview van een ingesloten werkboek](excel-chart-ole-preview.png)

In een compatibele desktop‑PowerPoint‑omgeving met Excel beschikbaar, kun je dubbelklikken op het object om het ingesloten werkboek te activeren en te bewerken. Activatie en bewerking hangen af van de OLE‑ondersteuning en beveiligingsinstellingen van de host‑applicatie.

## **Veelgestelde vragen**

**Waarom is een preview‑afbeelding nodig?**

Het ingesloten werkboek en de preview op de dia zijn afzonderlijke content. Voorzie een grafiekafbeelding zodat de dia het diagram toont in plaats van de standaard “EMBEDDED OLE OBJECT”‑plaatsaanduiding. Zie [Object Preview Issue when Adding OleObjectFrame](/slides/nl/net/object-preview-issue-when-adding-oleobjectframe/).

**Werk de preview automatisch bij wanneer ik het werkboek in code wijzig?**

Beschouw de preview als een momentopname. Wanneer je werkboekdata programmatically bijwerkt, moet je de grafiekafbeelding opnieuw genereren en zowel de preview als de ingesloten werkboekdata vervangen.

**Kan ik XLS in plaats van XLSX gebruiken?**

Ja. Sla het werkboek op in XLS‑formaat en gebruik `xls` als de extensie voor de ingesloten data. De extensie moet overeenkomen met het daadwerkelijke werkboekformaat; alleen de extensie wijzigen converteert de data niet.

**Waarom kan het object van grootte veranderen na activatie?**

De host‑applicatie kan de presentatie van het OLE‑object bijwerken wanneer het het werkboek activeert. Zowel het OLE‑weergavebereik van het werkboek als de afmetingen van het dia‑kader spelen hierbij een rol. Zie [Working Solution for Chart Resizing in PPTX](/slides/nl/net/working-solution-for-chart-resizing-in-pptx/).

## **Gerelateerde secties**

- [Working Solution for Chart Resizing in PPTX](/slides/nl/net/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/nl/net/object-preview-issue-when-adding-oleobjectframe/)
- [Update OLE Objects Automatically Using a PowerPoint Add-In](/slides/nl/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)