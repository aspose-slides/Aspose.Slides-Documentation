---
title: Aggiungi forme di linea alle presentazioni in Python via Java
linktitle: Linea
type: docs
weight: 50
url: /it/python-java/line/
keywords:
- linea
- crea linea
- aggiungi linea
- linea semplice
- configura linea
- personalizza linea
- stile tratteggiato
- punta freccia
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Impara a manipolare la formattazione delle linee nelle presentazioni PowerPoint con Aspose.Slides per Python via Java. Scopri proprietà, metodi ed esempi."
---
## **Panoramica**

Aspose.Slides consente di aggiungere forme di linea alle diapositive PowerPoint in modo programmatico. Questo articolo mostra come creare una semplice linea e come personalizzarla in modo che appaia come una freccia.

Imparerai come aggiungere una forma di linea a una diapositiva, regolare il suo aspetto visivo e salvare la presentazione aggiornata. Gli esempi si concentrano su impostazioni pratiche di formattazione delle linee, come stile, larghezza, tratteggio, opzioni di punta della freccia e colore di riempimento.

## **Crea una Linea Semplice**

Per aggiungere una semplice linea alla diapositiva selezionata della presentazione, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
- Ottieni un riferimento a una diapositiva tramite il suo indice.
- Aggiungi una forma di linea usando il metodo [addAutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addAutoShape) dell'oggetto [ShapeCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/).
- Scrivi la presentazione modificata come file PPTX.

L'esempio seguente aggiunge una linea alla prima diapositiva della presentazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Istanzia la classe Presentation che rappresenta il file PPTX.
presentation = Presentation()
try:
    # Ottieni la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi una forma di linea.
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Scrivi il file PPTX su disco.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Crea una Linea a Forma di Freccia**

Aspose.Slides for Python via Java consente inoltre agli sviluppatori di configurare le proprietà della linea per renderla più attraente. Per configurare una linea in modo che assomigli a una freccia, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
- Ottieni un riferimento a una diapositiva tramite il suo indice.
- Aggiungi una forma di linea usando il metodo [addAutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addAutoShape) dell'oggetto [ShapeCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/).
- Imposta lo [line style](https://reference.aspose.com/slides/it/python-java/aspose.slides/linestyle/) su uno degli stili offerti da Aspose.Slides for Python via Java.
- Imposta la larghezza della linea.
- Imposta lo [dash style](https://reference.aspose.com/slides/it/python-java/aspose.slides/linedashstyle/) su uno degli stili offerti da Aspose.Slides for Python via Java.
- Imposta lo [arrowhead style](https://reference.aspose.com/slides/it/python-java/aspose.slides/linearrowheadstyle/) e la [length](https://reference.aspose.com/slides/it/python-java/aspose.slides/linearrowheadlength/) all'inizio della linea.
- Imposta lo [arrowhead style](https://reference.aspose.com/slides/it/python-java/aspose.slides/linearrowheadstyle/) e la [length](https://reference.aspose.com/slides/it/python-java/aspose.slides/linearrowheadlength/) alla fine della linea.
- Scrivi la presentazione modificata come file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadLength, LineArrowheadStyle, LineDashStyle, LineStyle, Presentation, PresetColor, SaveFormat, ShapeType

# Istanzia la classe Presentation che rappresenta il file PPTX.
presentation = Presentation()
try:
    # Ottieni la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi una forma di linea.
    line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Applica la formattazione alla linea.
    line_format = line.getLineFormat()
    line_format.setStyle(LineStyle.ThickBetweenThin)
    line_format.setWidth(10)

    line_format.setDashStyle(LineDashStyle.DashDot)

    line_format.setBeginArrowheadLength(LineArrowheadLength.Short)
    line_format.setBeginArrowheadStyle(LineArrowheadStyle.Oval)

    line_format.setEndArrowheadLength(LineArrowheadLength.Long)
    line_format.setEndArrowheadStyle(LineArrowheadStyle.Triangle)

    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Maroon)

    # Scrivi il file PPTX su disco.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Posso convertire una linea normale in un connettore così che si "agganci" alle forme?**

No. Una linea normale (un [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/) di tipo [Line](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapetype/)) non diventa automaticamente un connettore. Per farla agganciare alle forme, utilizza il tipo dedicato [Connector](https://reference.aspose.com/slides/it/python-java/aspose.slides/connector/) e le [API corrispondenti](/slides/it/python-java/connector/) per le connessioni.

**Cosa devo fare se le proprietà di una linea sono ereditate dal tema e risulta difficile determinare i valori finali?**

[Leggi le proprietà effective](/slides/it/python-java/shape-effective-properties/) della linea e del suo riempimento—queste tengono già conto dell'ereditarietà e degli stili del tema.

**Posso bloccare una linea contro la modifica (spostamento, ridimensionamento)?**

Sì. Le forme forniscono [lock objects](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/#getAutoShapeLock) che consentono di [disallow editing operations](/slides/it/python-java/applying-protection-to-presentation/).