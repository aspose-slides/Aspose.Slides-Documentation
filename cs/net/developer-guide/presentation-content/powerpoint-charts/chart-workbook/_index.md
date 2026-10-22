---
title: Správa sešitů grafů v prezentacích v .NET
linktitle: Sešit grafu
type: docs
weight: 70
url: /cs/net/chart-workbook/
keywords:
- sešit grafu
- data grafu
- buňka sešitu
- popisek dat
- list
- zdroj dat
- externí sešit
- externí data
- mezipaměť grafu
- obnovení sešitu
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Objevte Aspose.Slides pro .NET: snadno spravujte sešity grafů ve formátech PowerPoint a OpenDocument a zjednodušte data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s sešity grafů v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu prostřednictvím streamů sešitu, používat buňky sešitu jako popisky dat grafu, přistupovat ke kolekcím listů a určit typ zdroje dat pro hodnoty grafu.

Také se zabývá používáním externích sešitů jako zdrojů dat grafu. Příklady ukazují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s grafem a upravit data grafu, když je sešit k dispozici.

Pro buňky sešitu, které představují chybějící data, viz [Ovládání zobrazování prázdných buněk](/slides/cs/net/chart-series/) pro rozdíl mezi prázdnou buňkou a nulou a pro srovnání liniového grafu dostupných režimů zobrazení.

## **Zahrnout data ze skrytých řádků a sloupců**

Použijte [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) k nastavení, zda graf vykresluje data ze skrytých řádků a sloupců listu. Nastavte na `true`, aby se vykreslovaly jen viditelné buňky, nebo na `false`, aby se zahrnovaly jak viditelné, tak skryté buňky. Toto nastavení řídí vykreslování grafu; neukrývá ani neodkrývá řádky ani sloupce listu.

[Ukázková prezentace](hidden-source-data.pptx) obsahuje sloupcový graf jako první tvar na první snímku. Vložený list `Sheet1` obsahuje následující zdrojový rozsah `A1:C4`. Řádek 3 a sloupec C jsou skryté, ale jejich buňky stále obsahují hodnoty.

| Řádek listu | A: Měsíc | B: Maloobchod | C: Velkoobchod (skrytý sloupec) |
| --- | --- | --- | --- |
| 2 | Leden | 10 | 30 |
| 3 (skrytý řádek) | Únor | 40 | 60 |
| 4 | Březen | 20 | 50 |

Přístup ke zdrojovým buňkám získáte přes [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) a čtením [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) můžete zjistit jejich stav skrytí. Tato vlastnost je jen pro čtení. V tomto souboru je B2 viditelná, B3 patří ke skrytému řádku a C2 patří ke skrytému sloupci; příklad vypíše `False`, `True` a `True`.

