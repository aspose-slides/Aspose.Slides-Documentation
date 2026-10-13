---
title: Přizpůsobení os grafu v prezentacích v .NET
linktitle: Osa grafu
type: docs
url: /cs/net/chart-axis/
keywords:
- osa grafu
- vertikální osa
- horizontální osa
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
description: "Objevte, jak pomocí Aspose.Slides pro .NET přizpůsobit osy grafů v prezentacích PowerPoint pro zprávy a vizualizace."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit osy grafu pomocí Aspose.Slides pro .NET. Pokrývá vypočítané hodnoty os, přepínání řádků a sloupců grafu, viditelnost os, intervaly popisků kategorií a značek os, datumové kategorie a formátování, otáčení názvu, umístění os, jednotky zobrazení a logaritmické škálování.

## **Získání maximálních hodnot na svislé ose grafů**

Vytvořte [Prezentaci](https://reference.aspose.com/slides/net/aspose.slides/presentation/) a přidejte plošný graf s výchozími daty. Zavolejte [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) před načtením vypočítaných hodnot os, aby byl rozvržení grafu aktuální.

Přečtěte [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) a [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) pro limity osy a [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) a [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) pro intervaly značek. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) a [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) poskytují časové jednotky, které jsou relevantní pro datumové osy. Příklad uloží tyto hodnoty do lokálních proměnných a uloží graf.

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

Použijte [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) k výměně rolí řad a kategorií v datech grafu. Každá bývalá kategorie se stane řadou a každá bývalá řada se stane kategorií. Tím se změní způsob seskupení dat; nevymění se svislá a vodorovná osa. Příklad používá [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) k navázání výchozích dat na `Sheet1!A1:D5`, včetně řádku záhlaví a sloupce kategorií, před výměnou řádků a sloupců. Uloží graf se čtyřmi řadami a třemi kategoriemi.

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

## **Zakázání svislé osy pro čárové grafy**

Nastavte [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) na `false` u svislé osy, aby byla skryta. Příklad vytvoří čárový graf s výchozími daty a uloží jej se skrytou svislou osou.

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

## **Zakázání vodorovné osy pro čárové grafy**

Nastavte [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) na `false` u vodorovné osy, aby byla skryta. Příklad vytvoří čárový graf s výchozími daty a uloží jej se skrytou vodorovnou osou.

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

## **Změna osy kategorie**

