---
title: Maak of werk grafieken in PowerPoint‑presentaties bij in .NET
linktitle: Maak of werk grafieken bij
type: docs
weight: 10
url: /nl/net/create-chart/
keywords:
- grafiek toevoegen
- grafiek maken
- grafiek bewerken
- grafiek wijzigen
- grafiek bijwerken
- spreidingsgrafiek
- taartgrafiek
- lijngrafiek
- boomkaartgrafiek
- aandelengrafiek
- box‑en‑whisker‑grafiek
- trechtergrafiek
- sunburst‑grafiek
- histogramgrafiek
- radargrafiek
- multicategorie‑grafiek
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Maak en pas grafieken aan in PowerPoint‑presentaties met Aspose.Slides voor .NET. Voeg grafieken toe, formatteer en bewerk ze met praktische code‑voorbeelden in C#."
---
## **Overzicht**

Dit artikel biedt een uitgebreide gids over hoe u grafieken maakt en aanpast met Aspose.Slides voor .NET. U leert hoe u programmatatisch een grafiek aan een dia toevoegt, deze van gegevens voorziet en verschillende opmaakopties toepast om aan uw specifieke ontwerpeisen te voldoen. Door het artikel heen illustreren gedetailleerde code‑voorbeelden elke stap, van het initialiseren van de presentatie en het grafiekobject tot het configureren van series, assen en legenda’s. Door deze gids te volgen, krijgt u een solide begrip van hoe u dynamische grafiekgeneratie integreert in uw .NET‑toepassingen, waardoor het maken van gegevensgestuurde presentaties wordt gestroomlijnd.

## **Grafiek maken**

Grafieken helpen mensen snel gegevens te visualiseren en inzichten te verkrijgen die niet meteen duidelijk zijn uit een tabel of spreadsheet.

**Waarom grafieken maken?**

Met grafieken kunt u:

* grote hoeveelheden gegevens samenvoegen, comprimeren of samenvatten op één dia in een presentatie;
* patronen en trends in gegevens blootleggen;
* de richting en het momentum van gegevens in de tijd of ten opzichte van een specifieke meeteenheid afleiden;
* uitschieters, afwijkingen, fouten en onzinnige gegevens opsporen;
* complexe gegevens communiceren of presenteren.

In PowerPoint kunt u grafieken maken via de *Invoegen*-functie, die sjablonen biedt voor het ontwerpen van vele soorten grafieken. Met Aspose.Slides kunt u zowel gewone grafieken (gebaseerd op populaire grafiektype) als aangepaste grafieken maken.

{{% alert color="info" title="Note" %}}
Gebruik de [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) enumeratie onder de [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/) namespace. De waarden in deze enumeratie komen overeen met verschillende grafiektype.
{{% /alert %}}

### **Geclusterde kolomgrafieken maken**

Dit voorbeeld gebruikt [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) om een geclusterde kolomgrafiek te maken die twee series over drie categorieën vergelijkt. De series gebruiken rode en groene opvullingen, en individuele labels tonen categorienamen, serienamen en waarden. Werkblad‑index 0 verwijst naar het eerste blad in de ingebedde grafiek‑werkmap.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);
seriesNameCell = workbook.GetCell(worksheetIndex, 0, 2, "Series 2");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var categoryCell = workbook.GetCell(worksheetIndex, 1, 0, "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(worksheetIndex, 2, 0, "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(worksheetIndex, 3, 0, "Category 3");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series[0];

var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 20);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 1, 50);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 1, 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);

series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

series = chart.ChartData.Series[1];

valueCell = workbook.GetCell(worksheetIndex, 1, 2, 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 2, 10);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 2, 60);
series.DataPoints.AddDataPointForBarSeries(valueCell);

series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;

var label = series.DataPoints[0].Label;
label.DataLabelFormat.ShowCategoryName = true;

label = series.DataPoints[1].Label;
label.DataLabelFormat.ShowSeriesName = true;

label = series.DataPoints[2].Label;
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.ShowSeriesName = true;
label.DataLabelFormat.Separator = "/";

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Het resultaat:

![Geclusterde kolomgrafiek](clustered_column_chart.png)

### **Verspreidingsgrafieken maken**

Verspreidingsgrafieken (ook wel scatter‑plots of x‑y‑grafieken genoemd) worden vaak gebruikt om patronen te zoeken of correlaties tussen twee variabelen aan te tonen.

Gebruik een verspreidingsgrafiek wanneer:

* u gekoppelde numerieke gegevens hebt;
* u twee variabelen heeft die goed bij elkaar passen;
* u wilt bepalen of de twee variabelen met elkaar verband houden;
* u een onafhankelijke variabele hebt die meerdere waarden heeft voor een afhankelijke variabele.

Dit voorbeeld plot twee sets x‑y‑waarden. De eerste serie gebruikt rechte lijnen met ster‑markers, terwijl de tweede gladde lijnen met cirkel‑markers gebruikt; beide gebruiken een [Size](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/size/) van 10. De [Symbol](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/symbol/)‑eigenschap bepaalt de marker‑vorm.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, 1, 1, "Series 1");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);
seriesNameCell = workbook.GetCell(worksheetIndex, 1, 3, "Series 2");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var series = chart.ChartData.Series[0];