Pro tento příklad obnovte data grafu po změně nastavení vykreslování: zachovejte vložený sešit pomocí [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) a načtěte jej znovu pomocí [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/). Při zahrnutí všech buněk také použijte [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) k obnovení kompletního rozsahu, včetně skryté kategorie únor. Pouhé změnění příznaku není dostatečné k aktualizaci mezipaměti dat grafu a popisků kategorií v tomto ukázkovém příkladu.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("hidden-source-data.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes[0] is IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    Console.WriteLine($"B2 hidden: {workbook.GetCell(0, "B2").IsHidden}");
    Console.WriteLine($"B3 hidden: {workbook.GetCell(0, "B3").IsHidden}");
    Console.WriteLine($"C2 hidden: {workbook.GetCell(0, "C2").IsHidden}");

    using var workbookStream = chart.ChartData.ReadWorkbookStream();
    foreach (var visibleOnly in new[] { true, false })
    {
        chart.PlotVisibleCellsOnly = visibleOnly;

        // Obnovte data grafu z vloženého sešitu.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Obnovte kompletní zdrojový rozsah, včetně skrytých kategorií.
            chart.ChartData.SetRange("Sheet1!$A$1:$C$4");
        }

        presentation.Save($"hidden_cells_{visibleOnly}.pptx", SaveFormat.Pptx);
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Příklad uloží dvě verze prezentace: jednu jen s viditelnými hodnotami maloobchodu (10 a 20) a druhou se všemi šesti hodnotami. Obrázky níže byly vygenerovány ze uložených prezentací po jejich opětovném otevření; oba soubory si zachovávají nastavené nastavení vykreslování. Řádek 3 a sloupec C zůstávají ve obou vložených sešitech skryté.

| Pouze viditelné buňky (`true`) | Všechny buňky (`false`) |
| --- | --- |
| ![Pouze viditelné buňky: Hodnoty maloobchodu 10 a 20 pro leden a březen.](hidden_cells_True.png) | ![Všechny buňky: Hodnoty maloobchodu a velkoobchodu pro leden, únor a březen.](hidden_cells_False.png) |

Skrytá buňka obsahující hodnotu se liší od prázdné buňky. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) řídí, jak se zobrazují chybějící hodnoty; neobejmuje ani nevynechává skrytá zdrojová data. Viz [Ovládání zobrazování prázdných buněk](/slides/cs/net/chart-series/#control-the-display-of-empty-cells) pro příklad.

## **Získat datový rozsah grafu**

Před aktualizací dat sešitu v existující prezentaci zkontrolujte zdrojové rozsahy, abyste zjistili, které buňky listu používá jednotlivý graf. Metoda [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) vrací aktuální datový rozsah jako vzorec kvalifikovaný listem, např. `Sheet1!$A$1:$D$5`. Zde `Sheet1` je název listu, `!` jej odděluje od rozsahu buněk a `$A$1:$D$5` označuje buňky A1 až D5 včetně. Znak `$` označuje absolutní odkazy na řádky a sloupce.

Metoda přečte aktuální rozsah bez změny grafu nebo jeho sešitu. Pokud graf nepoužívá sešit jako zdroj dat, vyvolá [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Další informace najdete v [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/).

Tento příklad otevře prezentaci a prohledá tvary přímo na každém snímku, aby našel grafy. Vypíše název každého grafu a jeho zdrojový rozsah. Pokud graf nepoužívá sešit, vypíše zprávu a pokračuje dalším grafem.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            try
            {
                var range = chart.ChartData.GetRange();
                Console.WriteLine($"{chart.Name}: {range}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"{chart.Name}: The chart does not use a workbook as its data source.");
            }
        }
    }
}
```

## **Číst a zapisovat data grafu ze sešitu**

Aspose.Slides pro .NET poskytuje metody [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) a [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/), které umožňují číst a zapisovat sešity dat grafu (obsahující data grafu upravená pomocí Aspose.Cells). **Poznámka** že data grafu musejí být uspořádána stejným způsobem nebo mít strukturu podobnou zdroji.

Tento příklad používá prezentaci s grafem jako první tvar na první snímku. Načte vložený sešit do proudu, vymaže existující řady a kategorie a zapíše zpět stejný sešit. Změny zůstávají v paměti; příklad prezentaci neukládá.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **Ověřit rozvržení grafu po úpravě sešitu**

Když nahradíte vložený sešit upraveným, graf si zachová původní kolekce řad a kategorií. Tato nesrovnalost může způsobit, že [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) selže s chybou indexu mimo rozsah. Před zápisem aktualizovaného sešitu zpět do grafu vymažte existující řady a kategorie. Tento příklad používá graf, který je první tvar na první snímku. Komentář označuje místo, kde by se upravoval sešit; spustitelný příklad zapíše zpět původní sešit a ověří rozvržení v paměti.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    // Upravte stream sešitu zde, například pomocí Aspose.Cells.

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
    chart.ValidateChartLayout();
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Vymazání kolekcí odstraní zastaralé odkazy na data před zápisem sešitu. Před použitím grafu znovu sestavte potřebné mapování řad a kategorií pro aktualizovaný sešit.

## **Nastavit vlastní formáty čísel pro buňky sešitu**

Použijte [ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) k nastavení, jak se číselné hodnoty zobrazují ve vloženém sešitu grafu. Například zpráva může potřebovat zobrazit konverzní poměr jako procento se čtyřmi desetinnými místy a koeficient s pěti desetinnými místy. Udržujte obě hodnoty jako číselné, aby byly nadále k dispozici pro výpočty a vykreslování grafu.

Formát čísla mění jen zobrazení, ne uloženou hodnotu. Formát `0.0000%` zobrazí `0.125` jako `12,5000 %`; nenahradí uložené číslo `12.5`. Podobně `0.00000` zobrazí `0.1234567` jako `0.12346` bez zaokrouhlení uložené hodnoty. Pokud je vlastní formát prázdný řetězec (`""`), použije se místo něj [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/).

Následující příklad vytvoří sloupcový graf a přistoupí k jeho buňkám přes [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/). V listu 0 obsahuje B2 konverzní poměr a C2 koeficient. Obě buňky poskytují hodnoty pro graf. Příklad také povolí popisky hodnot propojené na zdrojové formáty.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 270, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
chart.HasTitle = false;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00";
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A2", "Sample");
chart.ChartData.Categories.Add(categoryCell);

var percentageCell = workbook.GetCell(0, "B2", 0.125);
percentageCell.CustomNumberFormat = "0.0000%";
var percentageName = workbook.GetCell(0, "B1", "Conversion rate");
var percentageSeries = chart.ChartData.Series.Add(percentageName, chart.Type);
percentageSeries.DataPoints.AddDataPointForBarSeries(percentageCell);

var precisionCell = workbook.GetCell(0, "C2", 0.1234567);
precisionCell.CustomNumberFormat = "0.00000";
var precisionName = workbook.GetCell(0, "C1", "Coefficient");
var precisionSeries = chart.ChartData.Series.Add(precisionName, chart.Type);
precisionSeries.DataPoints.AddDataPointForBarSeries(precisionCell);

foreach (var series in chart.ChartData.Series)
{
    var labelFormat = series.DataPoints[0].Label.DataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = true;
}

presentation.Save("CustomCellFormats.pptx", SaveFormat.Pptx);
```

