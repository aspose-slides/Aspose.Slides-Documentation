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
description: "Scopri Aspose.Slides per Python tramite .NET: gestisci facilmente le cartelle di lavoro dei grafici nei formati PowerPoint e OpenDocument per semplificare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con le cartelle di lavoro dei grafici in Aspose.Slides. Mostra come leggere e scrivere i dati del grafico tramite flussi di cartelle di lavoro, usare le celle della cartella di lavoro come etichette dei dati del grafico, accedere alle collezioni di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Copre anche l'utilizzo di cartelle di lavoro esterne come fonti dati per i grafici. Gli esempi dimostrano come creare e assegnare una cartella di lavoro esterna, recuperare il percorso di una cartella di lavoro esterna collegata a un grafico e modificare i dati del grafico quando la cartella di lavoro è disponibile.

Per le celle della cartella di lavoro che rappresentano dati mancanti, vedere [Control the Display of Empty Cells](/slides/it/python-net/chart-series/) per la differenza tra una cella vuota e zero, e un confronto a linee dei diversi modi di visualizzazione disponibili.

## **Includere dati da righe e colonne nascoste**

Usa [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) per controllare se un grafico traccia dati da righe e colonne nascoste del foglio di lavoro. Impostalo su `True` per tracciare solo le celle visibili, o su `False` per includere sia le celle visibili sia quelle nascoste. Questa impostazione controlla il tracciamento del grafico; non nasconde né mostra righe o colonne del foglio di lavoro.

Scarica [hidden-source-data.pptx](hidden-source-data.pptx) e posizionalo nella directory di lavoro. La sua prima diapositiva contiene un grafico a colonne come prima forma. Il foglio di lavoro incorporato, `Sheet1`, contiene l’intervallo sorgente `A1:C4`. La riga 3 e la colonna C sono nascoste, ma le relative celle contengono ancora valori.

| Riga foglio di lavoro | A: Mese | B: Vendita al dettaglio | C: All'ingrosso (colonna nascosta) |
| --- | --- | --- | --- |
| 2 | Gennaio | 10 | 30 |
| 3 (riga nascosta) | Febbraio | 40 | 60 |
| 4 | Marzo | 20 | 50 |

Accedi alle celle sorgente tramite [ChartData.chart_data_workbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) e leggi [ChartDataCell.is_hidden](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdatacell/is_hidden/) per ispezionare lo stato di nascondimento. Questa proprietà è di sola lettura. In questo file, B2 è visibile, B3 appartiene alla riga nascosta e C2 appartiene alla colonna nascosta; l’esempio stampa `False`, `True` e `True`, rispettivamente.

