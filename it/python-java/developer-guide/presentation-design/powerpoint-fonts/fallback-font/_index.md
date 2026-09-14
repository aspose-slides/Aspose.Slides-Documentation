---
title: Gestisci i Font di Fallback per le Presentazioni in Python tramite Java
linktitle: Font di Fallback
type: docs
weight: 50
url: /it/python-java/fallback-font/
keywords:
- font di fallback
- font disponibile
- sostituzione dei glifi
- specificare il font
- specificare la regola
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Scopri come Aspose.Slides per Python tramite Java utilizza i font di fallback per mantenere il testo leggibile nelle presentazioni PowerPoint e OpenDocument quando i font originali non sono disponibili."
---
## **Introduzione**

I font di fallback vengono utilizzati quando il font specificato per il testo è presente nel sistema ma non contiene il glifo richiesto. In questo caso, Aspose.Slides può utilizzare uno dei font di fallback specificati per sostituire il glifo mancante.

## **Font di fallback**

Aspose.Slides consente di creare font di fallback, aggiungerli a una raccolta di font di fallback, impostare la raccolta di font di fallback per una determinata presentazione, rimuovere i font di fallback dalla presentazione, specificare le regole per l'applicazione dei font di fallback ed eseguire altre operazioni correlate.

Per familiarizzare con queste funzionalità, utilizzare i seguenti collegamenti:

- [Crea Font di Fallback](/slides/it/python-java/create-fallback-font/)
- [Crea Raccolta di Font di Fallback](/slides/it/python-java/create-fallback-fonts-collection/)
- [Rendering della Presentazione con Font di Fallback](/slides/it/python-java/render-presentation-with-fallback-font/)

## **FAQ**

**In che modo i font di fallback differiscono dalla sostituzione del font?**

Il fallback viene applicato per carattere o per intervallo Unicode quando il font principale non dispone di glifi specifici; copre solo i caratteri mancanti. [Substitution](/slides/it/python-java/font-substitution/) sostituisce un font mancante o non disponibile per un intero intervallo di testo o porzione di testo con un altro font. Possono essere combinati, ma il loro ambito e la logica di selezione sono diversi.

**Le impostazioni di fallback vengono salvate all'interno del file di presentazione?**

No. La configurazione di fallback esiste solo durante l'elaborazione/rendering nella libreria e non viene serializzata nel PPTX. La presentazione non memorizza le regole di fallback.

**Il fallback influisce sugli elementi creati da oggetti PowerPoint (SmartArt, grafici, WordArt)?**

Sì. Il testo all’interno di questi oggetti passa attraverso lo stesso processo di rendering, quindi le stesse regole di fallback si applicano sia a esso che al testo normale.