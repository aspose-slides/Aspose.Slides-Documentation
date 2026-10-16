---
title: Aggiungi linee di tendenza ai grafici delle presentazioni in Python
linktitle: Linea di tendenza
type: docs
url: /it/python-net/trend-line/
keywords:
- grafico
- linea di tendenza
- linea di tendenza esponenziale
- linea di tendenza lineare
- linea di tendenza logaritmica
- linea di tendenza media mobile
- linea di tendenza polinomiale
- linea di tendenza potenza
- linea di tendenza personalizzata
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Aggiungi rapidamente e personalizza le linee di tendenza nei grafici PowerPoint con Aspose.Slides per Python via .NET — una guida pratica per coinvolgere il tuo pubblico."
---
## **Panoramica**

Questo articolo spiega come aggiungere linee di tendenza ai grafici delle presentazioni utilizzando Aspose.Slides. Mostra come creare un grafico, aggiungere linee di tendenza alle serie del grafico e lavorare con diversi tipi di linee di tendenza, tra cui esponenziale, lineare, logaritmica, media mobile, polinomiale e potenza.

Descrive inoltre come aggiungere una linea personalizzata a un grafico inserendo una forma di linea e include una breve FAQ sui valori di proiezione in avanti e indietro della linea di tendenza e sul fatto che le linee di tendenza vengano preservate durante l'esportazione in PDF o SVG e quando i grafici vengono renderizzati come immagini.

## **Aggiungi una linea di tendenza**

Utilizza [TrendlineCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinecollection/add/) per aggiungere una linea di tendenza a una serie di un grafico, selezionando il suo tipo con [TrendlineType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendlinetype/). L'esempio crea un grafico a colonne raggruppate con dati predefiniti e aggiunge due linee di tendenza a ciascuna delle sue tre serie.

La linea di tendenza esponenziale nasconde la sua equazione e il valore R-quadrato tramite [display_equation](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_equation/) e [display_r_squared_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/display_r_squared_value/), mentre la linea di tendenza lineare è rossa. La linea di tendenza logaritmica utilizza [add_text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/add_text_frame_for_overriding/) per un'etichetta personalizzata. La media mobile utilizza un [period](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/period/) di tre punti dati e un [trendline_name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/trendline_name/) personalizzato.

