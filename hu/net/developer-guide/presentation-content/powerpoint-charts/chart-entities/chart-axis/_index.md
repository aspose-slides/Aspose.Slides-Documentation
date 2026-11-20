---
title: Diagramtengelyek testreszabása prezentációkban .NET-ben
linktitle: Diagramtengely
type: docs
url: /hu/net/chart-axis/
keywords:
- diagramtengely
- függőleges tengely
- vízszintes tengely
- tengely testreszabása
- tengely manipulálása
- tengely kezelése
- tengely tulajdonságok
- maximális érték
- minimális érték
- tengelyvonal
- dátum formátum
- tengelycím
- tengely pozíció
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel, hogyan használhatja az Aspose.Slides for .NET-et a diagramtengelyek testreszabásához PowerPoint prezentációkban jelentések és vizualizációk számára."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a diagram tengelyeit az Aspose.Slides for .NET segítségével. Tárgyalja a számított tengelyértékeket, a diagram sorok és oszlopok cseréjét, a tengely láthatóságát, a kategória címke‑ és jelölő‑távolságokat, a dátumkategóriákat és formázást, a cím forgatását, a tengely elhelyezését, a megjelenítési egységeket, valamint a logaritmikus skálázást.

## **A függőleges tengely maximális értékeinek lekérése a diagramokon**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) és adjon hozzá egy alapértelmezett adatokkal ellátott területdiagramot. Hívja meg a [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) metódust a számított tengelyértékek olvasása előtt, hogy a diagram elrendezése naprakész legyen.

Olvassa le az [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) és az [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) értékeket a tengelykorlátokhoz, valamint az [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) és az [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) értékeket a jelölő‑távolságokhoz. Az [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) és az [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) időegység‑skálákat biztosítanak, amelyek a dátum tengelyeknél relevánsak. A példa ezeket az értékeket helyi változókba menti, majd elmenti a diagramot.

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

## **Az adatok cseréje a tengelyek között**

Használja a [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) metódust a sorozatok és a kategóriák szerepének felcseréléséhez a diagram adataiban. Minden korábbi kategória sorozattá, minden korábbi sorozat pedig kategóriává válik. Ez módosítja az adatok csoportosítását; nem cseréli fel a vízszintes és függőleges tengelyeket. A példa a [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) metódust használja az alapértelmezett adatok `Sheet1!A1:D5` tartományba kötéséhez, beleértve a fejlécsort és a kategóriaoszlopot, a sorok és oszlopok cseréje előtt. Egy négy sorozatos és három kategóriás diagramot ment.

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

## **A tengely ábrázolási sorrendjének megfordítása**

Használja az [IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) tulajdonságot egy kategória‑ vagy érték‑tengely megfordításához. Például egy vízszintes sávdiagram a projektszakaszokat felülről lefelé ugyanabban a sorrendben jelenítheti meg, mint a munkalapon: Tervezés, Fejlesztés, Tesztelés. A tengely megfordítása az ábrázolási irányt változtatja; nem rendezi vagy átrendezi a munkafüzet adatokat. Ezzel ellentétben a [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) felcseréli a sorozatok és a kategóriák szerepét.

Az alábbi példa egy három szakaszból és egy sorozatból álló vízszintes sávdiagramot hoz létre. Egy prezentációt ment három diával: normál sorrend, megfordított kategóriák és megfordított értékek. Minden másolat ugyanazt az adatkészletet használja, és minden másolaton csak egy tengely van megfordítva.

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

A tengely megfordítása a merőleges tengelyt is áthelyezheti a diagram ellentétes oldalára. A [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) határozza meg, hogy a másik tengely hol keresztezi a konfigurálandó tengelyt. A 2. dián a `Maximum` beállítása a megfordított kategória‑tengelyen a vízszintes érték‑tengelyt az alsó pozícióban tartja. Egy konkrét keresztpont meghatározásához használja a [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) metódust. Ellenőrizze a keresztbeállításokat az irány módosításakor, különösen ha a diagram már rendelkezik egy egyéni keresztponttal. Állítsa vissza az `IsPlotOrderReversed` értékét `false`‑ra a normál ábrázolási irány visszaállításához; a keresztbeállítások különállóak.