var xValueCell = workbook.GetCell(worksheetIndex, 2, 1, 1);
var yValueCell = workbook.GetCell(worksheetIndex, 2, 2, 3);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 3, 1, 2);
yValueCell = workbook.GetCell(worksheetIndex, 3, 2, 10);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

series = chart.ChartData.Series[1];

xValueCell = workbook.GetCell(worksheetIndex, 2, 3, 5);
yValueCell = workbook.GetCell(worksheetIndex, 2, 4, 2);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 3, 3, 3);
yValueCell = workbook.GetCell(worksheetIndex, 3, 4, 1);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 4, 3, 2);
yValueCell = workbook.GetCell(worksheetIndex, 4, 4, 2);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 5, 3, 5);
yValueCell = workbook.GetCell(worksheetIndex, 5, 4, 1);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Het resultaat:

![Verspreidingsgrafiek](scatter_chart.png)

### **Taartgrafieken maken**

Taartgrafieken worden het best gebruikt om de deel‑tot‑geheel‑relatie in gegevens te tonen, vooral wanneer de gegevens categorische labels met numerieke waarden bevatten. Als uw gegevens echter veel delen of labels bevatten, kunt u overwegen een staafgrafiek te gebruiken.

Dit voorbeeld maakt een taartgrafiek met drie kwartaalwaarden. Elke part heeft een aangepaste opvulling en rand, en de labels tonen verschillende combinaties van waarden, percentages en serievormgeving. De [FirstSliceAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/firstsliceangle/)‑eigenschap stelt de eerste part in op 180 graden.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var categoryCell = workbook.GetCell(0, 1, 0, "1st Qtr");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 2, 0, "2nd Qtr");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 3, 0, "3rd Qtr");
chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 20);
series.DataPoints.AddDataPointForPieSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 1, 50);
series.DataPoints.AddDataPointForPieSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 1, 30);
series.DataPoints.AddDataPointForPieSeries(valueCell);

chart.ChartData.SeriesGroups[0].IsColorVaried = true;

var firstSlice = series.DataPoints[0];
firstSlice.Format.Fill.FillType = FillType.Solid;
firstSlice.Format.Fill.SolidFillColor.Color = Color.Cyan;

firstSlice.Format.Line.FillFormat.FillType = FillType.Solid;
firstSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
firstSlice.Format.Line.Width = 3.0;
firstSlice.Format.Line.Style = LineStyle.ThinThick;
firstSlice.Format.Line.DashStyle = LineDashStyle.LargeDash;

var secondSlice = series.DataPoints[1];
secondSlice.Format.Fill.FillType = FillType.Solid;
secondSlice.Format.Fill.SolidFillColor.Color = Color.Brown;

secondSlice.Format.Line.FillFormat.FillType = FillType.Solid;
secondSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
secondSlice.Format.Line.Width = 3.0;
secondSlice.Format.Line.Style = LineStyle.Single;
secondSlice.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

var thirdSlice = series.DataPoints[2];
thirdSlice.Format.Fill.FillType = FillType.Solid;
thirdSlice.Format.Fill.SolidFillColor.Color = Color.Coral;

thirdSlice.Format.Line.FillFormat.FillType = FillType.Solid;
thirdSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
thirdSlice.Format.Line.Width = 2.0;
thirdSlice.Format.Line.Style = LineStyle.ThinThin;
thirdSlice.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

var firstLabel = series.DataPoints[0].Label;
firstLabel.DataLabelFormat.ShowValue = true;

var secondLabel = series.DataPoints[1].Label;
secondLabel.DataLabelFormat.ShowValue = true;
secondLabel.DataLabelFormat.ShowLegendKey = true;
secondLabel.DataLabelFormat.ShowPercentage = true;

var thirdLabel = series.DataPoints[2].Label;
thirdLabel.DataLabelFormat.ShowSeriesName = true;
thirdLabel.DataLabelFormat.ShowPercentage = true;

series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

presentation.Save("PieChart.pptx", SaveFormat.Pptx);
```

Het resultaat:

![Taartgrafiek](pie_chart.png)

Om de leesbaarheid van labels buiten de taart te verbeteren, zie [Leiderslijnen opmaken](/slides/nl/net/chart-data-label/#format-leader-lines) voor een voorbeeld dat labels positioneert en de kleur, breedte, transparantie en stippellijnstijl van de lijnen aanpast.

### **Lijngrafieken maken**

Lijngrafieken (ook wel lijndiagrammen genoemd) worden het best gebruikt wanneer u veranderingen in waarde over tijd wilt tonen. Met een lijngrafiek kunt u veel gegevens tegelijk vergelijken, trends in de tijd volgen, afwijkingen in series benadrukken en meer.

Dit voorbeeld gebruikt [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) om een lijngrafiek te maken met de standaard series en categorieën, en slaat de presentatie vervolgens op als PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var lineChart = slide.Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

presentation.Save("lineChart.pptx", SaveFormat.Pptx);
```

