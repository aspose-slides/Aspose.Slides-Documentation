---
title: Aggiungi linee di tendenza ai grafici di presentazione in Python
linktitle: Linea di tendenza
type: docs
url: /it/python-java/trend-line/
keywords:
- grafico
- linea di tendenza
- linea di tendenza esponenziale
- linea di tendenza lineare
- linea di tendenza logaritmica
- linea di tendenza media mobile
- linea di tendenza polinomiale
- linea di tendenza di potenza
- linea di tendenza personalizzata
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Aggiungi e personalizza rapidamente le linee di tendenza nei grafici PowerPoint con Aspose.Slides per Python via Java — una guida pratica per coinvolgere il tuo pubblico."
---
## **Panoramica**

Questo articolo spiega come aggiungere linee di tendenza ai grafici di presentazione utilizzando Aspose.Slides. Mostra come creare un grafico, aggiungere linee di tendenza alle serie del grafico e lavorare con diversi tipi di linee di tendenza, tra cui esponenziale, lineare, logaritmica, media mobile, polinomiale e potenza.

Descrive inoltre come aggiungere una linea personalizzata a un grafico inserendo una forma linea e include una breve FAQ sui valori di proiezione della linea di tendenza in avanti e indietro e sul fatto se le linee di tendenza vengano conservate durante l'esportazione in PDF o SVG e durante il rendering dei grafici come immagini.

## **Aggiungere una linea di tendenza**

Aspose.Slides per Python via Java fornisce un'API semplice per gestire diverse linee di tendenza dei grafici:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Ottieni un riferimento a una diapositiva tramite il suo indice.
3. Aggiungi un grafico con dati predefiniti e il tipo desiderato (questo esempio utilizza [ChartType.ClusteredColumn](https://reference.aspose.com/slides/it/python-java/aspose.slides/charttype/#ClusteredColumn)).
4. Aggiungi una linea di tendenza esponenziale alla serie 1 del grafico.
5. Aggiungi una linea di tendenza lineare alla serie 1 del grafico.
6. Aggiungi una linea di tendenza logaritmica alla serie 2 del grafico.
7. Aggiungi una linea di tendenza media mobile alla serie 2 del grafico.
8. Aggiungi una linea di tendenza polinomiale alla serie 3 del grafico.
9. Aggiungi una linea di tendenza di potenza alla serie 3 del grafico.
10. Scrivi la presentazione modificata in un file PPTX.

Il codice seguente crea un grafico con linee di tendenza.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

# Crea un'istanza della classe Presentation.
presentation = Presentation()
try:
    # Crea un grafico a colonne raggruppate.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    # Aggiungi una linea di tendenza esponenziale alla serie 1 del grafico.
    exponential_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential)
    exponential_trend_line.setDisplayEquation(False)
    exponential_trend_line.setDisplayRSquaredValue(False)

    # Aggiungi una linea di tendenza lineare alla serie 1 del grafico.
    linear_trend_line = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear)
    linear_trend_line.setTrendlineType(TrendlineType.Linear)
    linear_trend_line.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trend_line.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Aggiungi una linea di tendenza logaritmica alla serie 2 del grafico.
    logarithmic_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trend_line.setTrendlineType(TrendlineType.Logarithmic)
    logarithmic_trend_line.addTextFrameForOverriding("New log trend line")

    # Aggiungi una linea di tendenza media mobile alla serie 2 del grafico.
    moving_average_trend_line = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trend_line.setTrendlineType(TrendlineType.MovingAverage)
    moving_average_trend_line.setPeriod(jpype.JByte(3))
    moving_average_trend_line.setTrendlineName("New TrendLine Name")

    # Aggiungi una linea di tendenza polinomiale alla serie 3 del grafico.
    polynomial_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trend_line.setTrendlineType(TrendlineType.Polynomial)
    polynomial_trend_line.setForward(1)
    polynomial_trend_line.setOrder(jpype.JByte(3))

    # Aggiungi una linea di tendenza di potenza alla serie 3 del grafico.
    power_trend_line = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Power)
    power_trend_line.setTrendlineType(TrendlineType.Power)
    power_trend_line.setBackward(1)

    # Salva la presentazione.
    presentation.save("ChartTrendLines_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aggiungere una linea personalizzata**

Aspose.Slides per Python via Java fornisce un'API semplice per aggiungere linee personalizzate a un grafico. Per aggiungere una linea semplice a un grafico su una diapositiva selezionata, segui questi passaggi:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
- Ottieni un riferimento a una diapositiva tramite il suo indice.
- Crea un nuovo grafico utilizzando il metodo [addChart](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addChart) della classe [ShapeCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/).
- Aggiungi una forma linea utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addAutoShape) con [ShapeType.Line](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapetype/#Line).
- Imposta il colore della linea della forma.
- Scrivi la presentazione modificata in un file PPTX.

Il codice seguente crea un grafico con una linea personalizzata.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Crea un'istanza della classe Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0)

    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("Presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Cosa significano 'forward' e 'backward' per una linea di tendenza?**

Sono le lunghezze della linea di tendenza proiettata in avanti o indietro: per i grafici a dispersione (XY) sono misurate in unità dell'asse; per i grafici non a dispersione sono misurate nel numero di categorie. Sono consentiti solo valori non negativi.

**La linea di tendenza sarà conservata quando si esporta la presentazione in PDF o SVG, o quando si rende una diapositiva in immagine?**

Sì. Aspose.Slides converte le presentazioni in [PDF](/slides/it/python-java/convert-powerpoint-to-pdf/)/[SVG](/slides/it/python-java/render-a-slide-as-an-svg-image/) e rende i grafici in immagini; le linee di tendenza, in quanto parte del grafico, sono conservate durante queste operazioni. È disponibile anche un metodo per [esportare un'immagine del grafico](/slides/it/python-java/create-shape-thumbnails/) stesso.