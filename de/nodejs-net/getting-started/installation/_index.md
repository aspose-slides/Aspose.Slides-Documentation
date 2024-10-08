---
title: Installation
type: docs
weight: 70
url: /de/nodejs-net/installation/
keySlides: "Aspose.Slides herunterladen, Aspose.Slides installieren, Aspose.Slides Installation, Windows, macOS, Linux, Javascript, Node.js"
description: "Installieren Sie Aspose.Slides für Node.js über .NET unter Windows, Linux oder macOS"
---

Aspose.Slides für Node.js über .NET ist eine plattformunabhängige API und kann auf jeder Plattform (Windows, Linux und MacOS) verwendet werden, wo `Node.js` und der `edge-js`-Brücke installiert sind.

## **Installation über NPM**

Sie können Aspose.Slides für Node.js über .NET ganz einfach mit folgendem Befehl von [NPM](https://www.npmjs.com/) installieren:
```
$ npm install aspose.slides.via.net
```
Wenn Sie während des Installationsprozesses auf Probleme stoßen, beziehen Sie sich bitte auf https://www.npmjs.com/package/edge-js.

## **Installation aus ZIP-Archiv**

Um Aspose.Slides für Node.js über .NET aus einem ZIP-Archiv zu installieren und zu verwenden, folgen Sie bitte stattdessen diesen Anweisungen:

### **Windows**

1. Installieren Sie .NET6 oder höher.
1. Installieren Sie Node.js (https://nodejs.org/en/download/) und fügen Sie node.exe zu `PATH` hinzu.
1. Installieren Sie edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install -g edge-js
```
6. [Laden Sie Aspose.Slides für Node.js über .NET herunter](https://releases.aspose.com/slides/nodejs-net/) und extrahieren Sie es nach `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
7. Erstellen Sie eine Datei namens `hello.js` im Ordner `aspose.slides.nodejs.net` mit folgendem Beispielcode:

```javascript
// Importieren Sie das Aspose.Slides-Modul zur Manipulation von PowerPoint-Dateien
const asposeSlides = require('aspose.slides.via.net');

// Fügen Sie die erforderlichen Klassen aus asposeSlides hinzu
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Erstellen und speichern Sie eine leere Präsentation, um die grundlegende Funktionalität zu demonstrieren
function createEmptyPresentation() {
	
    // Initialisieren Sie eine neue leere Präsentation
    var emptyPresentation = new Presentation();
    
    // Speichern Sie die leere Präsentation im PPTX-Format
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Geben Sie die mit der Präsentation verbundenen Ressourcen frei
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Führen Sie die Funktion aus, um eine leere Präsentation zu erstellen
```

8. Führen Sie nun `node hello.js` @Befehlszeile aus, um es auszuführen.

### **Linux**

1. Installieren Sie .NET6 oder höher.
1. Installieren Sie Node.js (https://nodejs.org/en/download/) und fügen Sie node.exe zu `PATH` hinzu.
1. Installieren Sie edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```
5. [Laden Sie Aspose.Slides für Node.js über Java herunter](https://releases.aspose.com/slides/nodejs-net/) und extrahieren Sie es nach `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
6. Erstellen Sie eine Testdatei namens `hello.js` in dem Ordner `aspose.slides.nodejs.net` mit diesem Beispielcode:

```javascript
// Importieren Sie das Aspose.Slides-Modul zur Manipulation von PowerPoint-Dateien
const asposeSlides = require('aspose.slides.via.net');

// Fügen Sie die erforderlichen Klassen aus asposeSlides hinzu
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Erstellen und speichern Sie eine leere Präsentation, um die grundlegende Funktionalität zu demonstrieren
function createEmptyPresentation() {
	
    // Initialisieren Sie eine neue leere Präsentation
    var emptyPresentation = new Presentation();
    
    // Speichern Sie die leere Präsentation im PPTX-Format
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Geben Sie die mit der Präsentation verbundenen Ressourcen frei
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Führen Sie die Funktion aus, um eine leere Präsentation zu erstellen
```
7. Führen Sie nun `node hello.js` @Befehlszeile aus, um es auszuführen.

### **Mac**

1. Installieren Sie .NET6 oder höher.
1. Installieren Sie Node.js (https://nodejs.org/en/download/) und fügen Sie node.exe zu `PATH` hinzu.
1. Installieren Sie edge-js.

$ mkdir aspose.slides.nodejs.net
 
$ cd aspose.slides.nodejs.net
 
$ npm install edge-js
```

```javascript
// Importieren Sie das Aspose.Slides-Modul zur Manipulation von PowerPoint-Dateien
const asposeSlides = require('aspose.slides.via.net');

// Fügen Sie die erforderlichen Klassen aus asposeSlides hinzu
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Erstellen und speichern Sie eine leere Präsentation, um die grundlegende Funktionalität zu demonstrieren
function createEmptyPresentation() {
	
    // Initialisieren Sie eine neue leere Präsentation
    var emptyPresentation = new Presentation();
    
    // Speichern Sie die leere Präsentation im PPTX-Format
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Geben Sie die mit der Präsentation verbundenen Ressourcen frei
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Führen Sie die Funktion aus, um eine leere Präsentation zu erstellen
```
9. Führen Sie nun `node hello.js` @Befehlszeile aus, um es auszuführen.