Formáty buněk sešitu jsou oddělené od formátů nastavených přímo na osách grafu nebo popiscích dat. V tomto příkladu každý popisek zobrazuje hodnotu své zdrojové buňky, protože je povoleno [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) a je nastavena vlastnost [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) na `true`. Po uložení a opětovném otevření prezentace popisky zobrazí `12,5000 %` a `0,12346`, jak je ukázáno níže. Svislá osa používá svůj vlastní [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) `0.00`, přičemž [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) je nastaveno na `false`.

Pro nezávislé formátování popisku nastavte příznak propojení na zdroj na `false` a přiřaďte mu [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/). Tím se nezmění formát buňky sešitu. Například nezávislý formát popisku `0.00` zobrazí první hodnotu jako `0,13`, zatímco B2 stále zobrazuje `12,5000 %`. Viz [Popisky dat grafu](/slides/cs/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) pro přímé formátování popisků.

![Sloupcový graf se štítky propojenými na zdroj zobrazující 12,5000 % a 0,12346 a nezávisle formátovanou číselnou osou.](custom-cell-formats.png)

## **Nastavit buňku sešitu jako popisek dat grafu**

Můžete použít text z buněk sešitu jako popisky dat grafu.

Tento příklad přidá bublinový graf s výchozími daty na první snímek existující prezentace. Použije buňky A10:A12 v listu 0 pro první tři popisky v první řadě, povolí popisky z buněk a uloží aktualizovanou prezentaci.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart2.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
var series = chart.ChartData.Series[0];
var workbook = chart.ChartData.ChartDataWorkbook;

series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;
series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "Label 0 cell value");
series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Label 1 cell value");
series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Label 2 cell value");

presentation.Save("resultchart.pptx", SaveFormat.Pptx);
```

## **Spravovat listy**

Vlastnost [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) poskytuje přístup k listům v sešitu grafu. Tento příklad vytvoří koláčový graf s výchozími daty a vypíše název každého listu do konzole.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
var workbook = chart.ChartData.ChartDataWorkbook;

for (var i = 0; i < workbook.Worksheets.Count; i++)
{
    Console.WriteLine(workbook.Worksheets[i].Name);
}
```

## **Zadat typ zdroje dat**

