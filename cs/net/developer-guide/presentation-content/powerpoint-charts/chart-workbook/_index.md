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
description: "Objevte Aspose.Slides pro .NET: snadno spravujte sešity grafů v PowerPoint a formátech OpenDocument a optimalizujte data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s tabulkami grafů v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu pomocí streamů sešitu, používat buňky sešitu jako popisky dat grafu, přistupovat ke kolekcím listů a specifikovat typ zdroje dat pro hodnoty grafu.

Také se zabývá prací s externími sešity jako zdroji dat pro grafy. Příklady ukazují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s grafem a upravit data grafu, když je sešit k dispozici.

Pro buňky sešitu, které představují chybějící data, viz [Řízení zobrazení prázdných buněk](/slides/cs/net/chart-series/) pro rozdíl mezi prázdnou buňkou a nulou a srovnání liniového grafu dostupných režimů zobrazení.

## **Čtení a zápis dat grafu ze sešitu**
Aspose.Slides poskytuje metody [ReadWorkbookStream](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdata/readworkbookstream/) a [WriteWorkbookStream](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdata/writeworkbookstream/), které umožňují číst a zapisovat sešity s daty grafu (obsahující data grafu upravená pomocí Aspose.Cells). **Poznámka**: data grafu musejí být uspořádána stejným způsobem nebo mít strukturu podobnou zdroji.

Tento C# kód ukazuje ukázkovou operaci:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation pres = new Presentation("chart.pptx"))
{
    Chart chart = (Chart) pres.Slides[0].Shapes[0];
    IChartData data = chart.ChartData;

    MemoryStream stream = data.ReadWorkbookStream();

    data.Series.Clear();
    data.Categories.Clear();

    stream.Position = 0;
    data.WriteWorkbookStream(stream);
}
```

### **Ověření rozvržení grafu po úpravě sešitu**

Když nahradíte vložený sešit upraveným, graf si zachová své původní kolekce řad a kategorií. Tento nesoulad může způsobit, že [IChart.ValidateChartLayout](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichart/validatechartlayout/) selže s chybou indexu mimo rozsah. Před zápisem aktualizovaného sešitu zpět do grafu vymažte existující řady a kategorie.

```csharp
// Po úpravě streamu sešitu (např. pomocí Aspose.Cells)
using var updatedWorkbook = chartData.ReadWorkbookStream();

// Vymazat existující odkazy na data.
chartData.Series.Clear();
chartData.Categories.Clear();

updatedWorkbook.Position = 0;
chartData.WriteWorkbookStream(updatedWorkbook);

chart.ValidateChartLayout();
```

Vymazání kolekcí zajistí, že struktura dat grafu bude konzistentní s novým sešitem, což umožní metodě `ValidateChartLayout` dokončit bez chyb.

## **Nastavení buňky sešitu jako popisku dat grafu**
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte referenci snímku přes jeho index.
1. Přidejte bublinový graf s nějakými daty.
1. Přistupte k řadám grafu.
1. Nastavte buňku sešitu jako popisek dat.
1. Uložte prezentaci.

Tento C# kód ukazuje, jak nastavit buňku sešitu jako popisek dat grafu:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Vytváří instanci třídy prezentace, která představuje soubor prezentace 

using (Presentation pres = new Presentation("chart2.pptx"))
{
    ISlide slide = pres.Slides[0];


    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);

    IChartSeriesCollection series = chart.ChartData.Series;

    series[0].Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

    IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

    series[0].Labels[0].ValueFromCell = wb.GetCell(0, "A10", lbl0);
    series[0].Labels[1].ValueFromCell = wb.GetCell(0, "A11", lbl1);
    series[0].Labels[2].ValueFromCell = wb.GetCell(0, "A12", lbl2);

    pres.Save("resultchart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Správa listů**

Tento C# kód demonstruje operaci, kde se používá vlastnost [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) k přístupu ke kolekci listů:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Určení typu zdroje dat**

Tento C# kód ukazuje, jak specifikovat typ pro zdroj dat:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.ChartData.Series[0].Name;
    
    val.DataSourceType = DataSourceType.StringLiterals;
    val.Data = "LiteralString";

    val = chart.ChartData.Series[1].Name;
    val.Data = chart.ChartData.ChartDataWorkbook.GetCell(0, "B1", "NewCell");

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Detekce nepodporovaných formátů vložených sešitů**

Aspose.Slides nepodporuje binární formát Excel sešitu (.xlsb), který může být vložen v některých grafech. K detekci nepodporovaných formátů a vynechání těchto grafů můžete použít vlastnost `EmbeddedWorkbookType` na [IChartData](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdata/) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/workbooktype/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        if (shape is not IChart chart) continue;

        var chartData = chart.ChartData;

        if (chartData.DataSourceType == ChartDataSourceType.InternalWorkbook &&
            chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro)
        {
            // Vložený sešit je ve formátu .xlsb, který není podporován.
            continue;
        }

        // Zde načtěte nebo upravte data sešitu grafu.
    }
}
```

## **Externí sešit**

Aspose.Slides podporuje používání externích sešitů jako zdroj dat pro grafy.

### **Vytvoření externího sešitu**

Použitím metod **`ReadWorkbookStream`** a **`SetExternalWorkbook`** můžete buď vytvořit externí sešit od nuly, nebo učinit interní sešit externím.

