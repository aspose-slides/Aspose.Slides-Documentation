---
title: Anpassa diagramaxlar i presentationer i .NET
linktitle: Diagramaxel
type: docs
url: /sv/net/chart-axis/
keywords:
- diagramaxel
- vertikal axel
- horisontell axel
- anpassa axel
- manipulera axel
- hantera axel
- axelegenskaper
- maxvärde
- minvärde
- axellinje
- datumformat
- axeltitel
- axelposition
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Upptäck hur du använder Aspose.Slides för .NET för att anpassa diagramaxlar i PowerPoint-presentationer för rapporter och visualiseringar."
---
## **Översikt**

Den här artikeln förklarar hur du anpassar diagramaxlar med Aspose.Slides för .NET. Den täcker beräknade axiella värden, byte av diagramrader och -kolumner, axelns synlighet, kategori‑etikett‑ och stapel‑intervall, datumkategorier och formatering, titelrotation, axelpositionering, visningsenheter och logaritmisk skalning.

## **Hämta maxvärden på den vertikala axeln i diagram**

Skapa en [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) och lägg till ett områdesdiagram med standarddata. Anropa [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) innan du läser beräknade axiella värden så att diagrammets layout är uppdaterad.

Läs [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) och [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) för axelgränserna, samt [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) och [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) för stapelintervallen. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) och [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) tillhandahåller tidsenhetsskalor som är relevanta för datumaxlar. Exemplet lagrar dessa värden i lokala variabler och sparar diagrammet.

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

## **Byt data mellan axlarna**

Använd [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) för att byta rollerna för serier och kategorier i diagramdata. Varje tidigare kategori blir en serie, och varje tidigare serie blir en kategori. Detta ändrar hur data grupperas; det byter inte de horisontella och vertikala axlarna. Exemplet använder [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) för att binda standarddata till `Sheet1!A1:D5`, inklusive rubrikraden och kategori‑kolumnen, innan rader och kolumner växlas. Det sparar ett diagram med fyra serier och tre kategorier.

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

## **Omvänd plotningsordning för en axel**

Använd [IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) för att vända en kategori‑ eller värdeaxel. Till exempel kan ett horisontellt stapeldiagram visa projektfaser från topp till botten i samma ordning som kalkylbladet: Planering, Utveckling, Testning. Att vända en axel ändrar plottningsriktningen; det sorterar inte eller omorganiserar kalkylbladsdata. Till jämförelse byter [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) rollerna för serier och kategorier.

Följande exempel skapar ett horisontellt stapeldiagram med tre faser och en serie. Det sparar en presentation med tre bilder: normal ordning, omvända kategorier och omvända värden. Varje kopia använder samma dataset, och endast en axel är omvänd i varje kopia.

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

// Bild 2: visa den första kategorin högst upp.
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// Behåll den horisontella värdeaxeln längst ner.
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// Bild 3: vänd endast den horisontella numeriska skalan.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

