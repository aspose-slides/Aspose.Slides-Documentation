---
title: Gestisci le cartelle di lavoro dei grafici nelle presentazioni con Python
linktitle: Cartella di lavoro del grafico
type: docs
weight: 70
url: /it/python-net/chart-workbook/
keywords:
- cartella di lavoro del grafico
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
- Python
- Aspose.Slides
description: "Scopri Aspose.Slides per Python via .NET: gestisci facilmente le cartelle di lavoro dei grafici in formati PowerPoint e OpenDocument per semplificare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con le cartelle di lavoro dei grafici in Aspose.Slides. Mostra come leggere e scrivere dati di grafico tramite flussi di workbook, usare le celle del workbook come etichette dei dati del grafico, accedere alle collezioni di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Copre anche l'utilizzo di cartelle di lavoro esterne come sorgenti dati per i grafici. Gli esempi dimostrano come creare e assegnare una cartella di lavoro esterna, recuperare il percorso di una cartella di lavoro esterna collegata a un grafico e modificare i dati del grafico quando il workbook è disponibile.

## **Leggere e scrivere dati di grafico da una cartella di lavoro**

Aspose.Slides fornisce metodi per leggere e scrivere i workbook dei dati del grafico (che contengono dati di grafico modificati con Aspose.Cells). **Nota:** i dati del grafico devono essere organizzati nello stesso modo o avere una struttura simile a quella della sorgente.

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

## **Impostare una cella di WorkBook come etichetta dei dati del grafico**

A volte è necessario avere etichette del grafico che provengono direttamente dalle celle del workbook di dati sottostante. Aspose.Slides consente di associare le etichette dei dati a celle specifiche del workbook in modo che il testo dell'etichetta rifletta sempre il valore della cella. L'esempio seguente mostra come abilitare le etichette basate su valore‑cellula e indirizzare le etichette selezionate verso celle personalizzate nel workbook del grafico.

1. Crea un'istanza della classe [Presentation](https://docs.aspose.com/slides/it/python-net/api-reference/aspose.slides/presentation/).
1. Ottieni un riferimento alla diapositiva per indice.
1. Aggiungi un grafico a bolle con dati di esempio.
1. Accedi alla serie del grafico.
1. Usa una cella di workbook come etichetta dei dati.
1. Salva la presentazione.

Il seguente codice Python mostra come impostare una cella di workbook come etichetta dei dati del grafico:

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

Il seguente codice Python dimostra come utilizzare la proprietà `worksheets` per accedere alla collezione di fogli di lavoro:

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

## **Rilevare formati di cartella di lavoro incorporati non supportati**

Aspose.Slides non supporta il formato di cartella di lavoro Excel binario (.xlsb) che può essere incorporato in alcuni grafici. È possibile utilizzare la proprietà `embedded_workbook_type` su [ChartData](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/) insieme all'enumerazione [WorkbookType](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/workbooktype/) per rilevare formati non supportati e saltare quei grafici.

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
            # Il workbook incorporato è in formato .xlsb, che non è supportato.
            continue

        # Leggi o modifica i dati del workbook del grafico qui.
