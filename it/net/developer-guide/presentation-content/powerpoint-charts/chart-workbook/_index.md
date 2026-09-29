---
title: Gestire le cartelle di lavoro dei grafici nelle presentazioni in .NET
linktitle: Cartella di lavoro del grafico
type: docs
weight: 70
url: /it/net/chart-workbook/
keywords:
- cartella di lavoro del grafico
- dati del grafico
- cella della cartella di lavoro
- etichetta dati
- foglio di lavoro
- origine dati
- cartella di lavoro esterna
- dati esterni
- cache del grafico
- recupero della cartella di lavoro
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri Aspose.Slides per .NET: gestisci agevolmente le cartelle di lavoro dei grafici nei formati PowerPoint e OpenDocument per ottimizzare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con le cartelle di lavoro dei grafici in Aspose.Slides. Mostra come leggere e scrivere i dati del grafico tramite flussi di cartelle di lavoro, utilizzare le celle della cartella di lavoro come etichette dei dati del grafico, accedere alle raccolte di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Copre inoltre l'uso di cartelle di lavoro esterne come origini dati dei grafici. Gli esempi dimostrano come creare e assegnare una cartella di lavoro esterna, recuperare il percorso di una cartella di lavoro esterna collegata a un grafico e modificare i dati del grafico quando la cartella di lavoro è disponibile.

Per le celle della cartella di lavoro che rappresentano dati mancanti, vedere [Controllare la visualizzazione delle celle vuote](/slides/it/net/chart-series/) per la differenza tra una cella vuota e zero, e un confronto a linea dei grafici delle modalità di visualizzazione disponibili.

## **Includere dati da righe e colonne nascoste**

Utilizzare [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) per controllare se un grafico traccia i dati provenienti da righe e colonne nascoste del foglio di lavoro. Impostarlo su `true` per tracciare solo le celle visibili, oppure su `false` per includere sia le celle visibili che quelle nascoste. Questa impostazione controlla il tracciamento del grafico; non nasconde o rende visibili le righe o le colonne del foglio di lavoro.

Scaricare [hidden-source-data.pptx](hidden-source-data.pptx) e posizionarlo nella directory di lavoro. La sua prima diapositiva contiene un grafico a colonne come prima forma. Il foglio di lavoro incorporato, `Sheet1`, contiene il seguente intervallo di origine, `A1:C4`. La riga 3 e la colonna C sono nascoste, ma le loro celle contengono ancora valori.

| Riga foglio di lavoro | A: Mese | B: Vendita al dettaglio | C: Vendita all'ingrosso (colonna nascosta) |
| --- | --- | --- | --- |
| 2 | Gennaio | 10 | 30 |
| 3 (riga nascosta) | Febbraio | 40 | 60 |
| 4 | Marzo | 20 | 50 |

Accedere alle celle di origine tramite [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/chartdataworkbook/) e leggere [IChartDataCell.IsHidden](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdatacell/ishidden/) per ispezionare il loro stato di nascondimento. Questa proprietà è di sola lettura. In questo file, B2 è visibile, B3 appartiene alla riga nascosta e C2 appartiene alla colonna nascosta; l'esempio stampa `False`, `True` e `True` rispettivamente.

Per questo esempio, aggiornare i dati del grafico dopo aver modificato l'impostazione di tracciamento: conservare la cartella di lavoro incorporata con [ReadWorkbookStream](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/readworkbookstream/) e ricaricarla con [WriteWorkbookStream](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/writeworkbookstream/). Quando si includono tutte le celle, utilizzare anche [SetRange](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/setrange/) per ripristinare l'intervallo completo, inclusa la categoria di febbraio nascosta. Modificare semplicemente il flag non è sufficiente per aggiornare i dati del grafico memorizzati nella cache e le etichette delle categorie di questo esempio.

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

        // Aggiorna i dati del grafico dalla cartella di lavoro incorporata.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Ripristina l'intervallo di origine completo, incluse le categorie nascoste.
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

L'esempio salva `hidden_cells_True.pptx` con solo i valori di Vendita al dettaglio visibili (10 e 20), e `hidden_cells_False.pptx` con tutti e sei i valori. Le immagini sotto sono state generate dalle presentazioni salvate dopo averle riaperte; entrambi i file conservano l'impostazione di tracciamento assegnata. La riga 3 e la colonna C rimangono nascoste in entrambe le cartelle di lavoro incorporate.

