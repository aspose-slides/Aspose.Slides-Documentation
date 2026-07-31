---
title: Gestisci i Font di Fallback per le Presentazioni in C++
linktitle: Font di Fallback
type: docs
weight: 50
url: /it/cpp/fallback-font/
keywords:
- font di fallback
- font disponibile
- sostituzione di glifi
- specificare il font
- specificare la regola
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Scopri come Aspose.Slides per C++ utilizza i font di fallback per mantenere il testo leggibile nelle presentazioni PowerPoint e OpenDocument quando i font originali non sono disponibili."
---
## **Introduzione**

I font di fallback vengono utilizzati quando il font specificato per il testo è disponibile nel sistema ma non contiene il glifo richiesto. In questo caso, Aspose.Slides può utilizzare uno dei font di fallback specificati per sostituire il glifo mancante.

## **Font di fallback**
Il font di fallback viene utilizzato quando il font specificato per il testo è disponibile nel sistema, ma questo font non contiene il glifo necessario. In questo caso, è possibile utilizzare uno dei font di fallback specificati per la sostituzione del glifo.

Aspose.Slides consente di creare font di fallback, aggiungerli alla collezione di font di fallback, impostare la collezione di font di fallback per una determinata presentazione, rimuovere i font di fallback dalla presentazione, specificare le regole per applicare i font di fallback e altro.

Per familiarizzare con queste funzionalità, utilizza i seguenti collegamenti:

- [Crea Font di Fallback](/slides/it/cpp/create-fallback-font)
- [Crea Collezione di Font di Fallback](/slides/it/cpp/create-fallback-fonts-collection)
- [Renderizza Presentazione con Font di Fallback](/slides/it/cpp/render-presentation-with-fallback-font)

## **FAQ**

**Qual è la differenza tra i font di fallback e la sostituzione dei font?**

Il fallback viene applicato per carattere o per intervallo Unicode quando il font principale non contiene glifi specifici; riempie solo i caratteri mancanti. [Sostituzione](/slides/it/cpp/font-substitution/) sostituisce un font mancante o non disponibile per un'intera sequenza o parte di testo con un altro font. Possono essere combinati, ma il loro ambito e la logica di selezione sono diversi.

**Le impostazioni di fallback vengono salvate all'interno del file di presentazione?**

No. La configurazione di fallback vive al momento dell'elaborazione/rendering nella libreria e non viene serializzata nel PPTX. La presentazione non memorizza le tue regole di fallback.

**Il fallback influisce sugli elementi creati da oggetti PowerPoint (SmartArt, grafici, WordArt)?**

Sì. Il testo all'interno di questi oggetti passa attraverso la stessa pipeline di rendering, quindi le stesse regole di fallback si applicano ad esso come al testo normale.