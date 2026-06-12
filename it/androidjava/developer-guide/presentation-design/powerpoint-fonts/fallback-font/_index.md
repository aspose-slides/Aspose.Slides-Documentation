---
title: Gestisci i caratteri di riserva per le presentazioni su Android
linktitle: Carattere di riserva
type: docs
weight: 50
url: /it/androidjava/fallback-font/
keywords:
- carattere di riserva
- carattere disponibile
- sostituzione di glifi
- specificare il carattere
- specificare regola
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come Aspose.Slides per Android via Java utilizza i caratteri di riserva per mantenere il testo leggibile nelle presentazioni PowerPoint e OpenDocument quando i caratteri originali non sono disponibili."
---
## **Introduzione**

Il carattere di riserva viene utilizzato quando il carattere specificato per il testo è disponibile nel sistema, ma questo carattere non contiene il glifo necessario. In tal caso, è possibile utilizzare uno dei caratteri di riserva specificati per la sostituzione del glifo.

## **Carattere di riserva**

Aspose.Slides consente di creare caratteri di riserva, aggiungerli alla collezione di caratteri di riserva, impostare la collezione di caratteri di riserva per una determinata presentazione, rimuovere i caratteri di riserva dalla presentazione, specificare le regole per applicare i caratteri di riserva e altro.

Per familiarizzare con queste funzionalità, usa i seguenti collegamenti:
- [Creare carattere di riserva](/slides/it/androidjava/create-fallback-font)
- [Creare collezione di caratteri di riserva](/slides/it/androidjava/create-fallback-fonts-collection)
- [Renderizzare presentazione con carattere di riserva](/slides/it/androidjava/render-presentation-with-fallback-font)

## **FAQ**

**In che modo i caratteri di riserva differiscono dalla sostituzione dei caratteri?**

Il carattere di riserva viene applicato per carattere o per intervallo Unicode quando il carattere principale manca di glifi specifici; riempie solo i caratteri mancanti. [Sostituzione](/slides/it/androidjava/font-substitution/) sostituisce un carattere mancante o non disponibile per un intero intervallo o porzione di testo con un altro carattere. Possono essere combinati, ma il loro ambito e la logica di selezione sono diversi.

**Le impostazioni di riserva vengono salvate all'interno del file della presentazione?**

No. La configurazione del carattere di riserva vive al momento dell'elaborazione/rendering nella libreria e non viene serializzata nel PPTX. La presentazione non memorizza le tue regole di riserva.

**Il carattere di riserva influisce sugli elementi creati dagli oggetti PowerPoint (SmartArt, grafici, WordArt)?**

Sì. Il testo all'interno di questi oggetti passa attraverso lo stesso processo di rendering, quindi le stesse regole di riserva si applicano come per il testo normale.