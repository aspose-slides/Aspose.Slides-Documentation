---
title: Gestire i Font di Riserva per le Presentazioni in PHP
linktitle: Font di Riserva
type: docs
weight: 50
url: /it/php-java/fallback-font/
keywords:
- font di riserva
- font disponibile
- sostituzione glifo
- specificare font
- specificare regola
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come Aspose.Slides per PHP utilizza i font di riserva per mantenere il testo leggibile nelle presentazioni PowerPoint e OpenDocument quando i font originali non sono disponibili."
---
## **Introduzione**

I font di riserva vengono utilizzati quando il font specificato per il testo è disponibile nel sistema ma non contiene il glifo richiesto. In questo caso, Aspose.Slides può usare uno dei font di riserva specificati per sostituire il glifo mancante.

## **Font di Riserva**
Il font di riserva viene usato quando il font specificato per il testo è disponibile nel sistema, ma questo font non contiene un glifo necessario. In tal caso è possibile utilizzare uno dei font di riserva specificati per la sostituzione del glifo.

Aspose.Slides consente di creare font di riserva, aggiungerli alla raccolta di font di riserva, impostare la raccolta di font di riserva per una determinata presentazione, rimuovere i font di riserva dalla presentazione, specificare le regole per applicare i font di riserva e altro ancora.

Per familiarizzare con queste funzionalità, utilizzare i seguenti collegamenti:

- [Crea Font di Riserva](/slides/it/php-java/create-fallback-font)
- [Crea Raccolta di Font di Riserva](/slides/it/php-java/create-fallback-fonts-collection)
- [Renderizza Presentazione con Font di Riserva](/slides/it/php-java/render-presentation-with-fallback-font)

## **FAQ**

**In che modo i font di riserva differiscono dalla sostituzione dei font?**

Il font di riserva viene applicato per carattere o per intervallo Unicode quando il font principale non dispone di glifi specifici; colma solo i caratteri mancanti. [Sostituzione](/slides/it/php-java/font-substitution/) sostituisce un font mancante o non disponibile per un intero run o segmento di testo con un altro font. Possono essere combinati, ma il loro ambito e la logica di selezione sono diversi.

**Le impostazioni di riserva vengono salvate all'interno del file della presentazione?**

No. La configurazione di riserva vive al momento dell'elaborazione/rendering nella libreria e non viene serializzata nel PPTX. La presentazione non memorizza le regole di riserva.

**Il font di riserva influisce sugli elementi creati dagli oggetti PowerPoint (SmartArt, grafici, WordArt)?**

Sì. Il testo all'interno di questi oggetti passa attraverso la stessa pipeline di rendering, quindi le stesse regole di riserva si applicano così come al testo normale.