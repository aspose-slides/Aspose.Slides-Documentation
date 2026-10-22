---
title: Gestire i workbook dei grafici nelle presentazioni su Android
linktitle: Workbook del grafico
type: docs
weight: 70
url: /it/androidjava/chart-workbook/
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
- Android
- Java
- Aspose.Slides
description: "Scopri Aspose.Slides per Android via Java: gestisci facilmente i workbook dei grafici nei formati PowerPoint e OpenDocument per ottimizzare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con i workbook dei grafici in Aspose.Slides. Mostra come leggere e scrivere i dati del grafico tramite stream dei workbook, usare le celle del workbook come etichette dei dati del grafico, accedere alle raccolte di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Tratta anche dell'uso di workbook esterni come fonti di dati per i grafici. Gli esempi dimostrano come creare e assegnare un workbook esterno, recuperare il percorso di un workbook esterno collegato a un grafico e modificare i dati del grafico quando il workbook è disponibile.

Per le celle del workbook che rappresentano dati mancanti, vedere [Controllare la visualizzazione delle celle vuote](/slides/it/androidjava/chart-series/) per la differenza tra una cella vuota e zero, e un confronto a linee dei relativi modi di visualizzazione disponibili.

## **Includere dati da righe e colonne nascoste**

Utilizza [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) per controllare se un grafico traccia dati da righe e colonne di foglio di lavoro nascoste. Impostalo su `true` per tracciare solo le celle visibili, o su `false` per includere sia le celle visibili che quelle nascoste. Questa impostazione controlla il tracciamento del grafico; non nasconde né mostra righe o colonne del foglio di lavoro.

La [presentazione di esempio](hidden-source-data.pptx) contiene un grafico a colonne come prima forma nella prima diapositiva. Il foglio di lavoro incorporato, `Sheet1`, contiene l’intervallo di origine `A1:C4`. La riga 3 e la colonna C sono nascoste, ma le loro celle contengono ancora valori.

| Riga foglio | A: Mese | B: Vendita al dettaglio | C: Vendita all'ingrosso (colonna nascosta) |
| --- | --- | --- | --- |
| 2 | Gennaio | 10 | 30 |
| 3 (riga nascosta) | Febbraio | 40 | 60 |
| 4 | Marzo | 20 | 50 |

Accedi alle celle di origine tramite [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) e leggi [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) per ispezionare il loro stato di nascondimento. Questo metodo segnala lo stato di nascondimento senza modificarlo. In questo file, B2 è visibile, B3 appartiene alla riga nascosta e C2 appartiene alla colonna nascosta; l’esempio stampa `false`, `true` e `true`, rispettivamente.

Per questo esempio, aggiorna i dati del grafico dopo aver modificato l’impostazione di tracciamento: mantieni il workbook incorporato con [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) e ricaricalo con [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---). Quando includi tutte le celle, usa anche [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) per ripristinare l’intervallo completo, inclusa la categoria di febbraio nascosta. Cambiare semplicemente il flag non è sufficiente per aggiornare i dati della cache del grafico e le etichette delle categorie in questo esempio.

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

            // Aggiorna i dati del grafico dal workbook incorporato.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Ripristina l'intervallo di origine completo, incluse le categorie nascoste.
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

L’esempio salva due versioni della presentazione: una con solo i valori di Vendita al dettaglio visibili (10 e 20) e un’altra con tutti e sei i valori. Le immagini sotto illustrano i due modi di tracciamento. La riga 3 e la colonna C rimangono nascoste in entrambi i workbook incorporati.