Per questo esempio, aggiorna i dati del grafico dopo aver modificato l’impostazione di tracciamento: conserva la cartella di lavoro incorporata con [read_workbook_stream](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) e ricaricala con [write_workbook_stream](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). Quando includi tutte le celle, usa anche [set_range](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/set_range/) per ripristinare l’intervallo completo, inclusa la categoria di Febbraio nascosta. Cambiare semplicemente il flag non è sufficiente a aggiornare i dati del grafico memorizzati nella cache di questo esempio e le etichette delle categorie.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("hidden-source-data.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        workbook = chart.chart_data.chart_data_workbook
        print(f"B2 hidden: {workbook.get_cell(0, 'B2').is_hidden}")
        print(f"B3 hidden: {workbook.get_cell(0, 'B3').is_hidden}")
        print(f"C2 hidden: {workbook.get_cell(0, 'C2').is_hidden}")

        workbook_stream = chart.chart_data.read_workbook_stream()
        for visible_only in [True, False]:
            chart.plot_visible_cells_only = visible_only

            # Aggiorna i dati del grafico dalla cartella di lavoro incorporata.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Ripristina l'intervallo sorgente completo, incluse le categorie nascoste.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

L’esempio salva `hidden_cells_True.pptx` con solo i valori di Vendita al dettaglio visibili (10 e 20), e `hidden_cells_False.pptx` con tutti e sei i valori. Le immagini sotto sono state generate dalle presentazioni salvate dopo averle riaperte; entrambi i file conservano l’impostazione di tracciamento assegnata. La riga 3 e la colonna C rimangono nascoste in entrambe le cartelle di lavoro incorporate.

| Solo celle visibili (`True`) | Tutte le celle (`False`) |
| --- | --- |
| ![Solo celle visibili: valori Vendita al dettaglio 10 e 20 per Gennaio e Marzo.](hidden_cells_True.png) | ![Tutte le celle: valori Vendita al dettaglio e All'ingrosso per Gennaio, Febbraio e Marzo.](hidden_cells_False.png) |

Una cella nascosta contenente un valore è diversa da una cella vuota. [Chart.display_blanks_as](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/display_blanks_as/) controlla come vengono visualizzati i valori mancanti; non include né esclude dati sorgente nascosti. Vedere [Control the Display of Empty Cells](/slides/it/python-net/chart-series/#control-the-display-of-empty-cells) per un esempio.

## **Leggere e scrivere dati di grafico da una cartella di lavoro**

Aspose.Slides per Python tramite .NET fornisce i metodi [read_workbook_stream](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) e [write_workbook_stream](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) che consentono di leggere e scrivere le cartelle di lavoro dei dati del grafico (contenenti dati del grafico modificati con Aspose.Cells). **Nota** che i dati del grafico devono essere organizzati nello stesso modo o avere una struttura simile a quella della sorgente.

Questo esempio apre `chart.pptx`, che deve contenere un grafico come prima forma nella sua prima diapositiva. Legge la cartella di lavoro incorporata in un flusso, cancella le serie e le categorie esistenti e riscrive la stessa cartella di lavoro. Le modifiche rimangono in memoria; l’esempio non salva la presentazione.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
    else:
        print("The first shape is not a chart.")
```

### **Convalidare il layout del grafico dopo la modifica della cartella di lavoro**

Quando sostituisci una cartella di lavoro incorporata con una modificata, il grafico mantiene le collezioni di serie e categorie originali. Questa discrepanza può far fallire [Chart.validate_chart_layout](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/validate_chart_layout/) con un errore di indice fuori intervallo. Cancella le serie e le categorie esistenti prima di scrivere la cartella di lavoro aggiornata nel grafico. Questo esempio richiede `chart.pptx` con un grafico come prima forma nella sua prima diapositiva. Il commento indica dove avverrebbe la modifica della cartella di lavoro; l’esempio eseguibile riscrive la cartella di lavoro originale e convalida il layout in memoria.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Modifica lo stream della cartella di lavoro qui, ad esempio, usando Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

La cancellazione delle collezioni rimuove i riferimenti a dati obsoleti prima che la cartella di lavoro venga riscritta. Ricostruisci eventuali mappature di serie e categorie richieste per la cartella di lavoro aggiornata prima di utilizzare il grafico.

## **Impostare una cella della cartella di lavoro come etichetta dati del grafico**

Puoi usare il testo delle celle della cartella di lavoro come etichette dati del grafico. I passaggi seguenti mostrano come collegare le etichette in un grafico a bolle alle celle nella sua cartella di lavoro dati.

1. Crea un'istanza della [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) classe.  
2. Accedi alla prima diapositiva tramite il suo indice basato su zero.  
3. Aggiungi un grafico a bolle con dati predefiniti.  
4. Accedi alle serie del grafico.  
5. Imposta la cella della cartella di lavoro come etichetta dati.  
6. Salva la presentazione.

Questo esempio apre `chart2.pptx`, che deve contenere almeno una diapositiva, e aggiunge un grafico a bolle con dati predefiniti. Usa le celle A10:A12 sul foglio di lavoro 0 per le prime tre etichette nella prima serie, abilita le etichette dalle celle e salva il risultato in `resultchart.pptx`.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart2.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    workbook = chart.chart_data.chart_data_workbook

    series.labels.default_data_label_format.show_label_value_from_cell = True
    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0 cell value")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1 cell value")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2 cell value")

    presentation.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **Gestire i fogli di lavoro**

La proprietà [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) fornisce l'accesso ai fogli di lavoro in una cartella di lavoro del grafico. Questo esempio crea un grafico a torta con dati predefiniti e stampa ogni nome di foglio di lavoro nella console.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
    workbook = chart.chart_data.chart_data_workbook

    for worksheet in workbook.worksheets:
        print(worksheet.name)
```

## **Specificare il tipo di origine dati**

Questo esempio crea un grafico a colonne 3D con dati predefiniti e imposta due nomi di serie utilizzando diverse origini dati. Il primo nome usa un literal stringa; il secondo usa la cella C1 sul foglio di lavoro 0. L'enumerazione [DataSourceType](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/datasourcetype/) seleziona la sorgente per ogni nome. Il risultato è salvato in `pres.pptx`.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    literal_name = chart.chart_data.series[0].name

    literal_name.data_source_type = charts.DataSourceType.STRING_LITERALS
    literal_name.data = "LiteralString"

    cell_name = chart.chart_data.series[1].name
    name_cell = chart.chart_data.chart_data_workbook.get_cell(0, "C1", "NewCell")
    cell_name.data_source_type = charts.DataSourceType.WORKSHEET
    cell_name.data = name_cell

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Rilevare formati di cartella di lavoro incorporata non supportati**

Aspose.Slides non supporta il formato di cartella di lavoro binaria Excel (.xlsb) che può essere incorporato in alcuni grafici. Puoi usare la proprietà [embedded_workbook_type](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) su [ChartData](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/) insieme all'enumerazione [WorkbookType](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/workbooktype/) per rilevare i formati non supportati e saltare quei grafici. Questo esempio ispeziona le forme nella prima diapositiva di `sample.pptx`, ignora le forme non grafico e stampa un messaggio diagnostico per ogni grafico con una cartella di lavoro .xlsb incorporata.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart_data = shape.chart_data
        is_internal_workbook = chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK
        is_binary_macro = chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue

        # Leggi o modifica i dati della cartella di lavoro del grafico supportati qui.
```

## **Cartella di lavoro esterna**

Aspose.Slides supporta l'uso di cartelle di lavoro esterne come fonte dati per i grafici.

### **Creare una cartella di lavoro esterna**

Usa [read_workbook_stream](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) e [set_external_workbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/set_external_workbook/) per esportare una cartella di lavoro di grafico incorporata in un file e collegare il grafico a quella cartella di lavoro esterna.

Questo esempio crea un grafico a torta con dati predefiniti, scrive la sua cartella di lavoro in `externalWorkbook1.xlsx` e chiude il flusso di output prima di assegnare il file come sorgente dati del grafico. Salva la presentazione collegata in `externalWorkbook.pptx`.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)
    workbook_path = str(Path("externalWorkbook1.xlsx").resolve())

    workbook_stream = chart.chart_data.read_workbook_stream()
    workbook_data = workbook_stream.read()
    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    chart.chart_data.set_external_workbook(workbook_path)
    presentation.save("externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Impostare una cartella di lavoro esterna**

Utilizzando il metodo [set_external_workbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/set_external_workbook/), puoi assegnare una cartella di lavoro esterna a un grafico come sua fonte dati. Questo metodo può essere usato anche per aggiornare il percorso della cartella di lavoro esterna (se quest’ultima è stata spostata).

Sebbene non sia possibile modificare i dati in cartelle di lavoro memorizzate in posizioni remote o risorse, è comunque possibile usarle come fonte dati esterna. Se viene fornito un percorso relativo per una cartella di lavoro esterna, viene convertito automaticamente in un percorso assoluto.

Questo esempio richiede `externalWorkbook.xlsx` nella directory di lavoro. Il suo foglio di lavoro denominato `Sheet1` deve contenere un nome di serie in B1, nomi di categoria in A2:A4 e valori numerici in B2:B4. L’esempio crea un grafico a torta, collega la cartella di lavoro e usa [set_range](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/set_range/) per mappare A1:B4 a una serie e tre categorie. Salva il risultato in `Presentation_with_externalWorkbook.pptx`.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart_data = chart.chart_data
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())

    chart_data.set_external_workbook(workbook_path)
    chart_data.set_range("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

Il parametro `update_chart_data` di [set_external_workbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/set_external_workbook/) controlla se la cartella di lavoro viene caricata.

* Quando `update_chart_data` è `False`, viene aggiornato solo il percorso della cartella di lavoro. I dati del grafico non vengono caricati né aggiornati dalla cartella di lavoro di destinazione, quindi la cartella di lavoro può essere non disponibile.  
* Quando `update_chart_data` è `True`, i dati del grafico vengono aggiornati dalla cartella di lavoro di destinazione.

Il seguente esempio assegna un URL segnaposto con `update_chart_data` impostato su `False`. Mantiene i dati predefiniti del grafico a torta e salva la presentazione senza caricare la cartella di lavoro non disponibile.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)

    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Ottenere il percorso della cartella di lavoro sorgente dati esterna di un grafico**

Per identificare la cartella di lavoro collegata a un grafico, verifica prima se il grafico utilizza una fonte dati esterna. Se è così, puoi recuperare il percorso della cartella di lavoro seguendo questi passaggi.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).  
2. Accedi alla prima diapositiva tramite il suo indice basato su zero.  
3. Verifica che la prima forma sia un grafico.  
4. Leggi il tipo di origine dati del grafico.  
5. Se la sorgente è una cartella di lavoro esterna, leggi il suo percorso.

Questo esempio apre `externalWorkbook.pptx`, creato nell’esempio precedente, e ispeziona la prima forma nella prima diapositiva. Se è un grafico collegato a una cartella di lavoro esterna, l’esempio stampa [external_workbook_path](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/external_workbook_path/) nella console. Successivamente salva una copia della presentazione in `Result.pptx`.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("externalWorkbook.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        if chart_data.data_source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
            print(chart_data.external_workbook_path)
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

### **Modificare i dati del grafico**

Puoi modificare i dati nelle cartelle di lavoro esterne nello stesso modo in cui apporti modifiche al contenuto delle cartelle di lavoro interne. Quando una cartella di lavoro esterna non può essere caricata, viene generata un’eccezione.

Questo esempio richiede `presentation.pptx` con un grafico come prima forma nella prima diapositiva e una cartella di lavoro esterna accessibile. Imposta il valore basato sulla cella del primo punto dati nella prima serie a 100 e salva la presentazione in `presentation_out.pptx`. Modificare i valori delle celle può aggiornare il file XLSX esterno collegato, quindi usa una copia se devi preservare la cartella di lavoro originale.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        series = chart.chart_data.series
        if len(series) > 0 and len(series[0].data_points) > 0:
            value_cell = series[0].data_points[0].value.as_cell
            if value_cell is not None:
                value_cell.value = 100
                presentation.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
```

### **Recuperare una cartella di lavoro dalla cache del grafico**

Se un grafico utilizza una cartella di lavoro esterna mancante o non disponibile, Aspose.Slides può ricostruire la cartella di lavoro del grafico dai dati memorizzati nella cache della presentazione. Crea [LoadOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/), configura la sua [spreadsheet_options](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/spreadsheet_options/), e imposta [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/it/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) su `True` prima di aprire la presentazione.

Il seguente esempio Python apre `presentation.pptx`, il cui primo elemento nella prima diapositiva deve essere un grafico che fa riferimento a una cartella di lavoro esterna non disponibile, e accede ai dati recuperati tramite [Chart.chart_data](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/chart_data/) e [ChartData.chart_data_workbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        recovered_workbook = chart.chart_data.chart_data_workbook

        # Leggi o modifica i dati del workbook recuperato qui.
    else:
        print("The first shape is not a chart.")
```

Se la cartella di lavoro esterna è non disponibile e il recupero è disabilitato, Aspose.Slides genera un’eccezione. Abilita il recupero solo quando l’uso dei dati del grafico memorizzati nella cache è un’alternativa accettabile, poiché la cache potrebbe non contenere le modifiche apportate alla cartella di lavoro esterna dopo l’ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un grafico specifico è collegato a una cartella di lavoro esterna o incorporata?**

Sì. Un grafico ha un [data source type](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/data_source_type/) e un [path to an external workbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/external_workbook_path/); se la sorgente è una cartella di lavoro esterna, puoi leggere il percorso completo per assicurarti che venga usato un file esterno.

**I percorsi relativi alle cartelle di lavoro esterne sono supportati e come vengono memorizzati?**

Sì. Se specifichi un percorso relativo, viene convertito automaticamente in un percorso assoluto. La presentazione memorizza il percorso assoluto nel file PPTX, quindi spostare la cartella di lavoro potrebbe richiedere l’aggiornamento del collegamento.

**Posso utilizzare cartelle di lavoro situate su risorse di rete/condivisioni?**

Sì, tali cartelle di lavoro possono essere usate come fonte dati esterna. Tuttavia, la modifica diretta di cartelle di lavoro remote da Aspose.Slides non è supportata: possono essere utilizzate solo come sorgente.

**Aspose.Slides sovrascrive il file XLSX esterno quando salva la presentazione?**

La presentazione memorizza un [link al file esterno](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Modificare i dati del grafico basati su celle può anche aggiornare il file XLSX locale collegato. Usa una copia della cartella di lavoro se l’originale deve rimanere invariato.

**Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password durante il collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio, usando [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) e collegarsi a quella copia.

**Possono più grafici fare riferimento alla stessa cartella di lavoro esterna?**

Sì. Ogni grafico memorizza il proprio collegamento. Se tutti puntano allo stesso file, l’aggiornamento di quel file verrà riflesso in ogni grafico al successivo caricamento dei dati.