| Solo celle visibili (`true`) | Tutte le celle (`false`) |
| --- | --- |
| ![Solo celle visibili: valori di Vendita al dettaglio 10 e 20 per Gennaio e Marzo.](hidden_cells_True.png) | ![Tutte le celle: valori di Vendita al dettaglio e Vendita all'ingrosso per Gennaio, Febbraio e Marzo.](hidden_cells_False.png) |

Una cella nascosta contenente un valore è diversa da una cella vuota. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichart/displayblanksas/) controlla come vengono visualizzati i valori mancanti; non include né esclude i dati di origine nascosti. Vedere [Controllare la visualizzazione delle celle vuote](/slides/it/net/chart-series/#control-the-display-of-empty-cells) per un esempio.

## **Leggere e scrivere dati del grafico da una cartella di lavoro**

Aspose.Slides per .NET fornisce i metodi [ReadWorkbookStream](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/readworkbookstream/) e [WriteWorkbookStream](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/writeworkbookstream/) che consentono di leggere e scrivere le cartelle di lavoro dei dati del grafico (contenenti dati del grafico modificati con Aspose.Cells). **Nota** che i dati del grafico devono essere organizzati nello stesso modo o devono avere una struttura simile all'origine.

Questo esempio apre `chart.pptx`, che deve contenere un grafico come prima forma nella sua prima diapositiva. Legge la cartella di lavoro incorporata in un flusso, cancella le serie e le categorie esistenti, e riscrive la stessa cartella di lavoro. Le modifiche rimangono in memoria; l'esempio non salva la presentazione.

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

### **Convalidare il layout del grafico dopo la modifica della cartella di lavoro**

Quando si sostituisce una cartella di lavoro incorporata con una modificata, il grafico mantiene le collezioni originali di serie e categorie. Questa discrepanza può causare il fallimento di [IChart.ValidateChartLayout](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichart/validatechartlayout/) con un errore di indice fuori intervallo. Cancellare le serie e le categorie esistenti prima di scrivere la cartella di lavoro aggiornata nel grafico. Questo esempio richiede `chart.pptx` con un grafico come prima forma nella sua prima diapositiva. Il commento indica dove avverrebbe la modifica della cartella di lavoro; l'esempio eseguibile riscrive la cartella di lavoro originale e convalida il layout in memoria.

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

    // Modifica lo stream della cartella di lavoro qui, ad esempio, usando Aspose.Cells.

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

Cancellare le collezioni rimuove i riferimenti a dati obsoleti prima che la cartella di lavoro venga riscritta. Ricostruire eventuali mappe di serie e categorie necessarie per la cartella di lavoro aggiornata prima di utilizzare il grafico.

## **Impostare una cella della cartella di lavoro come etichetta di dati del grafico**

È possibile utilizzare il testo delle celle della cartella di lavoro come etichette di dati del grafico. I passaggi seguenti mostrano come collegare le etichette in un grafico a bolle alle celle nella sua cartella di lavoro dei dati.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Accedere alla prima diapositiva tramite il suo indice a base zero.
1. Aggiungere un grafico a bolle con dati predefiniti.
1. Accedere alle serie del grafico.
1. Impostare la cella della cartella di lavoro come etichetta di dati.
1. Salvare la presentazione.

Questo esempio apre `chart2.pptx`, che deve contenere almeno una diapositiva, e aggiunge un grafico a bolle con dati predefiniti. Utilizza le celle A10:A12 nel foglio di lavoro 0 per le prime tre etichette della prima serie, abilita le etichette dalle celle e salva il risultato in `resultchart.pptx`.

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

## **Gestire i fogli di lavoro**

La proprietà [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdataworkbook/worksheets/) fornisce l'accesso ai fogli di lavoro in una cartella di lavoro del grafico. Questo esempio crea un grafico a torta con dati predefiniti e stampa ogni nome di foglio di lavoro sulla console.

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

## **Specificare il tipo di origine dati**

Questo esempio crea un grafico a colonne 3D con dati predefiniti e imposta due nomi di serie utilizzando diverse origini dati. Il primo nome utilizza una stringa letterale; il secondo usa la cella C1 nel foglio di lavoro 0. L'enumerazione [DataSourceType](https://reference.aspose.com/slides/it/net/aspose.slides.charts/datasourcetype/) seleziona l'origine per ciascun nome. Il risultato è salvato in `pres.pptx`.

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

## **Rilevare formati di cartelle di lavoro incorporate non supportati**

Aspose.Slides non supporta il formato di cartella di lavoro binario Excel (.xlsb) che può essere incorporato in alcuni grafici. È possibile utilizzare la proprietà [EmbeddedWorkbookType](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) su [IChartData](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/) insieme all'enumerazione [WorkbookType](https://reference.aspose.com/slides/it/net/aspose.slides.charts/workbooktype/) per rilevare formati non supportati e saltare quei grafici. Questo esempio esamina le forme nella prima diapositiva di `sample.pptx`, ignora le forme non grafiche e stampa un messaggio diagnostico per ogni grafico con una cartella di lavoro .xlsb incorporata.

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

    // Leggi o modifica i dati della cartella di lavoro del grafico supportati qui.
}
```

## **Cartella di lavoro esterna**

Aspose.Slides supporta l'uso di cartelle di lavoro esterne come fonte di dati per i grafici.

### **Creare una cartella di lavoro esterna**

Utilizzare [ReadWorkbookStream](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/readworkbookstream/) e [SetExternalWorkbook](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/setexternalworkbook/) per esportare una cartella di lavoro di un grafico incorporato in un file e collegare il grafico a quella cartella di lavoro esterna.

Questo esempio crea un grafico a torta con dati predefiniti, scrive la sua cartella di lavoro in `externalWorkbook1.xlsx` e chiude il flusso di output prima di assegnare il file come fonte dei dati del grafico. Salva la presentazione collegata in `externalWorkbook.pptx`.

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

### **Impostare una cartella di lavoro esterna**

Utilizzando il metodo [SetExternalWorkbook](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/setexternalworkbook/), è possibile assegnare una cartella di lavoro esterna a un grafico come sua fonte di dati. Questo metodo può anche essere usato per aggiornare il percorso della cartella di lavoro esterna (se quest'ultima è stata spostata).

Sebbene non sia possibile modificare i dati nelle cartelle di lavoro archiviate in posizioni o risorse remote, è comunque possibile utilizzare tali cartelle di lavoro come fonte di dati esterna. Se viene fornito un percorso relativo per una cartella di lavoro esterna, esso viene convertito automaticamente in un percorso assoluto.

Questo esempio richiede `externalWorkbook.xlsx` nella directory di lavoro. Il suo foglio di lavoro denominato `Sheet1` deve contenere un nome di serie in B1, i nomi delle categorie in A2:A4 e valori numerici in B2:B4. L'esempio crea un grafico a torta, collega la cartella di lavoro, e utilizza [SetRange](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/setrange/) per mappare A1:B4 a una serie e tre categorie. Salva il risultato in `Presentation_with_externalWorkbook.pptx`.

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

Il parametro `updateChartData` di [SetExternalWorkbook](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/setexternalworkbook/) controlla se la cartella di lavoro è caricata.

* Quando `updateChartData` è `false`, solo il percorso della cartella di lavoro viene aggiornato. I dati del grafico non sono caricati né aggiornati dalla cartella di lavoro di destinazione, quindi la cartella di lavoro può essere non disponibile.
* Quando `updateChartData` è `true`, i dati del grafico vengono aggiornati dalla cartella di lavoro di destinazione.

Il seguente esempio assegna un URL segnaposto con `updateChartData` impostato su `false`. Mantiene i dati predefiniti del grafico a torta e salva la presentazione senza caricare la cartella di lavoro non disponibile.

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

### **Ottenere il percorso della cartella di lavoro sorgente esterna di un grafico**

Per identificare la cartella di lavoro collegata a un grafico, verificare innanzitutto se il grafico utilizza una fonte dati esterna. Se lo fa, è possibile recuperare il percorso della cartella di lavoro seguendo questi passaggi.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Accedere alla prima diapositiva tramite il suo indice a base zero.
1. Verificare che la prima forma sia un grafico.
1. Leggere il tipo di origine dati del grafico.
1. Se l'origine è una cartella di lavoro esterna, leggerne il percorso.

Questo esempio apre `externalWorkbook.pptx`, creato nell'esempio precedente, e ispeziona la prima forma nella prima diapositiva. Se è un grafico collegato a una cartella di lavoro esterna, l'esempio stampa [ExternalWorkbookPath](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/externalworkbookpath/) sulla console. Successivamente salva una copia della presentazione in `Result.pptx`.

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

### **Modificare i dati del grafico**

È possibile modificare i dati nelle cartelle di lavoro esterne allo stesso modo in cui si apportano modifiche al contenuto delle cartelle di lavoro interne. Quando una cartella di lavoro esterna non può essere caricata, viene generata un'eccezione.

Questo esempio richiede `presentation.pptx` con un grafico come prima forma nella prima diapositiva e una cartella di lavoro esterna accessibile. Imposta il valore basato sulla cella del primo punto dati nella prima serie a 100 e salva la presentazione in `presentation_out.pptx`. Modificare i valori delle celle può aggiornare il file XLSX locale collegato, quindi utilizzare una copia se è necessario preservare la cartella di lavoro originale.

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

### **Recuperare una cartella di lavoro dalla cache del grafico**

Se un grafico utilizza una cartella di lavoro esterna mancante o non disponibile, Aspose.Slides può ricostruire la cartella di lavoro del grafico dai dati memorizzati nella cache della presentazione. Creare [LoadOptions](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/), configurare le sue [SpreadsheetOptions](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/spreadsheetoptions/), e impostare [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/it/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) su `true` prima di aprire la presentazione.

Il seguente esempio C# apre `presentation.pptx`, la cui prima forma nella prima diapositiva deve essere un grafico che fa riferimento a una cartella di lavoro esterna non disponibile, e accede ai dati recuperati tramite [IChart.ChartData](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichart/chartdata/) e [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

    // Leggi o modifica i dati del workbook recuperato qui.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Se la cartella di lavoro esterna non è disponibile e il recupero è disabilitato, Aspose.Slides genera un'[InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Abilitare il recupero solo quando l'uso dei dati del grafico nella cache è una soluzione accettabile, poiché la cache potrebbe non contenere le modifiche apportate alla cartella di lavoro esterna dopo l'ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un grafico specifico è collegato a una cartella di lavoro esterna o incorporata?**

Sì. Un grafico ha un [tipo di origine dati](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chartdata/datasourcetype/) e un [percorso a una cartella di lavoro esterna](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chartdata/externalworkbookpath/); se l'origine è una cartella di lavoro esterna, è possibile leggere il percorso completo per verificare che venga utilizzato un file esterno.

**I percorsi relativi alle cartelle di lavoro esterne sono supportati e come vengono memorizzati?**

Sì. Se si specifica un percorso relativo, viene automaticamente convertito in un percorso assoluto. La presentazione memorizza il percorso assoluto nel file PPTX, quindi spostare la cartella di lavoro potrebbe richiedere l'aggiornamento del collegamento.

**Posso utilizzare cartelle di lavoro posizionate su risorse/condivisioni di rete?**

Sì, tali cartelle di lavoro possono essere usate come fonte di dati esterna. Tuttavia, la modifica diretta di cartelle di lavoro remote da Aspose.Slides non è supportata — possono essere utilizzate solo come fonte.

**Aspose.Slides sovrascrive l'XLSX esterno quando salva la presentazione?**

La presentazione memorizza un [collegamento al file esterno](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chartdata/externalworkbookpath/). Modificare i dati del grafico basati su celle può anche aggiornare il file XLSX locale collegato. Utilizzare una copia della cartella di lavoro se l'originale deve rimanere invariato.

**Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password durante il collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio, usando [Aspose.Cells](https://reference.aspose.com/cells/net/)) e collegarsi a quella copia.

**Possono più grafici fare riferimento alla stessa cartella di lavoro esterna?**

Sì. Ogni grafico memorizza il proprio collegamento. Se puntano tutti allo stesso file, l'aggiornamento di quel file sarà riflesso in ciascun grafico al successivo caricamento dei dati.