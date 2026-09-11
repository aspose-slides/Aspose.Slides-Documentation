---
title: Aggiungere rettangoli alle presentazioni in Python tramite Java
linktitle: Rettangolo
type: docs
weight: 80
url: /it/python-java/rectangle/
keywords:
- aggiungi rettangolo
- crea rettangolo
- forma rettangolare
- rettangolo semplice
- rettangolo formattato
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Migliora le tue presentazioni PowerPoint aggiungendo rettangoli con Aspose.Slides per Python via Java—progetta e modifica facilmente le forme in modo programmatico."
---
## **Panoramica**

Questo articolo mostra come aggiungere forme rettangolari alle diapositive PowerPoint utilizzando Aspose.Slides. Copre la creazione di un rettangolo semplice, la creazione di un rettangolo formattato e il salvataggio della presentazione aggiornata come file PPTX.

Vedrai anche come applicare la formattazione di base del rettangolo, come un colore di riempimento solido, il colore della linea e lo spessore della linea. Inoltre, la sezione FAQ dell'articolo rimanda a operazioni correlate al rettangolo, tra cui angoli arrotondati, riempimenti con immagine, effetti visivi, collegamenti ipertestuali, blocchi della forma, opzioni di esportazione e proprietà effettive.

## **Aggiungere un rettangolo a una diapositiva**

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
- Ottieni un riferimento a una diapositiva tramite il suo indice.
- Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/) di tipo rettangolo utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addAutoShape) esposto dall'oggetto [ShapeCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/).
- Scrivi la presentazione modificata come file PPTX.

Nel esempio indicato di seguito, abbiamo aggiunto un rettangolo semplice alla prima diapositiva della presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Instanzia la classe Presentation che rappresenta il file PPTX.
presentation = Presentation()
try:
    # Ottieni la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi una forma rettangolare.
    slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Scrivi il file PPTX su disco.
    presentation.save("RecShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aggiungere un rettangolo formattato a una diapositiva**

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
- Ottieni un riferimento a una diapositiva tramite il suo indice.
- Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/) di tipo rettangolo utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addAutoShape) esposto dall'oggetto [ShapeCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/).
- Imposta il [fill type](https://reference.aspose.com/slides/it/python-java/aspose.slides/filltype/) del rettangolo su solido.
- Imposta il colore del rettangolo usando il metodo [setColor](https://reference.aspose.com/slides/it/python-java/aspose.slides/colorformat/#setColor) sul colore di riempimento solido dell'oggetto [FillFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/fillformat/) associato all'oggetto [Shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/).
- Imposta il colore del contorno del rettangolo.
- Imposta la larghezza del contorno del rettangolo.
- Scrivi la presentazione modificata come file PPTX.

I passaggi sopra sono implementati nell'esempio indicato di seguito.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instanzia la classe Presentation che rappresenta il file PPTX.
presentation = Presentation()
try:
    # Ottieni la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi una forma rettangolare.
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Formatta il riempimento del rettangolo.
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    # Formatta il contorno del rettangolo.
    rectangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    rectangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    rectangle.getLineFormat().setWidth(5)

    # Scrivi il file PPTX su disco.
    presentation.save("RecShp2.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Come aggiungo un rettangolo con angoli arrotondati?**

Utilizza il [shape type](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapetype/) a angolo arrotondato e regola il raggio dell'angolo nelle proprietà della forma; l'arrotondamento può essere applicato anche per singolo angolo tramite regolazioni geometriche.

**Come riempio un rettangolo con un'immagine (texture)?**

Seleziona il [fill type](https://reference.aspose.com/slides/it/python-java/aspose.slides/filltype/) dell'immagine, fornisci la sorgente dell'immagine e configura le [stretching/tiling modes](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillmode/).

**Un rettangolo può avere ombra e bagliore?**

Sì. Sono disponibili [Outer/inner shadow, glow, and soft edges](/slides/it/python-java/shape-effect/) con parametri regolabili.

**Posso trasformare un rettangolo in un pulsante con un collegamento ipertestuale?**

Sì. [Assign a hyperlink](/slides/it/python-java/manage-hyperlinks/) al click della forma (passa a una diapositiva, file, indirizzo web o e‑mail).

**Come posso proteggere un rettangolo da spostamenti e modifiche?**

[Use shape locks](/slides/it/python-java/applying-protection-to-presentation/): puoi vietare lo spostamento, il ridimensionamento, la selezione o la modifica del testo per preservare il layout.

**Posso convertire un rettangolo in un'immagine raster o SVG?**

Sì. Puoi [render the shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getImage) in un'immagine con dimensione/scala specificata oppure [export it as SVG](/slides/it/python-java/create-shape-thumbnails/) per utilizzo vettoriale.

**Come ottengo rapidamente le proprietà effettive di un rettangolo considerando tema ed ereditarietà?**

[Use the shape’s effective properties](/slides/it/python-java/shape-effective-properties/): l'API restituisce valori calcolati che tengono conto degli stili del tema, del layout e delle impostazioni locali, semplificando l'analisi della formattazione.