Nastavte [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) pro výběr datumové nebo textové osy kategorie. Tento příklad vyžaduje `ExistingChart.pptx`, kde je graf prvním tvarem na první snímku a buňky kategorie obsahují číselné hodnoty data v Excelu. Změní vodorovnou osu na datumovou osu. Nastavením [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) na `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) na `1` a [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) na měsíce umístí hlavní značky na interval jednoho měsíce.

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

## **Řízení intervalů popisků osy kategorie**

Když má graf mnoho kategorií, snižte počet viditelných popisků osy, aniž byste odstraňovali kategorie nebo datové body. Nastavte [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) na `false` a poté nastavte [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) na požadovaný interval kategorií. Pro textové kategorie v jejich normálním pořadí číslování začíná od první kategorie:

| Interval | Popisky zobrazené v příkladu |
| --- | --- |
| `1` | Kategorie 1, Kategorie 2, Kategorie 3, … Kategorie 24 |
| `2` | Kategorie 1, Kategorie 3, Kategorie 5, … Kategorie 23 |
| `3` | Kategorie 1, Kategorie 4, Kategorie 7, … Kategorie 22 |

Interval `3` zobrazí každý třetí popisek a mezi zobrazenými popisky skryje dva popisky. Neodstraní odpovídající sloupce. Automatické rozestupování volí interval na základě dostupného prostoru; nemusí zobrazit každý popisek.

Značky mají samostatná nastavení. Nastavte [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) na `false` a použijte [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) pro nastavení jejich intervalu. Například `1` zachová značku na každém intervalu kategorie, zatímco popisky se objeví jen každou třetí kategorií. Nastavte [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) na viditelný styl, abyste viděli výsledek. Nastavením některé z automatických vlastností zpět na `true` umožní grafu znovu zvolit tento interval.

Následující samostatný příklad vytváří 24 kategorií a jednu řadu, poté uloží tři snímky v `CategoryAxisIntervals.pptx`: automatické rozestupování, ruční rozestupování popisků s nezávislými značkami a obnovené automatické rozestupování. Obě kopie zachovávají původní data grafu. Vstupní prezentace není vyžadována. Vodorovný text popisků usnadňuje vizuální porovnání hustoty.

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

// Snímek 2: zobrazit každý třetí popisek, ale zachovat značku pro každou kategorii.
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

**Automatické rozestupování (snímek 1):** V tomto vykreslení je zobrazen každý druhý popisek kategorie a zalamuje se do dvou řádků. Automatický výsledek se může lišit podle velikosti grafu, fontů a vykreslovacího zařízení.

![Automatické rozestupování popisků kategorií se všemi 24 sloupci viditelnými](category-axis-automatic.png)

**Manuální rozestupování (snímek 2):** Každý třetí popisek je zobrazen na jednom řádku, zatímco značky zůstávají na každém intervalu kategorie. Všechny 24 sloupce, včetně těch bez popisků, zůstávají viditelné se stejnými hodnotami. Snímek 3 obnoví automatický vzhled uvedený výše.

![Manuální interval popisků kategorií tři se všemi 24 sloupci viditelnými](category-axis-manual.png)

### **Vyberte správnou osu a interval**

Použijte tento interval počtu kategorií pro textovou osu kategorie, například pro osu kategorie sloupcového, čárového, plošného nebo pruhového grafu. Ve sloupcovém grafu je to vodorovná osa. V horizontálním pruhovém grafu je osa kategorie svislá, takže tyto nastavení aplikujte na [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Rozestupování značek se také vztahuje na osu řady v grafech, které ji mají.

Nenastavujte interval popisků kategorie pro určení číselné stupnice hodnotové osy. Na hodnotové ose [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) určuje rozdíl v hodnotách: například hlavní jednotka `10` vytvoří značky při 0, 10, 20 atd., pokud osa začíná nulou. Interval popisků kategorie `3` počítá pozice kategorií bez ohledu na jejich datové hodnoty. Rozptylové a bublinové grafy používají hodnotové osy místo textové osy kategorie. Pro datumovou osu použijte časové hlavní jednotky a stupnice popsané v [Změna osy kategorie](#změna-osy-kategorie).

## **Nastavení formátu data pro hodnoty osy kategorie**

Příklad nahradí výchozí data grafu čtyřmi ročními hodnotami. Data jsou uložena jako sériová čísla OLE Automation v první tabulce (index `0`). Nastavte [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) na datumovou osu, zakažte [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) a přiřaďte `yyyy` k [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/), aby popisky kategorií zobrazovaly čtyřciferné roky nezávisle na formátování buňky.

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

## **Nastavení úhlu otočení pro název osy grafu**

Povolte [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) na svislé ose, zadejte text názvu a nastavte [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) pro otočení názvu. Úhel se měří ve stupních; tento příklad uloží sloupcový graf s názvem hodnotové osy otočeným o 90 stupňů.

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

## **Nastavení pozice osy na ose kategorie nebo hodnoty**

Použijte [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) k řízení, zda hodnotová osa protíná osu kategorie mezi kategoriemi nebo na značkách kategorie. Tato vlastnost se vztahuje na osy kategorií. Příklad nastaví tuto hodnotu na `true` u vodorovné osy kategorie sloupcového grafu a uloží výsledek.

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

## **Nastavení jednotky zobrazení na hodnotové ose grafu**

Nastavte [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) pro škálování popisků na hodnotové ose bez změny podkladových dat. S [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) nastaveným na `Millions` se hodnota 60 000 000 zobrazí jako 60. Příklad vytvoří sloupcový graf a použije jednotku zobrazení milionů na jeho svislé ose.

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

Logaritmická hodnotová osa je užitečná, když kladné hodnoty zasahují několik řádů velikosti. Například služba může během pěti období přijímat 10, 100, 1 000, 10 000 a 100 000 požadavků. Na lineární stupnici jsou menší hodnoty těsně u nuly. Logaritmická stupnice usnadňuje porovnání relativního růstu: stejné vzdálenosti představují stejné poměry, nikoli stejné rozdíly.

Nastavte [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) na `true` na hodnotové ose a použijte [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) k výběru základu. Tím se změní způsob zobrazení existujících hodnot; data se nezmění a nepřidá se logaritmická trendová čára. Trendová čára představuje vhodnou funkci pro data a je samostatnou funkcí.

### **Vyberte hodnotovou osu a základ**

U čárových a sloupcových grafů je hodnotová osa [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). U horizontálního pruhového grafu je to [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). Rozptylové a bublinové grafy mají dvě hodnotové osy, takže pro hodnoty X vyberte vodorovnou osu, pro hodnoty Y svislou osu nebo obě. Nepoužívejte logaritmické škálování na ose kategorie.

Výchozí logaritmický základ je `10`. U PPTX grafů použijte základ v rozmezí od `2` do `1000` včetně; podporovány jsou i zlomkové základy jako `2.5`. Se základem `10` jsou po sobě jdoucí mocniny 10, 100, 1 000 a 10 000 rovnoměrně rozmístěny.

### **Porovnání lineárního a logaritmického škálování**

Následující samostatný příklad vytvoří čárový graf s pěti počty požadavků na prvním snímku, poté tento snímek klonuje a na druhém povolí logaritmickou hodnotovou osu se základem 10. Oba snímky zachovají stejná data.

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

// Zachovejte první snímek lineární a změňte pouze měřítko hodnotové osy kopie.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Lineární škála (snímek 1):** Stejné vertikální vzdálenosti představují stejné rozdíly v počtech požadavků. Největší hodnota dominuje grafu, což ztěžuje rozlišení menších hodnot.

![Čárový graf v PowerPointu zobrazující pět počtů požadavků na lineární hodnotové ose](value-axis-linear.png)

**Logaritmická škála (snímek 2):** Stejné vertikální vzdálenosti představují stejné poměry. Každé období má desetkrát více požadavků než předchozí, takže body tvoří přímou rostoucí čáru na logaritmické stupnici se základem 10. Osy nadále zobrazují původní počty požadavků.

![Stejné pět požadavků v PowerPointu na logaritmické hodnotové ose se základem 10](value-axis-logarithmic.png)

### **Zpracování nulových a záporných hodnot**

Logaritmická stupnice může zobrazovat pouze přísně kladné hodnoty. Před jejím povolením zkontrolujte data. Pokud jsou nula nebo záporné hodnoty významné, zachovejte lineární stupnici nebo je zobrazte zvlášť. Pokud je vyloučení těchto hodnot vhodné pro analýzu, vysvětlete vynechání. Nikdy je neomezujte tiše malými kladnými čísly, protože by to změnilo smysl dat. Jakýkoli ručně nastavený minimum nebo maximum pro logaritmickou osu musí být také kladné.

## **Často kladené otázky**

**Jak nastavit hodnotu, při které se jedna osa protíná s druhou (průsečík osy)?**

Použijte [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) k výběru chování průsečíku. Pro určení číselné hodnoty průsečíku nastavte [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Tato nastavení umožňují posunout průsečík osy na vhodnou základnu.

**Jak mohu umístit značky popisků relativně k ose?**

Nastavte [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) pomocí [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` nebo `None`. Pro řízení samotných značek použijte [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) nebo [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); jsou oddělené od umístění popisků.