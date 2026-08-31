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
description: "Objevte Aspose.Slides pro .NET: snadno spravujte sešity grafů v formátech PowerPoint a OpenDocument a zefektivněte data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s grafickými sešity v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu pomocí streamů sešitu, používat buňky sešitu jako popisky dat grafu, přistupovat ke kolekcím listů a specifikovat typ zdroje dat pro hodnoty grafu.

Také popisuje práci s externími sešity jako zdroji dat grafu. Příklady demonstrují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s grafem a upravit data grafu, když je sešit k dispozici.

## **Čtení a zápis dat grafu ze sešitu**

Aspose.Slides poskytuje metody [ReadWorkbookStream](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdata/readworkbookstream/) a [WriteWorkbookStream](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdata/writeworkbookstream/), které umožňují číst a zapisovat sešity dat grafu (obsahující data grafu upravená pomocí Aspose.Cells). **Note** že data grafu musí být uspořádána stejným způsobem nebo mít strukturu podobnou zdroji.

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

### **Ověření rozložení grafu po úpravě sešitu**

Když nahradíte vložený sešit upraveným, graf si ponechává své původní kolekce řad a kategorií. Tento nesoulad může způsobit selhání [IChart.ValidateChartLayout](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichart/validatechartlayout/) s chybou index-out-of-range. Před zápisem aktualizovaného sešitu zpět do grafu vymažte existující řady a kategorie.

```csharp
// Po úpravě streamu sešitu (např. pomocí Aspose.Cells)
using var updatedWorkbook = chartData.ReadWorkbookStream();

// Vymažte existující odkazy na data.
chartData.Series.Clear();
chartData.Categories.Clear();

updatedWorkbook.Position = 0;
chartData.WriteWorkbookStream(updatedWorkbook);

chart.ValidateChartLayout();
```

Vymazání kolekcí zajistí, že struktura dat grafu bude korespondovat s novým sešitem, což umožní metodě `ValidateChartLayout` dokončit bez chyb.

## **Nastavení buňky sešitu jako popisků dat grafu**
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte bublinový graf s některými daty.
4. Přistupujte k řadám grafu.
5. Nastavte buňku sešitu jako popisek dat.
6. Uložte prezentaci.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Vytvoří instanci třídy prezentace, která představuje soubor prezentace 

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

Aspose.Slides nepodporuje formát binárního sešitu Excel (.xlsb), který může být vložen v některých grafech. K detekci nepodporovaných formátů a přeskakování takových grafů můžete použít vlastnost `EmbeddedWorkbookType` na rozhraní [IChartData](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdata/) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/workbooktype/).

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

{{% alert color="info" %}} 
V [Aspose.Slides 19.4](https://docs.aspose.com/slides/cs/net/aspose-slides-for-net-19-4-release-notes/) jsme zavedli podporu externích sešitů jako zdroje dat pro grafy.
{{% /alert %}} 

### **Vytvoření externího sešitu**
Pomocí metod **`ReadWorkbookStream`** a **`SetExternalWorkbook`** můžete buď vytvořit externí sešit od nuly, nebo učinit interní sešit externím.

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
Metodou **`SetExternalWorkbook`** můžete přiřadit externí sešit grafu jako jeho zdroj dat. Tuto metodu můžete také použít k aktualizaci cesty k externímu sešitu (pokud byl přesunut).

Přestože nemůžete upravovat data v sešitech uložených na vzdálených místech nebo zdrojích, můžete takové sešity stále používat jako externí zdroj dat. Pokud je zadána relativní cesta k externímu sešitu, automaticky se převede na úplnou cestu.

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

Parametr `ChartData` (ve metodě `SetExternalWorkbook`) určuje, zda se excelový sešit načte či ne. 

* Když je hodnota `ChartData` nastavena na `false`, aktualizuje se pouze cesta k sešitu – data grafu nebudou načtena ani aktualizována ze cílového sešitu. Toto nastavení je užitečné, když cílový sešit neexistuje nebo není dostupný. 
* Když je hodnota `ChartData` nastavena na `true`, data grafu jsou aktualizována ze cílového sešitu.

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
2. Získejte odkaz na snímek podle jeho indexu.
3. Vytvořte objekt pro tvar grafu.
4. Vytvořte objekt pro typ zdroje (`ChartDataSourceType`), který reprezentuje zdroj dat grafu.
5. Specifikujte odpovídající podmínku na základě toho, že typ zdroje je stejný jako typ externího sešitu.

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

Data v externích sešitech můžete upravovat stejným způsobem, jako měníte obsah interních sešitů. Když se externí sešit nepodaří načíst, je vyhozena výjimka.

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

Pokud graf používá externí sešit, který chybí nebo není dostupný, Aspose.Slides dokáže zrekonstruovat sešit grafu z dat uložených v mezipaměti prezentace. Vytvořte [LoadOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/), nastavte jeho [SpreadsheetOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/spreadsheetoptions/), a nastavte [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cs/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) na `true` před otevřením prezentace.

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

// Read or modify the recovered workbook data here.
```

Pokud je externí sešit nedostupný a obnovení je zakázáno, Aspose.Slides vyhodí `InvalidOperationException`. Povolit obnovení má smysl jen tehdy, když je použitelné spoléhat se na data z mezipaměti, protože mezipaměť nemusí obsahovat změny provedené v externím sešitu po poslední aktualizaci prezentace.

## **Často kladené otázky**

**Mohu zjistit, zda je konkrétní graf propojen s externím nebo vloženým sešitem?**

Ano. Graf má typ [zdroje dat](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chartdata/datasourcetype/) a [cestu k externímu sešitu](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chartdata/externalworkbookpath/); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ověřit, že se používá externí soubor.

**Jsou podporovány relativní cesty k externím sešitům a jak jsou ukládány?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní cestu. To je výhodné pro přenositelnost projektu; buďte však vědomi, že prezentace uloží absolutní cestu v souboru PPTX.

**Mohou být použity sešity umístěné na síťových prostředcích/sdílených složkách?**

Ano, takové sešity lze použít jako externí zdroj dat. Přímé úpravy vzdálených sešitů z Aspose.Slides však nejsou podporovány – mohou být použity pouze jako zdroj.

**Přepisuje Aspose.Slides externí XLSX při ukládání prezentace?**

Ne. Prezentace ukládá [odkaz na externí soubor](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chartdata/externalworkbookpath/) a používá jej pro čtení dat. Externí soubor není při uložení prezentace upravován.

**Co mám dělat, když je externí soubor chráněn heslem?**

Aspose.Slides nepřijímá heslo při propojení. Běžný postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (například pomocí [Aspose.Cells](/cells/net/)) a odkazovat na tuto kopii.

**Mohou více grafů odkazovat na stejný externí sešit?**

Ano. Každý graf ukládá svůj vlastní odkaz. Pokud všechny odkazují na stejný soubor, změna tohoto souboru se projeví ve všech grafech při dalším načtení dat.