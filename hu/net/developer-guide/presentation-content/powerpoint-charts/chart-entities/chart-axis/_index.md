---
title: Diagram tengelyek testreszabása PowerPoint bemutatókban .NET-ben
linktitle: Diagramtengely
type: docs
url: /hu/net/chart-axis/
keywords:
- diagram tengely
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
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel, hogyan használhatja az Aspose.Slides for .NET-et a diagram tengelyek testreszabásához PowerPoint bemutatókban jelentések és vizualizációk számára."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a diagram tengelyeit az Aspose.Slides for .NET segítségével. Tárgyalja a kiszámított tengelyértékeket, a diagram sorok és oszlopok átváltását, a tengely láthatóságát, a kategóriacímke- és jelölőjel-intervalumokat, a dátumkategóriákat és formázást, a cím forgatását, a tengely elhelyezését, valamint a megjelenítési egységeket.

## **A maximális értékek lekérése a függőleges tengelyen a diagramokban**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) és adjon hozzá egy területdiagramot alapértelmezett adatokkal. Hívja meg a [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) előtt a kiszámított tengelyértékek olvasása előtt, hogy a diagramelrendezés naprakész legyen.

Olvassa ki az [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) és [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) értékeket a tengely határakhoz, valamint az [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) és [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) értékeket a jelölőjel-intervalumokhoz. Az [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) és [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) időegység-skálákat adnak, amelyek a dátumtengelyeknél relevánsak. A példában ezek az értékek helyi változókba kerülnek, majd a diagram mentésre kerül.

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

## **Az adatok felcserélése a tengelyek között**

Használja a [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) metódust a sorozatok és kategóriák szerepének felcseréléséhez a diagram adataiban. Minden korábbi kategória sorozattá, minden korábbi sorozat pedig kategóriává válik. Ez a csoportosítást változtatja meg; nem cseréli fel a vízszintes és függőleges tengelyeket. A példa a [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) metódust használja az alapértelmezett adatok a `Sheet1!A1:D5` tartományra kötéséhez, beleértve a fejlécsort és a kategóriakolumnát, mielőtt a sorokat és oszlopokat átváltaná. Egy négy sorozatú és három kategóriás diagram mentésre kerül.

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

## **A függőleges tengely letiltása vonaldiagramoknál**

Állítsa az [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) tulajdonságot `false` értékre a függőleges tengelyen a rejtéséhez. A példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, és a függőleges tengely elrejtésével menti el.

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

Állítsa az [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) tulajdonságot `false` értékre a vízszintes tengelyen a rejtéséhez. A példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, és a vízszintes tengely elrejtésével menti el.

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

Állítsa a [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) tulajdonságot egy dátum- vagy szöveges kategóriatengely kiválasztásához. Ez a példa a `ExistingChart.pptx` fájlt igényli, amelynek első diáján az első alakzat egy diagram, és a kategóriacellák numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt egy dátumtengellyé változtatja. Az [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) `false`, a [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) `1`, és a [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) `Months` beállítás havonta egy fő jelölőt helyez el.

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

## **Kategóriatengely címkel intervallumok vezérlése**

Amikor egy diagram sok kategóriát tartalmaz, csökkentheti a látható tengelycímkék számát anélkül, hogy a kategóriákat vagy az adatpontokat eltávolítaná. Állítsa az [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) tulajdonságot `false` értékre, majd a [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) értékét a kívánt kategória-intervalumra. Szöveges kategóriák esetén a számozás az első kategóriától indul:

| Intervallum | A példában megjelenített címkék |
| --- | --- |
| `1` | Kategória 1, Kategória 2, Kategória 3, ... Kategória 24 |
| `2` | Kategória 1, Kategória 3, Kategória 5, ... Kategória 23 |
| `3` | Kategória 1, Kategória 4, Kategória 7, ... Kategória 22 |

A `3` intervallum minden harmadik címkét jelenít meg, a megjelenített címkék között két címke rejtve marad. Nem távolítja el a megfelelő oszlopokat. Az automatikus távolság a rendelkezésre álló hely alapján választ intervallumot; nem feltétlenül jeleníti meg az összes címkét.

A jelölőjelnek külön vezérlése van. Állítsa az [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) tulajdonságot `false` értékre, és a [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) segítségével állítsa be az intervallumukat. Például az `1` minden kategória-intervalumra helyez el egy jelölőjelet, míg a címkék csak minden harmadik kategórián jelennek meg. Állítson be egy látható [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) stílust, hogy lássa az eredményt. Bármelyik automatikus távolságot szabályozó tulajdonság visszaállítása `true` értékre lehetővé teszi, hogy a diagram újra a saját intervallumát válassza.

A következő önálló példa 24 kategóriát és egy sorozatot hoz létre, majd három diát ment el a `CategoryAxisIntervals.pptx` fájlba: automatikus távolság, kézi címke-intervalum független jelölőjelekkel, és visszaállított automatikus távolság. A két másolat az eredeti diagramadatokat tartja meg. Bemutató bemenet nem szükséges. A vízszintes címkeszöveg megkönnyíti a sűrűség látványát.

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