Standaard worden punten op een lijngrafiek verbonden door rechte, doorlopende lijnen. Als u de punten liever met streepjes wilt verbinden, stel dan [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) in op een waarde uit [LineDashStyle](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var lineChart = slide.Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

foreach (var series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

Het resultaat:

![Lijngrafiek](line_chart.png)

### **Tree Map‑grafieken maken**

Tree Map‑grafieken worden het best gebruikt voor verkoopgegevens wanneer u de relatieve grootte van datacategorieën wilt tonen en snel de items wilt benadrukken die grote bijdragers zijn binnen elke categorie.

Dit voorbeeld maakt een tree map met acht bladeren gegroepeerd in vier stammen en twee takken. De [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/)‑methode kent stammen toe op groeperingsniveau 1 en takken op niveau 2. Waarden bepalen de relatieve rechthoekgroottes, terwijl categorielabels en overlappende bovenliggende labels de hiërarchie aangeven.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Tak 1
var categoryCell = workbook.GetCell(0, "C1", "Leaf1");
var leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

categoryCell = workbook.GetCell(0, "C2", "Leaf2");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C3", "Leaf3");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

categoryCell = workbook.GetCell(0, "C4", "Leaf4");
chart.ChartData.Categories.Add(categoryCell);

// Tak 2
categoryCell = workbook.GetCell(0, "C5", "Leaf5");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

categoryCell = workbook.GetCell(0, "C6", "Leaf6");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C7", "Leaf7");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

categoryCell = workbook.GetCell(0, "C8", "Leaf8");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Treemap);
series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
var valueCell = workbook.GetCell(0, "D1", 4);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D2", 5);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D3", 3);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D4", 6);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D5", 9);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D6", 9);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D7", 4);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D8", 3);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);

series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

presentation.Save("Treemap.pptx", SaveFormat.Pptx);
```

Het resultaat:

![Boomkaartgrafiek](treemap_chart.png)

### **Watervalgrafieken maken**

Een watervalgrafiek toont hoe positieve en negatieve veranderingen bijdragen aan een eindwaarde. Bijvoorbeeld, een winst‑analyse kan beginnen met omzet, kosten aftrekken en andere inkomsten toevoegen. Veranderingskolommen zweven tussen de vorige en nieuwe lopende waarden, terwijl totaalkolommen van nul tot de opgehoopte waarde reiken.

De volgende tabel toont de gebruikte waarden (in duizenden Amerikaanse dollars):

| Categorie | Werkboekwaarde | Kolomtype |
| --- | ---: | --- |
| Omzet | 1000 | Toename |
| Kosten van verkoop | -400 | Afname |
| Brutowinst | 600 | Tussentotaal |
| Operationele kosten | -200 | Afname |
| Overig inkomen | 50 | Toename |
| Netto winst | 450 | Eindtotaal |

Om een punt te markeren als een tussentotaal of eindtotaal, stel de [SetAsTotal](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatapoint/setastotal/)‑eigenschap in op `true`. Geef het werkboek‑celdrukte‑bedrag op in die punt‑cel: `600` voor brutowinst (`1000 - 400`) en `450` voor netto winst (`600 - 200 + 50`). De eigenschap markeert de kolom als een totaal; ze berekent of vult de celwaarde niet. Gebruik geen nul als tijdelijke aanduiding en geef geen andere verandering voor een totaalpunt. Een totaal‑kolom toont de opgehoopte waarde zonder deze opnieuw bij te tellen bij de lopende waarde.

Dit volledige C#‑voorbeeld maakt een grafiek met het `Waterfall`‑element van [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/), wist de standaardgegevens en vult de ingebedde werkmap. Werkblad‑index `0` selecteert het eerste werkblad; kolom A bevat categorienamen en kolom B bevat waarden. Elke waardecel wordt toegevoegd met [AddDataPointForWaterfallSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/adddatapointforwaterfallseries/). De nul‑gebaseerde puntindices `2` en `5` identificeren respectievelijk het tussentotaal en het eindtotaal. Het inschakelen van [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) toont de bedragen op de kolommen. Er is geen invoer‑presentatie of werkmap vereist.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Waterfall, 20, 20, 680, 200);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Profit breakdown (USD thousands)");
chart.ChartTitle.Overlay = false;
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

workbook.Clear(worksheetIndex);

var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Profit");
var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.Waterfall);
var categories = new[] { "Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit" };
var values = new double[] { 1000, -400, 600, -200, 50, 450 };

for (var i = 0; i < categories.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categories[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForWaterfallSeries(valueCell);
}

// De derde en zesde punten vertegenwoordigen totalen, niet extra veranderingen.
series.DataPoints[2].SetAsTotal = true;
series.DataPoints[5].SetAsTotal = true;
series.ShowConnectorLines = true;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("WaterfallChart.pptx", SaveFormat.Pptx);
```

Stel de series‑niveau‑eigenschap [ShowConnectorLines](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/showconnectorlines/) in op `true` om lijnen te tonen die opeenvolgende kolommen verbinden en de lopende waarde makkelijker volgbaar maken. Om deze lijnen te verbergen, vervang de toewijzing in het voorbeeld door `series.ShowConnectorLines = false;` vóór het opslaan. Dit wijzigt alleen de zichtbaarheid van de lijnen, niet de gegevens of totalen.

Het opgeslagen document toont een brutowinst van 600 en een netto winst van 450, waarbij beide totalen vanaf nul worden opgebouwd:

![Watervalgrafiek die omzet, kosten, brutowinst van 600 en netto winst van 450 toont, met waardelabels en verbindingslijnen](waterfall_chart.png)

### **Aandelengrafieken maken**

Aandelengrafieken worden gebruikt om financiële gegevens zoals openings‑, hoog‑, laag‑ en slotkoersen weer te geven, zodat markttrends en volatiliteit geanalyseerd kunnen worden. Ze bieden essentiële inzichten in aandelenprestaties, waardoor beleggers en analisten weloverwogen beslissingen kunnen nemen.

