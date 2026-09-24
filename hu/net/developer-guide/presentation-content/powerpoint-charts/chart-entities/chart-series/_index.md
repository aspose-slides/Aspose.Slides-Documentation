---
title: Diagram adat sorozatok kezelése prezentációkban .NET-ben
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
description: "Ismerje meg, hogyan kezelhet diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket prezentációkban C#-vel."
---
## **Áttekintés**

Egy diagram a megjelenített adatokat egy diagramadat-munkafüzetben tárolja. Az [IChartSeries](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/) egy kapcsolódó értékkészletet képvisel, és a sorozat minden [IChartDataPoint](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapoint/) egy vagy több munkafüzetcellára hivatkozik. Az [IChartCategory](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosítási értékeket biztosítják. A sorozat neve, a kategóriák és a pontértékek ezért [IChartDataCell](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/) objektumokra hivatkoznak, nem csak megjelenítési szövegként tárolódnak.

Hagyományos kategória diagram esetén az alapértelmezett munkafüzet a 0. sort használja a sorozatnevekhez, a 0. oszlopot a kategórianévhez, a többi cellát pedig a sorozatértékekhez. A [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/getcell/)‑nak átadott munkalap, sor és oszlop indexek nulla‑alapúak. Ez a felépítés hasznos, amikor alapértelmezett adatokkal hozol létre diagramot, de ne feltételezd, hogy minden létező diagram ezt használja. Betöltött bemutató esetén ellenőrizd a sorozatok, kategóriák és adatok pontjai által hivatkozott cellákat, mielőtt a munkafüzet értékeit módosítanád.

A diagram beállítások három különböző hatókörrel rendelkeznek:

- Sorozatszintű beállítások, például az [IChartSeries.Format](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/format/) alapértelmezett megjelenést biztosítanak egy sorozat összes pontjának.
- Adatpont beállítások, például a [IChartDataPoint.Format](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapoint/format/) felülírják a sorozat megjelenését egy pont esetén.
- Csoportbeállítások alkalmazhatók kompatibilis sorozatokra, amelyek ugyanahhoz az [IChartSeriesGroup](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseriesgroup/) tartoznak. A csoportot a [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/parentseriesgroup/)‑on keresztül érheted el, ha például az átfedés vagy a hézag szélesség opciókat szeretnéd beállítani.

Ha nincs explicit pont vagy sorozat kitöltés beállítva, a diagram stílusa és témája határozza meg az automatikus megjelenést. Ha mind a sorozat, mind a pont formázása meg van adva, a pont formázása lesz előnyben a pont esetén.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **A diagram sorozat átfedésének beállítása**

[IChartSeries.Overlap](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/overlap/) megadja, hogy a sávok vagy oszlopok mennyire fednek át egy 2D diagramon, -100 és 100 százalék között. Ez egy csak olvasható leképezése a beállításnak a szülő sorozatcsoporton. A [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseriesgroup/overlap/) beállításával frissítheted a csoportban lévő minden kompatibilis sorozatot. Ez az opció a csoportosított sávok vagy oszlopok megjelenítését támogató diagramtípusokra vonatkozik; nem érint nem kapcsolódó sorozatcsoportokat egy kombinált diagramon.

A következő példa beállítja az átfedést a csoportban, amely az első sorozatot tartalmazza:
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

## **A sorozat kitöltőszínének módosítása**

Használd a [IChartSeries.Format](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/format/)‑t egy teljes sorozat alapértelmezett kitöltésének beállításához. Ha egy pont már rendelkezik explicit kitöltéssel, annak [IChartDataPoint.Format](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapoint/format/) beállítása felülírja a sorozat kitöltését az adott pontnál.

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

A sorozat neve a diagram adatmunkafüzetben tárolódik, és általában a legendában jelenik meg. Az alapértelmezett munkafüzetben, amely egy csoportosított oszlopdiagramhoz jön létre, a B1 cella a 0. sorban, 1. oszlopban található, és az első sorozat nevét tartalmazza. A következő példában a megnevezett konstansok expliciten leírják ezt a struktúrát:
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

Meg is frissítheted a már [IChartSeries.Name](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/name/) által hivatkozott cellát. Ez a megközelítés elkerüli egy adott sor és oszlop feltételezését egy meglévő diagramon:
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

## **Az automatikus sorozat kitöltőszín lekérése**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) visszaadja a sorozat indexéből és a diagram stílusából számított színt. Ez a szín akkor kerül felhasználásra, ha a sorozat kitöltése nincs explicit módon megadva. A metódus meghívása a kiszámított színt olvassa, nem ad új kitöltést.

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

Példa kimenet az alapértelmezett diagram stílusra:
```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

A pontos színek a diagram stílusától és témájától függenek.

## **A diagram sorozat invertált kitöltőszínének beállítása**

Oszlop, sáv és buborék sorozatoknál a [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/invertifnegative/) lehetővé teszi, hogy a negatív értékeket eltérő kitöltéssel jelenítsd meg. Állítsd be a szabályos sorozatkitöltést szilárdra, engedélyezd az invertálást, és a negatív érték színét a [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/)‑on keresztül add meg. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük változik.

A következő példa az alapértelmezett diagram adatokat egy sorozatra cseréli. A munkalap 0. sorában a sorozat neve, a 0. oszlopban a kategória nevek, az 1. oszlopban az értékek szerepelnek:
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
![Az invertált szilárd kitöltőszín](inverted_solid_fill_color.png)

Az invertálást egyetlen pontnál engedélyezheted a [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) segítségével. A következő példában a sorozatnál ki van kapcsolva az invertálás, és csak a kiválasztott pontnál van engedélyezve. A pontnak negatív értéket is adunk, hogy a hatás látható legyen:
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

Hogy egy pontot üresen hagyj anélkül, hogy a többi pontot eltávolítanád, állítsd a mögöttes munkafüzetcellát `null`‑ra. Oszlopdiagram esetén a megjelenített érték a [IChartDataPoint.YValue](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapoint/yvalue/)‑on keresztül érhető el. Az adatpont a ugyanabban a kategóriahelyen marad, de a diagram a beállítások szerint üres értékként kezeli.

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

A szórás diagramok külön X és Y cellákat használnak, a buborék diagramok pedig egy méretcellát is. Töröld csak azt a cellát, amely a törölni kívánt értéket képviseli. Ne hívd a [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapointcollection/clear/) metódust, ha meg akarod tartani a többi pontot, mert ez a metódus a gyűjtemény minden adatpontját eltávolítja.

## **Az üres cellák megjelenítésének szabályozása**

Egy üres munkafüzetcell a hiányzó adatot jelenti; a `0` értéket tartalmazó cella egy ismert numerikus értéket jelent. A [IChartDataCell.Value](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/value/) beállításával `null`‑ra teheted a cellát üresnek. A numerikus nulla továbbra is nulla marad a ürescellás beállítástól függetlenül.

Használd a [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichart/displayblanksas/)‑t, hogy kiválaszd, a diagram hogyan jelenítse meg az üres cellákat. Ez a beállítás az egész diagramra vonatkozik. Megváltoztatja, hogyan kerülnek ábrázolásra a hiányzó értékek, anélkül, hogy az üres munkafüzetcellát nullával vagy interpolált értékkel töltené fel.

A következő önálló példa egy egy sorozatos vonaldiagramot hoz létre, törli a 3. nap értékét, és ugyanazt a diagramot minden móddal elmenti. Bemeneti fájl nem szükséges. Az [IChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/) a 0. munkalapot, a 0. oszlopot használja a kategóriacímkékhez, az 1. oszlopot az értékekhez; a 0. sor tartalmazza a sorozat nevet. A végső adatok: `10, 20, empty, 30, 40`.
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

Minden kimeneti fájl a mentés előtt beállított módot tárolja: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, és `empty_cells_Span.pptx`. Ha csak egy verziót szeretnél menteni, állítsd be a kívánt módot, és a prezentációt egyszer mentsd el a módok iterálása helyett.

Az alábbi összehasonlítás mindhárom fájlban ugyanazt az adatot mutatja. A 3. nap minden esetben üres a munkafüzetben:
![Vonaldiagramok azonos adatokkal: Gap szaggatja a vonalat a 3. napon, Zero a vonalat nullára viszi, Span összeköti a 2. és 4. napot.](display_blanks_as.png)

A látható hatás a diagram típusától függ. A vonaldiagram minden három módot könnyen összehasonlíthatóvá teszi. Az oszlop és sáv diagramoknak nincs vonala, amely összekötné a hiányzó kategóriát, így a `Span` nem képes előállítani a fenti csatlakozó szegmenst; egy hiányzó oszlop és egy nulla magasságú oszlop is hasonló lehet. Hasonlóképpen egy szórás diagram csak jelölőkkel nem rendelkezik vonallal. Ne várj három különböző eredményt minden diagramtípusra; ellenőrizd a kimenetet a használt típusnál.

## **A sorozat hézag szélességének beállítása**

A hézag szélessége a szomszédos sáv- vagy oszlopháromszögek közötti tér, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. A [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) egyszeri beállítása elegendő a csoporthoz. A nagyobb érték több helyet hoz létre a klaszterek között; a kisebb érték sűrűbbé teszi őket.

A következő példa módosítja a hézag szélességét, és csak a végső prezentációt menti:
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

**Mely diagramtípusok támogatják az adat sorozatokat?**

Az [ChartType](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/charttype/) felsorolásban szereplő összes diagramtípus diagramadatokat használ, de a sorozataik nem mindegyiknek ugyanaz a értékstruktúrája vagy beállításai. Például a kategória diagramok kategóriákat és értékeket használnak, a szórás diagramok X és Y értékeket, a buborék diagramok pedig buborékméreteket adnak hozzá. Használd a sorozattípushoz illeszkedő adatpont‑létrehozó metódust. Az olyan opciók, mint az átfedés és a hézag szélesség, csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

Egy [IChartSeriesGroup](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös csoportszintű ábrázolási beállításokkal rendelkeznek. Egy kombinált diagram több csoportot is tartalmazhat, így egy sorozaton keresztül elérhető csoport módosítása nem feltétlenül változtatja meg a diagram összes sorozatát.

**Tartalmaz-e egy újonnan létrehozott diagram alapértelmezett adatokat?**

Igen. Alapértelmezés szerint a [IShapeCollection.AddChart](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addchart/) mintasorozatokat, kategóriákat és értékeket hoz létre. Szerkesztheted ezeket a cellákat, vagy törölheted mind a sorozat- mind a kategóriagyűjteményt, mielőtt teljesen egyedi adatkészletet adnál hozzá. Egy túlterhelés lehetővé teszi, hogy diagramot alapértelmezett adatok nélkül is hozz létre.

**Hogyan kapcsolódnak a diagram objektumok a munkafüzet celláihoz?**

A sorozatnevek, kategóriacímkék és adatpont értékek az [IChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagram elemet. Egyedi adat építésekor tartsd összehangoltan a kategória sorokat és a sorozat‑érték sorokat, hogy minden pont a kívánt kategória alatt legyen ábrázolva.

**Hogyan törölhetek egy pontot a teljes sorozat helyett?**

Állítsd a megfelelő értékcellát `null`‑ra, hogy a pont kategóriahelye üres pontként maradjon. Használd a [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapointcollection/clear/)‑t csak akkor, ha az adott sorozat összes pontját el akarod távolítani. Ha a kategóriákat is eltávolítod, frissítsd minden sorozatot, hogy az értékek továbbra is a kategóriagyűjteménnyel össze legyenek hangolva.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagram típusától és a [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichart/displayblanksas/)‑tól függ. A támogatott diagramok a hiányzó értékeket hézagként, nullaként vagy a szomszédos pontok összekapcsolásával jeleníthetik meg. Válaszd ki azt a beállítást, amely a hiányzó adatok jelentését tükrözi a prezentációdban. Tekintsd meg a [Control the Display of Empty Cells](#control-the-display-of-empty-cells) részt a teljes példa és a vizuális összehasonlítás miatt.

**Hogyan vannak formázva a negatív értékek?**

Támogatott sáv, oszlop és buborék sorozatoknál engedélyezd a [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/invertifnegative/)‑t és állítsd be a [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/)‑t. Egy adott pontnál a viselkedést felülírhatod a [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapoint/invertifnegative/)‑szel. Ezek a tulajdonságok a formázást érintik, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha a sorozat és a pont is formázva van?**

Az explicit adatpont‑formázás előnyben részesül az adott pontnál. A többi pont továbbra is az explicit sorozat formázást használja, vagy ha a sorozat formátuma nincs meghatározva, akkor az automatikus diagram stílust és témát. A csoporttulajdonságok, mint az átfedés és a hézag szélesség, az elrendezést szabályozzák, és nem pont‑szintű formázás felülírásai.

**Van korlát arra, hány sorozatot tartalmazhat egy diagram?**

Az Aspose.Slides nem szab meg különálló, rögzített sorozatszám‑korlátot. Gyakorlatban a prezentációs fájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos határt.

**Mit kell változtatni, ha az oszlopok túl közel vagy túl messze vannak egymástól?**

Állítsd be a megfelelő szülő sorozatcsoport [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)‑ét. Növeld az értéket, hogy szélesebb legyen a klaszterek közötti tér, vagy csökkentsd, hogy a klaszterek közelebb kerüljenek egymáshoz.