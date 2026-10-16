---
title: Aggiungere linee di tendenza ai grafici delle presentazioni in Python
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

Questo articolo spiega come aggiungere linee di tendenza ai grafici di presentazione utilizzando Aspose.Slides. Mostra come creare un grafico, aggiungere linee di tendenza alle serie del grafico e lavorare con diversi tipi di linee di tendenza, tra cui esponenziale, lineare, logaritmica, media mobile, polinomiale e di potenza.

Descrive inoltre come aggiungere una linea personalizzata a un grafico inserendo una forma di linea e include una breve FAQ sui valori di proiezione avanti e indietro delle linee di tendenza e se le linee di tendenza vengono conservate durante l'esportazione in PDF o SVG e durante il rendering dei grafici come immagini.

## **Aggiungere una linea di tendenza**

Usa [TrendlineCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinecollection/#add) per aggiungere una linea di tendenza a una serie di un grafico, selezionando il suo tipo con [TrendlineType](https://reference.aspose.com/slides/python-java/aspose.slides/trendlinetype/). L'esempio crea un grafico a colonne raggruppate con dati predefiniti e aggiunge due linee di tendenza a ciascuna delle sue tre serie.

La linea di tendenza esponenziale nasconde la sua equazione e il valore R-squared mediante [setDisplayEquation](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayEquation) e [setDisplayRSquaredValue](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setDisplayRSquaredValue), mentre la linea di tendenza lineare è rossa. La linea di tendenza logaritmica usa [addTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#addTextFrameForOverriding) per un'etichetta personalizzata. La media mobile usa un [setPeriod](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setPeriod) di tre punti dati e un [setTrendlineName](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setTrendlineName) personalizzato.

La linea di tendenza polinomiale ha un ordine di tre, impostato tramite [setOrder](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setOrder) e si estende di una categoria in avanti tramite [setForward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setForward). La linea di tendenza di potenza si estende di una categoria all'indietro tramite [setBackward](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setBackward).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, TrendlineType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400)

    first_series = chart.getChartData().getSeries().get_Item(0)

    exponential_trendline = first_series.getTrendLines().add(TrendlineType.Exponential)
    exponential_trendline.setDisplayEquation(False)
    exponential_trendline.setDisplayRSquaredValue(False)

    linear_trendline = first_series.getTrendLines().add(TrendlineType.Linear)
    linear_trendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    linear_trendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)

    second_series = chart.getChartData().getSeries().get_Item(1)

    logarithmic_trendline = second_series.getTrendLines().add(TrendlineType.Logarithmic)
    logarithmic_trendline.addTextFrameForOverriding("New log trend line")

    moving_average_trendline = second_series.getTrendLines().add(TrendlineType.MovingAverage)
    moving_average_trendline.setPeriod(jpype.JByte(3))
    moving_average_trendline.setTrendlineName("New TrendLine Name")

    third_series = chart.getChartData().getSeries().get_Item(2)

    polynomial_trendline = third_series.getTrendLines().add(TrendlineType.Polynomial)
    polynomial_trendline.setForward(1)
    polynomial_trendline.setOrder(jpype.JByte(3))

    power_trendline = third_series.getTrendLines().add(TrendlineType.Power)
    power_trendline.setBackward(1)

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Impostare l'intercetta della linea di tendenza**

Usa [setIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#setIntercept) per fissare il valore Y di una linea di tendenza a X = 0. Questa impostazione è supportata per le linee di tendenza lineari, esponenziali e polinomiali.

Ad esempio, un modello di costo di produzione potrebbe dover partire da costi fissi noti di 100, anche quando le misurazioni a volumi di produzione diversi da zero suggeriscono una linea di base diversa. Per una linea di tendenza lineare, fissare l'intercetta vincola l'equazione `y = ax + b` a `b = 100`; la pendenza viene adattata ai dati sotto tale vincolo. Non sposta semplicemente una linea già adattata. Le impostazioni di intersezione degli assi controllano dove gli assi del grafico si incontrano, non i coefficienti della linea di tendenza adattata.

Il seguente esempio crea un grafico a dispersione (XY) con volumi di produzione da 1 a 4 e costi di 170, 200, 230 e 260. Salva il grafico con l'intercetta automatica predefinita, imposta l'intercetta a 100 e salva un secondo PPTX. I due file differiscono solo per l'impostazione dell'intercetta. La linea di tendenza visualizza la sua equazione e si estende fino a X = 0.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, TrendlineType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    name_cell = workbook.getCell(0, 0, 1, "Production cost")
    series = chart.getChartData().getSeries().add(name_cell, ChartType.ScatterWithMarkers)
    costs = [170, 200, 230, 260]

    for i in range(len(costs)):
        x_cell = workbook.getCell(0, i + 1, 0, i + 1)
        y_cell = workbook.getCell(0, i + 1, 1, costs[i])
        series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    trendline = series.getTrendLines().add(TrendlineType.Linear)
    trendline.setDisplayEquation(True)
    trendline.setBackward(1)

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx)

    trendline.setIntercept(100)
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Con il calcolo automatico, questi dati producono `y = 30x + 140`. Impostare l'intercetta a 100 invece produce approssimativamente `y = 43.33x + 100`: il valore adattato a zero corrisponde alla linea di base nota, mentre la linea non passa più per ogni punto dati.

| Intercetta automatica | Intercetta fissa di 100 |
| --- | --- |
| ![Linea di tendenza lineare con intercetta calcolata automaticamente di 140](intercept-automatic.png) | ![Linea di tendenza lineare con intercetta fissata a 100](intercept-fixed.png) |

Entrambe le immagini utilizzano gli stessi dati e le stesse scale degli assi. Le linee di tendenza sono estese fino a X = 0 per mostrare le loro intercette.

Per impostazione predefinita, [getIntercept](https://reference.aspose.com/slides/python-java/aspose.slides/trendline/#getIntercept) restituisce `NaN`, che rappresenta un'intercetta non specificata anziché zero. L'intercetta viene quindi calcolata automaticamente dai dati.

## **Aggiungere una linea personalizzata**

Una linea personalizzata è una forma disegnata sopra il grafico piuttosto che una linea di tendenza calcolata dai dati della serie. Questo esempio utilizza [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) per aggiungere una linea orizzontale alla diapositiva sopra il grafico. La posizione della linea è specificata in coordinate della diapositiva, misurate in punti, quindi inizia dal bordo sinistro del grafico e si trova a metà altezza del grafico. La sua larghezza corrisponde a quella del grafico. Il metodo [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) fornisce l'accesso alla formattazione della linea usata per applicare un colore rosso solido.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0)
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Che cosa significano 'forward' e 'backward' per una linea di tendenza?**

Sono le lunghezze della linea di tendenza proiettata in avanti/indietro: per i grafici a dispersione (XY) — in unità dell'asse; per i grafici non a dispersione — in numero di categorie. Sono consentiti solo valori non negativi.

**La linea di tendenza verrà conservata durante l'esportazione della presentazione in PDF o SVG, o durante il rendering di una diapositiva in un'immagine?**

Sì. Aspose.Slides converte le presentazioni in [PDF](/slides/it/python-java/convert-powerpoint-to-pdf/) o [SVG](/slides/it/python-java/render-a-slide-as-an-svg-image/) e rende i grafici in immagini; le linee di tendenza, come parte del grafico, sono conservate durante queste operazioni. È disponibile anche un metodo per [esportare un'immagine del grafico](/slides/it/python-java/create-shape-thumbnails/) stesso.