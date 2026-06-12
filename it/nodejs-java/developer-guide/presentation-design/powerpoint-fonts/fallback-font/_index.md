---
title: Gestisci i font di riserva per le presentazioni in JavaScript
linktitle: Font di riserva
type: docs
weight: 50
url: /it/nodejs-java/fallback-font/
keywords:
- font di riserva
- font disponibile
- sostituzione del glifo
- specificare il font
- specificare la regola
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Vedi come Aspose.Slides per Node.js utilizza i font di riserva per mantenere il testo leggibile nelle presentazioni PowerPoint e OpenDocument quando i font originali non sono disponibili."
---
## **Introduzione**

I caratteri di riserva vengono utilizzati quando il carattere specificato per il testo è disponibile nel sistema ma non contiene il glifo richiesto. In questo caso, Aspose.Slides può utilizzare uno dei caratteri di riserva specificati per sostituire il glifo mancante.

## **Font di riserva**

Aspose.Slides consente di creare font di riserva, aggiungerli alla collezione di font di riserva, impostare la collezione di font di riserva per una determinata presentazione, rimuovere i font di riserva dalla presentazione, specificare le regole per applicare i font di riserva e altro.

Per familiarizzare con queste funzionalità, utilizzare i seguenti collegamenti:

- [Crea font di riserva](/slides/it/nodejs-java/create-fallback-font)
- [Crea collezione di font di riserva](/slides/it/nodejs-java/create-fallback-fonts-collection)
- [Renderizza presentazione con font di riserva](/slides/it/nodejs-java/render-presentation-with-fallback-font)

## **FAQ**

**Come si differenziano i font di riserva dalla sostituzione dei caratteri?**

Il font di riserva viene applicato per carattere o per intervallo di Unicode quando il font primario manca di glifi specifici; colma solo i caratteri mancanti. [Substitution](/slides/it/nodejs-java/font-substitution/) sostituisce un font mancante o non disponibile per un intero blocco o porzione di testo con un altro font. Possono essere combinati, ma il loro ambito e la logica di selezione sono diversi.

**Le impostazioni di riserva vengono salvate all'interno del file della presentazione?**

No. La configurazione del font di riserva esiste solo durante l'elaborazione/rendering nella libreria e non viene serializzata nel PPTX. La presentazione non memorizza le tue regole di riserva.

**Il font di riserva influisce sugli elementi creati dagli oggetti PowerPoint (SmartArt, grafici, WordArt)?**

Sì. Il testo all'interno di questi oggetti passa attraverso la stessa pipeline di rendering, quindi le stesse regole di font di riserva si applicano sia a esso che al testo normale.