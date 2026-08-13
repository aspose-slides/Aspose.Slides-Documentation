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
- sorozat neve
- adatpont
- sorozat hézag
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a diagram sorozatokat, adatpontokat, munkafüzetcellákat, formázást, átfedést, hézag szélességet és negatív értékeket a prezentációkban C#-val."
---
## **Áttekintés**

A diagram a megjelenített adatait egy diagramadat‑munkafüzetben tárolja. Az [IChartSeries](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/) egy összefüggő értékek halmazát képviseli, és a sorozat minden [IChartDataPoint](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapoint/) egy vagy több munkafüzetcellára hivatkozik. Az [IChartCategory](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartcategory/) objektumok biztosítják a sorozatok által megosztott címkéket vagy csoportosítási értékeket. Ezért a sorozat neve, a kategóriák és a pontértékek az [IChartDataCell](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/) objektumokhoz kapcsolódnak, nem csak megjelenítési szövegként tárolódnak.

Tipikus kategória diagram esetén az alapértelmezett munkafüzet a 0. sort használja a sorozatnevekhez, a 0. oszlopot a kategória nevekhez, a többi cellát pedig a sorozatértékekhez. A [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/getcell/) metódusnak átadott munkalap, sor és oszlop indexek nullára kezdődőek. Ez a felépítés hasznos, ha alapértelmezett adatokkal hoz létre diagramot, de ne tételezze, hogy minden létező diagram ezt használja. Betöltött bemutató esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt módosítaná a munkafüzet értékeit.

A diagram beállításai három különböző hatókörrel rendelkeznek:

- Sorozatszintű beállítások, például az [IChartSeries.Format](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/format/), az egy sorozat összes pontjának alapértelmezett megjelenését biztosítják.
- Adatpont beállítások, például az [IChartDataPoint.Format](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapoint/format/), felülírják a sorozat megjelenését egy adott pontnál.
- Csoportbeállítások alkalmazhatók a kompatibilis sorozatokra, amelyek ugyanahhoz az [IChartSeriesGroup](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseriesgroup/) tartoznak. A csoportot a [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/parentseriesgroup/) segítségével érheti el, ha olyan beállításokat kell megadni, mint az átfedés vagy a hézag szélessége.

Ha nincs explicit pont- vagy sorozatkitöltés megadva, a diagram stílusa és témája határozza meg az automatikus megjelenést. Ha a sorozat és a pont formázása egyaránt jelen van, a pont formázása élvez elsőbbséget az adott pontnál.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Állítsa be a diagram sorozat átfedését**

[IChartSeries.Overlap](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/overlap/) jelzi, hogy a sávok vagy oszlopok mennyire fednek át egy 2D diagramon, -100 és 100 százalék között. Ez a beállítás csak olvasható leképezése a szülő sorozatcsoport beállításának. A [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseriesgroup/overlap/) beállításával frissíthető az összes kompatibilis sorozat ebben a csoportban. Ez az opció olyan diagramtípusokra vonatkozik, amelyek csoportos sávokat vagy oszlopokat jelenítenek meg; nem befolyásolja a kombinációs diagramokhoz nem kapcsolódó sorozatcsoportokat.

A következő példa beállítja az átfedést az első sorozatot tartalmazó csoportban:

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

Használja az [IChartSeries.Format](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/format/) metódust egy teljes sorozat alapértelmezett kitöltésének beállításához. Ha egy pont már rendelkezik explicit kitöltéssel, akkor annak [IChartDataPoint.Format](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapoint/format/) beállítása felülírja a sorozat kitöltését az adott pontnál.

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

![The color of the series](series_color.png)

## **A sorozat nevének módosítása**

Egy sorozat neve a diagram adatmunkafüzetben van tárolva, és általában a jelmagyarázatban jelenik meg. A klaszterezett oszlopdiagramhoz létrehozott alapértelmezett munkafüzetben a B1 cella a 0. sor, 1. oszlop helyén a első sorozat nevét tartalmazza. A következő példában szereplő névkonstansok ezt a struktúrát teszik egyértelművé:

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

Frissítheti azt a cellát is, amelyre már hivatkozik az [IChartSeries.Name](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/name/). Ez a megközelítés elkerüli, hogy egy meglévő diagram konkrét sorát és oszlopát feltételezze:

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

## **A sorozat automatikus kitöltőszínének lekérdezése**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) visszaadja a sorozat indexéből és a diagramstílusból kiszámított színt. Ez a szín akkor kerül használatra, amikor a sorozat kitöltése nincs explicit módon definiálva. A metódus meghívása csak a kiszámított színt olvassa, nem ad új kitöltést.

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

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

A pontos színek a diagram stílusától és témájától függenek.

## **Fordított kitöltőszín beállítása egy diagram sorozathoz**

Sáv, oszlop és buboréksorozatok esetén az [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/invertifnegative/) segítségével a negatív értékek más kitöltéssel jeleníthetők meg. Állítsa be a normál sorozatkitöltést szilárdra, engedélyezze a fordítást, és adja meg a negatív érték színét az [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) segítségével. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenített színük változik.

A következő példa az alapértelmezett diagramadatokat egy sorozattal helyettesíti. A munkalap 0. sora a sorozat nevét, a 0. oszlop a kategória neveket, az 1. oszlop pedig az értékeket tartalmazza:

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

