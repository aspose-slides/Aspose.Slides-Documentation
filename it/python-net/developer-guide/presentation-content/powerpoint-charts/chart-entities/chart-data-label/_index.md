---
title: Gestisci le etichette dei dati del grafico nelle presentazioni con Python
linktitle: Etichetta dati
type: docs
url: /it/python-net/chart-data-label/
keywords:
- grafico
- etichetta dati
- precisione dei dati
- percentuale
- distanza etichetta
- posizione etichetta
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Impara ad aggiungere e formattare le etichette dei dati dei grafici nelle presentazioni PowerPoint usando Aspose.Slides per Python via .NET per diapositive più coinvolgenti."
---
## **Introduzione**

Le etichette dei dati visualizzano informazioni sulle serie del grafico e sui singoli punti dati, aiutando i lettori a identificare i valori e a comprendere il grafico. Questo articolo spiega come formattare i valori, visualizzare le percentuali, leggere il testo delle etichette, controllare le etichette oltre il valore massimo dell'asse, regolare la spaziatura delle etichette dell'asse delle categorie e posizionare le etichette di un grafico a torta.

## **Imposta la precisione dei dati nelle etichette dei grafici**

Utilizza [number_format_of_values](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartseries/number_format_of_values/) per formattare i valori delle serie. Questo esempio crea un grafico a linee con dati predefiniti, visualizza la sua tabella dati e abilita le etichette dei valori per la prima serie. Il formato `#,##0.00` mostra un separatore delle migliaia e due decimali senza modificare i valori sottostanti.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
    chart.has_data_table = True

    series = chart.chart_data.series[0]
    series.number_format_of_values = "#,##0.00"
    series.labels.default_data_label_format.show_value = True

    presentation.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Visualizza la percentuale come etichette**

Per un grafico a colonne impilate, calcola ogni valore come percentuale del totale della sua categoria e assegna il testo a [text_frame_for_overriding](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). Questo esempio utilizza i dati predefiniti del grafico e visualizza le percentuali con due decimali in un carattere da 8 punti. Le categorie con un totale pari a zero vengono saltate per evitare divisioni per zero. Ricalcola il testo personalizzato dell'etichetta se i dati del grafico cambiano.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)

    category_totals = [0.0] * len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for series in chart.chart_data.series:
            point_value = float(series.data_points[k].value.data)
            category_totals[k] += point_value

    for series in chart.chart_data.series:
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            label = series.data_points[j].label
            if category_totals[j] == 0:
                continue

            point_value = float(series.data_points[j].value.data)
            data_point_percent = point_value / category_totals[j] * 100

            portion = slides.Portion()
            portion.text = f"{data_point_percent:.2f} %"
            portion.portion_format.font_height = 8

            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(portion)

            label.data_label_format.show_value = True
            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta il simbolo di percentuale con le etichette dei dati del grafico**

Quando i valori sono memorizzati come frazioni, utilizza [number_format](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/datalabelformat/number_format/) per visualizzare le percentuali. Imposta [is_number_format_linked_to_source](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) a `False` per applicare la formattazione dell'etichetta in modo indipendente dalle celle di origine.

