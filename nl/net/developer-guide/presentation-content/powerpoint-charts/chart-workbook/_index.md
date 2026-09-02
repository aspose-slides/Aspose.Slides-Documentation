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
- gegevenslabel
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
description: "Ontdek Aspose.Slides voor .NET: beheer eenvoudig grafiekwerkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiek‑werkboeken in Aspose.Slides kunt werken. Het laat zien hoe u grafiekgegevens kunt lezen en schrijven via werkboek‑streams, werkboekcellen kunt gebruiken als grafiekgegevens‑labels, werkbladcollecties kunt benaderen en het type gegevensbron voor grafiekwaarden kunt opgeven.

Het behandelt tevens het werken met externe werkboeken als gegevensbronnen voor grafieken. De voorbeelden demonstreren hoe u een extern werkboek maakt en toewijst, het pad van een extern werkboek dat aan een grafiek is gekoppeld opvraagt, en grafiekgegevens bewerkt wanneer het werkboek beschikbaar is.

## **Grafiekgegevens lezen en schrijven vanuit een werkboek**
Aspose.Slides biedt de [ReadWorkbookStream](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdata/readworkbookstream/) en [WriteWorkbookStream](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdata/writeworkbookstream/) methoden waarmee u grafiekgegevens‑werkboeken (die grafiekgegevens bevatten die met Aspose.Cells zijn bewerkt) kunt lezen en schrijven. **Opmerking** dat de grafiekgegevens op dezelfde manier moeten zijn georganiseerd of een structuur moeten hebben die op de bron lijkt.

Deze C#‑code toont een voorbeeldoperatie:

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

## **Een werkboekcel instellen als grafiekgegevenslabel**
1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
2. Haal een dia‑referentie op via de index.
3. Voeg een bubbelfiguur toe met enkele gegevens.
4. Benader de grafiekserie.
5. Stel de werkboekcel in als gegevenslabel.
6. Sla de presentatie op.

Deze C#‑code laat zien hoe u een werkboekcel instelt als grafiekgegevenslabel:

```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Instanceert een presentatieklasse die een presentatiebestand vertegenwoordigt 
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

Deze C#‑code demonstreert een operatie waarbij de [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets)‑eigenschap wordt gebruikt om een werkbladcollectie te benaderen:

``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Het type gegevensbron specificeren**

Deze C#‑code toont hoe u een type voor een gegevensbron opgeeft:

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

## **Niet‑ondersteunde ingesloten werkboekformaten detecteren**

Aspose.Slides ondersteunt het Excel‑binaire werkboek (.xlsb)‑formaat dat in sommige grafieken kan worden ingesloten niet. U kunt de `EmbeddedWorkbookType`‑eigenschap op [IChartData](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdata/) samen met de [WorkbookType](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/workbooktype/)‑enumeratie gebruiken om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan.

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
            // Ingesloten werkboek is in .xlsb-formaat, wat niet wordt ondersteund.
            continue;
        }

        // Lees of wijzig hier de grafiekwerkboekgegevens.
    }
}
```

## **Extern werkboek**

