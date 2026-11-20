---
title: Grafiekassen aanpassen in presentaties in .NET
linktitle: Grafiekas
type: docs
url: /nl/net/chart-axis/
keywords:
- grafiekas
- verticale as
- horizontale as
- as aanpassen
- as manipuleren
- as beheren
- as eigenschappen
- maximale waarde
- minimale waarde
- aslijn
- datumnotatie
- as titel
- aspositie
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontdek hoe u Aspose.Slides voor .NET kunt gebruiken om grafiekassen in PowerPoint-presentaties aan te passen voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe u grafiekassen kunt aanpassen met Aspose.Slides voor .NET. Het behandelt berekende aswaarden, rijen‑ en kolomomwisseling van grafieken, as‑zichtbaarheid, intervallen voor categorie‑labels en tick‑marks, datumcategorieën en -opmaak, titelrotatie, as‑positionering, weergave‑eenheden en logaritmische schaling.

## **Maximale waarden op de verticale as van grafieken ophalen**

Maak een [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) en voeg een gebiedsgrafiek toe met standaardgegevens. Roep [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) aan voordat u berekende aswaarden uitleest, zodat de grafieklay‑out up‑to‑date is.

Lees [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) en [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) voor de aslimieten, en [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) en [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) voor de tick‑intervallen. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) en [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) leveren tijd‑eenheidsschaal, die relevant is voor datumassen. Het voorbeeld slaat deze waarden op in lokale variabelen en slaat de grafiek op.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
chart.ValidateChartLayout();

var maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
var minValue = chart.Axes.VerticalAxis.ActualMinValue;

var majorUnit = chart.Axes.VerticalAxis.ActualMajorUnit;
var minorUnit = chart.Axes.VerticalAxis.ActualMinorUnit;

var majorUnitScale = chart.Axes.VerticalAxis.ActualMajorUnitScale;
var minorUnitScale = chart.Axes.VerticalAxis.ActualMinorUnitScale;

presentation.Save("AxisValues_out.pptx", SaveFormat.Pptx);
```

## **Gegevens tussen assen verwisselen**

Gebruik [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) om de rollen van series en categorieën in grafiekgegevens om te wisselen. Elke voormalige categorie wordt een serie en elke voormalige serie een categorie. Dit verandert hoe de gegevens worden gegroepeerd; het verwisselt niet de horizontale en verticale assen. Het voorbeeld gebruikt [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) om de standaardgegevens te binden aan `Sheet1!A1:D5`, inclusief de koprij en categoriekolom, vóór het wisselen van rijen en kolommen. Het slaat een grafiek op met vier series en drie categorieën.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

chart.ChartData.SetRange("Sheet1!A1:D5");
chart.ChartData.SwitchRowColumn();

presentation.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
```

## **Volgorde van plotten van een as omkeren**

Gebruik [IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) om een categorie‑ of waardenas om te keren. Bijvoorbeeld, een horizontale staafgrafiek kan projectfasen van boven naar beneden in dezelfde volgorde als het werkblad weergeven: Planning, Ontwikkeling, Testen. Het omkeren van een as verandert de plotrichting; het sorteert of herschikt de werkblad‑gegevens niet. Ter vergelijking verwisselt [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) de rollen van series en categorieën.

