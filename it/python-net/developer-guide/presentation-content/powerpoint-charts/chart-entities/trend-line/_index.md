---
title: Aggiungere linee di tendenza ai grafici di presentazione in Python
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
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Aggiungere rapidamente e personalizzare le linee di tendenza nei grafici PowerPoint e OpenDocument con Aspose.Slides per Python tramite .NET — una guida pratica e esempi di codice per migliorare l'accuratezza delle previsioni e coinvolgere il tuo pubblico."
---
## **Panoramica**

Questo articolo spiega come aggiungere linee di tendenza ai grafici delle presentazioni utilizzando Aspose.Slides. Mostra come creare un grafico, aggiungere linee di tendenza alle serie del grafico e lavorare con diversi tipi di linee di tendenza, inclusi esponenziale, lineare, logaritmico, media mobile, polinomiale e potenza.

Descrive inoltre come aggiungere una linea personalizzata a un grafico inserendo una forma linea e include una breve FAQ sui valori di proiezione della linea di tendenza in avanti e indietro e sull’opportunità di conservare le linee di tendenza durante l’esportazione in PDF o SVG e quando i grafici vengono renderizzati come immagini.

## **Aggiungi linea di tendenza**
Aspose.Slides for Python via .NET fornisce un'API semplice per gestire le varie Linee di Tendenza dei grafici:

1. Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni il riferimento di una diapositiva mediante il suo indice.
3. Aggiungi un grafico con dati predefiniti insieme a uno dei tipi desiderati (questo esempio usa ChartType.CLUSTERED_COLUMN).
4. Aggiungi una linea di tendenza esponenziale per la serie del grafico 1.
5. Aggiungi una linea di tendenza lineare per la serie del grafico 1.
6. Aggiungi una linea di tendenza logaritmica per la serie del grafico 2.
7. Aggiungi una linea di tendenza a media mobile per la serie del grafico 2.
8. Aggiungi una linea di tendenza polinomiale per la serie del grafico 3.
9. Aggiungi una linea di tendenza potenza per la serie del grafico 3.
10. Scrivi la presentazione modificata in un file PPTX.

Il codice seguente viene usato per creare un grafico con Linee di Tendenza.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Creazione di una presentazione vuota
with slides.Presentation() as pres:

    # Creazione di un grafico a colonne raggruppate
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # Aggiunta di una linea di tendenza esponenziale per la serie 1 del grafico
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # Aggiunta di una linea di tendenza lineare per la serie 1 del grafico
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # Aggiunta di una linea di tendenza logaritmica per la serie 2 del grafico
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # Aggiunta di una linea di tendenza media mobile per la serie 2 del grafico
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # Aggiunta di una linea di tendenza polinomiale per la serie 3 del grafico
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # Aggiunta di una linea di tendenza potenza per la serie 3 del grafico
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # Salvataggio della presentazione
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Aggiungi linea personalizzata**
Aspose.Slides for Python via .NET fornisce un'API semplice per aggiungere linee personalizzate in un grafico. Per aggiungere una semplice linea plain a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

- Crea un'istanza della classe Presentation.
- Ottieni il riferimento di una diapositiva usando il suo indice.
- Crea un nuovo grafico usando il metodo AddChart esposto dall'oggetto Shapes.
- Aggiungi un AutoShape di tipo Linea usando il metodo AddAutoShape esposto dall'oggetto Shapes.
- Imposta il colore delle linee della forma.
- Scrivi la presentazione modificata come file PPTX.

Il codice seguente viene usato per creare un grafico con Linee Personalizzate.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    shape = chart.user_shapes.shapes.add_auto_shape(slides.ShapeType.LINE, 0, chart.height / 2, chart.width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
    pres.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Cosa significano “avanti” e “indietro” per una linea di tendenza?**

Sono le lunghezze della linea di tendenza proiettate in avanti/indietro: per i grafici a dispersione (XY) — in unità degli assi; per i grafici non a dispersione — in numero di categorie. Sono consentiti solo valori non negativi.

**La linea di tendenza viene conservata quando si esporta la presentazione in PDF o SVG, o quando si renderizza una diapositiva in un’immagine?**

Sì. Aspose.Slides converte le presentazioni in [PDF](/slides/it/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/it/python-net/render-a-slide-as-an-svg-image/) e renderizza i grafici in immagini; le linee di tendenza, essendo parte del grafico, sono conservate durante queste operazioni. È inoltre disponibile un metodo per [esportare un’immagine del grafico](/slides/it/python-net/create-shape-thumbnails/).