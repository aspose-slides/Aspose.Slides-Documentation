---
title: Instalace
type: docs
weight: 70
url: /cs/nodejs-net/installation/
keywords:
- stáhnout Aspose.Slides
- nainstalovat Aspose.Slides
- instalace Aspose.Slides
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Nainstalujte Aspose.Slides for Node.js via .NET ve Windows, Linuxu nebo macOS"
---
Aspose.Slides for Node.js via .NET je platformně nezávislé API a může být použito na jakékoli platformě (Windows, Linux a macOS), kde jsou nainstalovány `Node.js` a most `edge‑js`.

## **Install from NPM**

Instalaci Aspose.Slides for Node.js via .NET můžete snadno provést z [NPM](https://www.npmjs.com/) pomocí následujícího příkazu:
```
$ npm install aspose.slides.via.net
```
Pokud během instalačního procesu narazíte na jakýkoli problém, obraťte se na https://www.npmjs.com/package/edge-js.

## **Install from ZIP archive**

Chcete‑li nainstalovat a používat Aspose.Slides for Node.js via .NET ze ZIP archivu, postupujte podle těchto pokynů:

### **Windows**

1. Nainstalujte .NET 6 nebo novější.
1. Nainstalujte Node.js (https://nodejs.org/en/download/) a přidejte node.exe do `PATH`.
1. Nainstalujte edge‑js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install -g edge-js
```
6. [Download Aspose.Slides for Node.js via .NET](https://releases.aspose.com/slides/cs/nodejs-net/) a rozbalte jej do `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
7. Vytvořte soubor s názvem `hello.js` ve složce `aspose.slides.nodejs.net` pomocí následujícího ukázkového kódu:

```javascript
// Importujte modul Aspose.Slides pro manipulaci se soubory PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Přidejte potřebné třídy z asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Vytvořte a uložte prázdnou prezentaci pro demonstraci základní funkčnosti
function createEmptyPresentation() {
	
    // Inicializujte novou prázdnou prezentaci
    var emptyPresentation = new Presentation();
    
    // Uložte prázdnou prezentaci ve formátu PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Uvolněte prostředky související s prezentací
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Spusťte funkci pro vytvoření prázdné prezentace
```

8. Nyní spusťte `node hello.js` v příkazovém řádku.

### **Linux**

1. Nainstalujte .NET 6 nebo novější.
1. Nainstalujte Node.js (https://nodejs.org/en/download/) a přidejte node.exe do `PATH`.
1. Nainstalujte edge‑js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```
5. [Download Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/cs/nodejs-net/) a rozbalte jej do `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
6. Vytvořte testovací soubor s názvem `hello.js` pomocí tohoto ukázkového kódu ve složce `aspose.slides.nodejs.net`:

```javascript
// Importujte modul Aspose.Slides pro manipulaci se soubory PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Přidejte potřebné třídy z asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Vytvořte a uložte prázdnou prezentaci pro demonstraci základní funkčnosti
function createEmptyPresentation() {
	
    // Inicializujte novou prázdnou prezentaci
    var emptyPresentation = new Presentation();
    
    // Uložte prázdnou prezentaci ve formátu PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Uvolněte prostředky související s prezentací
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Spusťte funkci pro vytvoření prázdné prezentace
```
7. Nyní spusťte `node hello.js` v příkazovém řádku.

### **Mac**

1. Nainstalujte .NET 6 nebo novější.
1. Nainstalujte Node.js (https://nodejs.org/en/download/) a přidejte node.exe do `PATH`.
1. Nainstalujte edge‑js.

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
9. Nyní spusťte `node hello.js` v příkazovém řádku.