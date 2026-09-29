---
title: Gestire le Serie di Dati del Grafico nelle Presentazioni in Python
linktitle: Serie di Dati
type: docs
url: /it/python-net/chart-series/
keywords:
- serie di grafico
- sovrapposizione serie
- colore serie
- colore categoria
- nome serie
- punto dati
- spazio serie
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Impara come gestire le serie di grafico, i punti dati, le celle della cartella di lavoro, la formattazione, la sovrapposizione, la larghezza dello spazio e i valori negativi nelle presentazioni con Python."
---
## **Panoramica**

Un grafico memorizza i dati tracciati in una cartella di lavoro dei dati del grafico. Un [ChartSeries](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartseries/) rappresenta un insieme di valori correlati, e ogni [ChartDataPoint](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdatapoint/) nella serie si riferisce a una o più celle della cartella di lavoro. Gli oggetti [ChartCategory](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartcategory/) forniscono le etichette o i valori di raggruppamento condivisi dalla serie. Il nome della serie, le categorie e i valori dei punti sono quindi collegati a oggetti [ChartDataCell](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdatacell/) anziché essere memorizzati solo come testo di visualizzazione.

Per un tipico grafico a categorie, la cartella di lavoro predefinita utilizza la riga 0 per i nomi delle serie, la colonna 0 per i nomi delle categorie e le celle rimanenti per i valori delle serie. Gli indici di foglio di lavoro, riga e colonna passati a [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) sono basati su zero. Questo layout è utile quando si crea un grafico con dati predefiniti, ma non si deve presumere che ogni grafico esistente lo utilizzi. Per una presentazione caricata, ispezionare le celle a cui fanno riferimento le serie, le categorie e i punti dati prima di modificare i valori della cartella di lavoro.

Le impostazioni del grafico hanno tre ambiti diversi:

- Impostazioni a livello di serie, come [ChartSeries.format](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartseries/format/), forniscono l'aspetto predefinito per tutti i punti di una serie.
- Impostazioni a livello di punto dati, come [ChartDataPoint.format](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdatapoint/format/), sovrascrivono l'aspetto della serie per un punto.
- Le impostazioni di gruppo si applicano a serie compatibili che appartengono allo stesso [ChartSeriesGroup](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartseriesgroup/). Accedere al gruppo tramite [ChartSeries.parent_series_group](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartseries/parent_series_group/) quando è necessario impostare opzioni come la sovrapposizione o la larghezza dello spazio.

Quando non è impostato alcun riempimento esplicito per punto o serie, lo stile e il tema del grafico determinano l'aspetto automatico. Quando sono presenti sia la formattazione della serie sia quella del punto, la formattazione del punto prevale per quel punto.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Imposta la sovrapposizione della serie del grafico**

[ChartSeries.overlap](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartseries/overlap/) indica quanto le barre o le colonne si sovrappongono in un grafico 2D, da -100 a 100 percento. È una proiezione di sola lettura dell'impostazione sul gruppo di serie genitore. Impostare [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartseriesgroup/overlap/) per aggiornare tutte le serie compatibili in quel gruppo. Questa opzione si applica ai tipi di grafico che visualizzano barre o colonne raggruppate; non influisce sui gruppi di serie non correlati in un grafico combinato.

L'esempio seguente imposta la sovrapposizione per il gruppo che contiene la prima serie:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Il nuovo grafico contiene serie, categorie e valori di esempio.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![The series overlap](series_overlap.png)

## **Modifica il colore di riempimento della serie**

Usare [ChartSeries.format](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartseries/format/) per impostare il riempimento predefinito per un'intera serie. Se un punto ha già un riempimento esplicito, la sua impostazione [ChartDataPoint.format](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdatapoint/format/) sovrascrive il riempimento della serie per quel punto.

L'esempio seguente applica un riempimento solido blu alla prima serie:

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

![The color of the series](series_color.png)

## **Modifica il nome della serie**

Il nome di una serie è memorizzato nella cartella di lavoro dei dati del grafico e viene normalmente visualizzato nella legenda. Nella cartella di lavoro predefinita creata per un grafico a colonne raggruppate, la cella B1 è alla riga 0, colonna 1 e contiene il nome della prima serie. Le costanti denominate nell'esempio seguente rendono esplicita tale struttura:

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

È anche possibile aggiornare la cella già referenziata da [ChartSeries.name](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartseries/name/). Questo approccio evita di assumere una riga e una colonna particolari in un grafico esistente:

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

![The series name](series_name.png)

