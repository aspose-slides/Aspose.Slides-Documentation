---
title: Diagramtengelyek testreszabása .NET prezentációkban
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
- max érték
- min érték
- tengelyvonala
- dátumformátum
- tengelycím
- tengelypozíció
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel, hogyan használhatja az Aspose.Slides for .NET-et a diagramtengelyek testreszabásához PowerPoint prezentációkban jelentések és vizualizációk készítéséhez."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a diagram tengelyeit az Aspose.Slides for .NET használatával. Tárgyalja a kiszámított tengelyértékeket, a diagram sorok és oszlopok cseréjét, a tengely láthatóságát, a kategória címke és a jelölő intervallumokat, a dátum kategóriákat és formázásukat, a cím forgatását, a tengely elhelyezkedését, a megjelenítési egységeket és a logaritmikus skálázást.

## **Maximum értékek lekérése a függőleges tengelyen diagramoknál**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) elemet, és adjon hozzá egy területdiagramot az alapértelmezett adatokkal. Hívja meg a [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) metódust a számított tengelyértékek olvasása előtt, hogy a diagram elrendezése naprakész legyen.

Olvassa el a [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) és a [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) értékeket a tengely határain, valamint a [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) és a [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) értékeket a jelölő intervallumokhoz. Az [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) és az [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) időegység skálákat adnak vissza, amelyek a dátumtengelyekhez relevánsak. A példa ezeket az értékeket helyi változókba menti, majd elmenti a diagramot.

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

## **Adatok cseréje a tengelyek között**

Használja a [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) metódust a sorozatok és kategóriák szerepének felcseréléséhez a diagram adataiban. Minden korábbi kategória sorozattá, minden korábbi sorozat pedig kategóriává válik. Ez megváltoztatja az adatok csoportosítását; nem cseréli fel a vízszintes és függőleges tengelyeket. A példa a [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) metódussal köti az alapértelmezett adatokat a `Sheet1!A1:D5` tartományra, beleértve a fejlécsort és a kategória oszlopot, mielőtt sorokat és oszlopokat cserélne. Egy négy sorozatos és három kategóriás diagramot ment.

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

Állítsa a [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) tulajdonságot `false` értékre a függőleges tengelyen, hogy elrejtse azt. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, és elmenti a függőleges tengely elrejtett állapotban.

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

Állítsa a [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) tulajdonságot `false` értékre a vízszintes tengelyen, hogy elrejtse azt. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, és elmenti a vízszintes tengely elrejtett állapotban.

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

## **Kategória tengely módosítása**

Állítsa a [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) tulajdonságot a dátum vagy szöveg kategória tengely kiválasztásához. Ez a példa a `ExistingChart.pptx` fájlt igényli, amelynek első diájának első alakja egy diagram, és a kategória cellák numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt dátumtengellyé változtatja. A [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) beállítása `false`, a [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) `1`, valamint a [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) `months` beállítása havi fő jelölőket helyez el.

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

## **Kategória tengely címke intervallumok szabályozása**

Amikor egy diagram sok kategóriát tartalmaz, csökkenthető a látható tengelycímkék száma a kategóriák vagy adatpontok eltávolítása nélkül. Állítsa a [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) tulajdonságot `false` értékre, majd állítsa be a [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) értékét a kívánt kategória intervallumra. Szöveges kategóriák esetén, a normál sorrendben, a számozás az első kategóriától indul:

| Intervallum | Példában megjelenő címkék |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

A `3` intervallum minden harmadik címkét jelenít meg, a megjelenő címkék között két címke rejtve marad. Nem távolítja el a megfelelő oszlopokat. Az automatikus távolság a rendelkezésre álló hely alapján választ intervallumot; nem feltétlenül jeleníti meg az összes címkét.

A jelölővonalak külön vezérelhetők. Állítsa az [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) tulajdonságot `false` értékre, és használja a [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) beállítást az intervallum meghatározásához. Például a `1` érték minden kategória intervallumra jelölővonalat helyez el, míg a címkék csak minden harmadik kategórián jelennek meg. Állítsa a [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) tulajdonságot látható stílusra, hogy látható legyen az eredmény. Bármelyik automatikus távolságot visszaállítva `true` értékre, a diagram újból kiválasztja az intervallumot.

