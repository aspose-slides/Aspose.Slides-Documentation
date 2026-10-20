---
title: Werkende oplossing voor het aanpassen van de grafiekgrootte in PPTX
type: docs
weight: 60
url: /nl/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- grafiekgrootte-aanpassing
- Excel-grafiek
- OLE-object
- grafiek insluiten
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Los onverwachte grootteaanpassing van grafieken op in PPTX bij het gebruik van ingesloten Excel OLE-objecten met Aspose.Slides voor .NET. Stel vaste grafiekafmetingen in om de grafiek- en OLE-frame-groottes consistent te houden."
---
## **Achtergrond**

Excel‑grafieken die als OLE‑objecten in PowerPoint‑presentaties zijn ingesloten via Aspose‑componenten, kunnen na de eerste activering van grootte veranderen. Dit kan een merkbaar verschil in het uiterlijk van de grafiek vóór en na activering veroorzaken. Dit artikel legt uit waarom de groottewijziging optreedt en toont hoe je dit kunt voorkomen door de vaste grafiekafmetingen op het OLE‑frame af te stemmen.

In [Maak Excel‑grafieken en embed ze als OLE‑objecten in presentaties](/slides/nl/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) legden we uit hoe je met Aspose.Cells voor .NET een Excel‑grafiek maakt en deze via Aspose.Slides voor .NET in een PowerPoint‑presentatie opneemt. Om het [object‑preview‑probleem](/slides/nl/net/object-preview-issue-when-adding-oleobjectframe/) aan te pakken, hebben we de grafiekafbeelding toegewezen aan het OLE‑objectframe van de grafiek. In de resulterende presentatie, wanneer je dubbelklikt op het OLE‑objectframe dat de grafiekafbeelding toont, wordt de Excel‑grafiek geactiveerd. Gebruikers kunnen de ingesloten Excel‑werkmap bewerken en vervolgens terugkeren naar de dia door buiten de geactiveerde werkmap te klikken. De grootte van het OLE‑objectframe verandert wanneer de gebruiker terugkeert naar de dia, en de factor van de groottewijziging varieert afhankelijk van de oorspronkelijke afmetingen van zowel het OLE‑objectframe als de ingesloten Excel‑werkmap.

## **Oorzaak van groottewijziging**

De ingesloten Excel‑werkmap heeft eigen venstergrootte, die Excel probeert te behouden wanneer het object voor de eerste keer wordt geactiveerd. Het OLE‑frame op de dia heeft onafhankelijk gedefinieerde afmetingen. Wanneer de Excel‑werkmap wordt geactiveerd, onderhandelen Excel en PowerPoint over de grootte van het object om de verhoudingen te behouden als onderdeel van het embed‑proces. Verschillen tussen het werkmapvenster en het OLE‑frame kunnen derhalve leiden tot een aanpassing van de objectgrootte.

## **Werkende oplossing**

Stem de grafiekgrootte af op het OLE‑frame op de dia en houd de grafiekafmetingen onafhankelijk van het werkmapvenster. Deze oplossing werkt zowel met een nieuwe presentatie als met een bestaande sjabloon.

Het voorbeeld vereist Aspose.Cells voor .NET en Aspose.Slides voor .NET. Het maakt een eenvoudige kolomgrafiek op een actief grafiekblad en embedde de werkmap in XLS‑formaat. Er wordt geen grafiek‑preview‑afbeelding toegewezen; de grafiek wordt zichtbaar wanneer het OLE‑object in PowerPoint wordt geactiveerd.

