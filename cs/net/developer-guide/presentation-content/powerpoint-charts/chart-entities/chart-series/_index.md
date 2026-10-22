---
title: Správa datových sérií grafu v prezentacích v .NET
linktitle: Datové série
type: docs
url: /cs/net/chart-series/
keywords:
- série grafu
- překrytí sérií
- barva série
- barva kategorie
- název série
- datový bod
- mezera mezi sériemi
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak spravovat série grafu, datové body, buňky sešitu, formátování, překrytí, šířku mezery a záporné hodnoty v prezentacích pomocí C#."
---
## **Přehled**

Graf může ukládat vykreslené hodnoty buď v buňkách sešitu, nebo přímo jako číselné literály. [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) představuje jednu sadu souvisejících hodnot a každý [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) představuje bod v této sérii. Objekt [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) poskytuje popisky nebo hodnoty seskupení sdílené sériemi. V grafech vytvořených s výchozími daty se názvy sérií, kategorie a hodnoty bodů používají objekty [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) ze sešitu grafu.

Pro typický kategoriový graf výchozí sešit používá řádek 0 pro názvy sérií, sloupec 0 pro názvy kategorií a zbývající buňky pro hodnoty sérií. Indexy listu, řádku a sloupce předávané metodě [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) jsou nulové. Toto rozložení je užitečné, když vytvoříte graf s výchozími daty, ale nepředpokládejte, že každý existující graf jej používá. Pro načtenou prezentaci si před změnou hodnot sešitu prohlédněte buňky, na které odkazují série, kategorie a datové body.

Nastavení grafu mají tři různé rozsahy:

- Nastavení na úrovni série, například [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/), poskytuje výchozí vzhled pro všechny body v jedné sérii.
- Nastavení datových bodů, například [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/), přepisuje vzhled série pro jeden bod.
- Skupinová nastavení platí pro kompatibilní série, které patří do stejné [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/). Přístup ke skupině získáte pomocí [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/), když potřebujete nastavit možnosti jako překrytí nebo šířku mezery.

Když není nastaven žádný explicitní výplňový bod nebo série, určuje automatický vzhled styl grafu a motiv. Když jsou přítomna jak nastavení série, tak bodu, přebíjí formátování bodu pro daný bod.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Nastavení hodnot sérií pomocí číselných literálů**

Použijte číselné literály, když hodnoty sérií pocházejí z aplikačních dat nebo výpočtů a nepotřebují odkazy na buňky listu. Nastavte [DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/) na [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) před přiřazením každému bodu jeho [Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/) pomocí [AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/).

Nastavení kolekce řídí typ zdroje všech hodnot bodů v dané sérii. [Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/) každého bodu uvádí vybraný typ; změňte jej prostřednictvím nastavení kolekce. S `Worksheet` použijte [AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/) pro přístup k odkazované buňce. S `DoubleLiterals` použijte `AsLiteralDouble` pro přímé čtení nebo zápis čísla.

Následující příklad vytvoří sloupcový graf s výchozími sériemi a kategoriemi a poté přiřadí vypočítané hodnoty 10, 20 atd. k existujícím bodům první série. Uloží prezentaci, znovu ji otevře a vytiskne uložené hodnoty.

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

Typ zdroje hodnoty bodu je oddělený od [IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/), který určuje konfiguraci interního nebo externího sešitu grafu. Použití číselných literálů samo o sobě neodstraňuje vložený sešit. V tomto příkladu zůstává sešit k dispozici pro popisky kategorií, názvy sérií a ostatní série. Viz [Sešit grafu](/slides/cs/net/chart-workbook/) pro správu sešitu.

Pro rozptylové a bublinové grafy nastavte [DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/) a [DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/) pro výběr zdrojů pro [XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/) a [YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). Bublinové grafy také používají [DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/) pro [BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/). Nastavte každý příslušný zdroj na `DoubleLiterals` před přiřazením čísel prostřednictvím vlastnosti `AsLiteralDouble` dané hodnoty.

