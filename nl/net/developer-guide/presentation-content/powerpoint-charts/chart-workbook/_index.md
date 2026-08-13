---
title: Beheer grafiekwerkboeken in presentaties in .NET
linktitle: Grafiekwerkboek
type: docs
weight: 70
url: /nl/net/chart-workbook/
keywords:
- grafiekwerkboek
- grafiekgegevens
- werkboekcel
- databelabel
- werkblad
- gegevensbron
- extern werkboek
- externe gegevens
- grafiekcache
- werkboekherstel
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontdek Aspose.Slides voor .NET: beheer moeiteloos grafiekwerkboeken in PowerPoint- en OpenDocument-formaten om de gegevens van uw presentatie te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiek‑werkboeken in Aspose.Slides kunt werken. Het laat zien hoe u grafiekgegevens kunt lezen en schrijven via werkboek‑streams, werkboekcellen kunt gebruiken als grafiek‑datlabels, toegang krijgt tot werkbladcollecties en het gegevenstype voor grafiekwaarden kunt opgeven.

Het behandelt tevens het gebruik van externe werkboeken als gegevensbron voor grafieken. De voorbeelden laten zien hoe u een extern werkboek maakt en toewijst, het pad van een extern werkboek dat aan een grafiek is gekoppeld opvraagt, en grafiekgegevens bewerkt wanneer het werkboek beschikbaar is.

## **Grafiekgegevens lezen en schrijven vanuit een werkboek**
Aspose.Slides biedt de [ReadWorkbookStream](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdata/readworkbookstream/) en [WriteWorkbookStream](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdata/writeworkbookstream/) methoden die u in staat stellen grafiek‑werkboeken (bevatten grafiekgegevens bewerkt met Aspose.Cells) te lezen en te schrijven. **Opmerking** dat de grafiekgegevens op dezelfde manier moeten zijn georganiseerd of een structuur moeten hebben die vergelijkbaar is met de bron.

Deze C#‑code toont een voorbeeldoperatie:

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

## **Een werkboekcel instellen als grafiek‑datlabel**
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een verwijzing naar een dia via de index.
1. Voeg een bolgrafiek toe met enkele gegevens.
1. Open de grafiekserie.
1. Stel de werkboekcel in als datlabel.
1. Sla de presentatie op.

Deze C#‑code laat zien hoe u een werkboekcel instelt als grafiek‑datlabel:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Maakt een presentatieklasse aan die een presentatiebestand vertegenwoordigt 

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

Deze C#‑code demonstreert een operatie waarbij de [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets)‑eigenschap wordt gebruikt om toegang te krijgen tot een werkbladcollectie:

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

## **Het gegevenstype voor de bron opgeven**

Deze C#‑code laat zien hoe u een type opgeeft voor een gegevensbron:

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

## **Detectie van niet‑ondersteunde ingesloten werkboekformaten**