Hodnoty bodů řady mohou být také uloženy přímo jako číselné literály. Viz [Nastavit hodnoty řady pomocí číselných literálů](/slides/cs/net/chart-series/#set-series-values-using-numeric-literals) pro kompletní příklad, který je ukládá a čte. Typ zdroje hodnot bodů je oddělený od vnitřní nebo externí konfigurace sešitu grafu; použití číselných literálů samo o sobě neodstraňuje vložený sešit.

Tento příklad vytvoří 3D sloupcový graf s výchozími daty a nastaví dva názvy řad pomocí různých zdrojů dat. První název používá řetězcový literál; druhý používá buňku C1 v listu 0. Výčtový typ [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) volí zdroj pro každý název. Příklad uloží prezentaci s aktualizovanými názvy řad.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
var literalName = chart.ChartData.Series[0].Name;

literalName.DataSourceType = DataSourceType.StringLiterals;
literalName.Data = "LiteralString";

var cellName = chart.ChartData.Series[1].Name;
var nameCell = chart.ChartData.ChartDataWorkbook.GetCell(0, "C1", "NewCell");
cellName.DataSourceType = DataSourceType.Worksheet;
cellName.Data = nameCell;

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **Detekovat nepodporované formáty vložených sešitů**

Aspose.Slides nepodporuje binární formát Excel sešitu (.xlsb), který může být vložen v některých grafech. K detekci nepodporovaných formátů a přeskočení těchto grafů můžete použít vlastnost [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) na [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) společně s výčtem [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/). Tento příklad kontroluje tvary na první snímek existující prezentace, přeskočí tvary, které nejsou grafy, a vypíše diagnostickou zprávu pro každý graf s vloženým .xlsb sešitem.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
    {
        continue;
    }

    var chartData = chart.ChartData;
    var isInternalWorkbook = chartData.DataSourceType == ChartDataSourceType.InternalWorkbook;
    var isBinaryMacro = chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console.WriteLine("Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // Přečtěte nebo upravte podporovaná data sešitu grafu zde.
}
```

## **Externí sešit**

Aspose.Slides podporuje používání externích sešitů jako zdrojů dat pro grafy.

### **Vytvořit externí sešit**

Použijte [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) a [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) k exportu vloženého sešitu grafu do souboru a propojení grafu s tímto externím sešitem.

Tento příklad vytvoří koláčový graf s výchozími daty a exportuje jeho sešit. Před přiřazením externího sešitu jako zdroj dat grafu uzavře výstupní proud a poté uloží propojenou prezentaci.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
var workbookPath = Path.GetFullPath("externalWorkbook1.xlsx");

using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var fileStream = File.Create(workbookPath))
{
    workbookStream.CopyTo(fileStream);
}

chart.ChartData.SetExternalWorkbook(workbookPath);
presentation.Save("externalWorkbook.pptx", SaveFormat.Pptx);
```

### **Nastavit externí sešit**

Pomocí metody [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) můžete přiřadit externí sešit grafu jako jeho zdroj dat. Tato metoda může být také použita k aktualizaci cesty k externímu sešitu (pokud byl přesunut).

I když není možné upravovat data v sešitech uložených na vzdálených místech nebo zdrojích, můžete takové sešity stále používat jako externí zdroj dat. Pokud je zadána relativní cesta k externímu sešitu, automaticky se převede na úplnou cestu.

Tento příklad používá externí sešit, jehož list pojmenovaný `Sheet1` obsahuje název řady v B1, názvy kategorií v A2:A4 a číselné hodnoty v B2:B4. Příklad vytvoří koláčový graf, propojí sešit a použije [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) k mapování A1:B4 na jednu řadu a tři kategorie. Uloží prezentaci s propojeným grafem.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
var chartData = chart.ChartData;
var workbookPath = Path.GetFullPath("externalWorkbook.xlsx");

chartData.SetExternalWorkbook(workbookPath);
chartData.SetRange("Sheet1!$A$1:$B$4");

presentation.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
```

Parametr `updateChartData` metody [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) určuje, zda se sešit načte.

* Když je `updateChartData` `false`, aktualizuje se jen cesta k sešitu. Data grafu nejsou načtena ani aktualizována z cílového sešitu, takže sešit může být nedostupný.
* Když je `updateChartData` `true`, data grafu jsou aktualizována z cílového sešitu.

Následující příklad přiřadí zástupnou URL s `updateChartData` nastaveným na `false`. Zachová výchozí data koláčového grafu a uloží prezentaci bez načtení nedostupného sešitu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

chart.ChartData.SetExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);
presentation.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
```

### **Získat cestu k externímu sešitu zdroje dat grafu**

Pro identifikaci sešitu propojeného s grafem zkontrolujte, zda graf používá externí zdroj dat, a získejte jeho cestu.

Tento příklad kontroluje první tvar na první snímek prezentace s propojeným externím sešitem. Pokud jde o graf propojený s externím sešitem, vypíše [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) do konzole. Poté uloží kopii prezentace.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("externalWorkbook.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    if (chartData.DataSourceType == ChartDataSourceType.ExternalWorkbook)
    {
        Console.WriteLine(chartData.ExternalWorkbookPath);
    }
    else
    {
        Console.WriteLine("The chart does not use an external workbook.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

### **Upravit data grafu**

Můžete upravovat data v externích sešitech stejným způsobem, jako provádíte změny v obsahu interních sešitů. Když nelze externí sešit načíst, je vyvolána výjimka.

Tento příklad používá graf, který je první tvar na první snímek a je propojen s dostupným externím sešitem. Nastaví hodnotu buňky prvního datového bodu v první řadě na 100 a uloží aktualizovanou prezentaci. Úprava hodnot v buňkách může aktualizovat propojený externí soubor XLSX, takže použijte kopii, pokud potřebujete zachovat původní sešit.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var series = chart.ChartData.Series;
    if (series.Count > 0 && series[0].DataPoints.Count > 0)
    {
        var valueCell = series[0].DataPoints[0].Value.AsCell;
        if (valueCell != null)
        {
            valueCell.Value = 100;
            presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
        }
        else
        {
            Console.WriteLine("The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console.WriteLine("The chart has no data points to edit.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **Obnovit sešit z mezipaměti grafu**

Pokud graf používá externí sešit, který chybí nebo není dostupný, Aspose.Slides může rekonstruovat sešit grafu z dat uložených v mezipaměti prezentace. Vytvořte [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/), nakonfigurujte jeho [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) a nastavte [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) na `true` před otevřením prezentace.

Následující C# příklad obnoví data sešitu pro graf, který je první tvar na první snímek a odkazuje na nedostupný externí sešit. Data jsou přístupná přes [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) a [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

var spreadsheetOptions = new SpreadsheetOptions
{
    RecoverWorkbookFromChartCache = true
};
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = spreadsheetOptions
};

using var presentation = new Presentation("presentation.pptx", loadOptions);
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

    // Přečtěte nebo upravte obnovená data sešitu zde.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Pokud je externí sešit nedostupný a obnovení je zakázáno, Aspose.Slides vyhodí [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Povolit obnovení použijte jen tehdy, když je akceptovatelné použít data uložená v mezipaměti grafu, protože mezipaměť nemusí obsahovat změny provedené v externím sešitu po poslední aktualizaci prezentace.

## **Často kladené otázky**

**Mohu zjistit, zda je konkrétní graf propojen s externím nebo vloženým sešitem?**

Ano. Graf má [typ zdroje dat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) a [cestu k externímu sešitu](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ověřit, že je používán externí soubor.

**Jsou podporovány relativní cesty k externím sešitům a jak jsou uloženy?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní cestu. Prezentace uloží absolutní cestu do souboru PPTX, takže přesunutí sešitu může vyžadovat aktualizaci odkazu.

**Mohu používat sešity umístěné na síťových zdrojích/sdíleních?**

Ano, takové sešity lze použít jako externí zdroj dat. Úpravy vzdálených sešitů přímo z Aspose.Slides však nejsou podporovány – lze je použít jen jako zdroj.

**Přepisuje Aspose.Slides externí XLSX při ukládání prezentace?**

Prezentace ukládá [odkaz na externí soubor](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/). Úprava dat grafu založených na buňkách může také aktualizovat propojený lokální soubor XLSX. Použijte kopii sešitu, pokud musí zůstat původní soubor beze změny.

**Co mám dělat, když je externí soubor chráněn heslem?**

Aspose.Slides nepřijímá heslo při propojení. Běžný postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (například pomocí [Aspose.Cells](https://reference.aspose.com/cells/net/)) a odkazovat na tuto kopii.

**Může více grafů odkazovat na stejný externí sešit?**

Ano. Každý graf ukládá svůj vlastní odkaz. Pokud všechny ukazují na stejný soubor, aktualizace tohoto souboru bude odražena ve všech grafech při dalším načtení dat.