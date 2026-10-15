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
- as-eigenschappen
- maximale waarde
- minimale waarde
- aslijn
- datumnotatie
- as titel
- as positie
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontdek hoe u Aspose.Slides voor .NET kunt gebruiken om grafiekassen aan te passen in PowerPoint-presentaties voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe je grafiekassen kunt aanpassen met Aspose.Slides voor .NET. Het behandelt berekende aswaarden, het verwisselen van rijen en kolommen in een grafiek, aszichtbaarheid, categorie‑label‑ en tik‑markering‑intervallen, datumcategorieën en -opmaak, titelrotatie, aspositionering, weergave‑eenheden en logaritmische schaling.

## **Verkrijg de maximale waarden op de verticale as in grafieken**

Maak een [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) en voeg een gebiedsgrafiek met standaardgegevens toe. Roep [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) aan voordat je berekende aswaarden uitleest zodat de grafieklay-out up‑to‑date is.

Lees [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) en [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) uit voor de aslimieten, en [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) en [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) voor de tik‑intervallen. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) en [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) bieden tijd‑eenheid‑schalen, die relevant zijn voor datumassen. Het voorbeeld slaat deze waarden op in lokale variabelen en slaat de grafiek op.

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

## **Gegevens tussen assen omwisselen**

Gebruik [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) om de rollen van series en categorieën in grafiekgegevens om te wisselen. Elke voormalige categorie wordt een serie, en elke voormalige serie wordt een categorie. Dit verandert hoe de gegevens worden gegroepeerd; het wisselt niet de horizontale en verticale assen uit. Het voorbeeld gebruikt [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) om de standaardgegevens te binden aan `Sheet1!A1:D5`, inclusief de koprij en categoriekolom, vóór het verwisselen van rijen en kolommen. Het slaat een grafiek op met vier series en drie categorieën.

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

## **Omgekeerde plotvolgorde van een as**

Gebruik [IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) om een categorie‑ of waardenas om te keren. Bijvoorbeeld, een horizontale staafgrafiek kan projectfasen tonen van boven naar beneden in dezelfde volgorde als het werkblad: Planning, Ontwikkeling, Testen. Het omkeren van een as verandert de plotrichting; het sorteert of herschikt de werkboekgegevens niet. Ter vergelijking wisselt [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) de rollen van series en categorieën.

Het volgende voorbeeld maakt een horizontale staafgrafiek met drie fasen en één serie. Het slaat een presentatie op met drie dia's: normale volgorde, omgekeerde categorieën en omgekeerde waarden. Elke kopie gebruikt dezelfde gegevensset, en slechts één as wordt per kopie omgekeerd.

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

// Dia 2: toon de eerste categorie bovenaan.
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// Houd de horizontale waardenas onderaan.
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// Dia 3: keer alleen de horizontale numerieke schaal om.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