| Normál sorrend (1. dia) | Megfordított kategóriák (2. dia) | Megfordított értékek (3. dia) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| A kategóriák az alulról felfelé haladnak; az értékek balról jobbra nőnek. | A Tervezés, Fejlesztés és Tesztelés fentről lefele jelenik meg. Az értékek és a munkafüzet sor sorrendje változatlan. | A kategóriák megtartják a normál sorrendet; az értékek jobbról balra nőnek. A kategória‑tengely a jobb oldalon, a nullánál keresztezi a tengelyt. |

## **A függőleges tengely letiltása vonaldiagramoknál**

Állítsa az [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) tulajdonságot `false`‑ra a függőleges tengelyen a rejtéshez. A példa egy alapértelmezett adatokkal ellátott vonaldiagramot hoz létre, és a függőleges tengelyt elrejtve menti.

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

## **A vízszintes tengely letiltása vonaldiagramoknál**

Állítsa az [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) tulajdonságot `false`‑ra a vízszintes tengelyen a rejtéshez. A példa egy alapértelmezett adatokkal ellátott vonaldiagramot hoz létre, és a vízszintes tengelyt elrejtve menti.

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

## **Diagram rácsvonalainak megjelenítése vagy elrejtése**

Olvassa le a [ShowMajorGridLines](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/showmajorgridlines/) és a [ShowMinorGridLines](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/showminorgridlines/) értékeket, hogy megtudja, mely rácsvonalakat jeleníti meg a tengely. Mindkét tulajdonság csak olvasható. Használja a [MinorGridLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/minorgridlinesformat/) vonal kitöltését a kisebb rácsvonalak megjelenítéséhez vagy elrejtéséhez. Állítson be egy szilárd kitöltést látható színnel a megjelenítéshez, vagy használja a `FillType.NoFill` értéket a rejtéshez. A nagyobb rácsvonalak megfelelő beállítása a [MajorGridLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorgridlinesformat/)`.Line.FillFormat`. A rácsvonal kitöltésének módosítása megőrzi a tengely láthatóságát és a jelölőket.

Ennek a csoportosított oszlopdiagramnak a függőleges tengelye kezdetben a nagyobb rácsvonalakat láthatóvá, a kisebbeket rejtve teszi. A példa először narancssárga kisebb rácsvonalakat jelenít meg, majd a mentés előtt újra elrejti őket.

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

| Kisebb rácsvonalak engedélyezve | Kisebb rácsvonalak rejtve |
| --- | --- |
| ![Orange minor gridlines between the major gridlines on the vertical axis](minor-gridlines-enabled.png) | ![The same column chart with only major gridlines visible](minor-gridlines-hidden.png) |

## **Kategória‑tengely módosítása**

Állítsa be a [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) értékét egy dátum‑ vagy szöveg‑kategória‑tengely kiválasztásához. Ez a példa az `ExistingChart.pptx` fájlt igényli, amelynek első diáján az első alakzata a diagram, és a kategória‑cellák numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt dátum‑tengelyre állítja. Az [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) `false`, a [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) `1`, valamint a [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) `Months` beállítása egyhavi intervallumú fő jelölőket eredményez.

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

### **A kategória‑tengely típusának automatikus meghatározása adatokból**

A kategóriák feltöltése után hívja meg a [SetCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/setcategoryaxistypeautomatically/) metódust, majd olvassa le a [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/categoryaxistype/) értékét a választás ellenőrzéséhez. Ez akkor hasznos, ha ugyanaz a diagram szöveges címkéket vagy numerikus dátumértékeket kap. A metódus a hívás pillanatában meghatározza a típust; nem állít be tartós módot, amely későbbi adatváltozásokra újraszámolna. Hívja meg újra a kategóriák cseréje után.

