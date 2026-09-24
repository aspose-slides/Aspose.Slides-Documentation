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
- etichetta dei dati
- foglio di lavoro
- origine dati
- workbook esterno
- dati esterni
- cache del grafico
- recupero del workbook
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri Aspose.Slides per .NET: gestisci facilmente i workbook dei grafici nei formati PowerPoint e OpenDocument per ottimizzare i dati delle tue presentazioni."
---
## **Panoramica**

Questo articolo spiega come lavorare con i workbook dei grafici in Aspose.Slides. Mostra come leggere e scrivere i dati del grafico tramite flussi di workbook, utilizzare le celle del workbook come etichette dei dati del grafico, accedere alle collezioni di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Copre anche l'utilizzo di workbook esterni come origini dati per i grafici. Gli esempi dimostrano come creare e assegnare un workbook esterno, recuperare il percorso di un workbook esterno collegato a un grafico e modificare i dati del grafico quando il workbook è disponibile.

Per le celle del workbook che rappresentano dati mancanti, vedere [Control the Display of Empty Cells](/slides/it/net/chart-series/) per la differenza tra una cella vuota e zero, e un confronto a linee dei modi di visualizzazione disponibili.

## **Leggere e Scrivere i Dati del Grafico da un Workbook**

Aspose.Slides fornisce i metodi [ReadWorkbookStream](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/readworkbookstream/) e [WriteWorkbookStream](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/writeworkbookstream/) che consentono di leggere e scrivere i workbook dei dati del grafico (contenenti dati del grafico modificati con Aspose.Cells). **Note** che i dati del grafico devono essere organizzati nello stesso modo o avere una struttura simile all'origine.

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

### **Convalidare il Layout del Grafico dopo la Modifica del Workbook**

Quando si sostituisce un workbook incorporato con uno modificato, il grafico mantiene le collezioni originali di serie e categorie. Questa discrepanza può far fallire [IChart.ValidateChartLayout](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichart/validatechartlayout/) con un errore di indice fuori intervallo. Cancella le serie e le categorie esistenti prima di scrivere il workbook aggiornato nel grafico.

```csharp
// Dopo aver modificato lo stream del workbook (ad esempio usando Aspose.Cells)
using var updatedWorkbook = chartData.ReadWorkbookStream();

// Cancella i riferimenti ai dati esistenti.
chartData.Series.Clear();
chartData.Categories.Clear();

updatedWorkbook.Position = 0;
chartData.WriteWorkbookStream(updatedWorkbook);

chart.ValidateChartLayout();
```

Cancellare le collezioni garantisce che la struttura dei dati del grafico sia coerente con il nuovo workbook, permettendo a `ValidateChartLayout` di completarsi senza errori.

## **Impostare una Cella di WorkBook come Etichetta dei Dati del Grafico**
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) .
1. Ottieni il riferimento di una diapositiva tramite il suo indice.
1. Aggiungi un grafico a bolle con alcuni dati.
1. Accedi alla serie del grafico.
1. Imposta la cella del workbook come etichetta dei dati.
1. Salva la presentazione.

Questo codice C# mostra come impostare una cella di workbook come etichetta dei dati del grafico:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Istanzia una classe di presentazione che rappresenta un file di presentazione 

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

## **Gestire i Fogli di Lavoro**

Questo codice C# dimostra un'operazione in cui la proprietà [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) viene utilizzata per accedere a una collezione di fogli di lavoro:

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

## **Specificare il Tipo di Origine Dati**

Questo codice C# mostra come specificare un tipo per un'origine dati:

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

## **Rilevare i Formati di Workbook Incorporati Non Supportati**

