---
title: Apri presentazioni in Node.js via .NET
linktitle: Apri presentazione
type: docs
weight: 20
url: /it/nodejs-net/open-presentation/
keywords:
- apri presentazione
- apri PowerPoint
- apri PPTX
- apri PPT
- apri ODP
- carica presentazione
- presentazione da buffer
- conteggio diapositive
- converti presentazione
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Apri presentazioni PPTX, PPT e ODP in JavaScript con Aspose.Slides per Node.js via .NET: carica da un percorso file o da un Buffer, leggi il conteggio diapositive e salva in un altro formato."
---
## **Panoramica**

Aspose.Slides for Node.js via .NET apre presentazioni PowerPoint e OpenDocument, come i file PPTX, PPT e ODP, da un percorso file o da un `Buffer` Node.js. Questo articolo mostra entrambi i metodi, legge il numero di diapositive e salva una presentazione aperta in un altro formato.

Gli esempi si aspettano una presentazione chiamata `sample.pptx` nella cartella del progetto che hai configurato in [Installation](/slides/it/nodejs-net/installation/). Qualsiasi presentazione PowerPoint va bene. Salva ciascun esempio come file `.js` nella cartella del progetto ed eseguilo da quella cartella con `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET non ha una propria documentazione API. Rispecchia l'API di Aspose.Slides per .NET con nomi camelCase, quindi i collegamenti API in questo articolo puntano alle classi e ai membri corrispondenti nel [riferimento API di Aspose.Slides per .NET](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Apri una presentazione da un file**

Per aprire una presentazione, passa il suo percorso al costruttore [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) . Aspose.Slides rileva il formato dal contenuto del file invece che dall'estensione, quindi lo stesso codice apre file PPTX, PPT e ODP. Un percorso relativo viene risolto rispetto alla directory di lavoro corrente, che è la cartella del progetto quando esegui lo script da lì.

```javascript
const { Presentation } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

Lo script stampa il numero di diapositive in `sample.pptx`, ad esempio `Slide count: 9`. La proprietà `count` della raccolta [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) include le diapositive nascoste. Chiama `dispose` in un blocco `finally`, come mostrato, in modo che le risorse .NET dietro la presentazione vengano rilasciate anche se il tuo codice fallisce.

## **Apri una presentazione da un buffer**

Quando una presentazione proviene da un database, un caricamento HTTP o un'altra sorgente che fornisce byte invece di un percorso file, passa un `Buffer` Node.js come secondo argomento del costruttore e `null` come primo. L'esempio seguente legge `sample.pptx` in un buffer per simulare tale sorgente:

```javascript
const fs = require("fs");
const { Presentation } = require("aspose.slides.via.net");

const presentationData = fs.readFileSync("sample.pptx");

const presentation = new Presentation(null, presentationData);
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

Lo script stampa lo stesso conteggio di diapositive dell'esempio precedente. Il secondo argomento deve essere un `Buffer`. Per qualsiasi altro tipo, come `Uint8Array`, il costruttore non segnala un errore; crea invece una nuova presentazione con una diapositiva vuota. Converti altri tipi binari con `Buffer.from` prima.

## **Salva una presentazione in un altro formato**

Per convertire una presentazione in un altro formato di presentazione, aprila e salvala con un valore diverso di [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/). L'esempio seguente stampa il formato rilevato da Aspose.Slides, restituito dalla proprietà [sourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) e salva la presentazione come una presentazione OpenDocument:

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Source format: " + presentation.sourceFormat);
    presentation.save("sample.odp", SaveFormat.Odp);
} finally {
    presentation.dispose();
}
```

Lo script stampa `Source format: Pptx` e scrive `sample.odp`, che contiene le stesse diapositive. `sourceFormat` restituisce `Ppt`, `Pptx` o `Odp`. Per salvare invece in PDF o come immagini, vedi [Converti PowerPoint in PDF](/slides/it/nodejs-net/convert-powerpoint-to-pdf/) e [Converti diapositive in immagini](/slides/it/nodejs-net/convert-slide/).

## **FAQ**

**Come aprire una presentazione protetta da password?**

Crea un oggetto [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) , imposta la sua proprietà [password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) e passa l'oggetto come terzo argomento del costruttore: `new Presentation("protected.pptx", null, loadOptions)`. Senza la password corretta, il costruttore genera un errore.

**Perché il costruttore genera un `Error` con un messaggio vuoto?**

Quando il costruttore `Presentation` fallisce in .NET, ad esempio perché il file è mancante, non è una presentazione o richiede una password diversa, JavaScript riceve un `Error` il cui messaggio è vuoto. Prima di aprire un file, verifica che esista rispetto alla directory di lavoro, ad esempio con `fs.existsSync`.

**Quali formati posso aprire?**

Formati di presentazione PowerPoint e OpenDocument, inclusi PPT, PPTX, PPS, POT, POTX, PPTM, ODP, OTP e FODP.