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

Denna artikel förklarar hur man anpassar diagramaxlar med Aspose.Slides för .NET. Den täcker beräknade axelvärden, byta rader och kolumner i diagram, axelns synlighet, kategorimärkes‑ och tick‑mark‑intervaller, datumkategorier och -formatering, titelrotation, axelpositionering, visningsenheter och logaritmisk skala.

## **Hämta maxvärdena på den vertikala axeln i diagram**

Skapa en [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) och lägg till ett ytdiagram med standarddata. Anropa [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) innan du läser beräknade axelvärden så att diagramlayouten är uppdaterad.

Läs [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) och [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) för axelgränserna, samt [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) och [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) för tick‑intervall. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) och [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) ger tidsenhetsskalor, vilket är relevant för datumaxlar. Exemplet lagrar dessa värden i lokala variabler och sparar diagrammet.

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

## **Byt data mellan axlar**

Använd [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) för att byta rollerna för serier och kategorier i diagramdata. Varje tidigare kategori blir en serie, och varje tidigare serie blir en kategori. Detta ändrar hur data grupperas; det byter inte ut de horisontella och vertikala axlarna. Exemplet använder [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) för att binda standarddata till `Sheet1!A1:D5`, inklusive rubrikraden och kategori‑kolumnen, innan rader och kolumner byts. Det sparar ett diagram med fyra serier och tre kategorier.

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

## **Inaktivera den vertikala axeln för linjediagram**

Ställ in [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) på `false` på den vertikala axeln för att dölja den. Exemplet skapar ett linjediagram med standarddata och sparar det med den vertikala axeln dold.

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

Ställ in [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) på `false` på den horisontella axeln för att dölja den. Exemplet skapar ett linjediagram med standarddata och sparar det med den horisontella axeln dold.

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

