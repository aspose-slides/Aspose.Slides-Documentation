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
description: "Scopri Aspose.Slides per .NET: gestisci facilmente le cartelle di lavoro dei grafici in PowerPoint e nei formati OpenDocument per ottimizzare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con le cartelle di lavoro dei grafici in Aspose.Slides. Mostra come leggere e scrivere i dati del grafico tramite flussi di cartella di lavoro, usare le celle della cartella di lavoro come etichette dei dati del grafico, accedere alle collezioni di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Copre anche il lavoro con cartelle di lavoro esterne come fonti dati per i grafici. Gli esempi dimostrano come creare e assegnare una cartella di lavoro esterna, recuperare il percorso di una cartella di lavoro esterna collegata a un grafico e modificare i dati del grafico quando la cartella di lavoro è disponibile.

## **Leggere e scrivere dati del grafico da una cartella di lavoro**
Aspose.Slides fornisce i metodi [ReadWorkbookStream](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/readworkbookstream/) e [WriteWorkbookStream](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/writeworkbookstream/) che consentono di leggere e scrivere le cartelle di lavoro dei dati del grafico (contenenti dati del grafico modificati con Aspose.Cells). **Note** i dati del grafico devono essere organizzati nello stesso modo o devono avere una struttura simile a quella della sorgente.

Questo codice C# dimostra un’operazione di esempio:

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

## **Impostare una cella di WorkBook come etichetta dei dati del grafico**
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottieni il riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un grafico a bolle con alcuni dati.
1. Accedi alle serie del grafico.
1. Imposta la cella della cartella di lavoro come etichetta dei dati.
1. Salva la presentazione.

Questo codice C# mostra come impostare una cella di WorkBook come etichetta dei dati del grafico:

```c#
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

## **Gestire i fogli di lavoro**

Questo codice C# dimostra un'operazione in cui la proprietà [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) viene utilizzata per accedere a una collezione di fogli di lavoro:

``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Specificare il tipo di origine dati**

Questo codice C# mostra come specificare un tipo per una fonte dati:

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

## **Rilevare i formati di cartelle di lavoro incorporati non supportati**

Aspose.Slides non supporta il formato cartella di lavoro binaria Excel (.xlsb) che può essere incorporato in alcuni grafici. È possibile utilizzare la proprietà `EmbeddedWorkbookType` su [IChartData](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/) insieme all'enumerazione [WorkbookType](https://reference.aspose.com/slides/it/net/aspose.slides.charts/workbooktype/) per rilevare formati non supportati e saltare quei grafici.

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
            // Il workbook incorporato è in formato .xlsb, che non è supportato.
            continue;
        }

        // Leggi o modifica i dati del workbook del grafico qui.
    }
}
```

## **Cartella di lavoro esterna**

