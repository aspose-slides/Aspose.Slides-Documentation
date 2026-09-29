---
title: Diagram adatsorozatok kezelése prezentációkban .NET-ben
linktitle: Adatsorozatok
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
description: "Ismerje meg, hogyan kezelheti a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és a negatív értékeket a prezentációkban C#-val."
---
## **Áttekintés**

Egy diagram a megjelenített adatokat egy diagramadat‑munkafüzetben tárolja. Egy [IChartSeries](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/) egy kapcsolódó értékcsoportot képvisel, és a sorozat minden [IChartDataPoint](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapoint/) egy vagy több munkafüzet‑cellára hivatkozik. Az [IChartCategory](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosítási értékeket biztosítják. A sorozat neve, a kategóriák és a pontértékek ezért [IChartDataCell](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/) objektumokhoz kapcsolódnak, nem csak megjelenő szövegként tárolódnak.

Hagyományos kategória diagram esetén az alapértelmezett munkafüzet a 0‑s sort használja a sorozatnevekre, a 0‑s oszlopot a kategórianévre, a többi cellát pedig a sorozatértékekre. A [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/getcell/) számára megadott munkalap‑, sor‑ és oszlopszámok nullától indulnak. Ez a kialakítás hasznos, amikor alapértelmezett adatokkal hoz létre egy diagramot, de ne feltételezze, hogy minden meglévő diagram ezt használja. Betöltött prezentáció esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat a munkafüzet értékeinek módosítása előtt.

A diagram beállításainak három különböző hatóköre van:

- Sorozatszintű beállítások, például a [IChartSeries.Format](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/format/) alapértelmezett megjelenést biztosítanak egy sorozat összes pontjának.
- Adatpont szintű beállítások, például a [IChartDataPoint.Format](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapoint/format/) felülírják a sorozat megjelenését egy pontnál.
- Csoportbeállítások a kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz az [IChartSeriesGroup](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseriesgroup/) tartoznak. A csoportot a [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/parentseriesgroup/) segítségével érheti el, ha például az átfedés vagy a hézag szélesség beállítására van szükség.

Amikor nincs explicit pont‑ vagy sorozat‑kitöltés beállítva, a diagram stílusa és témája határozza meg az automatikus megjelenést. Ha mind a sorozati, mind a pontformázás jelen van, a pontformázás felülbírálja a sorozati beállítást az adott pontnál.

![Diagram sorozat PowerPoint](chart-series-powerpoint.png)

## **A diagram sorozat átfedésének beállítása**

[IChartSeries.Overlap](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/overlap/) megadja, hogy a sávok vagy oszlopok mennyire átfedik egymást egy 2D diagramon, -100‑tól 100‑ig százalékban. Ez egy csak olvasható leképezése a szülő sorozatcsoport beállításának. Az [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseriesgroup/overlap/) beállításával frissítheti a csoport összes kompatibilis sorozatát. Ez az opció olyan diagramtípusokra vonatkozik, amelyek csoportosított sávokat vagy oszlopokat jelenítenek meg; nem érinti a kombinációs diagramokban lévő nem kapcsolódó sorozatcsoportokat.

A következő példa beállítja az átfedést azon csoportban, amely az első sorozatot tartalmazza:

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

![A sorozat átfedése](series_overlap.png)

## **A sorozat kitöltőszínének módosítása**

Használja a [IChartSeries.Format](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/format/) a teljes sorozat alapértelmezett kitöltésének beállításához. Ha egy pont már rendelkezik explicit kitöltéssel, annak [IChartDataPoint.Format](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapoint/format/) beállítása felülírja a sorozati kitöltést az adott pontnál.

A következő példa szilárd kék kitöltést alkalmaz az első sorozatra:

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

## **A sorozat nevének módosítása**

A sorozat neve a diagram adat‑munkafüzetben tárolódik, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett munkafüzet, amely a csoportosított oszlopdiagramhoz készül, a B1 cella a 0‑s sorban és az 1‑s oszlopban található, és az első sorozat nevét tartalmazza. Az alábbi példa elnevezett állandói ezt a struktúrát teszik egyértelművé:

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

A [IChartSeries.Name](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/name/) által már hivatkozott cellát is frissítheti. Ez a megközelítés elkerüli egy adott sor és oszlop feltételezését egy meglévő diagramon:

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

## **Az automatikus sorozatkitöltő szín lekérése**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) visszaadja a sorozat indexéből és a diagram stílusából kiszámított színt. Ez a szín akkor kerül felhasználásra, ha a sorozat kitöltése nincs explicit módon meghatározva. A metódus meghívása csak kiolvassa a számított színt; nem állít be új kitöltést.

A következő példa kiírja minden alapértelmezett sorozat automatikus színét:

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

Példa kimenet az alapértelmezett diagram stílushoz:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

A pontos színek a diagram stílusától és témájától függenek.

## **Invert (fordított) kitöltőszín beállítása egy diagram sorozathoz**

Osáleg, oszlopsorozat és buborék sorozatok esetén az [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/invertifnegative/) negatív értékeket másik kitöltéssel jeleníthet meg. Állítsa be a szabályos sorozat kitöltést szilárdra, engedélyezze a fordítást, és adja meg a negatív érték színét az [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) segítségével. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük módosul.

A következő példa az alapértelmezett diagram adatot egy sorozatra cseréli. A munkalap 0‑s sorában a sorozat neve van, az 0‑s oszlopban a kategória nevek, az 1‑s oszlopban az értékek:

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

![A fordított szilárd kitöltő szín](inverted_solid_fill_color.png)

Az [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) segítségével egy pontnál engedélyezheti a fordítást. A következő példában a sorozatra le van tiltva a fordítás, és csak a kiválasztott pontnál van engedélyezve. A pontnak negatív értéket is adunk, hogy a hatás látható legyen:

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

## **Egy konkrét adatpont értékének törlése**

Ahhoz, hogy egy pontot üresen hagyjon a többi pont eltávolítása nélkül, állítsa a hozzá tartozó munkafüzet‑cellát `null`‑ra. Oszlopdiagram esetén a megjelenített érték az [IChartDataPoint.YValue](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapoint/yvalue/) segítségével érhető el. Az adatpont ugyanazon kategória pozícióban marad, de a diagram a beállított üres‑érték szabályok szerint üresnek kezeli az értékét.

A következő példa csak a második pontot törli az első sorozatban:

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

A szórásdiagram külön X és Y cellákat használ, a buborékdiagram pedig egy méretcellát. Csak azt a cellát törölje, amely a törölni kívánt értéket képviseli. Ne hívja a [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapointcollection/clear/)‑t, ha a többi pontot megtartani szeretné, mivel ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **Az üres cellák megjelenítésének vezérlése**

A rejtett, értéket tartalmazó cellák külön esetet képeznek az üres celláktól. A rejtett munkalap‑sorok és -oszlopok adatait tartalmazó vagy kizáró információkért lásd a [Include Data from Hidden Rows and Columns](/slides/hu/net/chart-workbook/#include-data-from-hidden-rows-and-columns) oldalát.

Egy üres munkafüzet‑cellát hiányzó adatként értelmeznek; egy `0` értékű cella ismert numerikus értéket jelent. Állítsa az [IChartDataCell.Value](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/value/)‑t `null`‑ra, hogy a cella üres legyen. A numerikus nulla továbbra is nulla marad, függetlenül az üres‑cellá beállítástól.

Használja a [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichart/displayblanksas/)‑t, hogy kiválassza, a diagram hogyan jelenítse meg az üres cellákat. Ez a beállítás a teljes diagramra vonatkozik. Megváltoztatja az üresek ábrázolását anélkül, hogy az üres munkafüzet‑cellát nullával vagy interpolált értékkel töltené fel.

A következő önálló példa egy vonaldiagramot hoz létre egy sorozattal, a 3. nap értékét törli, és a diagramot minden móddal elmenti. Bemeneti fájlra nincs szükség. A [IChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/) a 0‑s munkalapot, a 0‑s oszlopot a kategória címkéknek, az 1‑s oszlopot az értékeknek használja; a 0‑s sor a sorozat nevét tartalmazza. A végső adatok: `10, 20, empty, 30, 40`.

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

// A 3. napot valóban üresen hagyjuk, miközben megtartjuk a kategóriáját és adatpontját.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

Minden kimeneti fájl a mentés előtt beállított módot tárolja: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy verziót szeretne menteni, állítsa be a kívánt módot, és egyszer mentse a prezentációt a módok iterálása helyett.

Az alábbi összehasonlítás ugyanazt az adatot mutatja mindhárom fájlban. A 3. nap minden esetben üres a munkafüzetben:

![Vonaldiagramok azonos adatokkal: Gap szakítja a vonalat a 3. napnál, Zero a vonalat nullára húzza, Span összeköti a 2. és 4. napot.](display_blanks_as.png)

A látható hatás a diagram típusától függ. A vonaldiagram minden három módot könnyen összehasonlíthatóvá tesz. Az oszlop- és sávdiagramoknak nincs vonala, amely összekötné a hiányzó kategóriát, így a `Span` nem tudja létrehozni a fent látható összekötő szegmenst; egy hiányzó oszlop és egy nulla magasságú oszlop is hasonlóan nézhet ki. Hasonlóképpen a csak jelölőkkel rendelkező szórásdiagramnak sincs kapcsolódó vonala. Ne várjon három különálló eredményt minden diagramtípusra; ellenőrizze a kimenetet a használt típushoz.

## **A sorozat hézag szélességének beállítása**

A hézag szélessége a szomszédos sáv- vagy oszlopszövetek közötti távolság, amely a sáv vagy oszlop szélességének százalékában van megadva. Az átfedéshez hasonlóan a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. A [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) beállítható egyszer a csoporthoz. A nagyobb érték nagyobb távolságot eredményez a klaszterek között; a kisebb érték sűrűbbé teszi azokat.

A következő példa megváltoztatja a hézag szélességét, és csak a végső prezentációt menti:

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

![A hézag szélessége](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják az adat‑sorozatokat?**

Az [ChartType](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/charttype/) felsorolásban szereplő összes diagramtípus használ diagramadatot, de sorozataik nem rendelkeznek ugyanazzal az értékstruktúrával vagy beállításokkal. Például a kategóriadiagramok kategóriákat és értékeket használnak, a szórásdiagramok X és Y értékeket, a buborékdiagramok pedig buborékméreteket adnak. Használja a sorozattípussal megegyező adatpont‑létrehozási módszert. Az átfedés és a hézag szélesség opciók csak kompatibilis sáv‑ vagy oszlopsorozatokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

Az [IChartSeriesGroup](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös csoport‑szintű ábrázolási beállításokat osztanak meg. Egy kombinációs diagram több csoportot is tartalmazhat, ezért egy sorozaton keresztül elért csoport megváltoztatása nem feltétlenül módosítja a diagram összes sorozatát.

**Tartalmaz egy újonnan létrehozott diagram alapértelmezett adatokat?**

Igen. Alapértelmezés szerint az [IShapeCollection.AddChart](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addchart/) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy a sorozat- és kategóriagyűjteményeket kiürítheti, mielőtt teljesen egyedi adatkészletet adna hozzá. Egy túlterhelés lehetővé teszi, hogy a diagramot alapértelmezett adatok nélkül hozza létre.

**Hogyan kapcsolódnak a diagramobjektumok a munkafüzet celláihoz?**

A sorozatnevek, kategória címkék és adatpont értékek egy [IChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagramelemet. Egyedi adatok készítésekor tartsa összehangoltan a kategóriasorokat és a sorozat‑érték sorokat, hogy minden pont a kívánt kategória alá kerüljön.

**Hogyan törlök egyetlen pontot a teljes sorozat helyett?**

Állítsa a megfelelő értékcellát `null`‑ra, hogy a pont kategória‑pozíciója üres pontként megmaradjon. A [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapointcollection/clear/)‑t csak akkor használja, ha az adott sorozat összes pontját el akarja távolítani. Ha a kategóriákat is törli, frissítse minden sorozatot, hogy az értékek továbbra is a kategóriagyűjteménnyel legyenek összehangolva.

**Hogyan jelennek meg az üres pontok?**

A végeredmény a diagram típusától és a [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichart/displayblanksas/) beállítástól függ. A támogatott diagramok az üreseket megjeleníthetik hézagokként, null értékekként vagy a szomszédos pontok összekapcsolásával. Válassza ki azt a beállítást, amely megfelel a hiányzó adatok jelentésének a prezentációban. Tekintse meg a [Control the Display of Empty Cells](#control-the-display-of-empty-cells) szekciót a teljes példáért és vizuális összehasonlításért.

**Hogyan formázódnak a negatív értékek?**

Támogatott sáv-, oszlop- és buborék sorozatok esetén engedélyezze az [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/invertifnegative/)‑t, és állítsa be az [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/)‑t. Egy egyedi pontnál a viselkedést felülírhatja a [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapoint/invertifnegative/)‑val. Ezek a tulajdonságok a formázásra hatnak, nem a tárolt numerikus értékekre.

**Melyik formázás nyer, ha egy sorozat és egy pont is formázva van?**

Az explicit adatpont‑formázás felülbírálja a sorozati formázást az adott pontnál. A többi pont továbbra is az explicit sorozati formátumot vagy, ha a sorozati formátum nincs definiálva, az automatikus diagramstílust és témát használja. A csoport‑tulajdonságok, mint az átfedés és a hézag szélesség, a elrendezést szabályozzák, és nem pont‑szintű formázási felülírások.

**Van korláta, hogy hány sorozatot tartalmazhat egy diagram?**

Az Aspose.Slides nem szab ki különálló, rögzített sorozatszám‑korlátot. Gyakorlatban a prezentáció fájlkorlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg az ésszerű limitet.

**Mit kell módosítanom, ha az oszlopok túl közel vagy túl messze vannak egymástól?**

Állítsa be a megfelelő szülő sorozatcsoporton a [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)‑t. Növelje az értéket a klaszterek közti távolság bővítéséhez, vagy csökkentse, hogy a klaszterek közelebb kerüljenek egymáshoz.