Het omkeren van een as kan ook de loodrechte as naar de tegenovergestelde kant van de plot verplaatsen. [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) bepaalt waar de andere as de geconfigureerde as kruist. In dia 2 houdt het instellen op `Maximum` op de omgekeerde categorie‑as de horizontale waardenas onderaan. Voor een specifiek kruispunt gebruik je [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Controleer de kruispersinstellingen bij het veranderen van de richting, vooral als de grafiek al een aangepaste kruispositie heeft. Stel `IsPlotOrderReversed` terug in op `false` om de normale plotrichting te herstellen; kruispersinstellingen zijn gescheiden.

| Normale volgorde (dia 1) | Omgekeerde categorieën (dia 2) | Omgekeerde waarden (dia 3) |
| --- | --- | --- |
| ![Horizontale staafgrafiek met normale categorie‑ en waardenasvolgorde](axis-order-normal.png) | ![Horizontale staafgrafiek met categorieën weergegeven van boven naar beneden](axis-order-categories-reversed.png) | ![Horizontale staafgrafiek met een omgekeerde waardenas en nul aan de rechterkant](axis-order-values-reversed.png) |
| Categorieën lopen van onder naar boven; waarden nemen toe van links naar rechts. | Planning, Ontwikkeling en Testen lopen van boven naar beneden. Waarden en werkboekrijvolgorde blijven ongewijzigd. | Categorieën behouden hun normale volgorde; waarden nemen toe van rechts naar links. De categorie‑as kruist op nul aan de rechterkant. |

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

## **Een categorie‑as wijzigen**

Stel [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) in om een datum‑ of tekstcategorie‑as te kiezen. Dit voorbeeld vereist `ExistingChart.pptx`, met een grafiek als het eerste object op de eerste dia en categoriecellen die numerieke Excel‑datums bevatten. Het wijzigt de horizontale as naar een datum‑as. Het instellen van [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) op `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) op `1` en [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) op maanden plaatst grote tikken op één‑maand intervallen.

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

## **Intervallen voor categorie‑as‑labels beheersen**

Wanneer een grafiek veel categorieën heeft, kun je het aantal zichtbare as‑labels verminderen zonder categorieën of gegevenspunten te verwijderen. Stel [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) in op `false`, en stel vervolgens [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) in op het gewenste categorie‑interval. Voor tekstcategorieën in hun normale volgorde begint de telling bij de eerste categorie:

| Interval | In het voorbeeld weergegeven labels |
| --- | --- |
| `1` | Categorie 1, Categorie 2, Categorie 3, ... Categorie 24 |
| `2` | Categorie 1, Categorie 3, Categorie 5, ... Categorie 23 |
| `3` | Categorie 1, Categorie 4, Categorie 7, ... Categorie 22 |

Een interval van `3` toont elk derde label, waarbij twee labels verborgen blijven tussen de weergegeven labels. Het verwijdert de bijbehorende kolommen niet. Automatische afstand kiest een interval op basis van de beschikbare ruimte; het toont niet per se elk label.

Tik‑markeringen hebben aparte instellingen. Stel [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) in op `false` en gebruik [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) om hun interval in te stellen. Bijvoorbeeld, `1` houdt een tik‑markering bij elk categorie‑interval, terwijl labels alleen elke derde categorie verschijnen. Stel [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) in op een zichtbaar type zodat je het resultaat kunt zien. Het terugzetten van een van de automatische‑afstand‑eigenschappen op `true` laat de grafiek het interval opnieuw kiezen.

Het volgende zelfstandige voorbeeld maakt 24 categorieën en één serie, en slaat vervolgens drie dia's op in `CategoryAxisIntervals.pptx`: automatische afstand, handmatige labelafstand met onafhankelijke tik‑markeringen, en herstelde automatische afstand. De twee kopieën behouden de oorspronkelijke grafiekgegevens. Er is geen invoerpresentatie vereist. Horizontale labeltekst maakt het dichtheidsverschil goed zichtbaar.

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

// Dia 2: toon elke derde label, maar behoud een tikmarkering voor elke categorie.
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

**Automatische afstand (dia 1):** In deze weergave wordt elk tweede categorielabel weergegeven en wordt het over twee regels weergegeven. Het automatische resultaat kan variëren met grafiekgrootte, lettertypen en de renderer.

![Automatische categorie‑labelafstand met alle 24 kolommen zichtbaar](category-axis-automatic.png)

**Handmatige afstand (dia 2):** Elk derde label wordt op één regel weergegeven, terwijl tik‑markeringen bij elk categorie‑interval blijven. Alle 24 kolommen, inclusief die zonder labels, blijven zichtbaar met dezelfde waarden. Dia 3 herstelt de bovenstaande automatische weergave.

![Handmatige categorie‑labelinterval van drie met alle 24 kolommen zichtbaar](category-axis-manual.png)

### **Kies de juiste as en interval**

Gebruik dit categorie‑aantal‑interval voor een tekstcategorie‑as, zoals de categorie‑as van een kolom‑, lijn‑, gebieds‑ of staafgrafiek. In een kolomgrafiek is dit de horizontale as. In een horizontale staafgrafiek is de categorie‑as verticaal, dus pas deze instellingen toe op [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). De tik‑markering‑afstand geldt ook voor een serie‑as in grafieken die er één hebben.

Gebruik de categorie‑labelafstand niet om de numerieke schaal van een waardenas in te stellen. Op een waardenas specificeert [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) een verschil in waarden: bijvoorbeeld, een grote eenheid van `10` geeft tikken op 0, 10, 20, enz., wanneer de as bij nul begint. Een categorie‑labelinterval van `3` telt in plaats daarvan categorieposities, ongeacht hun gegevenswaarden. Spreidings‑ en bolgrafieken gebruiken waardassen in plaats van een tekstcategorie‑as. Voor een datum‑as gebruik je tijd‑gebaseerde grote eenheden en schalen zoals beschreven in [Change a Category Axis](#change-a-category-axis).

## **Datumnotatie instellen voor categorie‑as‑waarden**

Het voorbeeld vervangt de standaard grafiekgegevens door vier jaarlijkse waarden. Datums worden opgeslagen als OLE‑Automation‑serienummers in het eerste werkblad (index `0`). Stel [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) in op een datum‑as, schakel [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) uit, en wijs `yyyy` toe aan [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) zodat de categorie‑labels viercijferige jaartallen tonen, onafhankelijk van de celopmaak.

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

## **Rotatiehoek instellen voor een grafiekas‑titel**

Schakel [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) in op de verticale as, geef de titeltekst op, en stel [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) in om de titel te draaien. De hoek wordt gemeten in graden; dit voorbeeld slaat een kolomgrafiek op met de waardenas‑titel gedraaid met 90 graden.

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

## **Aspositie instellen op een categorie‑ of waardenas**

Gebruik [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) om te bepalen of de waardenas de categorie‑as kruist tussen categorieën of op categorie‑tikmarkeringen. Deze eigenschap geldt voor categorie‑assen. Het voorbeeld stelt deze in op `true` voor de horizontale categorie‑as van een kolomgrafiek en slaat het resultaat op.

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

## **Weergave‑eenheid instellen op een waardenas van een grafiek**

Stel [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) in om de labels op een waardenas te schalen zonder de onderliggende gegevens te wijzigen. Met [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) ingesteld op `Millions` wordt een waarde van 60.000.000 weergegeven als 60. Het voorbeeld maakt een kolomgrafiek en past de miljoenen‑weergave‑eenheid toe op de verticale as.

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

Een logaritmische waardenas is handig wanneer positieve waarden zich over meerdere machten van tien uitstrekken. Bijvoorbeeld, een dienst kan 10, 100, 1.000, 10.000 en 100.000 verzoeken ontvangen over vijf perioden. Op een lineaire schaal staan de kleinere waarden dicht bij elkaar rond nul. Een logaritmische schaal maakt hun relatieve groei beter vergelijkbaar: gelijke afstanden vertegenwoordigen gelijke verhoudingen in plaats van gelijke verschillen.

Stel [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) in op `true` voor de waardenas en gebruik [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) om de basis te kiezen. Dit verandert hoe de bestaande waarden worden weergegeven; het wijzigt de gegevens niet of voegt een logaritmische trendlijn toe. Een trendlijn vertegenwoordigt een passende relatie in de gegevens en is een afzonderlijke functie.

### **Kies de waardenas en basis**

Voor een lijn‑ of kolomgrafiek is de waardenas [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Voor een horizontale staafgrafiek is dit [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). Spreidings‑ en bolgrafieken hebben twee waardassen, kies dus de horizontale as voor X‑waarden, de verticale as voor Y‑waarden, of beide. Pas geen logaritmische schaling toe op een categorie‑as.

De standaard logaritmische basis is `10`. Voor PPTX‑grafieken gebruik je een basis van `2` tot en met `1000`, inclusief; fractionele bases zoals `2,5` worden ook ondersteund. Met basis `10` zijn opeenvolgende machten zoals 10, 100, 1.000 en 10.000 gelijkmatig verdeeld.

### **Lineaire en logaritmische schaal vergelijken**

Het volgende zelfstandige voorbeeld maakt een lijngrafiek met de vijf verzoekaantallen op de eerste dia, kloont vervolgens die dia en schakelt een logaritmische waardenas met basis 10 in op de tweede. Beide dia's behouden dezelfde gegevens.

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

// Bewaar de eerste dia lineair en wijzig alleen de schaal van de waardenas van de kopie.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Lineaire schaal (dia 1):** Gelijke verticale afstanden vertegenwoordigen gelijke verschillen in verzoekaantallen. De grootste waarde domineert de grafiek, waardoor de kleinere waarden moeilijk te onderscheiden zijn.

![Lijngrafiek in PowerPoint die vijf verzoekaantallen toont op een lineaire waardenas](value-axis-linear.png)

**Logaritmische schaal (dia 2):** Gelijke verticale afstanden vertegenwoordigen gelijke verhoudingen. Elke periode heeft tien keer zoveel verzoeken als de vorige, waardoor de punten een rechte stijgende lijn vormen op de basis‑10 schaal. De as‑labels tonen nog steeds de oorspronkelijke verzoekaantallen.

![Dezelfde vijf verzoekaantallen in PowerPoint op een logaritmische waardenas met basis 10](value-axis-logarithmic.png)

### **Omgaan met nul en negatieve waarden**

Een logaritmische schaal kan alleen strikt positieve waarden weergeven. Controleer de gegevens voordat je deze inschakelt. Als nul of negatieve waarden betekenis hebben, behoud dan een lineaire schaal of toon ze apart. Als het weglaten van die waarden geschikt is voor de analyse, leg dan de omissie uit. Vervang ze niet stilletjes door kleine positieve getallen, want dat verandert de betekenis van de gegevens. Elke handmatig geconfigureerde minimum‑ of maximum‑waarde voor een logaritmische as moet ook positief zijn.

## **FAQ**

**Hoe stel ik de waarde in waarop één as de andere kruist (as‑kruising)?**

Gebruik [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) om het kruisgedrag te selecteren. Om een numerieke kruiswaarde op te geven, stel je [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) in. Deze instellingen laten je de as‑kruising naar een geschikte basislijn verplaatsen.

**Hoe kan ik tick‑labels positioneren ten opzichte van de as?**

Stel [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) in met behulp van [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` of `None`. Om de tik‑markeringen zelf te regelen, gebruik je [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) of [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); deze staan los van de labelpositionering.