Dit voorbeeld maakt een open‑high‑low‑close‑grafiek met vier series in die volgorde en drie categorieën. De [HasUpDownBars](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/hasupdownbars/)‑eigenschap schakelt op/af‑balken in, en [HiLowLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/hilowlinesformat/) regelt de hoog‑laag‑lijnen die de prijsintervallen tonen, terwijl de individuele series‑lijnen en kleine horizontale rasterlijnen verborgen blijven.

De [UpDownBars](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/updownbars/)‑manager biedt aparte [UpBarsFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/upbarsformat/)‑ en [DownBarsFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/downbarsformat/)‑objecten. Gebruik voor elk object de [Fill](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/fill/)‑ en [Line](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/line/)‑eigenschappen om de opvulling en omtrek onafhankelijk in te stellen. Dit voorbeeld gebruikt groene balken met donker‑groene omtrek voor stijgende intervallen en oranje‑rode balken met donker‑rode omtrek voor dalende intervallen.

Geef numerieke waarden op voor alle vier series per categorie, waarbij Hoog en Laag Open en Slot omsluiten. De balken vergelijken Slot met Open **binnen dezelfde categorie**, niet met de vorige categorie: A daalt van 72 naar 25, terwijl B stijgt van 25 naar 38 en C stijgt van 38 naar 50. Gelijke Open‑ en Slot‑waarden geven geen zichtbaar gevuld interval. Op/af‑balken beslaan Open‑Slot; hoog‑laag‑lijnen beslaan Laag‑Hoog. Deze balken behoren tot de series‑groep en zijn geen gewone staafgrafiek‑series.

Deze opmaak werkt ook met [Line and LineWithMarkers](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)‑grafieken die minimaal twee series in dezelfde groep en overeenkomstige numerieke waarden per categorie bevatten. Voor deze niet‑gestapelde lijngrafieken vergelijken op/af‑balken de eerste en laatste serie: een hoger laatste punt levert een op‑balk op, een lager laatste punt levert een af‑balk op. Het omkeren van die series keert de classificatie om. Het onderstaande voorbeeld gebruikt [OpenHighLowClose](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/); ga er niet van uit dat andere aandelengrafiek‑, gestapelde‑lijn‑ of 3D‑varianten dezelfde gegevensindeling of intervalinterpretatie hanteren.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 150, false);

var workbook = chart.ChartData.ChartDataWorkbook;

var categoryCell = workbook.GetCell(0, 1, 0, "A");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 2, 0, "B");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 3, 0, "C");
chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, 0, 1, "Open");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 2, "High");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 3, "Low");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 4, "Close");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);

var series = chart.ChartData.Series[0];
var valueCell = workbook.GetCell(0, 1, 1, 72);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 1, 25);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 1, 38);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[1];
valueCell = workbook.GetCell(0, 1, 2, 172);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 2, 57);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 2, 57);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[2];
valueCell = workbook.GetCell(0, 1, 3, 12);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 3, 12);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 3, 13);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[3];
valueCell = workbook.GetCell(0, 1, 4, 25);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 4, 38);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 4, 50);
series.DataPoints.AddDataPointForStockSeries(valueCell);

var upDownBars = chart.ChartData.SeriesGroups[0].UpDownBars;
upDownBars.HasUpDownBars = true;

upDownBars.UpBarsFormat.Fill.FillType = FillType.Solid;
upDownBars.UpBarsFormat.Fill.SolidFillColor.Color = Color.LimeGreen;
upDownBars.UpBarsFormat.Line.FillFormat.FillType = FillType.Solid;
upDownBars.UpBarsFormat.Line.FillFormat.SolidFillColor.Color = Color.DarkGreen;
upDownBars.UpBarsFormat.Line.Width = 2;

upDownBars.DownBarsFormat.Fill.FillType = FillType.Solid;
upDownBars.DownBarsFormat.Fill.SolidFillColor.Color = Color.OrangeRed;
upDownBars.DownBarsFormat.Line.FillFormat.FillType = FillType.Solid;
upDownBars.DownBarsFormat.Line.FillFormat.SolidFillColor.Color = Color.DarkRed;
upDownBars.DownBarsFormat.Line.Width = 2;

chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

foreach (var stockSeries in chart.ChartData.Series)
{
    stockSeries.Format.Line.FillFormat.FillType = FillType.NoFill;
}

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
```

Het resultaat, geëxporteerd vanuit PowerPoint:

![Aandelengrafiek met een oranje‑rode dalende interval voor A en groene stijgende intervallen voor B en C](stock_chart.png)

### **Box‑en‑whisker‑grafieken maken**

Box‑en‑whisker‑grafieken worden gebruikt om de verdeling van gegevens weer te geven door belangrijke statistische maten, zoals mediaan, kwartielen en mogelijke uitschieters, samen te vatten. Ze zijn bijzonder nuttig bij verkennende data‑analyse en statistische studies om snel de variabiliteit van gegevens te begrijpen en eventuele anomalieën te identificeren.

Dit voorbeeld maakt een box‑en‑whisker‑grafiek van zes waarden. De [QuartileMethod](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/quartilemethod/)‑eigenschap selecteert de exclusieve kwartielberekening. Het voorbeeld schakelt tevens gemiddelde‑lijnen, gemiddelde‑markers, interne punten en uitschieter‑punten in.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A1", "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A2", "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A3", "Category 3");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A4", "Category 4");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A5", "Category 5");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A6", "Category 6");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

series.QuartileMethod = QuartileMethodType.Exclusive;
series.ShowMeanLine = true;
series.ShowMeanMarkers = true;
series.ShowInnerPoints = true;
series.ShowOutlierPoints = true;

var valueCell = workbook.GetCell(0, "B1", 15);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B2", 41);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B3", 16);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B4", 10);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B5", 23);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B6", 16);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);

presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
```

