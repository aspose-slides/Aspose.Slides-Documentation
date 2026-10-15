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
- tengely tulajdonságai
- maximális érték
- minimális érték
- tengelyvonal
- dátumformátum
- tengelycím
- tengely pozíció
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan használhatja az Aspose.Slides for .NET-et a diagramtengelyek testreszabásához PowerPoint prezentációkban jelentések és vizualizációk számára."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a diagram tengelyeit az Aspose.Slides for .NET segítségével. Kitér a kiszámított tengelyértékekre, a diagram sorok és oszlopok felcserélésére, a tengely láthatóságára, a kategória címke‑ és jelölőintervallumokra, a dátumkategóriákra és formázásra, a cím forgatására, a tengely pozicionálására, a megjelenítési egységekre és a logaritmikus skálázásra.

## **A függőleges tengely legnagyobb értékeinek lekérése diagramokon**

Hozzon létre egy [Prezentáció](https://reference.aspose.com/slides/net/aspose.slides/presentation/) és adjon hozzá egy alapértelmezett adatokkal rendelkező területdiagramot. Hívja meg a [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) mielőtt a kiszámított tengelyértékeket olvasná, hogy a diagram elrendezése naprakész legyen.

Olvassa a [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) és [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) értékeket a tengelykorlátokhoz, valamint a [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) és [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) értékeket a jelölőintervallumokhoz. A [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) és [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) időegység skálákat biztosít, amelyek a dátumtengelyeknél relevánsak. A példában ezeket az értékeket helyi változókba tárolja, és elmenti a diagramot.

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

Használja a [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) metódust a sorozatok és kategóriák szerepének felcseréléséhez a diagram adataiban. Minden korábbi kategória sorozattá, és minden korábbi sorozat kategóriává válik. Ez megváltoztatja az adatok csoportosítását; nem cseréli fel a vízszintes és függőleges tengelyeket. A példában a [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) metódust használja, hogy az alapértelmezett adatot a `Sheet1!A1:D5` tartományra kötse, beleértve a fejlécsort és a kategóriaoszlopot, mielőtt a sorok és oszlopok fel lennének cserélve. Egy négy sorozatos és három kategóriás diagramot ment.

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

## **A tengely rajzolási sorrendjének megfordítása**

Használja az [IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) metódust egy kategória vagy értéktengely megfordításához. Például egy vízszintes sávdiagram megjelenítheti a projektfázisokat felülről lefelé ugyanabban a sorrendben, mint a munkalapon: Tervezés, Fejlesztés, Tesztelés. Egy tengely megfordítása megváltoztatja a rajzolási irányt; nem rendezi vagy átrendezi a munkafüzet adatait. Ezzel szemben a [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) felcseréli a sorozatok és kategóriák szerepét.

A következő példa egy három fázisú és egy sorozatú vízszintes sávdiagramot hoz létre. Egy prezentációt ment három diával: normál sorrend, megfordított kategóriák és megfordított értékek. Minden másolat azonos adatkészletet használ, és minden másolaton csak egy tengely van megfordítva.

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

// 2. dia: az első kategóriát felül jelenítse meg.
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// Tartsa a vízszintes értéktengelyt alul.
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// 3. dia: csak a vízszintes numerikus skálát fordítsa meg.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

Egy tengely megfordítása áthelyezheti a merőleges tengelyt a diagram másik oldalára is. A [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) szabályozza, hogy a másik tengely hol metsződik a konfigurált tengellyel. A 2. dián, ha a megfordított kategóriatengelyen `Maximum` értékre állítja, a vízszintes értéktengely alul marad. Egy konkrét metszéspont meghatározásához használja a [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) metódust. Ellenőrizze a metszési beállításokat irányváltáskor, különösen ha a diagram már rendelkezik egy egyéni metszésponttal. Állítsa az `IsPlotOrderReversed` értékét `false`‑ra a normál rajzolási irány helyreállításához; a metszési beállítások külön kezelendők.

| Normál sorrend (1. dia) | Megfordított kategóriák (2. dia) | Megfordított értékek (3. dia) |
| --- | --- | --- |
| ![Vízszintes sávdiagram a normál kategória- és értéktengely sorrenddel](axis-order-normal.png) | ![Vízszintes sávdiagram a kategóriákkal felülről lefelé](axis-order-categories-reversed.png) | ![Vízszintes sávdiagram megfordított értéktengellyel és nullával a jobb oldalon](axis-order-values-reversed.png) |
| A kategóriák alulról felfelé helyezkednek el; az értékek balról jobbra nőnek. | A Tervezés, Fejlesztés és Tesztelés felülről lefelé helyezkednek el. Az értékek és a munkafüzet sorrendje változatlan. | A kategóriák megtartják a normál sorrendet; az értékek jobbról balra nőnek. A kategóriatengely a jobb oldalon nullánál metsződik. |

## **A függőleges tengely letiltása vonaldiagramoknál**

Állítsa az [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) értékét `false`‑ra a függőleges tengelyen, hogy elrejtse. A példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, és elmenti a függőleges tengely rejtve.

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

Állítsa az [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) értékét `false`‑ra a vízszintes tengelyen, hogy elrejtse. A példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, és elmenti a vízszintes tengely rejtve.

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

## **Kategóriatengely módosítása**

Állítsa be a [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) értékét, hogy dátum vagy szöveg kategóriatengelyt válasszon. Ez a példa a `ExistingChart.pptx` fájlt igényli, amelyben a diagram az első dián az első alakzat, és a kategória cellák numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt dátumtengelyre változtatja. A [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) `false`, a [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) `1`, a [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) hónap beállításával a fő jelölők egyhónapos intervallumra kerülnek.

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

## **Kategóriatengely címkeintervallumok vezérlése**

Mikor egy diagram sok kategóriát tartalmaz, csökkentheti a látható tengelycímkék számát anélkül, hogy a kategóriákat vagy adatpontokat eltávolítaná. Állítsa az [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) értékét `false`‑ra, majd a [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) értékét a kívánt kategória intervallumra. Szöveges kategóriák esetén normál sorrendben a számozás az első kategóriától indul:

| Intervallum | Példában megjelenített címkék |
| --- | --- |
| `1` | Kategória 1, Kategória 2, Kategória 3, … Kategória 24 |
| `2` | Kategória 1, Kategória 3, Kategória 5, … Kategória 23 |
| `3` | Kategória 1, Kategória 4, Kategória 7, … Kategória 22 |

Egy `3` intervallum minden harmadik címkét jelenít meg, két címke marad rejtve a megjelenített címkék között. Nem távolítja el a megfelelő oszlopokat. Az automatikus távolság az elérhető hely alapján választ intervallumot; nem feltétlenül jeleníti meg az összes címkét.

Jelölővonalak külön vezérelhetők. Állítsa az [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) értékét `false`‑ra, és a [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) segítségével adja meg az intervallumukat. Például a `1` érték minden kategória intervallumban jelölővonalat helyez el, miközben a címkék csak minden harmadik kategórián jelennek meg. Állítsa a [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) értékét látható stílusra, hogy lássa az eredményt. Bármelyik automatikus távolság‑tulajdonság visszaállítása `true`‑ra lehetővé teszi, hogy a diagram újra kiválassza azt az intervallumot.

A következő önálló példa 24 kategóriát és egy sorozatot hoz létre, majd három diát ment a `CategoryAxisIntervals.pptx` fájlba: automatikus távolság, manuális címke‑távolság független jelölőkkel, és az automatikus távolság visszaállítása. A két másolat megőrzi az eredeti diagramadatokat. Bemeneti prezentáció nem szükséges. A vízszintes címke‑szöveg megkönnyíti a sűrűség különbségének észrevételét.

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

// 2. dia: minden harmadik címkét jelenítsen meg, de minden kategóriához tartson egy jelölővonalat.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// 3. dia: engedje, hogy a diagram újra válassza ki mindkét intervallumot.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**Automatikus távolság (1. dia):** Ebben a megjelenítésben minden második kategória címke látható és két sorra törik. Az automatikus eredmény a diagram méretétől, betűtípustól és a megjelenítőtől függ.

![Automatikus kategória címke távolság minden 24 oszlop láthatóval](category-axis-automatic.png)

**Manuális távolság (2. dia):** Minden harmadik címke egy sorra jelenik meg, miközben a jelölővonalak minden kategória intervallumban maradnak. Az összes 24 oszlop – beleértve a címke nélküli oszlopokat – látható ugyanazokkal az értékekkel. A 3. dia visszaállítja a fentebb mutatott automatikus megjelenést.

![Manuális kategória címke intervallum hárommal, minden 24 oszlop láthatóval](category-axis-manual.png)

### **A megfelelő tengely és intervallum kiválasztása**

Használja ezt a kategóriaszám‑intervallumot szöveges kategóriatengelyhez, például oszlop-, vonal-, terület- vagy sávdiagram kategóriatengelyéhez. Oszlopdiagram esetén ez a vízszintes tengely. Vízszintes sávdiagramnál a kategóriatengely függőleges, ezért alkalmazza ezeket a beállításokat a [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) elemre. A jelölővonal‑távolság egy sorozattengelyre is vonatkozik az olyan diagramoknál, ahol van ilyen.

Ne használja a kategória címke távolságát az értéktengely numerikus skálájának beállítására. Egy értéktengelyen a [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) egy értékkülönbséget határoz meg: például a `10` fő egység 0, 10, 20 stb. értékeket eredményez, ha a tengely nullánál kezdődik. A `3` kategória címke intervallum ehelyett a kategória pozíciókat számolja, függetlenül azok adatértékétől. Szórt és buborékdiagramok értéktengelyt használnak, nem szöveges kategóriatengelyt. Dátumtengely esetén használjon időalapú fő egységeket és skálákat, amint azt a [Kategóriatengely módosítása](#change-a-category-axis) szakaszban leírta.

## **A kategóriatengely értékek dátumformátumának beállítása**

A példa az alapértelmezett diagramadatokat négy éves értékkel helyettesíti. A dátumok OLE Automation sorozatszámként tárolódnak az első munkalapon (index `0`). Állítsa be a [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) értékét dátumtengelyre, tiltsa le az [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) beállítást, és adja a `yyyy` értéket a [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/)‑nek, hogy a kategória címkék négy számjegyű évet jelenítsenek a cella formázásától függetlenül.

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

## **A diagram tengelycím forgatási szögének beállítása**

Engedélyezze a [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) beállítást a függőleges tengelyen, adjon meg cím szöveget, és állítsa be a [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) értékét a cím elforgatásához. A szög fokban van megadva; ez a példa egy oszlopdiagramot ment el, amelynek értéktengelycíme 90 fokkal el van forgatva.

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

## **A tengely pozíciójának beállítása kategória vagy értéktengelyen**

Használja az [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) beállítást, hogy meghatározza, a értéktengely a kategóriatengelyet a kategóriák között vagy a kategória jelölővonalaknál metszi‑e. Ez a tulajdonság a kategóriatengelyekre vonatkozik. A példa ezt `true` értékre állítja a oszlopdiagram vízszintes kategóriatengelyén, és elmenti az eredményt.

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

## **A diagram értéktengely megjelenítési egységének beállítása**

Állítsa a [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) értékét, hogy a címkék skálázódjanak egy értéktengelyen anélkül, hogy az alapadatok változnának. A [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) `Millions` értékre állításával a 60 000 000 érték 60‑ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a függőleges tengelyére a millió megjelenítési egységet alkalmazza.

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

## **Logaritmikus értéktengely konfigurálása**

Logaritmikus értéktengely akkor hasznos, ha a pozitív értékek több nagyságrendet fednek le. Például egy szolgáltatás 10, 100, 1 000, 10 000 és 100 000 kérést kaphat öt időszakban. Lineáris skálán a kisebb értékek közel nulla helyen összenyomódnak. Logaritmikus skála könnyebbé teszi a relatív növekedés összehasonlítását: egyenlő távolságok egyenlő arányokat jelentenek, nem egyenlő különbségeket.

Állítsa az [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) értékét `true`‑ra az értéktengelyen, és a [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) segítségével válassza ki az alapot. Ez megváltoztatja a meglévő értékek megjelenítését; nem változtatja meg az adatokat, vagy ad hozzá logaritmikus trendvonalat. A trendvonal a data‑fit kapcsolatot jelöli, és külön funkció.

### **Az értéktengely és az alap kiválasztása**

Egy vonal‑ vagy oszlopdiagramnál az értéktengely a [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Vízszintes sávdiagramnál az [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). A szórt és buborékdiagramok két értéktengellyel rendelkeznek, így a vízszintes tengely az X‑értékekhez, a függőleges a Y‑értékekhez, vagy mindkettőhöz használható. Ne alkalmazzon logaritmikus skálát kategóriatengelyen.

Az alapértelmezett logaritmikus alap `10`. PPTX diagramoknál a `2`‑tól `1000`‑ig terjedő értékek használhatók, a törtalapok, például `2.5` is támogatott. A `10` alapnál a sorozatos hatványok, mint 10, 100, 1 000, 10 000 egyenlő távolságra helyezkednek el.

### **Lineáris és logaritmikus skálázás összehasonlítása**

A következő önálló példa egy vonaldiagramot hoz létre az öt kérelem számával az első dián, majd lemásolja ezt a diát, és a második dián egy 10‑es alapú logaritmikus értéktengelyt engedélyez. Mindkét dia ugyanazt az adatot tartja.

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

// Tartsa az első diát lineárisnak, és csak a másolat értéktengely skáláját változtassa meg.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Lineáris skála (1. dia):** Az egyenlő függőleges távolságok egyenlő különbségeket jelentenek a kérelem számok között. A legnagyobb érték uralja a diagramot, a kisebb értékek nehezen megkülönböztethetők.

![Vonaldiagram PowerPointban, amely öt kérelem számot mutat lineáris értéktengelyen](value-axis-linear.png)

**Logaritmikus skála (2. dia):** Az egyenlő függőleges távolságok egyenlő arányokat jelentenek. Minden időszak kérései tízszeresen nagyobbak az előzőnél, így a pontok egy egyenes vonalat alkotnak a 10‑es alapú skálán. A tengelycímkék továbbra is az eredeti kérelem számokat mutatják.

![Ugyanaz az öt kérelem szám PowerPointban 10‑es alapú logaritmikus értéktengelyen](value-axis-logarithmic.png)

### **Nulla és negatív értékek kezelése**

A logaritmikus skála csak szigorúan pozitív értékeket tud megjeleníteni. Ellenőrizze az adatokat, mielőtt engedélyezi. Ha a nulla vagy negatív értékek jelentősek, használjon lineáris skálát vagy jelenítse meg őket külön. Ha az értékek kizárása megfelelő az elemzéshez, magyarázza el az elhagyás okát. Ne helyettesítse őket csendben kis pozitív számokkal, mivel ez megváltoztatja az adatok jelentését. Bármely manuálisan beállított minimum vagy maximum logaritmikus tengelyen szintén pozitívnak kell lennie.

## **FAQ**

**Hogyan állíthatom be azt az értéket, ahol egy tengely keresztezi a másikat (tengelykereszt?)?**

Használja a [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) metódust a keresztezési viselkedés kiválasztásához. Numerikus keresztezési érték megadásához állítsa be a [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) értékét. Ezek a beállítások lehetővé teszik a tengelykereszt elhelyezését egy megfelelő alapvonalra.

**Hogyan helyezhetem el a jelölőcímkéket a tengelyhez viszonyítva?**

Állítsa be a [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) értékét a [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/) segítségével: `Low`, `High`, `NextTo` vagy `None`. A jelölővonalak vezérléséhez használja a [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) vagy a [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/) beállításokat; ezek különállóak a címke pozicionálástól.