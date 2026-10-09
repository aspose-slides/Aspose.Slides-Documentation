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
- Aspose.Slides
description: "Scopri Aspose.Slides per Python via .NET: gestisci facilmente le cartelle di lavoro dei grafici in PowerPoint e nei formati OpenDocument per ottimizzare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con le cartelle di lavoro dei grafici in Aspose.Slides. Mostra come leggere e scrivere dati del grafico tramite flussi di cartelle di lavoro, usare le celle della cartella di lavoro come etichette dei dati del grafico, accedere alle collezioni di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Copre inoltre l'utilizzo di cartelle di lavoro esterne come origini dati dei grafici. Gli esempi dimostrano come creare e assegnare una cartella di lavoro esterna, recuperare il percorso di una cartella di lavoro esterna collegata a un grafico e modificare i dati del grafico quando la cartella di lavoro è disponibile.

Per le celle della cartella di lavoro che rappresentano dati mancanti, vedere [Controllare la visualizzazione delle celle vuote](/slides/it/python-net/chart-series/) per la differenza tra una cella vuota e zero, e un confronto a linee dei vari modi di visualizzazione disponibili.

## **Includere dati da righe e colonne nascoste**

Usa [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) per controllare se un grafico traccia dati da righe e colonne nascoste del foglio di lavoro. Impostalo su `True` per tracciare solo le celle visibili, o su `False` per includere sia le celle visibili sia quelle nascoste. Questa impostazione controlla il tracciamento del grafico; non nasconde né rende visibili le righe o le colonne del foglio di lavoro.

La [presentazione di esempio](hidden-source-data.pptx) contiene un grafico a colonne come prima forma nella prima diapositiva. Il foglio di lavoro incorporato, `Sheet1`, contiene l’intervallo di origine `A1:C4`. La riga 3 e la colonna C sono nascoste, ma le loro celle contengono ancora valori.

| Riga del foglio | A: Mese | B: Vendita al dettaglio | C: Vendita all’ingrosso (colonna nascosta) |
| --- | --- | --- | --- |
| 2 | gennaio | 10 | 30 |
| 3 (riga nascosta) | febbraio | 40 | 60 |
| 4 | marzo | 20 | 50 |

Accedi alle celle di origine tramite [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) e leggi [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) per verificare lo stato di nascondimento. Questa proprietà è di sola lettura. In questo file, B2 è visibile, B3 appartiene alla riga nascosta e C2 appartiene alla colonna nascosta; l’esempio stampa `False`, `True` e `True`, rispettivamente.

Per questo esempio, aggiorna i dati del grafico dopo aver modificato l’impostazione di tracciamento: mantieni la cartella di lavoro incorporata con [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) e ricaricala con [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). Quando includi tutte le celle, usa anche [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) per ripristinare l’intervallo completo, includendo la categoria di febbraio nascosta. Cambiare semplicemente il flag non è sufficiente per aggiornare i dati del grafico memorizzati nella cache di questo esempio e le etichette delle categorie.

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

            # Aggiorna i dati del grafico dal workbook incorporato.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Ripristina l'intervallo di origine completo, incluse le categorie nascoste.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

L’esempio salva due versioni della presentazione: una con solo i valori di vendita al dettaglio visibili (10 e 20), e un’altra con tutti e sei i valori. Le immagini sottostanti sono state generate dalle presentazioni salvate dopo averle riaperte; entrambi i file preservano l’impostazione di tracciamento assegnata. La riga 3 e la colonna C rimangono nascoste in entrambe le cartelle di lavoro incorporate.

| Solo celle visibili (`True`) | Tutte le celle (`False`) |
| --- | --- |
| ![Solo celle visibili: valori di vendita al dettaglio 10 e 20 per gennaio e marzo.](hidden_cells_True.png) | ![Tutte le celle: valori di vendita al dettaglio e all’ingrosso per gennaio, febbraio e marzo.](hidden_cells_False.png) |