Az alábbi példa szöveges kategóriákkal rendelkező diagramot hoz létre, és a `Text` feliratot írja ki. Ezután a kategória‑cellák értékeit dátumokra cseréli, és újra meghívja a metódust, amely a `Date` feliratot adja. A dátumok numerikus OLE Automation értékekként tárolódnak, amelyeket a [DateTime.ToOADate](https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tooadate) ad vissza, nem dátum‑karakterláncokként. A [CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/customnumberformat/) szabályozza, hogyan jelennek meg ezek az értékek; nem alakítja át a szöveget numerikus dátumokká. További információ a kategória‑cellákról a [Chart Workbook](/slides/hu/net/chart-workbook/) oldalon található.

Használja az automatikus meghatározást, ha a bemenet szöveges kategóriákat vagy numerikus dátumokat tartalmaz, ahogy ez a példában is történt. Általános numerikus címkék, vegyes kategóriák vagy üres adatok esetén állítsa be kifejezetten a [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/categoryaxistype/) értékét a kívánt jelentésnek megfelelően. A puszta numerikus értékek önmagukban nem jelzik, hogy a kategóriák dátumokat képviselnek.

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
Console.WriteLine(axis.CategoryAxisType); // Szöveg

var dates = new[] { new DateTime(2026, 1, 1), new DateTime(2026, 1, 2), new DateTime(2026, 2, 1) };

for (var i = 0; i < dates.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0);
    categoryCell.Value = dates[i].ToOADate();
    categoryCell.CustomNumberFormat = "yyyy-mm-dd";
}

axis.SetCategoryAxisTypeAutomatically();
Console.WriteLine(axis.CategoryAxisType); // Dátum

