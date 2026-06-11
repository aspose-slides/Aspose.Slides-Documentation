---
title: Instalacja
type: docs
weight: 70
url: /pl/nodejs-net/installation/
keywords:
- pobierz Aspose.Slides
- zainstaluj Aspose.Slides
- instalacja Aspose.Slides
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Zainstaluj Aspose.Slides for Node.js via .NET w systemie Windows, Linux lub macOS"
---
Aspose.Slides for Node.js via .NET jest niezależnym od platformy API i może być używany na dowolnej platformie (Windows, Linux i macOS), gdzie zainstalowane są `Node.js` i most `edge-js`.

## **Instalacja z NPM**

Możesz łatwo zainstalować Aspose.Slides for Node.js via .NET z [NPM](https://www.npmjs.com/) przy użyciu tego polecenia:
```
$ npm install aspose.slides.via.net
```
Jeśli napotkasz jakikolwiek problem podczas procesu instalacji, odwołaj się do https://www.npmjs.com/package/edge-js.

## **Instalacja z archiwum ZIP**

Aby zainstalować i używać Aspose.Slides for Node.js via .NET z archiwum ZIP, postępuj zgodnie z poniższymi instrukcjami:

### **Windows**

1. Zainstaluj .NET6 lub nowszy.
1. Zainstaluj Node.js (https://nodejs.org/en/download/) i dodaj node.exe do `PATH`.
1. Zainstaluj edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install -g edge-js
```
6. [Pobierz Aspose.Slides for Node.js via .NET](https://releases.aspose.com/slides/pl/nodejs-net/) i wypakuj go do `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
7. Utwórz plik o nazwie `hello.js` w folderze `aspose.slides.nodejs.net` przy użyciu poniższego przykładowego kodu:
```javascript
// Importuj moduł Aspose.Slides do manipulacji plikami PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Dodaj niezbędne klasy z asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Utwórz i zapisz pustą prezentację, aby zademonstrować podstawową funkcjonalność
function createEmptyPresentation() {
	
    // Zainicjuj nową pustą prezentację
    var emptyPresentation = new Presentation();
    
    // Zapisz pustą prezentację w formacie PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Zwolnij zasoby powiązane z prezentacją
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Wykonaj funkcję tworzącą pustą prezentację
```
8. Teraz uruchom `node hello.js` w wierszu poleceń, aby go wykonać.

### **Linux**

1. Zainstaluj .NET6 lub nowszy.
1. Zainstaluj Node.js (https://nodejs.org/en/download/) i dodaj node.exe do `PATH`.
1. Zainstaluj edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```
5. [Pobierz Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/pl/nodejs-net/) i wypakuj go do `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
6. Utwórz plik testowy o nazwie `hello.js` używając tego przykładowego kodu w folderze `aspose.slides.nodejs.net`:
```javascript
// Importuj moduł Aspose.Slides do manipulacji plikami PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Dodaj niezbędne klasy z asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Utwórz i zapisz pustą prezentację, aby zademonstrować podstawową funkcjonalność
function createEmptyPresentation() {
	
    // Zainicjuj nową pustą prezentację
    var emptyPresentation = new Presentation();
    
    // Zapisz pustą prezentację w formacie PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Zwolnij zasoby związane z prezentacją
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Wykonaj funkcję tworzącą pustą prezentację
```
7. Teraz uruchom `node hello.js` w wierszu poleceń, aby go wykonać.

### **Mac**

1. Zainstaluj .NET6 lub nowszy.
1. Zainstaluj Node.js (https://nodejs.org/en/download/) i dodaj node.exe do `PATH`.
1. Zainstaluj edge-js.

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
9. Teraz uruchom `node hello.js` w wierszu poleceń, aby go wykonać.