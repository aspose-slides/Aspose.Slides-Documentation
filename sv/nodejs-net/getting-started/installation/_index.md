---
title: Installation
type: docs
weight: 70
url: /sv/nodejs-net/installation/
keywords:
- ladda ner Aspose.Slides
- installera Aspose.Slides
- installation av Aspose.Slides
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Installera Aspose.Slides för Node.js via .NET i Windows, Linux eller macOS"
---
Aspose.Slides for Node.js via .NET är en plattformsoberoende API och kan användas på alla plattformar (Windows, Linux och MacOS) där `Node.js` och `edge-js`-bryggan är installerade.

## **Installera från NPM**

Du kan enkelt installera Aspose.Slides for Node.js via .NET från [NPM](https://www.npmjs.com/) med detta kommando:
```
$ npm install aspose.slides.via.net
```
Om du stöter på något problem under installationsprocessen, se https://www.npmjs.com/package/edge-js.

## **Installera från ZIP-arkiv**

För att installera och använda Aspose.Slides for Node.js via .NET från ett ZIP‑arkiv, följ dessa instruktioner istället:

### **Windows**

1. Installera .NET6 eller senare.
2. Installera Node.js (https://nodejs.org/en/download/) och lägg till node.exe i `PATH`.
3. Installera edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install -g edge-js
```
6. [Ladda ner Aspose.Slides for Node.js via .NET](https://releases.aspose.com/slides/sv/nodejs-net/) och extrahera den till `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
7. Skapa en fil med namnet `hello.js` i mappen `aspose.slides.nodejs.net` med följande exempel kod:
```javascript
// Importera Aspose.Slides-modulen för PowerPoint-filmanipulering
const asposeSlides = require('aspose.slides.via.net');

// Lägg till nödvändiga klasser från asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Skapa och spara en tom presentation för att demonstrera grundfunktionalitet
function createEmptyPresentation() {
    
    // Initiera en ny tom presentation
    var emptyPresentation = new Presentation();
    
    // Spara den tomma presentationen i PPTX-format
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Frigör resurser som är associerade med presentationen
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Kör funktionen för att skapa en tom presentation
```
8. Kör nu `node hello.js` i kommandotolken för att köra den.

### **Linux**

1. Installera .NET6 eller senare.
2. Installera Node.js (https://nodejs.org/en/download/) och lägg till node.exe i `PATH`.
3. Installera edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```
5. [Ladda ner Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/sv/nodejs-net/) och extrahera den till `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
6. Skapa en testfil med namnet `hello.js` med denna exempel kod i mappen `aspose.slides.nodejs.net`:
```javascript
// Importera Aspose.Slides-modulen för PowerPoint-filmanipulering
const asposeSlides = require('aspose.slides.via.net');

// Lägg till nödvändiga klasser från asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Skapa och spara en tom presentation för att demonstrera grundfunktionalitet
function createEmptyPresentation() {
	
    // Initiera en ny tom presentation
    var emptyPresentation = new Presentation();
    
    // Spara den tomma presentationen i PPTX-format
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Frigör resurser som är kopplade till presentationen
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Kör funktionen för att skapa en tom presentation
```
7. Kör nu `node hello.js` i kommandotolken för att köra den.

### **Mac**

1. Installera .NET6 eller senare.
2. Installera Node.js (https://nodejs.org/en/download/) och lägg till node.exe i `PATH`.
3. Installera edge-js.

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
9. Kör nu `node hello.js` i kommandotolken för att köra den.