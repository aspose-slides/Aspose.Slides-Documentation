---
title: Gestisci i font di fallback per le presentazioni in Java
linktitle: Font di fallback
type: docs
weight: 50
url: /it/java/fallback-font/
keywords:
- font di fallback
- font disponibile
- sostituzione di glifo
- specificare font
- specificare regola
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Scopri come Aspose.Slides per Java utilizza i font di fallback per mantenere il testo leggibile nelle presentazioni PowerPoint e OpenDocument quando i font originali non sono disponibili."
---
## **Introduzione**

I font di fallback vengono utilizzati quando il font specificato per il testo è disponibile nel sistema ma non contiene il glifo richiesto. In questo caso, Aspose.Slides può usare uno dei font di fallback specificati per sostituire il glifo mancante.

## **Font di fallback**

Aspose.Slides consente di creare font di fallback, aggiungerli alla raccolta di font di fallback, impostare la raccolta di font di fallback per una determinata presentazione, rimuovere i font di fallback dalla presentazione, specificare le regole per applicare i font di fallback e altro.

Per familiarizzare con queste funzionalità, utilizzare i seguenti collegamenti:

- [Crea font di fallback](/slides/it/java/create-fallback-font)
- [Crea collezione di font di fallback](/slides/it/java/create-fallback-fonts-collection)
- [Esegui il rendering della presentazione con font di fallback](/slides/it/java/render-presentation-with-fallback-font)

## **FAQ**

**In che modo i font di fallback differiscono dalla sostituzione dei font?**

Il fallback viene applicato per carattere o per intervallo Unicode quando il font principale non contiene glyph specifici; inserisce solo i caratteri mancanti. [Sostituzione](/slides/it/java/font-substitution/) sostituisce un font mancante o non disponibile per un intero run o una porzione di testo con un altro font. Possono essere combinati, ma il loro ambito e la logica di selezione sono diversi.

**Le impostazioni di fallback sono salvate all'interno del file della presentazione?**

No. La configurazione di fallback vive al momento dell'elaborazione/rendering nella libreria e non viene serializzata nel PPTX. La presentazione non memorizza le regole di fallback.

**Il fallback influisce sugli elementi creati da oggetti PowerPoint (SmartArt, grafici, WordArt)?**

Sì. Il testo all'interno di questi oggetti passa attraverso la stessa pipeline di rendering, quindi le stesse regole di fallback si applicano al testo così come al testo normale.