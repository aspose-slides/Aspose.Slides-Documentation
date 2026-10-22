---
title: Beheer grafiek-werkboeken in presentaties in .NET
linktitle: Grafiek-werkboek
type: docs
weight: 70
url: /nl/net/chart-workbook/
keywords:
- grafiek-werkboek
- grafiekgegevens
- werkbladcel
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
description: "Ontdek Aspose.Slides voor .NET: beheer moeiteloos grafiek-werkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met grafiek‑werkbladen in Aspose.Slides kunt werken. Het toont hoe u grafiekgegevens kunt lezen en schrijven via werkblad‑streams, werkbladcellen kunt gebruiken als gegevenslabels, toegang krijgt tot werkbladcollecties en het gegevenstype voor grafiekwaarden kunt opgeven.

Het behandelt ook het gebruik van externe werkbladen als gegevensbron voor grafieken. De voorbeelden laten zien hoe u een extern werkblad maakt en toewijst, het pad van een extern werkblad dat aan een grafiek is gekoppeld opvraagt, en grafiekgegevens bewerkt wanneer het werkblad beschikbaar is.

Voor werkbladcellen die ontbrekende gegevens vertegenwoordigen, zie [De weergave van lege cellen regelen](/slides/nl/net/chart-series/) voor het verschil tussen een lege cel en nul, en een lijngrafiek‑vergelijking van de beschikbare weergavemodi.

## **Gegevens van verborgen rijen en kolommen opnemen**

Gebruik [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) om te bepalen of een grafiek gegevens plot uit verborgen werkbladrijen en -kolommen. Stel in op `true` om alleen zichtbare cellen te plotten, of op `false` om zowel zichtbare als verborgen cellen op te nemen. Deze instelling beïnvloedt alleen het plotten van de grafiek; hij verbergt of maakt geen verborgen rijen of kolommen zichtbaar.

De [voorbeeldpresentatie](hidden-source-data.pptx) bevat een kolomgrafiek als eerste vorm op de eerste dia. Het ingebedde werkblad, `Sheet1`, bevat het volgende bronbereik, `A1:C4`. Rij 3 en kolom C zijn verborgen, maar hun cellen bevatten nog steeds waarden.

| Werkbladrij | A: Maand | B: Detailhandel | C: Groothandel (verborgen kolom) |
| --- | --- | --- | --- |
| 2 | januari | 10 | 30 |
| 3 (verborgen rij) | februari | 40 | 60 |
| 4 | maart | 20 | 50 |

Toegang tot broncellen via [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) en lees [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) om hun verborgen status te inspecteren. Deze eigenschap is alleen‑lezend. In dit bestand is B2 zichtbaar, B3 behoort tot de verborgen rij en C2 tot de verborgen kolom; het voorbeeld print respectievelijk `False`, `True` en `True`.

Voor dit voorbeeld moet u de grafiekgegevens vernieuwen nadat u de plot‑instelling hebt gewijzigd: behoud het ingebedde werkblad met [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) en laad het opnieuw met [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/). Wanneer u alle cellen opneemt, gebruik dan ook [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) om het volledige bereik te herstellen, inclusief de verborgen februari‑categorie. Alleen de vlag wijzigen is onvoldoende om de in het voorbeeld gecachte grafiekgegevens en categorielabels te vernieuwen.

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

        // Vernieuw de grafiekgegevens van het ingebedde werkboek.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Herstel het volledige bronbereik, inclusief verborgen categorieën.
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

Het voorbeeld slaat twee versies van de presentatie op: één met alleen de zichtbare detailhandelwaarden (10 en 20) en één met alle zes waarden. De afbeeldingen hieronder zijn gerenderd vanuit de opgeslagen presentaties na het opnieuw openen; beide bestanden behouden hun ingestelde plot‑optie. Rij 3 en kolom C blijven verborgen in beide ingebedde werkbladen.

| Alleen zichtbare cellen (`true`) | Alle cellen (`false`) |
| --- | --- |
| ![Alleen zichtbare cellen: detailhandelwaarden 10 en 20 voor januari en maart.](hidden_cells_True.png) | ![Alle cellen: detailhandel‑ en groothandelwaarden voor januari, februari en maart.](hidden_cells_False.png) |

