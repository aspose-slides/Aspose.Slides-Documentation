---
title: "Gestire le cartelle di lavoro dei grafici nelle presentazioni con Python"
linktitle: "Cartella di lavoro del grafico"
type: docs
weight: 70
url: /it/python-net/chart-workbook/
keywords:
- "cartella di lavoro del grafico"
- "dati del grafico"
- "cella della cartella di lavoro"
- "etichetta dei dati"
- "foglio di lavoro"
- "origine dati"
- "cartella di lavoro esterna"
- "dati esterni"
- "cache del grafico"
- "recupero della cartella di lavoro"
- "PowerPoint"
- "presentazione"
- "Python"
- "Aspose.Slides"
description: "Scopri Aspose.Slides per Python via .NET: gestisci facilmente le cartelle di lavoro dei grafici in formato PowerPoint e OpenDocument per ottimizzare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con le cartelle di lavoro dei grafici in Aspose.Slides. Mostra come leggere e scrivere i dati del grafico tramite flussi di cartelle di lavoro, usare le celle della cartella di lavoro come etichette di dati del grafico, accedere alle raccolte di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Copre inoltre l'utilizzo di cartelle di lavoro esterne come origini dati dei grafici. Gli esempi dimostrano come creare e assegnare una cartella di lavoro esterna, recuperare il percorso di una cartella di lavoro esterna collegata a un grafico e modificare i dati del grafico quando la cartella di lavoro è disponibile.

Per le celle della cartella di lavoro che rappresentano dati mancanti, vedere [Controllare la visualizzazione delle celle vuote](/slides/it/python-net/chart-series/) per la differenza tra una cella vuota e zero, e un confronto a linee dei diversi modi di visualizzazione disponibili.

## **Leggere e scrivere dati del grafico da una cartella di lavoro**

Aspose.Slides fornisce metodi per leggere e scrivere le cartelle di lavoro dei dati del grafico (che contengono dati del grafico modificati con Aspose.Cells). **Nota:** I dati del grafico devono essere organizzati nello stesso modo o avere una struttura simile alla sorgente.

Il seguente codice Python dimostra un'operazione di esempio:

```py
import aspose.slides as slides

with slides.Presentation("chart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]

    data_stream = chart.chart_data.read_workbook_stream()

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    data_stream.seek(0)
    chart.chart_data.write_workbook_stream(data_stream)
```

### **Convalidare il layout del grafico dopo la modifica della cartella di lavoro**

Quando si sostituisce una cartella di lavoro incorporata con una modificata, il grafico mantiene le collezioni originali di serie e categorie. Questa discrepanza può far fallire [IChart.validate_chart_layout](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/ichart/validate_chart_layout/) con un errore di indice fuori intervallo. Cancella le serie e le categorie esistenti prima di scrivere nuovamente la cartella di lavoro aggiornata nel grafico.

```python
# Dopo aver modificato lo stream della cartella di lavoro (ad esempio, usando Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# Cancella i riferimenti ai dati esistenti.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

Cancellare le collezioni assicura che la struttura dei dati del grafico sia coerente con la nuova cartella di lavoro, consentendo a `validate_chart_layout` di completarsi senza errori.

## **Impostare una cella della cartella di lavoro come etichetta di dati del grafico**

A volte è necessario che le etichette del grafico provengano direttamente dalle celle della cartella di lavoro sottostante. Aspose.Slides consente di associare le etichette di dati a celle specifiche della cartella di lavoro in modo che il testo dell'etichetta rifletta sempre il valore della cella. L'esempio seguente mostra come abilitare le etichette valore-da-cella e indirizzare le etichette selezionate a celle personalizzate nella cartella di lavoro del grafico.

1. Creare un'istanza della classe [Presentation](https://docs.aspose.com/slides/it/python-net/api-reference/aspose.slides/presentation/).
2. Ottenere un riferimento alla diapositiva per indice.
3. Aggiungere un grafico a bolle con dati di esempio.
4. Accedere alle serie del grafico.
5. Utilizzare una cella della cartella di lavoro come etichetta di dati.
6. Salvare la presentazione.

Il seguente codice Python mostra come impostare una cella della cartella di lavoro come etichetta di dati del grafico:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Istanziare la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_label_value_from_cell = True

    workbook = chart.chart_data.chart_data_workbook

    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2")

    presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Gestire i fogli di lavoro**

Il seguente codice Python dimostra come utilizzare la proprietà `worksheets` per accedere alla raccolta di fogli di lavoro:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)

    workbook = chart.chart_data.chart_data_workbook
    for i in range(len(workbook.worksheets)):
        print(workbook.worksheets[i].name)
```

