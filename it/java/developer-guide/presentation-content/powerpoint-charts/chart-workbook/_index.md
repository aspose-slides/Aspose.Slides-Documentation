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
description: "Scopri Aspose.Slides per Java: gestisci facilmente le cartelle di lavoro dei grafici nei formati PowerPoint e OpenDocument per semplificare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con le cartelle di lavoro dei grafici in Aspose.Slides. Mostra come leggere e scrivere dati del grafico tramite flussi di cartella di lavoro, utilizzare le celle della cartella di lavoro come etichette dei dati del grafico, accedere alle raccolte di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Copre anche l'utilizzo di cartelle di lavoro esterne come origini dati per i grafici. Gli esempi dimostrano come creare e assegnare una cartella di lavoro esterna, recuperare il percorso di una cartella di lavoro esterna collegata a un grafico e modificare i dati del grafico quando la cartella di lavoro è disponibile.

Per le celle della cartella di lavoro che rappresentano dati mancanti, vedere [Controlla la visualizzazione delle celle vuote](/slides/it/java/chart-series/) per la differenza tra una cella vuota e zero, e un confronto a linee dei vari modi di visualizzazione disponibili.

## **Includere dati da righe e colonne nascoste**

Usa [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) per controllare se un grafico traccia dati da righe e colonne nascoste del foglio di lavoro. Impostalo su `true` per tracciare solo le celle visibili, o su `false` per includere sia le celle visibili che quelle nascoste. Questa impostazione controlla il tracciamento del grafico; non nasconde né mostra righe o colonne del foglio di lavoro.

La [presentazione di esempio](hidden-source-data.pptx) contiene un grafico a colonne come prima forma nella prima diapositiva. Il foglio di lavoro incorporato, `Sheet1`, contiene l’intervallo di origine `A1:C4`. La riga 3 e la colonna C sono nascoste, ma le loro celle contengono ancora valori.

| Riga del foglio di lavoro | A: Mese | B: Vendita al dettaglio | C: All'ingrosso (colonna nascosta) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (riga nascosta) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Accedi alle celle di origine tramite [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) e leggi [IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) per verificare lo stato di nascondimento. Questo metodo restituisce lo stato senza modificarlo. In questo file, B2 è visibile, B3 appartiene alla riga nascosta e C2 appartiene alla colonna nascosta; l’esempio stampa `false`, `true` e `true`, rispettivamente.