Het voorbeeld maakt een nieuwe presentatie met een OLE‑frame van 9,5 × 4 inch, geplaatst 0,5 inch van de linkerrand en 1 inch van de bovenkant. Dia‑coördinaten en afmetingen worden in points opgegeven (72 points per inch). Voor een bestaande presentatie, zie [Gebruik een sjabloon](#use-a-template).

## **Stel een vaste grafiekgrootte in**

Stel [SizeWithWindow](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/sizewithwindow/) in op false zodat de grafiekafmetingen onafhankelijk zijn van het werkmapvenster. Stel de [ChartObject](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/chartobject/) afmetingen in via [Width](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/width/) en [Height](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/height/), waarbij points naar pixels worden omgerekend met 96 pixels per inch: een frame van 684 × 288 points komt overeen met een grafiek van 912 × 384 pixels. Stel [PrintSize](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/printsize/) in op de Custom‑waarde van [PrintSizeType](https://reference.aspose.com/cells/net/aspose.cells/printsizetype/). Het voorbeeld embedde de werkmap met [AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addoleobjectframe/) en slaat een presentatie op met een OLE‑frame van 9,5 × 4 inch.

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

// Dia-coördinaten en afmetingen zijn in points (72 points per inch).
var width = 684f; // 9,5 inches.
var height = 288f; // 4 inches.

chart.SizeWithWindow = false;
// Converteer points naar grafiekpixels met 96 pixels per inch.
chart.ChartObject.Width = (int)(width / 72f * 96f);
chart.ChartObject.Height = (int)(height / 72f * 96f);
chart.PrintSize = Aspose.Cells.PrintSizeType.Custom;

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Excel97To2003);
var dataInfo = new OleEmbeddedDataInfo(workbookStream.ToArray(), "xls");
slide.Shapes.AddOleObjectFrame(36, 72, width, height, dataInfo);

presentation.Save("chart-fixed-size.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Gebruik een sjabloon**

De logica voor de afmetingen is hetzelfde voor een bestaande presentatie. Om het voorbeeld aan te passen:

1. Laad de sjabloonpresentatie in plaats van een lege presentatie te maken.
1. Controleer dat de eerste dia minstens drie vormen bevat, en gebruik vervolgens de vorm op index 2 als tijdelijke aanduiding.
1. Neem de frame‑breedte en -hoogte van die vorm in plaats van de vaste waarden 684 en 288. Houd de berekeningen ongewijzigd.
1. Voeg het OLE‑frame toe op de positie van de tijdelijke aanduiding in plaats van de vaste coördinaten 36 en 72.
1. Verwijder de tijdelijke aanduiding voordat je de presentatie opslaat.

## **FAQ**

**Waarom verandert mijn ingesloten Excel‑grafiek van grootte nadat hij in PowerPoint is geactiveerd?**

Dit gebeurt omdat Excel probeert de oorspronkelijke venstergrootte te herstellen bij de eerste activering, terwijl het OLE‑objectframe in PowerPoint eigen afmetingen heeft. PowerPoint en Excel onderhandelen over de grootte om de beeldverhouding te behouden, wat kan leiden tot een aanpassing van de grootte.

**Hoe kan ik de grafiek‑ en OLE‑frame‑groottes consistent houden?**

Stel vaste grafiekafmetingen in die overeenkomen met het OLE‑frame en gebruik een aangepaste grafiek‑printgrootte voordat je de werkmap embedt. Het voorbeeld hierboven toont de benodigde instellingen en eenhedenconversies.

**Is het afstemmen van de werkmap‑venstergrootte voldoende?**

Alleen het afstemmen van de werkmap‑venstergrootte voorkomt niet betrouwbaar dat het OLE‑frame van grootte verandert na activering. Gebruik vaste grafiekafmetingen zoals in het voorbeeld.

**Werkt deze oplossing zowel voor sjabloon‑gebaseerde presentaties als voor nieuwe presentaties?**

Ja. Voor een sjabloon gebruik je de afmetingen en positie van de tijdelijke aanduiding. Voor een nieuwe presentatie specificeer je de frame‑afmetingen en positie direct.

**Kan ik dit voorbeeld gebruiken met grafieken die zijn gemaakt in andere spreadsheet‑programma’s?**

Het voorbeeld maakt gebruik van een Excel‑werkmap die is aangemaakt met Aspose.Cells. Het demonstreert geen activatie‑gedrag voor andere spreadsheet‑programma’s.

## **Gerelateerde secties**

- [Maak Excel‑grafieken en embed ze als OLE‑objecten in presentaties](/slides/nl/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Update OLE‑objecten automatisch met een PowerPoint‑add‑in](/slides/nl/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)