## **Ottieni il colore di riempimento automatico della serie**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) restituisce il colore calcolato dall'indice della serie e dallo stile del grafico. Questo è il colore usato quando il riempimento della serie non è stato definito esplicitamente. Chiamare il metodo legge il colore calcolato; non assegna un nuovo riempimento.

L'esempio seguente stampa il colore automatico di ciascuna serie predefinita:

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

## **Imposta il colore di riempimento invertito per una serie del grafico**

Per serie a barre, colonne e bolle, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartseries/invert_if_negative/) può visualizzare i valori negativi con un riempimento diverso. Impostare il riempimento regolare della serie su solido, abilitare l'inversione e assegnare il colore per valori negativi tramite [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). I numeri negativi rimangono invariati nella cartella di lavoro; cambia solo il colore di visualizzazione.

L'esempio seguente sostituisce i dati del grafico predefiniti con una sola serie. La riga 0 del foglio contiene il nome della serie, la colonna 0 contiene i nomi delle categorie e la colonna 1 contiene i valori:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

È possibile abilitare l'inversione per un singolo punto tramite [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Nell'esempio seguente l'inversione è disabilitata per la serie e abilitata solo per il punto selezionato. Al punto è anche assegnato un valore negativo affinché l'effetto sia visibile:

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

## **Cancella un valore specifico del punto dati**

Per rendere vuoto un punto senza rimuovere gli altri punti, impostare la cella di supporto della cartella di lavoro su `None`. Per un grafico a colonne, il valore tracciato è disponibile tramite [ChartDataPoint.value](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdatapoint/value/). Il punto dati rimane nella stessa posizione di categoria, ma il grafico tratta il suo valore come vuoto secondo le impostazioni del grafico per i valori vuoti.

L'esempio seguente cancella solo il secondo punto nella prima serie:

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

I grafici a dispersione usano celle X e Y separate, e i grafici a bolle usano anche una cella di dimensione. Cancellare solo la cella che rappresenta il valore che si desidera rimuovere. Non chiamare [ChartDataPointCollection.clear](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdatapointcollection/clear/) quando si vuole mantenere gli altri punti, perché quel metodo rimuove tutti i punti dati dalla collezione.

## **Controlla la visualizzazione delle celle vuote**