Az alábbi önálló példa 24 kategóriát és egy sorozatot hoz létre, majd három diát ment a `CategoryAxisIntervals.pptx` fájlba: automatikus távolság, kézi címke távolság független jelölővonalakkal, és visszaállított automatikus távolság. A két másolat az eredeti diagram adatokat tartja meg. Bemutató prezentációra nincs szükség. A vízszintes címke szöveg megkönnyíti a sűrűség különbségének észlelését.

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

// Dia 2: mutassa minden harmadik címkét, de minden kategóriához tartsa meg a jelölővonalat.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Dia 3: engedje, hogy a diagram újra kiválassza a két intervallumot.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**Automatikus távolság (1. dia):** Ebben a megjelenítésben minden második kategória címke látható, és két sorra kerül tördelve. Az automatikus eredmény a diagram méretétől, betűtípusától és a renderertől függően változhat.

![Automatikus kategória címke távolság, minden 24 oszlop látható](category-axis-automatic.png)

**Kézi távolság (2. dia):** Minden harmadik címke egy sorban jelenik meg, míg a jelölővonalak minden kategória intervallumra megmaradnak. Az összes 24 oszlop, beleértve a címkék nélküli oszlopokat is, látható ugyanazokkal az értékekkel. A 3. dia visszaállítja a fenti automatikus kinézetet.

![Kézi kategória címke intervallum, három, minden 24 oszlop látható](category-axis-manual.png)

### **A megfelelő tengely és intervallum kiválasztása**

Használja ezt a kategória számláló intervallumot szöveges kategória tengely esetén, például oszlop-, vonal-, terület- vagy sávdiagramnál. Oszlopdiagram esetén ez a vízszintes tengely. Vízszintes sávdiagram esetén a kategória tengely függőleges, ezért ezeket a beállításokat a [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/)-ra alkalmazza. A jelölővonalak távolsága egy sorozat tengelyre is vonatkozik az egyetlen tengelyes diagramoknál.

