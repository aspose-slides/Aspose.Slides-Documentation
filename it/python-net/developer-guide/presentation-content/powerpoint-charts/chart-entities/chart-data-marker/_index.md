---
title: Gestire i marcatori dei dati del grafico nelle presentazioni con Python
linktitle: Marcatore dati
type: docs
url: /it/python-net/chart-data-marker/
keywords:
- grafico
- punto dati
- marcatore
- opzioni marcatore
- dimensione marcatore
- tipo riempimento
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri come personalizzare i marcatori dei dati del grafico in Aspose.Slides, aumentando l'impatto della presentazione nei formati PPT, PPTX e ODP con esempi di codice chiari."
---
## **Panoramica**

Questo articolo spiega come lavorare con i marcatori dei dati nei grafici in Aspose.Slides. Mostra come creare un grafico, accedere a una serie e ai suoi punti dati, applicare riempimenti immagine ai marcatori a livello di punto dati, regolare la dimensione del marcatore e salvare la presentazione aggiornata. Inoltre osserva che le forme standard dei marcatori sono disponibili attraverso l'enumerazione `MarkerStyleType` e che l'aspetto del marcatore viene conservato quando si esportano i grafici in formati raster o SVG.

## **Imposta opzioni marcatore del grafico**
I marcatori possono essere impostati sui punti dati del grafico all'interno di serie specifiche. Per impostare le opzioni dei marcatori del grafico, seguire i passaggi seguenti:

- Istanziate la classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
- Creare il grafico predefinito.
- Impostare l'immagine.
- Prendere la prima serie del grafico.
- Aggiungere un nuovo punto dati.
- Scrivere la presentazione su disco.

Nell'esempio mostrato di seguito, abbiamo impostato le opzioni del marcatore del grafico a livello di punti dati.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Creare un'istanza della classe Presentation
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Creazione del grafico predefinito
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # Ottenere l'indice del foglio di lavoro dei dati del grafico predefinito
    defaultWorksheetIndex = 0

    # Ottenere il foglio di lavoro dei dati del grafico
    fact = chart.chart_data.chart_data_workbook

    # Eliminare la serie demo
    chart.chart_data.series.clear()

    # Aggiungere una nuova serie
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # Impostare l'immagine
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # Impostare l'immagine
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # Prendere la prima serie del grafico
    series = chart.chart_data.series[0]

    # Aggiungere un nuovo punto (1:3) lì.
    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 2.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 3.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 4, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    # Modificare il marcatore della serie del grafico
    series.marker.size = 15

    # Scrivere la presentazione su disco
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Quali forme dei marcatori sono disponibili di default?**

Le forme standard sono disponibili (cerchio, quadrato, diamante, triangolo, ecc.); l'elenco è definito dall'enumerazione [MarkerStyleType](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/markerstyletype/). Se avete bisogno di una forma non standard, usate un marcatore con riempimento immagine per emulare visualizzazioni personalizzate.

**I marcatori sono conservati quando si esporta un grafico in immagine o SVG?**

Sì. Quando si rendono i grafici in [raster formats](/slides/it/python-net/convert-powerpoint-to-png/) o si salvano [shapes as SVG](/slides/it/python-net/render-a-slide-as-an-svg-image/), i marcatori mantengono il loro aspetto e le impostazioni, inclusi dimensione, riempimento e contorno.