---
title: Beheer diagramwerkboeken in presentaties in .NET
linktitle: Diagramwerkboek
type: docs
weight: 70
url: /nl/net/chart-workbook/
keywords:
- diagramwerkboek
- diagramgegevens
- werkboekcel
- gegevenslabel
- werkblad
- gegevensbron
- extern werkboek
- externe gegevens
- diagramcache
- werkboekherstel
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontdek Aspose.Slides voor .NET: beheer moeiteloos diagramwerkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiegegevens te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met diagramwerkboeken in Aspose.Slides werkt. Het laat zien hoe u diagramgegevens kunt lezen en schrijven via werkboekstreams, werkboekcellen kunt gebruiken als diagramgegevenslabels, werkbladcollecties kunt benaderen en het gegevenstype van de gegevensbron voor diagramwaarden kunt specificeren.

Het behandelt ook het werken met externe werkboeken als diagramgegevensbronnen. De voorbeelden laten zien hoe u een extern werkboek kunt maken en toewijzen, het pad van een extern werkboek dat aan een diagram is gekoppeld kunt ophalen, en diagramgegevens kunt bewerken wanneer het werkboek beschikbaar is.

## **Diagramgegevens lezen en schrijven vanuit een werkboek**
Aspose.Slides biedt de [ReadWorkbookStream](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdata/readworkbookstream/) en [WriteWorkbookStream](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdata/writeworkbookstream/) methoden die het mogelijk maken diagramgegevens‑werkboeken (bevat diagramgegevens bewerkt met Aspose.Cells) te lezen en te schrijven. **Opmerking** dat de diagramgegevens op dezelfde manier georganiseerd moeten zijn of een structuur moeten hebben die vergelijkbaar is met de bron.

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

### **Diagrameindeling valideren na wijziging van werkboek**

Wanneer u een ingebed werkboek vervangt door een aangepast, behoudt het diagram de oorspronkelijke reeks‑ en categorie‑collecties. Deze discrepantie kan ervoor zorgen dat [IChart.ValidateChartLayout](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichart/validatechartlayout/) faalt met een index‑out‑of‑range‑fout. Maak de bestaande reeksen en categorieën leeg voordat u het aangepaste werkboek terugschrijft naar het diagram.

```csharp
// Nadat de werkboekstream is aangepast (bijv. met Aspose.Cells)
using var updatedWorkbook = chartData.ReadWorkbookStream();

// Verwijder bestaande gegevensreferenties.
chartData.Series.Clear();
chartData.Categories.Clear();

updatedWorkbook.Position = 0;
chartData.WriteWorkbookStream(updatedWorkbook);

chart.ValidateChartLayout();
```

Het leegmaken van de collecties zorgt ervoor dat de diagramgegevens‑structuur consistent is met het nieuwe werkboek, zodat `ValidateChartLayout` zonder fouten kan worden voltooid.

## **Werkboekcel instellen als diagramgegevenslabel**
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse aan.  
1. Haal de referentie van een dia op via de index.  
1. Voeg een bubbeldiagram toe met enkele gegevens.  
1. Benader de diagramreeksen.  
1. Stel de werkboekcel in als gegevenslabel.  
1. Sla de presentatie op.

Deze C#‑code toont hoe u een werkboekcel instelt als diagramgegevenslabel:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Instantiëert een presentatie‑klasse die een presentatiebestand vertegenwoordigt 

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

Deze C#‑code toont een operatie waarin de [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets)‑eigenschap wordt gebruikt om een werkbladcollectie te benaderen:

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

## **Gegevenstype van de gegevensbron opgeven**

Deze C#‑code laat zien hoe u een type voor een gegevensbron kunt specificeren:

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

## **Detectie van niet‑ondersteunde ingebedde werkboekformaten**