Een verborgen cel met een waarde verschilt van een lege cel. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) bepaalt hoe ontbrekende waarden worden weergegeven; hij neemt geen verborgen brongegevens op of sluit ze uit. Zie [De weergave van lege cellen regelen](/slides/nl/net/chart-series/#control-the-display-of-empty-cells) voor een voorbeeld.

## **Het gegevensbereik van een grafiek ophalen**

Voordat u werkbladgegevens in een bestaande presentatie bijwerkt, inspecteert u de bronbereiken om te bepalen welke werkbladcellen elke grafiek gebruikt. De methode [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) retourneert het huidige gegevensbereik als een werkblad‑gekwalificeerde formule, bijvoorbeeld `Sheet1!$A$1:$D$5`. Hier is `Sheet1` de werkbladnaam, `!` scheidt deze van het celbereik, en `$A$1:$D$5` duidt de cellen A1 tot en met D5 aan, inclusief. De dollartekens geven absolute rij‑ en kolomreferenties aan.

De methode leest het huidige bereik zonder de grafiek of het werkblad te wijzigen. Als de grafiek geen werkblad als gegevensbron gebruikt, wordt een [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) opgegooid. Zie voor meer informatie de [ChartData API‑referentie](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/).

Dit voorbeeld opent een presentatie en controleert de vormen direct op elke dia op grafieken. Het print de naam en het bronbereik van elke grafiek. Als een grafiek geen werkblad gebruikt, wordt een bericht geprint en wordt doorgaan met de volgende grafiek.

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

## **Grafiekgegevens lezen en schrijven vanuit een werkblad**

Aspose.Slides for .NET biedt de methoden [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) en [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) waarmee u grafiek‑werkbladen (die grafiekgegevens bevatten die met Aspose.Cells bewerkt zijn) kunt lezen en schrijven. **Opmerking**: de grafiekgegevens moeten op dezelfde manier zijn georganiseerd of een vergelijkbare structuur hebben als de bron.

Dit voorbeeld gebruikt een presentatie met een grafiek als eerste vorm op de eerste dia. Het leest het ingebedde werkblad in een stream, wist de bestaande series en categorieën, en schrijft hetzelfde werkblad terug. De wijzigingen blijven in het geheugen; het voorbeeld slaat de presentatie niet op.

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

### **Grafieklay‑out valideren na wijziging van het werkblad**

Wanneer u een ingebed werkblad vervangt door een aangepast werkblad, behoudt de grafiek de oorspronkelijke series‑ en categorieverzamelingen. Deze mismatch kan ervoor zorgen dat [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) faalt met een index‑out‑of‑range‑fout. Wis de bestaande series en categorieën voordat u het bijgewerkte werkblad terugschrijft naar de grafiek. Dit voorbeeld gebruikt een grafiek die de eerste vorm is op de eerste dia. Het commentaar geeft aan waar de bewerking van het werkblad zou plaatsvinden; het uitvoerbare voorbeeld schrijft het oorspronkelijke werkblad terug en valideert de lay‑out in het geheugen.

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

    // Wijzig hier de werkbladstream, bijvoorbeeld met Aspose.Cells.

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

Het wissen van de verzamelingen verwijdert verouderde gegevensreferenties voordat het werkblad wordt weggeschreven. Bouw eventuele benodigde series‑ en categorietoewijzingen opnieuw op voor het bijgewerkte werkblad voordat u de grafiek gebruikt.

## **Aangepaste getalnotaties voor werkbladcellen instellen**

Gebruik [ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) om te bepalen hoe numerieke waarden verschijnen in het ingebedde werkblad van een grafiek. Bijvoorbeeld, een rapport kan een conversieratio als percentage met vier decimalen en een coëfficiënt met vijf decimalen moeten weergeven. Houd beide waarden numeriek zodat ze beschikbaar blijven voor berekeningen en grafiekplotting.

Een getalnotatie wijzigt alleen de weergave, niet de opgeslagen waarde. Het formaat `0.0000%` toont `0.125` als `12.5000%`; het vervangt niet het opgeslagen getal door `12.5`. Evenzo toont `0.00000` `0.1234567` als `0.12346` zonder de opgeslagen waarde af te ronden. Als het aangepaste formaat een lege tekenreeks (`""`) is, wordt in plaats daarvan [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) gebruikt.

Het volgende voorbeeld creëert een kolomgrafiek en krijgt toegang tot de cellen via [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/). Op werkblad 0 bevat B2 de conversieratio en C2 de coëfficiënt. Beide cellen leveren grafiekwaarden. Het voorbeeld schakelt ook waardelabels in die gekoppeld zijn aan de bron­formaten.

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

Werkbladcel‑formaten staan los van de formaten die direct op grafiekassen of gegevenslabels worden ingesteld. In dit voorbeeld geeft elk label de waarde van de broncel weer omdat [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) is ingeschakeld, en volgt het bron‑getalformaat omdat [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) `true` is. Na het opslaan en opnieuw openen van de presentatie geven de labels `12.5000%` en `0.12346` weer, zoals hieronder te zien is. De verticale as gebruikt zijn eigen [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) van `0.00`, met [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) ingesteld op `false`.

Om een gegevenslabel onafhankelijk te formatteren, zet u de bron‑koppelvlag op `false` en kent u een eigen [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) toe. Dit verandert niet het formaat van de werkbladcel. Bijvoorbeeld, een onafhankelijk labelformaat van `0.00` toont de eerste waarde als `0.13`, terwijl B2 nog steeds `12.5000%` toont. Zie [Grafiek‑gegevenslabels](/slides/nl/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) voor directe label‑formattering.

De afbeelding hieronder is gerenderd vanuit de opgeslagen presentatie na het opnieuw openen:

![Kolomgrafiek met bron‑gekoppelde labels die 12.5000% en 0.12346 tonen en een onafhankelijk geformatteerde numerieke as.](custom-cell-formats.png)

## **Een werkbladcel als grafiek‑gegevenslabel gebruiken**

U kunt tekst uit werkbladcellen gebruiken als grafiek‑gegevenslabels.

Dit voorbeeld voegt een bubbelgrafiek met standaardgegevens toe aan de eerste dia van een bestaande presentatie. Het gebruikt cellen A10:A12 op werkblad 0 voor de eerste drie labels in de eerste serie, schakelt labels uit cellen in, en slaat de bijgewerkte presentatie op.

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

## **Werkbladen beheren**

De eigenschap [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) geeft toegang tot de werkbladen in een grafiek‑werkboek. Dit voorbeeld creëert een taartgrafiek met standaardgegevens en print elke werkbladnaam naar de console.

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

## **Gegevenstype van de bron opgeven**

Waarde‑punten van een serie kunnen ook rechtstreeks als numerieke literal‑waarden worden opgeslagen. Zie [Serieswaarden instellen met numerieke literal‑waarden](/slides/nl/net/chart-series/#set-series-values-using-numeric-literals) voor een volledig voorbeeld dat ze opslaat en leest. Het gegevenstype van puntwaarden staat los van de interne of externe werkboekconfiguratie van de grafiek; het gebruik van numerieke literal‑waarden verwijdert niet automatisch het ingebedde werkboek.

Dit voorbeeld maakt een 3D‑kolomgrafiek met standaardgegevens en stelt twee serienaam‑waarden in met verschillende gegevensbronnen. De eerste naam gebruikt een string‑literal; de tweede gebruikt cel C1 op werkblad 0. De enumeratie [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) selecteert de bron voor elke naam. Het voorbeeld slaat de presentatie op met de bijgewerkte serienaam‑waarden.

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

## **Niet‑ondersteunde formaten van ingebedde werkbladen detecteren**

Aspose.Slides ondersteunt het Excel‑binaire werkboek‑formaat (.xlsb) niet wanneer het in sommige grafieken is ingebed. U kunt de eigenschap [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) op [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) combineren met de enumeratie [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan. Dit voorbeeld inspecteert de vormen op de eerste dia van een bestaande presentatie, slaat niet‑grafiek‑vormen over, en print een diagnostisch bericht voor elke grafiek met een ingebed .xlsb‑werkboek.

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

    // Lees of wijzig ondersteunde grafiek-werkboekgegevens hier.
}
```

## **Extern werkblad**

Aspose.Slides ondersteunt het gebruik van externe werkbladen als gegevensbron voor grafieken.

### **Een extern werkblad maken**

Gebruik [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) en [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) om een ingebed grafiek‑werkboek naar een bestand te exporteren en de grafiek aan dat externe werkboek te koppelen.

Dit voorbeeld maakt een taartgrafiek met standaardgegevens en exporteert het werkboek. Het sluit de output‑stream vóór het toewijzen van het externe werkboek als gegevensbron, en slaat vervolgens de gekoppelde presentatie op.

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

### **Een extern werkblad instellen**

Met de methode [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) kunt u een extern werkboek toewijzen aan een grafiek als gegevensbron. Deze methode kan ook worden gebruikt om een pad naar het externe werkboek bij te werken (als het bestand is verplaatst).

Hoewel u de gegevens in werkbladen die op een externe locatie of bron staan niet kunt bewerken, kunt u dergelijke werkbladen wel als externe gegevensbron gebruiken. Als een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Dit voorbeeld gebruikt een extern werkboek waarvan het werkblad `Sheet1` een serienaam in B1, categorienamen in A2:A4 en numerieke waarden in B2:B4 bevat. Het voorbeeld maakt een taartgrafiek, koppelt het werkboek, en gebruikt [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) om A1:B4 te mappen naar één serie en drie categorieën. Het slaat de presentatie met de gekoppelde grafiek op.

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

De parameter `updateChartData` van [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) bepaalt of het werkboek wordt geladen.

* Wanneer `updateChartData` `false` is, wordt alleen het werkboekpad bijgewerkt. De grafiekgegevens worden niet geladen of bijgewerkt vanuit het doel‑werkboek, zodat het werkboek afwezig kan zijn.
* Wanneer `updateChartData` `true` is, worden de grafiekgegevens bijgewerkt vanuit het doel‑werkboek.

Het volgende voorbeeld kent een tijdelijke URL toe met `updateChartData` ingesteld op `false`. Het behoudt de standaardgegevens van de taartgrafiek en slaat de presentatie op zonder het onbeschikbare werkboek te laden.

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

### **Het pad van het externe gegevens‑werkboek van een grafiek ophalen**

Om te bepalen welk werkboek aan een grafiek is gekoppeld, controleert u of de grafiek een externe gegevensbron gebruikt en haalt u het werkboekpad op.

Dit voorbeeld inspecteert de eerste vorm op de eerste dia van een presentatie met een gekoppeld extern werkboek. Als het een grafiek is die naar een extern werkboek verwijst, print het voorbeeld [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) naar de console. Daarna wordt een kopie van de presentatie opgeslagen.

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

### **Grafiekgegevens bewerken**

U kunt de gegevens in externe werkbladen bewerken op dezelfde manier als u de inhoud van interne werkbladen wijzigt. Wanneer een extern werkboek niet kan worden geladen, wordt een uitzondering opgegooid.

Dit voorbeeld gebruikt een grafiek die de eerste vorm is op de eerste dia en gekoppeld is aan een toegankelijk extern werkboek. Het stelt de cel‑gebaseerde waarde van het eerste datapunt in de eerste serie in op 100 en slaat de bijgewerkte presentatie op. Het bewerken van celwaarden kan het gekoppelde externe XLSX‑bestand updaten; gebruik een kopie als u het oorspronkelijke werkboek wilt behouden.

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

### **Een werkboek herstellen uit de grafiek‑cache**

Als een grafiek een extern werkboek gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het grafiek‑werkboek reconstrueren vanuit de in de presentatie gecachte gegevens. Maak een [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) aan, configureer de [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/), en zet [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) op `true` voordat u de presentatie opent.

Het volgende C#‑voorbeeld herstelt werkboekgegevens voor een grafiek die de eerste vorm is op de eerste dia en verwijst naar een niet‑beschikbaar extern werkboek. Het benadert de herstelde gegevens via [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) en [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

    // Lees of wijzig hier de herstelde werkboekgegevens.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Als het externe werkboek niet beschikbaar is en herstel uitgeschakeld is, gooit Aspose.Slides een [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Schakel herstel alleen in wanneer het gebruik van de gecachte grafiekgegevens een aanvaardbare fallback is, want de cache bevat mogelijk niet de wijzigingen die in het externe werkboek zijn aangebracht sinds de laatste presentatie‑update.

## **FAQ**

**Kan ik bepalen of een specifieke grafiek gekoppeld is aan een extern of een ingebed werkboek?**

Ja. Een grafiek heeft een [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) en een [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/); als de bron een extern werkboek is, kunt u het volledige pad lezen om te bevestigen dat een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkbladen ondersteund, en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. De presentatie slaat het absolute pad op in het PPTX‑bestand, dus het verplaatsen van het werkboek kan vereisen dat de koppeling wordt bijgewerkt.

**Kan ik werkbladen gebruiken die zich op netwerklocaties of gedeelde schijven bevinden?**

Ja, dergelijke werkbladen kunnen als externe gegevensbron worden gebruikt. Het direct bewerken van externe werkbladen vanuit Aspose.Slides wordt echter niet ondersteund – ze kunnen alleen als bron dienen.

**Overschrijft Aspose.Slides het externe XLSX‑bestand bij het opslaan van de presentatie?**

De presentatie slaat een [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) op. Het bewerken van cel‑gebaseerde grafiekgegevens kan ook het gekoppelde lokale XLSX‑bestand updaten. Gebruik een kopie van het werkboek als het origineel ongewijzigd moet blijven.

**Wat moet ik doen als het externe bestand met een wachtwoord is beveiligd?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gangbare aanpak is om de beveiliging vooraf te verwijderen of een gedecodeerde kopie te maken (bijvoorbeeld met [Aspose.Cells](https://reference.aspose.com/cells/net/)) en die kopie te koppelen.

**Kunnen meerdere grafieken naar hetzelfde externe werkboek verwijzen?**

Ja. Elke grafiek slaat zijn eigen koppeling op. Als ze allemaal naar hetzelfde bestand wijzen, wordt een wijziging van dat bestand in elke grafiek weerspiegeld de volgende keer dat de gegevens worden geladen.