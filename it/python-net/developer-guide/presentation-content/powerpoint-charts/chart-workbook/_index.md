---
title: Gestire le cartelle di lavoro dei grafici nelle presentazioni con Python
linktitle: Cartella di lavoro del grafico
type: docs
weight: 70
url: /it/python-net/chart-workbook/
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
- Aspose.Slides
description: "Scopri Aspose.Slides per Python via .NET: gestisci facilmente le cartelle di lavoro dei grafici in PowerPoint e nei formati OpenDocument per semplificare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con le cartelle di lavoro dei grafici in Aspose.Slides. Mostra come leggere e scrivere i dati del grafico tramite flussi di cartella di lavoro, utilizzare le celle della cartella di lavoro come etichette dei dati del grafico, accedere alle raccolte di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Copre inoltre l'utilizzo di cartelle di lavoro esterne come origini dati per i grafici. Gli esempi dimostrano come creare e assegnare una cartella di lavoro esterna, recuperare il percorso di una cartella di lavoro esterna collegata a un grafico e modificare i dati del grafico quando la cartella di lavoro è disponibile.

## **Leggere e Scrivere Dati del Grafico da una Cartella di Lavoro**

Aspose.Slides fornisce metodi per leggere e scrivere le cartelle di lavoro dei dati del grafico (che contengono dati del grafico modificati con Aspose.Cells). **Nota:** I dati del grafico devono essere organizzati nello stesso modo o avere una struttura simile a quella di origine.

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

### **Convalida del Layout del Grafico Dopo la Modifica della Cartella di Lavoro**

Quando si sostituisce una cartella di lavoro incorporata con una modificata, il grafico conserva le collezioni originali di serie e categorie. Questa discrepanza può causare il fallimento di [IChart.validate_chart_layout](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/ichart/validate_chart_layout/) con un errore di indice fuori intervallo. Cancella le serie e le categorie esistenti prima di scrivere la cartella di lavoro aggiornata nel grafico.

```python
# Dopo aver modificato il flusso della cartella di lavoro (ad esempio, utilizzando Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# Elimina i riferimenti ai dati esistenti.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

Cancellare le collezioni garantisce che la struttura dei dati del grafico sia coerente con la nuova cartella di lavoro, consentendo a `validate_chart_layout` di completarsi senza errori.

## **Impostare una Cellula di Cartella di Lavoro come Etichetta di Dati del Grafico**

A volte è necessario che le etichette del grafico provengano direttamente dalle celle della cartella di lavoro dei dati sottostanti. Aspose.Slides permette di associare le etichette dei dati a celle specifiche della cartella di lavoro in modo che il testo dell'etichetta rifletta sempre il valore della cella. L'esempio seguente mostra come abilitare le etichette valore-da-cella e puntare le etichette selezionate a celle personalizzate nella cartella di lavoro del grafico.

1. Crea un'istanza della classe [Presentation](https://docs.aspose.com/slides/it/python-net/api-reference/aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva per indice.
3. Aggiungi un grafico a bolle con dati di esempio.
4. Accedi alle serie del grafico.
5. Usa una cella della cartella di lavoro come etichetta di dati.
6. Salva la presentazione.

Il seguente codice Python mostra come impostare una cella della cartella di lavoro come etichetta di dati del grafico:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Istanziate la classe Presentation che rappresenta un file di presentazione.
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

## **Gestire i Fogli di Lavoro**

Il seguente codice Python dimostra come usare la proprietà `worksheets` per accedere alla raccolta di fogli di lavoro:

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

## **Specificare il Tipo di Origine Dati**

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

## **Rilevare Formati di Cartella di Lavoro Incorporati non Supportati**

Aspose.Slides non supporta il formato di cartella di lavoro binaria Excel (.xlsb) che può essere incorporato in alcuni grafici. È possibile utilizzare la proprietà `embedded_workbook_type` su [ChartData](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/) insieme all'enumerazione [WorkbookType](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/workbooktype/) per rilevare formati non supportati e saltare quei grafici.

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

## **Cartelle di Lavoro Esterne**

Aspose.Slides supporta l'uso di cartelle di lavoro esterne come origine dati per i grafici.

### **Impostare Cartelle di Lavoro Esterne**

Utilizzando il metodo [ChartData.set_external_workbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/set_external_workbook/), è possibile assegnare una cartella di lavoro esterna a un grafico come sua origine dati. Questo metodo può anche aggiornare il percorso verso una cartella di lavoro esterna se è stata spostata.

Sebbene non sia possibile modificare i dati in cartelle di lavoro archiviate su posizioni remote o risorse, è comunque possibile usarle come origini dati esterne. Se viene fornito un percorso relativo per una cartella di lavoro esterna, questo viene automaticamente convertito in un percorso assoluto.

Il seguente codice Python mostra come impostare una cartella di lavoro esterna:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # Passa False così viene memorizzato solo il percorso: il file di lavoro di destinazione non deve ancora esistere.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Il parametro `update_chart_data` del metodo [set_external_workbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/set_external_workbook/) specifica se il foglio Excel verrà caricato.

- Quando `update_chart_data` è impostato su `False`, viene aggiornato solo il percorso della cartella di lavoro; i dati del grafico non vengono caricati né aggiornati dalla cartella di lavoro di destinazione. Usa questa impostazione quando la cartella di lavoro di destinazione non esiste o non è disponibile.
- Quando `update_chart_data` è impostato su `True` (impostazione predefinita), i dati del grafico vengono caricati e aggiornati dalla cartella di lavoro di destinazione. Se tale cartella di lavoro non può essere aperta, viene generata un'eccezione con il messaggio “External workbook is not available”.

### **Creare Cartelle di Lavoro Esterne**

Utilizzando i metodi [read_workbook_stream](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) e [set_external_workbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/set_external_workbook/), è possibile creare una cartella di lavoro esterna da zero o convertire una cartella di lavoro interna in una esterna.

Questo codice Python dimostra il processo di creazione della cartella di lavoro esterna:

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

### **Ottenere il Percorso della Cartella di Lavoro Esterna di Origine Dati per un Grafico**

A volte i dati di un grafico sono collegati a una cartella di lavoro Excel esterna anziché ai dati incorporati nella presentazione. Con Aspose.Slides è possibile ispezionare l'origine dati del grafico e, se è una cartella di lavoro esterna, leggere il percorso completo della cartella di lavoro.

1. Crea un'istanza della classe [Presentation](https://docs.aspose.com/slides/it/python-net/api-reference/aspose.slides/presentation/).
2. Ottieni un riferimento alla diapositiva per indice.
3. Ottieni un riferimento alla forma del grafico.
4. Recupera l'origine ([ChartDataSourceType](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdatasourcetype/)) che rappresenta l'origine dati del grafico.
5. Verifica se il tipo di origine corrisponde al tipo di origine dati della cartella di lavoro esterna.

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

### **Modificare i Dati del Grafico**

È possibile modificare i dati nelle cartelle di lavoro esterne allo stesso modo in cui si modificano quelli nelle cartelle di lavoro interne. Se una cartella di lavoro esterna non può essere caricata, viene sollevata un'eccezione.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Recuperare una Cartella di Lavoro dalla Cache del Grafico**

Se un grafico utilizza una cartella di lavoro esterna mancante o non disponibile, Aspose.Slides può ricostruire la cartella di lavoro del grafico dai dati memorizzati nella cache della presentazione. Crea [LoadOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/), poi abilita [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/it/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) tramite [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/spreadsheet_options/) prima di aprire la presentazione.

Il seguente esempio Python apre una presentazione il cui grafico fa riferimento a una cartella di lavoro esterna non disponibile e accede ai dati recuperati tramite [Chart.chart_data](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/chart_data/) e [ChartData.chart_data_workbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Leggi o modifica i dati del workbook recuperato qui.
```

