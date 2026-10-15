---
title: Přizpůsobení os grafu v prezentacích v .NET
linktitle: Osa grafu
type: docs
url: /cs/net/chart-axis/
keywords:
- osa grafu
- svislá osa
- vodorovná osa
- přizpůsobit osu
- manipulovat osou
- spravovat osu
- vlastnosti osy
- maximální hodnota
- minimální hodnota
- čára osy
- formát data
- název osy
- pozice osy
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Objevte, jak použít Aspose.Slides pro .NET k přizpůsobení os grafu v PowerPoint prezentacích pro zprávy a vizualizace."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit osy grafu pomocí Aspose.Slides pro .NET. Popisuje vypočítané hodnoty os, přepínání řádků a sloupců v grafu, viditelnost os, intervaly popisků kategorií a značek os, datumové kategorie a formátování, otáčení názvu, umístění os, zobrazovací jednotky a logaritmické škálování.

## **Získat maximální hodnoty na svislé ose v grafech**

Vytvořte [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) a přidejte plošný graf s výchozími daty. Před načtením vypočítaných hodnot os zavolejte [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/), aby byl rozvržení grafu aktuální.

Načtěte [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) a [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) pro limity osy a [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) a [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) pro intervaly značek. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) a [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) poskytují časově‑jednotkové měřítka, která jsou relevantní pro datumové osy. Příklad ukládá tyto hodnoty do lokálních proměnných a ukládá graf.

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

## **Prohodit data mezi osami**

Použijte [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) k výměně rolí řad a kategorií v datech grafu. Každá bývalá kategorie se stane řadou a každá bývalá řada se stane kategorií. Tím se změní způsob seskupení dat; neprohodí se svislé a vodorovné osy. Příklad používá [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) k navázání výchozích dat na `Sheet1!A1:D5`, včetně řádku hlavičky a sloupce kategorií, před výměnou řádků a sloupců. Uloží graf se čtyřmi řadami a třemi kategoriemi.

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

## **Obrátit pořadí vykreslování osy**

Použijte [IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) k obrácení osy kategorie nebo hodnot. Například vodorovný pruhový graf může zobrazovat fáze projektu shora dolů ve stejném pořadí jako list: Plánování, Vývoj, Testování. Obrácení osy mění směr vykreslování; neseřadí ani nepřeskupí data v sešitu. Ve srovnání s tím [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) vyměňuje role řad a kategorií.

Níže uvedený příklad vytváří vodorovný pruhový graf se třemi fázemi a jednou řadou. Ukládá prezentaci se třemi snímky: normální pořadí, obrácené kategorie a obrácené hodnoty. Každá kopie používá stejný datový soubor a na každé kopii je obrácena jen jedna osa.

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

// Snímek 2: zobrazit první kategorii nahoře.
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// Zachovat vodorovnou osu hodnot dole.
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// Snímek 3: obrátit pouze vodorovnou číselnou stupnici.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

