---
title: Gestire i workbook dei grafici nelle presentazioni in .NET
linktitle: Workbook del grafico
type: docs
weight: 70
url: /it/net/chart-workbook/
keywords:
- workbook del grafico
- dati del grafico
- cella del workbook
- etichetta dati
- foglio di lavoro
- fonte dati
- workbook esterno
- dati esterni
- cache del grafico
- recupero del workbook
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri Aspose.Slides per .NET: gestisci facilmente i workbook dei grafici in formati PowerPoint e OpenDocument per ottimizzare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con i workbook dei grafici in Aspose.Slides. Mostra come leggere e scrivere i dati del grafico tramite stream di workbook, utilizzare le celle del workbook come etichette dei dati del grafico, accedere alle collezioni di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Copre inoltre l'uso di workbook esterni come origini dati per i grafici. Gli esempi dimostrano come creare e assegnare un workbook esterno, recuperare il percorso di un workbook esterno collegato a un grafico e modificare i dati del grafico quando il workbook è disponibile.

Per le celle del workbook che rappresentano dati mancanti, vedere [Controllare la visualizzazione delle celle vuote](/slides/it/net/chart-series/) per la differenza tra una cella vuota e zero, e un confronto a linee dei modi di visualizzazione disponibili.

## **Includere dati da righe e colonne nascoste**

Usa [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) per controllare se un grafico traccia dati da righe e colonne nascoste del foglio di lavoro. Impostalo su `true` per tracciare solo le celle visibili, o su `false` per includere sia le celle visibili sia quelle nascoste. Questa impostazione controlla il tracciamento del grafico; non nasconde né mostra righe o colonne del foglio di lavoro.

La [presentazione di esempio](hidden-source-data.pptx) contiene un grafico a colonne come prima forma nella sua prima diapositiva. Il foglio di lavoro incorporato, `Sheet1`, contiene il seguente intervallo di origine, `A1:C4`. La riga 3 e la colonna C sono nascoste, ma le loro celle contengono ancora valori.

| Riga foglio di lavoro | A: Mese | B: Vendita al dettaglio | C: Vendita all'ingrosso (colonna nascosa) |
| --- | --- | --- | --- |
| 2 | Gennaio | 10 | 30 |
| 3 (riga nascosta) | Febbraio | 40 | 60 |
| 4 | Marzo | 20 | 50 |

Accedi alle celle di origine tramite [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) e leggi [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) per ispezionare il loro stato di nascondimento. Questa proprietà è di sola lettura. In questo file, B2 è visibile, B3 appartiene alla riga nascosta e C2 appartiene alla colonna nascosta; l'esempio stampa `False`, `True` e `True`, rispettivamente.

Per questo esempio, aggiorna i dati del grafico dopo aver modificato l'impostazione di tracciamento: mantieni il workbook incorporato con [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) e ricaricalo con [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/). Quando includi tutte le celle, usa anche [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) per ripristinare l'intervallo completo, inclusa la categoria di febbraio nascosta. Cambiare semplicemente il flag non è sufficiente a aggiornare i dati del grafico memorizzati nella cache di questo esempio e le etichette delle categorie.

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

        // Aggiorna i dati del grafico dal workbook incorporato.
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

L'esempio salva due versioni della presentazione: una con solo i valori di vendita al dettaglio visibili (10 e 20) e un'altra con tutti e sei i valori. Le immagini sotto sono state generate dalle presentazioni salvate dopo averle riaperte; entrambi i file conservano l'impostazione di tracciamento assegnata. La riga 3 e la colonna C rimangono nascoste in entrambi i workbook incorporati.

