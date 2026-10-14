---
title: Pas taartdiagrammen aan in presentaties in .NET
linktitle: Taartdiagram
type: docs
url: /nl/net/pie-chart/
keywords:
- taartdiagram
- diagram beheren
- diagram aanpassen
- diagramopties
- diagraminstellingen
- plotopties
- segmentkleur
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Maak en pas taartdiagrammen aan in .NET met Aspose.Slides. Configureer secundaire plotten, geef gegevenslabels weer en pas automatische segmentkleuren toe in PowerPoint."
---
## **Overzicht**

Dit artikel legt uit hoe je met cirkeldiagrammen in Aspose.Slides werkt. Het laat zien hoe je secundaire plotopties voor Pie of Pie- en Bar of Pie-diagrammen configureert en hoe je automatische kleuring van segmenten inschakelt voor een standaard cirkeldiagram.

De voorbeelden richten zich op taken voor diagramaanpassing, zoals het toevoegen van een diagram aan een dia, het aanpassen van serie‑ en labelinstellingen, het vervangen van standaard diagramgegevens door aangepaste categorieën en waarden, en het opslaan van de bijgewerkte presentatie.

## **Opties voor secundaire plot bij Pie of Pie- en Bar of Pie-diagrammen**

Aspose.Slides for .NET ondersteunt secundaire plotopties voor Pie of Pie- en Bar of Pie-diagrammen. Deze opties bepalen de grootte van de secundaire plot en hoe datapunten tussen de twee plotten worden gesplitst.

Het volgende voorbeeld maakt een Pie of Pie-diagram in een nieuwe presentatie en toont datapuntenwaarden als labels. De [SecondPieSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/secondpiesize/)‑eigenschap stelt de grootte van de secundaire plot in op 149 % van de hoofdplot. [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitby/) kiest procentgebaseerd splitsen, en [PieSplitPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitposition/) stelt de drempel in op 53 %.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
var series = chart.ChartData.Series[0];

// Display values and configure the secondary plot.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.SecondPieSize = 149;
seriesGroup.PieSplitBy = PieSplitType.ByPercentage;
seriesGroup.PieSplitPosition = 53;

presentation.Save("pie_of_pie.pptx", SaveFormat.Pptx);
```

### **Selecteer categorieën voor de secundaire plot**

Gebruik aangepaste splitsing wanneer je specifieke categorieën in de secundaire plot wilt groeperen, ongeacht hun procentuele waarden. Bijvoorbeeld, een verkooprapport kan Online en Evenementen samen tonen zodat lezers deze twee kanalen kunnen vergelijken, ook al vormen ze respectievelijk 35 % en 10 % van de totale verkoop.

Stel [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitby/) in op [PieSplitType.Custom](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplittype/) en selecteer de punten via [PieSplitCustomPoints](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitcustompoints/). De [Add](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/add/)‑methode van de collectie accepteert ofwel een nulgebaseerde index in de serie of een datapuntobject. In dit voorbeeld selecteert index 1 Online, en het punt op index 3 selecteert Evenementen. Partners wordt tijdelijk toegevoegd, daarna uitgesloten met [Remove](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/remove/).

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 200);

// Vervang de standaardgegevens door verkoop per kanaal.
var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "Retail", "Online", "Partners", "Events" };
var values = new[] { 40, 35, 15, 10 };
var seriesNameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.PieSplitBy = PieSplitType.Custom;
seriesGroup.IsColorVaried = true;

// Selecteer Online op basis van zijn nulgebaseerde index en Evenementen op basis van zijn datapuntobject.
seriesGroup.PieSplitCustomPoints.Add(1);
seriesGroup.PieSplitCustomPoints.Add(series.DataPoints[3]);

// Sluit Partners uit de selectie zonder de brongegevens te verwijderen.
seriesGroup.PieSplitCustomPoints.Add(2);
seriesGroup.PieSplitCustomPoints.Remove(series.DataPoints[2]);

presentation.Save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
```

Online (35) en Evenementen (10) verschijnen als afzonderlijke segmenten in de secundaire plot. In de primaire plot worden ze weergegeven als één gecombineerd segment met een waarde van 45, naast Retail (40) en Partners (15). Het verwijderen van Partners uit de aangepaste selectie houdt het segment in de primaire plot; het verwijdert de categorie of de waarde niet uit de brongegevens van het diagram.

De onderstaande afbeelding toont de opgeslagen presentatie in PowerPoint:

![Pie of Pie chart with Online and Events in the secondary plot and their combined value of 45 in the primary plot](pie_of_pie_custom.png)

## **Stel automatische kleuren voor cirkeldiagramsegmenten in**

Aspose.Slides for .NET kan automatisch verschillende kleuren toewijzen aan segmenten van cirkeldiagrammen. Het volgende voorbeeld maakt een cirkeldiagram met een gecentreerde titel en vervangt de standaardgegevens door drie kwartaalcategorieën en hun waarden. De [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/)‑eigenschap toont de waarden 20, 50 en 30 als labels, terwijl [IsColorVaried](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/iscolorvaried/) een aparte kleur voor elk segment mogelijk maakt.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// Voeg een gecentreerde diagramtitel toe.
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// Vervang de standaardgegevens met het eerste werkblad.
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "First Qtr", "2nd Qtr", "3rd Qtr" };
var values = new[] { 20, 50, 30 };
var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

// Toon waarden en wijs verschillende kleuren toe aan de segmenten.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.ParentSeriesGroup.IsColorVaried = true;

presentation.Save("pie.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Worden de Pie of Pie- en Bar of Pie-varianten ondersteund?**

Ja, de bibliotheek [supports](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) een secundaire plot voor cirkeldiagrammen, inclusief de Pie of Pie‑ en Bar of Pie‑typen.

**Kan ik alleen het diagram exporteren als een afbeelding (bijvoorbeeld PNG)?**

Ja, je kunt [export the chart itself as an image](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (zoals PNG) zonder de volledige presentatie te exporteren.