La linea di tendenza polinomiale ha un [order](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/order/) di tre e si estende di una categoria in avanti tramite [forward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/forward/). La linea di tendenza potenza si estende di una categoria indietro tramite [backward](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/backward/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    first_series = chart.chart_data.series[0]

    exponential_trendline = first_series.trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    exponential_trendline.display_equation = False
    exponential_trendline.display_r_squared_value = False

    linear_trendline = first_series.trend_lines.add(charts.TrendlineType.LINEAR)
    linear_trendline.format.line.fill_format.fill_type = slides.FillType.SOLID
    linear_trendline.format.line.fill_format.solid_fill_color.r = 255
    linear_trendline.format.line.fill_format.solid_fill_color.g = 0
    linear_trendline.format.line.fill_format.solid_fill_color.b = 0

    second_series = chart.chart_data.series[1]

    logarithmic_trendline = second_series.trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    logarithmic_trendline.add_text_frame_for_overriding("New log trend line")

    moving_average_trendline = second_series.trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    moving_average_trendline.period = 3
    moving_average_trendline.trendline_name = "New TrendLine Name"

    third_series = chart.chart_data.series[2]

    polynomial_trendline = third_series.trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    polynomial_trendline.forward = 1
    polynomial_trendline.order = 3

    power_trendline = third_series.trend_lines.add(charts.TrendlineType.POWER)
    power_trendline.backward = 1

    presentation.save("ChartTrendLines.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta l'intercetta della linea di tendenza**

Utilizza [intercept](https://reference.aspose.com/slides/python-net/aspose.slides.charts/trendline/intercept/) per fissare il valore Y di una linea di tendenza a X = 0. Questa impostazione è supportata per le linee di tendenza lineari, esponenziali e polinomiali.

Ad esempio, un modello di costo di produzione potrebbe dover partire da costi fissi noti di 100, anche quando le misurazioni a volumi di produzione diversi dallo zero suggeriscono una linea di base differente. Per una linea di tendenza lineare, fissare l'intercetta vincola l'equazione `y = ax + b` a `b = 100`; la pendenza viene adattata ai dati sotto tale vincolo. Non sposta semplicemente una linea già adattata. Le impostazioni di intersezione degli assi controllano dove gli assi del grafico si incontrano, non i coefficienti della linea di tendenza adattata.

L'esempio seguente crea un grafico a dispersione (XY) con volumi di produzione da 1 a 4 e costi di 170, 200, 230 e 260. Salva il grafico con l'intercetta automatica predefinita, imposta l'intercetta a 100 e salva un secondo file PPTX. I due file differiscono solo per l'impostazione dell'intercetta. La linea di tendenza visualizza la sua equazione e si estende indietro fino a X = 0.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_MARKERS, 20, 20, 480, 210)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    name_cell = workbook.get_cell(0, 0, 1, "Production cost")
    series = chart.chart_data.series.add(name_cell, charts.ChartType.SCATTER_WITH_MARKERS)
    costs = [170, 200, 230, 260]

    for i, cost in enumerate(costs):
        x_cell = workbook.get_cell(0, i + 1, 0, i + 1)
        y_cell = workbook.get_cell(0, i + 1, 1, cost)
        series.data_points.add_data_point_for_scatter_series(x_cell, y_cell)

    trendline = series.trend_lines.add(charts.TrendlineType.LINEAR)
    trendline.display_equation = True
    trendline.backward = 1

    presentation.save("AutomaticIntercept.pptx", slides.export.SaveFormat.PPTX)

    trendline.intercept = 100
    presentation.save("FixedIntercept.pptx", slides.export.SaveFormat.PPTX)
```

Con il calcolo automatico, questi dati producono `y = 30x + 140`. Impostare l'intercetta a 100 invece produce approssimativamente `y = 43.33x + 100`: il valore adattato a zero corrisponde alla linea di base nota, mentre la linea non passa più per tutti i punti dati.

| Intercetta automatica | Intercetta fissa di 100 |
| --- | --- |
| ![Linea di tendenza lineare con intercetta calcolata automaticamente di 140](intercept-automatic.png) | ![Linea di tendenza lineare con intercetta fissa di 100](intercept-fixed.png) |

Entrambe le immagini usano gli stessi dati e le stesse scale degli assi. Le linee di tendenza sono estese indietro fino a X = 0 per mostrare le loro intercette.

Per impostazione predefinita, la proprietà contiene `float("nan")`, che rappresenta un'intercetta non specificata anziché zero. L'intercetta viene quindi calcolata automaticamente dai dati.

## **Aggiungi una linea personalizzata**

Una linea personalizzata è una forma disegnata sopra il grafico piuttosto che una linea di tendenza calcolata dai dati delle serie. Questo esempio utilizza [ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) per aggiungere una linea orizzontale alla diapositiva sopra il grafico. La posizione della linea è specificata in coordinate della diapositiva, misurate in punti, quindi inizia dal bordo sinistro del grafico e si trova a metà altezza del grafico. La sua larghezza corrisponde a quella del grafico. Il [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) assegna alla linea un colore rosso solido.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)

    line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, chart.x, chart.y + chart.height / 2, chart.width, 0)
    line.line_format.fill_format.fill_type = slides.FillType.SOLID
    line.line_format.fill_format.solid_fill_color.r = 255
    line.line_format.fill_format.solid_fill_color.g = 0
    line.line_format.fill_format.solid_fill_color.b = 0

    presentation.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Cosa significano 'forward' e 'backward' per una linea di tendenza?**

Sono le lunghezze della linea di tendenza proiettata in avanti/indietro: per i grafici a dispersione (XY) — in unità dell'asse; per i grafici non a dispersione — in numero di categorie. Sono concessi solo valori non negativi.

**La linea di tendenza verrà preservata durante l'esportazione della presentazione in PDF o SVG, o durante il rendering di una diapositiva in un'immagine?**

Sì. Aspose.Slides converte le presentazioni in [PDF](/slides/it/python-net/convert-powerpoint-to-pdf/) o [SVG](/slides/it/python-net/render-a-slide-as-an-svg-image/) e rende i grafici in immagini; le linee di tendenza, come parte del grafico, sono preservate durante queste operazioni. È disponibile anche un metodo per [esportare un'immagine del grafico](/slides/it/python-net/create-shape-thumbnails/).