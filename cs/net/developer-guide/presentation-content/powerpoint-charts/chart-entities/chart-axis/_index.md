---
title: Přizpůsobení os grafu v prezentacích v .NET
linktitle: Osa grafu
type: docs
url: /cs/net/chart-axis/
keywords:
- osa grafu
- svislá osa
- vodorovná osa
- přizpůsobení osy
- manipulace s osou
- správa osy
- vlastnosti osy
- maximální hodnota
- minimální hodnota
- čára osy
- formát data
- název osy
- umístění osy
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Objevte, jak použít Aspose.Slides pro .NET k přizpůsobení os grafu v PowerPoint prezentacích pro zprávy a vizualizace."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit osy grafu pomocí Aspose.Slides pro .NET. Pokrývá vypočítané hodnoty os, přepínání řádků a sloupců grafu, viditelnost os, intervaly popisků kategorií a značek, datumové kategorie a formátování, rotaci názvu, umístění os, zobrazovací jednotky a logaritmické škálování.

## **Získání maximálních hodnot na svislé ose grafu**

Vytvořte [Prezentaci](https://reference.aspose.com/slides/net/aspose.slides/presentation/) a přidejte plošný graf s výchozími daty. Zavolejte [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) před čtením vypočítaných hodnot os, aby byl rozvržení grafu aktuální.

Přečtěte [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) a [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) pro limity osy a [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) a [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) pro intervaly značek. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) a [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) poskytují škály časových jednotek, které jsou relevantní pro datumové osy. Příklad uloží tyto hodnoty do lokálních proměnných a uloží graf.

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

## **Prohození dat mezi osami**

Použijte [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) k výměně rolí řad a kategorií v datech grafu. Každá bývalá kategorie se stane řadou a každá bývalá řada se stane kategorií. Tím se změní způsob seskupování dat; nevymění se však vodorovné a svislé osy. Příklad používá [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) k navázání výchozích dat na `Sheet1!A1:D5`, včetně řádku záhlaví a sloupce kategorií, před provedením výměny řádků a sloupců. Uloží graf se čtyřmi řadami a třemi kategoriemi.

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

## **Obrácení pořadí vykreslování osy**

Použijte [IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) k obrácení kategorie nebo hodnotové osy. Například vodorovný sloupcový graf může zobrazovat fáze projektu odshora dolů ve stejném pořadí jako list: Plánování, Vývoj, Testování. Obrácení osy změní směr vykreslování; neprovádí řazení ani přeskupení dat v sešitu. Naopak [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) vyměňuje role řad a kategorií.