Una cella nascosta contenente un valore è diversa da una cella vuota. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) controlla come vengono visualizzati i valori mancanti; non include né esclude i dati di origine nascosti. Vedi [Controllare la visualizzazione delle celle vuote](/slides/it/python-net/chart-series/#control-the-display-of-empty-cells) per un esempio.

## **Recuperare l’intervallo di dati di un grafico**

Prima di aggiornare i dati della cartella di lavoro in una presentazione esistente, esamina gli intervalli di origine per identificare quali celle del foglio di lavoro utilizza ciascun grafico. Il metodo [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) restituisce l’intervallo di dati corrente come formula qualificata per foglio di lavoro, ad esempio `Sheet1!$A$1:$D$5`. Qui, `Sheet1` è il nome del foglio, `!` lo separa dall’intervallo di celle, e `$A$1:$D$5` identifica le celle da A1 a D5, inclusi. I segni di dollaro indicano riferimenti assoluti a righe e colonne.

Il metodo legge l’intervallo corrente senza modificare il grafico o la sua cartella di lavoro. Se il grafico non utilizza una cartella di lavoro come origine dati, solleva un’eccezione. Per ulteriori informazioni, vedere il [Riferimento API di ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/).

Questo esempio apre una presentazione e verifica le forme direttamente su ogni diapositiva per i grafici. Stampa il nome di ciascun grafico e il suo intervallo di origine. Se l’intervallo non può essere recuperato, stampa un messaggio diagnostico e continua con il grafico successivo.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                try:
                    data_range = shape.chart_data.get_range()
                    print(f"{shape.name}: {data_range}")
                except RuntimeError as error:
                    print(f"{shape.name}: Unable to retrieve the chart data range. {error}")
```

## **Leggere e scrivere dati del grafico da una cartella di lavoro**

Aspose.Slides for Python via .NET fornisce i metodi [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) e [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) che consentono di leggere e scrivere le cartelle di lavoro dei dati del grafico (contenenti dati del grafico modificati con Aspose.Cells). **Nota** che i dati del grafico devono essere organizzati nello stesso modo o devono avere una struttura simile a quella di origine.

Questo esempio utilizza una presentazione con un grafico come prima forma nella sua prima diapositiva. Legge la cartella di lavoro incorporata in un flusso, cancella le serie e le categorie esistenti e riscrive la stessa cartella di lavoro. Le modifiche rimangono in memoria; l’esempio non salva la presentazione.

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

Quando si sostituisce una cartella di lavoro incorporata con una modificata, il grafico mantiene le collezioni originali di serie e categorie. Questa discrepanza può causare il fallimento di [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) con un errore di indice fuori intervallo. Cancella le serie e le categorie esistenti prima di scrivere la cartella di lavoro aggiornata nel grafico. Questo esempio usa un grafico che è la prima forma nella prima diapositiva. Il commento indica dove avverrebbe la modifica della cartella di lavoro; l’esempio eseguibile riscrive la cartella di lavoro originale e convalida il layout in memoria.

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

Cancellare le collezioni rimuove i riferimenti a dati obsoleti prima che la cartella di lavoro venga riscritta. Ricostruisci eventuali mappature di serie e categorie necessarie per la cartella di lavoro aggiornata prima di utilizzare il grafico.

## **Impostare una cella della cartella di lavoro come etichetta dei dati del grafico**

Puoi usare il testo delle celle della cartella di lavoro come etichette dei dati del grafico.

Questo esempio aggiunge un grafico a bolle con dati predefiniti alla prima diapositiva di una presentazione esistente. Utilizza le celle A10:A12 sul foglio 0 per le prime tre etichette della prima serie, abilita le etichette dalle celle e salva la presentazione aggiornata.

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

La proprietà [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) fornisce l’accesso ai fogli di lavoro in una cartella di lavoro del grafico. Questo esempio crea un grafico a torta con dati predefiniti e stampa il nome di ciascun foglio di lavoro nella console.

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

Questo esempio crea un grafico a colonne 3D con dati predefiniti e imposta due nomi di serie usando origini dati diverse. Il primo nome usa una stringa letterale; il secondo usa la cella C1 sul foglio 0. L’enumerazione [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) seleziona l’origine per ciascun nome. L’esempio salva la presentazione con i nomi di serie aggiornati.

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

Aspose.Slides non supporta il formato di cartella di lavoro Excel binario (.xlsb) che può essere incorporato in alcuni grafici. Puoi usare la proprietà [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) su [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) insieme all’enumerazione [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) per rilevare i formati non supportati e saltare quei grafici. Questo esempio esamina le forme nella prima diapositiva di una presentazione esistente, ignora le forme non grafiche e stampa un messaggio diagnostico per ciascun grafico con una cartella di lavoro .xlsb incorporata.

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

Aspose.Slides supporta l’utilizzo di cartelle di lavoro esterne come origine dati per i grafici.

### **Creare una cartella di lavoro esterna**

Usa [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) e [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) per esportare una cartella di lavoro di un grafico incorporato in un file e collegare il grafico a quella cartella di lavoro esterna.

Questo esempio crea un grafico a torta con dati predefiniti ed esporta la sua cartella di lavoro. Chiude lo stream di output prima di assegnare la cartella di lavoro esterna come origine dati del grafico, quindi salva la presentazione collegata.

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

Utilizzando il metodo [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/), è possibile assegnare una cartella di lavoro esterna a un grafico come origine dati. Questo metodo può anche essere usato per aggiornare il percorso della cartella di lavoro esterna (se quest’ultima è stata spostata).

Sebbene non sia possibile modificare i dati nelle cartelle di lavoro archiviate in posizioni remote o risorse, è comunque possibile usarle come origine dati esterna. Se viene fornito un percorso relativo per la cartella di lavoro esterna, esso viene convertito automaticamente in un percorso assoluto.

Questo esempio utilizza una cartella di lavoro esterna il cui foglio denominato `Sheet1` contiene un nome di serie in B1, nomi di categoria in A2:A4 e valori numerici in B2:B4. L’esempio crea un grafico a torta, collega la cartella di lavoro e usa [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) per mappare A1:B4 su una serie e tre categorie. Salva la presentazione con il grafico collegato.

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

Il parametro `update_chart_data` di [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) controlla se la cartella di lavoro viene caricata.

* Quando `update_chart_data` è `False`, viene aggiornato solo il percorso della cartella di lavoro. I dati del grafico non vengono caricati né aggiornati dalla cartella di lavoro di destinazione, quindi la cartella di lavoro può non essere disponibile.
* Quando `update_chart_data` è `True`, i dati del grafico vengono aggiornati dalla cartella di lavoro di destinazione.

L’esempio seguente assegna un URL segnaposto con `update_chart_data` impostato su `False`. Mantiene i dati predefiniti del grafico a torta e salva la presentazione senza caricare la cartella di lavoro non disponibile.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Ottenere il percorso della cartella di lavoro esterna di un grafico**

Per identificare la cartella di lavoro collegata a un grafico, verifica se il grafico utilizza un’origine dati esterna e recupera il suo percorso.

Questo esempio esamina la prima forma nella prima diapositiva di una presentazione con una cartella di lavoro esterna collegata. Se è un grafico collegato a una cartella di lavoro esterna, stampa [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) nella console. Quindi salva una copia della presentazione.

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

È possibile modificare i dati nelle cartelle di lavoro esterne nello stesso modo in cui si modificano i contenuti delle cartelle di lavoro interne. Quando una cartella di lavoro esterna non può essere caricata, viene generata un’eccezione.

Questo esempio utilizza un grafico che è la prima forma nella prima diapositiva e che è collegato a una cartella di lavoro esterna accessibile. Imposta il valore basato sulla cella del primo punto dati della prima serie a 100 e salva la presentazione aggiornata. Modificare i valori delle celle può aggiornare il file XLSX esterno collegato, quindi usa una copia se devi conservare la cartella di lavoro originale.

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

### **Ripristinare una cartella di lavoro dalla cache del grafico**

Se un grafico utilizza una cartella di lavoro esterna mancante o non disponibile, Aspose.Slides può ricostruire la cartella di lavoro del grafico dai dati memorizzati nella cache della presentazione. Crea [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/), configura la sua [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/), e imposta [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) su `True` prima di aprire la presentazione.

Il seguente esempio Python ripristina i dati della cartella di lavoro per un grafico che è la prima forma nella prima diapositiva e fa riferimento a una cartella di lavoro esterna non disponibile. Accede ai dati recuperati tramite [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) e [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

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

Se la cartella di lavoro esterna non è disponibile e il recupero è disabilitato, Aspose.Slides solleva un’eccezione. Abilita il recupero solo quando l’utilizzo dei dati del grafico in cache è un’alternativa accettabile, perché la cache potrebbe non contenere le modifiche apportate alla cartella di lavoro esterna dopo l’ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un grafico specifico è collegato a una cartella di lavoro esterna o incorporata?**

Sì. Un grafico ha un [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) e un [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); se l’origine è una cartella di lavoro esterna, puoi leggere il percorso completo per assicurarti che venga utilizzato un file esterno.

**Sono supportati percorsi relativi a cartelle di lavoro esterne e come vengono memorizzati?**

Sì. Se specifichi un percorso relativo, viene convertito automaticamente in un percorso assoluto. La presentazione memorizza il percorso assoluto nel file PPTX, quindi lo spostamento della cartella di lavoro potrebbe richiedere l’aggiornamento del collegamento.

**Posso usare cartelle di lavoro situate su risorse di rete/condivisioni?**

Sì, tali cartelle di lavoro possono essere usate come origine dati esterna. Tuttavia, la modifica diretta di cartelle di lavoro remote da Aspose.Slides non è supportata — possono solo essere usate come fonte.

**Aspose.Slides sovrascrive l’XLSX esterno quando salva la presentazione?**

La presentazione memorizza un [link al file esterno](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Modificare i dati del grafico basati su celle può anche aggiornare il file XLSX locale collegato. Usa una copia della cartella di lavoro se l’originale deve rimanere invariato.

**Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password quando crea il collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decriptata (ad esempio, usando [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) e collegarsi a quella copia.

**Più grafici possono fare riferimento alla stessa cartella di lavoro esterna?**

Sì. Ogni grafico memorizza il proprio collegamento. Se tutti puntano allo stesso file, l’aggiornamento di quel file verrà riflesso in ciascun grafico al successivo caricamento dei dati.