## **Nastavení překrytí sérií grafu**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) udává, jak moc se překrývají pruhy nebo sloupce v 2D grafu, v rozmezí od -100 do 100 procent. Jedná se o jen‑čtení projekci nastavení na nadřazené skupině sérií. Nastavte [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) pro aktualizaci všech kompatibilních sérií v dané skupině. Tato volba se vztahuje na typy grafů, které zobrazují seskupené pruhy nebo sloupce; neovlivní nesouvisející skupiny sérií v kombinovaném grafu.

Následující příklad nastaví překrytí pro skupinu, která obsahuje první sérii:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// Nový graf obsahuje ukázkové série, kategorie a hodnoty.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

Výsledek:

![The series overlap](series_overlap.png)

## **Změna barvy výplně série**

Použijte [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) pro nastavení výchozí výplně celé série. Pokud má bod již explicitní výplň, jeho nastavení [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) přepisuje výplň série pro tento bod.

Následující příklad aplikuje jednotnou modrou výplň na první sérii:

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

Výsledek:

![The color of the series](series_color.png)

## **Změna názvu série**

Název série je uložen v sešitu grafu a obvykle se zobrazuje v legendě. Ve výchozím sešitu vytvořeném pro seskupený sloupcový graf je buňka B1 v řádku 0, sloupci 1 a obsahuje název první série. Následující ukázkové konstanty dělají tuto strukturu explicitní:

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

Můžete také aktualizovat buňku, na kterou již odkazuje [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/). Tento přístup se vyhýbá předpokladu konkrétního řádku a sloupce v existujícím grafu:

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

Výsledek:

![The series name](series_name.png)

### **Vytvoření série s názvem z více buněk**

Složený název série je užitečný, když je název produktu a vykazovací období uloženo v samostatných buňkách sešitu. Například můžete zkombinovat `Product A` v B1 a `2026` v C1 do jednoho názvu série a přitom ponechat oba části propojené na své zdrojové buňky.

Použijte [IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) pro získání rozsahu názvu a pak předajte tuto kolekci metodě [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/). Argument `skipHiddenCells` určuje, zda se zahrnou skryté buňky: `true` je vyloučí, `false` zahrne. Tento příklad používá `false` k zahrnutí všech buněk v rozsahu názvu.

Následující příklad vytvoří prezentaci s jednou sérií a dvěma datovými body. Buňky B1:C1 poskytují pouze název série; A2:A3 poskytují popisky kategorií a B2:B3 poskytují číselné hodnoty.

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

// Tyto dvě buňky poskytují název série.
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// Samostatné buňky poskytují kategorie a číselné datové body.
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

Výsledný název série je `Product A 2026`, s mezerou mezi dvěma hodnotami buněk. Legenda jej zobrazuje jako jeden záznam pro oba sloupce. Obrázek níže byl vygenerován ze uložené prezentace:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Získání automatické barvy výplně série**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) vrací barvu vypočítanou z indexu série a stylu grafu. Jedná se o barvu používanou, když výplň série není explicitně definována. Volání metody pouze načte vypočítanou barvu; nenastavuje novou výplň.

Následující příklad vytiskne automatickou barvu každé výchozí série:

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

Ukázkový výstup pro výchozí styl grafu:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Přesné barvy závisí na stylu a motivu grafu.

## **Nastavení invertované barvy výplně pro sérii grafu**