Aspose.Slides non supporta il formato workbook binario di Excel (.xlsb) che può essere incorporato in alcuni grafici. È possibile utilizzare la proprietà `EmbeddedWorkbookType` su [IChartData](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/) insieme all'enumerazione [WorkbookType](https://reference.aspose.com/slides/it/net/aspose.slides.charts/workbooktype/) per rilevare formati non supportati e ignorare quei grafici.

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
            // Il workbook incorporato è in formato .xlsb, che non è supportato.
            continue;
        }

        // Leggi o modifica i dati del workbook del grafico qui.
    }
}
```

## **Workbook Esterno**

Aspose.Slides supporta l'uso di workbook esterni come origine dati per i grafici.

### **Creare un Workbook Esterno**

Utilizzando i metodi **`ReadWorkbookStream`** e **`SetExternalWorkbook`**, è possibile creare un workbook esterno da zero oppure rendere esterno un workbook interno.

Questo codice C# dimostra il processo di creazione di un workbook esterno:

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

### **Impostare un Workbook Esterno**
Utilizzando il metodo **`SetExternalWorkbook`**, è possibile assegnare un workbook esterno a un grafico come sua origine dati. Questo metodo può essere usato anche per aggiornare il percorso del workbook esterno (se quest'ultimo è stato spostato).

Sebbene non sia possibile modificare i dati nei workbook memorizzati in posizioni remote o risorse, è comunque possibile usarli come origine dati esterna. Se viene fornito un percorso relativo per un workbook esterno, questo viene convertito automaticamente in un percorso completo.

Questo codice C# mostra come impostare un workbook esterno:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Il percorso della directory dei documenti.
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

Il parametro `ChartData` (sotto il metodo `SetExternalWorkbook`) serve a specificare se un workbook Excel verrà caricato o meno.

* Quando il valore di `ChartData` è impostato su `false`, viene aggiornato solo il percorso del workbook: i dati del grafico non verranno caricati né aggiornati dal workbook di destinazione. Questa impostazione è utile quando il workbook di destinazione è inesistente o non disponibile.  
* Quando il valore di `ChartData` è impostato su `true`, i dati del grafico vengono aggiornati dal workbook di destinazione.

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

### **Ottenere il Percorso del Workbook di Origine Dati Esterna di un Grafico**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) .
1. Ottieni il riferimento di una diapositiva tramite il suo indice.
1. Crea un oggetto per la forma del grafico.
1. Crea un oggetto per il tipo di origine (`ChartDataSourceType`) che rappresenta l'origine dati del grafico.
1. Specifica la condizione pertinente in base al tipo di origine che corrisponde al tipo di origine dati del workbook esterno.

Questo codice C# dimostra l'operazione:

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
    
    // Salva la presentazione
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **Modificare i Dati del Grafico**

È possibile modificare i dati nei workbook esterni allo stesso modo in cui si modificano i contenuti dei workbook interni. Quando un workbook esterno non può essere caricato, viene sollevata un'eccezione.

Questo codice C# è un'implementazione del processo descritto:

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

### **Recuperare un Workbook dalla Cache del Grafico**

Se un grafico usa un workbook esterno mancante o non disponibile, Aspose.Slides può ricostruire il workbook del grafico dai dati memorizzati nella cache della presentazione. Crea un oggetto [LoadOptions](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/), configura le sue [SpreadsheetOptions](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/spreadsheetoptions/), e imposta [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/it/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) su `true` prima di aprire la presentazione.

Il seguente esempio C# apre una presentazione il cui grafico fa riferimento a un workbook esterno non disponibile e accede ai dati recuperati tramite [IChart.ChartData](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichart/chartdata/) e [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

Se il workbook esterno è non disponibile e il recupero è disabilitato, Aspose.Slides solleva un `InvalidOperationException`. Abilita il recupero solo quando l'uso dei dati del grafico in cache è un'opzione accettabile, poiché la cache potrebbe non contenere le modifiche apportate al workbook esterno dopo l'ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un grafico specifico è collegato a un workbook esterno o incorporato?**

Sì. Un grafico ha un [data source type](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chartdata/datasourcetype/) e un [path to an external workbook](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chartdata/externalworkbookpath/); se l'origine è un workbook esterno, è possibile leggere il percorso completo per verificare che venga utilizzato un file esterno.

**Sono supportati percorsi relativi a workbook esterni e come vengono memorizzati?**

Sì. Se si specifica un percorso relativo, questo viene convertito automaticamente in un percorso assoluto. È comodo per la portabilità del progetto; tuttavia, il percorso assoluto viene memorizzato nel file PPTX.

**Posso usare workbook situati su risorse di rete/condivisioni?**

Sì, tali workbook possono essere usati come origine dati esterna. Tuttavia, la modifica diretta di workbook remoti da Aspose.Slides non è supportata: possono essere usati solo come fonte.

**Aspose.Slides sovrascrive il file XLSX esterno quando salva la presentazione?**

No. La presentazione memorizza un [link al file esterno](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chartdata/externalworkbookpath/) e lo utilizza per la lettura dei dati. Il file esterno stesso non viene modificato al salvataggio della presentazione.

**Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password al momento del collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio usando [Aspose.Cells](/cells/net/)) e collegarsi a quella copia.

**Più grafici possono fare riferimento allo stesso workbook esterno?**

Sì. Ogni grafico memorizza il proprio collegamento. Se tutti puntano allo stesso file, l'aggiornamento di quel file verrà riflesso in ciascun grafico al successivo caricamento dei dati.