Tento C# kód demonstruje proces vytvoření externího sešitu:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    const string workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
    using (FileStream fileStream = new FileStream(workbookPath, FileMode.Create))
    {
        byte[] workbookData = chart.ChartData.ReadWorkbookStream().ToArray();
        fileStream.Write(workbookData, 0, workbookData.Length);
    }
    
    chart.ChartData.SetExternalWorkbook(Path.GetFullPath(workbookPath));

    pres.Save("externalWorkbook.pptx", SaveFormat.Pptx);
}
```

### **Nastavení externího sešitu**
Pomocí metody **`SetExternalWorkbook`** můžete přiřadit externí sešit grafu jako jeho zdroj dat. Tuto metodu můžete také použít k aktualizaci cesty k externímu sešitu (pokud byl přesunut).

I když nemůžete upravovat data v sešitech uložených na vzdálených místech nebo zdrojích, můžete takové sešity i nadále používat jako externí zdroj dat. Pokud je zadána relativní cesta k externímu sešitu, automaticky se převede na úplnou cestu.

Tento C# kód ukazuje, jak nastavit externí sešit:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Cesta k adresáři dokumentů.
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.ChartData;
                    
    chartData.SetExternalWorkbook(Path.GetFullPath("externalWorkbook.xlsx"));
                  

    chartData.Series.Add(chartData.ChartDataWorkbook.GetCell(0, "B1"), ChartType.Pie);
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B2"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B3"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B4"));

    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A4"));
    pres.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
}
```

Parametr `ChartData` (pod metodou `SetExternalWorkbook`) se používá k určení, zda bude excelový sešit načten nebo ne.

* Když je hodnota `ChartData` nastavena na `false`, aktualizuje se pouze cesta k sešitu — data grafu nebudou načtena ani aktualizována ze cílového sešitu. Toto nastavení můžete použít v situaci, kdy cílový sešit neexistuje nebo není k dispozici.
* Když je hodnota `ChartData` nastavena na `true`, data grafu se aktualizují z cílového sešitu.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Získání cesty k externímu sešitu zdroje dat grafu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Získejte referenci snímku přes jeho index.
1. Vytvořte objekt pro tvar grafu.
1. Vytvořte objekt pro typ zdroje (`ChartDataSourceType`), který představuje zdroj dat grafu.
1. Určete relevantní podmínku na základě toho, že typ zdroje je stejný jako typ externího sešitu.

Tento C# kód demonstruje operaci:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // Uloží prezentaci
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **Úprava dat grafu**

Data v externích sešitech můžete upravovat stejným způsobem, jako provádíte změny v obsahu interních sešitů. Když není externí sešit možné načíst, je vyhozena výjimka.

Tento C# kód je implementací popsaného postupu:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **Obnovení sešitu z mezipaměti grafu**

Pokud graf používá externí sešit, který chybí nebo není dostupný, Aspose.Slides může rekonstruovat sešit grafu z dat uložených v mezipaměti prezentace. Vytvořte [LoadOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/), nakonfigurujte jeho [SpreadsheetOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/spreadsheetoptions/), a nastavte [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cs/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) na `true` před otevřením prezentace.

Následující C# příklad otevře prezentaci, jejíž graf odkazuje na nedostupný externí sešit, a přistoupí k obnoveným datům prostřednictvím [IChart.ChartData](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichart/chartdata/) a [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        RecoverWorkbookFromChartCache = true
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

var chart = (IChart)presentation.Slides[0].Shapes[0];
var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

// Přečtěte nebo upravte data obnoveného sešitu zde.
```

Pokud je externí sešit nedostupný a obnovení je zakázáno, Aspose.Slides vyhodí `InvalidOperationException`. Povolení obnovení použijte jen v případě, že použití dat z mezipaměti grafu je přijatelnou záložní možností, protože mezipaměť nemusí obsahovat změny provedené v externím sešitu po poslední aktualizaci prezentace.

## **Často kladené otázky**

**Mohu určit, zda je konkrétní graf propojen s externím nebo vloženým sešitem?**

Ano. Graf má [typ zdroje dat](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chartdata/datasourcetype/) a [cestu k externímu sešitu](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chartdata/externalworkbookpath/); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ověřit, že je používán externí soubor.

**Podporují se relativní cesty k externím sešitum a jak jsou uloženy?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní cestu. To je pohodlné pro přenositelnost projektu; buďte však vědomi, že prezentace uloží absolutní cestu v souboru PPTX.

**Mohu používat sešity umístěné na síťových zdrojích/sdíleních?**

Ano, takové sešity lze použít jako externí zdroj dat. Úprava vzdálených sešitů přímo z Aspose.Slides však není podporována — lze je použít pouze jako zdroj.

**Přepisuje Aspose.Slides externí soubor XLSX při ukládání prezentace?**

Ne. Prezentace uloží [odkaz na externí soubor](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chartdata/externalworkbookpath/) a používá jej ke čtení dat. Samotný externí soubor není při uložení prezentace modifikován.

**Co mám dělat, když je externí soubor chráněn heslem?**

Aspose.Slides nepřijímá heslo při vytváření odkazu. Běžný postup je předem odstranit ochranu nebo připravit dešifrovanou kopii (např. pomocí [Aspose.Cells](/cells/net/)) a odkazovat na tuto kopii.

**Může více grafů odkazovat na stejný externí sešit?**

Ano. Každý graf ukládá vlastní odkaz. Pokud všechny odkazují na stejný soubor, aktualizace tohoto souboru se projeví v každém grafu při dalším načtení dat.