presentation.Save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
```

## **Kategória‑tengely címke‑intervallumok szabályozása**

Ha egy diagram sok kategóriát tartalmaz, csökkentse a látható tengelycímkék számát a kategóriák vagy adatpontok eltávolítása nélkül. Állítsa az [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) tulajdonságot `false`‑ra, majd adja meg a kívánt kategória‑intervallumot a [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) segítségével. Szöveges kategóriák esetén a számlálás az első kategóriától indul:

| Intervallum | A példában megjelenített címkék |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

A `3` intervallum minden harmadik címkét jelenít meg, a többi két címke rejtve marad. Nem távolítja el a megfelelő oszlopokat. Az automatikus elosztás a rendelkezésre álló hely alapján választ intervallumot; nem feltétlenül jeleníti meg az összes címkét.

A jelölőket külön lehet szabályozni. Állítsa az [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) tulajdonságot `false`‑ra, és használja a [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) értéket az intervallum beállításához. Például az `1` minden kategória‑intervallumnál egy jelölőt tart, míg a címkék csak minden harmadik kategóriánál jelennek meg. Állítsa a [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) értékét látható stílusra, hogy lássa a hatást. Bármely automatikus‑elhelyezési tulajdonság `true`‑ra állítása újra engedélyezi a diagram számára az intervallum automatikus kiválasztását.

Az alábbi önálló példa 24 kategóriát és egy sorozatot hoz létre, majd három diát ment a `CategoryAxisIntervals.pptx` fájlba: automatikus elosztás, kézi címke‑elosztás független jelölőkkel, és visszaállított automatikus elosztás. A két másolat az eredeti diagramadatot őrzi. Bemeneti prezentáció nem szükséges. A vízszintes címke‑szöveg teszi egyértelművé a sűrűségkülönbséget.

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

// Dia 2: minden harmadik címkét jelenítse meg, de minden kategóriához tartson egy jelölőt.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Dia 3: engedje, hogy a diagram újra kiválassza mindkét intervallumot.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**Automatikus távolság (1. dia):** Ebben a megjelenítésben minden második kategória‑címke látható, és két sorra törik. Az automatikus eredmény a diagram méretétől, betűtípustól és a renderelőtől függően változhat.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Kézi távolság (2. dia):** Minden harmadik címke jelenik meg egy sorban, miközben a jelölők minden kategória‑intervallumnál megmaradnak. Az összes 24 oszlop, beleértve a címkéktől menteseket is, látható ugyanazzal az értékkel. A 3. dia visszaállítja a fenti automatikus megjelenést.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **A megfelelő tengely és intervallum kiválasztása**

Használja ezt a kategória‑számintervallumot egy szöveges kategória‑tengelyhez, például oszlop, vonal, terület vagy sáv diagram kategória‑tengelyéhez. Oszlopdiagram esetén ez a vízszintes tengely. Vízzintes sávdiagram esetén a kategória‑tengely függőleges, ezért ezeket a beállításokat a [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) tulajdonságra alkalmazza. A jelölő‑távolság a sorozat‑tengelyre is vonatkozik azokban a diagramokban, ahol van ilyen.

Ne használja a kategória‑címke‑intervallumot az érték‑tengely numerikus skálájának beállításához. Egy érték‑tengelyen a [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) az értékek közti különbséget határozza meg: például egy `10`‑es fő egység 0, 10, 20 stb. jelölőket eredményez, ha a tengely nulláról indul. A `3`‑as kategória‑címke‑intervallum viszont a kategória‑pozíciókat számolja, függetlenül azok adatértékeitől. Szórt‑ és buborék‑diagramok érték‑tengelyt használnak, nem szöveges kategória‑tengelyt. Dátum‑tengely esetén használjon időalapú fő egységeket és skálákat, ahogy a [Kategória‑tengely módosítása](#change-a-category-axis) szakaszban le van írva.

## **A kategória‑tengely értékek dátumformátumának beállítása**

A példa négy éves értékkel helyettesíti az alapértelmezett diagramadatokat. A dátumok az első munkalapon (index `0`) OLE Automation sorozatszámként tárolódnak. Állítsa a [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) értékét dátum‑tengelyre, kapcsolja ki az [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) beállítást, és adja meg a `yyyy` formátumot a [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) tulajdonságnak, hogy a kategória‑címkék a cellaformázástól függetlenül négy számjegyű éveket jelenítsenek meg.

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

## **Diagramtengely cím forgatási szögének beállítása**

Aktiválja a [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) tulajdonságot a függőleges tengelyen, adja meg a cím szövegét, és állítsa be a [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) értékét a forgatáshoz. A szög fokban van megadva; ez a példa egy oszlopdiagramot ment, amelynek az érték‑tengely címe 90 fokban van elforgatva.

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

## **A tengely pozíciójának beállítása egy kategória‑ vagy érték‑tengelyen**

Használja az [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) tulajdonságot annak szabályozására, hogy az érték‑tengely a kategória‑tengelyet a kategóriák között vagy a kategória‑jelölőknél keresse‑t. Ez a tulajdonság csak a kategória‑tengelyekre vonatkozik. A példa a vízszintes kategória‑tengelyen `true`‑ra állítja egy oszlopdiagramon, és elmenti az eredményt.

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

## **Megjelenítési egység beállítása egy diagram érték‑tengelyén**

Állítsa a [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) tulajdonságot a címkék skálázásához az érték‑tengelyen anélkül, hogy az adatokat módosítaná. A [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) `Millions` értéke esetén a 60 000 000 érték 60‑ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a függőleges tengelyen a millió‑egységet alkalmazza.

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

## **Logaritmikus érték‑tengely konfigurálása**

A logaritmikus érték‑tengely akkor hasznos, ha a pozitív értékek több nagyságrendi rendet fednek le. Például egy szolgáltatás öt időszakban 10, 100, 1 000, 10 000 és 100 000 kérésre számíthat. Lineáris skálán a kisebb értékek közel a nullához jelennek meg. A logaritmikus skála a relatív növekedést könnyebben összehasonlíthatóvá teszi: az egyenlő távolságok egyenlő arányt jelentenek, nem egyenlő különbséget.

Állítsa a [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) tulajdonságot `true`‑ra az érték‑tengelyen, és használja a [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) metódust az alaphatár kiválasztásához. Ez megváltoztatja a meglévő értékek megjelenítését; nem változtatja meg az adatokat, és nem ad hozzá logaritmikus trendvonalat. A trendvonal egy külön funkció, amely a adatokhoz illeszkedő kapcsolatot mutat.

### **Az érték‑tengely és az alap kiválasztása**

Vonal‑ vagy oszlopdiagram esetén az érték‑tengely a [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Vízszintes sávdiagram esetén a [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). Szórt‑ és buborék‑diagramok két érték‑tengellyel rendelkeznek, ezért az X‑értékekhez a vízszintes, a Y‑értékekhez a függőleges tengelyt, vagy mindkettőt választhatja. Ne alkalmazzon logaritmikus skálázást kategória‑tengelyen.

Az alapértelmezett logaritmikus alap `10`. PPTX diagramok esetén a `2`‑tól `1000`‑ig terjedő egész számok (beleértve a tört értékeket, például `2.5`) használhatók. A `10`‑es alappal a sorozatok (10, 100, 1 000, 10 000) egyenlő távolságra helyezkednek el.

### **Lineáris és logaritmikus skálázás összehasonlítása**

Az alábbi önálló példa egy vonaldiagramot hoz létre az első dián az öt kérés számával, majd klónozza ezt a diát, és a másodikon beállítja a tízes alapú logaritmikus érték‑tengelyt. Mindkét dia ugyanazt az adatot tartalmazza.

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

// Az első diát lineárisra hagyja, és csak a másolat érték‑tengely skáláját változtatja.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Lineáris skála (1. dia):** Az egyenlő függőleges távolságok egyenlő különbséget jelentenek a kérés számában. A legnagyobb érték dominálja a diagramot, ami megnehezíti a kisebb értékek megkülönböztetését.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Logaritmikus skála (2. dia):** Az egyenlő függőleges távolságok egyenlő arányt jelentenek. Minden időszak tízszer annyi kérést tartalmaz, mint az előző, ezért a pontok egy egyenes, emelkedő vonalat alkotnak a tízes skálán. A tengelycímkék továbbra is az eredeti kérés számokat mutatják.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Nulla és negatív értékek kezelése**

A logaritmikus skála csak kifejezetten pozitív értékeket jeleníthet meg. Ellenőrizze az adatokat, mielőtt engedélyezi. Ha a nulla vagy a negatív értékek jelentősek, tartsa meg a lineáris skálát, vagy jelenítse meg külön. Ha a kizárás megfelelő az elemzéshez, magyarázza el a hiányt. Ne cserélje le őket csendben kis pozitív számokra, mert ez megváltoztatja az adatok jelentését. Bármely, a logaritmikus tengelyen manuálisan beállított minimum vagy maximum szintén pozitívnak kell lennie.

## **GYIK**

**Hogyan állítható be, hogy melyik tengely hol metsződik a másikkal (tengely metszéspontja)?**

Használja a [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) beállítást a metszési viselkedés kiválasztásához. Numerikus metszési érték megadásához állítsa be a [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) tulajdonságot. Ezek a beállítások lehetővé teszik a tengely metszéspontjának áthelyezését egy megfelelő alapvonalra.

**Hogyan helyezhetők el a jelölőcímkék a tengelyhez viszonyítva?**

Állítsa be a [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) tulajdonságot a [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/) segítségével: `Low`, `High`, `NextTo` vagy `None`. A jelölőket magukat a [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) vagy a [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/) szabályozzák; ezek különállóak a címkeelhelyezéstől.