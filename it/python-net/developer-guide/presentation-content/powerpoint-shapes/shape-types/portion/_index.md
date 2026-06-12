---
title: Gestire le porzioni di testo nelle presentazioni con Python
linktitle: Porzione di testo
type: docs
weight: 70
url: /it/python-net/portion/
keywords:
- porzione di testo
- parte di testo
- coordinate del testo
- posizione del testo
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri come gestire le porzioni di testo in presentazioni PowerPoint e OpenDocument usando Aspose.Slides per Python via .NET, migliorando le prestazioni e la personalizzazione."
---
## **Introduzione**

Una porzione di testo rappresenta un frammento specifico di testo all'interno di un paragrafo e consente di lavorare su quel frammento in modo indipendente dal contenuto circostante. In Aspose.Slides, le porzioni possono essere utilizzate quando è necessario recuperare la posizione di un frammento di testo, applicare la formattazione solo a una parte di un paragrafo o controllare il comportamento del testo a un livello più dettagliato.

## **Ottenere le coordinate delle porzioni di testo**

Il metodo [get_coordinates](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/get_coordinates/) è stato aggiunto alla classe [Portion](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/) che consente di recuperare le coordinate delle porzioni di testo:

```py
import aspose.slides as slides

with slides.Presentation("HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame = shape.text_frame

    for paragraph in text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```

## **Domande frequenti**

**Posso applicare un collegamento ipertestuale solo a una parte del testo all'interno di un singolo paragrafo?**

Sì, è possibile [assegnare un collegamento ipertestuale](/slides/it/python-net/manage-hyperlinks/) a una singola porzione; solo quel frammento sarà cliccabile, non l'intero paragrafo.

**Come funziona l'ereditarietà degli stili: cosa sovrascrive una Portion e cosa proviene da Paragraph/TextFrame?**

Le proprietà a livello di Portion hanno la precedenza più alta. Se una proprietà non è impostata sulla [Portion](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/), il motore la prende dal [Paragraph](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/); se non è impostata neppure lì, dal [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) o dallo stile del [theme](https://reference.aspose.com/slides/it/python-net/aspose.slides.theme/theme/).

**Cosa succede se il font specificato per una Portion manca sulla macchina/server di destinazione?**

[Regole di sostituzione dei font](/slides/it/python-net/font-selection-sequence/) si applicano. Il testo potrebbe subire un reflow: metriche, sillabazione e larghezza possono cambiare, il che è importante per un posizionamento preciso.

**Posso impostare la trasparenza o il gradiente di riempimento del testo specifici per una Portion in modo indipendente dal resto del paragrafo?**

Sì, colore del testo, riempimento e trasparenza a livello di [Portion](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/) possono differire dai frammenti vicini.