### **Funnel‑grafieken maken**

Funnel‑grafieken worden gebruikt om processen te visualiseren die uit opeenvolgende fasen bestaan, waarbij het volume aan gegevens afneemt naarmate het van de ene stap naar de volgende gaat. Ze zijn vooral handig voor het analyseren van conversieratio’s, het identificeren van knelpunten en het volgen van de efficiëntie van verkoop‑ of marketingprocessen.

Dit voorbeeld gebruikt [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) om een funnel‑grafiek toe te voegen aan de eerste dia van een bestaande presentatie. Het vervangt de standaardgegevens door zes categorieën en waarden variërend van 50 tot 500, en slaat de bijgewerkte presentatie vervolgens op. De invoer‑presentatie moet minstens één dia bevatten.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A1", "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A2", "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A3", "Category 3");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A4", "Category 4");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A5", "Category 5");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A6", "Category 6");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Funnel);

var valueCell = workbook.GetCell(0, "B1", 50);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B2", 100);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B3", 200);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B4", 300);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B5", 400);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B6", 500);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);

presentation.Save("Funnel.pptx", SaveFormat.Pptx);
```

Het resultaat:

![Trechtergrafiek](funnel_chart.png)

### **Sunburst‑grafieken maken**

Sunburst‑grafieken worden gebruikt om hiërarchische gegevens te visualiseren, waarbij niveaus als concentrische ringen worden weergegeven. Ze helpen de deel‑tot‑geheel‑relaties te illustreren en zijn ideaal voor het representeren van geneste categorieën en subcategorieën in een duidelijk, compact formaat.

Dit voorbeeld maakt een sunburst‑grafiek met acht bladeren gegroepeerd in vier stammen en twee takken. De [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/)‑methode kent stammen toe op groeperingsniveau 1 en takken op niveau 2. Categorie‑labels identificeren de segmenten, en de waarden bepalen hun relatieve grootte.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Tak 1
var categoryCell = workbook.GetCell(0, "C1", "Leaf1");
var leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

categoryCell = workbook.GetCell(0, "C2", "Leaf2");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C3", "Leaf3");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

categoryCell = workbook.GetCell(0, "C4", "Leaf4");
chart.ChartData.Categories.Add(categoryCell);

// Tak 2
categoryCell = workbook.GetCell(0, "C5", "Leaf5");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

categoryCell = workbook.GetCell(0, "C6", "Leaf6");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C7", "Leaf7");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

categoryCell = workbook.GetCell(0, "C8", "Leaf8");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Sunburst);
series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
var valueCell = workbook.GetCell(0, "D1", 4);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D2", 5);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D3", 3);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D4", 6);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D5", 9);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D6", 9);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D7", 4);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D8", 3);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);

presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
```

Het resultaat:

![Sunburst‑grafiek](sunburst_chart.png)

### **Histogramgrafieken maken**

Histogramgrafieken tonen hoe numerieke waarden over intervallen (bins) zijn verdeeld. Voor maandelijkse rapporten over verwerkingstijden van bestellingen, gebruik dezelfde bin‑breedte en drempels om intervallen consistent te houden en verdelingen makkelijker te vergelijken.

Stel de horizontale as‑[AggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/aggregationtype/) in op een modus uit [AxisAggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/axisaggregationtype/). [BinWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/binwidth/) is alleen van toepassing bij `ByBinWidth`; [NumberOfBins](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberofbins/) alleen bij `ByNumberOfBins`. Gebruik `Automatic` om de grafiek de bins zelf te laten bepalen.

#### **Gebruik een vaste binbreedte**

Dit voorbeeld groepeert verwerkingstijden in 10‑minuten‑intervallen, met aparte bins voor tijden ≤ 10 minuten en > 40 minuten. Schakel deze bins in met [IsUnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isunderflowbin/) en [IsOverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isoverflowbin/). Wanneer u expliciete [UnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/underflowbin/)‑ en [OverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/overflowbin/)‑drempels opgeeft, stel dan [IsAutomaticUnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticunderflowbin/) en [IsAutomaticOverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticoverflowbin/) in op `false`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Histogram, 20, 20, 680, 200);