Následující příklad vytvoří vodorovný sloupcový graf se třemi fázemi a jednou řadou. Uloží prezentaci se třemi snímky: normální pořadí, obrácené kategorie a obrácené hodnoty. Každá kopie používá stejný datový soubor a na každé kopii je obrácena pouze jedna osa.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredBar, 50, 40, 620, 320);
chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredBar);
var stages = new[] { "Planning", "Development", "Testing" };
var values = new[] { 10, 30, 20 };
for (var i = 0; i < stages.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, stages[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

// Snímek 2: zobraz první kategorii nahoře.
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// Udrž vodorovnou hodnotovou osu dole.
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// Snímek 3: obrátit pouze vodorovnou číselnou stupnici.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

Obrácení osy může také přesunout kolmé osy na opačnou stranu grafu. [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) určuje, kde se druhá osa protíná s konfigurovanou osou. Ve snímku 2 nastavení na `Maximum` na obrácené osy kategorií udržuje vodorovnou hodnotovou osu ve spodní části. Pro konkrétní průsečík použijte [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Zkontrolujte nastavení průsečíků při změně směru, zejména pokud má graf již vlastní průsečík. Nastavte `IsPlotOrderReversed` zpět na `false` pro obnovení normálního směru vykreslování; nastavení průsečíků je samostatné.

| Normální pořadí (snímek 1) | Obrácené kategorie (snímek 2) | Obrácené hodnoty (snímek 3) |
| --- | --- | --- |
| ![Vodorovný sloupcový graf s normálním pořadím kategorií a hodnotové osy](axis-order-normal.png) | ![Vodorovný sloupcový graf se zobrazenými kategoriemi odshora dolů](axis-order-categories-reversed.png) | ![Vodorovný sloupcový graf s obrácenou hodnotovou osou a nulou vpravo](axis-order-values-reversed.png) |
| Kategorie běží odspoda nahoru; hodnoty rostou zleva doprava. | Plánování, Vývoj a Testování běží odshora dolů. Hodnoty a pořadí řádků sešitu zůstávají beze změny. | Kategorie zachovávají svůj normální pořádek; hodnoty rostou zprava doleva. Kategorie osa protíná v nule vpravo. |

## **Zakázání svislé osy u čárových grafů**

Nastavte [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) na `false` u svislé osy, aby se skryla. Příklad vytvoří čárový graf s výchozími daty a uloží jej se skrytou svislou osou.

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

## **Zakázání vodorovné osy u čárových grafů**

Nastavte [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) na `false` u vodorovné osy, aby se skryla. Příklad vytvoří čárový graf s výchozími daty a uloží jej se skrytou vodorovnou osou.

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

## **Zobrazit nebo skrýt mřížky grafu**

Přečtěte [ShowMajorGridLines](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/showmajorgridlines/) a [ShowMinorGridLines](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/showminorgridlines/) pro zjištění, které mřížky osa zobrazuje. Obě vlastnosti jsou jen ke čtení. Použijte výplň čáry [MinorGridLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/minorgridlinesformat/) k zobrazení nebo skrytí drobných mřížek. Nastavte plnou výplň s viditelnou barvou, aby se zobrazily, nebo použijte `FillType.NoFill` k jejich skrytí. Odpovídající nastavení pro hlavní mřížky je [MajorGridLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorgridlinesformat/)`.Line.FillFormat`. Změna výplně mřížky zachovává viditelnost osy a značky.

Svislá osa tohoto seskupeného sloupcového grafu začíná s viditelnými hlavními mřížkami a skrytými drobnými mřížkami. Příklad nejprve zobrazí drobné mřížky v oranžové barvě a poté je opět skryje před uložením prezentace.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
var axis = chart.Axes.VerticalAxis;
Console.WriteLine($"Initial: major={axis.ShowMajorGridLines}, minor={axis.ShowMinorGridLines}");

var minorFill = axis.MinorGridLinesFormat.Line.FillFormat;
minorFill.FillType = FillType.Solid;
minorFill.SolidFillColor.Color = Color.DarkOrange;
Console.WriteLine($"Enabled: minor={axis.ShowMinorGridLines}");

minorFill.FillType = FillType.NoFill;
Console.WriteLine($"Hidden: major={axis.ShowMajorGridLines}, minor={axis.ShowMinorGridLines}");

presentation.Save("ChartGridlines.pptx", SaveFormat.Pptx);
```

| Drobná mřížka povolena | Drobná mřížka skryta |
| --- | --- |
| ![Oranžové drobné mřížky mezi hlavními mřížkami na svislé ose](minor-gridlines-enabled.png) | ![Stejný sloupcový graf jen s viditelnými hlavními mřížkami](minor-gridlines-hidden.png) |

## **Změna typu kategorie osy**

Nastavte [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) pro výběr datumové nebo textové kategorie osy. Tento příklad vyžaduje `ExistingChart.pptx`, kde je graf první tvarem na prvním snímku a buňky kategorií obsahují číselné datumové hodnoty Excelu. Změní vodorovnou osu na datumovou osu. Nastavením [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) na `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) na `1` a [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) na měsíce umístí hlavní značky v jednom měsíčním intervalu.

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

### **Určení typu kategorie osy z dat**

Po naplnění kategorií zavolejte [SetCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/setcategoryaxistypeautomatically/) a poté přečtěte [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/categoryaxistype/) pro kontrolu výběru. To je užitečné, když stejný graf dostane buď textové popisky, nebo číselné datumové hodnoty. Metoda určí typ při zavolání; neaktivuje trvalý režim, který by později přehodnocoval změny dat. Zavolejte ji znovu po nahrazení kategorií.

Následující příklad vytvoří graf s textovými kategoriemi a vypíše `Text`. Poté nahradí hodnoty buněk kategorií daty a znovu zavolá metodu, která vypíše `Date`. Data jsou uložena jako číselné hodnoty OLE Automation vrácené metodou [DateTime.ToOADate](https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tooadate), nikoli jako řetězce datumů. [CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/customnumberformat/) řídí, jak jsou tyto hodnoty zobrazeny; nepřevádí text na číselná data. Další informace o buňkách kategorií najdete v [Chart Workbook](/slides/cs/net/chart-workbook/).

Použijte automatické určení, když je vstup známý tím, že obsahuje textové kategorie nebo číselné datumy, jako v tomto příkladu. Pro běžné číselné popisky, smíšené kategorie nebo prázdná data nastavte explicitně [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/categoryaxistype/) podle zamýšleného významu. Pouze číselné hodnoty samy o sobě nestanovují, že kategorie představují datumy.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var seriesName = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);
var labels = new[] { "First", "Second", "Third" };

for (var i = 0; i < labels.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, labels[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, (i + 1) * 10);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.SetCategoryAxisTypeAutomatically();
Console.WriteLine(axis.CategoryAxisType); // Text

var dates = new[] { new DateTime(2026, 1, 1), new DateTime(2026, 1, 2), new DateTime(2026, 2, 1) };

for (var i = 0; i < dates.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0);
    categoryCell.Value = dates[i].ToOADate();
    categoryCell.CustomNumberFormat = "yyyy-mm-dd";
}

axis.SetCategoryAxisTypeAutomatically();
Console.WriteLine(axis.CategoryAxisType); // Datum

presentation.Save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
```

## **Řízení intervalů popisků osy kategorií**

Když má graf mnoho kategorií, můžete snížit počet viditelných popisků osy, aniž byste odstraňovali kategorie nebo datové body. Nastavte [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) na `false` a poté [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) na požadovaný interval kategorií. Pro textové kategorie v jejich normálním pořadí se číslování začíná od první kategorie:

| Interval | Popisky zobrazené v příkladu |
| --- | --- |
| `1` | Kategorie 1, Kategorie 2, Kategorie 3, … Kategorie 24 |
| `2` | Kategorie 1, Kategorie 3, Kategorie 5, … Kategorie 23 |
| `3` | Kategorie 1, Kategorie 4, Kategorie 7, … Kategorie 22 |

Interval `3` zobrazuje každý třetí popisek a mezi zobrazenými ponechává dva skryté. Odstraňuje odpovídající sloupce neodstraňuje. Automatické odsazení volí interval podle dostupného místa; nemusí zobrazit všechny popisky.

Značky mají samostatná nastavení. Nastavte [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) na `false` a použijte [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) k nastavení jejich intervalu. Například `1` ponechá značku u každého intervalu kategorie, zatímco popisky se objeví jen každé třetí kategorie. Nastavte [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) na viditelný styl, abyste viděli výsledek. Návrat automatického nastavení (nastavením zpět na `true`) umožní grafu znovu zvolit interval.

Následující samostatný příklad vytvoří 24 kategorií a jednu řadu a uloží tři snímky v souboru `CategoryAxisIntervals.pptx`: automatické odsazení, ruční odsazení popisků s nezávislými značkami a obnovení automatického odsazení. Obě kopie zachovávají původní data grafu. Vstupní prezentace není potřeba. Vodorovný text popisků usnadňuje rozpoznání hustoty.

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

// Snímek 2: zobrazit každý třetí popisek, ale ponechat značku pro každou kategorii.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Snímek 3: nechat graf znovu zvolit oba intervaly.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**Automatické odsazení (snímek 1):** V tomto zobrazení se ukazuje každý druhý popisek kategorie a zalamuje se na dva řádky. Výsledek se může lišit podle velikosti grafu, písma a rendereru.

![Automatické odsazení popisků kategorií se všemi 24 sloupci viditelnými](category-axis-automatic.png)

**Ruční odsazení (snímek 2):** Každý třetí popisek je zobrazen v jednom řádku, zatímco značky zůstávají u každého intervalu kategorie. Všech 24 sloupců, včetně těch bez popisků, zůstává viditelných se stejnými hodnotami. Snímek 3 obnovuje automatický vzhled uvedený výše.

![Ruční interval popisků kategorií tři se všemi 24 sloupci viditelnými](category-axis-manual.png)

### **Výběr správné osy a intervalu**

Použijte tento interval počtu kategorií pro textovou osu kategorií, například osu kategorií sloupcového, čárového, plošného nebo sloupcového grafu. Ve sloupcovém grafu je to vodorovná osa. Ve vodorovném sloupcovém grafu je osa kategorií svislá, proto použijte tato nastavení na [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Interval značek se také vztahuje na osu řad v grafech, které ji mají.

Nevyužívejte odsazení popisků kategorií k nastavení číselné stupnice hodnotové osy. Na hodnotové ose [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) určuje rozdíl ve hodnotách: například hlavní jednotka `10` vytvoří značky na 0, 10, 20 atd., pokud osa začíná nulou. Interval popisků kategorií `3` počítá pozice kategorií bez ohledu na jejich hodnoty. Bodové a bublinové grafy používají hodnotové osy místo textové osy kategorií. Pro datumovou osu použijte časové hlavní jednotky a stupnice, jak je popsáno v [Změna typu kategorie osy](#změna-typu-kategorie-osy).

## **Nastavení formátu data pro hodnoty osy kategorií**

Příklad nahradí výchozí data grafu čtyřmi ročními hodnotami. Data jsou v první tabulce (index `0`) uložena jako sériová čísla OLE Automation. Nastavte [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) na datumovou osu, deaktivujte [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) a přiřaďte `yyyy` k [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/), aby se popisky kategorií zobrazovaly jako čtyřciferné roky nezávisle na formátování buňky.

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

## **Nastavení úhlu rotace názvu osy grafu**

Povolte [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) na svislé ose, zadejte text názvu a nastavte [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) k otočení názvu. Úhel je měřen ve stupních; tento příklad uloží sloupcový graf s názvem hodnotové osy natočeným o 90 stupňů.

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

## **Nastavení polohy osy na ose kategorie nebo hodnoty**

Použijte [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) k určení, zda se hodnotová osa protíná s osou kategorií mezi kategoriemi nebo na značkách kategorií. Toto nastavení platí pro osy kategorií. Příklad nastaví tuto vlastnost na `true` na vodorovné ose kategorie sloupcového grafu a uloží výsledek.

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

## **Nastavení zobrazovací jednotky na hodnotové ose grafu**

Nastavte [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) pro škálování popisků na hodnotové ose bez změny podkladových dat. S [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) nastaveným na `Millions` se hodnota 60 000 000 zobrazí jako 60. Příklad vytvoří sloupcový graf a použije jednotku milionů na jeho svislé ose.

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

## **Konfigurace logaritmické hodnotové osy**

Logaritmická hodnotová osa je užitečná, když kladné hodnoty pokrývají několik řádů velikosti. Například služba může během pěti období přijímat 10, 100, 1 000, 10 000 a 100 000 požadavků. Na lineární stupnici jsou menší hodnoty těsně u nuly. Logaritmická stupnice usnadňuje porovnání růstu: stejné vzdálenosti představují stejné poměry, nikoli stejné rozdíly.

Nastavte [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) na `true` na hodnotové ose a použijte [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) k výběru základu. Tím se změní pouze způsob zobrazení existujících hodnot; data ani logaritmická čáru trendu se nezmění. Trendová čára představuje odhad vztahu v datech a je samostatnou funkcí.

### **Výběr hodnotové osy a základu**

Pro čárový nebo sloupcový graf je hodnotová osa [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Pro vodorovný sloupcový graf je to [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). Bodové a bublinové grafy mají dvě hodnotové osy, takže pro hodnoty X vyberte vodorovnou osu, pro Y svislou, nebo obě. Na osu kategorií logaritmické škálování nepoužívejte.

Výchozí logaritmický základ je `10`. Pro PPTX grafy můžete použít základ od `2` do `1000` včetně; podporovány jsou i zlomkové základy, např. `2.5`. Se základem `10` jsou po sobě jdoucí mocniny (10, 100, 1 000, 10 000) rovnoměrně vzdálené.

### **Porovnání lineární a logaritmické stupnice**

Následující samostatný příklad vytvoří čárový graf s pěti počty požadavků na prvním snímku a potom tento snímek zduplikuje a na druhém povolí logaritmickou hodnotovou osu s základem 10. Oba snímky zachovávají stejná data.

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

// Keep the first slide linear and change only the copy's value-axis scale.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Lineární stupnice (snímek 1):** Stejné svislé vzdálenosti představují stejné rozdíly v počtech požadavků. Největší hodnota dominuje grafu, což menší hodnoty těžko rozeznávat.

![Čárový graf v PowerPointu ukazující pět požadavků na lineární hodnotové ose](value-axis-linear.png)

**Logaritmická stupnice (snímek 2):** Stejné svislé vzdálenosti představují stejné poměry. Každé období má desetkrát více požadavků než předchozí, takže body tvoří přímou rostoucí linii na logaritmické stupnici se základem 10. Osa stále zobrazuje původní počty požadavků.

![Stejných pět požadavků v PowerPointu na logaritmické hodnotové ose se základem 10](value-axis-logarithmic.png)

### **Zpracování nulových a záporných hodnot**

Logaritmická stupnice může zobrazovat jen striktně kladné hodnoty. Zkontrolujte data před jejím zapnutím. Pokud jsou nuly nebo záporné hodnoty významné, ponechte lineární stupnici nebo je zobrazte odděleně. Pokud je jejich vyloučení vhodné pro analýzu, vysvětlete vynechání. Neskrývejte je tichým nahrazením malými kladnými čísly, protože by to změnilo význam dat. Jakékoli ručně nastavené minimum nebo maximum pro logaritmickou osu musí být také kladné.

## **Často kladené otázky**

**Jak nastavit hodnotu, ve které se jedna osa protíná s druhou (průsečík osy)?**

Použijte [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) pro výběr chování průsečíku. Pro zadání číselné hodnoty průsečíku nastavte [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Tato nastavení vám umožní posunout průsečík osy na vhodnou referenční úroveň.

**Jak mohu umístit popisky značek relativně k ose?**

Nastavte [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) pomocí [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` nebo `None`. Pro ovládání samotných značek použijte [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) nebo [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); jsou oddělené od umístění popisků.