Ställ in [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) för att välja en datum‑ eller text‑kategori axel. Detta exempel kräver `ExistingChart.pptx`, med ett diagram som den första formen på den första bilden och kategoriceller som innehåller numeriska Excel‑datumvärden. Det ändrar den horisontella axeln till en datumaxel. Genom att sätta [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) till `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) till `1` och [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) till månader placeras huvud‑tickar med ett‑månadsintervall.

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

När ett diagram har många kategorier, minska antalet synliga axel‑etiketter utan att ta bort kategorier eller datapunkter. Ställ in [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) på `false`, sätt sedan [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) till önskat kategoriintervall. För textkategorier i deras normala ordning startar räkningen vid den första kategorin:

| Intervall | Etiketter som visas i exemplet |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

Ett intervall på `3` visar var tredje etikett och lämnar två etiketter dolda mellan de visade etiketterna. Det tar inte bort motsvarande kolumner. Automatisk spacing väljer ett intervall baserat på tillgängligt utrymme; det visar inte nödvändigtvis varje etikett.

Tick‑markerna har separata kontroller. Ställ in [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) på `false` och använd [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) för att ange deras intervall. Till exempel, `1` behåller en tick‑mark på varje kategoriintervall medan etiketter bara visas var tredje kategori. Ställ in [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) till en synlig stil så att du kan se resultatet. Att sätta antingen den automatiska spacing‑egenskapen tillbaka till `true` låter diagrammet välja intervallet igen.

Följande självständiga exempel skapar 24 kategorier och en serie, och sparar sedan tre bilder i `CategoryAxisIntervals.pptx`: automatisk spacing, manuell etikettspacing med oberoende tick‑markeringar, och återställd automatisk spacing. De två kopiorna behåller den ursprungliga diagramdatan. Ingen inmatningspresentation krävs. Horisontell etikettext gör skillnaden i täthet lätt att se.

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

// Bild 2: visa varje tredje etikett, men behåll en tick‑markering för varje kategori.
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

**Automatisk spacing (bild 1):** I denna rendering visas varje andra kategori‑etikett och radbryts till två rader. Det automatiska resultatet kan variera med diagramstorlek, teckensnitt och renderaren.

![Automatisk kategori‑etikettspacing med alla 24 kolumner synliga](category-axis-automatic.png)

**Manuell spacing (bild 2):** Varje tredje etikett visas på en rad, medan tick‑markeringar förblir vid varje kategoriintervall. Alla 24 kolumner, inklusive de utan etiketter, förblir synliga med samma värden. Bild 3 återställer den automatiska utseendet som visas ovan.

![Manuellt kategori‑etikettintervall på tre med alla 24 kolumner synliga](category-axis-manual.png)

### **Välj rätt axel och intervall**

Använd detta kategori‑räkningsintervall för en text‑kategori axel, till exempel kategori‑axeln i ett kolumndiagram, linjediagram, ytdiagram eller stapeldiagram. I ett kolumndiagram är den horisontell axel. I ett horisontellt stapeldiagram är kategori‑axeln vertikal, så tillämpa dessa inställningar på [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Tick‑mark‑spacing gäller även för en serie‑axel i diagram som har en.

Använd inte kategori‑etikettspacing för att ställa in den numeriska skalan på en värdeaxel. På en värdeaxel anger [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) ett värdeskillnad: till exempel ger en huvud‑enhet på `10` tick‑markeringar vid 0, 10, 20 osv när axeln börjar på noll. Ett kategori‑etikettintervall på `3` räknar däremot kategori‑positioner, oavsett deras datavärden. Spridnings‑ och bubbeldiagram använder värdeaxlar snarare än en text‑kategori axel. För en datumaxel, använd tidsbaserade huvud‑enheter och skalor som beskrivs i [Ändra en kategori‑axel](#change-a-category-axis).

## **Ställ in datumformatet för kategori‑axelvärden**

Exemplet ersätter standarddiagramdata med fyra årliga värden. Datum lagras som OLE Automation‑serienummer i det första kalkylbladet (index `0`). Ställ in [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) till en datumaxel, inaktivera [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/), och tilldela `yyyy` till [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) så att kategori‑etiketterna visar fyrsiffriga år oberoende av cellformateringen.

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

## **Ställ in en rotationsvinkel för ett diagramaxeltitel**

Aktivera [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) på den vertikala axeln, ange titeltext och sätt [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) för att rotera titeln. Vinkeln mäts i grader; detta exempel sparar ett kolumndiagram med dess värde‑axeltitel roterad 90 grader.

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

## **Ställ in axelpositionen på en kategori‑ eller värdeaxel**

Använd [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) för att styra om värdeaxeln korsar kategori‑axeln mellan kategorier eller vid kategori‑tick‑markeringar. Denna egenskap gäller kategori‑axlar. Exemplet sätter den till `true` på den horisontella kategori‑axeln i ett kolumndiagram och sparar resultatet.

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

Ställ in [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) för att skala etiketterna på en värdeaxel utan att ändra den underliggande datan. Med [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) satt till `Millions` visas ett värde på 60 000 000 som 60. Exemplet skapar ett kolumndiagram och tillämpar miljon‑visningsenheten på dess vertikala axel.

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

En logaritmisk värdeaxel är användbar när positiva värden sträcker sig över flera storleksordningar. Till exempel kan en tjänst ta emot 10, 100, 1 000, 10 000 och 100 000 förfrågningar över fem perioder. På en linjär skala ligger de mindre värdena nära varandra nära noll. En logaritmisk skala gör deras relativa tillväxt enklare att jämföra: lika avstånd representerar lika förhållanden snarare än lika skillnader.

Ställ in [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) på `true` på värdeaxeln och använd [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) för att välja basen. Detta ändrar hur befintliga värden visas; det ändrar inte datan eller lägger till en logaritmisk trendlinje. En trendlinje representerar ett anpassat förhållande i datan och är en separat funktion.

### **Välj värdeaxeln och basen**

För ett linje‑ eller kolumndiagram är värdeaxeln [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). För ett horisontellt stapeldiagram är den [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). Spridnings‑ och bubbeldiagram har två värdeaxlar, så välj den horisontella axeln för X‑värden, den vertikala axeln för Y‑värden, eller båda. Tillämpa inte logaritmisk skalning på en kategori‑axel.

Standardlogaritmbasen är `10`. För PPTX‑diagram, använd en bas mellan `2` och `1000`, inklusiva; bråkliga baser som `2.5` stöds också. Med bas `10` är på varandra följande potenser som 10, 100, 1 000 och 10 000 lika avstånd.

### **Jämför linjär och logaritmisk skalning**

Följande självständiga exempel skapar ett linjediagram med de fem förfrågningsantalena på den första bilden, klonar sedan den bilden och aktiverar en bas‑10 logaritmisk värdeaxel på den andra. Båda bilderna behåller samma data.

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

**Linjär skala (bild 1):** Lika vertikala avstånd representerar lika skillnader i förfrågningsantal. Det största värdet dominerar diagrammet, vilket gör de mindre värdena svåra att särskilja.

![Linjediagram i PowerPoint som visar fem förfrågningsantal på en linjär värdeaxel](value-axis-linear.png)

**Logaritmisk skala (bild 2):** Lika vertikala avstånd representerar lika förhållanden. Varje period har tio gånger så många förfrågningar som den föregående, så punkterna bildar en rak stigande linje på bas‑10‑skalan. Axelt etiketterna visar fortfarande de ursprungliga förfrågningsantalena.

![Samma fem förfrågningsantal i PowerPoint på en bas‑10 logaritmisk värdeaxel](value-axis-logarithmic.png)

### **Hantera noll- och negativa värden**

En logaritmisk skala kan bara visa strikt positiva värden. Kontrollera data innan du aktiverar den. Om noll‑ eller negativa värden är meningsfulla, behåll en linjär skala eller visa dem separat. Om det är lämpligt att exkludera dessa värden för analysen, förklara borttagandet. Ersätt inte tyst dem med små positiva tal, eftersom det förändrar datans innebörd. Alla manuellt konfigurerade min‑ eller maxvärden för en logaritmisk axel måste också vara positiva.

## **FAQ**

**Hur anger jag värdet där en axel korsar den andra (axelkorsning)?**

Använd [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) för att välja korsningsbeteende. För att ange ett numeriskt korsningsvärde, sätt [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Dessa inställningar låter dig flytta axelkorsningen till en lämplig baslinje.

**Hur kan jag positionera tick‑etiketter relativt axeln?**

Ställ in [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) med [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` eller `None`. För att styra själva tick‑markeringarna, använd [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) eller [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); dessa är separata från etikettpositioneringen.