chart.HasLegend = false;
chart.HasTitle = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Histogram);
double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
for (var i = 0; i < values.Length; i++)
{
    var valueCell = workbook.GetCell(0, i, 0, values[i]);
    series.DataPoints.AddDataPointForHistogramSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.AggregationType = AxisAggregationType.ByBinWidth;
axis.BinWidth = 10;
axis.IsUnderflowBin = true;
axis.IsAutomaticUnderflowBin = false;
axis.UnderflowBin = 10;
axis.IsOverflowBin = true;
axis.IsAutomaticOverflowBin = false;
axis.OverflowBin = 40;

presentation.Save("Histogram-bin-width.pptx", SaveFormat.Pptx);
```

De presentatie in PowerPoint toont bin‑aantallen van **3, 4, 4, 4 en 2**. De underflow‑bin omvat `5, 10, 10`, dus de drempel is inclusief. De overflow‑bin omvat alleen `41, 50`, dus de drempel is exclusief; beide waarden gelijk aan `40` blijven in het voorgaande interval. De binnen‑bins bevatten waarden groter dan hun ondergrens en kleiner‑of‑gelijk aan hun bovengrens.

![Histogram met 10‑minuten‑bins en expliciete underflow‑ en overflow‑drempels](histogram_bin_width.png)

#### **Specificeer het aantal bins**

Voor een vast detailniveau in plaats van vaste intervallen, vraag vijf bins aan voor dezelfde data. Dit voorbeeld laat underflow‑ en overflow‑bins uitgeschakeld. De grafiek bepaalt de breedte vanuit het gegevensbereik, zodat grenzen kunnen variëren tussen rapporten.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Histogram, 20, 20, 680, 200);

chart.HasLegend = false;
chart.HasTitle = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Histogram);
double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
for (var i = 0; i < values.Length; i++)
{
    var valueCell = workbook.GetCell(0, i, 0, values[i]);
    series.DataPoints.AddDataPointForHistogramSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.AggregationType = AxisAggregationType.ByNumberOfBins;
axis.NumberOfBins = 5;

presentation.Save("Histogram-bin-count.pptx", SaveFormat.Pptx);
```

De vijf bins hebben aantallen van **4, 4, 4, 4 en 1**. Vergelijk deze verdeling met het vaste‑breedte‑resultaat hierboven: de invoerwaarden zijn identiek, maar de grenzen verschillen.

![Histogram met vijf bins berekend uit dezelfde data](histogram_bin_count.png)

### **Radargrafieken maken**

Radargrafieken worden gebruikt om multivariate gegevens in een tweedimensionaal formaat weer te geven, waardoor meerdere variabelen tegelijk gemakkelijk kunnen worden vergeleken. Ze zijn bijzonder nuttig om patronen, sterktes en zwaktes over meerdere prestatiestatistieken of attributen te identificeren.

Dit voorbeeld gebruikt [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) om een radargrafiek te maken met de standaard series en categorieën, en slaat de presentatie vervolgens op als PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);

presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
```

Het resultaat:

![Radargrafiek](radar_chart.png)

### **Multi‑categorie‑grafieken maken**

Multi‑categorie‑grafieken worden gebruikt om gegevens weer te geven die meer dan één categorische groepering bevatten, zodat u waarden over meerdere dimensies tegelijk kunt vergelijken. Ze zijn bijzonder nuttig wanneer u trends en relaties binnen complexe, meerlagige datasets moet analyseren.

Dit voorbeeld maakt een geclusterde kolomgrafiek met acht categorieën die in vier paren zijn gerangschikt. De [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/)‑methode geeft elk paar een gedeeld label op groeperingsniveau 1, waardoor een categoriebenadering ontstaat met zowel individuele als groepslabels.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var worksheetIndex = 0;

var categoryCell = workbook.GetCell(0, "c2", "A");
var category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group1");
categoryCell = workbook.GetCell(0, "c3", "B");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c4", "C");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group2");
categoryCell = workbook.GetCell(0, "c5", "D");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c6", "E");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group3");
categoryCell = workbook.GetCell(0, "c7", "F");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c8", "G");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group4");
categoryCell = workbook.GetCell(0, "c9", "H");
category = chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, "D1", "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.ClusteredColumn);

var valueCell = workbook.GetCell(worksheetIndex, "D2", 10);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D3", 20);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D4", 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D5", 40);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D6", 50);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D7", 60);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D8", 70);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D9", 80);
series.DataPoints.AddDataPointForBarSeries(valueCell);

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Het resultaat:

![Grafiek met meerdere categorieën](multi_category_chart.png)

#### **Verwijder een kwartaallabel**

Download [quarters.pptx](quarters.pptx) en plaats het in de werkmap. De grafiek toont negen maanden en één verkoopserie met waarden van 10 tot 18. De categoriebenadering heeft drie kwartaal‑labels: Q1 beslaat Jan‑Mrt, Q2 Apr‑Jun en Q3 Jul‑Sep.

April is de vierde categorie en de categorie waarop Q2 expliciet was ingesteld. Roep [DeleteGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/deletegroupingitem/) aan op de [GroupingLevels](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/groupinglevels/)‑collectie van april. Het niveau is relatief ten opzichte van april: niveau 1 is het kwartaal, niveau 0 is de maand zelf. De methode kan de blad‑categorie op niveau 0 niet verwijderen.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (var presentation = new Presentation("quarters.pptx"))
{
    var chart = (IChart)presentation.Slides[0].Shapes[0];
    var april = chart.ChartData.Categories[3];
    april.GroupingLevels.DeleteGroupingItem(1);

    presentation.Save("quarters-updated.pptx", SaveFormat.Pptx);
}

using var reopened = new Presentation("quarters-updated.pptx");
var updatedChart = (IChart)reopened.Slides[0].Shapes[0];
var data = updatedChart.ChartData;

Console.WriteLine(string.Join(", ", data.Categories.Select(month => month.AsCell.Value)));
Console.WriteLine(string.Join(", ", data.Series[0].DataPoints.Select(point => point.Value.Data)));
```

