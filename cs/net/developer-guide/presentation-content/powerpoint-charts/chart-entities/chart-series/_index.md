---
title: Správa řad grafu v prezentacích v .NET
linktitle: Datové řady
type: docs
url: /cs/net/chart-series/
keywords:
- řada grafu
- překrytí řady
- barva řady
- barva kategorie
- název řady
- datový bod
- mezera řady
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak spravovat řady grafu, datové body, buňky sešitu, formátování, překrytí, šířku mezery a záporné hodnoty v prezentacích s C#."
---
## **Přehled**

Graf ukládá svá vykreslená data do sešitu s daty grafu. Rozhraní [IChartSeries](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/) představuje jednu sadu souvisejících hodnot a každý [IChartDataPoint](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatapoint/) v sérii odkazuje na jednu nebo více buněk sešitu. Objekt [IChartCategory](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartcategory/) poskytuje popisky nebo hodnoty seskupení sdílené sériemi. Název série, kategorie a hodnoty bodů jsou tedy propojeny s objekty [IChartDataCell](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/) spíše než uloženy pouze jako zobrazovaný text.

U typického kategoriálního grafu výchozí sešit používá řádek 0 pro názvy sérií, sloupec 0 pro názvy kategorií a zbývající buňky pro hodnoty sérií. Indexy listu, řádku a sloupce předávané metodě [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/getcell/) jsou založeny na nule. Toto uspořádání je užitečné, když vytváříte graf s výchozími daty, ale nepředpokládejte, že každý existující graf tuto strukturu používá. Pro načtenou prezentaci nejdříve zkontrolujte buňky odkazované sériemi, kategoriemi a datovými body, než změníte hodnoty v sešitu.

Nastavení grafu mají tři různé úrovně:

- Nastavení na úrovni série, například [IChartSeries.Format](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/format/), poskytuje výchozí vzhled pro všechny body v jedné sérii.
- Nastavení datového bodu, například [IChartDataPoint.Format](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatapoint/format/), přepíše vzhled série pro jeden bod.
- Nastavení skupiny se vztahuje na kompatibilní série, které patří do stejné [IChartSeriesGroup](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseriesgroup/). Přístup ke skupině získáte přes [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/parentseriesgroup/), když potřebujete nastavit možnosti jako překrytí nebo šířku mezery.

Když není explicitně nastavena výplň bodu ani série, určuje automatický vzhled styl grafu a motiv. Pokud jsou přítomny jak nastavení série, tak nastavení bodu, přebíjí formátování bodu pro daný bod.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Nastavení překrytí řady grafu**

[IChartSeries.Overlap](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/overlap/) udává, jak moc se překrývají sloupce nebo pruhy ve 2‑D grafu, v rozmezí od ‑100 % až 100 %. Jedná se o jen‑read‑only projekci nastavení v nadřazené skupině sérií. Nastavte [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseriesgroup/overlap/), aby se aktualizovaly všechny kompatibilní série v této skupině. Tato volba se vztahuje na typy grafů, které zobrazují seskupené pruhy nebo sloupce; neovlivní nesouvisející skupiny sérií v kombinovaném grafu.

Následující příklad nastaví překrytí pro skupinu obsahující první sérii:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// Nový graf obsahuje ukázkové řady, kategorie a hodnoty.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

Výsledek:

![The series overlap](series_overlap.png)

## **Změna barvy výplně řady**

Pomocí [IChartSeries.Format](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/format/) můžete nastavit výchozí výplň pro celou sérii. Pokud má bod již explicitně nastavenou výplň, jeho nastavení [IChartDataPoint.Format](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatapoint/format/) přebije výplň série pro tento bod.

Následující příklad použije jednolitou modrou výplň pro první sérii:

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

## **Změna názvu řady**

Název řady je uložen v sešitu s daty grafu a běžně se zobrazuje v legendě. Ve výchozím sešitu vytvořeném pro seskupený sloupcový graf se buňka B1 nachází v řádku 0, sloupci 1 a obsahuje název první série. Pojmenované konstanty v následujícím příkladu tuto strukturu explicitně vymezují:

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

Můžete také aktualizovat buňku, na kterou již odkazuje [IChartSeries.Name](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/name/). Tento přístup se vyhýbá předpokladu konkrétního řádku a sloupce v existujícím grafu:

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

