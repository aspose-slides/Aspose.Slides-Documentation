---
title: Gestire le Etichette dei Dati del Grafico nelle Presentazioni con Python
linktitle: Etichetta Dati
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
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Impara a aggiungere e formattare le etichette dei dati dei grafici in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Python via .NET per slide più coinvolgenti."
---
## **Panoramica**

Le etichette dei dati su un grafico mostrano i dettagli sulla serie di dati del grafico o sui singoli punti dati. Consentono ai lettori di identificare rapidamente le serie di dati e rendono i grafici più facili da comprendere. In Aspose.Slides per Python, è possibile abilitare, personalizzare e formattare le etichette dei dati per qualsiasi grafico—scegliendo cosa visualizzare (valori, percentuali, nomi della serie o della categoria), dove posizionare le etichette e come appaiono (font, formato numerico, separatori, linee guida e altro). Questo articolo descrive le API essenziali e gli esempi necessari per aggiungere etichette chiare e informative ai tuoi grafici.

## **Imposta la Precisione delle Etichette dei Dati**

Le etichette dei dati di un grafico mostrano spesso valori numerici che richiedono una precisione coerente. Questa sezione mostra come controllare il numero di cifre decimali per le etichette dei dati in Aspose.Slides applicando un formato numerico appropriato.

Il seguente esempio Python mostra come impostare la precisione numerica per le etichette dei dati del grafico:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 500, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.number_format_of_values = "#,##0.00"

    presentation.save("data_label_precision.pptx", slides.export.SaveFormat.PPTX)
```

## **Visualizza le Percentuali come Etichette**

Con Aspose.Slides, è possibile visualizzare le percentuali come etichette dei dati sui grafici. L'esempio seguente calcola la quota di ciascun punto all'interno della sua categoria e formatta l'etichetta per mostrare la percentuale.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Crea un'istanza della classe Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 600, 400)
    series = chart.chart_data.series[0]

    total_for_categories = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for i in range(len(chart.chart_data.series)):
            total_for_categories[k] += chart.chart_data.series[i].data_points[k].value.data

    for i in range(len(chart.chart_data.series)):
        series = chart.chart_data.series[i]
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            data_point_percent = series.data_points[j].value.data / total_for_categories[j] * 100

            text_portion = slides.Portion()
            text_portion.text = "{0:.2f} %".format(data_point_percent)
            text_portion.portion_format.font_height = 8

            label = series.data_points[j].label
            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(text_portion)

            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    # Salva la presentazione contenente il grafico.
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```


## **Mostra il Simbolo Percentuale con le Etichette dei Dati del Grafico**

Questa sezione mostra come visualizzare le percentuali nelle etichette dei dati del grafico e includere il simbolo percentuale utilizzando Aspose.Slides. Imparerai a abilitare i valori percentuali per l'intera serie o per punti specifici (ideale per grafici a torta, a ciambella e impilati al 100%) e come controllare la formattazione tramite le opzioni dell'etichetta o un formato numerico personalizzato.

Il seguente esempio Python mostra come aggiungere il simbolo percentuale a un'etichetta dei dati del grafico:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# Crea un'istanza della classe Presentation.
with slides.Presentation() as presentation:

    # Ottieni un riferimento alla diapositiva per indice.
    slide = presentation.slides[0]

    # Crea un grafico PercentsStackedColumn sulla diapositiva.
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # Ottieni la cartella di lavoro dei dati del grafico.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # Aggiungi una nuova serie.
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # Imposta il colore di riempimento della serie.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Imposta le proprietà di formattazione delle etichette.
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # Aggiungi una nuova serie.
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # Imposta il tipo di riempimento e il colore.
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # Salva la presentazione.
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta la Distanza dell'Etichetta dall'Asse**

Questa sezione mostra come controllare la distanza tra le etichette dei dati e l'asse del grafico in Aspose.Slides. Regolare questo offset aiuta a prevenire sovrapposizioni e migliora la leggibilità in visualizzazioni dense.

Il seguente codice Python mostra come impostare la distanza dell'etichetta dall'asse delle categorie quando si lavora con un grafico basato sugli assi:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Crea un'istanza della classe Presentation.
with slides.Presentation() as presentation:
    # Ottieni un riferimento alla diapositiva.
    slide = presentation.slides[0]

    # Crea un grafico a colonne raggruppate sulla diapositiva.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Imposta la distanza dell'etichetta dall'asse delle categorie (orizzontale).
    chart.axes.horizontal_axis.label_offset = 500

    # Salva la presentazione.
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```


## **Regola la Posizione dell'Etichetta**

Quando crei un grafico che non utilizza assi, come un grafico a torta, le etichette dei dati possono essere troppo vicine al bordo. In tal caso, regola la posizione dell'etichetta in modo che le linee guida siano visualizzate correttamente.

Il seguente codice Python mostra come regolare la posizione dell'etichetta su un grafico a torta:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.show_leader_lines = True

    label = series.labels[0]
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    label.x = 0.05
    label.y = 0.1

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Posizione dell'etichetta modificata](changed_label_position.png)

## **FAQ**

**Come posso evitare la sovrapposizione delle etichette dei dati nei grafici densi?**

Combina il posizionamento automatico delle etichette, le linee guida e una dimensione del carattere ridotta; se necessario, nascondi alcuni campi (ad esempio la categoria) o visualizza le etichette solo per i punti estremi/chiave.

**Come posso disabilitare le etichette solo per valori zero, negativi o vuoti?**

Filtra i punti dati prima di abilitare le etichette e disattiva la visualizzazione per valori pari a 0, valori negativi o valori mancanti secondo una regola definita.

**Come posso garantire uno stile coerente delle etichette durante l'esportazione in PDF/immagini?**

Imposta esplicitamente i font (famiglia, dimensione) e verifica che il font sia disponibile sul lato di rendering per evitare fallback.