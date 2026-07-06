---
title: Ottenere i limiti della porzione di testo dalle presentazioni in Python
linktitle: Limiti della porzione
type: docs
weight: 47
url: /it/python-net/portion-bounds/
keywords:
- limiti della porzione di testo
- porzione di testo
- parte di testo
- coordinate del testo
- posizione del testo
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Impara come recuperare i limiti delle porzioni di testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Python tramite .NET."
---
## **Panoramica**

Una porzione di testo rappresenta un frammento specifico di testo all'interno di un paragrafo e consente di lavorare con quel frammento in modo indipendente dal contenuto circostante. In Aspose.Slides, le porzioni possono essere utilizzate quando è necessario recuperare i limiti di un frammento di testo, applicare formattazione solo a una parte di un paragrafo o controllare il comportamento del testo a un livello più dettagliato.

Questo articolo mostra come ottenere il rettangolo di delimitazione di una porzione utilizzando [Portion.get_rect](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/get_rect/). Mostra inoltre come ottenere le coordinate dell'inizio di una porzione utilizzando [Portion.get_coordinates](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/get_coordinates/). Inoltre, evidenzia scenari comuni legati alle porzioni, come l'applicazione di un collegamento ipertestuale a un singolo frammento di testo, la comprensione di come la formattazione viene risolta attraverso porzione, paragrafo, cornice di testo e ereditarietà del tema, e la gestione dei casi in cui un font specificato non è disponibile.

## **Ottenere i limiti di una porzione di testo**

Utilizza [Portion.get_rect](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/get_rect/) per recuperare il rettangolo di delimitazione di una porzione di testo:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            rectangle = portion.get_rect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
```

## **Ottenere le coordinate di una porzione di testo**

Utilizza [Portion.get_coordinates](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/get_coordinates/) per recuperare le coordinate dell'inizio di una porzione di testo:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print(f"X = {point.x}; Y = {point.y}")
```

## **FAQ**

**Posso applicare un collegamento ipertestuale solo a una parte del testo all'interno di un singolo paragrafo?**

Sì, puoi [assegnare un collegamento ipertestuale](/slides/it/python-net/manage-hyperlinks/) a una porzione individuale; solo quel frammento sarà cliccabile, non l'intero paragrafo.

**Come funziona l'ereditarietà dello stile: cosa sovrascrive una porzione e cosa viene preso da un paragrafo o da una cornice di testo?**

Le proprietà a livello di porzione hanno la massima precedenza. Se una proprietà non è impostata sulla [Portion](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/), Aspose.Slides la prende dal [Paragraph](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/). Se non è impostata neanche lì, Aspose.Slides utilizza lo stile del [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) o del [theme](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/theme/).

**Cosa succede se il font specificato per una porzione è mancante sulla macchina o sul server di destinazione?**

Si applicano le [regole di sostituzione dei font](/slides/it/python-net/font-selection-sequence/). Il testo potrebbe riformattarsi: metriche, sillabazione e larghezza possono cambiare, il che è importante per un posizionamento preciso.

**Posso impostare la trasparenza o una gradazione di riempimento specifica per una porzione di testo in modo indipendente dal resto del paragrafo?**

Sì, il colore del testo, il riempimento e la trasparenza a livello di [Portion](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/) possono differire dai frammenti vicini.