Az [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) segítségével egy pontnál is engedélyezhető a fordítás. A következő példában a sorozatnál le van tiltva a fordítás, csak a kiválasztott pontnál van engedélyezve. A pontnak negatív értéket is adunk, hogy a hatás látható legyen:

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

Egy pont üressé tételéhez a többi pontot érintve, állítsa a mögöttes munkafüzetcellát `null`-ra. Oszlopdiagram esetén a megjelenített érték a [IChartDataPoint.YValue](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapoint/yvalue/) segítségével érhető el. Az adatpont ugyanabban a kategóriahelyen marad, de a diagram a beállított üresérték‑beállítások szerint üresnek tekinti az értékét.

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

A szórásdiagramok külön X és Y cellákat használnak, a buborékdiagramok pedig méretcellát is. Törölje csak azt a cellát, amely a eltávolítandó értéket képviseli. Ne hívja a [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapointcollection/clear/) metódust, ha a többi pontot meg szeretné tartani, mivel ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **A sorozat hézag szélességének beállítása**

A hézag szélessége a szomszédos sáv- vagy oszlopcsoportok közötti távolság, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez is a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. A [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) egyszeri beállítása a csoport számára elegendő. A nagyobb érték több helyet hoz létre a csoportok között; a kisebb érték sűrűbbé teszi őket.

A következő példa módosítja a hézag szélességét, és csak a végső bemutatót menti:

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

## **GYIK**

**Mely diagramtípusok támogatják az adat sorozatokat?**

Minden, a [ChartType](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/charttype/) felsorolásban szereplő diagramtípus használ diagramadatokat, de sorozataik nem mindegyiknek ugyanaz a értékstruktúrája vagy beállítása. Például a kategória diagramok kategóriákat és értékeket használnak, a szórásdiagramok X és Y értékeket, a buborékdiagramok pedig buborékméreteket adnak hozzá. Használja a sorozattípusnak megfelelő adatpont létrehozási módszert. Az átfedés és hézag szélesség opciók csak a kompatibilis sáv- vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

Egy [IChartSeriesGroup](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös csoportszintű ábrázolási beállításokat osztanak meg. Egy kombinációs diagram több csoportot is tartalmazhat, ezért egy sorozaton keresztül elért csoport megváltoztatása nem feltétlenül változtatja meg a diagram minden sorozatát.

**Tartalmaz-e egy újonnan létrehozott diagram alapértelmezett adatokat?**

Igen. Alapértelmezés szerint a [IShapeCollection.AddChart](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addchart/) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy törölheti a sorozat- és kategóriagyűjteményeket, mielőtt teljesen egyedi adatkészletet adna hozzá. Egy túlterhelés segítségével létrehozható olyan diagram is, amely nem tartalmaz alapértelmezett adatokat.

**Hogyan kapcsolódnak a diagram objektumok a munkafüzet celláihoz?**

A sorozatnevek, a kategória címkék és az adatpont értékek egy [IChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagram elemet. Egyedi adat építésekor tartsa összhangban a kategóriasorokat és a sorozat‑érték sorokat, hogy minden pont a megfelelő kategória alatt legyen ábrázolva.

**Hogyan törölhetek egy pontot a teljes sorozat helyett?**

Állítsa a megfelelő értékcellát `null`-ra, hogy a pont kategóriahelyét üres pontként megtartsa. Használja a [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapointcollection/clear/) metódust csak akkor, ha az adott sorozat összes pontját el akarja távolítani. Ha a kategóriákat is eltávolítja, frissítse az összes sorozatot, hogy az értékek a kategóriagyűjteménnyel továbbra is össze legyenek hangolva.

**Hogyan jelennek meg az üres pontok?**

A megjelenés a diagram típusától és az [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichart/displayblanksas/) beállítástól függ. A támogatott diagramok megjeleníthetik az üresek helyét hézagként, nulla értékként vagy a szomszédos pontok összekapcsolásával. Válassza ki a beállítást, amely a prezentációban hiányzó adatok értelméhez leginkább illik.

**Hogyan formázzák a negatív értékeket?**

Támogatott sáv-, oszlop- és buborék sorozatoknál engedélyezze az [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/invertifnegative/) beállítást, és állítsa be az [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) értéket. Egy egyedi pont viselkedését felülbírálhatja az [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) segítségével. Ezek a tulajdonságok a formázást befolyásolják, nem a tárolt numerikus értékeket.

**Melyik formázás érvényesül, ha a sorozat és a pont is formázva van?**

Az explicit adatpont formázás elsőbbséget élvez az adott pontnál. A többi pont továbbra is az explicit sorozatformátumot használja, vagy ha a sorozatformátum nincs definiálva, akkor az automatikus diagramstílust és témát. A csoporttulajdonságok, mint az átfedés és a hézag szélesség, az elrendezést szabályozzák, és nem pontszintű formázási felülbírálások.

**Van korlát a diagramban szereplő sorozatok számát illetően?**

Az Aspose.Slides nem határoz meg külön rögzített sorozatszámlimitet. Gyakorlatban a bemutató fájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a használható határt.

**Mit kell módosítanom, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Állítsa be a megfelelő szülő sorozatcsoport [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) értékét. Növelje az értéket a csoportok közötti tér növeléséhez, vagy csökkentse, ha a csoportokat közelebb szeretné hozni.