```

## **Cartelle di lavoro esterne**

Aspose.Slides supporta l'uso di cartelle di lavoro esterne come origine dati per i grafici.

### **Impostare cartelle di lavoro esterne**

Utilizzando il metodo [ChartData.set_external_workbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/set_external_workbook/) è possibile assegnare una cartella di lavoro esterna a un grafico come sua origine dati. Questo metodo può anche aggiornare il percorso di una cartella di lavoro esterna se è stata spostata.

Sebbene non sia possibile modificare i dati in workbook salvati su posizioni o risorse remote, è comunque possibile usare tali workbook come fonti dati esterne. Se si fornisce un percorso relativo per una cartella di lavoro esterna, questo viene convertito automaticamente in un percorso assoluto.

Il seguente codice Python mostra come impostare una cartella di lavoro esterna:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Il parametro `update_chart_data` del metodo [set_external_workbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/set_external_workbook/) specifica se il workbook Excel verrà caricato.

- Quando `update_chart_data` è impostato su `False`, viene aggiornato solo il percorso del workbook; i dati del grafico non vengono caricati né aggiornati dal workbook di destinazione. Utilizza questa impostazione quando il workbook di destinazione non esiste o non è disponibile.
- Quando `update_chart_data` è impostato su `True`, i dati del grafico vengono caricati e aggiornati dal workbook di destinazione.

### **Creare cartelle di lavoro esterne**

Utilizzando i metodi [read_workbook_stream](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) e [set_external_workbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/set_external_workbook/) è possibile creare una cartella di lavoro esterna da zero o convertire un workbook interno in uno esterno.

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

### **Ottenere il percorso del workbook di origine dati esterno per un grafico**

A volte i dati di un grafico sono collegati a un workbook Excel esterno anziché ai dati incorporati nella presentazione. Con Aspose.Slides è possibile ispezionare l'origine dati del grafico e, se si tratta di un workbook esterno, leggere il percorso completo del workbook.

1. Crea un'istanza della classe [Presentation](https://docs.aspose.com/slides/it/python-net/api-reference/aspose.slides/presentation/).
1. Ottieni un riferimento alla diapositiva per indice.
1. Ottieni un riferimento alla forma del grafico.
1. Recupera la sorgente ([ChartDataSourceType](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdatasourcetype/)) che rappresenta l'origine dati del grafico.
1. Verifica se il tipo di sorgente corrisponde al tipo di origine dati di un workbook esterno.

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

È possibile modificare i dati in workbook esterni allo stesso modo in cui si modificano i dati in workbook interni. Se un workbook esterno non può essere caricato, viene sollevata un'eccezione.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Recuperare una cartella di lavoro dalla cache del grafico**

Se un grafico utilizza un workbook esterno mancante o non disponibile, Aspose.Slides può ricostruire il workbook del grafico dai dati memorizzati nella presentazione. Crea un'istanza di [LoadOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/), quindi abilita [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/it/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) tramite [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/spreadsheet_options/) prima di aprire la presentazione.

Il seguente esempio Python apre una presentazione il cui grafico fa riferimento a un workbook esterno non disponibile e accede ai dati recuperati tramite [Chart.chart_data](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/chart_data/) e [ChartData.chart_data_workbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Leggi o modifica i dati del workbook recuperato qui.
```

Se il workbook esterno è non disponibile e il recupero è disabilitato, Aspose.Slides solleva un'eccezione. Abilita il recupero solo quando l'uso dei dati del grafico memorizzati nella cache è un'alternativa accettabile, poiché la cache potrebbe non contenere le modifiche apportate al workbook esterno dopo l'ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un grafico specifico è collegato a un workbook esterno o incorporato?**

Sì. Un grafico possiede un [tipo di origine dati](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/data_source_type/) e un [percorso a un workbook esterno](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/external_workbook_path/); se la sorgente è un workbook esterno, è possibile leggere il percorso completo per verificare che venga utilizzato un file esterno.

**Sono supportati percorsi relativi a workbook esterni e come vengono memorizzati?**

Sì. Se specifichi un percorso relativo, questo viene convertito automaticamente in un percorso assoluto. È comodo per la portabilità del progetto; tuttavia, la presentazione memorizzerà il percorso assoluto nel file PPTX.

**Posso usare workbook situati su risorse di rete/condivisioni?**

Sì, tali workbook possono essere usati come origine dati esterna. Tuttavia, la modifica diretta di workbook remoti da Aspose.Slides non è supportata: possono essere usati solo come sorgente.

**Aspose.Slides sovrascrive il file XLSX esterno quando salva la presentazione?**

No. La presentazione memorizza un [link al file esterno](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/external_workbook_path/) e lo utilizza per la lettura dei dati. Il file esterno stesso non viene modificato al salvataggio della presentazione.

**Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password al collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio, usando [Aspose.Cells](/cells/python-net/)) e collegarsi a quella copia.

**Più grafici possono fare riferimento allo stesso workbook esterno?**

Sì. Ogni grafico memorizza il proprio link. Se tutti puntano allo stesso file, l'aggiornamento di quel file verrà riflesso in ciascun grafico al successivo caricamento dei dati.