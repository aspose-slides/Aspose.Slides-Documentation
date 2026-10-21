---
title: Gestire le cartelle di lavoro dei grafici nelle presentazioni usando Python via Java
linktitle: Cartella di lavoro del grafico
type: docs
weight: 70
url: /it/python-java/chart-workbook/
keywords:
- cartella di lavoro del grafico
- dati del grafico
- cella della cartella di lavoro
- etichetta dei dati
- foglio di lavoro
- origine dati
- cartella di lavoro esterna
- dati esterni
- cache del grafico
- recupero della cartella di lavoro
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri Aspose.Slides per Python via Java: gestisci facilmente le cartelle di lavoro dei grafici in PowerPoint e nei formati OpenDocument per ottimizzare i dati delle tue presentazioni."
---
## **Panoramica**

Questo articolo spiega come lavorare con le cartelle di lavoro dei grafici in Aspose.Slides. Mostra come leggere e scrivere dati del grafico tramite flussi di cartelle di lavoro, usare le celle della cartella di lavoro come etichette di dati del grafico, accedere alle raccolte di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Copre anche l'utilizzo di cartelle di lavoro esterne come origini dati per i grafici. Gli esempi dimostrano come creare e assegnare una cartella di lavoro esterna, recuperare il percorso di una cartella di lavoro esterna collegata a un grafico e modificare i dati del grafico quando la cartella di lavoro è disponibile.

Per le celle della cartella di lavoro che rappresentano dati mancanti, vedere [Controllare la visualizzazione delle celle vuote](/slides/it/python-java/chart-series/) per la differenza tra una cella vuota e zero, e un confronto a linee dei vari modi di visualizzazione disponibili.

## **Includere dati da righe e colonne nascoste**

Usa [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) per controllare se un grafico traccia dati provenienti da righe e colonne nascoste del foglio di lavoro. Impostalo su `True` per tracciare solo le celle visibili, oppure su `False` per includere sia le celle visibili sia quelle nascoste. Questa impostazione controlla il tracciamento del grafico; non nasconde né mostra righe o colonne del foglio di lavoro.

La [presentazione di esempio](hidden-source-data.pptx) contiene un grafico a colonne come prima forma nella prima diapositiva. Il foglio di lavoro incorporato, `Sheet1`, contiene l’intervallo sorgente `A1:C4`. La riga 3 e la colonna C sono nascoste, ma le loro celle contengono ancora valori.

| Riga del foglio | A: Mese | B: Vendita al dettaglio | C: Vendita all'ingrosso (colonna nascosta) |
| --- | --- | --- | --- |
| 2 | Gennaio | 10 | 30 |
| 3 (riga nascosta) | Febbraio | 40 | 60 |
| 4 | Marzo | 20 | 50 |

Accedi alle celle sorgente tramite [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) e leggi [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) per verificare lo stato di visibilità. Questo metodo restituisce lo stato nascosto senza modificarlo. In questo file, B2 è visibile, B3 appartiene alla riga nascosta e C2 appartiene alla colonna nascosta; l’esempio stampa `False`, `True` e `True`, rispettivamente.

