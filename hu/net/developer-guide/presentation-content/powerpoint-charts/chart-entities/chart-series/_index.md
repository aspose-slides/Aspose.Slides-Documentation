---
title: Diagram sorozatkezelés prezentációkban .NET
linktitle: Adatsorozatok
type: docs
url: /hu/net/chart-series/
keywords:
- diagram sorozat
- sorozat átfedés
- sorozat szín
- kategória szín
- sorozat neve
- adatpont
- sorozat rés
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a diagram sorozatokat, adatpontokat, munkafüzetcellákat, formázást, átfedést, részsávszélességet és negatív értékeket a prezentációkban C#-val."
---
## **Áttekintés**

Egy diagram tárolhatja ábrázolt értékeit munkafüzetcellákban vagy közvetlenül numerikus literálokként. Az [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) egy kapcsolódó értékkészletet képvisel, és minden [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) egy pontot jelöl ebben a sorozatban. Az [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosító értékeket biztosítják. Az alapértelmezett adatokkal létrehozott diagramokban a sorozatnevek, kategóriák és pontértékek az [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) objektumokból származnak a diagram munkafüzetéből.

Egy tipikus kategória diagram esetén az alapértelmezett munkafüzet a 0‑s sort a sorozatneveknek, a 0‑s oszlopot a kategórianevnek, a maradék cellákat pedig a sorozatértékeknek használja. A [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) számára átadott munkalap-, sor- és oszlopszámok nullától indulnak. Ez a felépítés akkor hasznos, amikor alapértelmezett adatokkal hoz létre diagramot, de nem szabad azt feltételezni, hogy minden létező diagram ezt a szerkezetet használja. Betöltött prezentáció esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt módosítaná a munkafüzet értékeit.

A diagrambeállítások három különböző hatókörben léteznek:

- Sorozatszintű beállítások, például az [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) a sorozat minden pontjának alapértelmezett megjelenését adja meg.
- Adatpont-szintű beállítások, például az [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) felülírja a sorozat megjelenését egyetlen pontra.
- Csoportbeállítások olyan kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz az [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) tartoznak. A csoportot a [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) segítségével érheti el, ha például átfedés vagy részsáv szélesség beállítására van szükség.

Ha nem állít be explicit kitöltést sem a pontok, sem a sorozat számára, a diagram stílusa és témája határozza meg a automatikus megjelenést. Ha mind a sorozat, mind a pont formázása meg van adva, a pont formázása felülbírálja a sorozatét az adott pontnál.

![diagram-sorok](chart-series-powerpoint.png)

## **Sorértékek beállítása numerikus literálokkal**

Használjon numerikus literálokat, amikor a sorozatértékek az alkalmazás adataiból vagy számításaiból származnak, és nem szükséges munkalap‑cellahivatkozás. Állítsa be a [DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/) értékét [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/)‑re, mielőtt minden pont [Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/) tulajdonságát az [AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/) segítségével adná meg.

A gyűjteménybeállítás szabályozza az összes pont értékforrás‑típusát a sorozatban. Minden pont [Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/) attribútuma jelzi a kiválasztott típust; ezt a gyűjteménybeállítással módosíthatja. `Worksheet` esetén használja az [AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/) metódust a hivatkozott cellához való hozzáféréshez. `DoubleLiterals` esetén az `AsLiteralDouble` segítségével olvashatja vagy írhatja a számot közvetlenül.

Az alábbi példa oszlopdiagramot hoz létre alapértelmezett sorozattal és kategóriákkal, majd a saját sorozata első sorozatának meglévő pontjaira 10, 20 stb. számított értékeket rendel. Ezután menti a prezentációt, újra megnyitja, és kiírja a tárolt értékeket.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;
for (var i = 0; i < series.DataPoints.Count; i++)
{
    series.DataPoints[i].Value.AsLiteralDouble = (i + 1) * 10;
}

presentation.Save("numeric_literals.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("numeric_literals.pptx");
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedChart = (IChart)reopenedSlide.Shapes[0];
var reopenedSeries = reopenedChart.ChartData.Series[0];
foreach (var point in reopenedSeries.DataPoints)
{
    Console.WriteLine(point.Value.AsLiteralDouble);
}
```

A pontérték-forrás típusa különbözik az [IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/) beállítástól, amely a diagram belső vagy külső munkafüzet‑konfigurációját jelöli. A numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet. Ebben a példában a munkafüzet továbbra is elérhető a kategória‑címkék, sorozatnevek és a többi sorozat számára. A munkafüzet‑kezeléshez tekintse meg a [Diagram munkafüzet](/slides/hu/net/chart-workbook/) oldalt.

Szórt és buborék diagramok esetén állítsa be a [DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/) és a [DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/) értékeket, hogy kiválassza a forrásokat az [XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/) és [YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) számára. A buborék diagramok a [DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/) segítségével határozzák meg a [BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/) forrását. Állítsa be a megfelelő forrásokat `DoubleLiterals`‑re, mielőtt a `AsLiteralDouble` tulajdonságon keresztül számokat rendelne.

## **Diagram sorozat átfedésének beállítása**

Az [IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) azt mutatja, hogy a 2D diagramon a sávok vagy oszlopok mennyire fednek át egymást, -100‑tól 100‑ig terjedő százalékban. Ez a szülő sorozatcsoport beállításának csak olvasható leképezése. A [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) módosításával frissítheti a csoportban lévő összes kompatibilis sorozatot. Ez a lehetőség a csoportos sávok vagy oszlopok megjelenítésére szolgáló diagramtípusokra vonatkozik; a kombinált diagramokban nem kapcsolódó sorozatcsoportokat nem befolyásolja.

Az alábbi példa beállítja az átfedést a csoport számára, amely az első sorozatot tartalmazza:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// Az új diagram minta sorozatokat, kategóriákat és értékeket tartalmaz.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A sorozat átfedése](series_overlap.png)

## **Sorozat kitöltőszín módosítása**

Használja az [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) metódust az egész sorozat alapértelmezett kitöltésének beállításához. Ha egy pont már rendelkezik explicit kitöltéssel, annak az [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) beállítása felülírja a sorozat kitöltését az adott pontnál.

Az alábbi példa szilárd kék kitöltést alkalmaz az első sorozatra:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Blue;

presentation.Save("series_color.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A sorozat színe](series_color.png)

## **Sorozat nevének módosítása**

A sorozat neve a diagram adatmunkafüzetében tárolódik, és általában a jelmagyarázatban jelenik meg. Egy klaszterezett oszlopdiagram alapértelmezett munkafüzetében a B1 cella (0‑s sor, 1‑s oszlop) tartalmazza az első sorozat nevét. Az alábbi példában a névkonstansok ezt a szerkezetet teszik egyértelművé:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesNameCell = workbook.GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

A [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/) által már hivatkozott cellát is frissítheti. Ezzel a megközelítéssel nem kell egy konkrét sorra és oszlopra támaszkodni egy meglévő diagram esetében:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var seriesNameCell = series.Name.AsCells[firstNameCellIndex];
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A sorozat neve](series_name.png)

### **Sorozat létrehozása több cellából származó névvel**

Összetett sorozatnév akkor hasznos, ha a termék neve és a jelentési időszak külön munkafüzet‑cellákban van tárolva. Például a `Product A` értéket a B1‑ben és a `2026` értéket a C1‑ben egyetlen sorozatnévvé kombinálhatja, miközben mindkét rész megmarad a forráscellához kapcsolódva.

Használja a [IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) metódust a névtartomány lekéréséhez, majd adja át ezt a gyűjteményt a [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/) hívásnak. A `skipHiddenCells` argumentum határozza meg, hogy a rejtett cellák szerepeljenek‑e: `true` kizárja őket, `false` pedig belefoglalja. Az alábbi példa `false`‑t használ, hogy a névtartomány minden celláját belevegye.

Az alábbi példa egy prezentációt hoz létre egy sorozattal és két adatponttal. A B1:C1 tartomány csak a sorozat nevét adja meg; az A2:A3 a kategóriacímkéket, a B2:B3 pedig a numerikus értékeket.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
chart.HasLegend = true;

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Ez a két cella adja meg a sorozat nevét.
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// Különálló cellák biztosítják a kategóriákat és a numerikus adatpontokat.
var northCategory = workbook.GetCell(0, 1, 0, "North");
var southCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(northCategory);
chart.ChartData.Categories.Add(southCategory);
var northValue = workbook.GetCell(0, 1, 1, 120);
var southValue = workbook.GetCell(0, 2, 1, 150);
series.DataPoints.AddDataPointForBarSeries(northValue);
series.DataPoints.AddDataPointForBarSeries(southValue);

presentation.Save("composite_series_name.pptx", SaveFormat.Pptx);
```

Az eredményül kapott sorozatnév `Product A 2026`, a két cellaérték között szóköz van. A jelmagyarázat egyetlen bejegyzésként jeleníti meg mindkét oszlopot. Az alábbi kép a mentett prezentációból került előállításra:

![Oszlopdiagram Észak és Dél értékekkel, valamint a `Product A 2026` összetett sorozatnévvel a jelmagyarázatban](composite_series_name.png)

## **Automatikus sorozatkitöltő szín lekérdezése**

Az [IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) visszaadja a sorozat indexe és a diagram stílusa alapján kiszámított színt. Ez a szín akkor kerül felhasználásra, amikor a sorozat kitöltése nincs explicit módon definiálva. A metódus csak a kiszámított színt olvassa; nem állít be új kitöltést.

Az alábbi példa kiírja az alapértelmezett sorozatok automatikus színét:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

const int firstSlideIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var seriesCount = chart.ChartData.Series.Count;
for (var seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    var automaticColor = series.GetAutomaticSeriesColor();
    Console.WriteLine($"Series {seriesIndex}: {automaticColor.Name}");
}
```

Példa kimenet az alapértelmezett diagramstílushoz:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

A pontos színek a diagram stílusától és témájától függnek.

## **Negatív értékek inverz kitöltőszínének beállítása egy diagram sorozathoz**

Sáv‑, oszlop‑ és buborék‑sorozatok esetén az [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) lehetővé teszi, hogy a negatív értékek másik kitöltéssel jelenjenek meg. Állítsa be a normál sorozatkitöltést szilárd színre, aktiválja az inverziót, és a negatív érték színét az [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) segítségével adja meg. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük módosul.

Az alábbi példa a meglévő diagramadatokat egyetlen sorozattal helyettesíti. A munkalap 0‑s sora a sorozat nevét, a 0‑s oszlop a kategórianevet, az 1‑s oszlop pedig az értékeket tartalmazza:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;

var categoryNames = new[] { "Category 1", "Category 2", "Category 3" };
var seriesValues = new[] { -20, 50, -30 };

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
var series = chartData.Series.Add(seriesNameCell, chart.Type);

for (var categoryIndex = 0; categoryIndex < categoryNames.Length; categoryIndex++)
{
    var dataRowIndex = firstDataRowIndex + categoryIndex;
    var categoryName = categoryNames[categoryIndex];
    var seriesValue = seriesValues[categoryIndex];

    var categoryCell = workbook.GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
    chartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertIfNegative = true;
series.InvertedSolidFillColor.Color = Color.Red;

presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
```

Az eredmény:

![Inverz szilárd kitöltőszín](inverted_solid_fill_color.png)

Az inverzió egyetlen pontra is engedélyezhető az [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) segítségével. Az alábbi példában a sorozat inverziója ki van kapcsolva, míg csak a kiválasztott pont esetében van engedélyezve. A pontnak negatív értéket is adunk, hogy a hatás látható legyen:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertedSolidFillColor.Color = Color.Red;
series.InvertIfNegative = false;

var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = negativeValue;
dataPoint.InvertIfNegative = true;

presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
```

## **Egy adott adatpont értékének törlése**

Egy pont üresen hagyásához, a többi pont eltávolítása nélkül, állítsa be a mögöttes munkafüzetcellát `null`‑ra. Oszlopdiagram esetén a rajzolt érték a [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) segítségével érhető el. Az adatpont ugyanazon kategóriapozícióban marad, de a diagram a beállításai szerint üres értékként kezeli.

Az alábbi példa csak a második pontot törli az első sorozatban:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = null;

presentation.Save("clear_data_point_value.pptx", SaveFormat.Pptx);
```

Szórt diagramok külön X és Y cellákat használnak, a buborék diagramok pedig egy méretcellát is. Csak azt a cellát törölje, amely a eltávolítani kívánt értéket tartalmazza. Ne hívja meg az [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) metódust, ha a többi pontot megtartja, mivel ez a metódus az egész gyűjteményt törli.

## **Üres cellák megjelenítésének szabályozása**

A rejtett, de értékkel rendelkező cellák külön esetet jelentenek az üres celláktól. A rejtett munkalap‑sorok és -oszlopok adatait be vagy ki kell venni, erről olvasson a [Include Data from Hidden Rows and Columns](/slides/hu/net/chart-workbook/#include-data-from-hidden-rows-and-columns) cikkben.

Egy üres munkafüzetcellát hiányzó adatként kezelünk; a `0`‑t tartalmazó cella ismert numerikus értéket jelent. Az [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) beállításával `null`‑ra teheti a cellát üressé. A numerikus nulla marad nulla, függetlenül az üres‑cellás beállítástól.

Az [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) segítségével választhatja ki, hogy a diagram hogyan jelenítse meg az üres cellákat. Ez a beállítás a teljes diagramra vonatkozik, és módosítja, hogy a hiányzó értékek hogyan kerülnek ábrázolásra, anélkül, hogy a munkafüzet‑cellát nullával vagy interpolált értékkel töltené fel.

Az alábbi önálló példa egy vonaldiagramot hoz létre egy sorozattal, törli a 3‑as nap értékét, és minden módot külön‑külön ment el. Bemeneti fájlra nincs szükség. Az [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) 0‑s munkalapot használ, az 0‑s oszlopot a kategóriacímkéknek, az 1‑s oszlopot pedig az értékeknek; a 0‑s sor a sorozat nevét tartalmazza. A végső adatsor `10, 20, empty, 30, 40`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(0, 0, 1, "Measurements");
var series = chartData.Series.Add(seriesNameCell, chart.Type);
var values = new[] { 10, 20, 25, 30, 40 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Day {i + 1}");
    chartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Leave Day 3 genuinely empty, while retaining its category and data point.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

Minden kimeneti fájl a mentés előtti módot tárolja: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, és `empty_cells_Span.pptx`. Ha csak egy verziót kíván menteni, állítsa be a kívánt módot, és egyszer mentse a prezentációt a módok ciklikus mentése helyett.

Az alábbi összehasonlítás mindhárom fájlban ugyanazt az adatot mutatja. A 3‑as nap minden esetben üres a munkafüzetben:

![Vonaldiagramok azonos adatokkal: a Gap a vonalat szakadékra vágja a 3‑as napnál, a Zero a vonalat nullára süllyeszti, a Span összeköti a 2‑as és 4‑es napot.](display_blanks_as.png)

A látható hatás a diagramtípustól függ. Egy vonaldiagram esetén a három mód könnyen összehasonlítható. Sáv‑ és oszlopdiagramok esetén nincs vonal, amely összekötné a hiányzó kategóriát, így a `Span` nem tudja megjeleníteni a fenti összekötő szegmenst; egy hiányzó oszlop és egy nulla‑magasságú oszlop is hasonlóan nézhet ki. Hasonlóképpen, egy szórt diagram marker‑ekkel csak a pontokat jeleníti meg, így vonal nélküli. Ne számítson három különböző eredményre minden diagramtípusnál; ellenőrizze a saját típusához tartozó kimenetet.

## **Sorozat részsávszélesség beállítása**

A részsávszélesség a szomszédos sáv‑ vagy oszlopcsoportok közötti távolságot jelenti, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez is a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Állítsa be egyszer a [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) értékét a csoporton. A nagyobb érték nagyobb távolságot hoz létre a csoportok között; a kisebb érték sűrűbb elrendezést eredményez.

Az alábbi példa módosítja a részsávszélességet, és csak a végső prezentációt menti el:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int gapWidthPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.GapWidth = gapWidthPercent;

presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A részsávszélesség](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják az adat sorozatokat?**

Az összes, a [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) felsorolásban szereplő diagramtípus használ diagramadatokat, de sorozataik nem ugyanazt a szerkezetet vagy beállításokat tartalmazzák. Például a kategória diagramok kategóriákat és értékeket használnak, a szórt diagramok X és Y értékeket, a buborék diagramok pedig buborékméreteket. A sorozattípusnak megfelelő adatpont‑létrehozási módszert használja. Az átfedés és részsávszélesség opciók csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

Az [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös, csoportszintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több csoportot is tartalmazhat, ezért egy sorozaton keresztül elérhető csoport módosítása nem feltétlenül változtatja meg a diagram minden sorozatát.

**A frissen létrehozott diagram alapértelmezett adatokat tartalmaz?**

Igen. Alapértelmezés szerint az [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy a sorozat‑ és kategória‑gyűjteményeket is törölheti, mielőtt teljesen egyedi adatot adna hozzá. Egy túlterhelés (overload) segítségével elkészíthető diagram alapértelmezett adatok nélkül is.

**Hogyan kapcsolódnak a diagramobjektumok a munkafüzetcellákhoz?**

A sorozatnevek, kategóriacímkék és adatpont‑értékek egy [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagramelemet. Amikor egyedi adatot épít fel, tartsa összehangoltan a kategóriasorokat és a sorozat‑érték sorokat, hogy minden pont a megfelelő kategória alatt jelenjen meg.

**Hogyan töröljek egy pontot a teljes sorozat helyett?**

Állítsa a megfelelő értékcellát `null`‑ra, így a pont kategóriapozíciója üres pontként marad meg. Az [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) metódust csak akkor használja, ha valóban az összes pontot el kívánja távolítani a sorozatból. Ha a kategóriákat is eltávolítja, minden sorozatot frissítenie kell, hogy az értékeik továbbra is illeszkedjenek a kategóragyűjteményhez.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagramtípustól és az [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) beállítástól függ. A támogatott diagramok megjeleníthetik az üres helyeket szünetként, nullaként vagy a szomszédos pontok összekötésével. Válassza ki azt a beállítást, amely a hiányzó adat jelentését legjobban tükrözi a prezentációjában. Lásd a [Üres cellák megjelenítésének szabályozása](#control-the-display-of-empty-cells) részt a teljes példáért és vizuális összehasonlításért.

**Hogyan formázzák a negatív értékeket?**

A támogatott sáv‑, oszlop‑ és buborék‑sorozatok esetén engedélyezze az [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) beállítást, és állítsa be az [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) tulajdonságot a negatív‑érték színére. Egy adott pontnál az [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) segítségével felülírhatja ezt a viselkedést. Ezek a tulajdonságok a formázást befolyásolják, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha egy sorozat és egy pont is formázva van?**

Az explicit adatpont‑formázás felülbírálja a sorozat formázását az adott pontnál. A többi pont továbbra is az explicit sorozatformátumot vagy, ha az nincs definiálva, az automatikus diagramstílust és témát használja. A csoport‑tulajdonságok, mint az átfedés és a részsávszélesség, az elrendezést szabályozzák, és nem pont‑szintű formázási felülírások.

**Van korlátozás a diagramban szereplő sorozatok számát illetően?**

Az Aspose.Slides nem alkalmaz külön, fix sorozatszám‑korlátot. Gyakorlatban a prezentációfájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos felső határt.

**Mit kell módosítanom, ha a oszlopok túl közel vagy túl távol vannak egymástól?**

Állítsa be a [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) értékét a megfelelő szülő sorozatcsoporton. A nagyobb érték szélesíti a csoportok közötti távolságot, a kisebb érték pedig közelebb hozza a csoportokat.