Le celle nascoste che contengono valori sono un caso separato dalle celle vuote. Per includere o escludere dati da righe e colonne nascoste del foglio di lavoro, vedere [Includi dati da righe e colonne nascoste](/slides/it/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Una cella vuota della cartella di lavoro rappresenta dati mancanti; una cella contenente `0` rappresenta un valore numerico noto. Impostare [ChartDataCell.value](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdatacell/value/) su `None` per rendere una cella vuota. Uno zero numerico rimane zero indipendentemente dall'impostazione delle celle vuote.

Usare [Chart.display_blanks_as](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/display_blanks_as/) per scegliere come il grafico visualizza le celle vuote. Questa impostazione si applica all'intero grafico. Cambia il modo in cui i vuoti vengono tracciati, senza riempire la cella vuota della cartella di lavoro con zero o un valore interpolato.

L'esempio autonomo seguente crea un grafico a linee con una serie, cancella il valore per il Giorno 3 e salva lo stesso grafico con ciascuna modalità. Non è necessario alcun file di input. Il [ChartDataWorkbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdataworkbook/) usa il foglio 0, colonna 0 per le etichette delle categorie e colonna 1 per i valori; la riga 0 contiene il nome della serie. I dati finali sono `10, 20, empty, 30, 40`.

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

Ogni file di output memorizza la modalità assegnata prima del salvataggio: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` e `empty_cells_Span.pptx`. Per salvare una sola versione, assegnare la modalità desiderata e salvare la presentazione una volta invece di iterare sulle modalità.

Il confronto sottostante mostra gli stessi dati in tutti e tre i file. Il Giorno 3 è vuoto nella cartella di lavoro in ogni caso:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

L'effetto visibile dipende dal tipo di grafico. Un grafico a linee rende facili da confrontare tutte e tre le modalità. I grafici a barre e a colonne non hanno una linea da connettere attraverso una categoria mancante, quindi `SPAN` non può produrre il segmento di collegamento mostrato sopra; una colonna mancante e una colonna di altezza zero possono anche apparire simili. Analogamente, un grafico a dispersione con solo marcatori non ha linea di collegamento. Non ci si deve aspettare tre risultati distinti per ogni tipo di grafico; verificare l'output per il tipo utilizzato.

## **Imposta la larghezza dello spazio della serie**

La larghezza dello spazio è lo spazio tra gruppi adiacenti di barre o colonne, espresso in percentuale della larghezza della barra o della colonna. Come la sovrapposizione, appartiene al gruppo di serie genitore piuttosto che a una singola serie. Impostare [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) una volta per il gruppo. Un valore più grande crea più spazio tra i gruppi; un valore più piccolo li rende più densi.

L'esempio seguente modifica la larghezza dello spazio e salva solo la presentazione finale:

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

![The gap width](gap_width.png)

## **FAQ**

**Quali tipi di grafico supportano le serie di dati?**

Tutti i tipi di grafico rappresentati dall'enumerazione [ChartType](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/charttype/) utilizzano dati del grafico, ma le loro serie non hanno tutte la stessa struttura di valori o le stesse impostazioni. Ad esempio, i grafici a categorie usano categorie e valori, i grafici a dispersione usano valori X e Y, e i grafici a bolle aggiungono dimensioni delle bolle. Utilizzare il metodo di creazione del punto dati che corrisponde al tipo di serie. Opzioni come sovrapposizione e larghezza dello spazio si applicano solo a gruppi di barre o colonne compatibili.

**Che cos'è un gruppo di serie del grafico?**

Un [ChartSeriesGroup](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartseriesgroup/) contiene serie compatibili che condividono impostazioni di tracciamento a livello di gruppo. Un grafico combinato può contenere più di un gruppo, quindi modificare il gruppo raggiunto tramite una serie non cambia necessariamente tutte le serie del grafico.

**Un grafico appena creato contiene dati predefiniti?**

Sì. Per impostazione predefinita, [ShapeCollection.add_chart](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/add_chart/) crea serie, categorie e valori di esempio. È possibile modificare quelle celle o cancellare sia le collezioni di serie sia quelle di categorie prima di aggiungere un set di dati completamente personalizzato. Un overload può anche creare un grafico senza dati predefiniti.

**Come sono collegati gli oggetti del grafico alle celle della cartella di lavoro?**

I nomi delle serie, le etichette delle categorie e i valori dei punti dati fanno riferimento a celle in un [ChartDataWorkbook](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdataworkbook/). Modificare una cella referenziata aggiorna l'elemento corrispondente del grafico. Quando si costruiscono dati personalizzati, mantenere le righe delle categorie e le righe dei valori delle serie allineate in modo che ogni punto venga tracciato sotto la categoria prevista.

**Come faccio a cancellare un solo punto invece dell'intera serie?**

Impostare la cella di valore pertinente su `None` per mantenere la posizione di categoria del punto come punto vuoto. Utilizzare [ChartDataPointCollection.clear](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdatapointcollection/clear/) solo quando si intende rimuovere tutti i punti da quella serie. Se si rimuovono anche le categorie, aggiornare ogni serie affinché i valori rimangano allineati con la collezione di categorie.

**Come vengono visualizzati i punti vuoti?**

Il risultato dipende dal tipo di grafico e da [Chart.display_blanks_as](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/display_blanks_as/). I grafici supportati possono visualizzare i vuoti come spazi, come valori zero o collegando i punti vicini. Scegliere l'impostazione che corrisponde al significato dei dati mancanti nella presentazione. Vedere [Controlla la visualizzazione delle celle vuote](#control-the-display-of-empty-cells) per un esempio completo e un confronto visivo.

**Come vengono formattati i valori negativi?**

Per le serie a barre, colonne e bolle supportate, abilitare [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartseries/invert_if_negative/) e impostare [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). È possibile sovrascrivere il comportamento per un punto individuale con [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Queste proprietà influenzano la formattazione, non i valori numerici memorizzati.

**Quale formattazione prevale quando sia una serie sia un punto sono formattati?**

La formattazione esplicita del punto dati prevale per quel punto. Gli altri punti continuano a usare la formattazione esplicita della serie o, quando la formattazione della serie non è definita, lo stile e il tema automatici del grafico. Le proprietà di gruppo come sovrapposizione e larghezza dello spazio controllano il layout e non sono sovrascritture di formattazione a livello di punto.

**Esiste un limite al numero di serie che un grafico può contenere?**

Aspose.Slides non impone un limite fisso separato al conteggio delle serie. In pratica, i vincoli del file di presentazione, la memoria disponibile, il tempo di rendering e la leggibilità del grafico determinano un limite pratico.

**Cosa devo modificare quando le colonne sono troppo vicine o troppo distanti?**

Impostare [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) sul gruppo di serie genitore appropriato. Aumentare il valore per ampliare lo spazio tra i gruppi, o diminuirlo per avvicinare i gruppi.