---
title: Správa datových sérií grafů v prezentacích v .NET
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
description: "Zjistěte, jak spravovat série grafů, datové body, buňky sešitu, formátování, překrytí, šířku mezery a záporné hodnoty v prezentacích pomocí C#."
---
## **Přehled**

Graf ukládá svá vykreslená data do sešitu dat grafu. Rozhraní [IChartSeries](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/) představuje jednu sadu souvisejících hodnot a každá [IChartDataPoint](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatapoint/) v sérii odkazuje na jednu nebo více buněk sešitu. Objekty [IChartCategory](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartcategory/) poskytují popisky nebo hodnoty seskupení sdílené sériemi. Název série, kategorie a hodnoty bodů jsou proto propojeny s objekty [IChartDataCell](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/) místo toho, aby byly uloženy pouze jako zobrazovaný text.

Pro typický sloupcový graf výchozí sešit používá řádek 0 pro názvy sérií, sloupec 0 pro názvy kategorií a zbývající buňky pro hodnoty sérií. Indexy listu, řádku a sloupce předávané do [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/getcell/) jsou nulové‑založené. Toto uspořádání je užitečné, když vytváříte graf s výchozími daty, ale nepředpokládejte, že každý existující graf toto používá. Pro načtenou prezentaci před změnou hodnot sešitu zkontrolujte buňky, na které odkazují série, kategorie a datové body.

Nastavení grafu mají tři různé rozsahy:

- Nastavení na úrovni série, jako je [IChartSeries.Format](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/format/), poskytuje výchozí vzhled pro všechny body v jedné sérii.
- Nastavení datového bodu, jako je [IChartDataPoint.Format](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatapoint/format/), přepíše vzhled série pro jeden bod.
- Nastavení skupiny se vztahuje na kompatibilní série, které patří do stejné [IChartSeriesGroup](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseriesgroup/). Přistupujte ke skupině přes [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/parentseriesgroup/), když potřebujete nastavit možnosti, jako je překrytí nebo šířka mezery.

Když není nastaven explicitní výplň bodu nebo série, určuje automatický vzhled styl a motiv grafu. Pokud jsou přítomny jak formátování série, tak bodu, má přednost formátování bodu pro daný bod.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Nastavení překrytí sérií grafu**

[IChartSeries.Overlap](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/overlap/) uvádí, jak moc se překrývají sloupce nebo pruhy ve 2D grafu, v rozmezí od -100 do 100 procent. Jedná se o jen‑ke‑čtení projekci nastavení v nadřazené skupině sérií. Nastavte [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseriesgroup/overlap/), abyste aktualizovali každou kompatibilní sérii v této skupině. Tato možnost se vztahuje na typy grafů, které zobrazují seskupené sloupce nebo pruhy; neovlivňuje nesouvisející skupiny sérií v kombinovaném grafu.

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

Pomocí [IChartSeries.Format](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/format/) můžete nastavit výchozí výplň pro celou sérii. Pokud má bod již explicitní výplň, jeho nastavení [IChartDataPoint.Format](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatapoint/format/) přepíše výplň série pro tento bod.

Následující příklad použije jednolitou modrou výplň na první sérii:

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

Název série je uložen v sešitu dat grafu a normálně se zobrazí v legendě. Ve výchozím sešitu vytvořeném pro seskupený sloupcový graf je buňka B1 v řádku 0, sloupci 1 a obsahuje název první série. Pojmenované konstanty v následujícím příkladu tuto strukturu zpřehlední:

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

Můžete také aktualizovat buňku, na kterou již odkazuje [IChartSeries.Name](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/name/). Tento přístup zabraňuje předpokladu konkrétního řádku a sloupce v existujícím grafu:

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

## **Získání automatické barvy výplně série**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) vrací barvu vypočítanou z indexu série a stylu grafu. Toto je barva používaná, když výplň série nebyla explicitně definována. Volání metody pouze přečte vypočítanou barvu; nepřiřazuje novou výplň.

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