| Solo celle visibili (`true`) | Tutte le celle (`false`) |
| --- | --- |
| ![Solo celle visibili: valori di Vendita al dettaglio 10 e 20 per Gennaio e Marzo.](hidden_cells_True.png) | ![Tutte le celle: valori di Vendita al dettaglio e Vendita all'ingrosso per Gennaio, Febbraio e Marzo.](hidden_cells_False.png) |

Una cella nascosta contenente un valore è diversa da una cella vuota. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) controlla come vengono visualizzati i valori mancanti; non include né esclude i dati di origine nascosti. Vedi [Controllare la visualizzazione delle celle vuote](/slides/it/androidjava/chart-series/#control-the-display-of-empty-cells) per un esempio.

## **Recuperare l'intervallo dati di un grafico**

Prima di aggiornare i dati del workbook in una presentazione esistente, ispeziona gli intervalli di origine per identificare quali celle di foglio di lavoro usa ogni grafico. Il metodo [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) restituisce l’intervallo dati corrente come formula qualificata dal foglio, ad es. `Sheet1!$A$1:$D$5`. Qui, `Sheet1` è il nome del foglio, `!` lo separa dall’intervallo di celle e `$A$1:$D$5` identifica le celle da A1 a D5, inclusi. I segni di dollaro indicano riferimenti assoluti di riga e colonna.

Il metodo legge l’intervallo corrente senza modificare il grafico o il suo workbook. Se il grafico non usa un workbook come origine dati, lancia `InvalidOperationException`. Per ulteriori informazioni, vedere il [Riferimento API ChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/).

Questo esempio apre una presentazione e controlla le forme direttamente su ciascuna diapositiva per individuare i grafici. Stampa il nome di ogni grafico e il suo intervallo di origine. Se un grafico non usa un workbook, stampa un messaggio e passa al grafico successivo.

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

## **Leggere e scrivere dati del grafico da un workbook**

Aspose.Slides for Android via Java fornisce i metodi [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) e [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) che consentono di leggere e scrivere i workbook dei dati del grafico (contenenti dati del grafico modificati con Aspose.Cells). **Nota** che i dati del grafico devono essere organizzati nello stesso modo o avere una struttura simile all’origine.

Questo esempio usa una presentazione con un grafico come prima forma nella prima diapositiva. Legge il workbook incorporato in un array di byte, cancella le serie e le categorie esistenti e riscrive lo stesso workbook. Le modifiche rimangono in memoria; l’esempio non salva la presentazione.

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

### **Convalidare il layout del grafico dopo la modifica del workbook**

Quando sostituisci un workbook incorporato con uno modificato, il grafico mantiene le raccolte originali di serie e categorie. Questa discrepanza può far fallire [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) con un errore di indice fuori intervallo. Cancella le serie e le categorie esistenti prima di scrivere nuovamente il workbook aggiornato nel grafico. Questo esempio usa un grafico che è la prima forma nella prima diapositiva. Il commento indica dove avverrebbe la modifica del workbook; l’esempio eseguibile riscrive il workbook originale e convalida il layout in memoria.

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

        // Modifica i byte del workbook qui, ad esempio usando Aspose.Cells.

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

La cancellazione delle raccolte rimuove i riferimenti a dati obsoleti prima che il workbook venga riscritto. Ricostruisci eventuali mappature di serie e categorie necessarie per il workbook aggiornato prima di utilizzare il grafico.

## **Impostare formati numerici personalizzati per le celle del workbook**

Usa [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) per controllare come compaiono i valori numerici nel workbook incorporato di un grafico. Per esempio, un report può richiedere di visualizzare un tasso di conversione come percentuale con quattro decimali e un coefficiente con cinque decimali. Mantieni entrambi i valori numerici in modo che rimangano disponibili per i calcoli e il tracciamento del grafico.

Un formato numerico modifica la visualizzazione, non il valore memorizzato. Il formato `0.0000%` visualizza `0.125` come `12.5000%`; non sostituisce il numero memorizzato con `12.5`. Analogamente, `0.00000` visualizza `0.1234567` come `0.12346` senza arrotondare il valore memorizzato. Se il formato personalizzato è una stringa vuota (`""`), viene usato il formato restituito da [getPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--).

L’esempio seguente crea un grafico a colonne e accede alle sue celle tramite [getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--). Nel foglio 0, B2 contiene il tasso di conversione e C2 contiene il coefficiente. Entrambe le celle forniscono valori al grafico. L’esempio abilita anche le etichette dei valori collegate ai formati di origine.

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

I formati delle celle del workbook sono separati dai formati impostati direttamente sugli assi del grafico o sulle etichette dei dati. In questo esempio, ogni etichetta visualizza il valore della propria cella di origine perché [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) è impostato su `true`, e segue il formato di origine perché [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) è impostato su `true`. Dopo aver salvato e riaperto la presentazione, le etichette mostrano `12.5000%` e `0.12346`, come mostrato sotto. L’asse verticale utilizza un proprio formato numerico, assegnato con [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) come `0.00`, con [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) impostato su `false`.

Per formattare in modo indipendente un’etichetta di dati, imposta il suo flag di collegamento alla fonte su `false` e assegna un formato con [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-). Questo non modifica il formato della cella del workbook. Per esempio, un formato di etichetta indipendente `0.00` visualizza il primo valore come `0.13`, mentre B2 continua a mostrare `12.5000%`. Vedi [Etichette dati del grafico](/slides/it/androidjava/chart-data-label/#set-the-percentage-sign-with-chart-data-labels) per la formattazione diretta delle etichette.

L’immagine sotto è stata resa dalla presentazione salvata dopo averla riaperta:

![Grafico a colonne con etichette collegate alla fonte che mostrano 12.5000% e 0.12346 e un asse numerico formattato in modo indipendente.](custom-cell-formats.png)

## **Impostare una cella del workbook come etichetta dati del grafico**

Puoi usare il testo delle celle del workbook come etichette dati del grafico.

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

Il metodo [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) fornisce l’accesso ai fogli di lavoro in un workbook di grafico. Questo esempio crea un grafico a torta con dati predefiniti e stampa il nome di ciascun foglio di lavoro nella console.

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

I valori dei punti della serie possono anche essere memorizzati direttamente come letterali numerici. Vedi [Impostare i valori della serie utilizzando letterali numerici](/slides/it/androidjava/chart-series/#set-series-values-using-numeric-literals) per un esempio completo che li salva e li legge. Il tipo di origine dei valori dei punti è separato dalla configurazione interna o esterna del workbook del grafico; l’uso di letterali numerici non rimuove, di per sé, il workbook incorporato.

Questo esempio crea un grafico a colonne 3D con dati predefiniti e imposta due nomi di serie usando diverse origini dati. Il primo nome usa un letterale stringa; il secondo usa la cella C1 sul foglio 0. L’enumerazione [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) seleziona l’origine per ciascun nome. L’esempio salva la presentazione con i nomi delle serie aggiornati.

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

## **Rilevare formati di workbook incorporati non supportati**

Aspose.Slides non supporta il formato workbook Excel binario (.xlsb) che può essere incorporato in alcuni grafici. Puoi usare il metodo [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) su [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) insieme all’enumerazione [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) per individuare formati non supportati e saltare quei grafici. Questo esempio ispeziona le forme nella prima diapositiva di una presentazione esistente, ignora le forme non grafiche e stampa un messaggio diagnostico per ciascun grafico con un workbook .xlsb incorporato.

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

        // Leggi o modifica i dati del workbook del grafico supportati qui.
    }
} finally {
    presentation.dispose();
}
```

## **Workbook esterno**

Aspose.Slides supporta l’utilizzo di workbook esterni come fonte di dati per i grafici.

### **Creare un workbook esterno**

Usa [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) e [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) per esportare un workbook di grafico incorporato in un file e collegare il grafico a quel workbook esterno.

Questo esempio crea un grafico a torta con dati predefiniti ed esporta il suo workbook. Completa la scrittura del file prima di assegnare il workbook esterno come origine dati del grafico, quindi salva la presentazione collegata.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    File workbookFile = new File("externalWorkbook1.xlsx").getAbsoluteFile();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        try (FileOutputStream workbookStream = new FileOutputStream(workbookFile)) {
            workbookStream.write(workbookData);
        }
        chart.getChartData().setExternalWorkbook(workbookFile.getAbsolutePath());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Impostare un workbook esterno**

Utilizzando il metodo [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-), puoi assegnare un workbook esterno a un grafico come sua origine dati. Questo metodo può anche essere usato per aggiornare il percorso al workbook esterno (se quest’ultimo è stato spostato).

Sebbene non sia possibile modificare i dati nei workbook memorizzati in posizioni remote o risorse, è comunque possibile usarli come fonte di dati esterna. Se viene fornito un percorso relativo per un workbook esterno, viene convertito automaticamente in un percorso assoluto.

Questo esempio utilizza un workbook esterno il cui foglio chiamato `Sheet1` contiene un nome di serie in B1, nomi di categoria in A2:A4 e valori numerici in B2:B4. L’esempio crea un grafico a torta, collega il workbook e usa [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) per mappare A1:B4 a una serie e tre categorie. Salva la presentazione con il grafico collegato.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    File workbookFile = new File("externalWorkbook.xlsx");
    String workbookPath = workbookFile.getAbsolutePath();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il parametro `updateChartData` di [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) controlla se il workbook viene caricato.

* Quando `updateChartData` è `false`, viene aggiornato solo il percorso del workbook. I dati del grafico non vengono caricati né aggiornati dal workbook di destinazione, quindi il workbook può essere non disponibile.  
* Quando `updateChartData` è `true`, i dati del grafico vengono aggiornati dal workbook di destinazione.

L’esempio seguente assegna un URL segnaposto con `updateChartData` impostato su `false`. Mantiene i dati predefiniti del grafico a torta e salva la presentazione senza caricare il workbook non disponibile.

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

### **Ottenere il percorso del workbook di origine dati esterno di un grafico**

Per identificare il workbook collegato a un grafico, verifica se il grafico utilizza una fonte dati esterna e recupera il suo percorso.

Questo esempio ispeziona la prima forma nella prima diapositiva di una presentazione con un workbook esterno collegato. Se è un grafico collegato a un workbook esterno, stampa [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) nella console. Poi salva una copia della presentazione.

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

Puoi modificare i dati nei workbook esterni allo stesso modo in cui apporti modifiche al contenuto dei workbook interni. Quando un workbook esterno non può essere caricato, viene lanciata un’eccezione.

Questo esempio utilizza un grafico che è la prima forma nella prima diapositiva e collegato a un workbook esterno accessibile. Imposta il valore basato su cella del primo punto dati della prima serie a 100 e salva la presentazione aggiornata. La modifica dei valori delle celle può aggiornare il file XLSX esterno collegato, quindi usa una copia se devi preservare il workbook originale.

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

### **Recuperare un workbook dalla cache del grafico**

Se un grafico utilizza un workbook esterno mancante o non disponibile, Aspose.Slides può ricostruire il workbook del grafico dai dati memorizzati nella cache della presentazione. Crea [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/), chiama [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), e imposta [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) su `true` prima di aprire la presentazione.

Il seguente esempio Java recupera i dati del workbook per un grafico che è la prima forma nella prima diapositiva e fa riferimento a un workbook esterno non disponibile. Accede ai dati recuperati tramite [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) e [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

        // Leggi o modifica i dati del workbook recuperato qui.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Se il workbook esterno non è disponibile e il recupero è disabilitato, Aspose.Slides lancia un’eccezione. Abilita il recupero solo quando l’uso dei dati della cache del grafico è un’alternativa accettabile, poiché la cache potrebbe non contenere le modifiche apportate al workbook esterno dopo l’ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un grafico specifico è collegato a un workbook esterno o incorporato?**

Sì. Un grafico ha un [tipo di origine dati](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) e un [percorso a un workbook esterno](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); se l’origine è un workbook esterno, puoi leggere il percorso completo per verificare che sia stato usato un file esterno.

**Sono supportati i percorsi relativi ai workbook esterni e come vengono memorizzati?**

Sì. Se specifichi un percorso relativo, questo viene automaticamente convertito in un percorso assoluto. La presentazione memorizza il percorso assoluto nel file PPTX, quindi spostare il workbook potrebbe richiedere l’aggiornamento del collegamento.

**Posso usare workbook situati su risorse di rete/condivisioni?**

Sì, tali workbook possono essere usati come fonte di dati esterna. Tuttavia, la modifica diretta di workbook remoti da Aspose.Slides non è supportata—possono essere usati solo come fonte.

**Aspose.Slides sovrascrive l’XLSX esterno quando salva la presentazione?**

La presentazione memorizza un [collegamento al file esterno](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Modificare i dati del grafico basati su cella può anche aggiornare il file XLSX locale collegato. Usa una copia del workbook se l’originale deve rimanere invariato.

** Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password durante il collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio, usando [Aspose.Cells](https://reference.aspose.com/cells/java/)) e collegarsi a quella copia.

**Possono più grafici fare riferimento allo stesso workbook esterno?**

Sì. Ogni grafico memorizza il proprio collegamento. Se tutti puntano allo stesso file, l’aggiornamento di quel file sarà riflesso in ciascun grafico al successivo caricamento dei dati.