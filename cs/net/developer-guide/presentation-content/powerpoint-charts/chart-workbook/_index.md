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
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Objevte Aspose.Slides pro .NET: snadno spravujte sešity grafů ve formátech PowerPoint a OpenDocument a zefektivněte data vašich prezentací."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s sešity grafů v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu prostřednictvím proudů sešitu, používat buňky sešitu jako popisky dat grafu, přistupovat ke kolekcím listů a specifikovat typ zdroje dat pro hodnoty grafu.

Také se zabývá prací s externími sešity jako zdroji dat grafu. Příklady ukazují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s grafem a upravit data grafu, když je sešit k dispozici.

## **Čtení a zápis dat grafu ze sešitu**

Aspose.Slides poskytuje metody [ReadWorkbookStream](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdata/readworkbookstream/) a [WriteWorkbookStream](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdata/writeworkbookstream/), které vám umožňují číst a zapisovat sešity dat grafu (obsahující data grafu upravená pomocí Aspose.Cells). **Poznámka** že data grafu musejí být uspořádána stejným způsobem nebo mít strukturu podobnou zdroji.

Tento C# kód demonstruje ukázkovou operaci:

```c#
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

## **Nastavení buňky sešitu jako popisky dat grafu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte bublinový graf s některými daty.
4. Přistupujte k sériím grafu.
5. Nastavte buňku sešitu jako popisek dat.
6. Uložte prezentaci.

Tento C# kód ukazuje, jak nastavit buňku sešitu jako popisek dat grafu:

```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Vytvoří instanci třídy Presentation, která představuje soubor prezentace 

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

## **Detekce nepodporovaných vložených formátů sešitu**

Aspose.Slides nepodporuje binární formát Excelu (.xlsb), který může být vložen v některých grafech. Můžete použít vlastnost `EmbeddedWorkbookType` na rozhraní [IChartData](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdata/) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/workbooktype/) k detekci nepodporovaných formátů a vynechání těchto grafů.

```csharp
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

        // Zde přečtěte nebo upravte data sešitu grafu.
    }
}
```

## **Externí sešit**

{{% alert color="primary" %}} 
Ve [Aspose.Slides 19.4](https://docs.aspose.com/slides/cs/net/aspose-slides-for-net-19-4-release-notes/) jsme implementovali podporu externích sešitů jako zdroj dat pro grafy.
{{% /alert %}} 

### **Vytvoření externího sešitu**
Pomocí metod **`ReadWorkbookStream`** a **`SetExternalWorkbook`** můžete buď vytvořit externí sešit od nuly, nebo proměnit interní sešit na externí.

Tento C# kód demonstruje proces vytvoření externího sešitu:

```c#
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
Pomocí metody **`SetExternalWorkbook`** můžete přiřadit externí sešit grafu jako jeho zdroj dat. Tato metoda může být také použita k aktualizaci cesty k externímu sešitu (pokud byl přesunut).

Ačkoli nemůžete upravovat data v sešitech uložených na vzdálených místech nebo zdrojích, můžete takové sešity i nadále používat jako externí zdroj dat. Pokud je zadána relativní cesta k externímu sešitu, automaticky se převede na úplnou cestu.

Tento C# kód ukazuje, jak nastavit externí sešit:

```c#
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

Parametr `ChartData` (v metodě `SetExternalWorkbook`) se používá k určení, zda bude excelový sešit načten nebo ne.

* Když je hodnota `ChartData` nastavena na `false`, aktualizuje se pouze cesta k sešitu – data grafu nebudou načtena ani aktualizována ze cílového sešitu. Toto nastavení může být užitečné, pokud cílový sešit neexistuje nebo není dostupný. 
* Když je hodnota `ChartData` nastavena na `true`, data grafu jsou aktualizována ze cílového sešitu.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Získání cesty k externímu zdroji sešitu grafu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Vytvořte objekt pro tvar grafu.
4. Vytvořte objekt pro typ zdroje (`ChartDataSourceType`), který představuje zdroj dat grafu.
5. Určete relevantní podmínku na základě toho, že typ zdroje je stejný jako typ externího sešitu.

Tento C# kód demonstruje operaci:

```c#
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

Data v externích sešitech můžete upravovat stejným způsobem, jako provádíte změny v obsahu interních sešitů. Pokud se externí sešit nedaří načíst, je vyvolána výjimka.

Tento C# kód je implementací popsaného procesu:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**Mohu určit, zda je konkrétní graf propojen s externím nebo vloženým sešitem?**

Ano. Graf má [typ zdroje dat](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chartdata/datasourcetype/) a [cestu k externímu sešitu](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chartdata/externalworkbookpath/); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ujistit se, že je použita externí soubor.

**Jsou relativní cesty k externím sešitům podporovány a jak jsou ukládány?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní cestu. To je výhodné pro přenositelnost projektu; mějte však na vědomí, že prezentace uloží absolutní cestu v souboru PPTX.

**Mohu použít sešity umístěné na síťových zdrojích/ sdíleních?**

Ano, takové sešity lze použít jako externí zdroj dat. Úprava vzdálených sešitů přímo z Aspose.Slides však není podporována – mohou být použity pouze jako zdroj.

**Přepisuje Aspose.Slides externí soubor XLSX při ukládání prezentace?**

Ne. Prezentace uloží [odkaz na externí soubor](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chartdata/externalworkbookpath/) a používá jej pro čtení dat. Samotný externí soubor není při ukládání prezentace upravován.

**Co mám dělat, pokud je externí soubor chráněn heslem?**

Aspose.Slides nepřijímá heslo při propojení. Běžný postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (například pomocí [Aspose.Cells](/cells/net/)) a odkazovat na tuto kopii.

**Může více grafů odkazovat na stejný externí sešit?**

Ano. Každý graf si ukládá vlastní odkaz. Pokud všechny odkazují na stejný soubor, aktualizace tohoto souboru se projeví v každém grafu při příštím načtení dat.