Pro pruhové, sloupcové a bublinové série může [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/invertifnegative/) zobrazit záporné hodnoty jinou výplní. Nastavte běžnou výplň série na jednolitou, povolte inverzi a přiřaďte barvu záporných hodnot pomocí [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Záporná čísla zůstávají v sešitu beze změny; mění se jen jejich zobrazovaná barva.

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

Můžete povolit inverzi jen pro jeden bod přes [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). V následujícím příkladu je inverze zakázána pro sérii a povolena jen pro vybraný bod. Bod má také přiřazenu zápornou hodnotu, aby byl efekt viditelný:

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

Chcete‑li učinit jeden bod prázdným, aniž byste odstranili ostatní body, nastavte jeho podkladovou buňku sešitu na `null`. U sloupcového grafu je vykreslená hodnota dostupná přes [IChartDataPoint.YValue](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatapoint/yvalue/). Datový bod zůstane na stejné pozici kategorie, ale graf s ním bude zacházet jako s prázdným podle nastavení prázdných hodnot grafu.

Následující příklad vymaže jen druhý bod v první sérii:

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

Bodové grafy používají samostatné buňky X a Y a bublinové grafy také buňku velikosti. Vymažte jen buňku, která představuje hodnotu, kterou chcete odstranit. Nevolajte [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatapointcollection/clear/), pokud chcete zachovat ostatní body, protože tato metoda odstraní všechny datové body ze sbírky.

## **Ovládání zobrazení prázdných buněk**

Prázdná buňka sešitu představuje chybějící data; buňka obsahující `0` představuje známou číselnou hodnotu. Nastavte [IChartDataCell.Value](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/value/) na `null`, aby buňka byla prázdná. Číselná nula zůstane nulou bez ohledu na nastavení prázdných buněk.

Pomocí [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichart/displayblanksas/) zvolte, jak graf zobrazí prázdné buňky. Toto nastavení se vztahuje na celý graf. Mění způsob, jakým jsou mezery vykresleny, aniž by se prázdná buňka vyplnila nulou nebo interpolovanou hodnotou.

Následující samostatný příklad vytvoří čárový graf s jednou sérií, vymaže hodnotu pro den 3 a uloží stejný graf ve všech režimech. Vstupní soubor není potřeba. [IChartDataWorkbook](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/) používá list 0, sloupec 0 pro popisky kategorií a sloupec 1 pro hodnoty; řádek 0 obsahuje název série. Konečná data jsou `10, 20, empty, 30, 40`.

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

Každý výstupní soubor uchovává režim přiřazený před uložením: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` a `empty_cells_Span.pptx`. Pro uložení jen jedné verze přiřaďte požadovaný režim a prezentaci uložte jednou místo iterace přes režimy.

Porovnání níže ukazuje stejná data ve všech třech souborech. Den 3 je v sešitu prázdný ve všech případech:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Viditelný efekt závisí na typu grafu. Čárový graf umožňuje snadné porovnání všech tří režimů. Pruh a sloupec nemají čáru, která by spojila chybějící kategorii, takže `Span` nemůže vytvořit segment zobrazený výše; chybějící sloupec a sloupec s nulovou výškou mohou vypadat podobně. Podobně scatter graf jen s markery nemá spojovací čáru. Neočekávejte tři odlišné výsledky pro každý typ grafu; zkontrolujte výstup pro typ, který používáte.

## **Nastavení šířky mezery sérií**

Šířka mezery je prostor mezi sousedními shluky pruhů nebo sloupců, vyjádřený v procentech šířky pruhu nebo sloupce. Stejně jako překrytí patří k nadřazené skupině sérií, nikoli k jedné sérii. Nastavte [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) jednou pro celou skupinu. Větší hodnota vytvoří více prostoru mezi shluky; menší hodnota je učiní hustšími.

Následující příklad změní šířku mezery a uloží jen konečnou prezentaci:

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

## **Často kladené otázky**

**Které typy grafů podporují datové série?**

Všechny typy grafů zastoupené výčtem [ChartType](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/charttype/) používají data grafu, ale jejich série nemají vždy stejnou strukturu hodnot ani stejná nastavení. Například kategoriální grafy používají kategorie a hodnoty, scatter grafy používají hodnoty X a Y a bubble grafy přidávají velikosti bublin. Používejte metodu vytváření datových bodů, která odpovídá typu série. Možnosti jako překrytí a šířka mezery platí jen pro kompatibilní skupiny pruhových nebo sloupcových grafů.

**Co je skupina sérií grafu?**

[IChartSeriesGroup](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseriesgroup/) obsahuje kompatibilní série, které sdílejí nastavení na úrovni skupiny. Kombinovaný graf může obsahovat více než jednu skupinu, takže změna skupiny získané přes jednu sérii nemusí nutně změnit všechny série v grafu.

**Obsahuje nově vytvořený graf výchozí data?**

Ano. Ve výchozím nastavení metoda [IShapeCollection.AddChart](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/addchart/) vytvoří ukázkové série, kategorie a hodnoty. Můžete tyto buňky upravit nebo před přidáním zcela vlastního datového souboru vymazat jak kolekce sérií, tak kolekce kategorií. Přetížená metoda může také vytvořit graf bez výchozích dat.

**Jak jsou objekty grafu propojeny s buňkami sešitu?**

Názvy sérií, popisky kategorií a hodnoty datových bodů odkazují na buňky v [IChartDataWorkbook](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/). Změna odkazované buňky aktualizuje odpovídající prvek grafu. Když vytváříte vlastní data, udržujte řádky kategorií a řádky hodnot sérií zarovnané, aby každý bod byl vykreslen pod správnou kategorií.

**Jak vymazat jeden bod místo celé série?**

Nastavte relevantní buňku s hodnotou na `null`, aby bod zachoval svou pozici v kategorii jako prázdný bod. Používejte [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatapointcollection/clear/) jen tehdy, když chcete odstranit všechny body z dané série. Pokud také odstraňujete kategorie, aktualizujte všechny série tak, aby jejich hodnoty zůstaly zarovnané s kolekcí kategorií.

**Jak jsou prázdné body zobrazovány?**

Výsledek závisí na typu grafu a na [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichart/displayblanksas/). Podporované grafy mohou zobrazovat mezery jako mezery, jako nuly nebo spojením sousedních bodů. Zvolte nastavení, které odpovídá významu chybějících dat ve vaší prezentaci. Viz kapitola **Ovládání zobrazení prázdných buněk** pro úplný příklad a vizuální porovnání.

**Jak jsou formátovány záporné hodnoty?**

U podporovaných pruhových, sloupcových a bublinových sérií povolte [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/invertifnegative/) a nastavte [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Chování můžete přepsat pro jednotlivý bod pomocí [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Tyto vlastnosti ovlivňují formátování, ne uložené číselné hodnoty.

**Které formátování vítězí, když jsou formátovány jak série, tak bod?**

Explicitní formátování datového bodu má přednost pro tento bod. Ostatní body nadále používají explicitní formátování série nebo, pokud není formát série definován, automatický styl a motiv grafu. Vlastnosti skupiny jako překrytí a šířka mezery řídí rozložení a nejsou přepisovány na úrovni bodu.

**Existuje limit počtu sérií, které může graf obsahovat?**

Aspose.Slides neklade samostatný pevný limit pro počet sérií. V praxi určují omezení souboru prezentace, dostupná paměť, doba vykreslování a čitelnost grafu praktické limity.

**Co změnit, když jsou sloupce příliš blízko nebo příliš daleko od sebe?**

Nastavte [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) na vhodné nadřazené skupině sérií. Zvýšením hodnoty rozšíříte prostor mezi shluky, snížením jej přiblížíte.