Pro pruhové, sloupcové a bublinové série může [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) zobrazit záporné hodnoty jinou výplní. Nastavte běžnou výplň série na jednotnou, povolte inverzi a přiřaďte barvu záporných hodnot pomocí [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Záporná čísla v sešitu zůstávají beze změny; mění se pouze jejich barva při vykreslování.

Následující příklad nahradí výchozí data grafu jednou sérií. Řádek 0 listu obsahuje název série, sloupec 0 obsahuje názvy kategorií a sloupec 1 obsahuje hodnoty:

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

Výsledek:

![The inverted solid fill color](inverted_solid_fill_color.png)

Můžete povolit inverzi pro jeden bod pomocí [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). V následujícím příkladu je inverze zakázána pro sérii a povolena jen pro vybraný bod. Bod je také přiřazen zápornou hodnotou, aby byl efekt viditelný:

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

## **Vymazání konkrétní hodnoty datového bodu**

Chcete‑li učinit jeden bod prázdným, aniž byste odstranili ostatní body, nastavte jeho buňku v sešitu na `null`. Pro sloupcový graf je vykreslená hodnota dostupná přes [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). Datový bod zůstane na stejném místě kategorie, ale graf bude jeho hodnotu považovat za prázdnou podle nastavení grafu pro prázdné hodnoty.

Následující příklad vymaže pouze druhý bod v první sérii:

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

Rozptylové grafy používají samostatné buňky X a Y a bublinové grafy také buňku velikosti. Vymažte jen buňku, která představuje hodnotu, kterou chcete odstranit. Nepoužívejte [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/), pokud chcete zachovat ostatní body, protože tato metoda odstraní všechny datové body z kolekce.

## **Řízení zobrazení prázdných buněk**

Skryté buňky, které obsahují hodnoty, jsou odlišný případ od prázdných buněk. Pro zahrnutí nebo vyloučení dat ze skrytých řádků a sloupců listu viz [Include Data from Hidden Rows and Columns](/slides/cs/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Prázdná buňka sešitu představuje chybějící data; buňka obsahující `0` představuje známou číselnou hodnotu. Nastavte [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) na `null`, aby se buňka stala prázdnou. Číselná nula zůstane nulou bez ohledu na nastavení prázdných buněk.

Použijte [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) pro volbu, jak graf zobrazuje prázdné buňky. Toto nastavení se vztahuje na celý graf. Mění způsob, jakým jsou prázdná data vykreslena, aniž by se prázdná buňka sešitu vyplnila nulou nebo interpolovanou hodnotou.

Následující samostatný příklad vytvoří čárový graf s jednou sérií, vymaže hodnotu pro Den 3 a uloží stejný graf s každým režimem. Vstupní soubor není potřeba. [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) používá list 0, sloupec 0 pro popisky kategorií a sloupec 1 pro hodnoty; řádek 0 obsahuje název série. Konečná data jsou `10, 20, empty, 30, 40`.

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

// Nechte den 3 skutečně prázdný, přičemž zachováte jeho kategorii a datový bod.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

Každý výstupní soubor ukládá režim přiřazený před uložením: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` a `empty_cells_Span.pptx`. Pro uložení jen jedné verze nastavte požadovaný režim a prezentaci uložte jednou místo iterace přes režimy.

Níže uvedené srovnání ukazuje stejná data ve všech třech souborech. Den 3 je v sešitu v každém případě prázdný:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Viditelný efekt závisí na typu grafu. Čárový graf umožňuje snadno porovnat všechny tři režimy. Pruhové a sloupcové grafy nemají čáru, kterou by mohly spojit chybějící kategorii, takže `Span` nemůže vytvořit ukázaný spojovací segment; chybějící sloupec a sloupec o výšce nula mohou vypadat podobně. Podobně rozptylový graf jen s body postrádá spojovací čáru. Neočekávejte tři odlišné výsledky u každého typu grafu; zkontrolujte výstup pro typ, který používáte.

## **Nastavení šířky mezery mezi sériemi**

Šířka mezery je prostor mezi sousedními shluky pruhů nebo sloupců, vyjádřený v procentech šířky pruhu nebo sloupce. Stejně jako překrytí patří ke skupině nadřazených sérií, nikoli k jedné sérii. Nastavte [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) jednou pro skupinu. Větší hodnota vytváří větší prostor mezi shluky; menší hodnota je dělá hustšími.

Následující příklad změní šířku mezery a uloží jen finální prezentaci:

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

Výsledek:

![The gap width](gap_width.png)

## **Často kladené dotazy**

**Které typy grafů podporují datové série?**

Všechny typy grafů reprezentované výčtem [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) používají data grafu, ale jejich série nemají vždy stejnou strukturu hodnot nebo nastavení. Například kategoriové grafy používají kategorie a hodnoty, rozptylové grafy používají X a Y hodnoty a bublinové grafy přidávají velikosti bublin. Použijte metodu vytvoření datového bodu odpovídající typu série. Volby jako překrytí a šířka mezery platí jen pro kompatibilní skupiny pruhových nebo sloupcových sérií.

**Co je skupina sérií grafu?**

[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) obsahuje kompatibilní série, které sdílejí nastavení úrovně skupiny pro vykreslování. Kombinovaný graf může obsahovat více než jednu skupinu, takže změna skupiny dosažená přes jednu sérii nutně nemění všechny série v grafu.

**Obsahuje nově vytvořený graf výchozí data?**

Ano. Ve výchozím nastavení metoda [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) vytváří ukázkové série, kategorie a hodnoty. Můžete tyto buňky upravit nebo vymazat jak sériové, tak kategoriové kolekce před přidáním zcela vlastního datového souboru. Přetížení může také vytvořit graf bez výchozích dat.

**Jak jsou objekty grafu propojeny s buňkami sešitu?**

Názvy sérií, popisky kategorií a hodnoty datových bodů odkazují na buňky v [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/). Změna odkazované buňky aktualizuje příslušný prvek grafu. Při tvorbě vlastních dat udržujte řádky kategorií a řádky hodnot sérií zarovnané, aby byl každý bod vykreslen pod zamýšlenou kategorií.

**Jak vymazat jeden bod místo celé série?**

Nastavte příslušnou buňku hodnoty na `null`, aby bod zůstal na své pozici kategorie jako prázdný bod. Používejte [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) jen když chcete odstranit všechny body ze série. Pokud také odstraňujete kategorie, aktualizujte všechny série, aby jejich hodnoty zůstaly zarovnané s kolekcí kategorií.

**Jak jsou zobrazovány prázdné body?**

Výsledek závisí na typu grafu a na [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/). Podporované grafy mohou zobrazovat prázdná místa jako mezery, jako nulové hodnoty nebo spojením sousedních bodů. Vyberte nastavení, které odpovídá významu chybějících dat ve vaší prezentaci. Viz [Řízení zobrazení prázdných buněk](#control-the-display-of-empty-cells) pro kompletní příklad a vizuální srovnání.

**Jak jsou formátovány záporné hodnoty?**

U podporovaných pruhových, sloupcových a bublinových sérií povolte [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) a nastavte [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Chování můžete přepsat pro jednotlivý bod pomocí [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Tyto vlastnosti ovlivňují formátování, nikoli uložené číselné hodnoty.

**Které formátování má přednost, když jsou formátovány jak série, tak bod?**

Explicitní formátování datového bodu má přednost pro tento bod. Ostatní body nadále používají explicitní formátování série nebo, pokud není definováno, automatický styl a motiv grafu. Vlastnosti skupiny, jako překrytí a šířka mezery, řídí rozložení a nepřepisují formátování na úrovni bodu.

**Existuje limit počtu sérií, které může graf obsahovat?**

Aspose.Slides neukládá zvláštní pevný limit počtu sérií. V praxi určují omezení souboru prezentace, dostupná paměť, čas vykreslování a čitelnost grafu praktické limity.

**Co změnit, když jsou sloupce příliš blízko nebo příliš daleko?**

Nastavte [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) na příslušné nadřazené skupině sérií. Zvyšte hodnotu pro rozšíření prostoru mezi shluky nebo ji snižte, aby se shluky přiblížily.