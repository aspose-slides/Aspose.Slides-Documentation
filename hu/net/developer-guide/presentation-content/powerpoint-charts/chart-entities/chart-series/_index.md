---
title: Diagram adat-sorozatok kezelése prezentációkban .NET-ben
linktitle: Adatsorozat
type: docs
url: /hu/net/chart-series/
keywords:
- diagram sorozat
- sorozat átfedés
- sorozat szín
- kategória szín
- sorozat név
- adatpont
- sorozat hézag
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tanulja meg, hogyan kezelje a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket prezentációkban C#-ban."
---
## **Áttekintés**

A diagram tárolhatja a megjelenített értékeket a munkafüzet celláiban vagy közvetlenül numerikus literálokként. Egy [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) egy kapcsolódó értékkészletet képvisel, és minden [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) a sorozat egy pontját jelenti. Az [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosítási értékeket biztosítják. Az alapértelmezett adatokkal létrehozott diagramokban a sorozatnevek, kategóriák és pontértékek az [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) objektumokat használják a diagram munkafüzetéből.

Típikus kategóriadiagram esetén az alapértelmezett munkafüzet a 0‑s sort használja a sorozatnevekhez, a 0‑s oszlopot a kategórianevekhez, a többi cellát pedig a sorozatértékekhez. A [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/)‑nek átadott munkalap‑, sor‑ és oszlop‑indexek nullával kezdődnek. Ez a felépítés hasznos, ha alapértelmezett adatokkal hoz létre egy diagramot, de ne feltételezze, hogy minden meglévő diagram ezt használja. Betöltött prezentáció esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzet értékeit módosítaná.

A diagram beállításainak három különböző hatóköre van:

- Sorozatszintű beállítások, például az [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) biztosítja az alapértelmezett megjelenést egy sorozat minden pontjához.
- Adatpont‑szintű beállítások, például az [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) felülírja a sorozat megjelenését egy adott pontra.
- Csoportbeállítások a kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz az [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) tartoznak. A csoportot az [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/)‑on keresztül érheti el, ha olyan beállításokat kell megadnia, mint az átfedés vagy a hézagszélesség.

Ha nincs kifejezetten beállítva pont‑ vagy sorozat‑kitöltés, a diagram stílusa és témája határozza meg az automatikus megjelenést. Ha mindkettő (sorozat‑ és pontformázás) jelen van, a pontformázás felülbírálja a sorozat formázását az adott pontnál.

![chart-series-powerpoint](chart-series-powerpoint.png)

Csoportos henger diagram esetén tekintse meg, hogy a [changing the 3D series type or bar shape](/slides/hu/net/3d-chart/#change-the-3d-series-type-and-bar-shape) hogyan befolyásolja az első sorozatot.

## **Sorozatértékek beállítása numerikus literálokkal**

Használjon numerikus literálokat, ha a sorozatértékek alkalmazásadatokból vagy számításokból származnak, és nem szükséges munkalap‑cellahivatkozás. Állítsa a [DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/)‑t [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/)‑ra, mielőtt minden pont [Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/)‑ját a [AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/)‑vel rendeli hozzá.

A gyűjtemény beállítása szabályozza az összes pont értékének forrástípussát ebben a sorozatban. Minden pont [Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/) jelentése a kiválasztott típust; változtassa meg a gyűjtemény beállításán keresztül. `Worksheet` esetén a [AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/)‑t használja a hivatkozott cellához. `DoubleLiterals` esetén az `AsLiteralDouble`‑ot használja a szám közvetlen be- vagy kiolvasásához.

Az alábbi példa oszlopdiagramot hoz létre alapértelmezett sorozatokkal és kategóriákkal, majd a saját sorozatának első sorozatában lévő meglévő pontokhoz rendeli a 10, 20 stb. számított értékeket. Elmenti a prezentációt, újra megnyitja, és kiírja a tárolt értékeket.

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

A pontérték forrástípusa elkülönül az [IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/)‑tól, amely a diagram belső vagy külső munkafüzet‑konfigurációját azonosítja. Numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet. Ebben a példában a munkafüzet továbbra is elérhető a kategóriacímkék, sorozatnevek és a többi sorozat számára. Tekintse meg a [Chart Workbook](/slides/hu/net/chart-workbook/) útmutatót a munkafüzet kezeléséről.

Szórt és buborék diagramok esetén állítsa a [DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/) és a [DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/) értékeket, hogy kiválassza az [XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/) és [YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) forrásait. A buborék diagramok a [DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/)‑t használják a [BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/) esetén. Állítsa az érintett forrást `DoubleLiterals`‑ra, mielőtt a `AsLiteralDouble`‑on keresztül számokat rendelne hozzá.

## **A diagram sorozatátfedésének beállítása**

Az [IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) jelzi, hogy a 2D diagramokban a sávok vagy oszlopok milyen mértékben fednek át egymásra, -100‑tól 100 százalékig. Ez a tulajdonság csak olvasható, mivel a szülő sorozatcsoport beállítását tükrözi. Állítsa az [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/)‑t, hogy frissítse a csoport minden kompatibilis sorozatát. Ez a lehetőség azoknál a diagramtípusoknál érvényes, amelyek csoportos sávokat vagy oszlopokat jelenítenek meg; kombinált diagram esetén a nem kapcsolódó sorozatcsoportokat nem érinti.

Az alábbi példa beállítja az átfedést azon csoportnál, amelyik az első sorozatot tartalmazza:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// Az új diagram mintasorozatokat, kategóriákat és értékeket tartalmaz.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

Az eredmény:

![The series overlap](series_overlap.png)

## **A sorozat kitöltőszínének módosítása**

Használja az [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/)‑t az egész sorozat alapértelmezett kitöltésének beállításához. Ha egy pont már rendelkezik explicit kitöltéssel, annak az [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) beállítása felülírja a sorozat kitöltését az adott pontnál.

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

![The color of the series](series_color.png)

## **A sorozat nevének módosítása**

A sorozat neve a diagram adat-munkafüzetben tárolódik, és általában a jelmagyarázatban jelenik meg. Egy csoportos oszlopdiagram alapértelmezett munkafüzetében a B1 cella (sor 0, oszlop 1) tartalmazza az első sorozat nevét. Az alábbi példában a névkonstansok egyértelművé teszik ezt a struktúrát:

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

A [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/)‑nek már hivatkozott celláját is frissítheti. Ez a megközelítés elkerüli, hogy egy meglévő diagramra egy adott sorra és oszlopra hivatkozzon:

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

![The series name](series_name.png)

### **Sorozat létrehozása több cellából álló névvel**

Összetett sorozatnév akkor hasznos, ha a terméknév és a jelentési időszak külön munkafüzet‑cellákban van tárolva. Például a `Product A` értéket a B1‑ben és a `2026` értéket a C1‑ben egyesítheti egyetlen sorozatnévbe, miközben mindkét rész továbbra is a forráscellához kapcsolódik.

Használja az [IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/)‑t a névtartomány lekéréséhez, majd adja át a gyűjteményt az [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/)‑nak. A `skipHiddenCells` argumentum határozza meg, hogy a rejtett cellákat belefoglalja‑e: `true` kizárja őket, míg `false` belefoglalja. Ebben a példában `false`‑t használunk, hogy minden cella szerepeljen a névtartományban.

Az alábbi példa egy prezentációt hoz létre egy sorozattal és két adatponttal. A B1:C1 csak a sorozat nevét adja, az A2:A3 a kategória címkéket, a B2:B3 pedig a numerikus értékeket.

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

// Ezek a két cella szolgáltatja a sorozat nevét.
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// Különálló cellák szolgáltatják a kategóriákat és a numerikus adatpontokat.
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

Az eredményül kapott sorozatnév `Product A 2026`, egy szóközzel a két cella értéke között. A jelmagyarázat egy bejegyzésként jeleníti meg mindkét oszlopot. Az alábbi kép a mentett prezentációból lett generálva:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Az automatikus sorozatkitöltő szín lekérése**

Az [IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) visszaadja a sorozat indexéből és a diagram stílusából számított színt. Ez a szín akkor kerül felhasználásra, ha a sorozatkitöltést nem definiálták kifejezetten. A metódus meghívása csak a számított színt olvassa ki; nem rendeli hozzá új kitöltést.

Az alábbi példa kiírja minden alapértelmezett sorozat automatikus színét:

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

Alapértelmezett diagramstílus példakimenete:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

A pontos színek a diagram stílusától és témájától függenek.

## **Inverz kitöltőszín beállítása egy diagram sorozathoz**

Sáv‑, oszlop‑ és buborék‑sorozatok esetén az [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) negatív értékeket másik kitöltéssel jeleníthet meg. Állítsa be a normál sorozatkitöltést szilárdra, engedélyezze az invertálást, és adja meg a negatív érték színét az [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/)‑nel. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenített színük módosul.

Az alábbi példa a diagram adatát cseréli egy sorozatra. A munkalap 0‑s sora a sorozat nevét, a 0‑s oszlop a kategória neveket, az 1‑s oszlop pedig az értékeket tartalmazza:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

Inverzálást egyetlen pontnál az [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/)‑val is beállíthatja. Az alábbi példában a sorozatra vonatkozó inverzálás ki van kapcsolva, csak a kijelölt pontnál van engedélyezve, és a pont negatív értéket kapott, hogy a hatás látható legyen:

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

## **Egy adott adatpontérték törlése**

Egy pont üresen hagyásához anélkül, hogy a többi pontot eltávolítaná, állítsa a mögöttes munkafüzet‑cellát `null`‑ra. Oszlopdiagram esetén a megjelenített érték a [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/)‑ban érhető el. Az adatpont ugyanazon kategóriapozícióban marad, de a diagram a értéket üresnek tekinti a diagram üres‑érték beállításai szerint.

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

A szórt diagramok külön X és Y cellákat használnak, a buborék diagramok pedig méretcellát is. Törölje csak azt a cellát, amelyik a törlendő értéket tartalmazza. Ne hívja a [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/)‑t, ha a többi pontot megtartja, mivel ez a metódus a teljes sorozatot eltávolítja.

## **Az üres cellák megjelenítésének szabályozása**

A rejtett cellák, amelyek értéket tartalmaznak, külön esetet jelentenek az üres celláktól. A rejtett munkalap‑sorok és -oszlopok adatainak felvételéről vagy kizárásáról lásd a [Include Data from Hidden Rows and Columns](/slides/hu/net/chart-workbook/#include-data-from-hidden-rows-and-columns) oldalt.

Az üres munkafüzet‑cellák hiányzó adatot jelentenek; a `0` értékű cella egy ismert numerikus értéket jelent. A [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/)‑t állítsa `null`‑ra, hogy a cella üres legyen. Egy numerikus nulla továbbra is nulla marad, függetlenül az üres‑cellás beállítástól.

Az [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/)‑t használva választhatja ki, hogy a diagram hogyan jelenítse meg az üres cellákat. Ez a beállítás a teljes diagramra vonatkozik. Megváltoztatja az üres értékek ábrázolását anélkül, hogy az üres munkafüzet‑cellát nullával vagy interpolált értékkel töltené fel.

Az alábbi önálló példa egy vonaldiagramot hoz létre egy sorozattal, a 3. nap értékét törli, és minden módot külön ment a diagramra. Bemeneti fájl nem szükséges. Az [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) a 0‑s munkalapot, 0‑s oszlopot a kategória címkékhez, 1‑s oszlopot az értékekhez használja; a 0‑s sor a sorozat nevét tartalmazza. A végső adatsor `10, 20, empty, 30, 40`.

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

// Hagyja a 3. napot ténylegesen üresen, miközben megtartja a kategóriáját és az adatpontot.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

Minden kimeneti fájl a mentés előtt beállított módot tartalmazza: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, és `empty_cells_Span.pptx`. Ha csak egy változatot szeretne menteni, állítsa be a kívánt módot, és egyszer mentse a prezentációt a módok iterálása helyett.

Az alábbi összehasonlítás ugyanazt az adatot mutatja mindhárom fájlban. A 3. nap minden esetben üres a munkafüzetben:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

A látható hatás a diagram típusától függ. A vonaldiagramnál könnyű összehasonlítani a három módot. Sáv‑ és oszlopdiagramoknál nincs vonal, amely összekapcsolná a hiányzó kategóriát, így a `Span` nem tudja létrehozni a fenti összekötő szegmenst; egy hiányzó oszlop és egy nulla‑magasságú oszlop is hasonlóan nézhet ki. Hasonlóképpen, egy csak jelölőkkel rendelkező szórt diagramnak nincs összekötő vonala. Ne számítson három különböző eredményre minden diagramtípusnál; ellenőrizze a kimenetet a saját típusán.

## **A sorozati hézagszélesség beállítása**

A hézagszélesség a szomszédos sáv‑ vagy oszlop‑klaszterek közötti távolság, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Állítsa be egyszer a [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)‑t a csoportnál. Nagyobb érték szélesebb hézagot eredményez a klaszterek között; kisebb érték sűrűbbé teszi őket.

Az alábbi példa módosítja a hézagszélességet, és csak a végső prezentációt menti:

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

![The gap width](gap_width.png)

## **Sorozati vonalak megjelenítése vagy elrejtése**

A sorozati vonalak vizuálisan kötik össze a diagram kapcsolódó részeit. Használja az [IChartSeriesGroup.HasSeriesLines](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/hasserieslines/)‑t a támogatott halmozott sáv‑ és OfPie‑diagramokban való megjelenítéshez vagy elrejtéshez. Két dimenziós halmozott sáv‑ és oszlopdiagramokban a vonalak a megfelelő réteghatárokat kötik össze a kategóriák között. Pie of Pie és Bar of Pie diagramokban a fő diagramot kapcsolják a másodlagos diagramhoz. Ez a beállítás nem általános csatlakozó más diagramtípusokhoz.

A csoportot az [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/)‑on keresztül érheti el. A beállítás a csoport minden sorozatára vonatkozik. Az [IChartSeries.HasSeriesLines](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/hasserieslines/) csak olvasható, és tükrözi a szülő csoport beállítását; a csoport tulajdonságának módosításával frissítheti.

Az alábbi példa egy [PieOfPie](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) diagramot hoz létre alapértelmezett adatokkal. Elmenti ugyanazt a diagramot sorozati vonalakkal engedélyezve, majd letiltva, így két prezentáció jön létre az összehasonlításhoz.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 400);
var series = chart.ChartData.Series[0];
var seriesGroup = series.ParentSeriesGroup;

seriesGroup.HasSeriesLines = true;
presentation.Save("series_lines_enabled.pptx", SaveFormat.Pptx);

seriesGroup.HasSeriesLines = false;
presentation.Save("series_lines_disabled.pptx", SaveFormat.Pptx);
```

| Series lines enabled | Series lines disabled |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| The two lines connect the main pie to the secondary pie. | Both pies remain visible, but the connecting lines are hidden. |

A sorozati vonalak különböznek az adatcímke‑vonalaktól, amelyek a címkéket kapcsolják az adatpontokhoz; a rácsvonalaktól, amelyek a diagram tengelye mentén jelölik az intervallumokat; és a vonaldiagram vonalaitól, amelyek az adatértékeket ábrázolják. Ez a beállítás nem irányítja ezeket az elemeket.

## **GYIK**

**Mely diagramtípusok támogatják az adat‑sorozatokat?**

Az összes, a [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) felsorolásban szereplő diagramtípus használ diagramadatokat, de sorozataik nem mindegyiknek azonos értékstruktúrája vagy beállítása. Például a kategóriadiagramok kategóriákat és értékeket használnak, a szórt diagramok X és Y értékeket, a buborék diagramok pedig buborékméreteket. Válassza a sorozattípusnak megfelelő adatpont‑létrehozási módszert. Az átfedés és hézagszélesség beállítások csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi a diagram sorozatcsoport?**

Az [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek csoport‑szintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több mint egy csoportot tartalmazhat, így egy sorozaton keresztül elérhető csoport módosítása nem feltétlenül változtatja meg a diagram minden sorozatát.

**A frissen létrehozott diagram alapértelmezett adatokat tartalmaz?**

Igen. Alapértelmezés szerint az [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy törölheti a sorozat‑ és kategória‑gyűjteményeket, mielőtt teljesen egyedi adatkészletet adna hozzá. Egy túlterhelés is létrehozhat diagramot alapértelmezett adatok nélkül.

**Hogyan kapcsolódnak a diagramobjektumok a munkafüzet‑cellákhoz?**

A sorozatnevek, kategória‑címkék és adatpont‑értékek egy [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagramelemet. Egyedi adat felépítésekor tartsa a kategória‑sorokat és a sorozat‑érték‑sorokat igazítottak, hogy minden pont a megfelelő kategória alatt legyen ábrázolva.

**Hogyan töröljek egyetlen pontot a teljes sorozat helyett?**

Állítsa a megfelelő értékcellát `null`‑ra, hogy a pont kategóriapozíciója üres pontként megmaradjon. Az [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/)‑t csak akkor használja, ha a sorozat összes pontját el szeretné távolítani. Ha a kategóriákat is eltávolítja, frissítse minden sorozatot, hogy az értékek a kategória‑gyűjteménnyel igazodjanak.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagram típusától és az [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) beállítástól függ. A támogatott diagramok üres cellákat megjeleníthetnek hézagként, nullaként, vagy a szomszédos pontok összekapcsolásával. Válassza azt a beállítást, amely a hiányzó adatok jelentését tükrözi a prezentációban. Lásd a [Control the Display of Empty Cells](#control-the-display-of-empty-cells) részt a teljes példa és vizuális összehasonlítás miatt.

**Hogyan formázzák a negatív értékeket?**

A támogatott sáv‑, oszlop‑ és buborék‑sorozatok esetén engedélyezze az [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/)‑t, és állítsa be az [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/)‑t. Egy egyedi pont viselkedését az [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/)‑val felülbírálhatja. Ezek a tulajdonságok a formázást érintik, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha a sorozat és a pont is formázva van?**

Az explicit adatpont‑formázás felülbírálja a sorozat formázását az adott pontnál. A többi pont továbbra is az explicit sorozat‑formázást, vagy ha az nincs definiálva, a automatikus diagram‑stílust és témát használja. A csoport‑tulajdonságok, mint az átfedés és hézagszélesség, a elrendezést szabályozzák, nem pont‑szintű formázási felülírások.

**Van korlátozás arra, hány sorozat lehet egy diagramon?**

Az Aspose.Slides nem alkalmaz különálló, fix sorozatszám‑korlátot. Gyakorlatban a prezentációfájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos felső határt.

**Mit kell módosítani, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Állítsa be a megfelelő szülő sorozatcsoporton az [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)‑t. Növelje az értéket a klaszterek közötti tér növeléséhez, vagy csökkentse a közelebb hozáshoz.