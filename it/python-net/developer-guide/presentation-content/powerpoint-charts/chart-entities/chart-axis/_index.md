---
title: "Personalizza gli assi dei grafici nelle presentazioni con Python"
linktitle: "Asse del grafico"
type: docs
url: /it/python-net/chart-axis/
keywords:
- "asse del grafico"
- "asse verticale"
- "asse orizzontale"
- "personalizzare l'asse"
- "manipolare l'asse"
- "gestire l'asse"
- "proprietà dell'asse"
- "valore massimo"
- "valore minimo"
- "linea dell'asse"
- "formato data"
- "titolo dell'asse"
- "posizione dell'asse"
- "PowerPoint"
- "OpenDocument"
- "presentazione"
- "Python"
- "Aspose.Slides"
description: "Scopri come utilizzare Aspose.Slides per Python via .NET per personalizzare gli assi dei grafici nelle presentazioni PowerPoint e OpenDocument per report e visualizzazioni."
---
## **Panoramica**

Questo articolo spiega come personalizzare gli assi del grafico in Aspose.Slides. Mostra come ottenere i valori effettivi dell'asse, scambiare i dati tra gli assi, nascondere l'asse verticale o orizzontale per i grafici a linee, modificare il tipo di asse di categoria, impostare il formato data per i valori dell'asse di categoria, ruotare il titolo di un asse, impostare la posizione dell'asse e visualizzare un'etichetta di unità sull'asse dei valori.

## **Ottenere i valori massimi sull'asse verticale nei grafici**

Aspose.Slides per Python via .NET consente di ottenere i valori minimo e massimo su un asse verticale. Segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Accedi alla prima diapositiva.
3. Aggiungi un grafico con dati predefiniti.
4. Ottieni il valore massimo effettivo sull'asse.
5. Ottieni il valore minimo effettivo sull'asse.
6. Ottieni l'unità principale effettiva dell'asse.
7. Ottieni l'unità secondaria effettiva dell'asse.
8. Ottieni la scala dell'unità principale effettiva dell'asse.
9. Ottieni la scala dell'unità secondaria effettiva dell'asse.

Questo codice di esempio — un'implementazione dei passaggi sopra — mostra come ottenere i valori richiesti in Python:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
	chart.validate_chart_layout()

	maxValue = chart.axes.vertical_axis.actual_max_value
	minValue = chart.axes.vertical_axis.actual_min_value

	majorUnit = chart.axes.horizontal_axis.actual_major_unit
	minorUnit = chart.axes.horizontal_axis.actual_minor_unit
	
	# Salva la presentazione
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Scambiare i dati tra gli assi**

Aspose.Slides consente di scambiare rapidamente i dati tra gli assi — i dati rappresentati sull'asse verticale (y) vengono spostati sull'asse orizzontale (x) e viceversa. 

Questo codice Python mostra come eseguire lo scambio di dati tra gli assi in un grafico:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Crea una presentazione vuota
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    #Scambia righe e colonne
    chart.chart_data.switch_row_column()
            
    # Salva la presentazione
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Disattivare l'asse verticale per i grafici a linee**

Questo codice Python mostra come nascondere l'asse verticale per un grafico a linee:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **Disattivare l'asse orizzontale per i grafici a linee**

Questo codice mostra come nascondere l'asse orizzontale per un grafico a linee:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **Modificare l'asse di categoria**

Utilizzando la proprietà **CategoryAxisType**, è possibile specificare il tipo di asse di categoria preferito (**date** o **text**). Questo codice in Python dimostra l'operazione: 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS
    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Impostare il formato data per il valore dell'asse di categoria**

Aspose.Slides per Python via .NET consente di impostare il formato data per un valore dell'asse di categoria. L'operazione è dimostrata in questo codice Python:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
from datetime import date

def to_oadate(dt):
    delta = dt - date(1899, 12, 30)
    return delta.days + (delta.seconds + delta.microseconds / 1e6) / (24 * 3600)

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 50, 50, 450, 300)

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    chart.chart_data.categories.add(wb.get_cell(0, "A2", to_oadate(date(2015, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", to_oadate(date(2016, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", to_oadate(date(2017, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", to_oadate(date(2018, 1, 1))))

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B2", 1))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B3", 2))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B4", 3))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B5", 4))
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"
    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Impostare l'angolo di rotazione per il titolo dell'asse del grafico**

Aspose.Slides per Python via .NET consente di impostare l'angolo di rotazione per il titolo di un asse del grafico. Questo codice Python dimostra l'operazione:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Impostare la posizione dell'asse in un asse di categoria o di valore**

Aspose.Slides per Python via .NET consente di impostare la posizione dell'asse in un asse di categoria o di valore. Questo codice Python mostra come eseguire l'operazione:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Abilitare l'etichetta dell'unità di visualizzazione sull'asse dei valori del grafico**

Aspose.Slides per Python via .NET consente di configurare un grafico per mostrare un'etichetta di unità sul suo asse dei valori. Questo codice Python dimostra l'operazione:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Come impostare il valore in cui un asse incrocia l'altro (incrocio degli assi)?**

Gli assi offrono un'impostazione di [crossing setting](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/axis/cross_type/): è possibile scegliere di incrociare a zero, al valore massimo di categoria/valore, o a un valore numerico specifico. Questo è utile per spostare l'asse X verso l'alto o verso il basso o per enfatizzare una linea di base.

**Come posso posizionare le etichette dei tick rispetto all'asse (accanto, all'esterno, all'interno)?**

Imposta la [label position](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/axis/major_tick_mark/) su "cross", "outside" o "inside". Questo influisce sulla leggibilità e aiuta a risparmiare spazio, soprattutto nei grafici piccoli.