| Solo celle visibili (`true`) | Tutte le celle (`false`) |
| --- | --- |
| ![Solo celle visibili: valori di vendita al dettaglio 10 e 20 per Gennaio e Marzo.](hidden_cells_True.png) | ![Tutte le celle: valori di vendita al dettaglio e all'ingrosso per Gennaio, Febbraio e Marzo.](hidden_cells_False.png) |

Una cella nascosta contenente un valore è diversa da una cella vuota. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) controlla come vengono visualizzati i valori mancanti; non include né esclude dati di origine nascosti. Vedere [Controllare la visualizzazione delle celle vuote](/slides/it/net/chart-series/#control-the-display-of-empty-cells) per un esempio.

## **Recuperare l’intervallo di dati di un grafico**

Prima di aggiornare i dati del workbook in una presentazione esistente, ispeziona gli intervalli di origine per identificare quali celle del foglio di lavoro utilizza ogni grafico. Il metodo [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) restituisce l'intervallo di dati corrente come formula qualificata dal foglio di lavoro, ad esempio `Sheet1!$A$1:$D$5`. Qui, `Sheet1` è il nome del foglio di lavoro, `!` lo separa dall'intervallo di celle e `$A$1:$D$5` identifica le celle da A1 a D5, inclusive. I segni di dollaro indicano riferimenti assoluti di riga e colonna.

Se il grafico non utilizza un workbook come origine dati, genera un'eccezione [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Per ulteriori informazioni, vedere il [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/).

Questo esempio apre una presentazione e verifica le forme direttamente su ogni diapositiva per trovare i grafici. Stampa il nome di ogni grafico e il relativo intervallo di origine. Se un grafico non utilizza un workbook, stampa un messaggio e passa al grafico successivo.

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

## **Leggere e scrivere dati del grafico da un workbook**

Aspose.Slides for .NET fornisce i metodi [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) e [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) che consentono di leggere e scrivere i workbook dei dati del grafico (contenenti dati del grafico modificati con Aspose.Cells). **Note** che i dati del grafico devono essere organizzati nello stesso modo o avere una struttura simile a quella di origine.

Questo esempio utilizza una presentazione con un grafico come prima forma nella sua prima diapositiva. Legge il workbook incorporato in uno stream, cancella le serie e le categorie esistenti e riscrive lo stesso workbook. Le modifiche rimangono in memoria; l'esempio non salva la presentazione.

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

### **Convalidare il layout del grafico dopo la modifica del workbook**

Quando sostituisci un workbook incorporato con uno modificato, il grafico mantiene le collezioni originali di serie e categorie. Questa incongruenza può causare il fallimento di [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) con un errore di indice fuori intervallo. Cancella le serie e le categorie esistenti prima di scrivere il workbook aggiornato di nuovo nel grafico. Questo esempio usa un grafico che è la prima forma nella prima diapositiva. Il commento segna dove avverrebbe la modifica del workbook; l'esempio eseguibile riscrive il workbook originale e convalida il layout in memoria.

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

    // Modifica lo stream del workbook qui, ad esempio, usando Aspose.Cells.

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

Cancellare le collezioni rimuove i riferimenti a dati obsoleti prima che il workbook sia riscritto. Ricostruisci tutte le mappature di serie e categorie necessarie per il workbook aggiornato prima di utilizzare il grafico.

## **Impostare una cella del workbook come etichetta dei dati del grafico**

Puoi utilizzare il testo delle celle del workbook come etichette dei dati del grafico.

Questo esempio aggiunge un grafico a bolle con dati predefiniti alla prima diapositiva di una presentazione esistente. Usa le celle A10:A12 nel foglio di lavoro 0 per le prime tre etichette della prima serie, abilita le etichette dalle celle e salva la presentazione aggiornata.

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

La proprietà [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) fornisce l'accesso ai fogli di lavoro in un workbook di grafico. Questo esempio crea un grafico a torta con dati predefiniti e stampa il nome di ogni foglio di lavoro sulla console.

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

Questo esempio crea un grafico a colonne 3D con dati predefiniti e imposta due nomi di serie utilizzando diverse origini dati. Il primo nome utilizza un literal di stringa; il secondo utilizza la cella C1 nel foglio di lavoro 0. L'enumerazione [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) seleziona l'origine per ciascun nome. L'esempio salva la presentazione con i nomi delle serie aggiornati.

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

## **Rilevare formati di workbook incorporati non supportati**

Aspose.Slides non supporta il formato workbook binario Excel (.xlsb) che può essere incorporato in alcuni grafici. Puoi usare la proprietà [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) su [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) insieme all'enumerazione [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) per rilevare formati non supportati e saltare quei grafici. Questo esempio ispeziona le forme nella prima diapositiva di una presentazione esistente, ignora le forme non grafiche e stampa un messaggio diagnostico per ogni grafico con un workbook .xlsb incorporato.

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

    // Leggi o modifica i dati del workbook del grafico supportati qui.
}
```

## **Workbook esterno**

Aspose.Slides supporta l'uso di workbook esterni come fonte dati per i grafici.

### **Creare un workbook esterno**

Usa [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) e [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) per esportare un workbook di grafico incorporato in un file e collegare il grafico a quel workbook esterno.

Questo esempio crea un grafico a torta con dati predefiniti ed esporta il suo workbook. Chiude lo stream di output prima di assegnare il workbook esterno come origine dati del grafico, quindi salva la presentazione collegata.

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

### **Impostare un workbook esterno**

Utilizzando il metodo [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/), è possibile assegnare un workbook esterno a un grafico come sua origine dati. Questo metodo può anche essere usato per aggiornare il percorso al workbook esterno (se quest'ultimo è stato spostato).

Sebbene non sia possibile modificare i dati nei workbook memorizzati in posizioni remote o risorse, è comunque possibile usarli come fonte dati esterna. Se viene fornito un percorso relativo per un workbook esterno, viene convertito automaticamente in un percorso assoluto.

Questo esempio utilizza un workbook esterno il cui foglio di lavoro denominato `Sheet1` contiene un nome di serie in B1, nomi di categoria in A2:A4 e valori numerici in B2:B4. L'esempio crea un grafico a torta, collega il workbook e usa [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) per mappare A1:B4 a una serie e tre categorie. Salva la presentazione con il grafico collegato.

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

Il parametro `updateChartData` di [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) controlla se il workbook viene caricato.

* Quando `updateChartData` è `false`, viene aggiornato solo il percorso del workbook. I dati del grafico non vengono caricati né aggiornati dal workbook di destinazione, quindi il workbook può risultare non disponibile.  
* Quando `updateChartData` è `true`, i dati del grafico vengono aggiornati dal workbook di destinazione.

Il seguente esempio assegna un URL segnaposto con `updateChartData` impostato su `false`. Mantiene i dati predefiniti del grafico a torta e salva la presentazione senza caricare il workbook non disponibile.

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

### **Ottenere il percorso del workbook della fonte dati esterna di un grafico**

Per identificare il workbook collegato a un grafico, verifica se il grafico utilizza una fonte dati esterna e recupera il suo percorso.

Questo esempio ispeziona la prima forma nella prima diapositiva di una presentazione con un workbook esterno collegato. Se è un grafico collegato a un workbook esterno, l'esempio stampa [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) sulla console. Successivamente salva una copia della presentazione.

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

È possibile modificare i dati nei workbook esterni allo stesso modo in cui si modificano i contenuti dei workbook interni. Quando un workbook esterno non può essere caricato, viene generata un'eccezione.

Questo esempio utilizza un grafico che è la prima forma nella prima diapositiva e è collegato a un workbook esterno accessibile. Imposta il valore basato su cella del primo punto dati della prima serie a 100 e salva la presentazione aggiornata. La modifica dei valori di cella può aggiornare il file XLSX esterno collegato, perciò utilizzare una copia se è necessario conservare il workbook originale.

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

### **Recuperare un workbook dalla cache del grafico**

Se un grafico utilizza un workbook esterno mancante o non disponibile, Aspose.Slides può ricostruire il workbook del grafico dai dati memorizzati nella cache della presentazione. Crea [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/), configura le sue [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/), e imposta [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) su `true` prima di aprire la presentazione.

Il seguente esempio C# recupera i dati del workbook per un grafico che è la prima forma nella prima diapositiva e fa riferimento a un workbook esterno non disponibile. Accede ai dati recuperati tramite [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) e [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

Se il workbook esterno non è disponibile e il recupero è disabilitato, Aspose.Slides genera un'eccezione [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Abilita il recupero solo quando l'uso dei dati del grafico nella cache è un'alternativa accettabile, perché la cache potrebbe non contenere le modifiche apportate al workbook esterno dopo l'ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un grafico specifico è collegato a un workbook esterno o incorporato?**

Sì. Un grafico ha un [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) e un [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/); se l'origine è un workbook esterno, è possibile leggere il percorso completo per assicurarsi che venga utilizzato un file esterno.

**I percorsi relativi ai workbook esterni sono supportati e come vengono memorizzati?**

Sì. Se si specifica un percorso relativo, viene convertito automaticamente in un percorso assoluto. La presentazione memorizza il percorso assoluto nel file PPTX, quindi spostare il workbook potrebbe richiedere l'aggiornamento del collegamento.

**Posso usare workbook situati su risorse/Condivisioni di rete?**

Sì, tali workbook possono essere usati come fonte dati esterna. Tuttavia, la modifica diretta di workbook remoti da Aspose.Slides non è supportata—possono essere usati solo come fonte.

**Aspose.Slides sovrascrive il file XLSX esterno quando salva la presentazione?**

La presentazione memorizza un [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/). Modificare i dati del grafico basati su celle può anche aggiornare il file XLSX locale collegato. Usa una copia del workbook se l'originale deve rimanere invariato.

**Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password durante il collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio, usando [Aspose.Cells](https://reference.aspose.com/cells/net/)) e collegarsi a quella copia.

**Possono più grafici fare riferimento allo stesso workbook esterno?**

Sì. Ogni grafico memorizza il proprio collegamento. Se tutti puntano allo stesso file, l'aggiornamento di quel file verrà riflesso in ciascun grafico al successivo caricamento dei dati.