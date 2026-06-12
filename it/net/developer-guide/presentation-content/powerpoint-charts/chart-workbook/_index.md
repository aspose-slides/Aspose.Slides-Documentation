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
- origine dati
- workbook esterno
- dati esterni
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri Aspose.Slides per .NET: gestisci facilmente i workbook dei grafici in formati PowerPoint e OpenDocument per semplificare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con i workbook dei grafici in Aspose.Slides. Mostra come leggere e scrivere i dati dei grafici tramite flussi di workbook, utilizzare le celle del workbook come etichette dei dati del grafico, accedere alle raccolte di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Copre inoltre il lavoro con workbook esterni come origini dati per i grafici. Gli esempi dimostrano come creare e assegnare un workbook esterno, recuperare il percorso di un workbook esterno collegato a un grafico e modificare i dati del grafico quando il workbook è disponibile.

## **Leggere e scrivere dati del grafico da un workbook**
Aspose.Slides fornisce i metodi [ReadWorkbookStream](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/readworkbookstream/) e [WriteWorkbookStream](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/writeworkbookstream/) che consentono di leggere e scrivere i workbook dei dati del grafico (contenenti dati del grafico modificati con Aspose.Cells). **Nota** che i dati del grafico devono essere organizzati nello stesso modo o devono avere una struttura simile a quella della sorgente.

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

## **Impostare una cella del workbook come etichetta dei dati del grafico**
1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottenere il riferimento a una diapositiva tramite il suo indice.
1. Aggiungere un grafico Bubble con alcuni dati.
1. Accedere alla serie del grafico.
1. Impostare la cella del workbook come etichetta dei dati.
1. Salvare la presentazione.

Questo codice C# mostra come impostare una cella del workbook come etichetta dei dati del grafico:

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

Questo codice C# dimostra un’operazione in cui la proprietà [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) è usata per accedere a una raccolta di fogli di lavoro:

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

Questo codice C# mostra come specificare un tipo per un’origine dati:

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

## **Rilevare formati di workbook incorporati non supportati**

Aspose.Slides non supporta il formato di workbook Excel binario (.xlsb) che può essere incorporato in alcuni grafici. È possibile utilizzare la proprietà `EmbeddedWorkbookType` su [IChartData](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichartdata/) insieme all’enumerazione [WorkbookType](https://reference.aspose.com/slides/it/net/aspose.slides.charts/workbooktype/) per rilevare i formati non supportati e ignorare quei grafici.

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

## **Workbook esterno**

{{% alert color="primary" %}} 
In [Aspose.Slides 19.4](https://docs.aspose.com/slides/it/net/aspose-slides-for-net-19-4-release-notes/), abbiamo implementato il supporto per workbook esterni come origine dati per i grafici.
{{% /alert %}} 

### **Creare un workbook esterno**
Utilizzando i metodi **`ReadWorkbookStream`** e **`SetExternalWorkbook`**, è possibile creare un workbook esterno da zero o rendere esterno un workbook interno.

Questo codice C# dimostra il processo di creazione del workbook esterno:

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

### **Impostare un workbook esterno**
Utilizzando il metodo **`SetExternalWorkbook`**, è possibile assegnare un workbook esterno a un grafico come sua origine dati. Questo metodo può anche essere usato per aggiornare il percorso del workbook esterno (se quest’ultimo è stato spostato).

Sebbene non sia possibile modificare i dati nei workbook memorizzati in posizioni remote o risorse, è comunque possibile utilizzare tali workbook come origine dati esterna. Se viene fornito un percorso relativo per un workbook esterno, esso viene convertito automaticamente in un percorso completo.

Questo codice C# mostra come impostare un workbook esterno:

```c#
// Il percorso della cartella dei documenti.
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

Il parametro `ChartData` (nel metodo `SetExternalWorkbook`) è usato per specificare se un workbook Excel deve essere caricato o meno.

* Quando il valore di `ChartData` è impostato su `false`, viene aggiornato solo il percorso del workbook: i dati del grafico non verranno caricati né aggiornati dal workbook di destinazione. È opportuno utilizzare questa impostazione quando il workbook di destinazione è inesistente o non disponibile. 
* Quando il valore di `ChartData` è impostato su `true`, i dati del grafico vengono aggiornati dal workbook di destinazione.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Ottenere il percorso del workbook esterno di origine dati di un grafico**

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Ottenere il riferimento a una diapositiva tramite il suo indice.
1. Creare un oggetto per la forma del grafico.
1. Creare un oggetto per il tipo di origine (`ChartDataSourceType`) che rappresenta l’origine dati del grafico.
1. Specificare la condizione pertinente in base al fatto che il tipo di origine sia lo stesso del tipo di origine dati del workbook esterno.

Questo codice C# dimostra l’operazione:

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

È possibile modificare i dati nei workbook esterni allo stesso modo in cui si apportano modifiche al contenuto dei workbook interni. Quando un workbook esterno non può essere caricato, viene generata un’eccezione.

Questo codice C# implementa il processo descritto:

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

**Posso determinare se un grafico specifico è collegato a un workbook esterno o incorporato?**

Sì. Un grafico dispone di un [tipo di origine dati](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chartdata/datasourcetype/) e di un [percorso a un workbook esterno](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chartdata/externalworkbookpath/); se la sorgente è un workbook esterno, è possibile leggere il percorso completo per verificare che sia stato utilizzato un file esterno.

**Sono supportati i percorsi relativi ai workbook esterni e come vengono memorizzati?**

Sì. Se si specifica un percorso relativo, questo viene automaticamente convertito in un percorso assoluto. Ciò è comodo per la portabilità del progetto; tuttavia, tenere presente che la presentazione memorizzerà il percorso assoluto nel file PPTX.

**Posso usare workbook situati su risorse/condivisioni di rete?**

Sì, tali workbook possono essere usati come origine dati esterna. Tuttavia, la modifica diretta di workbook remoti da Aspose.Slides non è supportata: possono essere usati solo come fonte.

**Aspose.Slides sovrascrive il file XLSX esterno quando salva la presentazione?**

No. La presentazione memorizza un [collegamento al file esterno](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chartdata/externalworkbookpath/) e lo utilizza per leggere i dati. Il file esterno stesso non viene modificato al salvataggio della presentazione.

**Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password durante il collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio usando [Aspose.Cells](/cells/net/)) e collegare a quella copia.

**Più grafici possono fare riferimento allo stesso workbook esterno?**

Sì. Ogni grafico memorizza il proprio collegamento. Se tutti puntano allo stesso file, l’aggiornamento di quel file si rifletterà in ciascun grafico al successivo caricamento dei dati.