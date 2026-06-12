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
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontdek Aspose.Slides voor .NET: beheer grafiekwerkboeken moeiteloos in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiekwerkboeken in Aspose.Slides kunt werken. Het laat zien hoe u grafiekgegevens kunt lezen en schrijven via werkboekstreams, werkboekcellen als grafiekgegevenslabels kunt gebruiken, werkbladcollecties kunt benaderen en het gegevenstype van de gegevensbron voor grafiekwaarden kunt opgeven. Het behandelt tevens het werken met externe werkboeken als gegevensbron voor grafieken. De voorbeelden laten zien hoe u een extern werkboek kunt maken en toewijzen, het pad van een extern werkboek dat aan een grafiek is gekoppeld kunt ophalen, en grafiekgegevens kunt bewerken wanneer het werkboek beschikbaar is.

## **Lees en schrijf grafiekgegevens vanuit een werkboek**

Aspose.Slides biedt de [ReadWorkbookStream](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdata/readworkbookstream/) en [WriteWorkbookStream](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdata/writeworkbookstream/) methoden die u in staat stellen grafiekgegevens‑werkboeken te lezen en te schrijven (bevat grafiekgegevens bewerkt met Aspose.Cells). **Opmerking** dat de grafiekgegevens op dezelfde manier moeten zijn georganiseerd of een structuur moeten hebben die vergelijkbaar is met de bron.

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

## **Stel een werkboekcel in als een grafiekgegevenslabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.  
2. Haal een verwijzing naar een dia op via de index.  
3. Voeg een bubbelgrafiek toe met enkele gegevens.  
4. Benader de grafieksreeks.  
5. Stel de werkboekcel in als gegevenslabel.  
6. Sla de presentatie op.

Deze C#‑code laat zien hoe u een werkboekcel kunt instellen als een grafiekgegevenslabel:

```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Instantieert een presentatieklasse die een presentatiebestand vertegenwoordigt

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

Deze C#‑code toont een bewerking waarbij de [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets)‑eigenschap wordt gebruikt om een werkbladcollectie te benaderen:

``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Geef het type gegevensbron op**

Deze C#‑code laat zien hoe u een type voor een gegevensbron kunt opgeven:

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

## **Detecteer niet‑ondersteunde ingesloten werkboekformaten**

Aspose.Slides ondersteunt het Excel‑binaire werkboekformaat (.xlsb) dat in sommige grafieken kan worden ingesloten niet. U kunt de eigenschap `EmbeddedWorkbookType` op [IChartData](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdata/) in combinatie met de enumeratie [WorkbookType](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/workbooktype/) gebruiken om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan.

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
            // Ingesloten werkboek is in .xlsb-formaat, wat niet ondersteund wordt.
            continue;
        }

        // Lees of wijzig hier de grafiekwerkboekgegevens.
    }
}
```

## **Extern werkboek**

{{% alert color="primary" %}} 
In [Aspose.Slides 19.4](https://docs.aspose.com/slides/nl/net/aspose-slides-for-net-19-4-release-notes/) hebben we ondersteuning toegevoegd voor externe werkboeken als gegevensbron voor grafieken.
{{% /alert %}} 

### **Maak een extern werkboek**

Met behulp van de **`ReadWorkbookStream`**‑ en **`SetExternalWorkbook`**‑methoden kunt u een extern werkboek vanaf nul maken of een intern werkboek extern maken.

Deze C#‑code toont het proces van het maken van een extern werkboek:

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

### **Stel een extern werkboek in**

Met de **`SetExternalWorkbook`**‑methode kunt u een extern werkboek toewijzen aan een grafiek als gegevensbron. Deze methode kan ook worden gebruikt om het pad naar het externe werkboek bij te werken (als dat laatstgenoemde is verplaatst).

Hoewel u de gegevens in werkboeken die op externe locaties of bronnen zijn opgeslagen niet kunt bewerken, kunt u dergelijke werkboeken wel als externe gegevensbron gebruiken. Als een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Deze C#‑code laat zien hoe u een extern werkboek kunt instellen:

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

De parameter `ChartData` (bij de `SetExternalWorkbook`‑methode) wordt gebruikt om op te geven of een Excel‑werkboek wel of niet wordt geladen.

* Wanneer de waarde van `ChartData` op `false` wordt gezet, wordt alleen het pad van het werkboek bijgewerkt - de grafiekgegevens worden niet geladen of bijgewerkt vanuit het doelwerkboek. U kunt deze instelling gebruiken wanneer het doelwerkboek niet bestaat of niet beschikbaar is.  
* Wanneer de waarde van `ChartData` op `true` wordt gezet, worden de grafiekgegevens bijgewerkt vanuit het doelwerkboek.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Haal het pad van het externe gegevensbron‑werkboek van een grafiek op**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.  
2. Haal een verwijzing naar een dia op via de index.  
3. Maak een object voor de grafiekvorm.  
4. Maak een object voor het bron‑type (`ChartDataSourceType`) dat de gegevensbron van de grafiek vertegenwoordigt.  
5. Specificeer de relevante voorwaarde op basis van het feit dat het bron‑type hetzelfde is als het type van de externe werkboek‑gegevensbron.

Deze C#‑code toont de bewerking:

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

U kunt de gegevens in externe werkboeken bewerken op dezelfde manier als u wijzigingen aanbrengt in de inhoud van interne werkboeken. Wanneer een extern werkboek niet kan worden geladen, wordt een uitzondering gegooid.

Deze C#‑code is een implementatie van het beschreven proces:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Kan ik bepalen of een specifieke grafiek is gekoppeld aan een extern of een ingebed werkboek?**

Ja. Een grafiek heeft een [gegevenstype van de gegevensbron](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartdata/datasourcetype/) en een [pad naar een extern werkboek](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartdata/externalworkbookpath/); als de bron een extern werkboek is, kunt u het volledige pad lezen om te bevestigen dat er een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. Dit is handig voor de portabiliteit van projecten; let wel op dat de presentatie het absolute pad opslaat in het PPTX‑bestand.

**Kan ik werkboeken gebruiken die zich op netwerkbronnen-/shares bevinden?**

Ja, dergelijke werkboeken kunnen worden gebruikt als externe gegevensbron. Het direct bewerken van externe werkboeken vanuit Aspose.Slides wordt echter niet ondersteund - ze kunnen alleen als bron worden gebruikt.

**Overschrijft Aspose.Slides het externe XLSX‑bestand bij het opslaan van de presentatie?**

Nee. De presentatie slaat een [link naar het externe bestand](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartdata/externalworkbookpath/) op en gebruikt deze voor het lezen van gegevens. Het externe bestand zelf wordt niet gewijzigd wanneer de presentatie wordt opgeslagen.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gebruikelijke aanpak is om de beveiliging vooraf te verwijderen of een gedecrypteerde kopie voor te bereiden (bijvoorbeeld met [Aspose.Cells](/cells/net/)) en naar die kopie te linken.

**Kunnen meerdere grafieken naar hetzelfde externe werkboek verwijzen?**

Ja. Elke grafiek slaat zijn eigen link op. Als ze allemaal naar hetzelfde bestand verwijzen, zal een bijwerking van dat bestand bij de volgende keer dat de gegevens worden geladen in elke grafiek zichtbaar zijn.