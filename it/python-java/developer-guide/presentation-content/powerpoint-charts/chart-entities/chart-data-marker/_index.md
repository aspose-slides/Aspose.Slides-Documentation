---
title: Gestire i marker dei dati del grafico nelle presentazioni usando Python
linktitle: Marker dati
type: docs
url: /it/python-java/chart-data-marker/
keywords:
- grafico
- punto dati
- marker
- opzioni marker
- dimensione marker
- tipo di riempimento
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come personalizzare i marker dei dati del grafico in Aspose.Slides per Python tramite Java, migliorando l'impatto delle presentazioni nei formati PPT e PPTX con chiari esempi di codice Python."
---
## **Panoramica**

Questo articolo spiega come lavorare con i marker dei dati dei grafici in Aspose.Slides. Mostra come creare un grafico, accedere a una serie e ai suoi punti dati, applicare riempimenti immagine ai marker a livello di punto dati, regolare la dimensione del marker e salvare la presentazione aggiornata. Nota inoltre che le forme standard dei marker sono disponibili tramite l'enumerazione [MarkerStyleType](https://reference.aspose.com/slides/it/python-java/aspose.slides/markerstyletype/) e che l'aspetto dei marker viene preservato durante l'esportazione dei grafici in formati raster o SVG.

## **Imposta le opzioni del marker del grafico**

I marker possono essere impostati sui punti dati del grafico all'interno di una serie specifica. Per impostare le opzioni del marker del grafico, segui questi passaggi:

- Instanzia la classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
- Crea il grafico predefinito.
- Imposta le immagini.
- Accedi alla prima serie del grafico.
- Aggiungi nuovi punti dati.
- Scrivi la presentazione su disco.

Il seguente esempio imposta le opzioni del marker del grafico a livello di punto dati.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

# Crea una presentazione vuota.
presentation = Presentation()
try:
    # Accedi alla prima diapositiva
    slide = presentation.getSlides().get_Item(0)

    # Creazione del grafico predefinito
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400)

    # Ottieni l'indice del foglio di lavoro dei dati del grafico predefinito.
    default_worksheet_index = 0

    # Ottieni la cartella di lavoro dei dati del grafico.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Elimina le serie di esempio
    chart.getChartData().getSeries().clear()

    # Aggiungi una nuova serie
    series_name_cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    # Carica la prima immagine.
    desert_bytes = Path("Desert.jpg").read_bytes()
    desert_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(desert_bytes))

    # Carica la seconda immagine.
    tulips_bytes = Path("Tulips.jpg").read_bytes()
    tulips_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(tulips_bytes))

    # Accedi alla prima serie del grafico.
    series = chart.getChartData().getSeries().get_Item(0)

    # Aggiungi punti dati.
    value_cell = workbook.getCell(default_worksheet_index, 1, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 2, 1, 2.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    value_cell = workbook.getCell(default_worksheet_index, 3, 1, 3.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 4, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    # Modifica la dimensione dei marker della serie del grafico.
    series.getMarker().setSize(15)

    # Salva la presentazione con il grafico
    presentation.save("MarkOptions_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Quali forme di marker sono disponibili di default?**

Sono disponibili forme standard (cerchio, quadrato, diamante, triangolo, ecc.); l'elenco è definito dalla classe [MarkerStyleType](https://reference.aspose.com/slides/it/python-java/aspose.slides/markerstyletype/). Se ti serve una forma non standard, usa un marker con un riempimento immagine per emulare elementi grafici personalizzati.

**I marker vengono mantenuti quando si esporta un grafico in immagine o SVG?**

Sì. Quando si renderizzano i grafici in [formati raster](/slides/it/python-java/convert-powerpoint-to-png/) o si salvano [forme come SVG](/slides/it/python-java/render-a-slide-as-an-svg-image/), i marker conservano il loro aspetto e le impostazioni, inclusi dimensione, riempimento e contorno.