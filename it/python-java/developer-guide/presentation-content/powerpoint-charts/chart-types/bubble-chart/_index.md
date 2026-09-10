---
title: Personalizza i grafici a bolle nelle presentazioni usando Python
linktitle: Grafico a bolle
type: docs
url: /it/python-java/bubble-chart/
keywords:
- grafico a bolle
- dimensione della bolla
- scalatura della dimensione
- rappresentazione della dimensione
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Crea e personalizza potenti grafici a bolle in PowerPoint con Aspose.Slides per Python via Java per migliorare facilmente la visualizzazione dei dati."
---
## **Panoramica**

Questo articolo mostra come lavorare con i grafici a bolle in Aspose.Slides. Copre due specifiche opzioni di personalizzazione: la scalatura delle dimensioni delle bolle tramite il metodo [setBubbleSizeScale](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) e il controllo di come i valori di dimensione delle bolle vengono rappresentati tramite il metodo [setBubbleSizeRepresentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation).

Gli esempi dimostrano come creare un grafico a bolle, regolare la scalatura delle dimensioni e passare alla rappresentazione della dimensione della bolla usando la larghezza. L'articolo include anche una breve sezione FAQ che chiarisce il supporto per il tipo di grafico “Bubble with 3-D”, osserva che i limiti pratici del grafico dipendono dalle prestazioni e dalla versione di PowerPoint di destinazione, e spiega che l'esportazione preserva l'aspetto del grafico tramite il motore di rendering di Aspose.Slides.

## **Scalatura delle dimensioni del grafico a bolle**
Aspose.Slides per Python via Java supporta la scalatura delle dimensioni dei grafici a bolle tramite i metodi [ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseries/#getBubbleSizeScale), [ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeScale) e [ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale). L'esempio seguente mostra come scalare le dimensioni delle bolle.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Rappresentare i dati come dimensioni del grafico a bolle**
I metodi [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) e [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeRepresentation) sono disponibili nella classe [ChartSeriesGroup](https://reference.aspose.com/slides/it/python-java/aspose.slides/chartseriesgroup/). La rappresentazione della dimensione della bolla specifica come i valori di dimensione della bolla vengono rappresentati nel grafico a bolle. I valori possibili sono [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/it/python-java/aspose.slides/bubblesizerepresentationtype/#Area) e [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/it/python-java/aspose.slides/bubblesizerepresentationtype/#Width). L'enumerazione [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/it/python-java/aspose.slides/bubblesizerepresentationtype/) specifica i modi possibili per rappresentare i dati come dimensioni del grafico a bolle. L'esempio seguente mostra come rappresentare le dimensioni delle bolle usando la larghezza.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BubbleSizeRepresentationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width)

    presentation.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**È supportato un "grafico a bolle con effetto 3-D" e in che cosa differisce da uno normale?**

Sì. Esiste un tipo di grafico separato, "Bubble with 3-D". Applica lo stile 3-D alle bolle ma non aggiunge un asse aggiuntivo; i dati rimangono X‑Y‑S (dimensione). Il tipo è disponibile nella classe [chart type](https://reference.aspose.com/slides/it/python-java/aspose.slides/charttype/).

**Esiste un limite al numero di serie e punti in un grafico a bolle?**

Non c'è un limite rigido a livello di API; le restrizioni sono determinate dalle prestazioni e dalla versione di PowerPoint di destinazione. Si consiglia di mantenere un numero ragionevole di punti per la leggibilità e la velocità di rendering.

**Come influirà l'esportazione sull'aspetto di un grafico a bolle (PDF, immagini)?**

L'esportazione nei formati supportati preserva l'aspetto del grafico; il rendering è eseguito dal motore Aspose.Slides. Per i formati raster/vettoriali si applicano le regole generali di rendering della grafica dei grafici (risoluzione, anti-aliasing), quindi scegliete un DPI sufficiente per la stampa.