Het volgende voorbeeld maakt een horizontale staafgrafiek met drie fasen en één serie. Het slaat een presentatie op met drie dia’s: normale volgorde, omgekeerde categorieën en omgekeerde waarden. Elke kopie gebruikt dezelfde dataset, en op elke kopie wordt één as omgekeerd.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredBar, 50, 40, 620, 320);
chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredBar);
var stages = new[] { "Planning", "Development", "Testing" };
var values = new[] { 10, 30, 20 };
for (var i = 0; i < stages.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, stages[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

// Slide 2: display the first category at the top.
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// Keep the horizontal value axis at the bottom.
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// Slide 3: reverse only the horizontal numeric scale.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

Het omkeren van een as kan ook de loodrechte as naar de tegenovergestelde kant van de plot verplaatsen. [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) bepaalt waar de andere as de geconfigureerde as kruist. In dia 2 houdt het instellen op `Maximum` op de omgekeerde categorias het horizontale waardenas aan de onderkant. Voor een specifiek kruispunt gebruikt u [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Controleer de kruissinstellingen bij het wijzigen van de richting, vooral als de grafiek al een aangepast kruispunt heeft. Zet `IsPlotOrderReversed` terug op `false` om de normale plotrichting te herstellen; kruissinstellingen staan los.

| Normale volgorde (dia 1) | Omgekeerde categorieën (dia 2) | Omgekeerde waarden (dia 3) |
| --- | --- | --- |
| ![Horizontale staafgrafiek met normale categorie‑ en waardenasvolgorde](axis-order-normal.png) | ![Horizontale staafgrafiek met categorieën weergegeven van boven naar beneden](axis-order-categories-reversed.png) | ![Horizontale staafgrafiek met een omgekeerde waardenas en nul aan de rechterkant](axis-order-values-reversed.png) |
| Categorieën lopen van onder naar boven; waarden stijgen van links naar rechts. | Planning, Ontwikkeling en Testen lopen van boven naar beneden. Waarden en werkblad‑rijvolgorde blijven ongewijzigd. | Categorieën behouden hun normale volgorde; waarden stijgen van rechts naar links. De categorias kruist op nul aan de rechterkant. |

## **Verticale as uitschakelen voor lijngrafieken**

Stel [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) in op `false` voor de verticale as om deze te verbergen. Het voorbeeld maakt een lijngrafiek met standaardgegevens en slaat deze op met de verticale as verborgen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.VerticalAxis.IsVisible = false;

presentation.Save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
```

## **Horizontale as uitschakelen voor lijngrafieken**

Stel [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) in op `false` voor de horizontale as om deze te verbergen. Het voorbeeld maakt een lijngrafiek met standaardgegevens en slaat deze op met de horizontale as verborgen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.HorizontalAxis.IsVisible = false;

presentation.Save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
```

## **Rasterlijnen van de grafiek tonen of verbergen**

Lees [ShowMajorGridLines](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/showmajorgridlines/) en [ShowMinorGridLines](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/showminorgridlines/) om te controleren welke rasterlijnen een as weergeeft. Beide eigenschappen zijn read‑only. Gebruik de lijnvulling van [MinorGridLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/minorgridlinesformat/) om minder belangrijke rasterlijnen te tonen of te verbergen. Stel een solide vulling met een zichtbare kleur in om ze te tonen, of gebruik `FillType.NoFill` om ze te verbergen. De overeenkomstige instelling voor hoofd‑rasterlijnen is [MajorGridLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorgridlinesformat/)`.Line.FillFormat`. Het wijzigen van een rasterlijn‑vulling behoudt de as‑zichtbaarheid en tick‑marks.

De verticale as van deze gegroepeerde kolomgrafiek start met hoofd‑rasterlijnen zichtbaar en minder belangrijke rasterlijnen verborgen. Het voorbeeld toont eerst de minder belangrijke rasterlijnen in oranje, verbergt ze daarna opnieuw voordat de presentatie wordt opgeslagen.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
var axis = chart.Axes.VerticalAxis;
Console.WriteLine($"Initial: major={axis.ShowMajorGridLines}, minor={axis.ShowMinorGridLines}");

var minorFill = axis.MinorGridLinesFormat.Line.FillFormat;
minorFill.FillType = FillType.Solid;
minorFill.SolidFillColor.Color = Color.DarkOrange;
Console.WriteLine($"Enabled: minor={axis.ShowMinorGridLines}");

minorFill.FillType = FillType.NoFill;
Console.WriteLine($"Hidden: major={axis.ShowMajorGridLines}, minor={axis.ShowMinorGridLines}");

presentation.Save("ChartGridlines.pptx", SaveFormat.Pptx);
```

| Minder belangrijke rasterlijnen ingeschakeld | Minder belangrijke rasterlijnen verborgen |
| --- | --- |
| ![Oranje minder belangrijke rasterlijnen tussen de hoofd‑rasterlijnen op de verticale as](minor-gridlines-enabled.png) | ![Dezelfde kolomgrafiek met alleen de hoofd‑rasterlijnen zichtbaar](minor-gridlines-hidden.png) |

## **Categorieas wijzigen**

Stel [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) in om een datum‑ of tekst‑categorieas te kiezen. Dit voorbeeld vereist `ExistingChart.pptx`, met een grafiek als het eerste object op de eerste dia en categoriecellen die numerieke Excel‑datumnummers bevatten. Het verandert de horizontale as in een datumas. Het instellen van [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) op `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) op `1` en [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) op maanden plaatst hoofd‑ticks op intervallen van één maand.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

var chart = (IChart) slide.Shapes[0];
chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
chart.Axes.HorizontalAxis.MajorUnit = 1;
chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
```

### **Het type categorieas bepalen op basis van gegevens**

Roep [SetCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/setcategoryaxistypeautomatically/) aan na het vullen van de categorieën, lees vervolgens [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/categoryaxistype/) om de selectie te inspecteren. Dit is nuttig wanneer dezelfde grafiek ofwel tekst‑labels ofwel numerieke datums ontvangt. De methode bepaalt het type op het moment van aanroep; het activeert geen persistente modus die later gewijzigde gegevens opnieuw evalueert. Roep het opnieuw aan nadat de categorieën zijn vervangen.

Het volgende voorbeeld maakt een grafiek met tekstcategorieën en print `Text`. Vervolgens vervangt het de categoriecelfwaarden door datums en roept de methode opnieuw aan, die `Date` print. Datums worden opgeslagen als numerieke OLE‑Automation‑waarden die worden geretourneerd door [DateTime.ToOADate](https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tooadate), niet als datum‑strings. [CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/customnumberformat/) bepaalt hoe die waarden worden weergegeven; het converteert geen tekst naar numerieke datums. Voor meer over categoriecellen, zie [Chart Workbook](/slides/nl/net/chart-workbook/).

Gebruik automatische bepaling wanneer bekend is dat de invoer tekstcategorieën of numerieke datums bevat, zoals in dit voorbeeld. Voor gewone numerieke labels, gemengde categorieën of lege gegevens, stel expliciet [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/categoryaxistype/) in op de beoogde betekenis. Alleen numerieke waarden vormen niet automatisch een datumas.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var seriesName = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);
var labels = new[] { "First", "Second", "Third" };

for (var i = 0; i < labels.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, labels[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, (i + 1) * 10);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.SetCategoryAxisTypeAutomatically();
Console.WriteLine(axis.CategoryAxisType); // Tekst

var dates = new[] { new DateTime(2026, 1, 1), new DateTime(2026, 1, 2), new DateTime(2026, 2, 1) };

for (var i = 0; i < dates.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0);
    categoryCell.Value = dates[i].ToOADate();
    categoryCell.CustomNumberFormat = "yyyy-mm-dd";
}

axis.SetCategoryAxisTypeAutomatically();
Console.WriteLine(axis.CategoryAxisType); // Datum

presentation.Save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
```

## **Intervallen voor categorieas‑labels beheren**

Wanneer een grafiek veel categorieën heeft, kunt u het aantal zichtbare as‑labels verminderen zonder categorieën of datapunten te verwijderen. Stel [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) in op `false`, en stel vervolgens [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) in op het gewenste categorie‑interval. Voor tekstcategorieën in hun normale volgorde begint de telling bij de eerste categorie:

| Interval | Labels die in het voorbeeld worden weergegeven |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

Een interval van `3` toont elke derde label, waarbij twee labels verborgen blijven tussen de weergegeven labels. Het verwijdert de bijbehorende kolommen niet. Automatische spatiëring kiest een interval op basis van de beschikbare ruimte; het toont niet noodzakelijk elke label.

Tick‑marks hebben aparte besturingen. Stel [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) in op `false` en gebruik [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) om hun interval in te stellen. Bijvoorbeeld, `1` behoudt een tick‑mark bij elk categorie‑interval terwijl de labels alleen elke derde categorie verschijnen. Stel [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) in op een zichtbare stijl zodat u het resultaat kunt zien. Het terugzetten van een automatische‑spatiërings‑eigenschap naar `true` laat de grafiek het interval opnieuw kiezen.

Het volgende zelf‑containende voorbeeld maakt 24 categorieën en één serie, en slaat drie dia’s op in `CategoryAxisIntervals.pptx`: automatische spatiëring, handmatige label‑spatiëring met onafhankelijke tick‑marks, en herstelde automatische spatiëring. De twee kopieën behouden de oorspronkelijke grafiekgegevens. Geen invoer‑presentatie is vereist. Horizontale labeltekst maakt het verschil in dichtheid gemakkelijk zichtbaar.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.HasLegend = false;
chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredColumn);
for (var i = 0; i < 24; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, 10 + i % 6 * 5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.CategoryAxisType = CategoryAxisType.Text;
axis.TextFormat.TextBlockFormat.RotationAngle = 0;
axis.TextFormat.PortionFormat.FontHeight = 12;
axis.MajorTickMark = TickMarkType.Outside;
axis.IsAutomaticTickLabelSpacing = true;
axis.IsAutomaticTickMarksSpacing = true;

// Dia 2: toon elke derde label, maar behoud een tick‑mark voor elke categorie.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Dia 3: laat de grafiek beide intervallen opnieuw kiezen.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**Automatische spatiëring (dia 1):** In deze weergave wordt elke tweede categorielabel weergegeven en wordt deze over twee regels verdeeld. Het automatische resultaat kan variëren afhankelijk van grafiekgrootte, lettertypen en de renderer.

![Automatische categorie‑labelspatiëring met alle 24 kolommen zichtbaar](category-axis-automatic.png)

**Handmatige spatiëring (dia 2):** Elke derde label wordt op één regel weergegeven, terwijl tick‑marks behouden blijven bij elk categorie‑interval. Alle 24 kolommen, inclusief die zonder label, blijven zichtbaar met dezelfde waarden. Dia 3 herstelt de automatische opmaak zoals hierboven getoond.

![Handmatige categorie‑labelinterval van drie met alle 24 kolommen zichtbaar](category-axis-manual.png)

### **Kies de juiste as en interval**

Gebruik dit categorie‑aantal‑interval voor een tekst‑categorieas, zoals de categorias van een kolom‑, lijn‑, gebied‑ of staafgrafiek. In een kolomgrafiek is het de horizontale as. In een horizontale staafgrafiek is de categorias verticaal, dus pas deze instellingen toe op [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Tick‑mark‑spatiëring geldt ook voor een serie‑as in grafieken die er één hebben.

Gebruik geen categorie‑labelspatiëring om de numerieke schaal van een waardenas in te stellen. Op een waardenas bepaalt [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) een verschil in waarden: bijvoorbeeld, een hoofd‑eenheid van `10` produceert ticks op 0, 10, 20, enzovoort wanneer de as op nul start. Een categorie‑label‑interval van `3` telt juist categorie‑posities, ongeacht hun datawaarden. Spreidings‑ en bubbelsgrafieken gebruiken waardassen in plaats van een tekst‑categorieas. Voor een datumas gebruikt u tijd‑gebaseerde hoofd‑eenheden en schalen zoals beschreven in [Categorieas wijzigen](#categorieas-wijzigen).

## **Datumnotatie voor categorieas‑waarden instellen**

Het voorbeeld vervangt de standaardgrafiekgegevens door vier jaarlijkse waarden. Datums worden opgeslagen als OLE‑Automation‑serienummers in het eerste werkblad (index `0`). Stel [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) in op een datumas, schakel [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) uit, en wijs `yyyy` toe aan [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) zodat de categorielabels viercijferige jaartallen tonen, onafhankelijk van de celopmaak.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
for (var i = 0; i < 4; i++)
{
    var date = new DateTime(2015 + i, 1, 1);
    var categoryCell = workbook.GetCell(0, i + 1, 0, date.ToOADate());
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, i + 1);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.HorizontalAxis.NumberFormat = "yyyy";

presentation.Save("DateAxisFormat.pptx", SaveFormat.Pptx);
```

## **Rotatiehoek voor een as‑titel instellen**

Schakel [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) in op de verticale as, voorzie een titeltekst, en stel [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) in om de titel te roteren. De hoek wordt gemeten in graden; dit voorbeeld slaat een kolomgrafiek op met de waardenas‑titel geroteerd met 90 graden.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Value");
chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

presentation.Save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
```

## **As‑positie instellen op een categorie‑ of waardenas**

Gebruik [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) om te bepalen of de waardenas de categorias kruist tussen categorieën of op categorie‑tick‑marks. Deze eigenschap geldt voor categorieassen. Het voorbeeld stelt dit in op `true` voor de horizontale categorias van een kolomgrafiek en slaat het resultaat op.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

presentation.Save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
```

## **Weergave‑eenheid op een waardenas instellen**

Stel [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) in om de labels op een waardenas te schalen zonder de onderliggende gegevens te wijzigen. Met [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) ingesteld op `Millions` wordt een waarde van 60 000 000 weergegeven als 60. Het voorbeeld maakt een kolomgrafiek en past de miljoenen‑weergave‑eenheid toe op de verticale as.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

## **Logaritmische waardenas configureren**

Een logaritmische waardenas is nuttig wanneer positieve waarden zich over meerdere grootheidsordes uitstrekken. Bijvoorbeeld, een dienst kan 10, 100, 1 000, 10 000 en 100 000 verzoeken ontvangen over vijf perioden. Op een lineaire schaal staan de kleinere waarden dicht bij nul. Een logaritmische schaal maakt de relatieve groei beter vergelijkbaar: gelijke afstanden staan voor gelijke verhoudingen in plaats van gelijke verschillen.

Stel [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) in op `true` voor de waardenas en gebruik [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) om de basis te kiezen. Dit wijzigt hoe bestaande waarden worden weergegeven; het wijzigt de gegevens niet en voegt geen logaritmische trendlijn toe. Een trendlijn vertegenwoordigt een aangepaste relatie in de gegevens en is een afzonderlijke functie.

### **Waardenas en basis kiezen**

Voor een lijn‑ of kolomgrafiek is de waardenas [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Voor een horizontale staafgrafiek is het [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). Spreidings‑ en bubbelsgrafieken hebben twee waardassen, dus kies de horizontale as voor X‑waarden, de verticale as voor Y‑waarden, of beide. Pas geen logaritmische schaal toe op een categorias.

De standaardlogaritmische basis is `10`. Voor PPTX‑grafieken mag de basis liggen tussen `2` en `1000`, inclusief; breukdelen zoals `2.5` worden ook ondersteund. Met basis `10` zijn opvolgende machten zoals 10, 100, 1 000 en 10 000 gelijkmatig gespreid.

### **Lineaire en logaritmische schaal vergelijken**

Het volgende zelf‑containende voorbeeld maakt een lijngrafiek met de vijf aantallen verzoeken op de eerste dia, kloont die dia vervolgens en schakelt op de tweede een logaritmische waardenas met basis 10 in. Beide dia’s behouden dezelfde gegevens.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 30, 40, 660, 200);

chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
var values = new double[] { 10, 100, 1000, 10000, 100000 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Period {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Behoud de eerste dia lineair en wijzig alleen de schaal van de waardenas van de kopie.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Lineaire schaal (dia 1):** Gelijke verticale afstanden staan voor gelijke verschillen in het aantal verzoeken. De grootste waarde domineert de grafiek, waardoor de kleinere waarden moeilijk te onderscheiden zijn.

![Lijngrafiek in PowerPoint met vijf verzoekaantallen op een lineaire waardenas](value-axis-linear.png)

**Logaritmische schaal (dia 2):** Gelijke verticale afstanden staan voor gelijke verhoudingen. Elke periode heeft tien keer zoveel verzoeken als de vorige, waardoor de punten een rechte stijgende lijn vormen op de basis‑10‑schaal. De as‑labels tonen nog steeds de oorspronkelijke verzoekaantallen.

![Dezelfde vijf verzoekaantallen in PowerPoint op een logaritmische waardenas met basis 10](value-axis-logarithmic.png)

### **Omgaan met nul‑ en negatieve waarden**

Een logaritmische schaal kan alleen strikt positieve waarden weergeven. Controleer de gegevens vóór activering. Als nul of negatieve waarden betekenisvol zijn, behoud dan een lineaire schaal of toon ze apart. Als het weglaten van die waarden passend is voor de analyse, leg dan de uitsluiting uit. Vervang ze niet stilzwijgend door kleine positieve getallen, want dat verandert de betekenis van de gegevens. Elke handmatig ingestelde minimum‑ of maximumwaarde voor een logaritmische as moet eveneens positief zijn.

## **FAQ**

**Hoe stel ik de waarde in waarop één as de andere kruist (as‑kruising)?**

Gebruik [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) om het kruispuntgedrag te selecteren. Om een numerieke kruiswaarde op te geven, stel [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) in. Deze instellingen laten u de as‑kruising naar een geschikte basislijn verplaatsen.

**Hoe kan ik tick‑labels positioneren ten opzichte van de as?**

Stel [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) in via [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` of `None`. Om de tick‑marks zelf te regelen, gebruik [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) of [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); deze staan los van de label‑positionering.