Per questo esempio, aggiorna i dati del grafico dopo aver cambiato l’impostazione di tracciamento: mantieni la cartella di lavoro incorporata con [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) e ricaricala con [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream). Quando si includono tutte le celle, usa anche [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) per ripristinare l’intervallo completo, includendo la categoria di febbraio nascosta. Cambiare semplicemente il flag non è sufficiente a aggiornare i dati del grafico memorizzati nella cache e le etichette di categoria di questo esempio.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("hidden-source-data.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        workbook = chart.getChartData().getChartDataWorkbook()
        print("B2 hidden:", workbook.getCell(0, "B2").isHidden())
        print("B3 hidden:", workbook.getCell(0, "B3").isHidden())
        print("C2 hidden:", workbook.getCell(0, "C2").isHidden())

        workbook_data = chart.getChartData().readWorkbookStream()
        for visible_only in (True, False):
            chart.setPlotVisibleCellsOnly(visible_only)

            # Aggiorna i dati del grafico dalla cartella di lavoro incorporata.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # Ripristina l'intervallo di origine completo, incluse le categorie nascoste.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

L’esempio salva due versioni della presentazione: una con solo i valori di vendita al dettaglio visibili (10 e 20) e un’altra con tutti e sei i valori. Le immagini sotto illustrano i due modi di tracciamento. La riga 3 e la colonna C rimangono nascoste in entrambe le cartelle di lavoro incorporate.

| Solo celle visibili (`True`) | Tutte le celle (`False`) |
| --- | --- |
| ![Solo celle visibili: valori di vendita al dettaglio 10 e 20 per Gennaio e Marzo.](hidden_cells_True.png) | ![Tutte le celle: valori di vendita al dettaglio e all'ingrosso per Gennaio, Febbraio e Marzo.](hidden_cells_False.png) |

Una cella nascosta contenente un valore è diversa da una cella vuota. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) controlla come vengono visualizzati i valori mancanti; non include né esclude dati sorgente nascosti. Vedi [Controllare la visualizzazione delle celle vuote](/slides/it/python-java/chart-series/#control-the-display-of-empty-cells) per un esempio.

## **Recuperare l’intervallo dati di un grafico**

Prima di aggiornare i dati della cartella di lavoro in una presentazione esistente, esamina gli intervalli sorgente per identificare quali celle del foglio di lavoro utilizza ogni grafico. Il metodo [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) restituisce l’intervallo dati corrente come formula qualificata per il foglio di lavoro, ad esempio `Sheet1!$A$1:$D$5`. Qui, `Sheet1` è il nome del foglio, `!` lo separa dall’intervallo di celle e `$A$1:$D$5` identifica le celle da A1 a D5, inclusive. I segni di dollaro indicano riferimenti assoluti di riga e colonna.

Il metodo legge l’intervallo corrente senza modificare il grafico o la sua cartella di lavoro. Se il grafico non utilizza una cartella di lavoro come origine dati, genera `InvalidOperationException`. Per ulteriori informazioni, consulta il [Riferimento API di ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/).

Questo esempio apre una presentazione e controlla le forme direttamente su ogni diapositiva per individuare i grafici. Stampa il nome di ciascun grafico e il suo intervallo sorgente. Se un grafico non utilizza una cartella di lavoro, stampa un messaggio e passa al grafico successivo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

InvalidOperationException = jpype.JClass("com.aspose.slides.exceptions.InvalidOperationException")

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                try:
                    data_range = shape.getChartData().getRange()
                    print(f"{shape.getName()}: {data_range}")
                except InvalidOperationException:
                    print(f"{shape.getName()}: The chart does not use a workbook as its data source.")
finally:
    presentation.dispose()
```

## **Leggere e scrivere dati del grafico da una cartella di lavoro**

Aspose.Slides for Python via Java fornisce i metodi [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) e [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) che consentono di leggere e scrivere le cartelle di lavoro dei grafici (contenenti dati del grafico modificati con Aspose.Cells). **Nota** che i dati del grafico devono essere organizzati nello stesso modo o avere una struttura simile a quella della sorgente.

Questo esempio utilizza una presentazione con un grafico come prima forma nella prima diapositiva. Legge la cartella di lavoro incorporata in un array di byte, cancella le serie e le categorie esistenti, e riscrive la stessa cartella di lavoro. Le modifiche rimangono in memoria; l’esempio non salva la presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Convalidare il layout del grafico dopo la modifica della cartella di lavoro**

Quando si sostituisce una cartella di lavoro incorporata con una modificata, il grafico mantiene le collezioni di serie e categorie originali. Questa discrepanza può causare il fallimento di [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) con un errore di indice fuori intervallo. Cancella le serie e le categorie esistenti prima di scrivere la cartella di lavoro aggiornata nel grafico. Questo esempio utilizza un grafico che è la prima forma della prima diapositiva. Il commento indica dove avverrebbe la modifica della cartella di lavoro; l’esempio eseguibile riscrive la cartella di lavoro originale e convalida il layout in memoria.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        # Modifica i byte della cartella di lavoro qui, ad esempio usando Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

La cancellazione delle collezioni rimuove i riferimenti a dati obsoleti prima che la cartella di lavoro venga riscritta. Ricostruisci eventuali mappe di serie e categorie necessarie per la cartella di lavoro aggiornata prima di utilizzare il grafico.

## **Impostare formati numerici personalizzati per le celle della cartella di lavoro**

Usa [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) per controllare come i valori numerici appaiono nella cartella di lavoro incorporata di un grafico. Ad esempio, un report potrebbe richiedere un tasso di conversione mostrato come percentuale con quattro decimali e un coefficiente mostrato con cinque decimali. Mantieni entrambi i valori come numeri così rimangono disponibili per calcoli e tracciamento del grafico.

Un formato numerico modifica la visualizzazione, non il valore memorizzato. Il formato `0.0000%` visualizza `0.125` come `12.5000%`; non sostituisce il numero memorizzato con `12.5`. Analogamente, `0.00000` visualizza `0.1234567` come `0.12346` senza arrotondare il valore memorizzato. Se il formato personalizzato è una stringa vuota (`""`), viene usato il formato restituito da [getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat).

L’esempio seguente crea un grafico a colonne e accede alle sue celle tramite [getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook). Nel foglio 0, B2 contiene il tasso di conversione e C2 il coefficiente. Entrambe le celle forniscono i valori del grafico. L’esempio abilita anche le etichette di valore collegate ai formati sorgente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210)
    chart.setTitle(False)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00")
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(0)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A2", "Sample")
    chart.getChartData().getCategories().add(category_cell)

    percentage_cell = workbook.getCell(0, "B2", jpype.JDouble(0.125))
    percentage_cell.setCustomNumberFormat("0.0000%")
    percentage_name = workbook.getCell(0, "B1", "Conversion rate")
    percentage_series = chart.getChartData().getSeries().add(percentage_name, chart.getType())
    percentage_series.getDataPoints().addDataPointForBarSeries(percentage_cell)

    precision_cell = workbook.getCell(0, "C2", jpype.JDouble(0.1234567))
    precision_cell.setCustomNumberFormat("0.00000")
    precision_name = workbook.getCell(0, "C1", "Coefficient")
    precision_series = chart.getChartData().getSeries().add(precision_name, chart.getType())
    precision_series.getDataPoints().addDataPointForBarSeries(precision_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(True)

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

I formati delle celle della cartella di lavoro sono separati dai formati impostati direttamente sugli assi del grafico o sulle etichette dei dati. In questo esempio, ogni etichetta visualizza il valore della cella sorgente perché [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) è impostato su `True`, e segue il formato numerico sorgente poiché [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) è `True`. Dopo aver salvato e riaperto la presentazione, le etichette mostrano `12.5000%` e `0.12346`, come mostrato sotto. L’asse verticale utilizza un proprio formato numerico, assegnato con [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) come `0.00`, con [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) impostato su `False`.

Per formattare un’etichetta indipendentemente, imposta il flag di collegamento alla sorgente su `False` e assegna un formato con [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat). Questo non cambia il formato della cella della cartella di lavoro. Per esempio, un formato etichetta indipendente `0.00` visualizza il primo valore come `0.13`, mentre B2 continua a mostrare `12.5000%`. Vedi [Etichette dati del grafico](/slides/it/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) per la formattazione diretta delle etichette.

L’immagine sotto è stata generata dalla presentazione salvata dopo averla riaperta:

![Grafico a colonne con etichette collegate alla sorgente che mostrano 12.5000% e 0.12346 e asse numerico formattato indipendentemente.](custom-cell-formats.png)

## **Impostare una cella della cartella di lavoro come etichetta dati del grafico**

Puoi usare il testo delle celle della cartella di lavoro come etichette dati del grafico.

Questo esempio aggiunge un grafico a bolle con dati predefiniti alla prima diapositiva di una presentazione esistente. Usa le celle A10:A12 nel foglio 0 per le prime tre etichette della prima serie, abilita le etichette dalle celle e salva la presentazione aggiornata.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)

    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gestire i fogli di lavoro**

Il metodo [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) fornisce l’accesso ai fogli di lavoro in una cartella di lavoro del grafico. Questo esempio crea un grafico a torta con dati predefiniti e stampa ogni nome di foglio di lavoro sulla console.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Specificare il tipo di origine dati**

Questo esempio crea un grafico a colonne 3D con dati predefiniti e imposta due nomi di serie usando diverse origini dati. Il primo nome usa una stringa letterale; il secondo usa la cella C1 nel foglio 0. L’enumerazione [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) seleziona l’origine per ciascun nome. L’esempio salva la presentazione con i nomi delle serie aggiornati.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    literal_name = chart.getChartData().getSeries().get_Item(0).getName()
    literal_name.setDataSourceType(DataSourceType.StringLiterals)
    literal_name.setData("LiteralString")
    cell_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell")
    cell_name.setDataSourceType(DataSourceType.Worksheet)
    cell_name.setData(name_cell)
    
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Rilevare formati di cartella di lavoro incorporati non supportati**

Aspose.Slides non supporta il formato di cartella di lavoro Excel binario (.xlsb) che può essere incorporato in alcuni grafici. Puoi usare il metodo [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) su [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) insieme all’enumerazione [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) per rilevare i formati non supportati e saltare tali grafici. Questo esempio ispeziona le forme nella prima diapositiva di una presentazione esistente, ignora le forme non grafiche e stampa un messaggio diagnostico per ogni grafico con una cartella di lavoro .xlsb incorporata.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        chart_data = shape.getChartData()

        is_internal_workbook = chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook
        is_binary_macro = chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue
        # Leggi o modifica qui i dati della cartella di lavoro del grafico supportati.
finally:
    presentation.dispose()
```

## **Cartella di lavoro esterna**

Aspose.Slides supporta l’utilizzo di cartelle di lavoro esterne come origine dati per i grafici.

### **Creare una cartella di lavoro esterna**

Usa [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) e [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) per esportare una cartella di lavoro di un grafico incorporato in un file e collegare il grafico a quella cartella di lavoro esterna.

Questo esempio crea un grafico a torta con dati predefiniti ed esporta la sua cartella di lavoro. Completa la scrittura del file prima di assegnare la cartella di lavoro esterna come origine dati del grafico, quindi salva la presentazione collegata.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_path = Path("externalWorkbook1.xlsx").resolve()
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(str(workbook_path))

    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Impostare una cartella di lavoro esterna**

Utilizzando il metodo [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook), puoi assegnare una cartella di lavoro esterna a un grafico come origine dati. Questo metodo può anche essere usato per aggiornare il percorso della cartella di lavoro esterna (se quest’ultima è stata spostata).

Sebbene non sia possibile modificare i dati nelle cartelle di lavoro archiviate in posizioni remote o risorse, è comunque possibile usarle come origine dati esterna. Se viene fornito un percorso relativo per una cartella di lavoro esterna, esso viene convertito automaticamente in un percorso completo.

Questo esempio utilizza una cartella di lavoro esterna il cui foglio denominato `Sheet1` contiene un nome di serie in B1, nomi di categoria in A2:A4 e valori numerici in B2:B4. L’esempio crea un grafico a torta, collega la cartella di lavoro e usa [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) per mappare A1:B4 a una serie e tre categorie. Salva la presentazione con il grafico collegato.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())
    chart_data.setExternalWorkbook(workbook_path)
    chart_data.setRange("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il parametro `updateChartData` di [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) controlla se la cartella di lavoro viene caricata.

* Quando `updateChartData` è `False`, viene aggiornato solo il percorso della cartella di lavoro. I dati del grafico non vengono caricati né aggiornati dalla cartella di lavoro di destinazione, quindi la cartella di lavoro può essere non disponibile.
* Quando `updateChartData` è `True`, i dati del grafico vengono aggiornati dalla cartella di lavoro di destinazione.

L’esempio seguente assegna un URL segnaposto con `updateChartData` impostato su `False`. Mantiene i dati predefiniti del grafico a torta e salva la presentazione senza caricare la cartella di lavoro non disponibile.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", False)

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ottenere il percorso della cartella di lavoro esterna di un grafico**

Per identificare la cartella di lavoro collegata a un grafico, verifica se il grafico utilizza un’origine dati esterna e recupera il relativo percorso.

Questo esempio ispeziona la prima forma nella prima diapositiva di una presentazione con una cartella di lavoro esterna collegata. Se si tratta di un grafico collegato a una cartella di lavoro esterna, l’esempio stampa [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) sulla console. Successivamente salva una copia della presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("externalWorkbook.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.ExternalWorkbook:
            print(chart_data.getExternalWorkbookPath())
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Modificare i dati del grafico**

Puoi modificare i dati nelle cartelle di lavoro esterne esattamente come faresti con le cartelle di lavoro interne. Quando una cartella di lavoro esterna non può essere caricata, viene generata un’eccezione.

Questo esempio usa un grafico che è la prima forma nella prima diapositiva e collegato a una cartella di lavoro esterna accessibile. Imposta il valore derivato dalla cella del primo punto dati della prima serie a 100 e salva la presentazione aggiornata. Modificare i valori delle celle può aggiornare il file XLSX esterno collegato, quindi usa una copia se devi preservare la cartella di lavoro originale.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        series = chart.getChartData().getSeries()
        if series.size() > 0 and series.get_Item(0).getDataPoints().size() > 0:
            value_cell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell()
            if value_cell is not None:
                value_cell.setValue(jpype.JInt(100))
                presentation.save("presentation_out.pptx", SaveFormat.Pptx)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Recuperare una cartella di lavoro dalla cache del grafico**

Se un grafico utilizza una cartella di lavoro esterna mancante o non disponibile, Aspose.Slides può ricostruire la cartella di lavoro del grafico dai dati memorizzati nella cache della presentazione. Crea un [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/), chiama [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) e imposta [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) su `True` prima di aprire la presentazione.

L’esempio Python seguente recupera i dati della cartella di lavoro per un grafico che è la prima forma nella prima diapositiva e fa riferimento a una cartella di lavoro esterna non disponibile. Accede ai dati recuperati tramite [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) e [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        recovered_workbook = chart.getChartData().getChartDataWorkbook()

        # Leggi o modifica qui i dati della cartella di lavoro recuperata.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Se la cartella di lavoro esterna non è disponibile e il recupero è disabilitato, Aspose.Slides genera un’eccezione. Abilita il recupero solo quando l’uso dei dati del grafico nella cache è un’alternativa accettabile, perché la cache potrebbe non contenere le modifiche apportate alla cartella di lavoro esterna dopo l’ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un determinato grafico è collegato a una cartella di lavoro esterna o incorporata?**

Sì. Un grafico ha un [tipo di origine dati](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) e un [percorso a una cartella di lavoro esterna](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); se l’origine è una cartella di lavoro esterna, puoi leggere il percorso completo per assicurarti che sia stato utilizzato un file esterno.

**I percorsi relativi alle cartelle di lavoro esterne sono supportati e come vengono memorizzati?**

Sì. Se specifichi un percorso relativo, viene convertito automaticamente in un percorso assoluto. La presentazione memorizza il percorso assoluto nel file PPTX, quindi lo spostamento della cartella di lavoro potrebbe richiedere l’aggiornamento del collegamento.

**Posso usare cartelle di lavoro situate su risorse di rete/condivisioni?**

Sì, tali cartelle di lavoro possono essere usate come origine dati esterna. Tuttavia, la modifica diretta di cartelle di lavoro remote da Aspose.Slides non è supportata: possono essere solo una sorgente.

**Aspose.Slides sovrascrive il file XLSX esterno quando salva la presentazione?**

La presentazione memorizza un [collegamento al file esterno](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Modificare i dati del grafico derivati da celle può anche aggiornare il file XLSX locale collegato. Usa una copia della cartella di lavoro se l’originale deve rimanere invariato.

**Cosa fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password durante il collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio, usando [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) e collegarsi a quella copia.

**Più grafici possono fare riferimento alla stessa cartella di lavoro esterna?**

Sì. Ogni grafico memorizza il proprio collegamento. Se tutti puntano allo stesso file, l’aggiornamento di quel file verrà riflesso in ciascun grafico al successivo caricamento dei dati.