---
title: Gestire le serie di dati del grafico nelle presentazioni in Python
linktitle: Serie di dati
type: docs
url: /it/python-net/chart-series/
keywords:
- serie di grafico
- sovrapposizione della serie
- colore della serie
- colore della categoria
- nome della serie
- punto dati
- intervallo della serie
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Impara come gestire le serie di grafici, i punti dati, le celle della cartella di lavoro, la formattazione, la sovrapposizione, la larghezza dello spazio e i valori negativi nelle presentazioni con Python."
---
## **Panoramica**

Un grafico può memorizzare i suoi valori tracciati nelle celle della cartella di lavoro o direttamente come letterali numerici. Un [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) rappresenta un insieme di valori correlati, e ogni [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) rappresenta un punto in quella serie. Gli oggetti [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) forniscono le etichette o i valori di raggruppamento condivisi dalle serie. Nei grafici creati con dati predefiniti, i nomi delle serie, le categorie e i valori dei punti utilizzano oggetti [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) della cartella di lavoro del grafico.

Per un tipico grafico a categorie, la cartella di lavoro predefinita usa la riga 0 per i nomi delle serie, la colonna 0 per i nomi delle categorie e le celle rimanenti per i valori delle serie. Gli indici di foglio di lavoro, riga e colonna passati a [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) sono basati su zero. Questo layout è utile quando si crea un grafico con dati predefiniti, ma non si assume che ogni grafico esistente lo utilizzi. Per una presentazione caricata, ispezionare le celle a cui fanno riferimento le serie, le categorie e i punti dati prima di modificare i valori della cartella di lavoro.

Le impostazioni del grafico hanno tre diversi ambiti:

- Impostazioni a livello di serie, come [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/), forniscono l’aspetto predefinito per tutti i punti di una serie.
- Impostazioni a livello di punto dati, come [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/), sovrascrivono l’aspetto della serie per un singolo punto.
- Le impostazioni di gruppo si applicano a serie compatibili che appartengono allo stesso [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/). Accedere al gruppo tramite [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) quando è necessario impostare opzioni come sovrapposizione o larghezza dello spazio.

Quando non è impostato alcun riempimento esplicito per punto o serie, lo stile e il tema del grafico determinano l’aspetto automatico. Quando sono presenti sia formattazioni della serie sia del punto, la formattazione del punto ha la precedenza per quel punto.

![serie-di-grafico-powerpoint](chart-series-powerpoint.png)

## **Imposta i valori della serie usando letterali numerici**

Utilizzare i letterali numerici quando i valori della serie provengono da dati o calcoli dell’applicazione e non richiedono riferimenti a celle del foglio di lavoro. Impostare [data_source_type_for_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_values/) su [DataSourceType.DOUBLE_LITERALS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) prima di assegnare a ogni punto il suo [value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) tramite [as_literal_double](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_literal_double/).

L’impostazione della raccolta controlla il tipo di origine di tutti i valori dei punti in quella serie. Il [value.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/basechartvalue/data_source_type/) di ciascun punto riporta il tipo selezionato; modificarlo tramite l’impostazione della raccolta. Con `WORKSHEET`, usare [as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_cell/) per accedere alla cella di riferimento. Con `DOUBLE_LITERALS`, usare `as_literal_double` per leggere o scrivere direttamente il numero.