Aspose.Slides ondersteunt het Excel‑binaire werkboekformaat (.xlsb) niet, dat in sommige grafieken kan worden ingesloten. U kunt de `EmbeddedWorkbookType`‑eigenschap op [IChartData](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdata/) samen met de [WorkbookType](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/workbooktype/)‑enumeratie gebruiken om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan.

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
            // Ingebed werkboek is in .xlsb-formaat, wat niet ondersteund wordt.
            continue;
        }

        // Lees of wijzig hier de grafiekwerkboekgegevens.
    }
}
```

## **Extern werkboek**

{{% alert color="info" %}} 
In [Aspose.Slides 19.4](https://docs.aspose.com/slides/nl/net/aspose-slides-for-net-19-4-release-notes/) hebben we ondersteuning toegevoegd voor externe werkboeken als gegevensbron voor grafieken.
{{% /alert %}} 

### **Een extern werkboek maken**
Met de **`ReadWorkbookStream`**‑ en **`SetExternalWorkbook`**‑methoden kunt u ofwel een extern werkboek vanaf nul creëren of een intern werkboek extern maken.

Deze C#‑code demonstreert het proces van het maken van een extern werkboek:

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

### **Een extern werkboek instellen**
Met de **`SetExternalWorkbook`**‑methode kunt u een extern werkboek aan een grafiek toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om een pad naar het externe werkboek bij te werken (als het laatstgenoemde is verplaatst).

Hoewel u de gegevens in werkboeken die op externe locaties of resources zijn opgeslagen niet kunt bewerken, kunt u dergelijke werkboeken nog steeds als externe gegevensbron gebruiken. Als een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Deze C#‑code laat zien hoe u een extern werkboek instelt:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Het pad naar de documentmap.
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

De parameter `ChartData` (onder de `SetExternalWorkbook`‑methode) wordt gebruikt om op te geven of een Excel‑werkboek wel of niet wordt geladen.

* Als `ChartData` = `false`, wordt alleen het werkboekpad bijgewerkt – de grafiekgegevens worden niet geladen of bijgewerkt vanuit het doelwerkboek. Gebruik deze instelling bijvoorbeeld wanneer het doelwerkboek niet bestaat of niet beschikbaar is.
* Als `ChartData` = `true`, worden de grafiekgegevens bijgewerkt vanuit het doelwerkboek.

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

### **Het pad van de externe gegevensbron‑werkboek van een grafiek opvragen**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Verkrijg een verwijzing naar een dia via de index.
1. Maak een object voor de grafiekvorm.
1. Maak een object voor het bron‑type (`ChartDataSourceType`) dat de gegevensbron van de grafiek vertegenwoordigt.
1. Geef de relevante voorwaarde op op basis van of het bron‑type gelijk is aan het type van de externe werkboek‑gegevensbron.

Deze C#‑code demonstreert de bewerking:

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

U kunt de gegevens in externe werkboeken op dezelfde manier bewerken als bij interne werkboeken. Wanneer een extern werkboek niet kan worden geladen, wordt er een uitzondering gegenereerd.

Deze C#‑code is een implementatie van het beschreven proces:

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

### **Een werkboek herstellen vanuit de grafiek‑cache**

Als een grafiek een extern werkboek gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het grafiek‑werkboek reconstrueren vanuit de in de presentatie gecachete gegevens. Maak een [LoadOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/)‑object, configureer de [SpreadsheetOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/spreadsheetoptions/), en stel [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nl/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) in op `true` vóór het openen van de presentatie.

Het volgende C#‑voorbeeld opent een presentatie waarvan de grafiek een niet‑beschikbaar extern werkboek referereert en krijgt toegang tot de herstelde gegevens via [IChart.ChartData](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichart/chartdata/) en [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

Als het externe werkboek niet beschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een `InvalidOperationException`. Schakel herstel alleen in wanneer het gebruiken van de gecachete grafiekgegevens een aanvaardbare fallback is, omdat de cache mogelijk geen wijzigingen bevat die in het externe werkboek zijn aangebracht nadat de presentatie voor het laatst is bijgewerkt.

## **FAQ**

**Kan ik bepalen of een specifieke grafiek is gekoppeld aan een extern of een ingesloten werkboek?**

Ja. Een grafiek heeft een [data source type](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartdata/datasourcetype/) en een [path to an external workbook](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartdata/externalworkbookpath/); als de bron een extern werkboek is, kunt u het volledige pad lezen om te bevestigen dat er een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. Dit is handig voor projectportabiliteit; let wel op dat de presentatie het absolute pad in het PPTX‑bestand opslaat.

**Kan ik werkboeken gebruiken die zich op netwerkresources / shares bevinden?**

Ja, dergelijke werkboeken kunnen als externe gegevensbron worden gebruikt. Direct bewerken van remote werkboeken vanuit Aspose.Slides wordt echter niet ondersteund – ze kunnen alleen als bron dienen.

**Overschrijft Aspose.Slides het externe XLSX‑bestand bij het opslaan van de presentatie?**

Nee. De presentatie slaat een [link to the external file](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartdata/externalworkbookpath/) op en gebruikt die voor het lezen van gegevens. Het externe bestand zelf wordt niet aangepast bij het opslaan van de presentatie.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gebruikelijke aanpak is het wachtwoord vooraf te verwijderen of een gedecrypteerde kopie klaar te leggen (bijvoorbeeld met [Aspose.Cells](/cells/net/)) en naar die kopie te linken.

**Kunnen meerdere grafieken naar hetzelfde externe werkboek verwijzen?**

Ja. Elke grafiek slaat zijn eigen link op. Als ze allemaal naar hetzelfde bestand wijzen, worden wijzigingen in dat bestand in elke grafiek zichtbaar zodra de gegevens opnieuw worden geladen.