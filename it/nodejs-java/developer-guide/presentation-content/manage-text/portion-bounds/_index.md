---
title: Ottieni i limiti delle porzioni di testo dalle presentazioni in JavaScript
linktitle: Limiti della porzione
type: docs
weight: 47
url: /it/nodejs-java/portion-bounds/
keywords:
- limiti della porzione di testo
- porzione di testo
- parte di testo
- coordinate del testo
- posizione del testo
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come recuperare i limiti delle porzioni di testo nelle presentazioni PowerPoint utilizzando Aspose.Slides per Node.js tramite Java."
---
## **Panoramica**

Una porzione di testo rappresenta un frammento specifico di testo all’interno di un paragrafo e consente di lavorare su quel frammento in modo indipendente dal contenuto circostante. In Aspose.Slides, le porzioni possono essere utilizzate quando è necessario recuperare i limiti di un frammento di testo, applicare formattazione solo a parte di un paragrafo o controllare il comportamento del testo a un livello più dettagliato.

Questo articolo mostra come ottenere il rettangolo di delimitazione di una porzione usando [Portion.getRect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/getrect/). Mostra anche come ottenere le coordinate dell’inizio di una porzione usando [Portion.getCoordinates](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/getcoordinates/). Inoltre, evidenzia scenari comuni legati alle porzioni, come l’aggiunta di un collegamento ipertestuale a un singolo frammento di testo, la comprensione di come la formattazione venga risolta tramite ereditarietà di porzione, paragrafo, text frame e tema, e la gestione dei casi in cui un font specificato non è disponibile.

## **Ottieni i limiti di una porzione di testo**

Usa [Portion.getRect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/getrect/) per recuperare il rettangolo di delimitazione di una porzione di testo:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const rectangle = portion.getRect();
            console.log("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ottieni le coordinate di una porzione di testo**

Usa [Portion.getCoordinates](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/getcoordinates/) per recuperare le coordinate dell’inizio di una porzione di testo:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const point = portion.getCoordinates();
            console.log("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Posso applicare un collegamento ipertestuale solo a una parte del testo all’interno di un singolo paragrafo?**

Sì, puoi [assegnare un collegamento ipertestuale](/slides/it/nodejs-java/manage-hyperlinks/) a una singola porzione; solo quel frammento sarà cliccabile, non l’intero paragrafo.

**Come funziona l’eredità degli stili: cosa sovrascrive una porzione e cosa viene preso da un paragrafo o da un text frame?**

Le proprietà a livello di porzione hanno la precedenza più alta. Se una proprietà non è impostata sulla [Portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/), Aspose.Slides la prende dal [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/). Se non è impostata nemmeno lì, Aspose.Slides utilizza lo stile del [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) o del [theme](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/theme/).

** Cosa succede se il font specificato per una porzione è mancante sulla macchina o sul server di destinazione?**

Si applicano le [regole di sostituzione dei font](/slides/it/nodejs-java/font-selection-sequence/). Il testo potrebbe riformattarsi: metriche, sillabazione e larghezza possono cambiare, il che è importante per un posizionamento preciso.

**Posso impostare la trasparenza o un gradiente di riempimento del testo a livello di porzione in modo indipendente dal resto del paragrafo?**

Sì, colore, riempimento e trasparenza del testo a livello di [Portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/) possono differire dai frammenti adiacenti.