De geopende grafiek toont de oorspronkelijke maanden (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) en verkoopwaarden (`10, 11, 12, 13, 14, 15, 16, 17, 18`) in dezelfde volgorde. Open `quarters-updated.pptx` in PowerPoint om de as‑labels te vergelijken. Het Q2‑label en de groepsgrens vóór april verdwijnen, zodat Q1 van januari tot en met juni loopt. Q3 begint nog steeds in juli.

![Kwartaallabels vóór en na verwijdering. Links loopt Q2 van april tot en met juni. Rechts loopt Q1 van januari tot en met juni.](quarter-label-comparison.png)

### **Kaartgrafieken maken**

Kaartgrafieken worden gebruikt om geografische gegevens te visualiseren door informatie te koppelen aan specifieke locaties zoals landen, staten of steden. Ze zijn bijzonder nuttig voor het analyseren van regionale trends, demografische data en ruimtelijke distributies op een duidelijke, visueel aantrekkelijke manier.

Dit voorbeeld gebruikt [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) om een kaartgrafiek te maken met de standaard geografische gegevens en slaat deze vervolgens op voor weergave in PowerPoint.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);

presentation.Save("mapChart.pptx", SaveFormat.Pptx);
```

Het resultaat:

![Kaartgrafiek](map_chart.png)

{{% alert color="info" title="Note" %}}
Afbeelding hierboven toont de opgeslagen presentatie geopend in PowerPoint. Aspose.Slides schrijft de kaartgrafiek en de bijbehorende gegevens correct, maar tekent zelf geen kaartgrafieken: wanneer een dia met een kaartgrafiek wordt gerenderd naar een afbeelding of geconverteerd naar PDF of SVG, blijft het grafiekgebied leeg. Andere vormen op dezelfde dia blijven onaangetast.
{{% /alert %}}

### **Combinatiegrafieken maken**

Een combinatie‑grafiek (of combo‑grafiek) combineert twee of meer grafiektype in één grafiek. Deze grafiek laat u verschillen tussen twee of meer datasets benadrukken, vergelijken of onderzoeken, zodat relaties tussen hen geïdentificeerd kunnen worden.

![Combinatiegrafiek](combination_chart.png)

Dit voorbeeld combineert twee geclusterde kolomseries met een lijngrafiek over vier categorieën. De kolommen gebruiken de primaire verticale as, terwijl [PlotOnSecondAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/plotonsecondaxis/) de lijn op een secundaire verticale as rechts plaatst. Hulp‑functies configureren de titel, legenda, as‑labels en rasterlijnen.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

CreateComboChart();

static void CreateComboChart()
{
    using var presentation = new Presentation();
    var chart = CreateChartWithFirstSeries(presentation.Slides[0]);

    AddSecondSeriesToChart(chart);
    AddThirdSeriesToChart(chart);

    SetPrimaryAxesFormat(chart);
    SetSecondaryAxesFormat(chart);

    presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
}

static IChart CreateChartWithFirstSeries(ISlide slide)
{
    var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    var portionFormat = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    var worksheetIndex = 0;

    var categoryCell = workbook.GetCell(worksheetIndex, 1, 0, "Category 1");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 2, 0, "Category 2");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 3, 0, "Category 3");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 4, 0, "Category 4");
    chart.ChartData.Categories.Add(categoryCell);

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
    var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 4.3);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 1, 2.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 1, 3.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 1, 4.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);

    return chart;
}

static void AddSecondSeriesToChart(IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 2, "Series 2");
    var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    var valueCell = workbook.GetCell(worksheetIndex, 1, 2, 2.4);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 2, 4.4);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 2, 1.8);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 2, 2.8);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

static void AddThirdSeriesToChart(IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Series 3");
    var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.Line);

    var valueCell = workbook.GetCell(worksheetIndex, 1, 3, 2.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 3, 2.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 3, 3.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 3, 5.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);

    series.PlotOnSecondAxis = true;
}

static void SetPrimaryAxesFormat(IChart chart)
{
    var horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    var verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    var majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

static void SetSecondaryAxesFormat(IChart chart)
{
    var secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    var secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    var titlePortionFormat = axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```

## **Grafieken bijwerken**

Aspose.Slides voor .NET stelt u in staat PowerPoint‑grafieken bij te werken door grafiekgegevens, opmaak en styling te wijzigen. Deze functionaliteit vereenvoudigt het up‑to‑date houden van presentaties met dynamische inhoud en zorgt ervoor dat grafieken nauwkeurig de huidige gegevens en visuele standaarden weergeven.

