---
title: Ottieni i limiti del paragrafo dalle presentazioni in Python tramite Java
linktitle: Limiti del paragrafo
type: docs
weight: 43
url: /it/python-java/paragraph-bounds/
keywords:
- limiti del paragrafo
- coordinate del paragrafo
- dimensione del paragrafo
- frame di testo
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come recuperare i limiti del paragrafo in Aspose.Slides per Python tramite Java per ottimizzare il posizionamento del testo nelle presentazioni PowerPoint."
---
## **Panoramica**

Questo articolo spiega come ottenere i limiti, la dimensione e le coordinate dei paragrafi in Aspose.Slides. Mostra come recuperare un rettangolo del paragrafo da un [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/) utilizzando [Paragraph.getRect](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraph/#getRect), come ottenere le coordinate del paragrafo all'interno di un frame di testo di una cella di tabella, e evidenzia dettagli importanti come le unità di misura, l'effetto dell'andare a capo del testo sui limiti, la conversione in pixel e i valori di formattazione effettiva del paragrafo.

## **Ottenere le coordinate rettangolari di un paragrafo**

Utilizza [Paragraph.getRect](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraph/#getRect) per ottenere il rettangolo di delimitazione di un paragrafo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    rectangle = paragraph.getRect()
finally:
    presentation.dispose()
```

## **Ottenere la dimensione di un paragrafo all'interno del frame di testo di una cella di tabella**

Per ottenere la dimensione e le coordinate di un [Paragraph](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraph/) in un frame di testo di una cella di tabella, utilizza [Paragraph.getRect](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraph/#getRect). Il rettangolo restituito è relativo al frame di testo della cella di tabella, quindi aggiungi la posizione della tabella e l'offset della cella quando hai bisogno delle coordinate a livello di diapositiva.

Il seguente esempio ottiene i limiti del paragrafo all'interno di una cella di tabella e disegna rettangoli sulla diapositiva per visualizzare tali limiti:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation("source.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)
    cell = table.getRows().get_Item(1).get_Item(1)

    cell_x = table.getX() + cell.getOffsetX()
    cell_y = table.getY() + cell.getOffsetY()

    for paragraph in cell.getTextFrame().getParagraphs():
        if not paragraph.getText():
            continue

        paragraph_rectangle = paragraph.getRect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, paragraph_rectangle_x, paragraph_rectangle_y, paragraph_rectangle.width, paragraph_rectangle.height)

        paragraph_bounds_shape.getFillFormat().setFillType(FillType.NoFill)
        paragraph_bounds_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
        paragraph_bounds_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**In quali unità sono misurate le coordinate del paragrafo?**

Sono misurate in punti, dove 1 pollice corrisponde a 72 punti. Questo vale per tutte le coordinate e le dimensioni sulla diapositiva.

**Il ritorno a capo automatico influisce sui limiti di un paragrafo?**

Sì. Se [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setWrapText) è abilitato per il [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/), il testo viene interrotto per adattarsi alla larghezza dell'area, modificando i limiti effettivi del paragrafo.

**È possibile mappare in modo affidabile le coordinate del paragrafo su pixel nell'immagine esportata?**

Sì. Converti i punti in pixel usando questa formula: pixel = punti x (DPI / 72). Il risultato dipende dal DPI scelto per il rendering o l'esportazione.

**Come ottengo i parametri di formattazione "effettiva" del paragrafo, tenendo conto dell'ereditarietà di stile?**

Utilizza la [struttura dati di formattazione effettiva del paragrafo](/slides/it/python-java/shape-effective-properties/); restituisce i valori finali consolidati per rientri, spaziatura, avvolgimento, RTL e altro.