---
title: Gestire le porzioni di testo nelle presentazioni usando JavaScript
linktitle: Porzione di testo
type: docs
weight: 70
url: /it/nodejs-java/portion/
keywords:
- porzione di testo
- parte di testo
- coordinate del testo
- posizione del testo
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come gestire le porzioni di testo nelle presentazioni PowerPoint usando JavaScript e Aspose.Slides per Node.js via Java, migliorando prestazioni e personalizzazione."
---
## **Panoramica**

Una porzione di testo rappresenta uno specifico frammento di testo all'interno di un paragrafo e consente di lavorare con quel frammento in modo indipendente dal contenuto circostante. In Aspose.Slides, le porzioni possono essere utilizzate quando è necessario recuperare la posizione di un frammento di testo, applicare formattazione solo a una parte di un paragrafo o controllare il comportamento del testo a un livello più dettagliato.

Questo articolo mostra come ottenere le coordinate dell'inizio di una porzione utilizzando il metodo `getCoordinates()`. Evidenzia inoltre scenari comuni relativi alle porzioni, come l'applicazione di un collegamento ipertestuale a un singolo frammento di testo, la comprensione di come la formattazione venga risolta attraverso la porzione, il paragrafo, il riquadro di testo e l'ereditarietà del tema, e la gestione dei casi in cui un font specificato non è disponibile. Inoltre, segnala che il riempimento del testo, il colore e la trasparenza possono essere impostati in modo diverso per le singole porzioni all'interno dello stesso paragrafo.

## **Ottenere le coordinate di posizione della porzione**
[**getCoordinates()**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Portion#getCoordinates--) è stato aggiunto alla classe [Portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/) che consente di recuperare le coordinate dell'inizio della porzione.

```javascript
// Istanziare la classe Presentation che rappresenta il PPTX
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Rimodellare il contesto della presentazione
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const paragraph = textFrame.getParagraphs().get_Item(i);
        for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
            const portion = paragraph.getPortions().get_Item(j);
            var point = portion.getCoordinates();
            console.log("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso applicare un collegamento ipertestuale solo a una parte del testo all'interno di un singolo paragrafo?**

Sì, è possibile [assegnare un collegamento ipertestuale](/slides/it/nodejs-java/manage-hyperlinks/) a una singola porzione; solo quel frammento sarà cliccabile, non l'intero paragrafo.

**Come funziona l'ereditarietà degli stili: cosa sovrascrive una Porzione e cosa viene ereditato dal Paragrafo/Riquadro di testo?**

Le proprietà a livello di Porzione hanno la precedenza più alta. Se una proprietà non è impostata sulla [Portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/), il motore la prende dal [Paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/paragraph/); se non è impostata nemmeno lì, viene prelevata dallo [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) o dallo stile del [theme](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/theme/).

**Cosa succede se il font specificato per una Porzione è mancante sulla macchina/server di destinazione?**

Vengono applicate le [Font substitution rules](/slides/it/nodejs-java/font-selection-sequence/). Il testo potrebbe riadattarsi: metriche, sillabazione e larghezza possono cambiare, il che è importante per un posizionamento preciso.

**Posso impostare la trasparenza o il gradiente del riempimento del testo per una porzione in modo indipendente dal resto del paragrafo?**

Sì, colore, riempimento e trasparenza del testo a livello di [Portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/portion/) possono differire dai frammenti adiacenti.