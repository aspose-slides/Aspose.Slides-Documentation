---
title: Gestisci le cartelle di lavoro dei grafici nelle presentazioni con Java
linktitle: Cartella di lavoro del grafico
type: docs
weight: 70
url: /it/java/chart-workbook/
keywords:
- cartella di lavoro del grafico
- dati del grafico
- cella della cartella di lavoro
- etichetta dati
- foglio di lavoro
- origine dati
- cartella di lavoro esterna
- dati esterni
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri Aspose.Slides per Java: gestisci facilmente le cartelle di lavoro dei grafici nei formati PowerPoint e OpenDocument per semplificare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con le cartelle di lavoro dei grafici in Aspose.Slides. Mostra come leggere e scrivere i dati del grafico tramite flussi di cartelle di lavoro, utilizzare le celle della cartella di lavoro come etichette dei dati del grafico, accedere alle collezioni di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Copre inoltre l'utilizzo di cartelle di lavoro esterne come sorgenti dati per i grafici. Gli esempi dimostrano come creare e assegnare una cartella di lavoro esterna, recuperare il percorso di una cartella di lavoro esterna collegata a un grafico e modificare i dati del grafico quando la cartella di lavoro è disponibile.

## **Leggere e Scrivere i Dati del Grafico da una Cartella di Lavoro**
Aspose.Slides fornisce i metodi [ReadWorkbookStream](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChartData#readWorkbookStream--) e [WriteWorkbookStream](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) che consentono di leggere e scrivere le cartelle di lavoro dei dati del grafico (contenenti dati del grafico modificati con Aspose.Cells). **Nota** che i dati del grafico devono essere organizzati nello stesso modo o devono avere una struttura simile a quella della sorgente.

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

## **Impostare una Cella di WorkBook come Etichetta Dati del Grafico**

1. Creare un'istanza della classe [Presentation](https://apireference.aspose.com/slides/it/java/com.aspose.slides/presentation).
2. Ottenere un riferimento a una diapositiva tramite il suo indice.
3. Aggiungere un grafico a bolle con alcuni dati.
4. Accedere alla serie del grafico.
5. Impostare la cella del workbook come etichetta dati.
6. Salvare la presentazione.

Questo codice Java mostra come impostare una cella del workbook come etichetta dati del grafico:

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

## **Rilevare Formati Non Supportati di Cartelle di Lavoro Incorporate**

Aspose.Slides non supporta il formato di cartella di lavoro Excel binario (.xlsb) che può essere incorporato in alcuni grafici. È possibile utilizzare il metodo `getEmbeddedWorkbookType` su [IChartData](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChartData) insieme all'enumerazione [WorkbookType](https://reference.aspose.com/slides/it/java/com.aspose.slides/WorkbookType) per rilevare formati non supportati e ignorare quei grafici.

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

## **Cartella di Lavoro Esterna**

{{% alert color="primary"%}} 
In [Aspose.Slides 19.4](https://docs.aspose.com/slides/it/java/aspose-slides-for-java-19-4-release-notes/), abbiamo implementato il supporto per le cartelle di lavoro esterne come origine dati per i grafici.
{{% /alert%}} 

### **Creare una Cartella di Lavoro Esterna**

Utilizzando i metodi **`readWorkbookStream`** e **`setExternalWorkbook`**, è possibile creare una cartella di lavoro esterna da zero oppure rendere esterna una cartella di lavoro interna.

Questo codice Java dimostra il processo di creazione della cartella di lavoro esterna:

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

### **Impostare una Cartella di Lavoro Esterna**

Utilizzando il metodo **`setExternalWorkbook`**, è possibile assegnare una cartella di lavoro esterna a un grafico come sua origine dati. Questo metodo può anche essere utilizzato per aggiornare il percorso della cartella di lavoro esterna (se quest'ultima è stata spostata).

Sebbene non sia possibile modificare i dati nelle cartelle di lavoro archiviate in posizioni remote o risorse, è comunque possibile utilizzare tali cartelle di lavoro come origine dati esterna. Se viene fornito un percorso relativo per una cartella di lavoro esterna, questo viene convertito automaticamente in un percorso completo.

Questo codice Java mostra come impostare una cartella di lavoro esterna:

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

Il parametro `ChartData` (sotto il metodo `setExternalWorkbook`) è usato per specificare se una cartella di lavoro Excel verrà caricata o meno.

* Quando il valore di `ChartData` è impostato su `false`, viene aggiornato solo il percorso della cartella di lavoro: i dati del grafico non verranno caricati o aggiornati dalla cartella di lavoro di destinazione. Questa impostazione è utile quando la cartella di lavoro di destinazione è inesistente o non disponibile. 
* Quando il valore di `ChartData` è impostato su `true`, i dati del grafico vengono aggiornati dalla cartella di lavoro di destinazione.

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

### **Ottenere il Percorso della Cartella di Lavoro Esterna di un Grafico**

1. Creare un'istanza della classe [Presentation](https://apireference.aspose.com/slides/it/java/com.aspose.slides/presentation).
2. Ottenere un riferimento a una diapositiva tramite il suo indice.
3. Creare un oggetto per la forma del grafico.
4. Creare un oggetto per il tipo di sorgente (`ChartDataSourceType`) che rappresenta l'origine dati del grafico.
5. Specificare la condizione pertinente in base al fatto che il tipo di sorgente sia lo stesso del tipo di sorgente della cartella di lavoro esterna.

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

È possibile modificare i dati nelle cartelle di lavoro esterne nello stesso modo in cui si modificano i contenuti delle cartelle di lavoro interne. Quando una cartella di lavoro esterna non può essere caricata, viene generata un'eccezione.

Questo codice Java implementa il processo descritto:

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

**Posso determinare se un grafico specifico è collegato a una cartella di lavoro esterna o incorporata?**

Sì. Un grafico ha un [tipo di origine dati](https://reference.aspose.com/slides/it/java/com.aspose.slides/chartdata/#getDataSourceType--) e un [percorso a una cartella di lavoro esterna](https://reference.aspose.com/slides/it/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); se la sorgente è una cartella di lavoro esterna, è possibile leggere il percorso completo per verificare che venga utilizzato un file esterno.

**Sono supportati i percorsi relativi alle cartelle di lavoro esterne e come vengono memorizzati?**

Sì. Se si specifica un percorso relativo, questo viene automaticamente convertito in un percorso assoluto. ciò è comodo per la portabilità del progetto; tuttavia, la presentazione memorizzerà il percorso assoluto nel file PPTX.

**Posso utilizzare cartelle di lavoro situate su risorse di rete/condivisioni?**

Sì, tali cartelle di lavoro possono essere usate come origine dati esterna. Tuttavia, la modifica diretta di cartelle di lavoro remote da Aspose.Slides non è supportata: possono solo essere usate come sorgente.

**Aspose.Slides sovrascrive il file XLSX esterno durante il salvataggio della presentazione?**

No. La presentazione memorizza un [collegamento al file esterno](https://reference.aspose.com/slides/it/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) e lo utilizza per leggere i dati. Il file esterno stesso non viene modificato quando la presentazione viene salvata.

**Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password durante il collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio, usando [Aspose.Cells](/cells/java/)) e collegarsi a quella copia.

**Più grafici possono fare riferimento alla stessa cartella di lavoro esterna?**

Sì. Ogni grafico memorizza il proprio collegamento. Se tutti puntano allo stesso file, l'aggiornamento di quel file verrà riflesso in ciascun grafico al successivo caricamento dei dati.