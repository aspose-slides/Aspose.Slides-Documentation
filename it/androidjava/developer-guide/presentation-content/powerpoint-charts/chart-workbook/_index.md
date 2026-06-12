---
title: Gestire i Workbook dei Grafici nelle Presentazioni su Android
linktitle: Workbook del Grafico
type: docs
weight: 70
url: /it/androidjava/chart-workbook/
keywords:
- workbook grafico
- dati del grafico
- cella del workbook
- etichetta dati
- foglio di lavoro
- origine dati
- workbook esterno
- dati esterni
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri Aspose.Slides per Android via Java: gestisci facilmente i workbook dei grafici in formato PowerPoint e OpenDocument per semplificare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con le cartelle di lavoro dei grafici in Aspose.Slides. Mostra come leggere e scrivere i dati del grafico tramite flussi di cartelle di lavoro, utilizzare le celle della cartella di lavoro come etichette dei dati del grafico, accedere alle collezioni di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Copre anche l'uso di cartelle di lavoro esterne come origini dati per i grafici. Gli esempi dimostrano come creare e assegnare una cartella di lavoro esterna, recuperare il percorso di una cartella di lavoro esterna collegata a un grafico e modificare i dati del grafico quando la cartella di lavoro è disponibile.

## **Leggere e Scrivere Dati del Grafico da una Cartella di Lavoro**

Aspose.Slides fornisce i metodi [ReadWorkbookStream](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) e [WriteWorkbookStream](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) che consentono di leggere e scrivere le cartelle di lavoro dei dati del grafico (contenenti dati del grafico modificati con Aspose.Cells). **Nota** che i dati del grafico devono essere organizzati nello stesso modo o devono avere una struttura simile a quella della sorgente.

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

## **Impostare una Cella del WorkBook come Etichetta Dati del Grafico**

1. Crea un'istanza della classe [Presentation](https://apireference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).
2. Ottieni il riferimento a una diapositiva tramite il suo indice.
3. Aggiungi un grafico a bolle con alcuni dati.
4. Accedi alle serie del grafico.
5. Imposta la cella del workbook come etichetta dei dati.
6. Salva la presentazione.

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

## **Gestire i Fogli di Lavoro**

Questo codice Java dimostra un'operazione in cui il metodo [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) viene utilizzato per accedere a una collezione di fogli di lavoro:

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

## **Specificare il Tipo di Origine Dati**

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

## **Rilevare Formati di Workbook Incorporati Non Supportati**

Aspose.Slides non supporta il formato Excel binary workbook (.xlsb) che può essere incorporato in alcuni grafici. È possibile utilizzare il metodo `getEmbeddedWorkbookType` su [IChartData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IChartData) insieme all'enumerazione [WorkbookType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/WorkbookType) per rilevare i formati non supportati ed escludere quei grafici.

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

## **Workbook Esterno**

Aspose.Slides supporta workbook esterni come origine dati per i grafici.

### **Creare un Workbook Esterno**

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

### **Impostare un Workbook Esterno**

Utilizzando il metodo **`setExternalWorkbook`**, è possibile assegnare un workbook esterno a un grafico come sua origine dati. Questo metodo può anche essere usato per aggiornare il percorso del workbook esterno (se quest'ultimo è stato spostato).

Sebbene non sia possibile modificare i dati nei workbook archiviati in posizioni o risorse remote, è comunque possibile utilizzare tali workbook come origine dati esterna. Se viene fornito un percorso relativo per un workbook esterno, esso viene convertito automaticamente in un percorso completo.

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

Il parametro `ChartData` (nell'ambito del metodo `setExternalWorkbook`) viene utilizzato per specificare se un workbook Excel deve essere caricato o meno.

* Quando il valore di `ChartData` è impostato su `false`, viene aggiornato solo il percorso del workbook — i dati del grafico non verranno caricati né aggiornati dal workbook di destinazione. È possibile utilizzare questa impostazione quando il workbook di destinazione è inesistente o non disponibile.  
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

### **Ottenere il Percorso del Workbook di Origine Dati Esterno di un Grafico**

1. Crea un'istanza della classe [Presentation](https://apireference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).
2. Ottieni il riferimento a una diapositiva tramite il suo indice.
3. Crea un oggetto per la forma del grafico.
4. Crea un oggetto per il tipo di origine (`ChartDataSourceType`) che rappresenta l'origine dati del grafico.
5. Specifica la condizione pertinente basata sul fatto che il tipo di origine sia lo stesso del tipo di origine dati del workbook esterno.

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

### **Modificare i Dati del Grafico**

È possibile modificare i dati nei workbook esterni nello stesso modo in cui si apportano modifiche al contenuto dei workbook interni. Quando un workbook esterno non può essere caricato, viene generata un'eccezione.

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

## **FAQ**

**Posso determinare se un grafico specifico è collegato a un workbook esterno o incorporato?**

Sì. Un grafico ha un [data source type](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) e un [path to an external workbook](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); se l'origine è un workbook esterno, è possibile leggere il percorso completo per accertarsi che venga utilizzato un file esterno.

**Sono supportati i percorsi relativi ai workbook esterni e come vengono memorizzati?**

Sì. Se si specifica un percorso relativo, questo viene automaticamente convertito in un percorso assoluto. È comodo per la portabilità del progetto; tuttavia, è necessario sapere che la presentazione memorizzerà il percorso assoluto nel file PPTX.

**Posso utilizzare workbook situati su risorse o condivisioni di rete?**

Sì, tali workbook possono essere utilizzati come origine dati esterna. Tuttavia, la modifica di workbook remoti direttamente da Aspose.Slides non è supportata: possono essere solo utilizzati come origine.

**Aspose.Slides sovrascrive il file XLSX esterno quando si salva la presentazione?**

No. La presentazione memorizza un [link to the external file](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) e lo utilizza per leggere i dati. Il file esterno stesso non viene modificato quando la presentazione viene salvata.

**Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password durante il collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio, usando [Aspose.Cells](/cells/androidjava/)) e collegarsi a quella copia.

**Più grafici possono fare riferimento allo stesso workbook esterno?**

Sì. Ogni grafico memorizza il proprio collegamento. Se tutti puntano allo stesso file, l'aggiornamento di quel file verrà riflesso in ciascun grafico al successivo caricamento dei dati.