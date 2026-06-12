---
title: Gestire i font di riserva per le presentazioni in Python
linktitle: Font di riserva
type: docs
weight: 50
url: /it/python-net/fallback-font/
keywords:
- font di riserva
- font disponibile
- sostituzione del glifo
- specificare il font
- specificare la regola
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri come Aspose.Slides per Python tramite .NET utilizza i font di riserva per mantenere il testo leggibile nelle presentazioni PowerPoint e OpenDocument quando i font originali non sono disponibili."
---
## **Introduzione**

I font di riserva vengono utilizzati quando il font specificato per il testo è disponibile nel sistema ma non contiene il glifo richiesto. In questo caso, Aspose.Slides può usare uno dei font di riserva specificati per sostituire il glifo mancante.

## **Font di riserva**

Aspose.Slides consente di creare font di riserva, aggiungerli alla collezione di font di riserva, impostare la collezione di font di riserva per una determinata presentazione, rimuovere i font di riserva dalla presentazione, specificare le regole per applicare i font di riserva e altro ancora.

Per familiarizzare con queste funzionalità, usa i seguenti link:

- [Crea font di riserva](/slides/it/python-net/create-fallback-font)
- [Crea collezione di font di riserva](/slides/it/python-net/create-fallback-fonts-collection)
- [Esegui il rendering della presentazione con font di riserva](/slides/it/python-net/render-presentation-with-fallback-font)

## **FAQ**

**In che modo i font di riserva differiscono dalla sostituzione dei font?**

Il font di riserva viene applicato per carattere o per intervallo di Unicode quando il font primario non dispone di glifi specifici; colma solo i caratteri mancanti. [Sostituzione](/slides/it/python-net/font-substitution/) sostituisce un font mancante o non disponibile per un intero run o porzione di testo con un altro font. Possono essere combinati, ma il loro ambito e la logica di selezione sono diversi.

**Le impostazioni di riserva vengono salvate all'interno del file della presentazione?**

No. La configurazione di fallback risiede al momento dell'elaborazione/rendering nella libreria e non viene serializzata nel PPTX. La presentazione non memorizza le tue regole di fallback.

**Il fallback influisce sugli elementi creati dagli oggetti PowerPoint (SmartArt, grafici, WordArt)?**

Sì. Il testo all'interno di questi oggetti passa attraverso la stessa pipeline di rendering, quindi le stesse regole di fallback si applicano al testo come al testo regolare.