## **Získání automatické barvy výplně řady**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) vrací barvu vypočtenou z indexu série a stylu grafu. Jedná se o barvu používanou, když výplň řady není explicitně definována. Volání metody pouze přečte vypočtenou barvu; nepřiřadí novou výplň.

Následující příklad vypíše automatickou barvu každé výchozí série:

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

Konkrétní barvy závisejí na stylu a motivu grafu.

## **Nastavení inverzní výplně pro řadu grafu**

U sloupcových, pruhových a bublinových sérií může [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/invertifnegative/) zobrazit záporné hodnoty jinou výplní. Nastavte normální výplň řady na jednolitou, povolte inverzi a přiřaďte barvu záporné hodnoty pomocí [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Záporná čísla zůstávají v sešitu beze změny; mění se jen jejich barva při zobrazování.

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

Inverzi můžete povolit také jen pro jeden bod pomocí [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). V následujícím příkladu je inverze vypnuta pro celou sérii a zapnuta pouze pro vybraný bod. Bod je zároveň nastaven s zápornou hodnotou, aby byl efekt viditelný:

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

Chcete‑li učinit jeden bod prázdným, aniž byste odstraňovali ostatní body, nastavte buňku v sešitu, která jej podporuje, na `null`. U sloupcového grafu je vykreslená hodnota přístupná přes [IChartDataPoint.YValue](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatapoint/yvalue/). Datový bod zůstane na stejné pozici kategorie, ale graf bude interpretovat jeho hodnotu jako prázdnou dle nastavení prázdných hodnot grafu.

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

Bodové grafy používají samostatné buňky X a Y a bublinové grafy ještě buňku velikosti. Vymažte jen buňku, která představuje hodnotu, kterou chcete odstranit. Nepoužívejte [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatapointcollection/clear/), pokud chcete zachovat ostatní body, protože tato metoda odstraní všechny datové body ze sbírky.

## **Řízení zobrazení prázdných buněk**

Skryté buňky, které obsahují hodnoty, jsou odlišné od prázdných buněk. Pro zahrnutí nebo vyloučení dat ze skrytých řádků a sloupců listu viz [Include Data from Hidden Rows and Columns](/slides/cs/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Prázdná buňka v sešitu představuje chybějící data; buňka obsahující `0` představuje známou číselnou hodnotu. Nastavte [IChartDataCell.Value](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/value/) na `null`, aby se buňka stala prázdnou. Číselná nula zůstává nulou bez ohledu na nastavení prázdných buněk.

Použijte [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichart/displayblanksas/) k výběru, jak má graf zobrazovat prázdné buňky. Toto nastavení platí pro celý graf. Mění způsob, jakým jsou mezery vykresleny, aniž by prázdná buňka v sešitu byla vyplněna nulou nebo interpolovanou hodnotou.

Následující samostatný příklad vytvoří čárový graf s jednou sérií, vymaže hodnotu pro den 3 a uloží stejný graf ve všech třech režimech. Vstupní soubor není potřeba. [IChartDataWorkbook](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/) používá list 0, sloupec 0 pro popisky kategorií a sloupec 1 pro hodnoty; řádek 0 obsahuje název série. Konečná data jsou `10, 20, empty, 30, 40`.

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

Každý výstupní soubor ukládá režim přiřazený před uložením: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` a `empty_cells_Span.pptx`. Pokud chcete uložit jen jednu verzi, nastavte požadovaný režim a prezentaci uložte jednou místo iterace přes všechny režimy.

Srovnání níže ukazuje stejná data ve všech třech souborech. Den 3 je v sešitu v každém případě prázdný:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Viditelný efekt závisí na typu grafu. Čárový graf umožňuje snadno porovnat všechny tři režimy. U sloupcových a pruhových grafů není žádná čára, která by spojovala chybějící kategorii, takže `Span` nemůže vytvořit spojovací segment, který je na obrázku; chybějící sloupec a sloupec s nulovou výškou mohou vypadat podobně. Podobně scatter graf jen s body nemá spojovací čáru. Neočekávejte tři odlišné výsledky u každého typu grafu; ověřte výstup pro typ, který používáte.

## **Nastavení šířky mezery mezi řadami**

Šířka mezery je prostor mezi sousedními shluky sloupců nebo pruhů, vyjádřený v procentech šířky sloupce či pruhu. Stejně jako překrytí patří k nadřazené skupině sérií, nikoli k jedné sérii. Nastavte [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) jednou pro celou skupinu. Větší hodnota vytváří více prostoru mezi shluky; menší hodnota je dělá hustšími.

Následující příklad změní šířku mezery a uloží pouze finální prezentaci:

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

**Které typy grafů podporují datové řady?**

Všechny typy grafů reprezentované výčtem [ChartType](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/charttype/) používají data grafu, ale jejich řady nemají vždy stejnou strukturu hodnot nebo nastavení. Například kategoriální grafy používají kategorie a hodnoty, scatter grafy používají X a Y hodnoty a bublinové grafy ještě přidávají velikosti bublin. Použijte metodu tvorby datových bodů, která odpovídá typu řady. Možnosti jako překrytí a šířka mezery platí jen pro kompatibilní skupiny sloupcových nebo pruhových grafů.

**Co je skupina řad grafu?**

[IChartSeriesGroup](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseriesgroup/) obsahuje kompatibilní řady, které sdílejí nastavení na úrovni skupiny. Kombinovaný graf může obsahovat více než jednu skupinu, takže změna skupiny získané přes jednu řadu nemusí nutně změnit všechny řady v grafu.

**Obsahuje nově vytvořený graf výchozí data?**

Ano. Ve výchozím nastavení metoda [IShapeCollection.AddChart](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/addchart/) vytvoří ukázkové řady, kategorie a hodnoty. Můžete tyto buňky upravit nebo vymazat jak řady, tak i kolekce kategorií před tím, než přidáte zcela vlastní datovou sadu. Přetížená metoda může také vytvořit graf bez výchozích dat.

**Jak jsou objekty grafu propojeny s buňkami sešitu?**

Názvy řad, popisky kategorií a hodnoty datových bodů odkazují na buňky v [IChartDataWorkbook](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/). Změna odkazované buňky aktualizuje odpovídající prvek grafu. Když vytváříte vlastní data, udržujte řádky kategorií a řádky s hodnotami řad zarovnané tak, aby každý bod byl vykreslen pod správnou kategorií.

**Jak vymazat jeden bod místo celé řady?**

Nastavte příslušnou buňku s hodnotou na `null`, aby bod zůstal na své pozici kategorie jako prázdný bod. Používejte [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatapointcollection/clear/) jen tehdy, když chcete odstranit všechny body z dané řady. Pokud odstraňujete i kategorie, aktualizujte všechny řady, aby jejich hodnoty zůstaly zarovnané s kolekcí kategorií.

**Jak jsou prázdné body zobrazovány?**

Výsledek závisí na typu grafu a na [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichart/displayblanksas/). Podporované grafy mohou zobrazovat mezery jako prázdná místa, jako nulové hodnoty nebo spojením sousedních bodů. Vyberte nastavení, které odpovídá významu chybějících dat ve vaší prezentaci. Viz část **Řízení zobrazení prázdných buněk** pro kompletní příklad a vizuální srovnání.

**Jak jsou formátovány záporné hodnoty?**

U podporovaných sloupcových, pruhových a bublinových řad povolte [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/invertifnegative/) a nastavte [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Chování můžete přepsat pro jednotlivý bod pomocí [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Tyto vlastnosti ovlivňují formátování, nikoli uložené číselné hodnoty.

**Které formátování vítězí, když je formátována jak řada, tak bod?**

Explicitní formátování datového bodu má přednost pro daný bod. Ostatní body nadále používají explicitní formát řady nebo, pokud není řada definována, automatický styl a motiv grafu. Vlastnosti skupiny, jako překrytí a šířka mezery, řídí rozložení a nejsou přepisovány na úrovni bodu.

**Existuje limit počtu řad, které může graf obsahovat?**

Aspose.Slides neklade samostatný pevný limit počtu řad. V praxi rozhodují omezení souboru prezentace, dostupná paměť, doba vykreslování a čitelnost grafu.

**Co změnit, když jsou sloupce příliš blízko nebo příliš daleko od sebe?**

Nastavte [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) na příslušné nadřazené skupině řad. Zvyšte hodnotu pro rozšíření prostoru mezi shluky nebo ji snižte, aby se shluky přiblížily.