---
title: Beheer grafiek-workbooks in presentaties in .NET
linktitle: Grafiek-workbook
type: docs
weight: 70
url: /nl/net/chart-workbook/
keywords:
- grafiek-workbook
- grafiekgegevens
- workbook-cel
- datummarkering
- werkblad
- gegevensbron
- extern workbook
- externe gegevens
- grafiekcache
- workbook-herstel
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontdek Aspose.Slides voor .NET: beheer moeiteloos grafiek-workbooks in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe je met grafiek‑workbooks werkt in Aspose.Slides. Het laat zien hoe je grafiekgegevens leest en schrijft via workbook‑streams, workbook‑cellen gebruikt als grafiekdatummarkeringen, werkbladverzamelingen benadert, en het type van de gegevensbron specificeert voor grafiekwaarden.

Het behandelt ook het werken met externe workbooks als gegevensbron voor grafieken. De voorbeelden tonen hoe je een extern workbook maakt en toewijst, het pad van een extern workbook dat aan een grafiek gekoppeld is ophaalt, en grafiekgegevens bewerkt wanneer het workbook beschikbaar is.

Voor workbook‑cellen die ontbrekende data vertegenwoordigen, zie [De weergave van lege cellen regelen](/slides/nl/net/chart-series/) voor het verschil tussen een lege cel en nul, en een lijngrafiekvergelijking van de beschikbare weergavemodi.

## **Grafiekgegevens lezen en schrijven vanaf een workbook**

Aspose.Slides biedt de [ReadWorkbookStream](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdata/readworkbookstream/) en [WriteWorkbookStream](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdata/writeworkbookstream/) methoden waarmee je grafiek‑workbooks (die grafiekgegevens bevatten die bewerkt zijn met Aspose.Cells) kunt lezen en schrijven. **Note** dat de grafiekgegevens op dezelfde manier georganiseerd moeten zijn of een structuur moeten hebben die vergelijkbaar is met de bron.

Deze C#‑code toont een voorbeeldbewerking:

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

### **Grafieklay-out valideren na workbook‑aanpassing**

Wanneer je een ingebed workbook vervangt door een aangepast, behoudt de grafiek de oorspronkelijke series‑ en categorieverzamelingen. Deze mismatch kan ervoor zorgen dat [IChart.ValidateChartLayout](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichart/validatechartlayout/) faalt met een index‑out‑of‑range‑fout. Wis de bestaande series en categorieën voordat je het bijgewerkte workbook terugschrijft naar de grafiek.

```csharp
// Na het aanpassen van de workbook-stream (bijv. met Aspose.Cells)
using var updatedWorkbook = chartData.ReadWorkbookStream();

// Bestaande gegevensreferenties wissen.
chartData.Series.Clear();
chartData.Categories.Clear();

updatedWorkbook.Position = 0;
chartData.WriteWorkbookStream(updatedWorkbook);

chart.ValidateChartLayout();
```

Het wissen van de verzamelingen zorgt ervoor dat de grafiekgegevensstructuur consistent is met het nieuwe workbook, waardoor `ValidateChartLayout` zonder fouten kan worden afgerond.

## **Een WorkBook‑cel instellen als grafiekdatummarkering**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia via de index.
3. Voeg een bubbelgrafiek toe met enkele gegevens.
4. Benader de grafiekseries.
5. Stel de workbook‑cel in als datummarkering.
6. Sla de presentatie op.

Deze C#‑code laat zien hoe je een workbook‑cel instelt als grafiekdatummarkering:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Instancieert een presentatieklasse die een presentatiebestand vertegenwoordigt 

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

## **Werkbladen beheren**

Deze C#‑code toont een bewerking waarbij de [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets)‑eigenschap wordt gebruikt om een werkbladverzameling te benaderen:

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

## **Gegevenstype van de gegevensbron specificeren**

Deze C#‑code laat zien hoe je een type voor een gegevensbron specificeert:

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

## **Detecteer niet‑ondersteunde ingesloten workbook‑formaten**

