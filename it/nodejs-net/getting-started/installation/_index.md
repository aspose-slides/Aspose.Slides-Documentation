---
title: Installazione
type: docs
weight: 70
url: /it/nodejs-net/installation/
keywords:
- scarica Aspose.Slides
- installa Aspose.Slides
- installazione Aspose.Slides
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Installa Aspose.Slides per Node.js via .NET su Windows, Linux o macOS"
---
Aspose.Slides per Node.js via .NET è un'API indipendente dalla piattaforma e può essere usata su qualsiasi piattaforma (Windows, Linux e MacOS) dove sono installati `Node.js` e il bridge `edge-js`.

## **Installa da NPM**

Puoi facilmente installare Aspose.Slides per Node.js via .NET da [NPM](https://www.npmjs.com/) tramite questo comando:
```
$ npm install aspose.slides.via.net
```
Se incontri qualsiasi problema durante il processo di installazione, consulta https://www.npmjs.com/package/edge-js.

## **Installa da archivio ZIP**

Per installare e utilizzare Aspose.Slides per Node.js via .NET da un archivio ZIP, seguire queste istruzioni:

### **Windows**

1. Installa .NET6 o versioni successive.
1. Installa Node.js (https://nodejs.org/en/download/) e aggiungi node.exe al `PATH`.
1. Installa edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install -g edge-js
```
6. [Scarica Aspose.Slides per Node.js via .NET](https://releases.aspose.com/slides/it/nodejs-net/) ed estrailo in `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
7. Crea un file chiamato `hello.js` nella cartella `aspose.slides.nodejs.net` usando il seguente codice di esempio:
```javascript
// Importa il modulo Aspose.Slides per la manipolazione di file PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Aggiungi le classi necessarie da asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Crea e salva una presentazione vuota per dimostrare la funzionalità di base
function createEmptyPresentation() {
	
    // Inizializza una nuova presentazione vuota
    var emptyPresentation = new Presentation();
    
    // Salva la presentazione vuota in formato PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Rilascia le risorse associate alla presentazione
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Esegui la funzione per creare una presentazione vuota
```
8. Ora esegui `node hello.js` dal prompt dei comandi per avviarlo.

### **Linux**

1. Installa .NET6 o versioni successive.
1. Installa Node.js (https://nodejs.org/en/download/) e aggiungi node.exe al `PATH`.
1. Installa edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```
5. [Scarica Aspose.Slides per Node.js via Java](https://releases.aspose.com/slides/it/nodejs-net/) ed estrailo in `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
6. Crea un file di test chiamato `hello.js` usando questo codice di esempio nella cartella `aspose.slides.nodejs.net`:
```javascript
// Importa il modulo Aspose.Slides per la manipolazione di file PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Aggiungi le classi necessarie da asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Crea e salva una presentazione vuota per dimostrare la funzionalità di base
function createEmptyPresentation() {
	
    // Inizializza una nuova presentazione vuota
    var emptyPresentation = new Presentation();
    
    // Salva la presentazione vuota in formato PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Rilascia le risorse associate alla presentazione
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Esegui la funzione per creare una presentazione vuota
```
7. Ora esegui `node hello.js` dal prompt dei comandi per avviarlo.

### **Mac**

1. Installa .NET6 o versioni successive.
1. Installa Node.js (https://nodejs.org/en/download/) e aggiungi node.exe al `PATH`.
1. Installa edge-js.

$ mkdir aspose.slides.nodejs.net
 
$ cd aspose.slides.nodejs.net
 
$ npm install edge-js
```

```javascript
// Import the Aspose.Slides module for PowerPoint file manipulation
const asposeSlides = require('aspose.slides.via.net');

// Add necessary classes from the asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Create and save an empty presentation to demonstrate basic functionality
function createEmptyPresentation() {
	
    // Initialize a new empty presentation
    var emptyPresentation = new Presentation();
    
    // Save the empty presentation in PPTX format
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Release resources associated with the presentation
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Execute the function to create an empty presentation
9. Ora esegui `node hello.js` dal prompt dei comandi per avviarlo.