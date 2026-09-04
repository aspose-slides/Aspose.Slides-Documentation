---
title: Grafico
type: docs
weight: 60
url: /it/python-java/examples/elements/chart/
keywords:
- grafico
- aggiungi grafico
- accedi al grafico
- rimuovi grafico
- aggiorna grafico
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Crea, accedi, rimuovi e aggiorna i grafici nelle presentazioni PowerPoint e OpenDocument con Aspose.Slides per Python via Java."
---
Questo articolo dimostra come aggiungere, accedere, rimuovere e aggiornare i grafici in una presentazione utilizzando **Aspose.Slides for Python via Java**.

Installa il pacchetto come descritto nella [Installazione](/slides/it/python-java/installation/). Ogni esempio importa `asposeslides` prima di avviare la JVM, quindi importa l'API dopo che la JVM è in esecuzione. Esegui prima l'esempio di aggiunta per creare `chart.pptx` per gli esempi rimanenti.

## **Aggiungi un grafico**

Aggiungi un grafico ad area alla prima diapositiva e salva la presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi un grafico ad area alla prima diapositiva.
    chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Accedi a un grafico**

Trova il primo grafico nella raccolta di forme sulla prima diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Accedi al primo grafico nella diapositiva.
    first_chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            first_chart = shape
            break

    if first_chart is None:
        print("The first slide contains no charts.")
finally:
    presentation.dispose()
```

## **Rimuovi un grafico**

Rimuovi il primo grafico dalla diapositiva e salva la presentazione modificata.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Trova e rimuovi il primo grafico nella diapositiva.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        slide.getShapes().remove(chart)
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aggiorna i dati del grafico**

Visualizza il titolo del grafico, cambia il suo testo e salva la presentazione aggiornata.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Trova il primo grafico nella diapositiva.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        # Visualizza il titolo del grafico e cambia il suo testo.
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Sales Report")
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```