Ne használja a kategória címke távolságot a numerikus értéktengely skálájának beállítására. Egy értéktengelyen a [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) egy értékkülönbséget határoz meg: például a `10` fő egység 0, 10, 20 stb. jelölőket eredményez, ha a tengely nulláról indul. A `3` kategória címke intervallum ezzel szemben a kategória pozíciókat számolja, függetlenül az adatok tényleges értékétől. Szórás- és buborékdiagramok értéktengelyt használnak, nem szöveges kategória tengelyt. Dátumtengely esetén használjon időalapú fő egységeket és skálákat, ahogyan a [Kategória tengely módosítása](#change-a-category-axis) részben leírtuk.

## **Dátumformátum beállítása a kategória tengely értékekhez**

A példa kicseréli az alapértelmezett diagram adatokat négy éves értékre. A dátumok OLE Automation sorozatszámként vannak tárolva az első munkafüzetben (index `0`). Állítsa a [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) tulajdonságot dátumtengellyé, kapcsolja ki az [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) beállítást, és állítsa a [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) értékét `yyyy`-re, hogy a kategória címkék négy számjegyű éveket mutassanak, függetlenül a cella formázásától.

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

## **Forgatási szög beállítása a diagram tengely címéhez**

Engedélyezze a [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) tulajdonságot a függőleges tengelyen, adjon meg cím szöveget, és állítsa be a [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) értékét a cím forgatásához. A szög fokban van megadva; ez a példa egy oszlopdiagramot ment el, amelynek értéktengely címe 90 fokkal van elforgatva.

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

Használja az [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) tulajdonságot annak szabályozására, hogy az értéktengely a kategória tengelyen a kategóriák között vagy a kategória jelölővonalaknál metssze át. Ez a tulajdonság csak kategória tengelyekre vonatkozik. A példa `true` értékre állítja ezt a beállítást egy oszlopdiagram vízszintes kategória tengelyén, majd elmenti az eredményt.

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

## **Megjelenítési egység beállítása diagram értéktengelyen**

Állítsa a [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) tulajdonságot a címkék skálázásához egy értéktengelyen anélkül, hogy az alapadatok megváltoznának. A [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) `Millions` értékre állítása esetén a 60 000 000 érték 60‑ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a függőleges tengelyen alkalmazza a milliók megjelenítési egységét.

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

A logaritmikus értéktengely hasznos, ha a pozitív értékek több nagyságrendi szinten helyezkednek el. Például egy szolgáltatás öt időszak alatt 10, 100, 1 000, 10 000 és 100 000 kérést kap. Lineáris skálán a kisebb értékek közel egymáshoz jelennek meg a nullához. A logaritmikus skála megkönnyíti a relatív növekedés összehasonlítását: az egyenlő távok egyenlő arányokat jelentenek, nem egyenlő különbségeket.

Állítsa a [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) tulajdonságot `true` értékre az értéktengelyen, és a [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) segítségével válassza ki az alapot. Ez megváltoztatja a meglévő értékek megjelenítését; az adatokat vagy a diagramot nem módosítja, és nem ad logaritmikus trendvonalat. A trendvonal egy külön funkció, amely a adatokhoz illesztett kapcsolatot jeleníti meg.

### **Az értéktengely és az alap kiválasztása**

Vonal- vagy oszlopdiagram esetén az értéktengely a [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Vízszintes sávdiagram esetén a [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). Szórás- és buborékdiagramok két értéktengellyel rendelkeznek, ezért a vízszintes tengelyt használja X‑értékekhez, a függőleges tengelyt Y‑értékekhez, vagy mindkettőt. Ne alkalmazzon logaritmikus skálázást kategória tengelyen.

Az alapértelmezett logaritmikus alap a `10`. PPTX diagramok esetén az alap 2‑től 1000‑ig terjedhet, beleértve a tört alapokat is, például `2.5`. A `10` alap esetén a sorozatos hatványok (10, 100, 1 000, 10 000) egyenlő távolságra helyezkednek el.

### **Lineáris és logaritmikus skála összehasonlítása**

Az alábbi önálló példa egy vonaldiagramot hoz létre az öt kérésszámmal az első dián, majd lemásolja azt, és a második dián alap‑10 logaritmikus értéktengelyt engedélyez. Mindkét dia ugyanazt az adatot tartalmazza.

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

// Tartsd az első diát lineárisnak, és csak a másolat értéktengelyének skáláját változtasd meg.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Lineáris skála (1. dia):** Az egyenlő függőleges távolságok az egyenlő kérésszám‑eltéréseket jelölik. A legnagyobb érték uralja a diagramot, így a kisebb értékek nehezen megkülönböztethetők.

![Vonaldiagram PowerPointban, öt kérésszám lineáris értéktengellyel](value-axis-linear.png)

**Logaritmikus skála (2. dia):** Az egyenlő függőleges távolságok egyenlő arányokat jeleznek. Minden periódus tízszer több kérést tartalmaz, mint az előző, így a pontok egy egyenes vonalat alkotnak az alap‑10 skálán. A tengelycímkék továbbra is az eredeti kérésszámokat mutatják.

![Ugyanaz az öt kérésszám PowerPointban, alap‑10 logaritmikus értéktengellyel](value-axis-logarithmic.png)

### **Nulla és negatív értékek kezelése**

A logaritmikus skála csak szigorúan pozitív értékeket képes megjeleníteni. Ellenőrizze az adatokat, mielőtt engedélyezi. Ha a nulla vagy negatív értékek jelentősek, használjon lineáris skálát, vagy jelenítse meg őket külön. Ha a kizárásuk megfelelő az elemzéshez, magyarázza el az okát. Ne cserélje le őket csendben kis pozitív számokra, mivel ez megváltoztatja az adatok jelentését. Bármely manuálisan beállított minimum vagy maximum logaritmikus tengelyen szintén pozitív kell legyen.

## **GYIK**

**Hogyan állítható be az a pont, ahol egy tengely keresztezi a másikat (tengelykeresztezés)?**

Használja a [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) beállítást a keresztelési viselkedés kiválasztásához. Numerikus keresztelési érték megadásához állítsa be a [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) tulajdonságot. Ezek a beállítások lehetővé teszik, hogy a tengelykeresztezést egy megfelelő alapvonalra helyezze.

**Hogyan pozicionálhatók a jelölőcímkék a tengelyhez viszonyítva?**

Állítsa be a [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) tulajdonságot a [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/) segítségével: `Low`, `High`, `NextTo` vagy `None`. A jelölővonalak szabályozásához használja a [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) vagy a [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/) tulajdonságokat; ezek különböznek a címke pozicionálásától.