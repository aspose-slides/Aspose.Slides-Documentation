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
- etichetta dati
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
description: "Scopri Aspose.Slides per Python via Java: gestisci facilmente le cartelle di lavoro dei grafici in formati PowerPoint e OpenDocument per ottimizzare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con le cartelle di lavoro dei grafici in Aspose.Slides. Mostra come leggere e scrivere i dati del grafico tramite flussi di cartelle di lavoro, utilizzare le celle della cartella di lavoro come etichette dei dati del grafico, accedere alle collezioni di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Copre inoltre l'utilizzo di cartelle di lavoro esterne come fonti dati per i grafici. Gli esempi dimostrano come creare e assegnare una cartella di lavoro esterna, recuperare il percorso di una cartella di lavoro esterna collegata a un grafico e modificare i dati del grafico quando la cartella di lavoro è disponibile.

## **Leggere e Scrivere Dati del Grafico da una Cartella di Lavoro**
Aspose.Slides fornisce i metodi [readWorkbookStream](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdata/#readWorkbookStream) e [writeWorkbookStream](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdata/#writeWorkbookStream) che consentono di leggere e scrivere le cartelle di lavoro dei dati del grafico (contenenti dati del grafico modificati con Aspose.Cells). **Nota** che i dati del grafico devono essere organizzati nello stesso modo o devono avere una struttura simile a quella della sorgente.

Questo codice Python dimostra un'operazione di esempio:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    workbook_data = chart_data.readWorkbookStream()
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(workbook_data)
finally:
    presentation.dispose()
```

### **Convalidare il Layout del Grafico Dopo la Modifica della Cartella di Lavoro**

Quando si sostituisce una cartella di lavoro incorporata con una modificata, il grafico conserva le sue collezioni originali di serie e categorie. Questa incongruenza può far generare a [Chart.validateChartLayout](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/#validateChartLayout) un`ArgumentOutOfRangeException` (parametro: index). Per evitare l'eccezione, cancellare le serie e le categorie esistenti **prima** di scrivere la cartella di lavoro aggiornata nel grafico.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# Leggi la cartella di lavoro dopo averla modificata (ad esempio, usando Aspose.Cells).
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # Cancella i riferimenti ai dati esistenti.
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

La cancellazione delle collezioni garantisce che la struttura dei dati del grafico sia allineata alla nuova cartella di lavoro, consentendo a [validateChartLayout](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/#validateChartLayout) di completarsi senza errori.

## **Impostare una Cella della Cartella di Lavoro come Etichetta dei Dati del Grafico**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) .
2. Ottenere il riferimento a una diapositiva tramite il suo indice.
3. Aggiungere un grafico a bolle con alcuni dati.
4. Accedere alle serie del grafico.
5. Impostare la cella della cartella di lavoro come etichetta dei dati.
6. Salvare la presentazione.

Questo codice Python mostra come impostare una cella della cartella di lavoro come etichetta dei dati del grafico:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    slide = presentation.getSlides().get_Item(0)
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

## **Gestire i Fogli di Lavoro**

Questo codice Python dimostra un'operazione in cui il metodo [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdataworkbook/#getWorksheets) viene utilizzato per accedere a una collezione di fogli di lavoro:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Specificare il Tipo di Origine Dati**

Questo codice Python mostra come specificare un tipo per un'origine dati:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    series_name = chart.getChartData().getSeries().get_Item(0).getName()
    series_name.setDataSourceType(DataSourceType.StringLiterals)
    series_name.setData("LiteralString")
    series_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell")
    series_name.setData(name_cell)
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Rilevare Formati di Cartelle di Lavoro Incorporate Non Supportati**

Aspose.Slides non supporta il formato di cartella di lavoro Excel binario (.xlsb) che può essere incorporato in alcuni grafici. È possibile utilizzare il metodo [getEmbeddedWorkbookType](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) su [ChartData](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdata/) insieme all'enumerazione [WorkbookType](https://reference.aspose.com/slides/it/python-java/aspose.slides/workbooktype/) per rilevare i formati non supportati e saltare quei grafici.

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
        if chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook and chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro:
            # Il workbook incorporato è in formato .xlsb, che non è supportato.
            continue
        # Leggi o modifica i dati del workbook del grafico qui.
finally:
    presentation.dispose()
```

### **Creare una Cartella di Lavoro Esterna**

Utilizzando i metodi [readWorkbookStream](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdata/#readWorkbookStream) e [setExternalWorkbook](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdata/#setExternalWorkbook), è possibile creare una cartella di lavoro esterna da zero o trasformare una cartella di lavoro interna in esterna.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    workbook_path = "externalWorkbook1.xlsx"
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(workbook_path)
    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Impostare una Cartella di Lavoro Esterna**

Utilizzando il metodo [setExternalWorkbook](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdata/#setExternalWorkbook), è possibile assegnare una cartella di lavoro esterna a un grafico come sua origine dati. Questo metodo può anche essere usato per aggiornare il percorso della cartella di lavoro esterna (se quest'ultima è stata spostata).

Anche se non è possibile modificare i dati delle cartelle di lavoro archiviate in posizioni remote o risorse, è comunque possibile utilizzare tali cartelle di lavoro come fonte dati esterna. Se viene fornito un percorso relativo per una cartella di lavoro esterna, viene convertito automaticamente in un percorso completo.

Questo codice Python mostra come impostare una cartella di lavoro esterna:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, False)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("externalWorkbook.xlsx")
    workbook = chart_data.getChartDataWorkbook()
    series_name_cell = workbook.getCell(0, "B1")
    series = chart_data.getSeries().add(series_name_cell, ChartType.Pie)
    for row in range(2, 5):
        value_cell = workbook.getCell(0, f"B{row}")
        series.getDataPoints().addDataPointForPieSeries(value_cell)
    for row in range(2, 5):
        category_cell = workbook.getCell(0, f"A{row}")
        chart_data.getCategories().add(category_cell)
    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il secondo parametro (`bool`) del metodo [setExternalWorkbook](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdata/#setExternalWorkbook) viene utilizzato per specificare se una cartella di lavoro Excel deve essere caricata o meno. 

* Quando il suo valore è impostato a `False`, solo il percorso della cartella di lavoro viene aggiornato — i dati del grafico non saranno caricati o aggiornati dalla cartella di lavoro di destinazione. È consigliabile usare questa impostazione quando la cartella di lavoro di destinazione è inesistente o non disponibile. 
* Quando il suo valore è impostato a `True`, i dati del grafico vengono aggiornati dalla cartella di lavoro di destinazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("http://path/doesnt/exists", False)
    presentation.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ottenere il Percorso della Cartella di Lavoro della Fonte Dati Esterna di un Grafico**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) .
2. Ottenere il riferimento a una diapositiva tramite il suo indice.
3. Creare un oggetto per la forma del grafico.
4. Creare un oggetto per il tipo di origine ([ChartDataSourceType](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdatasourcetype/)) che rappresenta la fonte dati del grafico.
5. Specificare la condizione pertinente in base al tipo di origine che corrisponde al tipo di fonte dati della cartella di lavoro esterna.

Questo codice Python dimostra l'operazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(1)
    chart = slide.getShapes().get_Item(0)
    source_type = chart.getChartData().getDataSourceType()
    if source_type == ChartDataSourceType.ExternalWorkbook:
        path = chart.getChartData().getExternalWorkbookPath()
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Modificare i Dati del Grafico**

È possibile modificare i dati in cartelle di lavoro esterne allo stesso modo in cui si apportano modifiche al contenuto delle cartelle di lavoro interne. Quando una cartella di lavoro esterna non può essere caricata, viene generata un'eccezione.

Questo codice Python mostra come impostare una cartella di lavoro esterna:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    chart_data.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(jpype.JInt(100))
    presentation.save("presentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Recuperare una Cartella di Lavoro dalla Cache del Grafico**

Se un grafico utilizza una cartella di lavoro esterna che manca o non è disponibile, Aspose.Slides può ricostruire la cartella di lavoro del grafico dai dati memorizzati nella presentazione. Creare un [LoadOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/), configurarlo con [SpreadsheetOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/spreadsheetoptions/), e chiamare [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/it/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) con `True` prima di aprire la presentazione.

L'esempio Python seguente apre una presentazione il cui grafico fa riferimento a una cartella di lavoro esterna non disponibile e accede ai dati recuperati tramite [Chart.getChartData](https://reference.aspose.com/slides/it/python-java/aspose.slides/chart/#getChartData) e [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)
load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    recovered_workbook = chart.getChartData().getChartDataWorkbook()

    # Leggi o modifica i dati del workbook recuperato qui.
finally:
    presentation.dispose()
```

Se la cartella di lavoro esterna non è disponibile e il recupero è disabilitato, Aspose.Slides genera un'eccezione. Abilitare il recupero solo quando l'uso dei dati del grafico nella cache è un'alternativa accettabile, poiché la cache potrebbe non contenere le modifiche apportate alla cartella di lavoro esterna dopo l'ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un grafico specifico è collegato a una cartella di lavoro esterna o incorporata?**

Sì. Un grafico ha un [tipo di origine dati](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdata/#getDataSourceType) e un [percorso a una cartella di lavoro esterna](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); se la sorgente è una cartella di lavoro esterna, è possibile leggere il percorso completo per assicurarsi che venga utilizzato un file esterno.

**I percorsi relativi alle cartelle di lavoro esterne sono supportati e come vengono memorizzati?**

Sì. Se si specifica un percorso relativo, viene automaticamente convertito in un percorso assoluto. Questo è comodo per la portabilità del progetto; tuttavia, occorre tenere presente che la presentazione memorizzerà il percorso assoluto nel file PPTX.

**Posso usare cartelle di lavoro situate su risorse/condivisioni di rete?**

Sì, tali cartelle di lavoro possono essere utilizzate come fonte dati esterna. Tuttavia, la modifica diretta di cartelle di lavoro remote da Aspose.Slides non è supportata: possono essere utilizzate solo come fonte.

**Aspose.Slides sovrascrive il file XLSX esterno quando si salva la presentazione?**

No. La presentazione memorizza un [collegamento al file esterno](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) e lo utilizza per leggere i dati. Il file esterno stesso non viene modificato al salvataggio della presentazione.

**Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password durante il collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio, utilizzando [Aspose.Cells](/cells/python-java/)) e collegarsi a quella copia.

**Più grafici possono fare riferimento alla stessa cartella di lavoro esterna?**

Sì. Ogni grafico memorizza il proprio collegamento. Se tutti puntano allo stesso file, l'aggiornamento di quel file verrà riflesso in ciascun grafico al successivo caricamento dei dati.