Se la cartella di lavoro esterna non è disponibile e il recupero è disabilitato, Aspose.Slides genera un'eccezione. Abilita il recupero solo quando l'uso dei dati del grafico memorizzati nella cache è un'alternativa accettabile, poiché la cache potrebbe non contenere le modifiche apportate alla cartella di lavoro esterna dopo l'ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un grafico specifico è collegato a una cartella di lavoro esterna o incorporata?**

Sì. Un grafico dispone di un [data source type](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/data_source_type/) e di un [path to an external workbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/external_workbook_path/); se l'origine è una cartella di lavoro esterna, è possibile leggere il percorso completo per verificare che venga utilizzato un file esterno.

**I percorsi relativi alle cartelle di lavoro esterne sono supportati e come vengono memorizzati?**

Sì. Se specifichi un percorso relativo, questo viene automaticamente convertito in un percorso assoluto. È comodo per la portabilità del progetto; tuttavia, tieni presente che la presentazione memorizzerà il percorso assoluto nel file PPTX.

**Posso usare cartelle di lavoro locate su risorse o condivisioni di rete?**

Sì, tali cartelle di lavoro possono essere usate come origine dati esterna. Tuttavia, la modifica diretta di cartelle di lavoro remote da Aspose.Slides non è supportata: possono essere usate solo come fonte.

**Aspose.Slides sovrascrive il file XLSX esterno quando salva la presentazione?**

Solo se hai modificato i dati del grafico. La presentazione memorizza un [link to the external file](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/external_workbook_path/) e lo utilizza per la lettura dei dati, quindi aprire e salvare una presentazione lascia intatto il file di lavoro. Tuttavia, i valori modificati tramite i dati del grafico (vedi [Edit Chart Data](#edit-chart-data) sopra) vengono scritti nuovamente nella cartella di lavoro esterna al salvataggio della presentazione—lavora su una copia se l'originale deve rimanere intatto.

**Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password quando crea il collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio usando [Aspose.Cells](/cells/python-net/)) e collegarsi a quella copia.

**Più grafici possono fare riferimento alla stessa cartella di lavoro esterna?**

Sì. Ogni grafico memorizza il proprio collegamento. Se tutti puntano allo stesso file, l'aggiornamento di quel file si rifletterà in ciascun grafico al successivo caricamento dei dati.