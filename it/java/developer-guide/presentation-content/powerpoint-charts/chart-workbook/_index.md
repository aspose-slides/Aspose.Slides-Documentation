---
title: Gestire i workbook dei grafici nelle presentazioni con Java
linktitle: Workbook del grafico
type: docs
weight: 70
url: /it/java/chart-workbook/
keywords:
- workbook del grafico
- dati del grafico
- cella del workbook
- etichetta dati
- foglio di lavoro
- origine dati
- workbook esterno
- dati esterni
- cache del grafico
- recupero del workbook
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri Aspose.Slides per Java: gestisci facilmente i workbook dei grafici in formati PowerPoint e OpenDocument per ottimizzare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con i workbook dei grafici in Aspose.Slides. Mostra come leggere e scrivere dati del grafico tramite flussi di workbook, utilizzare le celle del workbook come etichette dei dati del grafico, accedere alle collezioni di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Copre inoltre l'utilizzo di workbook esterni come origini dati per i grafici. Gli esempi dimostrano come creare e assegnare un workbook esterno, recuperare il percorso di un workbook esterno collegato a un grafico e modificare i dati del grafico quando il workbook è disponibile.

## **Leggere e scrivere dati del grafico da un workbook**

Aspose.Slides fornisce i metodi [ReadWorkbookStream](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChartData#readWorkbookStream--) e [WriteWorkbookStream](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) che consentono di leggere e scrivere workbook dei dati del grafico (contenenti dati del grafico modificati con Aspose.Cells). **Note** che i dati del grafico devono essere organizzati nello stesso modo o devono avere una struttura simile a quella della sorgente.

Questo codice Java dimostra un'operazione di esempio:

```java
Presentation pres = new Presentation("chart.pptx");
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartData data = chart.getChartData();

    byte[] stream = data.readWorkbookStream();

    data.getSeries().clear();
    data.getCategories().clear();

    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Impostare una cella WorkBook come etichetta dei dati del grafico**

1. Creare un'istanza della classe [Presentation](https://apireference.aspose.com/slides/it/java/com.aspose.slides/presentation).
1. Ottenere il riferimento di una diapositiva tramite il suo indice.
1. Aggiungere un grafico a bolle con alcuni dati.
1. Accedere alla serie del grafico.
1. Impostare la cella del workbook come etichetta dei dati.
1. Salvare la presentazione.

Questo codice Java mostra come impostare una cella del workbook come etichetta dei dati del grafico:

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Istanzia una classe di presentazione che rappresenta un file di presentazione
Presentation pres = new Presentation("chart2.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    IDataLabelCollection dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));

    pres.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gestire i fogli di lavoro**

Questo codice Java dimostra un'operazione in cui il metodo [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) viene utilizzato per accedere a una collezione di fogli di lavoro:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook wb =  chart.getChartData().getChartDataWorkbook();
    for (int i = 0; i < wb.getWorksheets().size(); i++)
        System.out.println(wb.getWorksheets().get_Item(i).getName());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Specificare il tipo di origine dati**

Questo codice Java mostra come specificare un tipo per un'origine dati:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.getChartData().getSeries().get_Item(0).getName();

    val.setDataSourceType(DataSourceType.StringLiterals);
    val.setData("LiteralString");

    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rilevare formati di workbook incorporati non supportati**

Aspose.Slides non supporta il formato diWorkbook binario Excel (.xlsb) che può essere incorporato in alcuni grafici. È possibile utilizzare il metodo `getEmbeddedWorkbookType` su [IChartData](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChartData) insieme all'enumerazione [WorkbookType](https://reference.aspose.com/slides/it/java/com.aspose.slides/WorkbookType) per rilevare formati non supportati e saltare quei grafici.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // Il workbook incorporato è in formato .xlsb, che non è supportato.
            continue;
        }

        // Leggi o modifica i dati del workbook del grafico qui.
    }
} finally {
    presentation.dispose();
}
```

## **Workbook esterno**

{{% alert color="primary" %}} 
In [Aspose.Slides 19.4](https://docs.aspose.com/slides/it/java/aspose-slides-for-java-19-4-release-notes/), abbiamo implementato il supporto per workbook esterni come origine dati per i grafici.
{{% /alert %}} 

### **Creare un workbook esterno**

Utilizzando i metodi **`readWorkbookStream`** e **`setExternalWorkbook`**, è possibile creare un workbook esterno da zero o rendere esterno un workbook interno.

Questo codice Java dimostra il processo di creazione del workbook esterno:

```java
Presentation pres = new Presentation();
try {
    final String workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    FileOutputStream fileStream = new FileOutputStream(workbookPath);
    try {
        byte[] workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) fileStream.close();
    }

    chart.getChartData().setExternalWorkbook(workbookPath);

    pres.save("externalWorkbook.pptx", SaveFormat.Pptx);
} catch (IOException e) {    
} finally {
    if (pres != null) pres.dispose();
}
```

### **Impostare un workbook esterno**

Utilizzando il metodo **`setExternalWorkbook`**, è possibile assegnare un workbook esterno a un grafico come sua origine dati. Questo metodo può anche essere usato per aggiornare il percorso del workbook esterno (se quest'ultimo è stato spostato).

Sebbene non sia possibile modificare i dati nei workbook archiviati in posizioni remote o risorse, è comunque possibile utilizzare tali workbook come origine dati esterna. Se viene fornito un percorso relativo per un workbook esterno, questo viene convertito automaticamente in un percorso completo.

Questo codice Java mostra come impostare un workbook esterno:

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.getChartData();

    chartData.setExternalWorkbook("externalWorkbook.xlsx");

    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));

    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    
    pres.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Il parametro `ChartData` (sotto il metodo `setExternalWorkbook`) specifica se un workbook Excel verrà caricato o meno.

* Quando il valore di `ChartData` è impostato su `false`, viene aggiornato solo il percorso del workbook — i dati del grafico non verranno caricati o aggiornati dal workbook di destinazione. Questo può essere utile quando il workbook di destinazione è inesistente o non disponibile. 
* Quando il valore di `ChartData` è impostato su `true`, i dati del grafico vengono aggiornati dal workbook di destinazione.

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();

    ((ChartData)chartData).setExternalWorkbook("http://path/doesnt/exists", false);

    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Ottenere il percorso del workbook di origine dati esterno di un grafico**

1. Creare un'istanza della classe [Presentation](https://apireference.aspose.com/slides/it/java/com.aspose.slides/presentation).
1. Ottenere il riferimento di una diapositiva tramite il suo indice.
1. Creare un oggetto per la forma del grafico.
1. Creare un oggetto per il tipo di origine (`ChartDataSourceType`) che rappresenta l'origine dati del grafico.
1. Specificare la condizione rilevante in base al fatto che il tipo di origine sia lo stesso del tipo di workbook esterno.

Questo codice Java dimostra l'operazione:

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// Salva la presentazione
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Modificare i dati del grafico**

È possibile modificare i dati nei workbook esterni nello stesso modo in cui si modificano i contenuti dei workbook interni. Quando un workbook esterno non può essere caricato, viene generata un'eccezione.

Questo codice Java è un'implementazione del processo descritto:

```java
// Crea un'istanza della classe Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = (IChart)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ChartData chartData = (ChartData)chart.getChartData();
    
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    
    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Recuperare un workbook dalla cache del grafico**

Se un grafico utilizza un workbook esterno mancante o non disponibile, Aspose.Slides può ricostruire il workbook del grafico dai dati memorizzati nella presentazione. Creare un'istanza di [LoadOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/), configurarla con [SpreadsheetOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/spreadsheetoptions/), e chiamare [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/it/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) con `true` prima di aprire la presentazione.

Il seguente esempio Java apre una presentazione il cui grafico fa riferimento a un workbook esterno non disponibile e accede ai dati recuperati tramite [IChart.getChartData](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichart/#getChartData--) e [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Leggi o modifica i dati del workbook recuperato qui.
} finally {
    presentation.dispose();
}
```

Se il workbook esterno è non disponibile e il recupero è disabilitato, Aspose.Slides genera un'eccezione. Abilitare il recupero solo quando l'uso dei dati del grafico in cache è una soluzione accettabile, poiché la cache potrebbe non contenere le modifiche apportate al workbook esterno dopo l'ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un grafico specifico è collegato a un workbook esterno o incorporato?**

Sì. Un grafico ha un [tipo di origine dati](https://reference.aspose.com/slides/it/java/com.aspose.slides/chartdata/#getDataSourceType--) e un [percorso verso un workbook esterno](https://reference.aspose.com/slides/it/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); se l'origine è un workbook esterno, è possibile leggere il percorso completo per verificare che venga utilizzato un file esterno.

**I percorsi relativi ai workbook esterni sono supportati e come vengono memorizzati?**

Sì. Se si specifica un percorso relativo, questo viene automaticamente convertito in un percorso assoluto. È comodo per la portabilità del progetto; tuttavia, il percorso assoluto viene memorizzato nel file PPTX della presentazione.

**Posso usare workbook situati su risorse di rete/condivisioni?**

Sì, tali workbook possono essere usati come origine dati esterna. Tuttavia, la modifica diretta di workbook remoti da Aspose.Slides non è supportata—possono essere usati solo come sorgente.

**Aspose.Slides sovrascrive l'XLSX esterno quando salva la presentazione?**

No. La presentazione memorizza un [link al file esterno](https://reference.aspose.com/slides/it/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) e lo utilizza per la lettura dei dati. Il file esterno stesso non viene modificato quando la presentazione viene salvata.

**Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password durante il collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio, usando [Aspose.Cells](/cells/java/)) e collegarsi a tale copia.

**Più grafici possono fare riferimento allo stesso workbook esterno?**

Sì. Ogni grafico memorizza il proprio link. Se tutti puntano allo stesso file, l'aggiornamento di quel file verrà riflesso in ciascun grafico al successivo caricamento dei dati.