Aspose.Slides ondersteunt het Excel‑binaire workbook‑formaat (.xlsb) dat in sommige grafieken kan worden ingesloten niet. Je kunt de `EmbeddedWorkbookType`‑eigenschap op [IChartData](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdata/) samen met de [WorkbookType](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/workbooktype/)‑enumeratie gebruiken om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan.

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
            // Ingesloten workbook is in .xlsb-formaat, wat niet wordt ondersteund.
            continue;
        }

        // Lees of wijzig hier de grafiek-workbook-gegevens.
    }
}
```

## **Externe workbook**

Aspose.Slides ondersteunt het gebruik van externe workbooks als gegevensbron voor grafieken.

### **Een externe workbook maken**

Met de **`ReadWorkbookStream`**‑ en **`SetExternalWorkbook`**‑methoden kun je een extern workbook van nul af aan maken of een intern workbook extern maken.

Deze C#‑code demonstreert het aanmaakproces van een extern workbook:

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

### **Een externe workbook instellen**

Met de **`SetExternalWorkbook`**‑methode kun je een extern workbook aan een grafiek toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om het pad naar het externe workbook bij te werken (als dat laatste is verplaatst).

Hoewel je de gegevens in workbooks die op externe locaties of bronnen zijn opgeslagen niet kunt bewerken, kun je dergelijke workbooks nog steeds als externe gegevensbron gebruiken. Als een relatief pad voor een extern workbook wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Deze C#‑code laat zien hoe je een extern workbook instelt:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Het pad naar de documentenmap.
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

De `ChartData`‑parameter (onder de `SetExternalWorkbook`‑methode) wordt gebruikt om aan te geven of een Excel‑workbook wel of niet wordt geladen.

* Wanneer `ChartData`‑waarde is ingesteld op `false`, wordt alleen het workbook‑pad bijgewerkt — de grafiekgegevens worden niet geladen of bijgewerkt vanuit het doel‑workbook. Deze instelling kun je gebruiken wanneer het doel‑workbook niet bestaat of niet beschikbaar is.
* Wanneer `ChartData`‑waarde is ingesteld op `true`, worden de grafiekgegevens bijgewerkt vanuit het doel‑workbook.

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

### **Het pad van de externe gegevensbron‑workbook van een grafiek ophalen**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia via de index.
3. Maak een object voor de grafiekvorm.
4. Maak een object voor het bron‑type (`ChartDataSourceType`) dat de gegevensbron van de grafiek vertegenwoordigt.
5. Specificeer de relevante voorwaarde op basis van het bron‑type dat gelijk is aan het type van de externe workbook‑gegevensbron.

Deze C#‑code toont de bewerking:

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
    
    // Slaat de presentatie op
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **Grafiekgegevens bewerken**

Je kunt de gegevens in externe workbooks bewerken op dezelfde manier als je de inhoud van interne workbooks wijzigt. Wanneer een extern workbook niet kan worden geladen, wordt er een uitzondering gegooid.

Deze C#‑code implementeert het beschreven proces:

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

### **Een workbook herstellen uit de grafiek‑cache**

Als een grafiek een extern workbook gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het grafiek‑workbook reconstrueren uit de in de presentatie gecachete gegevens. Maak [LoadOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/), configureer de [SpreadsheetOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/spreadsheetoptions/), en stel [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nl/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) in op `true` voordat je de presentatie opent.

Het volgende C#‑voorbeeld opent een presentatie waarvan de grafiek verwijst naar een niet‑beschikbaar extern workbook en benadert de herstelde gegevens via [IChart.ChartData](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichart/chartdata/) en [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

// Lees of wijzig hier de herstelde workbook-gegevens.
```

Wanneer het externe workbook niet beschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een `InvalidOperationException`. Schakel herstel alleen in wanneer het gebruik van de gecachete grafiekgegevens een acceptabele fallback is, omdat de cache mogelijk geen wijzigingen bevat die na de laatste update van de presentatie in het externe workbook zijn aangebracht.

## **FAQ**

**Kan ik bepalen of een specifieke grafiek is gekoppeld aan een extern of een ingebed workbook?**  
Ja. Een grafiek heeft een [data source type](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartdata/datasourcetype/) en een [path to an external workbook](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartdata/externalworkbookpath/); als de bron een extern workbook is, kun je het volledige pad lezen om zeker te zijn dat er een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe workbooks ondersteund, en hoe worden ze opgeslagen?**  
Ja. Als je een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. Dit is handig voor de draagbaarheid van projecten; houd er echter rekening mee dat de presentatie het absolute pad opslaat in het PPTX‑bestand.

**Kan ik workbooks gebruiken die zich op netwerkresources/‑shares bevinden?**  
Ja, dergelijke workbooks kunnen worden gebruikt als een externe gegevensbron. Het rechtstreeks bewerken van remote workbooks vanuit Aspose.Slides wordt echter niet ondersteund — ze kunnen alleen als bron worden gebruikt.

**Overschrijft Aspose.Slides het externe XLSX‑bestand bij het opslaan van de presentatie?**  
Nee. De presentatie slaat een [link to the external file](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartdata/externalworkbookpath/) op en gebruikt die voor het lezen van gegevens. Het externe bestand zelf wordt niet aangepast wanneer de presentatie wordt opgeslagen.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**  
Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gebruikelijke aanpak is om de beveiliging vooraf te verwijderen of een ontsleutelde kopie (bijvoorbeeld met [Aspose.Cells](/cells/net/)) voor te bereiden en naar die kopie te linken.

**Kunnen meerdere grafieken naar hetzelfde externe workbook verwijzen?**  
Ja. Elke grafiek slaat zijn eigen link op. Als ze allemaal naar hetzelfde bestand wijzen, wordt een bijwerking van dat bestand gereflecteerd in elke grafiek de volgende keer dat de gegevens worden geladen.