Dit voorbeeld werkt de grafiek met de naam “My chart” op de eerste dia van een bestaande presentatie bij. Het vereist twee kolom‑series met elk drie gegevenspunten, waarbij categorielabels in kolom A en serienamen in de eerste rij van het eerste werkblad staan. Het voorbeeld gebruikt [GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) om werkboekcellen te wijzigen, werkt serie‑waarden bij, voegt een derde serie toe en verandert de grafiek naar geclusterde cilinders via [Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/type/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

foreach (IShape shape in slide.Shapes)
{
    if (shape is IChart chart && chart.Name == chartName)
    {
        var worksheetIndex = 0;

        var workbook = chart.ChartData.ChartDataWorkbook;

        workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
        workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

        var series = chart.ChartData.Series[0];

        workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1");
        series.DataPoints[0].Value.Data = 90;
        series.DataPoints[1].Value.Data = 123;
        series.DataPoints[2].Value.Data = 44;

        series = chart.ChartData.Series[1];

        workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2");
        series.DataPoints[0].Value.Data = 23;
        series.DataPoints[1].Value.Data = 67;
        series.DataPoints[2].Value.Data = 99;

        var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Series 3");
        series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

        var valueCell = workbook.GetCell(worksheetIndex, 1, 3, 20);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
        valueCell = workbook.GetCell(worksheetIndex, 2, 3, 50);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
        valueCell = workbook.GetCell(worksheetIndex, 3, 3, 30);
        series.DataPoints.AddDataPointForBarSeries(valueCell);

        chart.Type = ChartType.ClusteredCylinder;
    }
}

presentation.Save("AsposeChartModified.pptx", SaveFormat.Pptx);
```

## **Gegevensbereik instellen voor een grafiek**

Om het reeds door een bestaande grafiek gebruikte bereik te bekijken, zie [Het gegevensbereik van een grafiek ophalen](/slides/nl/net/chart-workbook/#retrieve-a-charts-data-range).

Aspose.Slides voor .NET biedt de flexibiliteit om een specifiek gegevensbereik uit een werkblad als bron voor de gegevens van uw grafiek in te stellen. Dit betekent dat u rechtstreeks een deel van uw werkblad aan de grafiek kunt koppelen, zodat u kunt bepalen welke cellen bijdragen aan de series en categorieën van de grafiek. Als gevolg hiervan kunt u uw grafieken eenvoudig bijwerken en synchroniseren met de laatste gegevenswijzigingen in uw werkblad, waardoor uw PowerPoint‑presentaties actuele en nauwkeurige informatie weergeven.

Dit voorbeeld gebruikt [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) om de gegevensbron van de grafiek met de naam “My chart” op de eerste dia van een bestaande presentatie in te stellen op `Sheet1!A1:B4`. De grafiek‑werkmap moet dat werkblad bevatten en een gevulde range met een serietitel in de eerste rij, categorielabels in kolom A en drie waarden in kolom B.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

foreach (IShape shape in slide.Shapes)
{
    if (shape is IChart chart && chart.Name == chartName)
    {
        chart.ChartData.SetRange("Sheet1!A1:B4");
    }
}

presentation.Save("SetDataRange.pptx", SaveFormat.Pptx);
```

## **Standaard markers gebruiken in grafieken**

Wanneer u standaard markers in grafieken gebruikt, krijgt elke grafiekserie automatisch een ander standaard marker‑symbool.

Dit voorbeeld gebruikt [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) om een grafiek te maken met twee lijngrafiek‑series en een legenda. De [Marker](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/marker/)‑instellingen behouden de automatisch toegewezen marker‑symbolen. De eerste serie bevat een negatieve waarde en een ontbrekende waarde, weergegeven door `null`, terwijl de tweede voor elke categorie een waarde heeft.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;

var seriesNameCell = workbook.GetCell(0, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var categoryCell = workbook.GetCell(0, 1, 0, "C1");
chart.ChartData.Categories.Add(categoryCell);
var valueCell = workbook.GetCell(0, 1, 1, 24);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 2, 0, "C2");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 2, 1, 23);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 3, 0, "C3");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 3, 1, -10);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 4, 0, "C4");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 4, 1, null);
series.DataPoints.AddDataPointForLineSeries(valueCell);

seriesNameCell = workbook.GetCell(0, 0, 2, "Series 2");
var secondSeries = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

valueCell = workbook.GetCell(0, 1, 2, 30);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 2, 10);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 2, 60);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 4, 2, 40);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);

chart.HasLegend = true;
chart.Legend.Overlay = false;

presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Welke grafiektype worden ondersteund door Aspose.Slides for .NET?**

Aspose.Slides for .NET ondersteunt een breed scala aan grafiektype, waaronder staaf, lijn, taart, gebied, spreiding, histogram, radar en nog veel meer. Deze flexibiliteit stelt u in staat het meest geschikte type te kiezen voor uw visualisatie‑behoeften.

**Hoe voeg ik een nieuwe grafiek toe aan een dia?**

Om een grafiek toe te voegen, maakt u eerst een instantie van de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑klasse, haalt u de gewenste dia op via de index en roept u vervolgens de methode aan om een grafiek toe te voegen, waarbij u het grafiektype en de initiële gegevens opgeeft. Dit proces integreert de grafiek direct in uw presentatie.

**Hoe kan ik de gegevens in een grafiek bijwerken?**

U kunt de gegevens van een grafiek bijwerken door toegang te krijgen tot de gegevens‑werkmap ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)), standaard series en categorieën te wissen en vervolgens uw eigen gegevens toe te voegen. Hiermee kunt u de grafiek programmatisch vernieuwen zodat deze de nieuwste gegevens weergeeft.

**Is het mogelijk om het uiterlijk van de grafiek aan te passen?**

Ja, Aspose.Slides for .NET biedt uitgebreide aanpassingsmogelijkheden. U kunt kleuren, lettertypen, labels, legenda’s en andere opmaak‑elementen wijzigen om het uiterlijk van de grafiek af te stemmen op uw specifieke ontwerpeisen.

Gerelateerde functie: [Maak bewerkbare grafieken](/slides/nl/features/create-charts/).