## **Specificare il tipo di origine dati**

Il seguente codice Python mostra come specificare un tipo di origine dati:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)

    series_name = chart.chart_data.series[0].name
    series_name.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    series_name.data = "LiteralString"

    series_name = chart.chart_data.series[1].name
    series_name.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NewCell")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Rilevare formati di cartelle di lavoro incorporati non supportati**

Aspose.Slides non supporta il formato di cartella di lavoro binaria Excel (.xlsb) che può essere incorporato in alcuni grafici. È possibile utilizzare la proprietà `embedded_workbook_type` su [ChartData](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/) insieme all'enumerazione [WorkbookType](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/workbooktype/) per rilevare formati non supportati e ignorare quei grafici.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart = shape
        chart_data = chart.chart_data

        if (chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK and
                chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO):
            # La cartella di lavoro incorporata è in formato .xlsb, che non è supportato.
            continue

        # Leggi o modifica i dati della cartella di lavoro del grafico qui.
```

## **Cartelle di lavoro esterne**

Aspose.Slides supporta l'uso di cartelle di lavoro esterne come origine dati per i grafici.

### **Impostare cartelle di lavoro esterne**

Utilizzando il metodo [ChartData.set_external_workbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/set_external_workbook/), è possibile assegnare una cartella di lavoro esterna a un grafico come sua origine dati. Questo metodo può anche aggiornare il percorso di una cartella di lavoro esterna se è stata spostata.

Sebbene non sia possibile modificare i dati in cartelle di lavoro archiviate su posizioni o risorse remote, è comunque possibile utilizzare tali cartelle di lavoro come origini dati esterne. Se si fornisce un percorso relativo per una cartella di lavoro esterna, questo viene automaticamente convertito in un percorso completo.

Il seguente codice Python mostra come impostare una cartella di lavoro esterna:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # Passa False così solo il percorso viene memorizzato: il workbook di destinazione non deve ancora esistere.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Il parametro `update_chart_data` del metodo [set_external_workbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/set_external_workbook/) specifica se la cartella di lavoro Excel verrà caricata.

- Quando `update_chart_data` è impostato su `False`, viene aggiornato solo il percorso della cartella di lavoro; i dati del grafico non vengono caricati né aggiornati dalla cartella di lavoro di destinazione. Usa questa impostazione quando la cartella di lavoro di destinazione non esiste o non è disponibile.
- Quando `update_chart_data` è impostato su `True` (impostazione predefinita), i dati del grafico vengono caricati e aggiornati dalla cartella di lavoro di destinazione. Se quella cartella di lavoro non può essere aperta, viene generata un'eccezione con il messaggio "External workbook is not available".

### **Creare cartelle di lavoro esterne**

Utilizzando i metodi [read_workbook_stream](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) e [set_external_workbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/set_external_workbook/), è possibile creare una cartella di lavoro esterna da zero o convertire una cartella di lavoro interna in una esterna.

Questo codice Python dimostra il processo di creazione di una cartella di lavoro esterna:

```python
import pathlib
import aspose.slides as slides
import aspose.slides.charts as charts

workbook_path = "external_workbook.xlsx"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)

    workbook_data = chart.chart_data.read_workbook_stream().read()

    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    full_path = str(pathlib.Path(workbook_path).resolve())
    chart.chart_data.set_external_workbook(full_path)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Ottenere il percorso della cartella di lavoro esterna associata a un grafico**