{{% alert color="primary" %}} 
In [Aspose.Slides 19.4](https://docs.aspose.com/slides/nl/net/aspose-slides-for-net-19-4-release-notes/) hebben we ondersteuning geïmplementeerd voor externe werkboeken als gegevensbron voor grafieken.
{{% /alert %}} 

### **Een extern werkboek maken**
Met de **`ReadWorkbookStream`**‑ en **`SetExternalWorkbook`**‑methoden kunt u een extern werkboek vanaf nul maken of een intern werkboek extern maken.

Deze C#‑code demonstreert het proces van het maken van een extern werkboek:

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

### **Een extern werkboek instellen**
Met de **`SetExternalWorkbook`**‑methode kunt u een extern werkboek aan een grafiek toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om het pad naar het externe werkboek bij te werken (indien dit is verplaatst).

Hoewel u de gegevens in werkboeken die op externe locaties of bronnen staan niet kunt bewerken, kunt u dergelijke werkboeken wel als externe gegevensbron gebruiken. Als er een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Deze C#‑code laat zien hoe u een extern werkboek instelt:

```c#
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

De `ChartData`‑parameter (onder de `SetExternalWorkbook`‑methode) wordt gebruikt om aan te geven of een Excel‑werkboek wel of niet moet worden geladen.

* Wanneer `ChartData` op `false` staat, wordt alleen het werkboekpad bijgewerkt – de grafiekgegevens worden niet geladen of bijgewerkt vanuit het doelwerkboek. Gebruik deze instelling wanneer het doelwerkboek niet bestaat of niet beschikbaar is.  
* Wanneer `ChartData` op `true` staat, worden de grafiekgegevens bijgewerkt vanuit het doelwerkboek.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Het pad van de externe gegevensbron‑werkboek van een grafiek ophalen**

1. Maak een exemplaar van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
2. Haal een dia‑referentie op via de index.
3. Maak een object voor de grafiek‑shape.
4. Maak een object voor het bron‑type (`ChartDataSourceType`) dat de gegevensbron van de grafiek representeert.
5. Specificeer de relevante voorwaarde op basis van het bron‑type dat gelijk is aan het type van de externe werkboek‑gegevensbron.

Deze C#‑code demonstreert de operatie:

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
    
    // Slaat de presentatie op
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **Grafiekgegevens bewerken**

U kunt de gegevens in externe werkboeken op dezelfde manier bewerken als wanneer u wijzigingen aanbrengt in interne werkboeken. Wanneer een extern werkboek niet kan worden geladen, wordt er een uitzondering gegooid.

Deze C#‑code implementeert het beschreven proces:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **Een werkboek herstellen uit de grafiek‑cache**

Als een grafiek een extern werkboek gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het grafiek‑werkboek reconstrueren uit de in de presentatie gecachete gegevens. Maak [LoadOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/) aan, configureer de [SpreadsheetOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/spreadsheetoptions/), en stel [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nl/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) in op `true` vóór het openen van de presentatie.

Het volgende C#‑voorbeeld opent een presentatie waarvan de grafiek een niet‑beschikbaar extern werkboek referereert en benadert de herstelde gegevens via [IChart.ChartData](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichart/chartdata/) en [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

```csharp
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

// Lees of wijzig hier de herstelde werkboekgegevens.
```

Als het externe werkboek niet beschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een `InvalidOperationException`. Schakel herstel alleen in wanneer het gebruik van de gecachete grafiekgegevens een acceptabele fallback is, omdat de cache mogelijk geen wijzigingen bevat die na de laatste update van de presentatie in het externe werkboek zijn aangebracht.

## **FAQ**

**Kan ik bepalen of een specifieke grafiek is gekoppeld aan een extern of een ingesloten werkboek?**

Ja. Een grafiek heeft een [data source type](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartdata/datasourcetype/) en een [pad naar een extern werkboek](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartdata/externalworkbookpath/); als de bron een extern werkboek is, kunt u het volledige pad lezen om te bevestigen dat een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. Dit is handig voor project‑portabiliteit; houd er echter rekening mee dat de presentatie het absolute pad opslaat in het PPTX‑bestand.

**Kan ik werkboeken die zich op netwerkbronnen/shared bevinden gebruiken?**

Ja, dergelijke werkboeken kunnen als externe gegevensbron worden gebruikt. Het direct bewerken van remote werkboeken vanuit Aspose.Slides wordt echter niet ondersteund – ze kunnen alleen als bron dienen.

**Overschrijft Aspose.Slides het externe XLSX‑bestand bij het opslaan van de presentatie?**

Nee. De presentatie slaat een [link naar het externe bestand](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartdata/externalworkbookpath/) op en gebruikt deze voor het lezen van gegevens. Het externe bestand zelf wordt niet aangepast wanneer de presentatie wordt opgeslagen.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gangbare aanpak is om de beveiliging vooraf te verwijderen of een gedecrypteerde kopie te maken (bijvoorbeeld met [Aspose.Cells](/cells/net/)) en naar die kopie te linken.

**Kunnen meerdere grafieken naar hetzelfde externe werkboek verwijzen?**

Ja. Elke grafiek slaat zijn eigen link op. Als ze allemaal naar hetzelfde bestand wijzen, wordt een wijziging in dat bestand bij de volgende laadactie in elke grafiek weergegeven.