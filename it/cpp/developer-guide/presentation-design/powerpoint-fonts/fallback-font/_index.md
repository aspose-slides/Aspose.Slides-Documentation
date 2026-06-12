---
title: Gestisci i caratteri di riserva per le presentazioni in С++
linktitle: Carattere di riserva
type: docs
weight: 50
url: /it/cpp/fallback-font/
keywords:
- carattere di riserva
- carattere disponibile
- sostituzione del glifo
- specificare il carattere
- specificare la regola
- PowerPoint
- OpenDocument
- presentazione
- С++
- Aspose.Slides
description: "Scopri come Aspose.Slides per С++ utilizza i caratteri di riserva per mantenere il testo leggibile nelle presentazioni PowerPoint e OpenDocument quando i caratteri originali non sono disponibili."
---
## **Introduzione**

I caratteri di riserva vengono utilizzati quando il carattere specificato per il testo è disponibile nel sistema ma non contiene un glifo richiesto. In questo caso, Aspose.Slides può utilizzare uno dei caratteri di riserva specificati per sostituire il glifo mancante.

## **Carattere di riserva**
Il carattere di riserva viene utilizzato quando il carattere specificato per il testo è disponibile nel sistema, ma questo carattere non contiene un glifo necessario. In questo caso, è possibile utilizzare uno dei caratteri di riserva specificati per la sostituzione del glifo.

Aspose.Slides consente di creare caratteri di riserva, aggiungerli alla collezione di caratteri di riserva, impostare la collezione di caratteri di riserva per una determinata presentazione, rimuovere i caratteri di riserva dalla presentazione, specificare le regole per applicare i caratteri di riserva e altro.

Per familiarizzare con queste funzionalità, utilizza i seguenti collegamenti:

- [Crea Carattere di Riserva](/slides/it/cpp/create-fallback-font)
- [Crea Collezione di Caratteri di Riserva](/slides/it/cpp/create-fallback-fonts-collection)
- [Renderizza Presentazione con Carattere di Riserva](/slides/it/cpp/render-presentation-with-fallback-font)

## **FAQ**

**Qual è la differenza tra i caratteri di riserva e la sostituzione dei caratteri?**

Il carattere di riserva viene applicato per carattere o per intervallo di Unicode quando il carattere principale non dispone di glifi specifici; riempie solo i caratteri mancanti. [Sostituzione](/slides/it/cpp/font-substitution/) sostituisce un carattere mancante o non disponibile per un intero intervallo o porzione di testo con un altro carattere. Possono essere combinati, ma il loro ambito e la logica di selezione sono diversi.

**Le impostazioni di riserva vengono salvate all'interno del file della presentazione?**

No. La configurazione di riserva vive al momento dell'elaborazione/rendering nella libreria e non viene serializzata nel PPTX. La presentazione non memorizza le tue regole di riserva.

**Il carattere di riserva influisce sugli elementi creati dagli oggetti di PowerPoint (SmartArt, grafici, WordArt)?**

Sì. Il testo all'interno di questi oggetti passa attraverso lo stesso processo di rendering, quindi le stesse regole di riserva si applicano a esso come al testo normale.