Per questo esempio, aggiorna i dati del grafico dopo aver modificato l’impostazione di tracciamento: mantieni la cartella di lavoro incorporata con [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) e ricaricala con [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---). Quando si includono tutte le celle, usa anche [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) per ripristinare l’intervallo completo, inclusa la categoria di febbraio nascosta. Cambiare semplicemente il flag non è sufficiente a aggiornare i dati del grafico e le etichette delle categorie nella cache di questo esempio.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hidden-source-data.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        System.out.println("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        System.out.println("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        System.out.println("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        byte[] workbookData = chart.getChartData().readWorkbookStream();
        for (boolean visibleOnly : new boolean[] { true, false }) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Aggiorna i dati del grafico dalla cartella di lavoro incorporata.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Ripristina l'intero intervallo di origine, incluse le categorie nascoste.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", SaveFormat.Pptx);
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

L’esempio salva due versioni della presentazione: una con solo i valori di vendita al dettaglio visibili (10 e 20) e un’altra con tutti e sei i valori. Le immagini sotto illustrano le due modalità di tracciamento. La riga 3 e la colonna C rimangono nascoste in entrambe le cartelle di lavoro incorporate.

| Solo celle visibili (`true`) | Tutte le celle (`false`) |
| --- | --- |
| ![Solo celle visibili: valori Retail 10 e 20 per January e March.](hidden_cells_True.png) | ![Tutte le celle: valori Retail e Wholesale per January, February e March.](hidden_cells_False.png) |

Una cella nascosta contenente un valore è diversa da una cella vuota. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) controlla come vengono visualizzati i valori mancanti; non include né esclude dati di origine nascosti. Vedi [Controlla la visualizzazione delle celle vuote](/slides/it/java/chart-series/#control-the-display-of-empty-cells) per un esempio.

## **Recuperare l’intervallo di dati di un grafico**

Prima di aggiornare i dati della cartella di lavoro in una presentazione esistente, ispeziona gli intervalli di origine per identificare quali celle del foglio di lavoro usa ciascun grafico. Il metodo [IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) restituisce l’intervallo di dati corrente come formula qualificata per foglio di lavoro, ad esempio `Sheet1!$A$1:$D$5`. Qui, `Sheet1` è il nome del foglio, `!` lo separa dall’intervallo di celle e `$A$1:$D$5` identifica le celle da A1 a D5, inclusa. I simboli `$` indicano riferimenti assoluti di riga e colonna.

Il metodo legge l’intervallo corrente senza modificare il grafico o la sua cartella di lavoro. Se il grafico non utilizza una cartella di lavoro come origine dati, genera `InvalidOperationException`. Per ulteriori informazioni, vedere il [riferimento API ChartData](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/).

Questo esempio apre una presentazione e controlla le forme direttamente su ogni diapositiva alla ricerca di grafici. Stampa il nome di ciascun grafico e il suo intervallo di origine. Se un grafico non usa una cartella di lavoro, stampa un messaggio e passa al grafico successivo.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.InvalidOperationException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                try {
                    String range = chart.getChartData().getRange();
                    System.out.println(chart.getName() + ": " + range);
                } catch (InvalidOperationException exception) {
                    System.out.println(chart.getName() + ": The chart does not use a workbook as its data source.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Leggere e scrivere dati del grafico da una cartella di lavoro**

Aspose.Slides for Java fornisce i metodi [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) e [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) che consentono di leggere e scrivere le cartelle di lavoro dei grafici (contenenti dati del grafico modificati con Aspose.Cells). **Nota** che i dati del grafico devono essere organizzati nello stesso modo o avere una struttura simile a quella di origine.

Questo esempio usa una presentazione con un grafico come prima forma nella prima diapositiva. Legge la cartella di lavoro incorporata in un array di byte, cancella le serie e le categorie esistenti, e scrive nuovamente la stessa cartella di lavoro. Le modifiche rimangono in memoria; l’esempio non salva la presentazione.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Convalidare il layout del grafico dopo la modifica della cartella di lavoro**

Quando si sostituisce una cartella di lavoro incorporata con una modificata, il grafico mantiene le collezioni di serie e categorie originali. Questa discrepanza può far fallire [IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) con un errore “index‑out‑of‑range”. Cancella le serie e le categorie esistenti prima di scrivere la cartella di lavoro aggiornata nel grafico. Questo esempio usa un grafico che è la prima forma nella prima diapositiva. Il commento indica dove avverrebbe la modifica della cartella di lavoro; l’esempio eseguibile scrive la cartella di lavoro originale e convalida il layout in memoria.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        // Modifica i byte della cartella di lavoro qui, ad esempio, usando Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

La cancellazione delle collezioni rimuove i riferimenti a dati obsoleti prima che la cartella di lavoro venga riscritta. Ricostruisci eventuali mappe di serie e categorie necessarie per la nuova cartella di lavoro prima di utilizzare il grafico.

## **Impostare formati numerici personalizzati per le celle della cartella di lavoro**

Usa [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) per controllare come i valori numerici appaiono nella cartella di lavoro incorporata del grafico. Ad esempio, un report potrebbe richiedere un tasso di conversione visualizzato come percentuale con quattro decimali e un coefficiente visualizzato con cinque decimali. Mantieni entrambi i valori numerici in modo che rimangano disponibili per i calcoli e il tracciamento del grafico.

Un formato numerico modifica la visualizzazione, non il valore memorizzato. Il formato `0.0000%` visualizza `0.125` come `12.5000%`; non sostituisce il numero memorizzato con `12.5`. Allo stesso modo, `0.00000` visualizza `0.1234567` come `0.12346` senza arrotondare il valore memorizzato. Se il formato personalizzato è una stringa vuota (`""`), viene usato il formato restituito da [getPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--).

L’esempio seguente crea un grafico a colonne e accede alle sue celle tramite [getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--). Nel foglio 0, B2 contiene il tasso di conversione e C2 contiene il coefficiente. Entrambe le celle forniscono valori al grafico. L’esempio attiva anche le etichette dei valori collegate ai formati di origine.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    IChartDataCell percentageName = workbook.getCell(0, "B1", "Conversion rate");
    IChartSeries percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    IChartDataCell precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    IChartDataCell precisionName = workbook.getCell(0, "C1", "Coefficient");
    IChartSeries precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

I formati delle celle della cartella di lavoro sono separati dai formati impostati direttamente sugli assi del grafico o sulle etichette dei dati. In questo esempio, ogni etichetta visualizza il valore della cella di origine perché [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) è impostato su `true`, e segue il formato numerico di origine perché [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) è impostato su `true`. Dopo aver salvato e riaperto la presentazione, le etichette mostrano `12.5000%` e `0.12346`, come mostrato sotto. L’asse verticale usa il proprio formato numerico, assegnato con [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) impostato a `0.00`, con [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) impostato su `false`.

Per formattare un’etichetta dei dati in modo indipendente, imposta il suo flag di collegamento alla sorgente su `false` e assegna un formato con [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-). Questo non cambia il formato della cella della cartella di lavoro. Per esempio, un formato indipendente `0.00` visualizza il primo valore come `0.13`, mentre B2 continua a visualizzare `12.5000%`. Vedi [Etichette dati del grafico](/slides/it/java/chart-data-label/#set-percentage-sign-with-chart-data-labels) per la formattazione diretta delle etichette.

L’immagine sottostante è stata renderizzata dalla presentazione salvata dopo la riapertura:

![Grafico a colonne con etichette collegate alla sorgente che mostrano 12.5000% e 0.12346 e un asse numerico formattato in modo indipendente.](custom-cell-formats.png)

## **Impostare una cella della cartella di lavoro come etichetta dei dati del grafico**

È possibile usare il testo delle celle della cartella di lavoro come etichette dei dati del grafico.

Questo esempio aggiunge un grafico a bolle con dati predefiniti alla prima diapositiva di una presentazione esistente. Usa le celle A10:A12 sul foglio 0 per le prime tre etichette della prima serie, abilita le etichette dalle celle e salva la presentazione aggiornata.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gestire i fogli di lavoro**

Il metodo [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) consente di accedere ai fogli di lavoro in una cartella di lavoro del grafico. Questo esempio crea un grafico a torta con dati predefiniti e stampa il nome di ogni foglio di lavoro nella console.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    for (int i = 0; i < workbook.getWorksheets().size(); i++) {
        System.out.println(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Specificare il tipo di origine dati**

I valori dei punti della serie possono anche essere memorizzati direttamente come letterali numerici. Vedi [Imposta valori della serie usando letterali numerici](/slides/it/java/chart-series/#set-series-values-using-numeric-literals) per un esempio completo che li salva e li legge. Il tipo di origine dei valori dei punti è separato dalla configurazione interna o esterna della cartella di lavoro del grafico; l’uso di letterali numerici non rimuove, di per sé, la cartella di lavoro incorporata.

Questo esempio crea un grafico a colonne 3D con dati predefiniti e imposta due nomi di serie usando origini dati diverse. Il primo nome usa un letterale stringa; il secondo usa la cella C1 sul foglio 0. L’enumerazione [DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) seleziona l’origine per ciascun nome. L’esempio salva la presentazione con i nomi di serie aggiornati.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    IStringChartValue cellName = chart.getChartData().getSeries().get_Item(1).getName();
    IChartDataCell nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rilevare formati di cartella di lavoro incorporati non supportati**

Aspose.Slides non supporta il formato di cartella di lavoro binario Excel (.xlsb) che può essere incorporato in alcuni grafici. Puoi usare il metodo [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) su [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) insieme all’enumerazione [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) per rilevare formati non supportati e saltare quei grafici. Questo esempio ispeziona le forme nella prima diapositiva di una presentazione esistente, ignora le forme non grafico e stampa un messaggio diagnostico per ogni grafico con una cartella di lavoro .xlsb incorporata.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IChartData chartData = chart.getChartData();
        boolean isInternalWorkbook = chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook;
        boolean isBinaryMacro = chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            System.out.println("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Leggi o modifica i dati della cartella di lavoro del grafico supportati qui.
    }
} finally {
    presentation.dispose();
}
```

## **Cartella di lavoro esterna**

Aspose.Slides supporta l’utilizzo di cartelle di lavoro esterne come origine dati per i grafici.

### **Creare una cartella di lavoro esterna**

Usa [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) e [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) per esportare una cartella di lavoro di un grafico incorporata in un file e collegare il grafico a quella cartella di lavoro esterna.

Questo esempio crea un grafico a torta con dati predefiniti ed esporta la sua cartella di lavoro. Completa la scrittura del file prima di assegnare la cartella di lavoro esterna come origine dei dati del grafico, quindi salva la presentazione collegata.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    Path workbookPath = Paths.get("externalWorkbook1.xlsx").toAbsolutePath();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        Files.write(workbookPath, workbookData);
        chart.getChartData().setExternalWorkbook(workbookPath.toString());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Impostare una cartella di lavoro esterna**

Utilizzando il metodo [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-), puoi assegnare una cartella di lavoro esterna a un grafico come sua origine dati. Questo metodo può anche essere usato per aggiornare il percorso della cartella di lavoro esterna (se quest’ultima è stata spostata).

Sebbene non sia possibile modificare i dati in cartelle di lavoro memorizzate in posizioni remote o risorse, è comunque possibile usarle come origine dati esterna. Se viene fornito un percorso relativo per una cartella di lavoro esterna, viene convertito automaticamente in un percorso assoluto.

Questo esempio utilizza una cartella di lavoro esterna il cui foglio denominato `Sheet1` contiene un nome di serie in B1, nomi di categoria in A2:A4 e valori numerici in B2:B4. L’esempio crea un grafico a torta, collega la cartella di lavoro e usa [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) per mappare A1:B4 a una serie e tre categorie. Salva la presentazione con il grafico collegato.

```java
import com.aspose.slides.*;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    String workbookPath = Paths.get("externalWorkbook.xlsx").toAbsolutePath().toString();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il parametro `updateChartData` di [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) controlla se la cartella di lavoro viene caricata.

* Quando `updateChartData` è `false`, viene aggiornato solo il percorso della cartella di lavoro. I dati del grafico non sono caricati né aggiornati dalla cartella di lavoro di destinazione, quindi la cartella di lavoro può essere non disponibile.
* Quando `updateChartData` è `true`, i dati del grafico sono aggiornati dalla cartella di lavoro di destinazione.

L’esempio seguente assegna un URL segnaposto con `updateChartData` impostato su `false`. Mantiene i dati predefiniti del grafico a torta e salva la presentazione senza caricare la cartella di lavoro non disponibile.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ottenere il percorso della cartella di lavoro esterna di un grafico**

Per identificare la cartella di lavoro collegata a un grafico, verifica se il grafico utilizza un’origine dati esterna e recupera il suo percorso.

Questo esempio ispeziona la prima forma nella prima diapositiva di una presentazione con una cartella di lavoro esterna collegata. Se è un grafico collegato a una cartella di lavoro esterna, stampa [getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) nella console. Successivamente salva una copia della presentazione.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("externalWorkbook.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        if (chartData.getDataSourceType() == ChartDataSourceType.ExternalWorkbook) {
            System.out.println(chartData.getExternalWorkbookPath());
        } else {
            System.out.println("The chart does not use an external workbook.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Modificare i dati del grafico**

Puoi modificare i dati nelle cartelle di lavoro esterne allo stesso modo in cui modifichi il contenuto delle cartelle di lavoro interne. Quando una cartella di lavoro esterna non può essere caricata, viene generata un’eccezione.

Questo esempio usa un grafico che è la prima forma nella prima diapositiva e collegato a una cartella di lavoro esterna accessibile. Imposta il valore basato su cella del primo punto dati della prima serie a 100 e salva la presentazione aggiornata. Modificare i valori delle celle può aggiornare il file XLSX esterno collegato, quindi usa una copia se devi conservare la cartella di lavoro originale.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartSeriesCollection series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            IChartDataCell valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", SaveFormat.Pptx);
            } else {
                System.out.println("The first data point is not linked to a workbook cell.");
            }
        } else {
            System.out.println("The chart has no data points to edit.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Recuperare una cartella di lavoro dalla cache del grafico**

Se un grafico utilizza una cartella di lavoro esterna mancante o non disponibile, Aspose.Slides può ricostruire la cartella di lavoro del grafico dai dati memorizzati nella presentazione. Crea [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/), chiama [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), e imposta [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) su `true` prima di aprire la presentazione.

Il seguente esempio Java recupera i dati della cartella di lavoro per un grafico che è la prima forma nella prima diapositiva e fa riferimento a una cartella di lavoro esterna non disponibile. Accede ai dati recuperati tramite [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) e [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Leggi o modifica i dati della cartella di lavoro recuperata qui.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Se la cartella di lavoro esterna è non disponibile e il recupero è disabilitato, Aspose.Slides genera un’eccezione. Abilita il recupero solo quando l’uso dei dati del grafico in cache è un’opzione accettabile, perché la cache potrebbe non contenere le modifiche apportate alla cartella di lavoro esterna dopo l’ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un grafico specifico è collegato a una cartella di lavoro esterna o incorporata?**

Sì. Un grafico ha un [tipo di origine dati](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) e un [percorso a una cartella di lavoro esterna](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); se l’origine è una cartella di lavoro esterna, puoi leggere il percorso completo per assicurarti che venga usato un file esterno.

**Sono supportati i percorsi relativi alle cartelle di lavoro esterne e come vengono memorizzati?**

Sì. Se specifichi un percorso relativo, viene convertito automaticamente in un percorso assoluto. La presentazione memorizza il percorso assoluto nel file PPTX, quindi spostare la cartella di lavoro potrebbe richiedere l’aggiornamento del collegamento.

**Posso usare cartelle di lavoro situate su risorse o condivisioni di rete?**

Sì, tali cartelle di lavoro possono essere usate come origine dati esterna. Tuttavia, la modifica diretta di cartelle di lavoro remote da Aspose.Slides non è supportata; possono solo essere usate come fonte.

**Aspose.Slides sovrascrive l’XLSX esterno quando salva la presentazione?**

La presentazione memorizza un [collegamento al file esterno](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Modificare i dati del grafico basati su cella può anche aggiornare il file XLSX locale collegato. Usa una copia della cartella di lavoro se l’originale deve rimanere invariato.

**Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password quando crea il collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio, usando [Aspose.Cells](https://reference.aspose.com/cells/java/)) e collegare a quella copia.

**Più grafici possono fare riferimento alla stessa cartella di lavoro esterna?**

Sì. Ogni grafico memorizza il proprio collegamento. Se tutti puntano allo stesso file, l’aggiornamento di quel file sarà riflesso in ciascun grafico al successivo caricamento dei dati.