L’esempio seguente crea un grafico a colonne con serie e categorie predefinite, quindi assegna valori calcolati di 10, 20, ecc. ai punti esistenti della prima serie. Salva la presentazione, la riapre e stampa i valori memorizzati.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    series = chart.chart_data.series[0]

    series.data_points.data_source_type_for_values = charts.DataSourceType.DOUBLE_LITERALS
    for i in range(len(series.data_points)):
        series.data_points[i].value.as_literal_double = (i + 1) * 10

    presentation.save("numeric_literals.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("numeric_literals.pptx") as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_chart = reopened_slide.shapes[0]
    reopened_series = reopened_chart.chart_data.series[0]
    for point in reopened_series.data_points:
        print(point.value.as_literal_double)
```

Il tipo di origine del valore del punto è separato da [ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/), che identifica la configurazione della cartella di lavoro interna o esterna del grafico. L’uso dei letterali numerici non rimuove, di per sé, la cartella di lavoro incorporata. In questo esempio, la cartella di lavoro rimane disponibile per le etichette delle categorie, i nomi delle serie e le altre serie. Vedere [Cartella di lavoro del grafico](/slides/it/python-net/chart-workbook/) per la gestione della cartella di lavoro.

Per i grafici a dispersione e a bolle, impostare [data_source_type_for_x_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_x_values/) e [data_source_type_for_y_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_y_values/) per scegliere le origini per [x_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/x_value/) e [y_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/y_value/). I grafici a bolle usano anche [data_source_type_for_bubble_sizes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_bubble_sizes/) per [bubble_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/bubble_size/). Impostare ogni origine applicabile su `DOUBLE_LITERALS` prima di assegnare numeri tramite la proprietà `as_literal_double` di quel valore.

## **Imposta la sovrapposizione delle serie del grafico**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) riporta quanto le barre o le colonne si sovrappongono in un grafico 2D, da -100 a 100 percento. È una proiezione in sola lettura dell’impostazione sul gruppo di serie padre. Impostare [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) per aggiornare tutte le serie compatibili in quel gruppo. Questa opzione si applica ai tipi di grafico che mostrano barre o colonne raggruppate; non influisce sui gruppi di serie non correlati in un grafico combinato.

L’esempio seguente imposta la sovrapposizione per il gruppo che contiene la prima serie:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Il nuovo grafico contiene serie di esempio, categorie e valori.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Sovrapposizione delle serie](series_overlap.png)

## **Modifica il colore di riempimento della serie**

Usare [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) per impostare il riempimento predefinito per un’intera serie. Se un punto ha già un riempimento esplicito, la sua impostazione [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) sovrascrive il riempimento della serie per quel punto.

L’esempio seguente applica un riempimento solido blu alla prima serie:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = drawing.Color.blue

    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Colore della serie](series_color.png)

## **Modifica il nome della serie**

Il nome di una serie è memorizzato nella cartella di lavoro del grafico ed è normalmente visualizzato nella legenda. Nella cartella di lavoro predefinita creata per un grafico a colonne raggruppate, la cella B1 (riga 0, colonna 1) contiene il nome della prima serie. Le costanti nominate nell’esempio seguente rendono esplicita quella struttura:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    workbook = chart.chart_data.chart_data_workbook
    series_name_cell = workbook.get_cell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

È possibile aggiornare anche la cella già referenziata da [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/). Questo approccio evita di assumere una riga o colonna specifica in un grafico esistente:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series_name_cell = series.name.as_cells[first_name_cell_index]
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Nome della serie](series_name.png)

### **Crea una serie con un nome proveniente da più celle**

Un nome di serie composito è utile quando il nome del prodotto e il periodo di riferimento sono memorizzati in celle di cartella di lavoro separate. Per esempio, è possibile combinare `Product A` in B1 e `2026` in C1 in un unico nome di serie mantenendo entrambi i componenti collegati alle loro celle di origine.

Usare [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) per recuperare l’intervallo di nome, quindi passare quella raccolta a [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/). L’argomento `skip_hidden_cells` controlla se includere le celle nascoste: `True` le esclude, `False` le include. Questo esempio usa `False` per includere ogni cella nell’intervallo di nome.

L’esempio seguente crea una presentazione con una serie e due punti dati. Le celle B1:C1 forniscono solo il nome della serie; A2:A3 forniscono le etichette delle categorie, e B2:B3 forniscono i valori numerici.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 620, 180)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = True

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Queste due celle forniscono il nome della serie.
    workbook.get_cell(0, 0, 1, "Product A")
    workbook.get_cell(0, 0, 2, "2026")
    name_cells = workbook.get_cell_collection("Sheet1!$B$1:$C$1", False)
    series = chart.chart_data.series.add(name_cells, charts.ChartType.CLUSTERED_COLUMN)

    # Celle separate forniscono le categorie e i punti dati numerici.
    north_category = workbook.get_cell(0, 1, 0, "North")
    south_category = workbook.get_cell(0, 2, 0, "South")
    chart.chart_data.categories.add(north_category)
    chart.chart_data.categories.add(south_category)
    north_value = workbook.get_cell(0, 1, 1, 120)
    south_value = workbook.get_cell(0, 2, 1, 150)
    series.data_points.add_data_point_for_bar_series(north_value)
    series.data_points.add_data_point_for_bar_series(south_value)

    presentation.save("composite_series_name.pptx", slides.export.SaveFormat.PPTX)
```

Il nome della serie risultante è `Product A 2026`, con uno spazio tra i due valori delle celle. La legenda lo visualizza come una singola voce per entrambe le colonne. L’immagine sotto è stata renderizzata dalla presentazione salvata:

![Grafico a colonne con valori Nord e Sud e il nome di serie composito Product A 2026 nella legenda](composite_series_name.png)

## **Ottieni il colore automatico di riempimento della serie**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) restituisce il colore calcolato in base all’indice della serie e allo stile del grafico. Questo è il colore usato quando il riempimento della serie non è stato definito esplicitamente. Chiamare il metodo legge il colore calcolato; non assegna un nuovo riempimento.

L’esempio seguente stampa il colore automatico di ciascuna serie predefinita:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series_count = len(chart.chart_data.series)
    for series_index in range(series_count):
        series = chart.chart_data.series[series_index]
        automatic_color = series.get_automatic_series_color()
        print(f"Series {series_index}: {automatic_color.name}")
```

Output di esempio per lo stile di grafico predefinito:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

I colori esatti dipendono dallo stile e dal tema del grafico.

## **Imposta il colore di riempimento invertito per una serie di grafico**

Per serie a barre, colonne e bolle, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) può visualizzare i valori negativi con un riempimento diverso. Impostare il riempimento normale della serie su solido, abilitare l’inversione e assegnare il colore per i valori negativi tramite [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). I numeri negativi rimangono invariati nella cartella di lavoro; solo il loro colore di visualizzazione cambia.

L’esempio seguente sostituisce i dati di grafico predefiniti con una serie. La riga 0 del foglio contiene il nome della serie, la colonna 0 i nomi delle categorie e la colonna 1 i valori:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    series = chart_data.series.add(series_name_cell, chart.type)

    category_count = len(category_names)
    for category_index in range(category_count):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.get_cell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.data_points.add_data_point_for_bar_series(value_cell)

    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.invert_if_negative = True
    series.inverted_solid_fill_color.color = drawing.Color.red

    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Colore di riempimento solido invertito](inverted_solid_fill_color.png)

È possibile abilitare l’inversione per un singolo punto tramite [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Nell’esempio seguente l’inversione è disabilitata per la serie e abilitata solo per il punto selezionato. Al punto è anche assegnato un valore negativo in modo che l’effetto sia visibile:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.inverted_solid_fill_color.color = drawing.Color.red
    series.invert_if_negative = False

    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = negative_value
    data_point.invert_if_negative = True

    presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **Cancella il valore di un punto dati specifico**

Per rendere vuoto un punto senza rimuovere gli altri, impostare la cella di supporto nella cartella di lavoro su `None`. Per un grafico a colonne, il valore tracciato è disponibile tramite [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/). Il punto dati rimane nella stessa posizione di categoria, ma il grafico lo tratta come vuoto secondo le impostazioni dei valori vuoti del grafico.

L’esempio seguente cancella solo il secondo punto della prima serie:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = None

    presentation.save("clear_data_point_value.pptx", slides.export.SaveFormat.PPTX)
```

I grafici a dispersione usano celle X e Y separate, e i grafici a bolle usano anche una cella di dimensione. Cancellare solo la cella che rappresenta il valore che si intende rimuovere. Non chiamare [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) quando si desidera mantenere gli altri punti, perché quel metodo rimuove tutti i punti dati dalla raccolta.

## **Controlla la visualizzazione delle celle vuote**

Le celle nascoste che contengono valori costituiscono un caso distinto dalle celle vuote. Per includere o escludere i dati da righe e colonne nascoste del foglio di lavoro, vedere [Include Data from Hidden Rows and Columns](/slides/it/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Una cella vuota della cartella di lavoro rappresenta dati mancanti; una cella contenente `0` rappresenta un valore numerico noto. Impostare [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) su `None` per rendere una cella vuota. Uno zero numerico rimane zero indipendentemente dall’impostazione delle celle vuote.

Usare [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) per scegliere come il grafico visualizza le celle vuote. Questa impostazione si applica a tutto il grafico. Cambia il modo in cui i valori vuoti sono tracciati, senza riempire la cella vuota con zero o un valore interpolato.

L’esempio autonomo seguente crea un grafico a linee con una serie, cancella il valore per il Giorno 3 e salva lo stesso grafico con ciascuna modalità. Non è necessario alcun file di input. Il [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) usa il foglio 0, la colonna 0 per le etichette di categoria e la colonna 1 per i valori; la riga 0 contiene il nome della serie. I dati finali sono `10, 20, empty, 30, 40`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 40, 40, 640, 400)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(0, 0, 1, "Measurements")
    series = chart_data.series.add(series_name_cell, chart.type)
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Lascia il giorno 3 realmente vuoto, mantenendo la sua categoria e il punto dati.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Ogni file di output memorizza la modalità assegnata prima del salvataggio: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` e `empty_cells_Span.pptx`. Per salvare una sola versione, assegnare la modalità desiderata e salvare la presentazione una volta sola invece di iterare sulle modalità.

Il confronto sotto mostra gli stessi dati in tutti e tre i file. Il Giorno 3 è vuoto nella cartella di lavoro in ogni caso:

![Grafici a linee con dati identici: Gap interrompe la linea al Giorno 3, Zero abbassa la linea a zero, e Span collega il Giorno 2 al Giorno 4.](display_blanks_as.png)

L’effetto visibile dipende dal tipo di grafico. Un grafico a linee rende facile confrontare tutte e tre le modalità. I grafici a barre e a colonne non hanno una linea da collegare attraverso una categoria mancante, così `SPAN` non può produrre il segmento di collegamento mostrato sopra; una colonna mancante e una colonna di altezza zero possono anche apparire simili. Analogamente, un grafico a dispersione con soli marcatori non ha linea di collegamento. Non aspettate tre risultati distinti per ogni tipo di grafico; verificate l’output per il tipo che state utilizzando.

## **Imposta la larghezza dello spazio tra le serie**

La larghezza dello spazio è lo spazio tra cluster di barre o colonne adiacenti, espresso in percentuale della larghezza della barra o della colonna. Come la sovrapposizione, appartiene al gruppo di serie padre anziché a una singola serie. Impostare [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) una sola volta per il gruppo. Un valore più grande crea più spazio tra i cluster; un valore più piccolo li rende più densi.

L’esempio seguente modifica la larghezza dello spazio e salva solo la presentazione finale:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.gap_width = gap_width_percent

    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Larghezza dello spazio](gap_width.png)

## **FAQ**

**Quali tipi di grafico supportano serie di dati?**

Tutti i tipi di grafico rappresentati dall’enumerazione [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) utilizzano dati di grafico, ma le loro serie non hanno tutte la stessa struttura di valori o le stesse impostazioni. Per esempio, i grafici a categorie usano categorie e valori, i grafici a dispersione usano valori X e Y, e i grafici a bolle aggiungono le dimensioni delle bolle. Utilizzare il metodo di creazione del punto dati che corrisponde al tipo di serie. Opzioni come sovrapposizione e larghezza dello spazio si applicano solo a gruppi di barre o colonne compatibili.

**Che cos’è un gruppo di serie di grafico?**

Un [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) contiene serie compatibili che condividono impostazioni di tracciamento a livello di gruppo. Un grafico combinato può contenere più di un gruppo, così modificare il gruppo raggiunto tramite una serie non necessariamente modifica tutte le serie nel grafico.

**Un grafico appena creato contiene dati predefiniti?**

Sì. Per impostazione predefinita, [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) crea serie, categorie e valori di esempio. È possibile modificare quelle celle o cancellare sia le serie sia le collezioni di categorie prima di aggiungere un set di dati completamente personalizzato. Un overload può anche creare un grafico senza dati predefiniti.

**Come sono collegati gli oggetti del grafico alle celle della cartella di lavoro?**

I nomi delle serie, le etichette delle categorie e i valori dei punti dati fanno riferimento a celle in una [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/). Modificare una cella di riferimento aggiorna l’elemento corrispondente del grafico. Quando si costruiscono dati personalizzati, mantenere le righe delle categorie e le righe dei valori delle serie allineate in modo che ogni punto sia tracciato nella categoria prevista.

**Come cancello un punto invece dell’intera serie?**

Impostare la cella di valore pertinente su `None` per mantenere la posizione di categoria del punto come punto vuoto. Usare [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) solo quando si vuole rimuovere tutti i punti di quella serie. Se si rimuovono anche le categorie, aggiornare tutte le serie affinché i loro valori rimangano allineati con la collezione di categorie.

**Come vengono visualizzati i punti vuoti?**

Il risultato dipende dal tipo di grafico e da [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/). I grafici supportati possono visualizzare i vuoti come spazi, come valori zero o collegando i punti vicini. Scegliere l’impostazione che corrisponde al significato dei dati mancanti nella presentazione. Vedere [Controlla la visualizzazione delle celle vuote](#control-the-display-of-empty-cells) per un esempio completo e un confronto visivo.

**Come sono formattati i valori negativi?**

Per le serie a barre, colonne e bolle supportate, abilitare [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) e impostare [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). È possibile sovrascrivere il comportamento per un singolo punto con [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Queste proprietà influenzano la formattazione, non i valori numerici memorizzati.

**Quale formattazione prevale quando sia la serie sia il punto sono formattati?**

La formattazione esplicita del punto dati prevale per quel punto. Gli altri punti continuano a utilizzare la formattazione esplicita della serie o, se la formattazione della serie non è definita, lo stile e il tema automatici del grafico. Le proprietà di gruppo come sovrapposizione e larghezza dello spazio controllano il layout e non sono sovrascritture di formattazione a livello di punto.

**Esiste un limite al numero di serie che un grafico può contenere?**

Aspose.Slides non impone un limite fisso separato per il conteggio delle serie. In pratica, i limiti del file di presentazione, la memoria disponibile, il tempo di rendering e la leggibilità del grafico determinano un limite pratico.

**Cosa devo modificare quando le colonne sono troppo vicine o troppo distanti?**

Impostare [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) sul gruppo di serie padre appropriato. Aumentare il valore per allargare lo spazio tra i cluster, o diminuire il valore per avvicinarli.