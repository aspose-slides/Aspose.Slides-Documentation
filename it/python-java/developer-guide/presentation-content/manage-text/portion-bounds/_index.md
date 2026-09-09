---
title: Ottenere i limiti della porzione di testo dalle presentazioni in Python via Java
linktitle: Limiti della porzione
type: docs
weight: 47
url: /it/python-java/portion-bounds/
keywords:
- limiti della porzione di testo
- porzione di testo
- parte del testo
- coordinate del testo
- posizione del testo
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come recuperare i limiti della porzione di testo nelle presentazioni PowerPoint utilizzando Aspose.Slides per Python via Java."
---
## **Panoramica**

Una porzione di testo rappresenta un frammento specifico di testo all'interno di un paragrafo e consente di lavorare con quel frammento in modo indipendente dal contenuto circostante. In Aspose.Slides, le porzioni possono essere utilizzate quando è necessario recuperare i confini di un frammento di testo, applicare formattazione solo a una parte di un paragrafo o controllare il comportamento del testo a un livello più dettagliato.

Questo articolo mostra come ottenere il rettangolo di delimitazione di una porzione utilizzando [Portion.getRect](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/#getRect). Mostra anche come ottenere le coordinate dell'inizio di una porzione utilizzando [Portion.getCoordinates](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/#getCoordinates). Inoltre, evidenzia scenari comuni legati alle porzioni, come l'applicazione di un collegamento ipertestuale a un singolo frammento di testo, la comprensione di come la formattazione venga risolta tramite eredità di porzione, paragrafo, text frame e tema, e la gestione dei casi in cui un carattere specificato non è disponibile.

## **Ottenere i confini di una porzione di testo**

Utilizza [Portion.getRect](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/#getRect) per recuperare il rettangolo di delimitazione di una porzione di testo:

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

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            rectangle = portion.getRect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
finally:
    presentation.dispose()
```

## **Ottenere le coordinate di una porzione di testo**

Utilizza [Portion.getCoordinates](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/#getCoordinates) per recuperare le coordinate dell'inizio di una porzione di testo:

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

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            point = portion.getCoordinates()
            print(f"X = {point.x}; Y = {point.y}")
finally:
    presentation.dispose()
```

## **FAQ**

**Posso applicare un collegamento ipertestuale solo a una parte del testo all'interno di un singolo paragrafo?**

Sì, puoi [assegnare un collegamento ipertestuale](/slides/it/python-java/manage-hyperlinks/) a una singola porzione; solo quel frammento sarà cliccabile, non l'intero paragrafo.

**Come funziona l'ereditarietà degli stili: cosa sovrascrive una porzione e cosa viene preso da un paragrafo o da un frame di testo?**

Le proprietà a livello di Porzione hanno la precedenza più alta. Se una proprietà non è impostata sulla [Portion](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/), Aspose.Slides la preleva dal [Paragraph](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraph/). Se non è impostata nemmeno lì, Aspose.Slides utilizza lo stile del [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/) o del [theme](https://reference.aspose.com/slides/it/python-java/aspose.slides/theme/).

**Cosa succede se il carattere specificato per una porzione è assente sulla macchina o sul server di destinazione?**

Si applicano le [regole di sostituzione dei caratteri](/slides/it/python-java/font-selection-sequence/). Il testo potrebbe ridistribuirsi: metriche, sillabazione e larghezza possono cambiare, il che è importante per un posizionamento preciso.

**Posso impostare la trasparenza o una sfumatura di riempimento del testo specifica per la porzione in modo indipendente dal resto del paragrafo?**

Sì, colore, riempimento e trasparenza del testo a livello di [Portion](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/) possono differire dai frammenti vicini.