// Diapozitív 2: minden harmadik címkét jelenítse meg, de minden kategóriához tartson meg egy jelölőjelet.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Diapozitív 3: engedje, hogy a diagram újra kiválassza mindkét intervallumot.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**Automatikus távolság (1. dia):** Ebben a megjelenítésben minden második kategóriacímke látható, és két sorba törik. Az automatikus eredmény a diagram méretétől, betűtípusaiktól és a renderertől függően változhat.

![Automatikus kategóriacímke elrendezés az összes 24 oszlop látható állapotban](category-axis-automatic.png)

**Manuális távolság (2. dia):** Minden harmadik címke egy sorban jelenik meg, míg a jelölőjelek minden kategória-intervalumban maradnak. Az összes 24 oszlop, beleértve a címkék nélküli oszlopokat is, ugyanazzal az értékkel látható. A 3. dia visszaállítja a fenti automatikus megjelenést.

![Manuális kategóriacímke intervallum hárommal, az összes 24 oszlop látható állapotban](category-axis-manual.png)

### **A megfelelő tengely és intervallum kiválasztása**

Használja ezt a kategória-számlálási intervallumot egy szöveges kategóriatengelyhez, például egy oszlop-, vonal-, terület- vagy oszlopdiagram kategóriatengelyéhez. Oszlopdiagram esetén ez a vízszintes tengely. Vízhorizontális oszlopdiagramnál a kategóriatengely függőleges, ezért ezeket a beállításokat a [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) tulajdonságra alkalmazza. A jelölőjel-távolság a sorozattengelyekre is vonatkozik a több tengelyes diagramokban.

Ne használja a kategóriacímke-távolságot az értéktengely numerikus skálájának beállítására. Az értéktengelyen a [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) az értékek közti különbséget határozza meg: például a `10` fő egység 0, 10, 20 stb. jelölőket eredményez, ha a tengely nulláról indul. A `3` kategóriacímke-intervalum ehelyett a kategóriahelyeket számolja, az adatértékektől függetlenül. Szórt és buborék diagramok értéktengelyeket használnak, nem szöveges kategóriatengelyt. Dátumtengely esetén használjon időalapú fő egységeket és skálákat, ahogy azt a [Kategóriatengely módosítása](#change-a-category-axis) részben leírták.

## **Dátumformátum beállítása a kategóriatengely értékekhez**

A példa a alapértelmezett diagramadatokat négy éves értékkel helyettesíti. A dátumok OLE Automation sorozatszámként tárolódnak az első munkalapon (index `0`). Állítsa a [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) értékét dátumtengellyé, tiltsa le az [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) beállítást, és az `yyyy` értéket adja a [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) tulajdonságnak, hogy a kategóriacímkék a cellaformázástól függetlenül négyjegyű éveket jelenítsenek meg.

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

## **Forgatási szög beállítása a diagramtengely címéhez**

Engedélyezze a [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) tulajdonságot a függőleges tengelyen, adja meg a címszöveget, és állítsa be a [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) értékét a cím forgatásához. A szög fokban van megadva; ez a példa egy oszlopdiagramot ment el, amelynek az érték-tengely címe 90 fokban van elforgatva.

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

## **A tengely pozíciójának beállítása egy kategória vagy értéktengelyen**

Használja az [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) tulajdonságot annak szabályozására, hogy az értéktengely a kategóriatengelyet a kategóriák között vagy a kategória jelölőjeleknél metszze. Ez a tulajdonság a kategóriatengelyekre vonatkozik. A példa a vízszintes kategóriatengelyen `true` értékre állítja ezt a tulajdonságot egy oszlopdiagram esetén, és elmenti az eredményt.

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

## **A megjelenítési egység beállítása egy diagram értéktengelyén**

Állítsa a [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) értékét a értéktengely címkéinek skálázásához anélkül, hogy az adatot módosítaná. A [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) `Millions` beállításakor a 60 000 000 érték 60‑ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a függőleges tengelyen a milliók megjelenítési egységét alkalmazza.

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

## **GYIK**

**Hogyan állítható be az a érték, ahol az egyik tengely keresztezi a másikat (tengelykereszt)?**  
Használja a [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) metódust a keresztelés viselkedésének kiválasztásához. Numerikus keresztérték megadásához állítsa be a [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) tulajdonságot. Ezek a beállítások lehetővé teszik a tengelykereszt megfelelő alapvonalra való mozgatását.

**Hogyan helyezhetem el a jelölőcímkéket a tengelyhez képest?**  
Állítsa be a [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) tulajdonságot a [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/) segítségével: `Low`, `High`, `NextTo` vagy `None`. A jelölőjelek saját szabályozásához használja a [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) vagy a [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/) tulajdonságot; ezek különállóak a címke elhelyezésétől.