{{% alert color="primary" %}} 
In [Aspose.Slides 19.4](https://docs.aspose.com/slides/it/net/aspose-slides-for-net-19-4-release-notes/), abbiamo implementato il supporto per le cartelle di lavoro esterne come fonte dati per i grafici.
{{% /alert %}} 

### **Creare una cartella di lavoro esterna**
Utilizzando i metodi **`ReadWorkbookStream`** e **`SetExternalWorkbook`**, è possibile creare una cartella di lavoro esterna da zero o rendere esterna una cartella di lavoro interna.

Questo codice C# dimostra il processo di creazione della cartella di lavoro esterna:

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

### **Impostare una cartella di lavoro esterna**
Utilizzando il metodo **`SetExternalWorkbook`**, è possibile assegnare una cartella di lavoro esterna a un grafico come sua fonte dati. Questo metodo può anche essere usato per aggiornare il percorso della cartella di lavoro esterna (se quest’ultima è stata spostata).

Sebbene non sia possibile modificare i dati nelle cartelle di lavoro memorizzate in posizioni remote o risorse, è comunque possibile utilizzare tali cartelle di lavoro come fonte dati esterna. Se viene fornito un percorso relativo per una cartella di lavoro esterna, questo viene convertito automaticamente in un percorso completo.

Questo codice C# mostra come impostare una cartella di lavoro esterna:

```c#
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

Il parametro `ChartData` (sotto il metodo `SetExternalWorkbook`) è usato per specificare se una cartella di lavoro Excel verrà caricata o meno. 

* Quando il valore di `ChartData` è impostato su `false`, viene aggiornato solo il percorso della cartella di lavoro — i dati del grafico non verranno caricati né aggiornati dalla cartella di lavoro di destinazione. È consigliabile usare questa impostazione quando la cartella di lavoro di destinazione non esiste o non è disponibile. 
* Quando il valore di `ChartData` è impostato su `true`, i dati del grafico vengono aggiornati dalla cartella di lavoro di destinazione.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Ottenere il percorso della cartella di lavoro sorgente dati esterna di un grafico**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottieni il riferimento a una diapositiva tramite il suo indice.
1. Crea un oggetto per la forma del grafico.
1. Crea un oggetto per il tipo di sorgente (`ChartDataSourceType`) che rappresenta la fonte dati del grafico.
1. Specifica la condizione pertinente in base al fatto che il tipo di sorgente sia lo stesso del tipo di sorgente della cartella di lavoro esterna.

Questo codice C# dimostra l'operazione:

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
    
    // Salva la presentazione
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **Modificare i dati del grafico**

È possibile modificare i dati nelle cartelle di lavoro esterne allo stesso modo in cui si modificano i contenuti delle cartelle di lavoro interne. Quando una cartella di lavoro esterna non può essere caricata, viene generata un'eccezione.

Questo codice C# è un'implementazione del processo descritto:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **Recuperare una cartella di lavoro dalla cache del grafico**

Se un grafico utilizza una cartella di lavoro esterna mancante o non disponibile, Aspose.Slides può ricostruire la cartella di lavoro del grafico dai dati memorizzati nella presentazione. Crea un oggetto [LoadOptions](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/), configura le sue [SpreadsheetOptions](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/spreadsheetoptions/), e imposta [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/it/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) su `true` prima di aprire la presentazione.

Il seguente esempio C# apre una presentazione il cui grafico fa riferimento a una cartella di lavoro esterna non disponibile e accede ai dati recuperati tramite [IChart.ChartData](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichart/chartdata/) e [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

// Read or modify the recovered workbook data here.
```

Se la cartella di lavoro esterna non è disponibile e il recupero è disabilitato, Aspose.Slides lancia un `InvalidOperationException`. Abilita il recupero solo quando è accettabile utilizzare i dati del grafico memorizzati nella cache, poiché la cache potrebbe non contenere le modifiche apportate alla cartella di lavoro esterna dopo l'ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un grafico specifico è collegato a una cartella di lavoro esterna o incorporata?**

Sì. Un grafico ha un [data source type](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chartdata/datasourcetype/) e un [path to an external workbook](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chartdata/externalworkbookpath/); se la sorgente è una cartella di lavoro esterna, è possibile leggere il percorso completo per verificare che venga utilizzato un file esterno.

**I percorsi relativi alle cartelle di lavoro esterne sono supportati e come vengono memorizzati?**

Sì. Se specifichi un percorso relativo, questo viene convertito automaticamente in un percorso assoluto. È comodo per la portabilità del progetto; tuttavia, tieni presente che la presentazione memorizzerà il percorso assoluto nel file PPTX.

**Posso usare cartelle di lavoro situate su risorse o condivisioni di rete?**

Sì, tali cartelle di lavoro possono essere usate come fonte dati esterna. Tuttavia, la modifica diretta di cartelle di lavoro remote da Aspose.Slides non è supportata — possono essere usate solo come fonte.

**Aspose.Slides sovrascrive il file XLSX esterno durante il salvataggio della presentazione?**

No. La presentazione memorizza un [link to the external file](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chartdata/externalworkbookpath/) e lo utilizza per leggere i dati. Il file esterno stesso non viene modificato quando la presentazione viene salvata.

**Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password durante il collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio, usando [Aspose.Cells](/cells/net/)) e collegarsi a quella copia.

**Più grafici possono fare riferimento alla stessa cartella di lavoro esterna?**

Sì. Ogni grafico memorizza il proprio link. Se tutti puntano allo stesso file, l'aggiornamento di quel file sarà riflesso in ciascun grafico al successivo caricamento dei dati.