Aspose.Slides ondersteunt het Excel‑binaire werkboek (.xlsb)‑formaat niet, dat in sommige diagrammen kan worden ingebed. U kunt de `EmbeddedWorkbookType`‑eigenschap op [IChartData](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdata/) samen met de [WorkbookType](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/workbooktype/)‑enumeratie gebruiken om niet‑ondersteunde formaten te detecteren en die diagrammen over te slaan.

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
            // Het ingebedde werkboek is in .xlsb-formaat, wat niet wordt ondersteund.
            continue;
        }

        // Lees of wijzig hier de diagramwerkboekgegevens.
    }
}
```

## **Extern werkboek**

{{% alert color="info" %}} 
In [Aspose.Slides 19.4](https://docs.aspose.com/slides/nl/net/aspose-slides-for-net-19-4-release-notes/) hebben we ondersteuning toegevoegd voor externe werkboeken als gegevensbron voor diagrammen.
{{% /alert %}} 

### **Extern werkboek maken**
Met behulp van de **`ReadWorkbookStream`**‑ en **`SetExternalWorkbook`**‑methoden kunt u een extern werkboek vanaf nul maken of een intern werkboek extern maken.

Deze C#‑code toont het proces voor het maken van een extern werkboek:

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

### **Extern werkboek instellen**
Met de **`SetExternalWorkbook`**‑methode kunt u een extern werkboek aan een diagram toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om een pad naar het externe werkboek bij te werken (als het werkboek is verplaatst).

Hoewel u de gegevens in werkboeken die op externe locaties of resources staan niet kunt bewerken, kunt u deze wel als externe gegevensbron gebruiken. Als er een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Deze C#‑code toont hoe u een extern werkboek instelt:

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

De `ChartData`‑parameter (bij de `SetExternalWorkbook`‑methode) geeft aan of een Excel‑werkboek wel of niet wordt geladen.

* Wanneer de waarde van `ChartData` is ingesteld op `false`, wordt alleen het pad van het werkboek bijgewerkt – de diagramgegevens worden niet geladen of bijgewerkt vanuit het doel‑werkboek. U kunt deze instelling gebruiken wanneer het doel‑werkboek niet bestaat of niet beschikbaar is.  
* Wanneer de waarde van `ChartData` is ingesteld op `true`, worden de diagramgegevens bijgewerkt vanuit het doel‑werkboek.

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

### **Pad van het externe gegevensbron‑werkboek van een diagram ophalen**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse aan.  
1. Haal de referentie van een dia op via de index.  
1. Maak een object voor de diagramvorm.  
1. Maak een object voor het bron‑type (`ChartDataSourceType`) dat de gegevensbron van het diagram vertegenwoordigt.  
1. Specificeer de relevante voorwaarde op basis van het bron‑type dat gelijk is aan het externe werkboek‑gegevensbron‑type.

Deze C#‑code toont de operatie:

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

### **Diagramgegevens bewerken**

U kunt de gegevens in externe werkboeken op dezelfde manier bewerken als bij interne werkboeken. Wanneer een extern werkboek niet kan worden geladen, wordt er een uitzondering gegooid.

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

### **Werkboek herstellen uit de diagramcache**

Als een diagram een extern werkboek gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het diagram‑werkboek reconstrueren uit de in de presentatie gecachte gegevens. Maak een [LoadOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/) aan, configureer de [SpreadsheetOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/spreadsheetoptions/), en stel [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nl/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) in op `true` voordat u de presentatie opent.

Het volgende C#‑voorbeeld opent een presentatie waarvan het diagram naar een niet‑beschikbaar extern werkboek verwijst en benadert de herstelde gegevens via [IChart.ChartData](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichart/chartdata/) en [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

Als het externe werkboek niet beschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een `InvalidOperationException`. Schakel herstel alleen in wanneer het gebruik van de gecachte diagramgegevens een acceptabele fallback is, omdat de cache mogelijk geen wijzigingen bevat die in het externe werkboek zijn aangebracht nadat de presentatie voor het laatst is bijgewerkt.

## **FAQ**

**Kan ik bepalen of een specifiek diagram gekoppeld is aan een extern of een ingebed werkboek?**

Ja. Een diagram heeft een [data source type](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartdata/datasourcetype/) en een [path to an external workbook](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartdata/externalworkbookpath/); als de bron een extern werkboek is, kunt u het volledige pad lezen om te bevestigen dat er een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. Dit is handig voor projectportabiliteit; houd er echter rekening mee dat de presentatie het absolute pad opslaat in het PPTX‑bestand.

**Kan ik werkboeken gebruiken die zich op netwerk‑resources/shares bevinden?**

Ja, dergelijke werkboeken kunnen worden gebruikt als externe gegevensbron. Het direct bewerken van externe werkboeken vanuit Aspose.Slides wordt echter niet ondersteund – ze kunnen alleen als bron worden gebruikt.

**Overschrijft Aspose.Slides het externe XLSX‑bestand bij het opslaan van de presentatie?**

Nee. De presentatie slaat een [link to the external file](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chartdata/externalworkbookpath/) op en gebruikt deze voor het lezen van gegevens. Het externe bestand zelf wordt niet gewijzigd wanneer de presentatie wordt opgeslagen.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gangbare aanpak is om de beveiliging vooraf te verwijderen of een gedecrypteerde kopie voor te bereiden (bijvoorbeeld met [Aspose.Cells](/cells/net/)) en naar die kopie te koppelen.

**Kunnen meerdere diagrammen naar hetzelfde externe werkboek verwijzen?**

Ja. Elk diagram slaat zijn eigen link op. Als ze allemaal naar hetzelfde bestand wijzen, wordt een update van dat bestand in elk diagram weerspiegeld de volgende keer dat de gegevens worden geladen.