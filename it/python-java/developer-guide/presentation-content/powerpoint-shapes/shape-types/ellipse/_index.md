---
title: Aggiungere ellissi alle presentazioni in Python tramite Java
linktitle: Ellisse
type: docs
weight: 30
url: /it/python-java/ellipse/
keywords:
- ellisse
- forma
- aggiungi ellisse
- creare ellisse
- disegnare ellisse
- ellisse formattata
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Scopri come creare, formattare e manipolare forme ellittiche in Aspose.Slides per Python tramite Java su presentazioni PPT e PPTX — esempi di codice Python inclusi."
---
## **Panoramica**

Questo articolo mostra come aggiungere forme ellittiche alle diapositive PowerPoint utilizzando Aspose.Slides. Copre la creazione di un'ellisse semplice, la creazione di un'ellisse formattata e il salvataggio della presentazione aggiornata come file PPTX. Inoltre tratta domande correlate come lavorare con la posizione e le dimensioni dell'ellisse, controllare l'ordine di sovrapposizione e applicare effetti di animazione.

## **Crea un'ellisse**

Per aggiungere un'ellisse semplice a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
- Ottieni un riferimento a una diapositiva tramite il suo indice.
- Aggiungi un'ellisse utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addAutoShape) dell'oggetto [ShapeCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/).
- Scrivi la presentazione modificata come file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Istanziare la classe Presentation che rappresenta il file PPTX.
presentation = Presentation()
try:
    # Ottenere la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungere una forma ellittica.
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Scrivere il file PPTX su disco.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Crea un'ellisse formattata**

Per aggiungere un'ellisse formattata a una diapositiva, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
- Ottieni un riferimento a una diapositiva tramite il suo indice.
- Aggiungi un'ellisse utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addAutoShape) dell'oggetto [ShapeCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/).
- Imposta il tipo di riempimento dell'ellisse su solido.
- Imposta il colore di riempimento dell'ellisse tramite [getSolidFillColor](https://reference.aspose.com/slides/it/python-java/aspose.slides/fillformat/#getSolidFillColor) sull'oggetto [FillFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/fillformat/) associato all'oggetto [Shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/).
- Imposta il colore del contorno dell'ellisse.
- Imposta la larghezza del contorno dell'ellisse.
- Scrivi la presentazione modificata come file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Istanziare la classe Presentation che rappresenta il file PPTX.
presentation = Presentation()
try:
    # Ottenere la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungere una forma ellittica.
    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Formattare il riempimento dell'ellisse.
    ellipse.getFillFormat().setFillType(FillType.Solid)
    ellipse.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Chocolate)

    # Formattare il contorno dell'ellisse.
    ellipse.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    ellipse.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    ellipse.getLineFormat().setWidth(5)

    # Scrivere il file PPTX su disco.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Come imposto la posizione e le dimensioni esatte di un'ellisse rispetto alle unità della diapositiva?**

Le coordinate e le dimensioni sono tipicamente specificate **in punti**. Per risultati prevedibili, basa i calcoli sulla dimensione della diapositiva e converti i millimetri o i pollici richiesti in punti prima di assegnare i valori.

**Come posso posizionare un'ellisse sopra o sotto altri oggetti (controllare l'ordine di sovrapposizione)?**

Regola l'ordine di disegno dell'oggetto portandolo in primo piano o inviandolo sullo sfondo. Questo consente all'ellisse di sovrapporsi ad altri oggetti o di rivelare quelli sottostanti.

**Come animare l'aspetto o l'enfasi di un'ellisse?**

[Applica](/slides/it/python-java/shape-animation/) effetti di entrata, enfasi o uscita alla forma, e configura trigger e tempistiche per orchestrare quando e come l'animazione viene eseguita.