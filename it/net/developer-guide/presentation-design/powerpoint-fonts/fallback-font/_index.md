---
title: Gestire i font di fallback per le presentazioni in .NET
linktitle: Font di fallback
type: docs
weight: 50
url: /it/net/fallback-font/
keywords:
- font di fallback
- font disponibile
- sostituzione di glifi
- specificare font
- specificare regola
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come Aspose.Slides per .NET utilizza i font di fallback per mantenere il testo leggibile nelle presentazioni PowerPoint e OpenDocument quando i font originali non sono disponibili."
---
## **Introduzione**

I font di fallback vengono usati quando il font specificato per il testo è disponibile nel sistema ma non contiene il glifo richiesto. In questo caso, Aspose.Slides può utilizzare uno dei font di fallback specificati per sostituire il glifo mancante.

## **Font di fallback**

Aspose.Slides consente di creare font di fallback, aggiungerli alla collezione di font di fallback, impostare la collezione di font di fallback per una determinata presentazione, rimuovere i font di fallback dalla presentazione, specificare le regole per applicare i font di fallback e altro.

Per prendere confidenza con queste funzionalità, utilizza i seguenti link:

- [Crea font di fallback](/slides/it/net/create-fallback-font)
- [Crea collezione di font di fallback](/slides/it/net/create-fallback-fonts-collection)
- [Esegui il rendering della presentazione con font di fallback](/slides/it/net/render-presentation-with-fallback-font)

## **FAQ**

**In che modo i font di fallback differiscono dalla sostituzione dei font?**

Il fallback viene applicato per carattere o per intervallo Unicode quando il font principale non contiene glifi specifici; riempie solo i caratteri mancanti. [Sostituzione](/slides/it/net/font-substitution/) sostituisce un font mancante o non disponibile per un intero run o porzione di testo con un altro font. Possono essere combinati, ma il loro ambito e la logica di selezione sono diversi.

**Le impostazioni di fallback vengono salvate all'interno del file di presentazione?**

No. La configurazione del fallback vive al momento dell'elaborazione/rendering nella libreria e non viene serializzata nel PPTX. La presentazione non conserva le tue regole di fallback.

**Il fallback influisce sugli elementi creati da oggetti PowerPoint (SmartArt, grafici, WordArt)?**

Sì. Il testo all'interno di questi oggetti passa attraverso lo stesso pipeline di rendering, quindi le stesse regole di fallback si applicano ad esso come al testo normale.