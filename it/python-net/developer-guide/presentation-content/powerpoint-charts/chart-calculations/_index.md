---
title: Ottimizza i calcoli dei grafici per le presentazioni in Python
linktitle: Calcoli dei grafici
type: docs
weight: 50
url: /it/python-net/chart-calculations/
keywords:
- calcoli dei grafici
- elementi del grafico
- posizione dell'elemento
- posizione reale
- elemento figlio
- elemento genitore
- valori del grafico
- valore reale
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Comprendi i calcoli dei grafici, gli aggiornamenti dei dati e il controllo della precisione in Aspose.Slides per Python via .NET per PPT, PPTX e ODP, con esempi di codice pratici."
---
## **Panoramica**

Aspose.Slides fornisce API per lavorare con i calcoli dei grafici e i dati di layout nelle presentazioni. Questo articolo mostra come recuperare i valori effettivi degli elementi del grafico, inclusa la posizione reale e le dimensioni degli elementi che implementano `ActualLayout` e i valori effettivi degli assi del grafico. Spiega inoltre che questi valori vengono popolati dopo la convalida del layout del grafico.

Inoltre, l'articolo dimostra come ottenere la posizione effettiva degli elementi genitore del grafico e come nascondere componenti del grafico come il titolo, gli assi, la legenda e le linee della griglia. Insieme, questi esempi ti aiutano a ispezionare le informazioni di layout del grafico e a controllare la visibilità degli elementi del grafico nelle presentazioni PowerPoint in modo programmatico.

## **Calcolare i valori effettivi degli elementi del grafico**
Aspose.Slides for Python via .NET fornisce una semplice API per ottenere queste proprietà. Questo ti aiuterà a calcolare i valori effettivi degli elementi del grafico. I valori effettivi includono la posizione degli elementi che ereditano la classe [IActualLayout](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/iactuallayout/) (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) e i valori effettivi degli assi (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    maxValue = chart.axes.vertical_axis.actual_max_value
    minValue = chart.axes.vertical_axis.actual_min_value
    majorUnit = chart.axes.horizontal_axis.actual_major_unit
    minorUnit = chart.axes.horizontal_axis.actual_minor_unit
```



## **Calcolare la posizione effettiva degli elementi genitore del grafico**
Aspose.Slides for Python via .NET fornisce una semplice API per ottenere queste proprietà. Le proprietà di IActualLayout forniscono informazioni sulla posizione effettiva dell'elemento genitore del grafico. È necessario chiamare in precedenza il metodo IChart.ValidateChartLayout() per riempire le proprietà con i valori effettivi.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
```



## **Nascondere le informazioni dal grafico**
Questo argomento ti aiuta a capire come nascondere le informazioni dal grafico. Utilizzando Aspose.Slides for Python via .NET puoi nascondere **Titolo, Asse verticale, Asse orizzontale** e **Linee della griglia** dal grafico. Il seguente esempio di codice mostra come utilizzare queste proprietà.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # Nascondere il titolo del grafico
    chart.has_title = False

    # Nascondere l'asse dei valori
    chart.axes.vertical_axis.is_visible = False

    # Visibilità dell'asse delle categorie
    chart.axes.horizontal_axis.is_visible = False

    # Nascondere la legenda
    chart.has_legend = False

    # Nascondere le linee della griglia principale
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # Impostare il colore della linea della serie
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**I file Excel esterni funzionano come fonte di dati e come influisce questo sul ricalcolo?**

Sì. Un grafico può fare riferimento a un libro di lavoro esterno: quando colleghi o aggiorni la fonte esterna, le formule e i valori vengono presi da quel libro di lavoro e il grafico riflette gli aggiornamenti durante le operazioni di apertura/modifica. L'API consente di [specificare il percorso del libro di lavoro esterno](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/set_external_workbook/) e di gestire i dati collegati.

**Posso calcolare e visualizzare le linee di tendenza senza implementare da me la regressione?**

Sì. Le [linee di tendenza](/slides/it/python-net/trend-line/) (lineari, esponenziali e altre) vengono aggiunte e aggiornate da Aspose.Slides; i loro parametri vengono ricalcolati automaticamente dai dati della serie, quindi non è necessario implementare i propri calcoli.

**Se una presentazione contiene più grafici con collegamenti esterni, posso controllare quale libro di lavoro utilizza ciascun grafico per i valori calcolati?**

Sì. Ogni grafico può puntare al proprio [libro di lavoro esterno](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chartdata/set_external_workbook/), oppure è possibile creare/sostituire un libro di lavoro esterno per ogni grafico in modo indipendente dagli altri.