---
title: Gestire le cartelle di lavoro dei grafici nelle presentazioni usando Java
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
- cache del grafico
- recupero della cartella di lavoro
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri Aspose.Slides per Java: gestisci facilmente le cartelle di lavoro dei grafici in formati PowerPoint e OpenDocument per ottimizzare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con le cartelle di lavoro dei grafici in Aspose.Slides. Mostra come leggere e scrivere i dati del grafico tramite flussi di cartelle di lavoro, utilizzare le celle della cartella di lavoro come etichette dei dati del grafico, accedere alle collezioni di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Tratta inoltre l'utilizzo di cartelle di lavoro esterne come fonti di dati per i grafici. Gli esempi dimostrano come creare e assegnare una cartella di lavoro esterna, recuperare il percorso di una cartella di lavoro esterna collegata a un grafico e modificare i dati del grafico quando la cartella di lavoro è disponibile.

## **Leggere e scrivere dati del grafico da una cartella di lavoro**

Aspose.Slides fornisce i metodi [ReadWorkbookStream](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChartData#readWorkbookStream--) e [WriteWorkbookStream](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) che consentono di leggere e scrivere le cartelle di lavoro dei dati del grafico (contenenti dati del grafico modificati con Aspose.Cells). **Nota** che i dati del grafico devono essere organizzati nello stesso modo o avere una struttura simile alla sorgente.

```java
import com.aspose.slides.*;

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

### **Convalidare il layout del grafico dopo la modifica della cartella di lavoro**

Quando si sostituisce una cartella di lavoro incorporata con una modificata, il grafico mantiene le collezioni di serie e categorie originali. Questa incongruenza può provocare l'eccezione `chart.validateChartLayout()` con `ArgumentOutOfRangeException` (parametro: index). Per evitare l'eccezione, cancellare le serie e le categorie esistenti **prima** di scrivere la cartella di lavoro aggiornata nel grafico.

```java
// Dopo aver modificato lo stream della cartella di lavoro (ad esempio, usando Aspose.Cells)
byte[] updatedWorkbook = baos.toByteArray();

// Cancella i riferimenti ai dati esistenti.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

// Scrivi la cartella di lavoro aggiornata nel grafico.
chart.getChartData().writeWorkbookStream(updatedWorkbook);

// Ora la convalida ha successo.
chart.validateChartLayout();
```

Cancellare le collezioni garantisce che la struttura dei dati del grafico sia allineata con la nuova cartella di lavoro, consentendo a `validateChartLayout()` di completarsi senza errori.

## **Impostare una cella della cartella di lavoro come etichetta dei dati del grafico**

1. Creare un'istanza della classe [Presentation](https://apireference.aspose.com/slides/it/java/com.aspose.slides/presentation).
1. Ottenere un riferimento a una diapositiva tramite il suo indice.
1. Aggiungere un grafico a bolle con alcuni dati.
1. Accedere alla serie del grafico.
1. Impostare la cella della cartella di lavoro come etichetta dei dati.
1. Salvare la presentazione.

Questo codice Java mostra come impostare una cella della cartella di lavoro come etichetta dei dati del grafico:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Istanzia una classe Presentation che rappresenta un file di presentazione
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
import com.aspose.slides.*;

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
import com.aspose.slides.*;

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

## **Rilevare formati di cartella di lavoro incorporati non supportati**

Aspose.Slides non supporta il formato di cartella di lavoro Excel binario (.xlsb) che può essere incorporato in alcuni grafici. È possibile utilizzare il metodo `getEmbeddedWorkbookType` su [IChartData](https://reference.aspose.com/slides/it/java/com.aspose.slides/IChartData) insieme all'enumerazione [WorkbookType](https://reference.aspose.com/slides/it/java/com.aspose.slides/WorkbookType) per rilevare formati non supportati e saltare quei grafici.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // La cartella di lavoro incorporata è in formato .xlsb, che non è supportato.
            continue;
        }

        // Leggi o modifica i dati della cartella di lavoro del grafico qui.
    }
} finally {
    presentation.dispose();
}
```

## **Cartella di lavoro esterna**

{{% alert color="info" %}} 
In [Aspose.Slides 19.4](https://docs.aspose.com/slides/it/java/aspose-slides-for-java-19-4-release-notes/), abbiamo implementato il supporto per le cartelle di lavoro esterne come origine dati per i grafici.
{{% /alert %}} 

### **Creare una cartella di lavoro esterna**

Utilizzando i metodi **`readWorkbookStream`** e **`setExternalWorkbook`**, è possibile creare una cartella di lavoro esterna da zero o rendere esterna una cartella di lavoro interna.

Questo codice Java dimostra il processo di creazione della cartella di lavoro esterna:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

### **Impostare una cartella di lavoro esterna**

Utilizzando il metodo **`setExternalWorkbook`**, è possibile assegnare una cartella di lavoro esterna a un grafico come sua origine dati. Questo metodo può anche essere usato per aggiornare il percorso della cartella di lavoro esterna (se quest'ultima è stata spostata).

Sebbene non sia possibile modificare i dati in cartelle di lavoro archiviate in posizioni remote o risorse, è ancora possibile utilizzare tali cartelle come origine dati esterna. Se viene fornito un percorso relativo per una cartella di lavoro esterna, questo viene convertito automaticamente in un percorso assoluto.

Questo codice Java mostra come impostare una cartella di lavoro esterna:

```java
import com.aspose.slides.*;

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

Il secondo parametro (`boolean`) del metodo `setExternalWorkbook` specifica se una cartella di lavoro Excel verrà caricata o meno.

* Quando il valore è impostato su `false`, viene aggiornato solo il percorso della cartella di lavoro: i dati del grafico non saranno caricati o aggiornati dalla cartella di lavoro di destinazione. È consigliabile utilizzare questa impostazione quando la cartella di lavoro di destinazione non esiste o non è disponibile. 
* Quando il valore è impostato su `true`, i dati del grafico vengono aggiornati dalla cartella di lavoro di destinazione.

```java
import com.aspose.slides.*;

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

### **Ottenere il percorso della cartella di lavoro di origine dati esterna di un grafico**

1. Creare un'istanza della classe [Presentation](https://apireference.aspose.com/slides/it/java/com.aspose.slides/presentation).
1. Ottenere un riferimento a una diapositiva tramite il suo indice.
1. Creare un oggetto per la forma del grafico.
1. Creare un oggetto per il tipo di origine (`ChartDataSourceType`) che rappresenta l'origine dati del grafico.
1. Specificare la condizione pertinente in base al fatto che il tipo di origine sia lo stesso del tipo di origine dati della cartella di lavoro esterna.

Questo codice Java dimostra l'operazione:

```java
import com.aspose.slides.*;

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

È possibile modificare i dati nelle cartelle di lavoro esterne allo stesso modo in cui si apportano modifiche al contenuto delle cartelle di lavoro interne. Quando una cartella di lavoro esterna non può essere caricata, viene generata un'eccezione.

Questo codice Java è un'implementazione del processo descritto:

```java
import com.aspose.slides.*;

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

### **Recuperare una cartella di lavoro dalla cache del grafico**

Se un grafico utilizza una cartella di lavoro esterna mancante o non disponibile, Aspose.Slides può ricostruire la cartella di lavoro del grafico dai dati memorizzati nella presentazione. Creare [LoadOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/), configurarlo con [SpreadsheetOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/spreadsheetoptions/), e chiamare [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/it/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) con `true` prima di aprire la presentazione.

Il seguente esempio Java apre una presentazione il cui grafico fa riferimento a una cartella di lavoro esterna non disponibile e accede ai dati recuperati tramite [IChart.getChartData](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichart/#getChartData--) e [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Leggi o modifica i dati della cartella di lavoro recuperata qui.
} finally {
    presentation.dispose();
}
```

Se la cartella di lavoro esterna non è disponibile e il recupero è disabilitato, Aspose.Slides genera un'eccezione. Abilitare il recupero solo quando l'utilizzo dei dati del grafico memorizzati nella cache è un'opzione accettabile, poiché la cache potrebbe non contenere le modifiche apportate alla cartella di lavoro esterna dopo l'ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un grafico specifico è collegato a una cartella di lavoro esterna o incorporata?**

Sì. Un grafico dispone di un [data source type](https://reference.aspose.com/slides/it/java/com.aspose.slides/chartdata/#getDataSourceType--) e di un [path to an external workbook](https://reference.aspose.com/slides/it/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); se la sorgente è una cartella di lavoro esterna, è possibile leggere il percorso completo per verificare che venga utilizzato un file esterno.

**Sono supportati percorsi relativi alle cartelle di lavoro esterne e come vengono memorizzati?**

Sì. Se si specifica un percorso relativo, questo viene convertito automaticamente in un percorso assoluto. È comodo per la portabilità del progetto; tuttavia, la presentazione memorizzerà il percorso assoluto nel file PPTX.

**Posso usare cartelle di lavoro situate su risorse di rete/condivisioni?**

Sì, tali cartelle di lavoro possono essere usate come origine dati esterna. Tuttavia, la modifica diretta di cartelle di lavoro remote da Aspose.Slides non è supportata: possono essere solo utilizzate come sorgente.

**Aspose.Slides sovrascrive il file XLSX esterno durante il salvataggio della presentazione?**

No. La presentazione memorizza un [link al file esterno](https://reference.aspose.com/slides/it/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) e lo utilizza per leggere i dati. Il file esterno stesso non viene modificato al salvataggio della presentazione.

** Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password durante il collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio, utilizzando [Aspose.Cells](/cells/java/)) e collegarsi a quella copia.

**Più grafici possono fare riferimento alla stessa cartella di lavoro esterna?**

Sì. Ogni grafico memorizza il proprio collegamento. Se tutti puntano allo stesso file, l'aggiornamento di quel file verrà riflesso in ciascun grafico al successivo caricamento dei dati.