Questo esempio crea un grafico a colonne impilate al 100% con serie rossa e blu su quattro categorie. Ogni coppia di valori somma 1. Il formato etichetta `0.0%` visualizza 0.30 come 30.0%, mentre l'asse verticale utilizza due decimali. Entrambe le serie usano testo dell'etichetta bianco, da 10 punti.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [drawing.Color.red, drawing.Color.blue]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i in range(len(series_names)):
        series_cell = workbook.get_cell(worksheet_index, 0, i + 1, series_names[i])
        series = chart.chart_data.series.add(series_cell, chart.type)
        for j in range(4):
            value_cell = workbook.get_cell(worksheet_index, j + 1, i + 1, values[i][j])
            series.data_points.add_data_point_for_bar_series(value_cell)

        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = series_colors[i]

        label_format = series.labels.default_data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = False
        label_format.number_format = "0.0%"
        label_format.text_format.portion_format.font_height = 10
        label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.text_format.portion_format.fill_format.solid_fill_color.color = drawing.Color.white

    presentation.save("SetDataLabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Leggi il testo effettivo delle etichette dei dati**

Utilizza [get_actual_label_text](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) per recuperare il testo prodotto dalle impostazioni di un'etichetta dati. Questo è utile quando si estraggono le etichette per report, si cerca contenuto nella presentazione o si convalidano i grafici generati. Nell'esempio sotto, il formato predefinito [data label format](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/datalabelformat/) combina ogni nome di categoria, nome della serie e valore. Un punto formatta il suo valore come percentuale, e un altro usa testo personalizzato da [text_frame_for_overriding](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    for i, category_name in enumerate(["Q1", "Q2"]):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    north_cell = workbook.get_cell(0, 0, 1, "North")
    north = chart.chart_data.series.add(north_cell, chart.type)
    for i, value in enumerate([0.25, 0.75]):
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        north.data_points.add_data_point_for_bar_series(value_cell)

    south_cell = workbook.get_cell(0, 0, 2, "South")
    south = chart.chart_data.series.add(south_cell, chart.type)
    for i, value in enumerate([0.40, 0.60]):
        value_cell = workbook.get_cell(0, i + 1, 2, value)
        south.data_points.add_data_point_for_bar_series(value_cell)

    for series in chart.chart_data.series:
        label_format = series.labels.default_data_label_format
        label_format.show_category_name = True
        label_format.show_series_name = True
        label_format.show_value = True

    north.labels[1].data_label_format.is_number_format_linked_to_source = False
    north.labels[1].data_label_format.number_format = "0%"
    south.labels[0].text_frame_for_overriding.text = "Reviewed"

    for series in chart.chart_data.series:
        for point in series.data_points:
            label = point.label
            if not label.is_visible:
                continue

            label_text = label.get_actual_label_text()
            print(f"Value: {point.value.data}; label: {label_text}")
```

Il numero memorizzato in un punto dati rimane `0.75`, anche quando la sua etichetta mostra `75%` insieme ai nomi di categoria e di serie. Il testo personalizzato sostituisce il testo dell'etichetta generato. [get_actual_label_text](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) restituisce la stringa dell'etichetta risultante in entrambi i casi. Controlla [is_visible](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/datalabel/is_visible/) separatamente, come mostrato sopra, quando vuoi estrarre solo le etichette visibili.

## **Controlla le etichette dei dati oltre il valore massimo dell'asse**

Quando limiti manualmente l'intervallo di un asse, alcuni punti dati possono superare il valore massimo. Usa [show_data_labels_over_maximum](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) per controllare se le loro etichette dati vengono visualizzate. Questa impostazione cambia la visibilità dell'etichetta; non modifica l'intervallo dell'asse né i valori dei dati sottostanti.

L'esempio sotto crea un grafico a colonne raggruppate 2D con valori 60 e 120. Imposta [is_automatic_max_value](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/axis/is_automatic_max_value/) a `False` e [max_value](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/axis/max_value/) a 100 sull'asse verticale. La prima diapositiva consente etichette oltre il massimo; una copia di quella diapositiva le disabilita. Entrambe le diapositive vengono salvate in `DataLabelsOverMaximum.pptx`.

Abilita le etichette dei valori con [show_value](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/datalabelformat/show_value/). L'impostazione a livello di grafico non abilita la visualizzazione dei valori da sola né sovrascrive la visualizzazione disabilitata di un'etichetta individuale. Questo esempio abilita i valori per l'intera serie e utilizza [position](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/datalabelformat/position/) per posizionare le etichette all'estremità esterna di ogni colonna.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    first_category = workbook.get_cell(0, 1, 0, "Within range")
    second_category = workbook.get_cell(0, 2, 0, "Above maximum")

    chart.chart_data.categories.add(first_category)
    chart.chart_data.categories.add(second_category)

    series_name = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_name, chart.type)

    first_value = workbook.get_cell(0, 1, 1, 60)
    second_value = workbook.get_cell(0, 2, 1, 120)

    series.data_points.add_data_point_for_bar_series(first_value)
    series.data_points.add_data_point_for_bar_series(second_value)

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 100
    chart.show_data_labels_over_maximum = True

    second_slide = presentation.slides.add_clone(slide)
    second_chart = second_slide.shapes[0]
    second_chart.show_data_labels_over_maximum = False

    presentation.save("DataLabelsOverMaximum.pptx", slides.export.SaveFormat.PPTX)
```

Le immagini seguenti mostrano le diapositive salvate renderizzate da Microsoft PowerPoint. Con `True`, l'etichetta **120** è visibile al limite superiore; con `False`, è nascosta. L'etichetta **60** rimane visibile, il valore massimo dell'asse resta **100**, e il secondo punto dati rimane **120** in entrambi i casi.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![Grafico PowerPoint che mostra l'etichetta valore 120 con un massimo dell'asse di 100](data-labels-over-maximum-true.png) | ![Grafico PowerPoint che nasconde l'etichetta valore 120 con un massimo dell'asse di 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Questo esempio utilizza un grafico a colonne 2D con un asse dei valori. I grafici senza asse dei valori, come i grafici a torta e a ciambella, non hanno un valore massimo dell'asse da limitare in questo modo.
{{% /alert %}}

## **Imposta la distanza dell'etichetta da un asse**

Utilizza [label_offset](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/axis/label_offset/) per controllare la distanza tra le etichette dell'asse delle categorie e l'asse. Il valore è una percentuale della dimensione massima del carattere delle etichette dell'asse. Questo esempio crea un grafico a colonne raggruppate e imposta lo spostamento dell'etichetta dell'asse orizzontale a 500. Questa impostazione influisce sulle etichette dell'asse delle categorie piuttosto che sulle etichette associate ai singoli punti dati.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Regola la posizione dell'etichetta**

Su un grafico a torta, regola le posizioni delle etichette dati per migliorare la spaziatura e fare spazio alle linee guida.

Questo esempio visualizza il valore del primo punto dati, posiziona la sua etichetta all'esterno della fetta e regola gli offset [x](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/datalabel/x/) e [y](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/datalabel/y/). Questi offset sono relativi rispettivamente alla larghezza e all'altezza del grafico.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 200, 200)
    series = chart.chart_data.series

    label = series[0].labels[0]
    label.data_label_format.show_value = True
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Grafico a torta con una posizione dell'etichetta dati regolata](pie-chart-adjusted-label.png)

## **FAQ**

**Come posso evitare che le etichette dei dati si sovrappongano su grafici densi?**  
Combina il posizionamento automatico delle etichette, le linee guida e una dimensione del carattere ridotta; se necessario, nascondi alcuni campi (ad esempio la categoria) o mostra le etichette solo per i valori estremi o i punti chiave.

**Come posso disabilitare le etichette solo per valori zero, negativi o vuoti?**  
Filtra i punti dati prima di abilitare le etichette e disattiva la visualizzazione per valori pari a 0, valori negativi o valori mancanti secondo una regola definita.

**Come posso garantire uno stile di etichetta coerente quando esporto in PDF/immagini?**  
Imposta esplicitamente la famiglia e la dimensione del carattere e verifica che il carattere sia disponibile nell'ambiente di rendering per evitare il fallback.