A volte i dati di un grafico sono collegati a una cartella di lavoro Excel esterna anziché ai dati incorporati della presentazione. Con Aspose.Slides è possibile ispezionare l'origine dati del grafico e, se è una cartella di lavoro esterna, leggere il percorso completo della cartella di lavoro.

1. Creare un'istanza della classe [Presentation](https://docs.aspose.com/slides/it/python-net/api-reference/aspose.slides/presentation/).
2. Ottenere un riferimento alla diapositiva per indice.
3. Ottenere un riferimento alla forma del grafico.
4. Ottenere l'origine ([ChartDataSourceType](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdatasourcetype/)) che rappresenta l'origine dati del grafico.
5. Verificare se il tipo di origine corrisponde al tipo di origine dati di una cartella di lavoro esterna.

Il seguente codice Python dimostra l'operazione:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Modificare i dati del grafico**

È possibile modificare i dati in cartelle di lavoro esterne allo stesso modo in cui si modificano i dati in cartelle di lavoro interne. Se una cartella di lavoro esterna non può essere caricata, viene generata un'eccezione.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Recuperare una cartella di lavoro dalla cache del grafico**

Se un grafico utilizza una cartella di lavoro esterna mancante o non disponibile, Aspose.Slides può ricostruire la cartella di lavoro del grafico dai dati memorizzati nella cache della presentazione. Creare un'istanza di [LoadOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/), quindi abilitare [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/it/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) tramite [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/spreadsheet_options/) prima di aprire la presentazione.

Il seguente esempio Python apre una presentazione il cui grafico fa riferimento a una cartella di lavoro esterna non disponibile e accede ai dati recuperati tramite [Chart.chart_data](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/chart_data/) e [ChartData.chart_data_workbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Leggi o modifica i dati della cartella di lavoro recuperata qui.
```

Se la cartella di lavoro esterna non è disponibile e il recupero è disabilitato, Aspose.Slides genera un'eccezione. Abilitare il recupero solo quando l'uso dei dati del grafico nella cache è un'opzione accettabile, poiché la cache potrebbe non contenere le modifiche effettuate alla cartella di lavoro esterna dopo l'ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un grafico specifico è collegato a una cartella di lavoro esterna o incorporata?**

Sì. Un grafico ha un [data source type](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/data_source_type/) e un [path to an external workbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/external_workbook_path/); se la sorgente è una cartella di lavoro esterna, è possibile leggere il percorso completo per assicurarsi che venga utilizzato un file esterno.

**I percorsi relativi alle cartelle di lavoro esterne sono supportati e come vengono memorizzati?**

Sì. Se si specifica un percorso relativo, questo viene automaticamente convertito in un percorso assoluto. Questo è comodo per la portabilità del progetto; tuttavia, la presentazione memorizzerà il percorso assoluto nel file PPTX.

**Posso utilizzare cartelle di lavoro situate su risorse o condivisioni di rete?**

Sì, tali cartelle di lavoro possono essere usate come origine dati esterna. Tuttavia, la modifica diretta di cartelle di lavoro remote da Aspose.Slides non è supportata: possono solo essere usate come sorgente.

**Aspose.Slides sovrascrive il file XLSX esterno quando salvo la presentazione?**

Solo se si sono modificati i dati del grafico. La presentazione memorizza un [link to the external file](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/external_workbook_path/) e lo utilizza per leggere i dati, quindi aprire e salvare la presentazione lascia intatto il file di lavoro. Tuttavia, i valori modificati tramite i dati del grafico (vedi [Edit Chart Data](#edit-chart-data) sopra) vengono scritti nuovamente nella cartella di lavoro esterna quando la presentazione viene salvata: lavorare su una copia se l'originale deve rimanere intatto.

**Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password durante il collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio, usando [Aspose.Cells](/cells/python-net/)) e collegarsi a quella copia.

**Più grafici possono fare riferimento alla stessa cartella di lavoro esterna?**

Sì. Ogni grafico memorizza il proprio link. Se tutti puntano allo stesso file, l'aggiornamento di quel file verrà riflesso in ciascun grafico al successivo caricamento dei dati.