Obrácení osy může také přesunout kolmé osy na opačnou stranu grafu. [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) určuje, kde druhá osa protíná konfigurovanou osu. Ve snímku 2 nastavení na `Maximum` na obrácené ose kategorií zachovává vodorovnou osu hodnot ve spodní části. Pro konkrétní průsečík použijte [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Zkontrolujte nastavení průsečíků při změně směru, zejména pokud má graf již vlastní průsečík. Nastavte `IsPlotOrderReversed` zpět na `false` pro obnovení normálního směru vykreslování; nastavení průsečíků jsou samostatná.

| Normální pořadí (snímek 1) | Obrácené kategorie (snímek 2) | Obrácené hodnoty (snímek 3) |
| --- | --- | --- |
| ![Proužkový vodorovný graf s normálním pořádkem kategorií a osy hodnot](axis-order-normal.png) | ![Proužkový vodorovný graf se zobrazenými kategoriemi shora dolů](axis-order-categories-reversed.png) | ![Proužkový vodorovný graf s obrácenou osou hodnot a nulou vpravo](axis-order-values-reversed.png) |
| Kategorie běží od spodku k hornímu; hodnoty rostou zleva doprava. | Plánování, vývoj a testování běží shora dolů. Hodnoty a pořadí řádků sešitů zůstávají nezměněny. | Kategorie zachovávají svůj normální pořádek; hodnoty rostou zprava doleva. Osa kategorií protíná na nule vpravo. |

## **Zakázat svislou osu pro čárové grafy**

Nastavte [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) na `false` na svislé ose, aby byla skryta. Příklad vytváří čárový graf s výchozími daty a ukládá jej se skrytou svislou osou.

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

## **Zakázat vodorovnou osu pro čárové grafy**

Nastavte [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) na `false` na vodorovné ose, aby byla skryta. Příklad vytváří čárový graf s výchozími daty a ukládá jej se skrytou vodorovnou osou.

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

## **Změnit osu kategorií**

Nastavte [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) pro výběr datumové nebo textové osy kategorií. Tento příklad vyžaduje `ExistingChart.pptx`, kde je graf první tvarem na prvním snímku a buňky kategorií obsahují číselné datumové hodnoty Excelu. Přepne vodorovnou osu na datumovou osu. Nastavením [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) na `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) na `1` a [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) na měsíce umístí hlavní značky v intervalech jednoho měsíce.

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

## **Ovládání intervalů popisků osy kategorií**

Když má graf mnoho kategorií, můžete snížit počet viditelných popisků osy, aniž byste odstraňovali kategorie nebo datové body. Nastavte [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) na `false` a poté [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) na požadovaný interval kategorií. Pro textové kategorie v jejich normálním pořadí počítání začíná od první kategorie:

| Interval | Popisky zobrazené v příkladu |
| --- | --- |
| `1` | Kategorie 1, Kategorie 2, Kategorie 3, … Kategorie 24 |
| `2` | Kategorie 1, Kategorie 3, Kategorie 5, … Kategorie 23 |
| `3` | Kategorie 1, Kategorie 4, Kategorie 7, … Kategorie 22 |

Interval `3` zobrazuje každou třetí popisku, přičemž dva popisky mezi zobrazenými zůstávají skryté. Nepoškozuje to odpovídající sloupce. Automatické rozestupy volí interval podle dostupného prostoru; nemusí zobrazit každou popisku.

Značky mají samostatná nastavení. Nastavte [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) na `false` a použijte [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) k nastavení jejich intervalu. Například `1` ponechá značku na každém intervalu kategorie, zatímco popisky se zobrazí jen každou třetí kategorii. Nastavte [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) na viditelný styl, abyste viděli výsledek. Návrat automatického nastavení obou vlastností na `true` umožní grafu znovu zvolit tento interval.

Níže uvedený samostatný příklad vytváří 24 kategorií a jednu řadu, poté uloží tři snímky v `CategoryAxisIntervals.pptx`: automatické rozestupy, manuální rozestupy popisků s nezávislými značkami a obnovené automatické rozestupy. Obě kopie zachovávají původní data grafu. Vstupní prezentace není vyžadována. Horizontální text popisků usnadňuje vnímat rozdíl v hustotě.

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

// Snímek 2: zobrazit každou třetí popisku, ale zachovat značku pro každou kategorii.
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

**Automatické rozestupy (snímek 1):** V tomto zobrazení je každá druhá popiska kategorie zobrazena a zalamuje se do dvou řádků. Automatický výsledek se může lišit podle velikosti grafu, fontů a vykreslovacího mechanismu.

![Automatické rozestupy popisků kategorií se všemi 24 sloupci viditelnými](category-axis-automatic.png)

**Manuální rozestupy (snímek 2):** Každá třetí popiska je zobrazena v jednom řádku, zatímco značky zůstávají na každém intervalu kategorie. Všech 24 sloupců, včetně těch bez popisků, zůstává viditelných se stejnými hodnotami. Snímek 3 obnovuje automatický vzhled uvedený výše.

![Manuální interval popisků kategorií tři se všemi 24 sloupci viditelnými](category-axis-manual.png)

### **Zvolte správnou osu a interval**

Použijte tento interval počtu kategorií pro textovou osu kategorií, například osu kategorií sloupcového, čárového, plošného nebo pruhového grafu. Ve sloupcovém grafu je to vodorovná osa. Ve vodorovném pruhovém grafu je osa kategorií svislá, takže použijte tato nastavení na [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Rozestup značek se také vztahuje na osu řady v grafech, které ji mají.

Nenastavujte rozestup popisků kategorií pro nastavení číselné stupnice hodnotové osy. Na hodnotové ose [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) určuje rozdíl v hodnotách: například hlavní jednotka `10` vytváří značky na 0, 10, 20 atd., když osa začíná nulou. Interval popisků kategorií `3` počítá pozice kategorií bez ohledu na jejich datové hodnoty. Bodové a bublinové grafy používají hodnotové osy místo textové osy kategorií. Pro datumovou osu použijte časově‑základní hlavní jednotky a stupnice, jak je popsáno v [Změnit osu kategorií](#změnit-osu-kategorií).

## **Nastavit formát data pro hodnoty osy kategorií**

Příklad nahrazuje výchozí data grafu čtyřmi ročními hodnotami. Data jsou uložena jako sériová čísla OLE Automation v první pracovní tabulce (index `0`). Nastavte [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) na datumovou osu, vypněte [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) a přiřaďte `yyyy` k [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/), aby se popisky kategorií zobrazovaly jako čtyřčíselné roky nezávisle na formátování buněk.

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

## **Nastavit úhel otočení názvu osy grafu**

Povolte [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) na svislé ose, zadejte text názvu a nastavte [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) k otočení názvu. Úhel se měří ve stupních; tento příklad ukládá sloupcový graf s názvem osy hodnot otočeným o 90 stupňů.

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

## **Nastavit polohu osy na ose kategorií nebo hodnot**

Použijte [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) k určení, zda osa hodnot protíná osu kategorií mezi kategoriemi nebo na značkách kategorií. Tato vlastnost platí pro osy kategorií. Příklad nastaví tuto hodnotu na `true` na vodorovné ose kategorií sloupcového grafu a uloží výsledek.

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

## **Nastavit zobrazovací jednotku na ose hodnot grafu**

Nastavte [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) pro škálování popisků na ose hodnot, aniž by se změnila podkladová data. S [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) nastaveným na `Millions` se hodnota 60 000 000 zobrazí jako 60. Příklad vytváří sloupcový graf a použije jednotku milionů na své svislé ose.

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

## **Konfigurovat logaritmickou osu hodnot**

Logaritmická osa hodnot je užitečná, když kladné hodnoty pokrývají několik řádů velikosti. Například služba může během pěti období obdržet 10, 100, 1 000, 10 000 a 100 000 požadavků. Na lineární stupnici se malé hodnoty seskupí blízko nuly. Logaritmická stupnice usnadňuje porovnání relativního růstu: rovné vzdálenosti představují stejné poměry, nikoli stejné rozdíly.

Nastavte [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) na `true` na osy hodnot a použijte [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) k volbě základu. Toto mění pouze způsob, jakým jsou existující hodnoty zobrazovány; nemění data ani nepřidává logaritmickou trendovou čáru. Trendová čára představuje upravený vztah v datech a je samostatnou funkcí.

### **Zvolte osu hodnot a základ**

Pro čárový nebo sloupcový graf je osou hodnot [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Pro vodorovný pruhový graf je to [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). Bodové a bublinové grafy mají dvě osy hodnot, takže můžete zvolit vodorovnou osu pro hodnoty X, svislou osu pro hodnoty Y nebo obě. Logaritmické škálování nepoužívejte na ose kategorií.

Výchozí logaritmický základ je `10`. Pro PPTX grafy můžete použít základ od `2` do `1000` včetně; podporovány jsou i zlomkové základy jako `2.5`. Se základem `10` jsou po sobě jdoucí mocniny jako 10, 100, 1 000 a 10 000 rovnoměrně rozloženy.

### **Porovnat lineární a logaritmické škálování**

Níže uvedený samostatný příklad vytváří čárový graf s pěti počty požadavků na prvním snímku, poté tento snímek klonuje a na druhém povolí logaritmickou osu hodnot s bází 10. Oba snímky zachovávají stejná data.

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

// Udržet první snímek lineární a změnit jen měřítko osy hodnot u kopie.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Lineární měřítko (snímek 1):** Rovné vertikální vzdálenosti představují rovné rozdíly v počtech požadavků. Největší hodnota dominuje grafu, což ztěžuje rozlišení menších hodnot.

![Čárový graf v PowerPointu zobrazující pět počtů požadavků na lineární ose hodnot](value-axis-linear.png)

**Logaritmické měřítko (snímek 2):** Rovné vertikální vzdálenosti představují rovné poměry. Každé období má desetkrát více požadavků než předchozí, takže body tvoří přímou stoupající čáru na bázi 10. Popisky osy stále ukazují původní počty požadavků.

![Stejných pět požadavků v PowerPointu na logaritmické ose hodnot s bází 10](value-axis-logarithmic.png)

### **Zpracování nulových a záporných hodnot**

Logaritmické měřítko může zobrazovat jen přísně kladné hodnoty. Před jeho povolením zkontrolujte data. Pokud jsou nula nebo záporné hodnoty významné, zachovejte lineární měřítko nebo je zobrazte odděleně. Pokud je vyloučení těchto hodnot vhodné pro analýzu, vysvětlete vynechání. Nebuďte tiše nahrazovat je malými kladnými čísly, protože by to změnilo smysl dat. Jakýkoli ručně nastavený minimum nebo maximum pro logaritmickou osu musí být také kladné.

## **Často kladené otázky**

**Jak nastavit hodnotu, ve které se jedna osa protíná s druhou (průsečík os)?**

Použijte [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) pro výběr chování průsečíku. Pro zadání číselné hodnoty průsečíku nastavte [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Tato nastavení vám umožní přesunout průsečík osy na vhodnou referenční úroveň.

**Jak mohu umístit popisky značek relativně k ose?**

Nastavte [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) pomocí [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` nebo `None`. Pro řízení samotných značek použijte [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) nebo [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); ty jsou oddělené od umístění popisků.