Att vända en axel kan också flytta den vinkelräta axeln till motsatt sida av diagrammet. [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) styr var den andra axeln korsar den axel som konfigureras. På bild 2 håller inställningen `Maximum` på den omvända kategori‑axeln den horisontella värdeaxeln längst ner. För en specifik korsningspunkt, använd [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Kontrollera korsningsinställningarna när du ändrar riktning, särskilt om diagrammet redan har en anpassad korsningspunkt. Sätt `IsPlotOrderReversed` tillbaka till `false` för att återställa normal plottningsriktning; korsningsinställningarna är separata.

| Normal ordning (bild 1) | Omvända kategorier (bild 2) | Omvända värden (bild 3) |
| --- | --- | --- |
| ![Horisontellt stapeldiagram med normal kategori‑ och värdeaxelordning](axis-order-normal.png) | ![Horisontellt stapeldiagram med kategorier visade från topp till botten](axis-order-categories-reversed.png) | ![Horisontellt stapeldiagram med omvänd värdeaxel och noll på höger sida](axis-order-values-reversed.png) |
| Kategorier löper från botten till toppen; värden ökar från vänster till höger. | Planering, Utveckling och Testning löper från topp till botten. Värden och kalkylbladsradordning förblir oförändrade. | Kategorier behåller sin normalordning; värden ökar från höger till vänster. Kategori‑axeln korsar vid noll på höger sida. |

## **Inaktivera den vertikala axeln för linjediagram**

Sätt [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) till `false` på den vertikala axeln för att dölja den. Exemplet skapar ett linjediagram med standarddata och sparar det med den vertikala axeln dold.

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

## **Inaktivera den horisontella axeln för linjediagram**

Sätt [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) till `false` på den horisontella axeln för att dölja den. Exemplet skapar ett linjediagram med standarddata och sparar det med den horisontella axeln dold.

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

## **Ändra en kategori‑axel**

Ställ in [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) för att välja en datum‑ eller textkategori‑axel. Detta exempel kräver `ExistingChart.pptx`, med ett diagram som den första formen på den första bilden och kategori‑celler som innehåller numeriska Excel‑datumvärden. Det ändrar den horisontella axeln till en datumaxel. Genom att sätta [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) till `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) till `1` och [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) till månader placeras huvudstaplar med en‑månad intervall.

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

## **Styr intervaller för kategori‑axelns etiketter**

När ett diagram har många kategorier, minska antalet synliga axel‑etiketter utan att ta bort kategorier eller datapunkter. Sätt [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) till `false`, och sätt sedan [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) till önskat kategoriintervall. För textkategorier i deras normala ordning börjar räknandet vid den första kategorin:

| Intervall | Etiketter som visas i exemplet |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

Ett intervall på `3` visar var tredje etikett och lämnar två etiketter dolda mellan de visade. Det tar inte bort motsvarande kolumner. Automatisk spacing väljer ett intervall baserat på tillgängligt utrymme; det visar inte nödvändigtvis varje etikett.

Streckmarkeringar har separata kontroller. Sätt [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) till `false` och använd [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) för att ange deras intervall. Till exempel behåller `1` en streckmarkering vid varje kategoriintervall medan etiketter bara visas var tredje kategori. Ställ in [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) till en synlig stil så att du kan se resultatet. Att sätta någon av de automatiska spacing‑egenskaperna tillbaka till `true` låter diagrammet välja det intervallet igen.

Följande fristående exempel skapar 24 kategorier och en serie, och sparar sedan tre bilder i `CategoryAxisIntervals.pptx`: automatisk spacing, manuell etikettspacing med oberoende streckmarkeringar, och återställd automatisk spacing. De två kopiorna behåller de ursprungliga diagramdata. Ingen inmatningspresentation krävs. Horisontell etiketttext gör skillnaden i täthet lätt att se.

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

// Bild 2: visa var tredje etikett, men behåll en streckmarkering för varje kategori.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Bild 3: låt diagrammet välja båda intervallen igen.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**Automatisk spacing (bild 1):** I denna rendering visas varje andra kategori‑etikett och radbryts till två rader. Det automatiska resultatet kan variera med diagramstorlek, typsnitt och renderaren.

![Automatisk kategori‑etikettspacing med alla 24 kolumner synliga](category-axis-automatic.png)

**Manuell spacing (bild 2):** Var tredje etikett visas på en rad, medan streckmarkeringar förblir vid varje kategoriintervall. Alla 24 kolumner, inklusive de utan etiketter, förblir synliga med samma värden. Bild 3 återställer den automatiska utseendet som visas ovan.

![Manuellt kategori‑etikettintervall på tre med alla 24 kolumner synliga](category-axis-manual.png)

### **Välj rätt axel och intervall**

Använd detta kategori‑antal intervall för en text‑kategori‑axel, såsom kategori‑axeln i ett kolumn-, linje-, area- eller stapeldiagram. I ett kolumndiagram är det den horisontella axeln. I ett horisontellt stapeldiagram är kategori‑axeln vertikal, så tillämpa dessa inställningar på [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Stapel‑spacing gäller även för en serie‑axel i diagram som har en.

Använd inte kategori‑etikettspacing för att ange den numeriska skalan på en värdeaxel. På en värdeaxel anger [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) en skillnad i värden: exempelvis ger en huvudenhet på `10` staplar vid 0, 10, 20 osv när axeln startar vid noll. Ett kategori‑etikettintervall på `3` räknar istället kategori‑positioner, oavsett deras datavärden. Spridnings‑ och bubbeldiagram använder värdeaxlar snarare än en text‑kategori‑axel. För en datumaxel, använd tidsbaserade huvudenheter och skalor som beskrivs i [Ändra en kategori‑axel](#change-a-category-axis).

## **Ställ in datumformat för kategori‑axelvärden**

Exemplet ersätter standarddiagramdata med fyra årliga värden. Datum lagras som OLE‑Automation‑serienummer i det första arbetsbladet (index `0`). Ställ in [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) till en datumaxel, inaktivera [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/), och tilldela `yyyy` till [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) så att kategori‑etiketterna visar fyrsiffriga år oberoende av cellformateringen.

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

## **Ställ in en rotationsvinkel för en diagramaxeltitel**

Aktivera [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) på den vertikala axeln, ange titeltext, och sätt [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) för att rotera titeln. Vinkeln mäts i grader; detta exempel sparar ett kolumndiagram med dess värdeaxeltitel roterad 90 grader.

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

## **Ställ in axelposition på en kategori‑ eller värdeaxel**

Använd [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) för att styra om värdeaxeln korsar kategori‑axeln mellan kategorier eller vid kategori‑staplar. Denna egenskap gäller kategori‑axlar. Exemplet sätter den till `true` på den horisontella kategori‑axeln i ett kolumndiagram och sparar resultatet.

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

## **Ställ in visningsenheten på en diagramvärdeaxel**

Ställ in [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) för att skala etiketter på en värdeaxel utan att ändra underliggande data. Med [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) satt till `Millions` visas ett värde på 60 000 000 som 60. Exemplet skapar ett kolumndiagram och tillämpar miljon‑visningsenheten på dess vertikala axel.

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

## **Konfigurera en logaritmisk värdeaxel**

En logaritmisk värdeaxel är användbar när positiva värden sträcker sig över flera storleksordningar. Till exempel kan en tjänst ta emot 10, 100, 1 000, 10 000 och 100 000 förfrågningar över fem perioder. På en linjär skala visar de mindre värdena sig nära varandra nära noll. En logaritmisk skala gör deras relativa tillväxt enklare att jämföra: lika avstånd motsvarar lika förhållanden snarare än lika skillnader.

Sätt [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) till `true` på värdeaxeln och använd [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) för att välja basen. Detta ändrar hur befintliga värden visas; det ändrar inte data eller lägger till en logaritmisk trendlinje. En trendlinje representerar ett anpassat samband i data och är en separat funktion.

### **Välj värdeaxeln och basen**

För ett linje‑ eller kolumndiagram är värdeaxeln [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). För ett horisontellt stapeldiagram är den [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). Spridnings‑ och bubbeldiagram har två värdeaxlar, så välj den horisontella axeln för X‑värden, den vertikala för Y‑värden, eller båda. Applicera inte logaritmisk skalning på en kategori‑axel.

Standardlogaritmbasen är `10`. För PPTX‑diagram, använd en bas från `2` till `1000`, inclusive; bråktalsbaser som `2.5` stöds också. Med bas `10` är på varandra följande potenser som 10, 100, 1 000 och 10 000 lika avstånd.

### **Jämför linjär och logaritmisk skalning**

Följande fristående exempel skapar ett linjediagram med de fem förfrågningsantalena på den första bilden, klonar sedan den bilden och aktiverar en bas‑10 logaritmisk värdeaxel på den andra. Båda bilderna behåller samma data.

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

// Behåll den första bilden linjär och ändra endast kopians värdeaxelskala.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Linjär skala (bild 1):** Lika vertikala avstånd motsvarar lika skillnader i förfrågningsantal. Det största värdet dominerar diagrammet, vilket gör de mindre värdena svåra att skilja.

![Linjediagram i PowerPoint som visar fem förfrågningsantal på en linjär värdeaxel](value-axis-linear.png)

**Logaritmisk skala (bild 2):** Lika vertikala avstånd motsvarar lika förhållanden. Varje period har tio gånger så många förfrågningar som den föregående, så punkterna bildar en rak stigande linje på bas‑10‑skalan. Axel‑etiketterna visar fortfarande de ursprungliga förfrågningsantalena.

![Samma fem förfrågningsantal i PowerPoint på en bas‑10 logaritmisk värdeaxel](value-axis-logarithmic.png)

### **Hantera noll- och negativa värden**

En logaritmisk skala kan endast visa strikt positiva värden. Kontrollera data innan den aktiveras. Om noll- eller negativa värden är meningsfulla, behåll en linjär skala eller visa dem separat. Om det är lämpligt att utesluta dessa värden för analysen, förklara utelämnandet. Ersätt dem inte tyst med små positiva tal, eftersom detta ändrar dataens betydelse. Alla manuellt konfigurerade minimum eller maximum för en logaritmisk axel måste också vara positiva.

## **FAQ**

**Hur ställer jag in värdet där en axel korsar den andra (axelkorsning)?**

Använd [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) för att välja korsningsbeteende. För att ange ett numeriskt korsningsvärde, sätt [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Dessa inställningar låter dig flytta axelkorsningen till ett lämpligt referensvärde.

**Hur kan jag placera tick‑etiketter i förhållande till axeln?**

Sätt [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) med [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` eller `None`. För att styra själva tick‑markeringarna, använd [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) eller [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); dessa är separata från etikettpositioneringen.