---
title: Installatie
type: docs
weight: 70
url: /nl/nodejs-net/installation/
keywords:
- downloaden Aspose.Slides
- installeren Aspose.Slides
- Aspose.Slides installatie
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Installeer Aspose.Slides voor Node.js via .NET in Windows, Linux of macOS"
---
Aspose.Slides for Node.js via .NET is een platformonafhankelijke API en kan worden gebruikt op elk platform (Windows, Linux en macOS) waar de `Node.js`‑ en `edge-js`‑brug geïnstalleerd zijn.

## **Installeren vanuit NPM**

U kunt gemakkelijk Aspose.Slides for Node.js via .NET installeren vanaf [NPM](https://www.npmjs.com/) met dit commando:
```
$ npm install aspose.slides.via.net
```
Als u een probleem ondervindt tijdens het installatieproces, raadpleeg dan https://www.npmjs.com/package/edge-js.

## **Installeren vanuit een ZIP‑archief**

Om Aspose.Slides for Node.js via .NET te installeren en te gebruiken vanuit een ZIP‑archief, volgt u in plaats hiervan deze instructies:

### **Windows**

1. Installeer .NET 6 of hoger.  
1. Installeer Node.js (https://nodejs.org/en/download/) en voeg node.exe toe aan `PATH`.  
1. Installeer edge‑js.  
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install -g edge-js
```
6. [Download Aspose.Slides for Node.js via .NET](https://releases.aspose.com/slides/nl/nodejs-net/) en extraheer het naar `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.  
7. Maak een bestand met de naam `hello.js` aan in de map `aspose.slides.nodejs.net` met de volgende voorbeeldcode:

```javascript
// Importeer de Aspose.Slides-module voor PowerPoint-bestandsmanipulatie
const asposeSlides = require('aspose.slides.via.net');

// Voeg benodigde klassen toe van de asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Maak en sla een lege presentatie op om de basisfunctionaliteit te demonstreren
function createEmptyPresentation() {
	
    // Initialiseer een nieuwe lege presentatie
    var emptyPresentation = new Presentation();
    
    // Sla de lege presentatie op in PPTX-formaat
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Maak de aan de presentatie gekoppelde resources vrij
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Voer de functie uit om een lege presentatie te maken
```

8. Voer nu `node hello.js` uit in de opdrachtprompt om het te starten.

### **Linux**

1. Installeer .NET 6 of hoger.  
1. Installeer Node.js (https://nodejs.org/en/download/) en voeg node.exe toe aan `PATH`.  
1. Installeer edge‑js.  
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```
5. [Download Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/nl/nodejs-net/) en extraheer het naar `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.  
6. Maak een testbestand met de naam `hello.js` met deze voorbeeldcode in de map `aspose.slides.nodejs.net`:

```javascript
// Importeer de Aspose.Slides-module voor PowerPoint-bestandsmanipulatie
const asposeSlides = require('aspose.slides.via.net');

// Voeg benodigde klassen toe van de asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Maak en sla een lege presentatie op om de basisfunctionaliteit te demonstreren
function createEmptyPresentation() {
	
    // Initialiseer een nieuwe lege presentatie
    var emptyPresentation = new Presentation();
    
    // Sla de lege presentatie op in PPTX-formaat
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Maak de aan de presentatie gekoppelde resources vrij
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Voer de functie uit om een lege presentatie te maken
```
7. Voer nu `node hello.js` uit in de opdrachtprompt om het te starten.

### **Mac**

1. Installeer .NET 6 of hoger.  
1. Installeer Node.js (https://nodejs.org/en/download/) en voeg node.exe toe aan `PATH`.  
1. Installeer edge‑js.  

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
9. Voer nu `node hello.js` uit in de opdrachtprompt om het te starten.