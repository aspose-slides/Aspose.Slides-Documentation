---
title: Collegamento ipertestuale
type: docs
weight: 130
url: /it/python-java/examples/elements/hyperlink/
keywords:
- esempio di codice
- collegamento ipertestuale
- aggiungere collegamento ipertestuale
- accedere al collegamento ipertestuale
- rimuovere collegamento ipertestuale
- aggiornare collegamento ipertestuale
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Aggiungi e gestisci collegamenti ipertestuali in Aspose.Slides per Python via Java: crea, accedi, rimuovi e aggiorna i collegamenti in presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come aggiungere, accedere, rimuovere e aggiornare collegamenti ipertestuali su forme utilizzando **Aspose.Slides for Python via Java**.

Installa il pacchetto come descritto in [Installation](/slides/it/python-java/installation/). Ogni esempio importa `asposeslides` prima di avviare la JVM, poi importa l'API dopo che la JVM è in esecuzione.

## **Aggiungere un collegamento ipertestuale**

Crea una forma rettangolare con un collegamento ipertestuale che punta a un sito web esterno.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))
finally:
    presentation.dispose()
```

## **Accedere a un collegamento ipertestuale**

Leggi le informazioni del collegamento ipertestuale dalla porzione di testo di una forma.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    hyperlink = text_portion.getPortionFormat().getHyperlinkClick()
finally:
    presentation.dispose()
```

## **Rimuovere un collegamento ipertestuale**

Rimuovi il collegamento ipertestuale dal testo di una forma.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com"))

    text_portion.getPortionFormat().setHyperlinkClick(None)
finally:
    presentation.dispose()
```

## **Aggiornare un collegamento ipertestuale**

Modifica la destinazione di un collegamento ipertestuale esistente. Usa [HyperlinkManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlinkmanager/) per modificare il testo che già contiene un collegamento ipertestuale, simulando il modo in cui PowerPoint aggiorna i collegamenti ipertestuali in modo sicuro.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("Aspose")

    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    text_portion = paragraph.getPortions().get_Item(0)
    text_portion.getPortionFormat().setHyperlinkClick(Hyperlink("https://old.example.com"))

    # Modificare un collegamento ipertestuale all'interno del testo esistente dovrebbe essere fatto tramite
    # HyperlinkManager piuttosto che impostare la proprietà direttamente.
    # Questo imita il modo in cui PowerPoint aggiorna in modo sicuro i collegamenti ipertestuali.
    text_portion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com")
finally:
    presentation.dispose()
```